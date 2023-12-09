using Medit.BLL.Models;

namespace MeditAPI.UtilityService
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}
