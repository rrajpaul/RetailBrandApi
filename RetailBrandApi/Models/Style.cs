using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetailBrandApi.Models
{
    [BsonIgnoreExtraElements]
    public class Style
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id { get; set; }

        public int StyleId { get; set; }

        public string Manufacturer { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}
