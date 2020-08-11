using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Infrastructure.Data;
using CrunchyAppBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrunchyAppBackend.Application.Services
{
    public class MangaService : GenericService<Manga>, IMangaService
    {
        public MangaService(ApplicationDbContext context) : base(context)
        {
        }
    }
}