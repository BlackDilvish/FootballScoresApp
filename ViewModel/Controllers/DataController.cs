using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using FootballScoresApp.Model;
using Newtonsoft.Json;

namespace FootballScoresApp.ViewModel.Controllers
{
    class DataController
    {
        public static List<Country> GetCountries()
        {
            return new JavaScriptSerializer().Deserialize<List<Country>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_countries"));
        }

        public static List<League> GetLeagues()
        {
            return new JavaScriptSerializer().Deserialize<List<League>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_leagues"));
        }

        public static List<League> GetLeague(int countryID)
        {
            return new JavaScriptSerializer().Deserialize<List<League>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_leagues" + "&country_id=" + countryID));
        }

        public static List<Team> GetTeams(int leagueID)
        {
            return new JavaScriptSerializer().Deserialize<List<Team>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_teams&league_id=" + leagueID));
        }

        public static List<Team> GetTeam(int leagueID, int team_id)
        {
            return new JavaScriptSerializer().Deserialize<List<Team>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_teams&league_id=" + leagueID + $"&team_id={team_id}"));
        }

        public static List<TeamStandings> GetStandings(int leagueID)
        {
            return new JavaScriptSerializer().Deserialize<List<TeamStandings>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_standings&league_id=" + leagueID));
        }

        public static List<MatchEvent> GetEvents(string from, string to, int leagueID)
        {
            return new JavaScriptSerializer().Deserialize<List<MatchEvent>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_events&from=" + from + "&to=" + to + "&league_id=" + leagueID));
        }

        public static List<MatchEvent> GetEvent(string from, string to, int leagueID, int matchID)
        {
            return new JavaScriptSerializer().Deserialize<List<MatchEvent>>(RestClient.MakeRequest(@"https://apiv2.apifootball.com/?action=get_events&from=" + from + "&to=" + to + "&league_id=" + leagueID + "&match_id=" + matchID));
        }

    }
}
