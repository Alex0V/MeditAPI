namespace Medit.BLL.DTO.Requests
{
    public class MeditationRequest
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? S3UrlFoto { get; set; }
    }
}
