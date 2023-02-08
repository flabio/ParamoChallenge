using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ParamoApi.Responses;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> Gets() {
            try {
                var results = await _productService.GetProducts();
               // var productDto = _mapper.Map<IEnumerable<ProductDto>>(results);
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
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _productService.InsertProduct(product);
                productDto = _mapper.Map<ProductDto>(product);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = productDto != null ? rscMessagasCommon.SuccessfulAdd : rscMessagasCommon.NotSuccessfulAdd,
                    Data = productDto
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
                var results = await _productService.GetProduct(id);
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Data = results
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
               var result=await _productService.UpdateProduct(id,product);
                productDto = _mapper.Map<ProductDto>(product);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result != null ? rscMessagasCommon.SuccessfulUpdate : rscMessagasCommon.NotSuccessfulUpdate,
                    Data = productDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = result,
                    Message = result ? rscMessagasCommon.SuccessfulRemove : rscMessagasCommon.NotSuccessfulRemove,
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

