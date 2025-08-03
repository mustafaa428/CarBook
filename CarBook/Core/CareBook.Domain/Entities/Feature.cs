using System.ComponentModel.DataAnnotations;

namespace CareBook.Domain.Entities
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public List<CarFeature> CarFeature { get; set; }
    }
}
