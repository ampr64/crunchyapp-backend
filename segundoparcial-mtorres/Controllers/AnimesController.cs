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
    public class AnimesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Anime>> GetAllAsync()
        {
            return new List<Anime>();
        }

        [HttpGet("{id}")]
        public async Task<Anime> GetByIdAsync(int id)
        {
            return new Anime();
        }

        [HttpPost]
        public void Create([FromBody]Anime newAnime)
        {
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Anime updatedAnime)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("/category/{id}")]
        public async Task<IEnumerable<Anime>> GetByCategory(int categoryId)
        {
            return new List<Anime>();
        }
    }
}