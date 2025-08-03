using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
