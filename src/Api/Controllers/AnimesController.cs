using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyAppBackend.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Common.Pagination;

namespace CrunchyAppBackend.Controllers
{
    [Route("api/[controller]")]
    public class AnimesController : Controller
    {
        private readonly IAnimeService _service;

        public AnimesController(IAnimeService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAll()
        {
            return Ok(await _service.Get(x => x.Category));
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResult<Anime>>> GetPaginated(PaginatedRequest paginatedRequest)
        {
            return Ok(await _service.GetPaginatedList(paginatedRequest, x => x.Category));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetById(int id)
        {
            var result = await _service.Find(id, x => x.Category);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<Anime>> GetByCategory(int id)
        {
            var result = await _service.Get(x => x.CategoryId.Equals(id));
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Anime newAnime)
        {
            var result = await _service.Create(newAnime);
            return result != null ? (IActionResult)CreatedAtAction(nameof(GetById), new { id = result.Id }, result) : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Anime updatedAnime)
        {
            var result = await _service.CreateOrUpdate(updatedAnime);
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