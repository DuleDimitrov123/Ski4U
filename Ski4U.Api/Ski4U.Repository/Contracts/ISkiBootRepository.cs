using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ISkiBootRepository
    {
        Task<IList<SkiBoot>> GetAllSkiBoots();

        Task<IList<SkiBoot>> GetSkiBootByIds(IList<int> ids);

        Task<SkiBoot> AddSkiBoot(SkiBoot skiBoot, CancellationToken cancellationToken);
    }
}
