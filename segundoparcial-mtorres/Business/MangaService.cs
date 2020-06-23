using segundoparcial_mtorres.Contracts;
using segundoparcial_mtorres.DAL;
using segundoparcial_mtorres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Business
{
    public class MangaService : GenericService<Manga>, IMangaService
    {
        public MangaService(ApplicationDbContext context) : base(context)
        {
        }
    }
}