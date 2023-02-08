using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.Services
{
    public class ArticleService :IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

    

        public async Task<Article> GetArticle(int id)
        {
          return  await _articleRepository.GetArticle(id);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _articleRepository.GetArticles();
        }

        public async Task InsertArticle(Article article)
        {
            await _articleRepository.InsertArticle(article);
        }

     

        public async Task<bool> UpdateArticle(int id, Article article)
        {
            return await _articleRepository.UpdateArticle(id, article);
        }
        public async Task<bool> DeleteArticle(int id)
        {
            return await _articleRepository.DeleteArticle(id);
        }
    }
}
