using System;
namespace segundoparcial_mtorres.Entities
{
    public class Category : IEntityBase
    {
        public Category() { }

        public Category(int id, string title, string description) => (Id, Title, Description) = (id, title, description);

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}