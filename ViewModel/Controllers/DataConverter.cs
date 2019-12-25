using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.ViewModel.Controllers
{
    static class DataConverter
    {
        static Dictionary<string, int> LeagueDictionary { get; set; }

        public static void InitDictionary()
        {
            LeagueDictionary = new Dictionary<string, int>
            {
                {"Premier League", 148 },
                {"Championship", 149 },
            };
        }

        public static int LeagueID(string name)
        {
            return LeagueDictionary[name];
        }
    }
}
