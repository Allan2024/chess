using System;

namespace ChessWebApi.Models
{
    public class PlayerSponsor
    {
        public int player_id { get; set; }
        public int sponsor_id { get; set; }
        public decimal sponsorship_amount { get; set; }
        public DateTime contract_start_date { get; set; }
        public DateTime contract_end_date { get; set; }

        public Player Player { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
