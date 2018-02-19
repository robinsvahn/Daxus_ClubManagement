using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Daxus_FootballManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Team/")]
    [EnableCors("AnyOrigin")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamsRepository;

        public TeamController(ITeamRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teamsRepository.GetAllAsync());
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _teamsRepository.GetByIdAsync(id);
            if (team == null) return NotFound(id);

            return Ok(await _teamsRepository.GetByIdAsync(id));
        }

        // POST: api/Team
        [HttpPost]
        public async Task<IActionResult> Post(Team team)
        {
            if (team == null) return BadRequest();
            await _teamsRepository.AddAsync(team);
            return Ok($"Team {team.Name} {team.Name} was saved succesfully");
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Team team)
        {
            if (team == null) return BadRequest();
            if (await _teamsRepository.GetByIdAsync(id) == null) return BadRequest();

            await _teamsRepository.UpdateAsync(team);
            return Ok($"Team {team.Name} {team.Name} was updated succesfully");
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamsRepository.GetByIdAsync(id);
            if (team == null) return BadRequest();

            await _teamsRepository.DeleteAsync(team);
            return Ok($"Team {team.Name} {team.Name} was deleted succesfully");
        }
    }
}
