using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class CarDescription
    {
        [Key]
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Detail { get; set; }
    }
}
