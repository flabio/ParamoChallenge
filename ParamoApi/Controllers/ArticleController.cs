using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParamoChallenge.Core.DTOs;
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using ParamoChallenge.Core.Responses;
using ParamoChallenge.Core.Services;
using ParamoChallenge.Core.Services.ConfigurationMsg;

namespace ParamoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper) {
            _articleService = articleService;
            _mapper= mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try { 
            var articles =await _articleService.GetArticles();
            var results = _mapper.Map<IEnumerable<ArticleDto>>(articles);
            return StatusCode(StatusCodes.Status200OK, new ResponseModel()
            {
                IsSuccessfull = true,
                Data = results
            });
        }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }

}
        [HttpPost]
        public async Task<IActionResult> Post(ArticleDto articleDto)
        {
            try
            {
                var article = _mapper.Map<Article>(articleDto);
                await _articleService.InsertArticle(article);
                articleDto = _mapper.Map<ArticleDto>(article);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = articleDto != null ? rscMessagasCommon.SuccessfulAdd : rscMessagasCommon.NotSuccessfulAdd,
                    Data = articleDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var result = await _articleService.GetArticle(id);
              
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message =null,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,ArticleDto articleDto)
        {
            try
            {
                var article = _mapper.Map<Article>(articleDto);
                var result =await _articleService.UpdateArticle(id,article);
                articleDto = _mapper.Map<ArticleDto>(article);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result != null ? rscMessagasCommon.SuccessfulUpdate : rscMessagasCommon.NotSuccessfulUpdate,
                    Data = articleDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Detele(int id)
        {
            try
            {
                var result = await _articleService.DeleteArticle(id);
               
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result != null ? rscMessagasCommon.SuccessfulRemove : rscMessagasCommon.NotSuccessfulRemove,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }
    }
}
