using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class UpdatedLeaderboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IServersRepository _serversRepository;
        private List<UpdatedLeaderboardEntry> _cachedLeaderboard;
        private DateTime _lastGenerated;

        public UpdatedLeaderboardService(IUserRepository userRepository, IServersRepository serversRepository)
        {
            _userRepository = userRepository;
            _serversRepository = serversRepository;
            _cachedLeaderboard = new List<UpdatedLeaderboardEntry>();
            _lastGenerated = DateTime.MinValue;
        }

        public async Task<List<UpdatedLeaderboardEntry>> GetLeaderboardAsync()
        {
            if (DateTime.UtcNow - _lastGenerated > TimeSpan.FromDays(1))
            {
                await GenerateLeaderboardAsync();
            }
            return _cachedLeaderboard;
        }

        private async Task GenerateLeaderboardAsync()
        {
            var users = _userRepository.GetAllUsers();
            var servers = await _serversRepository.GetAllServersAsync();

            _cachedLeaderboard = users.Select(user => new UpdatedLeaderboardEntry
            {
                UserId = user.Id,
                Name = user.Name,
                ServerCount = servers.Count(s => s.UserId == user.Id),
                AllBytes = user.AllBytes // Assuming AllBytes is a property in User model
            })
            .OrderByDescending(entry => entry.ServerCount)
            .ThenByDescending(entry => entry.AllBytes)
            .ToList();

            _lastGenerated = DateTime.UtcNow;
        }
    }

    public class UpdatedLeaderboardEntry
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public int ServerCount { get; set; }
        public long AllBytes { get; set; }
    }
}
