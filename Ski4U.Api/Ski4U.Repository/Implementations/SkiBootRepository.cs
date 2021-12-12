using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class SkiBootRepository : ISkiBootRepository, IAsyncDisposable
    {
        private readonly AppDbContext _context;

        public SkiBootRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<IList<SkiBoot>> GetAllSkiBoots()
        {
            return await _context.SkiBoots.ToListAsync();
        }

        public async Task<IList<SkiBoot>> GetSkiBootByIds(IList<int> ids)
        {
            return await _context.SkiBoots.Where(s => ids.Contains(s.Id)).ToListAsync();
        }

        public async Task<SkiBoot> AddSkiBoot(SkiBoot skiBoot, CancellationToken cancellationToken)
        {
            _context.SkiBoots.Add(skiBoot);

            await _context.SaveChangesAsync(cancellationToken);

            return skiBoot;
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
