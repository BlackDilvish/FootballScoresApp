using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    public class Team
    {
        public string team_key { get; set; }
        public string team_name { get; set; }
        public string team_badge { get; set; }
        
        public List<Player> players { get; set; }
        public List<Coach> coaches { get; set; }

        public Team()
        {
            players = new List<Player>();
            coaches = new List<Coach>();
        }

        public override string ToString()
        {
            return team_name;
        }
    }
}
