using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Infrastructure.Data;
using CrunchyAppBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrunchyAppBackend.Application.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}