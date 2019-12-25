using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    class Statistic
    {
        public string type { get; set; }
        public string home { get; set; }
        public string away { get; set; }

        public override string ToString()
        {
            return $"{type} : home:{home} - away{away}";
        }
    }
}
