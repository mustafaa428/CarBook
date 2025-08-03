namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateBannerCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VidepDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
