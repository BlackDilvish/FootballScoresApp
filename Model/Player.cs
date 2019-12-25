using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    public class Player
    {
        public string player_key { get; set; }
        public string player_name { get; set; }
        public string player_number { get; set; }
        public string player_country { get; set; }
        public string player_type { get; set; }
        public string player_age { get; set; }
        public string player_match_played { get; set; }
        public string player_goals { get; set; }
        public string player_yellow_cards { get; set; }
        public string player_red_cards { get; set; }

        public override string ToString()
        {
            return player_name;
        }
    }
}
