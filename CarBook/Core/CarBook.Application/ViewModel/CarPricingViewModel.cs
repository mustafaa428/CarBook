namespace CarBook.Application.ViewModel
{
    public class CarPricingViewModel
    {
        public CarPricingViewModel()
        {
            Amounts = new List<decimal>();
        }
        public string Model { get; set; }
        public string name { get; set; }
        public string CoverImageUrl { get; set; }

        public List<decimal> Amounts { get; set; }
    }
}
