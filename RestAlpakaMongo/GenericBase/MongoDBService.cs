using MongoDB.Driver;

namespace RestAlpakaMongo.GenericBase
{
    public abstract class MongoDbService<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        protected MongoDbService(IMongoClient client, IConfiguration config, string collectionName)
        {
            var database = client.GetDatabase(config["MongoDBConnection:Database"]);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }
    }
}
