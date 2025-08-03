namespace CarBook.Dto.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int serviceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
    }
}
