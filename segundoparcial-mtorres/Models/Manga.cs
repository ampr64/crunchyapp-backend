using System;
namespace segundoparcial_mtorres.Models
{
    public class Manga
    {
        public Manga() {}

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public int Chapters { get; set; }
        public bool IsComplete { get; set; }
        public string ImageURL { get; set; }
    }
}