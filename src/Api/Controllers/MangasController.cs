using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrunchyAppBackend.Common.Pagination;
using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Core.Entities;

namespace CrunchyAppBackend.Controllers
{
    [Route("api/[controller]")]
    public class MangasController : ControllerBase
    {

        private readonly IMangaService _service;

        public MangasController(IMangaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manga>>> GetAll()
        {
            return Ok(await _service.Get());
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResult<Manga>>> GetPaginated(PaginatedRequest paginatedRequest)
        {
            return Ok(await _service.GetPaginatedList(paginatedRequest));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manga>> GetById(int id)
        {
            var result = await _service.Find(id);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<Anime>> GetByCategory(int id)
        {
            var result = await _service.Get(x => x.CategoryId.Equals(id), x => x.Category);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Manga newManga)
        {
            var result = await _service.Create(newManga);
            return result != null ? (IActionResult)CreatedAtAction(nameof(GetById), new { id = result.Id }, result) : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Manga manga)
        {
            var result = await _service.CreateOrUpdate(manga);
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