using ParamoChallenge.Core.Interfaces;

namespace ParamoChallenge.Core.Entities
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<IProductQueryDto>> GetProducts();
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);

    }
}