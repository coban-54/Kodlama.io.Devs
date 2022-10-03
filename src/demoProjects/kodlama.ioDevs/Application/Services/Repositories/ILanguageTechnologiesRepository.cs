using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ILanguageTechnologiesRepository : IAsyncRepository<LanguageTechnologies>, IRepository<LanguageTechnologies>
    {
    }
}
