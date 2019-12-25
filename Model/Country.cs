using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoresApp.Model
{
    public class Country
    {
        public string country_id { get; set; }
        public string country_name { get; set; }

        public override string ToString()
        {
            return $"ID: {country_id}, Name: {country_name}";
        }
    }
}
