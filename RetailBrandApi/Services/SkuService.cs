using RetailBrandApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace RetailBrandApi.Services
{
    public class SkuService : RetailBrandType<Sku>
    {
        private readonly IMongoCollection<Sku> _sku;

        public SkuService(IRetailBrandDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sku = database.GetCollection<Sku>(settings.SkuCollectionName);
        }

        public override List<Sku> Get() =>
            _sku.Find(sku => true).ToList();

        public List<Sku> GetSkuByStyle(int StyleId)
        {
            return _sku.Find(sku => sku.StyleId == StyleId).ToList();
        }

        public override Sku Get(int SkuNumber)
        {
            return _sku.Find<Sku>(sku => sku.SkuNumber == SkuNumber).FirstOrDefault();
        }

        public override Sku Create(Sku sku)
        {
            _sku.InsertOne(sku);
            return sku;
        }

        public override void Update(Sku SkuIn)
        {
            _sku.ReplaceOne(sku => sku.SkuNumber == SkuIn.SkuNumber, SkuIn);
        }

        public override void Remove(Sku SkuIn)
        {
            _sku.DeleteOne(sku => sku.SkuNumber == SkuIn.SkuNumber);
        }

        public override void Remove(int SkuNumber)
        {
            _sku.DeleteOne(sku => sku.SkuNumber == SkuNumber);
        }
    }
}
