using Microsoft.EntityFrameworkCore;
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using ParamoChallenge.Infrastructure.Data;

namespace ParamoChallenge.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ParamoDbContext _context;

        public ArticleRepository(ParamoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var currentArticle =await GetArticle(id);
            if (currentArticle != null)
            {
                _context.Articles.Remove(currentArticle);
                int row =await _context.SaveChangesAsync();
                return row>0;
            }
            return false;
        }

        public  async Task<Article> GetArticle(int id)
        {
            try {
                var result = await  _context.Articles.FirstOrDefaultAsync(x => x.IdArticle == id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            var results =await _context.Articles.ToListAsync();
            return results;
        }

        public async Task InsertArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateArticle(int id, Article article)
        {
            var currentArticle = await GetArticle(id);
            if (currentArticle != null)
            {
                currentArticle.Name = article.Name;
             
                int rows = await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        #region
        //valida
       

        #endregion
    }
}
