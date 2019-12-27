using FootballScoresApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            SetClubDescription(team, txtDescription);
            SetClubBadge(team, imgBadge);
        }

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to)
        {
            if (from == to)
                txtHeader.Text = $"Fixtures from {from}";
            else
                txtHeader.Text = $"Fixtures from {from} to {to}";

            fixturesPanel.Children.Clear();

            foreach (var match in DataController.GetEvents(from, to))
            {
                var matchInfo = new TextBlock() { Text = match.ToString() };
                matchInfo.PreviewMouseDown += MatchBlock_PreviewMouseDown;

                fixturesPanel.Children.Add(matchInfo);
            }
        }

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to, int leagueID)
        {
            if (from == to)
                txtHeader.Text = $"Fixtures from {from}";
            else
                txtHeader.Text = $"Fixtures from {from} to {to}";

            fixturesPanel.Children.Clear();

            foreach (var match in DataController.GetEvents(from, to, leagueID))
            {
                var matchInfo = new TextBlock() { Text = match.ToString() };
                matchInfo.PreviewMouseDown += MatchBlock_PreviewMouseDown;

                fixturesPanel.Children.Add(matchInfo);
            }
        }

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to, int leagueID, int teamID)
        {
            if (from == to)
                txtHeader.Text = $"Fixtures from {from}";
            else
                txtHeader.Text = $"Fixtures from {from} to {to}";

            fixturesPanel.Children.Clear();

            foreach (var match in DataController.GetEvents(from, to, leagueID, teamID))
            {
                var matchInfo = new TextBlock() { Text = match.ToString() };
                matchInfo.PreviewMouseDown += MatchBlock_PreviewMouseDown;

                fixturesPanel.Children.Add(matchInfo);
            }
        }

        private static void SetClubDescription(Team team, TextBlock txtDescription)
        {
            foreach (var coach in team.coaches)
                txtDescription.Text = "Coach:\t" + coach.FullInfo();

            txtDescription.Text += PlayerInfoHeader();

            foreach (var player in team.players)
                txtDescription.Text += player.Formated().FullInfo();
        }

        private static void SetClubBadge(Team team, Image imgBadge)
        {
            imgBadge.Source = new BitmapImage(new Uri(team.team_badge, UriKind.Absolute));
        }

        private static void MatchBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as TextBlock).Text);
        }
    }
}
