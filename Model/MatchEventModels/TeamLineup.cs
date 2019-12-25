using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class TeamLineup
    {
        public List<LineupPlayer> starting_lineups { get; set; }
        public List<LineupPlayer> substitutes { get; set; }
        public List<LineupPlayer> coach { get; set; }
        public List<LineupPlayer> missing_players { get; set; }

        //public TeamLineup()
        //{
        //    starting_lineups = new List<LineupPlayer>();
        //    substitutes = new List<LineupPlayer>();
        //    coach = new List<LineupPlayer>();
        //    missing_players = new List<LineupPlayer>();
        //}

        public override string ToString()
        {
            string output = "Starting lineup: ";

            foreach (var p in starting_lineups)
                output += $"{p}, ";

            output += "\nSubstitutes: ";

            foreach (var p in substitutes)
                output += $"{p}, ";

            output += "\nCoach: ";

            foreach (var p in coach)
                output += $"{p}, ";

            output += "\nMissing Players: ";

            foreach (var p in missing_players)
                output += $"{p}, ";

            return output;
        }
    }
}
