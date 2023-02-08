using ParamoChallenge.Core.Entities;

namespace ParamoChallenge.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<IProductQueryDto>> GetProducts();
        Task<Product> GetProduct(int id);
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
    }
}
