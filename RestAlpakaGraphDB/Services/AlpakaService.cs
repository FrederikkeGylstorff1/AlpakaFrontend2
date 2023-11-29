using RestAlpaka.Model;
using WebApplication2.BaseComponents;

namespace WebApplication2.Services;

public class AlpakaService : Neo4jService<Alpaka>
{
    public AlpakaService(string neo4jUri, string neo4jUsername, string neo4jPassword)
        : base(neo4jUri, neo4jUsername, neo4jPassword)
    {
    }

    // You can add custom methods specific to Alpaka here
}