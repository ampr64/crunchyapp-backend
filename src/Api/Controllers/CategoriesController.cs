using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrunchyAppBackend.Common.Pagination;
using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Core.Entities;

namespace CrunchyAppBackend.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _service.Get());
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResult<Category>>> GetPaginated(PaginatedRequest paginatedRequest)
        {
            return Ok(await _service.GetPaginatedList(paginatedRequest));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var result = await _service.Find(id);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category newCategory)
        {
            var result = await _service.Create(newCategory);
            return result != null ? (IActionResult)CreatedAtAction(nameof(GetById), new { id = result.Id }, result) : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category updatedCategory)
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
            await _service.Delete(id);
            return NoContent();
        }
    }
}