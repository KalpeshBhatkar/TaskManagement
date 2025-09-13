using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement_API.Data;
using TaskManagement_API.Models;
using TaskManagement_API.Models.DTO;

namespace TaskManagement_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TeamController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeams()
        {
            IEnumerable<Team> TeamsList = await _db.Teams.Where(t => t.IsDeleted == false).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TeamDTO>>(TeamsList));
        }

        [HttpGet("{id:int}", Name = "GetTeamsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamDTO>> GetTeamsById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var team = await _db.Teams.Where(t => t.IsDeleted == false && t.TeamID == id).FirstOrDefaultAsync();
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
