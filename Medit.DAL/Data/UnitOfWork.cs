using Medit.DAL.Context;
using Medit.DAL.Interfaces;
using Medit.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly MeditDBContext context;

        public IUserRepository userRepository { get; }
        public ISessionRepository sessionRepository { get; }
        public ISessionGroupRepository sessionGroupRepository { get; }
        public ICompletedSessionRepository completedSessionRepository { get; }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();


        public UnitOfWork
        (
        MeditDBContext context,
        IUserRepository userRepository,
        ISessionRepository sessionRepository,
        ISessionGroupRepository sessionGroupRepository,
        ICompletedSessionRepository completedSessionRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.sessionRepository = sessionRepository;
            this.sessionGroupRepository = sessionGroupRepository;
            this.completedSessionRepository = completedSessionRepository;
        }
    }
}
