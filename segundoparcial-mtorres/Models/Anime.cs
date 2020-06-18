using System;
namespace segundoparcial_mtorres.Models
{
    public class Anime
    {
        public Anime(){}

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Episodes { get; set; }
        public bool IsComplete { get; set; }
        public string ImageURL { get; set; }
    }
}
