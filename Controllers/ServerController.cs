using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("api/{userid}")]
    public class ServerController : ControllerBase
    {
        private readonly ServerService _serverService;

        public ServerController(ServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet("serverid/{id}")]
        public ActionResult<Server> GetServerById(int userid, int id)
        {
            var server = _serverService.GetServerById(userid, id);
            if (server == null)
            {
                return NotFound();
            }
            return Ok(server);
        }
    }
}
