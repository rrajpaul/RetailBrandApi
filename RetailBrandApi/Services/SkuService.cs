using RetailBrandApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace RetailBrandApi.Services
{
    public class SkuService
    {
        private readonly IMongoCollection<Sku> _sku;

        public SkuService(IRetailBrandDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sku = database.GetCollection<Sku>(settings.SkuCollectionName);
        }

        public List<Sku> Get() =>
            _sku.Find(sku => true).ToList();

        public List<Sku> GetSkuByStyle(int StyleId) =>
            _sku.Find<Sku>(sku => sku.StyleId == StyleId).ToList();

        public Sku GetSku(int SkuNumber) =>
            _sku.Find<Sku>(sku => sku.SkuNumber == SkuNumber).FirstOrDefault();

        public Sku Create(Sku sku)
        {
            _sku.InsertOne(sku);
            return sku;
        }

        public void Update(Sku skuIn) =>
            _sku.ReplaceOne(sku => sku.SkuNumber == skuIn.SkuNumber, skuIn);

        public void Remove(Sku skuIn) =>
            _sku.DeleteOne(sku => sku.SkuNumber == skuIn.SkuNumber);

        public void Remove(int SkuNumber) =>
            _sku.DeleteOne(sku => sku.SkuNumber == SkuNumber);
    }
}
