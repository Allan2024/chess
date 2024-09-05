using System;

namespace ChessWebApi.Models
{
    public class Match
    {
        public int match_id { get; set; } // Primary Key
        public int player1_id { get; set; } // Foreign Key
        public Player player1 { get; set; }
        public int player2_id { get; set; } // Foreign Key
        public Player player2 { get; set; }
        public DateTime match_date { get; set; }
        public string match_level { get; set; } // Check Constraint
        public int? winner_id { get; set; } // Nullable Foreign Key
        public Player Winner { get; set; }
    }
}
