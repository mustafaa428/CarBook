using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class CarPricing
    {
        [Key]
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }

    }
}
