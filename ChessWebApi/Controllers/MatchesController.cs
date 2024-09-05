using Microsoft.AspNetCore.Mvc;
using ChessWebApi.Data;
using ChessWebApi.Models;
using ChessWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ChessWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly ChessDbContext _context;

        public MatchesController(ChessDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddMatch([FromBody] MatchDto matchDto)
        {
            // Ensure that the matchDto object is valid
            if (matchDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the players by ID
            var player1 = await _context.Players.FindAsync(matchDto.Player1Id);
            var player2 = await _context.Players.FindAsync(matchDto.Player2Id);

            // Check if both players exist
            if (player1 == null || player2 == null)
            {
                return BadRequest("Both players must exist.");
            }

            // Create a new Match entity from the DTO
            var match = new Match
            {
                player1_id = matchDto.Player1Id,
                player2_id = matchDto.Player2Id,
                match_date = matchDto.MatchDate,
                match_level = matchDto.MatchLevel
            };

            // Add the new match to the context
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatchById), new { id = match.match_id }, match);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
    }
}
