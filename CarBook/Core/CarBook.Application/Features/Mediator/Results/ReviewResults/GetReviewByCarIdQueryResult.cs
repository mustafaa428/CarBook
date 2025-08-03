namespace CarBook.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByCarIdQueryResult
    {
        public int ReviewId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RaitingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
