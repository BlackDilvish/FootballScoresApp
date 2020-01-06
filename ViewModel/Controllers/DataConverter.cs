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
            var leagues = DataController.GetLeagues().Select(l => new { l.league_name, l.league_id }).ToList();

            if(leagues.Count < 5)
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
            else
            {
                LeagueDictionary = new Dictionary<string, int>();

                foreach (var league in leagues)
                {
                    if (LeagueDictionary.ContainsKey(league.league_name))                       
                        LeagueDictionary.Add(league.league_name + $" ({LeagueDictionary.Where(d => d.Key.Contains(league.league_name)).ToList().Count})", int.Parse(league.league_id));
                    else
                        LeagueDictionary.Add(league.league_name, int.Parse(league.league_id));
                }
            }

            
        }

        public static int LeagueID(string name)
        {
            return LeagueDictionary[name];
        }
    }
}
