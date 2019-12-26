using FootballScoresApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FootballScoresApp.ViewModel.Controllers
{
    public static class InfoWriter
    {
        public static string TeamStandingsHeader()
        {
            return "Poz\tNazwa\t\tRoz\tW\tD\tL\tPKT";
        }

        public static string PlayerInfoHeader()
        {
            return "\nName\t\t\tAge\tCountry\t\tNumber\tPosition\t\tPlayed\tGoals\tYC\tRC\n";
        }

        public static void SetClubInfo(Team team, TextBlock txtName, TextBlock txtDescription, Image imgBadge)
        {
            txtName.Text = team.ToString();
            SetDescription(team, txtDescription);
            SetBadge(team, imgBadge);

        }

        private static void SetDescription(Team team, TextBlock txtDescription)
        {
            foreach (var coach in team.coaches)
                txtDescription.Text = "Coach:\t" + coach.FullInfo();

            txtDescription.Text += PlayerInfoHeader();

            foreach (var player in team.players)
                txtDescription.Text += player.Formated().FullInfo();
        }

        private static void SetBadge(Team team, Image imgBadge)
        {
            imgBadge.Source = new BitmapImage(new Uri(team.team_badge, UriKind.Absolute));
        }
    }
}
