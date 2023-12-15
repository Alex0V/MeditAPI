using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Entities.HelpModel
{
    public class CombinedDataModel
    {
        public CompletedSession CompletedSession { get; set; }
        public Session Session { get; set; }
        public Meditation Meditation { get; set; }
        // Інші поля, якщо необхідно
    }
}
