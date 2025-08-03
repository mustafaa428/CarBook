using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class FooterAddress
    {
        [Key]
        public int FooterAddressId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
