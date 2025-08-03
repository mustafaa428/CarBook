namespace CarBook.Dto.CarFeatureDtos
{
    public class GetCarFeatureByCarIdDto
    {
        public int carFeatureId { get; set; }
        public int featureId { get; set; }
        public object featureName { get; set; }
        public bool available { get; set; }
    }
}
