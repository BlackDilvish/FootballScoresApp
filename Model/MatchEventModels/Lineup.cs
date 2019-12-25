using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    class Lineup
    {
        public TeamLineup home { get; set; }
        public TeamLineup away { get; set; }

        //public Lineup()
        //{
        //    home = new TeamLineup();
        //    away = new TeamLineup();
        //}

        public override string ToString()
        {
            return $"Home lineup: {home}\nAway lineup: {away}";
        }
    }
}
