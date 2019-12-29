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

        public override string ToString()
        {
            string output = "Starting lineup: \n";

            foreach (var p in starting_lineups)
                output += p + " ";

            return output;
        }

        public string LineupInfo()
        {
            string output = "Starting lineup:\n\nName\t\t\tNumber\n";

            foreach (var p in starting_lineups)
                output += p.Formated().PlayerInfo();

            output += "\nSubstitutes:\n\n";

            foreach (var p in substitutes)
                output += p.Formated().PlayerInfo();

            output += "\nCoach:\t\t";

            foreach (var c in coach)
                output += $"{c.ToString()}\n";

            if(missing_players.Count > 0)
            {
                output += "\nMissing Players:\n\n";

                foreach (var p in missing_players)
                    output += p.Formated() + "\n";
            }

            return output;
        }
    }
}
