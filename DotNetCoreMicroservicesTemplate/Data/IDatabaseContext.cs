using MongoDB.Driver;

namespace DotNetCoreMicroservicesTemplate.Data
{
    public interface IDatabaseContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
