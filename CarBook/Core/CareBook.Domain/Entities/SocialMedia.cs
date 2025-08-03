using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class SocialMedia
    {
        [Key]
        public int SocailMediaId { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public string Icon { get; set; }
    }
}
