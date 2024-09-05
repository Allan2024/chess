namespace ChessWebApi.Models
{
    public class Player
    {
        public int player_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country { get; set; }
        public int current_world_ranking { get; set; }
        public int total_matches_played { get; set; }

        public ICollection<PlayerSponsor> PlayerSponsors { get; set; }
        public ICollection<Match> MatchesAsPlayer1 { get; set; }
        public ICollection<Match> MatchesAsPlayer2 { get; set; }
    }
}
