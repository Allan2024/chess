using System.Collections.Generic;

namespace ChessWebApi.Models
{
    public class Sponsor
    {
        public int sponsor_id { get; set; }  // Primary Key
        public string sponsor_name { get; set; }
        public string industry { get; set; }
        public string contact_email { get; set; }
        public string contact_phone { get; set; }

        public ICollection<PlayerSponsor> PlayerSponsors { get; set; }
    }
}
