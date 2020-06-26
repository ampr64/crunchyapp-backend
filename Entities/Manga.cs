using System;
namespace segundoparcial_mtorres.Entities
{
    public class Manga : IEntityBase
    {
        public Manga() { }

        public Manga(int categoryId, string title, string author, string description, int chapters, bool isComplete, string imageUrl)
            => (CategoryId, Title, Author, Description, Chapters, IsComplete, ImageURL) = (categoryId, title, author, description, chapters, isComplete, imageUrl);

        private Manga(int id) => Id = id;

        public int Id { get; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Chapters { get; set; }
        public bool IsComplete { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; }

    }
}