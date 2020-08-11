namespace CrunchyAppBackend.Core.Entities
{
    public class Manga : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Chapters { get; set; }
        public bool IsComplete { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; }
    }
}