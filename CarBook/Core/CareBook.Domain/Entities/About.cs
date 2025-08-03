using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
