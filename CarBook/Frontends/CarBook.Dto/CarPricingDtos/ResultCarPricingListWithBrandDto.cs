namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithBrandDto
    {
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal monthlyAmount { get; set; }
    }
}
