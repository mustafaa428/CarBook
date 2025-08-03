using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }

        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        public List<CarFeature> CarFeature { get; set; }
        public List<CarDescription> CarDescription { get; set; }
        public List<CarPricing> CarPricing { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcces> RentACarProcces { get; set; }
        public List<Rezervation> Rezervations { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
