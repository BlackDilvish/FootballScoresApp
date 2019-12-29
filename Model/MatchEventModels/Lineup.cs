using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class Lineup
    {
        public TeamLineup home { get; set; }
        public TeamLineup away { get; set; }

        public override string ToString()
        {
            return $"Home lineup: {home}\nAway lineup: {away}";
        }
    }
}
