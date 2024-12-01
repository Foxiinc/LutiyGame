using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;  
using System.Threading.Tasks;  

namespace Repositories
{
    public class ServersRepository : IServersRepository
    {
        private readonly ApplicationContext _context;

        public ServersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Server> GetServerByIdAsync(int id)
        {
            var server = await _context.Set<Server>().FindAsync(id);
            if (server == null)
            {
                throw new KeyNotFoundException($"Server with ID {id} not found.");
            }
            return server;
        }

        public async Task AddServerAsync(Server server)
        {
            await _context.Set<Server>().AddAsync(server);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServerAsync(Server server)
        {
            _context.Set<Server>().Update(server);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServerAsync(int id)
        {
            var server = await GetServerByIdAsync(id);
            if (server != null)
            {
                _context.Set<Server>().Remove(server);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Server>> GetAllServersAsync()
        {
            return await _context.Set<Server>().ToListAsync();
        }
    }
}
