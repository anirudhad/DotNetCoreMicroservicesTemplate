using DotNetCoreMicroservicesTemplate.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotNetCoreMicroservicesTemplate.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IDatabaseContext _context;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IDatabaseContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(string search)
        {
            var indexWildcardTextSearch = new CreateIndexModel<TEntity>(Builders<TEntity>.IndexKeys.Text("$**"));

            List<CreateIndexModel<TEntity>> indexes = new List<CreateIndexModel<TEntity>>();
            indexes.Add(indexWildcardTextSearch);

            _dbCollection.Indexes.CreateMany(indexes);

            var searchResult = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Text(search));
            return await searchResult.ToListAsync();
        }

        public virtual async Task<TEntity> Get(string id)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }

        public virtual async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
        }

        public async Task<bool> Update(TEntity obj)
        {
            var id = GetId(obj);
            var updateResult = await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), obj);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public virtual async Task<bool> Delete(string id)
        {
            var objectId = new ObjectId(id);
            var deleteResult = await _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        private BsonValue GetId(TEntity entity)
        {
            var bsonDoc = entity.ToBsonDocument();
            return bsonDoc.GetElement("_id").Value;
        }
    }
}
