using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class GoalScorer
    {
        public string time { get; set; }
        public string home_scorer { get; set; }
        public string score { get; set; }
        public string away_scorer { get; set; }
        public string info { get; set; }

        public GoalScorer Formated()
        {
            if(home_scorer != string.Empty)
                while (home_scorer.Length < 20)
                    home_scorer += " ";

            if (away_scorer != string.Empty)
                while (away_scorer.Length < 20)
                    away_scorer += " ";

            return this;
        }

        public override string ToString()
        {
            return $"{home_scorer+away_scorer}\tScore: {score}\tTime: {time}\'";
        }
    }
}
