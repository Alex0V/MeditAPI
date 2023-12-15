namespace Medit.BLL.DTO.Responses
{
    public class MeditationResponse
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? S3UrlFoto { get; set; }
    }
}
