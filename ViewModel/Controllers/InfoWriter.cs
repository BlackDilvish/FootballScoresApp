using FootballScoresApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FootballScoresApp.ViewModel.Controllers
{
    public static class InfoWriter
    {
        public static string TeamStandingsHeader()
        {
            return "Poz\tNazwa\t\tRoz\tW\tD\tL\tPKT";
        }

        public static void SetClubInfo(Team team, TextBlock txtName, TextBlock txtDescription, Image imgBadge)
        {
            txtName.Text = team.ToString();
        }
    }
}
