using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace WebApplication2.BaseComponents
{
    public abstract class Neo4jService<T> where T : class
    {
        private readonly IGraphClient _graphClient;

        protected Neo4jService(string neo4jUri, string neo4jUsername, string neo4jPassword)
        {
            _graphClient = new GraphClient(new Uri(neo4jUri), neo4jUsername, neo4jPassword);
            _graphClient.ConnectAsync().Wait(); // Wait for connection to complete
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _graphClient.Cypher
                .Match($"(item:{typeof(T).Name})")
                .Return(item => item.As<T>());

            return (await query.ResultsAsync).ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var query = _graphClient.Cypher
                .Match($"(item:{typeof(T).Name})")
                .Where((T item) => item.GetType().GetProperty("Id").GetValue(item).ToString() == id.ToString()) // Use reflection to access Id property
                .Return(item => item.As<T>());

            return (await query.ResultsAsync).SingleOrDefault();
        }

        public async Task CreateAsync(T entity)
        {
            await _graphClient.Cypher
                .Create($"(item:{typeof(T).Name} {{entity}})")
                .WithParam("entity", entity)
                .ExecuteWithoutResultsAsync();
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            await _graphClient.Cypher
                .Match($"(item:{typeof(T).Name})")
                .Where((T item) => item.GetType().GetProperty("Id").GetValue(item).ToString() == id.ToString()) // Use reflection to access Id property
                .Set("item = {entity}")
                .WithParam("entity", entity)
                .ExecuteWithoutResultsAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");

            if (idProperty == null || idProperty.PropertyType != typeof(Guid))
            {
                throw new InvalidOperationException($"The entity {entityType.Name} does not have a valid Id property.");
            }

            var query = _graphClient.Cypher
                .Match($"(item:{typeof(T).Name})")
                .Where((T item) => (Guid)idProperty.GetValue(item) == id) // Use reflection to access Id property
                .Delete("item")
                .ExecuteWithoutResultsAsync();
        }
    }
}


