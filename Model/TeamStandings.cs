using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    class TeamStandings
    {
        public string country_name { get; set; }
        public string league_id { get; set; }
        public string league_name { get; set; }
        public string team_id { get; set; }
        public string team_name { get; set; }
        public string overall_league_position { get; set; }
        public string overall_league_payed { get; set; }
        public string overall_league_W { get; set; }
        public string overall_league_D { get; set; }
        public string overall_league_L { get; set; }
        public string overall_league_GF { get; set; }
        public string overall_league_GA { get; set; }
        public string overall_league_PTS { get; set; }
        public string home_league_position { get; set; }
        public string home_league_payed { get; set; }
        public string home_league_W { get; set; }
        public string home_league_D { get; set; }
        public string home_league_L { get; set; }
        public string home_league_GF { get; set; }
        public string home_league_GA { get; set; }
        public string home_league_PTS { get; set; }
        public string away_league_position { get; set; }
        public string away_league_payed { get; set; }
        public string away_league_W { get; set; }
        public string away_league_D { get; set; }
        public string away_league_L { get; set; }
        public string away_league_GF { get; set; }
        public string away_league_GA { get; set; }
        public string away_league_PTS { get; set; }

        

        public string ShortStandings()
        {
            FillName();

            return $"{overall_league_position}\t{team_name}\t{overall_league_payed}\t" +
                   $"{overall_league_W}\t{overall_league_D}\t{overall_league_L}\t" +
                   $"{overall_league_GF}:{overall_league_GA}\t{overall_league_PTS}";
        }

        public override string ToString()
        {
            return $"{team_name} : {overall_league_position}";
        }

        void FillName()
        {
            while (team_name.Length < 15)
                team_name += " ";
        }

    }
}
