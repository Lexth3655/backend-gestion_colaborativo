using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Interfaces
{
    public interface IRepositoryRol
    {
        Task<Roles> GetByNameAsync(string nombreRol); // Método específico para buscar roles por nombre
    }
}
