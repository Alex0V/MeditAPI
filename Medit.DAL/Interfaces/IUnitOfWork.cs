using Medit.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
        ISessionRepository sessionRepository { get; }
        ISessionGroupRepository sessionGroupRepository { get; }
        ICompletedSessionRepository completedSessionRepository { get; }
        Task SaveChangesAsync();
    }
}
