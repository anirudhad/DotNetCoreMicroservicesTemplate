using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreMicroservicesTemplate.Entities.Base
{
    public abstract class BaseEntity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        private DateTime? createdDate;
        private DateTime? modifiedDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate
        {
            get { return modifiedDate ?? DateTime.UtcNow; }
            set { modifiedDate = value; }
        }

        public BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
        }
    }
}
