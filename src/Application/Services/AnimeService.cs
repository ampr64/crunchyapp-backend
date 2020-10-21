using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Infrastructure.Data;
using CrunchyAppBackend.Core.Entities;

namespace CrunchyAppBackend.Application.Services
{
    public class AnimeService : GenericService<Anime>, IAnimeService
    {
        public AnimeService(ApplicationDbContext context) : base(context) { }
    }
}