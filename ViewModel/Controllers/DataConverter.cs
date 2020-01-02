using FootballScoresApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.ViewModel.Controllers
{
    static class DataConverter
    {
        public static Dictionary<string, int> LeagueDictionary { get; private set; }
        public static List<MatchEvent> LastLoadedEvents { get; set; }
        public static List<Match> LastLoadedMatches { get; set; }

        public static void InitDictionary()
        {
            LeagueDictionary = new Dictionary<string, int>
            {
                {"Premier League", 148 },
                {"Championship", 149 },
                {"English League One", 150 },
                {"Ligue 1", 176 },
                {"Ligue 2", 177 },
            };
        }

        public static int LeagueID(string name)
        {
            return LeagueDictionary[name];
        }
    }
}
