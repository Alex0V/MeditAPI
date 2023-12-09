using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Models
{
    public class EmailModel
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public EmailModel(string to, string subject, string content)
        {
            this.To = to;
            this.Subject = subject;
            this.Content = content;
        }
    }
}
