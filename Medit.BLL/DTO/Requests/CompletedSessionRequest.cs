namespace Medit.BLL.DTO.Requests
{
    public class CompletedSessionRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public DateTime SessionСounter { get; set; }
    }
}
