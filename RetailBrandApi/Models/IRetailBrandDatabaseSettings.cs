namespace RetailBrandApi.Models
{
    public interface IRetailBrandDatabaseSettings
    {
        string StyleCollectionName { get; set; }
        string SkuCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
