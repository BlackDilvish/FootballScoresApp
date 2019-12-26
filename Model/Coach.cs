using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    public class Coach
    {
        public string coach_name { get; set; }
        public string coach_country { get; set; }
        public string coach_age { get; set; }

        public override string ToString()
        {
            return coach_name;
        }

        public string FullInfo()
        {
            return $"{coach_name},\t{coach_age}\t({coach_country})\n";
        }
    }
}
