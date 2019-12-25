using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    class League
    {
        #region Country
        public string country_id { get; set; }
        public string country_name { get; set; }
        #endregion

        public string league_id { get; set; }
        public string league_name { get; set; }
        public string league_season { get; set; }

        public override string ToString()
        {
            return $"Country: ID: {country_id}, Name: {country_name}\nLeague: Id: {league_id}, Name: {league_name}, season: {league_season}";
        }

    }
}
