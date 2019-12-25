using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class LineupPlayer
    {
        public string lineup_player { get; set; }
        public string lineup_number { get; set; }
        public string lineup_position { get; set; }

        public override string ToString()
        {
            return lineup_player;
        }
    }
}
