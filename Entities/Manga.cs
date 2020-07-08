using System;
namespace segundoparcial_mtorres.Entities
{
    public class Manga : IEntityBase
    {
        public Manga() { }

        public Manga(int id, int categoryId, string title, string author, string description, int chapters, bool isComplete, string imageUrl)
            => (Id, CategoryId, Title, Author, Description, Chapters, IsComplete, ImageURL) = (id, categoryId, title, author, description, chapters, isComplete, imageUrl);

        public int Id { get; set; }
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