using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
