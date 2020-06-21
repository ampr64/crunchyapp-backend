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
    public class CategoryController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return new List<Category>();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            return new Category();
        }

        [HttpPost]
        public void Create([FromBody]Category newCategory)
        {

        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Category updatedCategory)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
