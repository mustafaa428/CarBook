namespace CarBook.Dto.ReviewDtos
{
    public class GetReviewByCarIdDto
    {

        public int reviewId { get; set; }
        public string customerName { get; set; }
        public string customerImage { get; set; }
        public string comment { get; set; }
        public int raitingValue { get; set; }
        public DateTime reviewDate { get; set; }
        public int carId { get; set; }
    }
}
