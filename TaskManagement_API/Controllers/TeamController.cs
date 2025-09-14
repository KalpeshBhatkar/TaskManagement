using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
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
        protected APIResponse _response;

        public TeamController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTeams()
        {
            try
            {
                IEnumerable<Team> TeamsList = await _db.Teams.Where(t => t.IsDeleted == false).ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<TeamDTO>>(TeamsList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{TeamID:int}", Name = "GetTeamsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetTeamsById(int TeamID)
        {
            try
            {
                if (TeamID == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Id cannot be zero");
                    return BadRequest(_response);
                }
                var team = await _db.Teams.Where(t => t.IsDeleted == false && t.TeamID == TeamID).FirstOrDefaultAsync();
                if (team == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Data Not Found");
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<TeamDTO>(team);
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost(Name = "CreateTeams")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateTeams([FromBody] TeamCreateDTO teamCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (teamCreateDTO == null)
                {
                    return BadRequest(teamCreateDTO);
                }
                if (await _db.Teams.Where(t => t.TeamName == teamCreateDTO.TeamName).FirstOrDefaultAsync() != null)
                {
                    ModelState.AddModelError("CustomError", "Team Name Already Exists!");
                    return BadRequest(ModelState);
                }

                Team model = _mapper.Map<Team>(teamCreateDTO);
                model.CreatedDate = DateTime.Now;
                model.CreatedID = model.CreatedID;
                model.IsDeleted = false;
                await _db.Teams.AddAsync(model);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<TeamDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                //return _response;
                return CreatedAtAction("GetTeamsById", new { TeamId = model.TeamID }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{TeamID:int}", Name = "UpdateTeam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateTeam(int TeamID, [FromBody] TeamUpdateDTO teamUpdateDTO)
        {
            try
            {
                if (teamUpdateDTO == null || teamUpdateDTO.TeamID != TeamID)
                {
                    return BadRequest();
                }

                Team team = await _db.Teams.Where(t => t.IsDeleted == false && t.TeamID == TeamID).FirstOrDefaultAsync();

                if (team == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Team ID is Invalid");
                    return BadRequest(ModelState);
                }
                team.TeamName = teamUpdateDTO.TeamName;
                team.ModifiedID = teamUpdateDTO.ModifiedID;
                team.ModifiedDate = DateTime.Now;
                _db.Teams.Update(team);
                await _db.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{TeamID:int}/{UserID:long}", Name = "DeleteTeam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteTeam(int TeamID, int UserID)
        {
            try
            {
                if(TeamID == 0)
                {
                    return BadRequest();
                }
                Team team = await _db.Teams.Where(t => t.IsDeleted == false && t.TeamID == TeamID).FirstOrDefaultAsync();
                if (team == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Team ID is Invalid");
                    return BadRequest(ModelState);
                    //return NotFound();
                }
                team.DeletedID = UserID;
                team.DeletedDate = DateTime.Now;
                team.IsDeleted = true;
                _db.Teams.Update(team);
                await _db.SaveChangesAsync();
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }
    }
}
