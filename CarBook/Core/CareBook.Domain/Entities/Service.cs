using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
