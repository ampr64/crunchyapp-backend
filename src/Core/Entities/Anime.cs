namespace CrunchyAppBackend.Core.Entities
{
    public class Anime : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public bool IsComplete { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; }
    }
}