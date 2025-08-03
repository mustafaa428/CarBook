using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<Rezervation> PickUpRezervation { get; set; }
        public List<Rezervation> DropOffRezervation { get; set; }
    }
}
