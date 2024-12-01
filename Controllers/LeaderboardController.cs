using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace LutiyGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly UpdatedLeaderboardService _leaderboardService;

        public LeaderboardController(UpdatedLeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var leaderboard = await _leaderboardService.GetLeaderboardAsync();
            return Ok(leaderboard);
        }
    }
}
