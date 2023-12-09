using Medit.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Entities.Base
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
