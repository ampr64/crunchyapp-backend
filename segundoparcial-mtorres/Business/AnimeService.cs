using segundoparcial_mtorres.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Business
{
    public class AnimeService
    {
        private ApplicationDbContext _context;

        public AnimeService(ApplicationDbContext context) => _context = context;


    }
}