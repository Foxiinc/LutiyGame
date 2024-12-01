using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IServersRepository
    {
        Task<IEnumerable<Server>> GetAllServersAsync();
        Task<Server> GetServerByIdAsync(int id);
        Task AddServerAsync(Server server);
        Task UpdateServerAsync(Server server);
        Task DeleteServerAsync(int id);
    }
}
