using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
