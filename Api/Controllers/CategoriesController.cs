using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using segundoparcial_mtorres.Common.Pagination;
using segundoparcial_mtorres.Contracts;
using segundoparcial_mtorres.Entities;

namespace segundoparcial_mtorres.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var result = await _service.Get();
            return result != null ? (ActionResult)Ok(result) : StatusCode(500);
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResult<Category>>> GetPaginated(PaginatedRequest paginatedRequest)
        {
            var result = await _service.GetPaginatedList(paginatedRequest);
            return result != null ? (ActionResult)Ok(result) : StatusCode(500);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var result = await _service.Find(id);
            return result != null ? (ActionResult)Ok(result) : StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category newCategory)
        {
            var result = await _service.Create(newCategory);
            return result != null ? (IActionResult)CreatedAtAction(nameof(GetById), new { id = result.Id }, result) : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category updatedCategory)
        {
            var result = await _service.CreateOrUpdate(updatedCategory);
            if (result.Equals(default))
            {
                return StatusCode(500);
            }

            return result.exists ? (IActionResult)Ok() : CreatedAtAction(nameof(GetById), new { id = result.entity.Id }, result.entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.Delete(id) ? (IActionResult)Ok() : BadRequest(400);
        }
    }
}