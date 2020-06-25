using segundoparcial_mtorres.Contracts;
using segundoparcial_mtorres.DataLayer;
using segundoparcial_mtorres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.ServiceLayer
{
    public class MangaService : GenericService<Manga>, IMangaService
    {
        public MangaService(ApplicationDbContext context) : base(context)
        {
        }
    }
}