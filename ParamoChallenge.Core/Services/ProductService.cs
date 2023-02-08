
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using ParamoChallenge.Core.Services.ConfigurationMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IArticleRepository _articleRepository;
        public ProductService(IProductRepository repository,IArticleRepository articleRepository )
        {
            _repository= repository;
            _articleRepository= articleRepository;
        }

        

        public async Task<Product> GetProduct(int id)
        {
            return await _repository.GetProduct(id);
        }

        public async Task<IEnumerable<IProductQueryDto>> GetProducts()
        {
           return await _repository.GetProducts();
        }

        public async Task InsertProduct(Product product)
        {
            await ArticleExistId(product);

            await _repository.InsertProduct(product);
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            await ArticleExistId(product);
            return await _repository.UpdateProduct(id, product);
        }
        public async Task<bool> DeleteProduct(int id)
        {
            return await _repository.DeleteProduct(id);
        }

        #region
        //method private

        private async Task ArticleExistId(Product product) {
            var article = await _articleRepository.GetArticle(product.IdArticle);
            if(article == null) {
                throw new Exception(string.Format(rscMessagasCommon.IdArticleNotExist, "IdArticle "));
            }
            
        }
        #endregion
    }
}
