using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class LanguageTechnologiesRepository : EfRepositoryBase<LanguageTechnologies, BaseDbContext>, ILanguageTechnologiesRepository
    {
        public LanguageTechnologiesRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
