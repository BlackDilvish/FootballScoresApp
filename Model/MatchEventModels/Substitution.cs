using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class Substitution
    {
        public string time { get; set; }
        public string substitution { get; set; }

        public override string ToString()
        {
            return $"{time}\'\t-\t{substitution}";
        }
    }
}
