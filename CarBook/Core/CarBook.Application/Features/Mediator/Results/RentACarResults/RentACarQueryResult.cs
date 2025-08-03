namespace CarBook.Application.Features.Mediator.Results.RentACarResults
{
    public class RentACarQueryResult
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
