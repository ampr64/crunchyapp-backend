using System;
namespace CrunchyAppBackend.Core.Entities
{
    public class Category : IEntity
    {
        public Category() { }

        public Category(int id, string title, string description) => (Id, Title, Description) = (id, title, description);

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}