using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ISkiItemAttributeRepository : IRepository<SkiItemAttribute>
    {
        Task<IList<SkiItemAttribute>> GetAllSkiItemAttributesBySkiItemId(int skiItemId);
    }
}
