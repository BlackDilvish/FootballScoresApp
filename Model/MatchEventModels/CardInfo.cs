using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model.MatchEventModels
{
    public class CardInfo
    {
        public string time { get; set; }
        public string home_fault { get; set; }
        public string card { get; set; }
        public string away_fault { get; set; }
        public string info { get; set; }

        public override string ToString()
        {
            return $"{home_fault+away_fault}\t{time}'\t{card}";
        }

        public CardInfo Formated()
        {
            if (home_fault.Length > 0)
                while (home_fault.Length < 20)
                    home_fault += " ";
            else
                while (away_fault.Length < 20)
                    away_fault += " ";

            return this;
        }
    }
}
