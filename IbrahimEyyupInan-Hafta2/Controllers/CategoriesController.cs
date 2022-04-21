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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetCategory()
        {
            return Ok(await _categoryService.getListAsync());
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetCategory(int id)
        {
            var category = await _categoryService.findByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpGet("search")]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryBySearch([FromQuery] CategoryQuery query)
        {

            IEnumerable< CategoryViewModel> val = await _categoryService.getBySearchAsync(query);
            return Ok(val);

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {
            

            try
            {
                await _categoryService.updateAsync(id, category);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }    

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> PostCategory(CategoryDto category)
        {
            CategoryViewModel model = await _categoryService.createAsync(category);

            return CreatedAtAction("GetCategory", new { id = model.Id }, model);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.deleteAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
