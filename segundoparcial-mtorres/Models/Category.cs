using System;
namespace segundoparcial_mtorres.Models
{
    public class Category : IEntityBase
    {
        public Category()
        {
        }

        public Category(string title, string description) => (Title, Description) = (title, description);

        private Category(int id) => Id = id;

        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
