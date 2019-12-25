using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class Substitutions
    {
        public List<Substitution> home { get; set; }
        public List<Substitution> away { get; set; }

        public override string ToString()
        {
            string output = string.Empty;

            foreach (var sub in home)
                output += $"{sub}\n";

            foreach (var sub in away)
                output += $"{sub}\n";

            return output;
        }
    }

}
