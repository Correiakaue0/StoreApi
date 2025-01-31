using Domain.Interfaces.Services;
using Domain.ViewModels.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin, user")]
    public class ProductController : ControllerBase
    {
        public IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productService.Get();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var products = _productService.GetById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductViewModel productViewModel)
        {
            try
            {
                _productService.Create(productViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ProductViewModel productViewModel)
        {
            try
            {
                _productService.Update(id, productViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}