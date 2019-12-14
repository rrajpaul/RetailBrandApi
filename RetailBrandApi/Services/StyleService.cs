using RetailBrandApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace RetailBrandApi.Services
{
    public class StyleService
    {
        private readonly IMongoCollection<Style> _styles;

        public StyleService(IRetailBrandDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _styles = database.GetCollection<Style>(settings.StyleCollectionName);
        }

        public List<Style> Get() =>
            _styles.Find(style => true).ToList();

        public Style Get(int id) =>
            _styles.Find<Style>(style => style.StyleId == id).FirstOrDefault();

        public Style Create(Style style)
        {
            _styles.InsertOne(style);
            return style;
        }

        public void Update(Style styleIn) =>
        _styles.ReplaceOne(style => style.StyleId == styleIn.StyleId, styleIn);


        public void Remove(Style styleIn) =>
            _styles.DeleteOne(style => style.StyleId == styleIn.StyleId);

        public void Remove(int id) =>
            _styles.DeleteOne(style => style.StyleId == id);
    }
}
