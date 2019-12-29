using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class Statistic
    {
        public string type { get; set; }
        public string home { get; set; }
        public string away { get; set; }

        public override string ToString()
        {
            return $"{type} : home:{home} - away{away}";
        }

        public string FormatedType()
        {
            string temp = type;

            while (temp.Length < 42)
                temp += " ";

            return temp;
        }
    }
}
