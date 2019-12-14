namespace RetailBrandApi.Models
{
    public class RetailBrandDatabaseSettings : IRetailBrandDatabaseSettings
    {
        public string StyleCollectionName { get; set; }
        public string SkuCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
