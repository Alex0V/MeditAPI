using Medit.DAL.Context;
using Medit.DAL.Repositories.Base;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;

namespace Medit.DAL.Repositories
{
    public class MeditationRepository : GenericRepository<Meditation>, IMeditationRepository
    {
        public MeditationRepository(MeditDBContext dbContext) : base(dbContext){}


    }
}
