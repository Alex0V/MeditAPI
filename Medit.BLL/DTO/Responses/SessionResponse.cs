namespace Medit.BLL.DTO.Responses
{
    public class SessionResponse
    {
        public int Id { get; set; }
        public int SessionGroupId { get; set; }
        public string? SessionName { get; set; }
        public string? S3UrlAudio { get; set; }
        public string? Duration { get; set; }
    }
}
