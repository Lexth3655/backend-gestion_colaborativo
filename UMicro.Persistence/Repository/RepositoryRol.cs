using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Repository
{
    public class RepositoryRol : IRepositoryRol
    {
        private readonly DbContext _dbContext;

        public RepositoryRol(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Roles> GetByNameAsync(string nombreRol)
        {
            return await _dbContext.Set<Roles>()
                                   .FirstOrDefaultAsync(r => r.nombreRol == nombreRol);
        }
    }
}
