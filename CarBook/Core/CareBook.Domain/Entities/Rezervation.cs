namespace CareBook.Domain.Entities
{
    public class Rezervation
    {
        public int RezervationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Age { get; set; }
        public int DriverLicanseYear { get; set; }
        public string? Description { get; set; }

        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public string Status { get; set; }
    }
}
