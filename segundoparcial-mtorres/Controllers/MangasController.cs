using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using segundoparcial_mtorres.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace segundoparcial_mtorres.Controllers
{
    [Route("api/[controller]")]
    public class MangasController : Controller
    {

        [HttpGet]
        public async Task<IEnumerable<Manga>> GetAllAsync()
        {
            return new List<Manga>();
        }

        [HttpGet("{id}")]
        public async Task<Manga> GetByIdAsync(int id)
        {
            return new Manga();
        }

        [HttpPost]
        public void Create([FromBody]Manga newManga)
        {
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Manga updatedManga)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [HttpGet("category/{id}")]
        public async Task<IEnumerable<Manga>> GetByCategory(int categoryId)
        {
            return new List<Manga>();
        }
    }
}
