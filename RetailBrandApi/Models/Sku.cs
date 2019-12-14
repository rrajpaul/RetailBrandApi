using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetailBrandApi.Models
{
    public class Sku
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id { get; set; }

        public int StyleId { get; set; }

        public int SkuNumber { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public int InStock { get; set; }

        public double Price { get; set; }
    }
}
