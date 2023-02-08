using Microsoft.EntityFrameworkCore;
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using ParamoChallenge.Core.Responses;
using ParamoChallenge.Infrastructure.Data;

namespace ParamoChallenge.Infrastructure.Repositories
{
    public class ProductRepository :IProductRepository
    {
        private readonly ParamoDbContext _context;

        public ProductRepository(ParamoDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var result = await _context.Products.FirstOrDefaultAsync(x => x.IdProduct == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<IProductQueryDto>> GetProducts()
        {
            try {
                var result = await (from u in _context.Products
                                    select new ProductQuery()
                                    {
                                        IdProduct = u.IdProduct,
                                        IdArticle = u.IdArticle,
                                        Name = u.Name,
                                        Description = u.Description,
                                        ArticleName = u.IdArticleNavigation.Name,
                                        Date = u.Date,
                                        IsActive = u.IsActive

                                    }).ToListAsync<IProductQueryDto>();

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            try { 
                var currentProduct = await GetProduct(id);
                if (currentProduct != null)
                {
                    currentProduct.Name = product.Name;
                    currentProduct.Description = product.Description;
                    currentProduct.Date = product.Date;
                    currentProduct.IsActive = product.IsActive;
                    currentProduct.IdArticle = product.IdArticle;

                    int rows = await _context.SaveChangesAsync();
                    return rows>0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var currentProduct = await GetProduct(id);
            if (currentProduct != null)
            {
                _context.Products.Remove(currentProduct);
                int row = await _context.SaveChangesAsync();
                return row > 0;
            }
            return false;
        }
    }
}
