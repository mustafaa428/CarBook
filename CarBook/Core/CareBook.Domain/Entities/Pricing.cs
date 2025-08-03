using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Pricing
    {
        [Key]
        public int PricingId { get; set; }
        public string Name { get; set; }
        public List<CarPricing> CarPricing { get; set; }
    }
}
