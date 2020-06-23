using segundoparcial_mtorres.Contracts;
using segundoparcial_mtorres.DAL;
using segundoparcial_mtorres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Business
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}