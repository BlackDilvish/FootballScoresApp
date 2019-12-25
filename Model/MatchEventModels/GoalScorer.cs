using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    class GoalScorer
    {
        public string time { get; set; }
        public string home_scorer { get; set; }
        public string score { get; set; }
        public string away_scorer { get; set; }
        public string info { get; set; }

        public override string ToString()
        {
            return $"{home_scorer+away_scorer} : {time}";
        }
    }
}
