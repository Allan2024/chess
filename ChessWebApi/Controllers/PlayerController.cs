using Microsoft.AspNetCore.Mvc;
using ChessWebApi.Data;
using ChessWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ChessDbContext _context;

        public PlayersController(ChessDbContext context)
        {
            _context = context;
        }

        // Endpoint to get all players
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpGet("country/{country}")]
        public async Task<IActionResult> GetPlayersByCountry(string country)
        {
            var players = await _context.Players
                .Where(p => p.country == country)
                .OrderBy(p => p.current_world_ranking)
                .ToListAsync();

            return Ok(players);
        }

        [HttpGet("performance")]
        public async Task<IActionResult> GetPlayersPerformance()
        {
            var playerPerformances = await _context.Players
                .Select(p => new
                {
                    FullName = p.first_name + " " + p.last_name,
                    TotalMatchesPlayed = p.total_matches_played,
                    TotalMatchesWon = _context.Matches.Count(m => m.winner_id == p.player_id),
                    WinPercentage = p.total_matches_played == 0 ? 0 : (double)_context.Matches.Count(m => m.winner_id == p.player_id) / p.total_matches_played * 100
                })
                .ToListAsync();

            return Ok(playerPerformances);
        }

        [HttpGet("above-average-wins")]
        public async Task<IActionResult> GetPlayersAboveAverageWins()
        {
            var averageWins = await _context.Matches
                .GroupBy(m => m.winner_id)
                .Select(g => g.Count())
                .AverageAsync();

            var players = await _context.Players
                .Select(p => new
                {
                    FullName = p.first_name + " " + p.last_name,
                    TotalMatchesWon = _context.Matches.Count(m => m.winner_id == p.player_id),

                    WinPercentage = p.total_matches_played == 0 ? 0 : (double)_context.Matches.Count(m => m.winner_id == p.player_id) / p.total_matches_played * 100
                })
                .Where(p => p.TotalMatchesWon > averageWins)
                .ToListAsync();

            return Ok(players);
        }

        // Endpoint to add a new player
      
    }
}

