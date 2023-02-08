using ParamoChallenge.Core.Entities;

namespace ParamoChallenge.Core.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int id);
        Task InsertArticle(Article article);
        Task<bool> UpdateArticle(int id, Article article);
        Task<bool> DeleteArticle(int id);
    }
}