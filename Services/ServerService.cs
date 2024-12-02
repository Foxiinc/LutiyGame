using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class ServerService
    {
        private readonly IServersRepository _serversRepository;

        public ServerService(IServersRepository serversRepository)
        {
            _serversRepository = serversRepository;
        }

        public async Task<Server> GetServerById(int userid, int id)
        {
            return await _serversRepository.GetServerByIdAsync(id);
        }

        public async Task AddServerAsync(Server server)
        {
            await _serversRepository.AddServerAsync(server);
        }

        public async Task UpdateServerAsync(Server server)
        {
            await _serversRepository.UpdateServerAsync(server);
        }

        public async Task DeleteServerAsync(int id)
        {
            await _serversRepository.DeleteServerAsync(id);
        }

        public async Task<IEnumerable<Server>> GetAllServersAsync()
        {
            return await _serversRepository.GetAllServersAsync();
        }
    }
}
