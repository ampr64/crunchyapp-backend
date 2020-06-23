using System;
namespace segundoparcial_mtorres.Models
{
    public class Anime : IEntityBase
    {
        public Anime()
        {
        }

        public Anime(int categoryId, string title, string description, int episodes, bool isComplete, string imageUrl)
            => (CategoryId, Title, Description, Episodes, IsComplete, ImageURL) = (categoryId, title, description, episodes, isComplete, imageUrl);

        private Anime(int id) => Id = id;

        public int Id { get; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Episodes { get; set; }
        public bool IsComplete { get; set; }
        public string ImageURL { get; set; }
        public virtual Category Category { get; set; }
    }
}
