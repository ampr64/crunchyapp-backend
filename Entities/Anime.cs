using System;
namespace segundoparcial_mtorres.Entities
{
    public class Anime : IEntityBase
    {
        public Anime() { }

        public Anime(int id, int categoryId, string title, string description, int episodes, bool isComplete, string imageUrl)
            => (Id, CategoryId, Title, Description, Episodes, IsComplete, ImageURL) = (id, categoryId, title, description, episodes, isComplete, imageUrl);

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public bool IsComplete { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; }
    }
}