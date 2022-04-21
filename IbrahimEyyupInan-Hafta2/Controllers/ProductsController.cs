using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IbrahimEyyupInan_Hafta2.Data;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;
using IbrahimEyyupInan_Hafta2.Contracts.Service;
using IbrahimEyyupInan_Hafta2.Exceptions;
using IbrahimEyyupInan_Hafta2.Model.Query;

namespace IbrahimEyyupInan_Hafta2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly W2Context _context;
        private readonly IProductService _productService;

        public ProductsController(W2Context context, IProductService productService)
        {
            _context = context;
            _productService= productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProduct()
        {
            IEnumerable<ProductViewModel> products = await _productService.getListAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {

           var product = await _productService.findByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("search")]
        public async Task<ActionResult<ProductViewModel>> GetCategoryBySearch([FromQuery] ProductQuery query)
        {

            IEnumerable<ProductViewModel> val = await _productService.getBySearchAsync(query);
            return Ok(val);

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductUpdationDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                await _productService.updateAsync(id, product);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
            

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductCreationDto product)
        {
            ProductViewModel model = await _productService.createAsync(product);

            return CreatedAtAction("GetProduct", new { id = model.Id }, model);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.deleteAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }


            return NoContent();
        }

        
    }
}
