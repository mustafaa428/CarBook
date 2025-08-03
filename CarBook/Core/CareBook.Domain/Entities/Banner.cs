using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VidepDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
