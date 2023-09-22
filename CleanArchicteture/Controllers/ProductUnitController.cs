using Microsoft.AspNetCore.Mvc;
using ProductUnitAplication.Dtos;
using ProductUnitAplication.Interfaces;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Models;

namespace CleanArchicteture.Controllers
{
    public class ProductUnitController : Controller
    {
        private readonly IProductUnitAppServices _services;

        public ProductUnitController(IProductUnitAppServices services)
        {
            _services = services;
        }

        [HttpPost()]
        [Route("/Insert")] 
        public async Task<ActionResult> Insert([FromBody] ProductUnitDto dto)
        {
            var result = await _services.Insert(dto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpDelete()]
        [Route("/Delete/{id}")]
        public async Task<ActionResult> Insert(string id)
        {
            var result = await _services.Delete(id);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost()]
        [Route("/Update")]
        public async Task<ActionResult> Update([FromBody] ProductUnitDto dto)
        {
            var result = await _services.Update(dto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpGet()]
        [Route("/Get/{id}")]
        public async Task<ActionResult<ProductUnitDto>> Get(string id)
        {
            var result = await _services.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet()]
        [Route("/Query")]
        public async Task<ActionResult<List<ProductUnitDto>>> Query()
        {
            var result = await _services.Query();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

    }
}
