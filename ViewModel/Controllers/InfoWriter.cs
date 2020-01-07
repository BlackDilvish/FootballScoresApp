using FootballScoresApp.Model;
using FootballScoresApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FootballScoresApp.ViewModel.Controllers
{
    public static class InfoWriter
    {
        #region Standings

        public static string TeamStandingsHeader()
        {
            return "Poz\tNazwa\t\tRoz\tW\tD\tL\tGoals\tPKT";
        }

        public static void SetStandings(TextBlock txtStandings, int leagueID)
        {
            txtStandings.Text = TeamStandingsHeader() + "\n\n";

            foreach (var team in DataController.GetStandings(leagueID))
                txtStandings.Text += $"{team.ShortStandings()}\n";
        }

        #endregion

        #region ClubInfo

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

        #endregion

        #region Fixtures

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to)
        {
            EditFixturesDateHeader(txtHeader, from, to);
            FillFixturesPanel(fixturesPanel, DataController.GetEvents(from, to));
        }

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to, int leagueID)
        {
            EditFixturesDateHeader(txtHeader, from, to);
            FillFixturesPanel(fixturesPanel, DataController.GetEvents(from, to, leagueID));
        }

        public static void SetFixtures(TextBlock txtHeader, StackPanel fixturesPanel, string from, string to, int leagueID, int teamID)
        {
            EditFixturesDateHeader(txtHeader, from, to);
            FillFixturesPanel(fixturesPanel, DataController.GetEvents(from, to, leagueID, teamID));
        }

        private static void EditFixturesDateHeader(TextBlock txtHeader, string from, string to)
        {
            if (from == to)
                txtHeader.Text = $"Fixtures from {from}";
            else
                txtHeader.Text = $"Fixtures from {from} to {to}";
        }

        private static void FillFixturesPanel(StackPanel fixturesPanel, List<MatchEvent> matches)
        {
            fixturesPanel.Children.Clear();
            int i = 0;

            foreach (var match in matches)
            {
                var matchInfo = new TextBlock();

                if (match.IsLive())
                {
                    matchInfo.Inlines.Add(new Run($"{i++}#| ") { Foreground = Brushes.Black });
                    matchInfo.Inlines.Add(new Run($"Live!") { Foreground = Brushes.Red });
                    matchInfo.Inlines.Add(new Run($" | {match.ToString()}" ) { Foreground = Brushes.Black });
                    matchInfo.PreviewMouseDown += FixturesPage.MatchBlock_PreviewMouseDown;
                }
                else
                {
                    matchInfo.Inlines.Add(new Run($"{i++}# {match.ToString()}") { Foreground = Brushes.Black });
                    matchInfo.PreviewMouseDown += FixturesPage.MatchBlock_PreviewMouseDown;
                }

                fixturesPanel.Children.Add(matchInfo);
            }

            DataConverter.LastLoadedEvents = new List<MatchEvent>(matches);
        }

        #endregion

        #region FixtureDescription

        public static void SetFixturesHeader(TextBlock t1Name, TextBlock t2Name, TextBlock txtResult, MatchEvent match)
        {
            t1Name.Text = match.match_hometeam_name;
            t2Name.Text = match.match_awayteam_name;

            var color = match.IsLive() ? Brushes.Red : Brushes.Gray;
            txtResult.Inlines.Clear();
            txtResult.Inlines.Add(new Run($"{match.match_hometeam_score}:{match.match_awayteam_score}") { Foreground = color });
        }

        public static void GetFullFixtureDescription(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            GetLineupInfo(t1Desc, t2Desc, match);
            GetGoalScorers(t1Desc, t2Desc, match);
            GetSubstitutions(t1Desc, t2Desc, match);
            GetCards(t1Desc, t2Desc, match);
            GetStatistics(t1Desc, t2Desc, match);
        }

        public static void GetExtraInfo(TextBlock extraDesc, MatchEvent match)
        {
            extraDesc.Inlines.Clear();
            var color = match.IsLive() ? Brushes.Red : Brushes.Black;

            extraDesc.Inlines.Add(new Run("Start: " + match.match_time + "\n"));
            extraDesc.Inlines.Add(new Run("Time: " + match.match_status + "\'\n") { Foreground = color });
            extraDesc.Inlines.Add(new Run("League: " + match.league_name + "\n"));
        }

        public static void GetGoalScorers(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            t1Desc.Text += HomeGoalScorers(match);
            t2Desc.Text += AwayGoalScorers(match);
        }

        public static void GetLineupInfo(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            t1Desc.Text += HomeLineupInfo(match);
            t2Desc.Text += AwayLineupInfo(match);
        }

        public static void GetSubstitutions(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            t1Desc.Text += HomeSubstitutions(match);
            t2Desc.Text += AwaySubstitutions(match);
        }

        public static void GetCards(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            t1Desc.Text += HomeCards(match);
            t2Desc.Text += AwayCards(match);
        }

        public static void GetStatistics(TextBlock t1Desc, TextBlock t2Desc, MatchEvent match)
        {
            if (match.statistics.Count == 0)
                return;

            t1Desc.Text += HomeStats(match);
            t2Desc.Text += AwayStats(match);
        }

        private static string HomeLineupInfo(MatchEvent match)
        {
            if (match.match_hometeam_system.Length > 0)
                return $"System: {match.match_hometeam_system}\n\n{match.lineup.home.LineupInfo()}";
            else
                return string.Empty;
        }

        private static string AwayLineupInfo(MatchEvent match)
        {
            if (match.match_awayteam_system.Length > 0)
                return $"System: {match.match_awayteam_system}\n\n{match.lineup.away.LineupInfo()}";
            else
                return string.Empty;
        }

        private static string HomeGoalScorers(MatchEvent match)
        {
            var scorers = match.goalscorer.Where(s => s.home_scorer.Length > 0).ToList();

            if (scorers.Count == 0)
                return string.Empty;

            if (scorers.Count > 0)
            {
                string output = "\nScorers:\n";

                foreach (var scorer in scorers)
                    output += $"{scorer.Formated().ToString()}\n";

                return output;
            }
            else
                return string.Empty;
        }

        private static string AwayGoalScorers(MatchEvent match)
        {
            var scorers = match.goalscorer.Where(s => s.away_scorer.Length > 0).ToList();

            if (scorers.Count > 0)
            {
                string output = "\nScorers:\n";

                foreach (var scorer in scorers)
                    output += $"{scorer.Formated().ToString()}\n";

                return output;
            }
            else
                return string.Empty;
        }

        private static string HomeSubstitutions(MatchEvent match)
        {
            if (match.substitutions.home.Count > 0)
            {
                string output = "\nSubstitutions: \n";

                foreach (var sub in match.substitutions.home)
                    output += $"{sub}\n";

                return output;
            }
            else
                return string.Empty;
        }

        private static string AwaySubstitutions(MatchEvent match)
        {
            if (match.substitutions.away.Count > 0)
            {
                string output = "\nSubstitutions: \n";

                foreach (var sub in match.substitutions.away)
                    output += $"{sub}\n";

                return output;
            }
            else
                return string.Empty;
        }

        private static string HomeCards(MatchEvent match)
        {
            var cards = match.cards.Where(c => c.home_fault.Length > 0).ToList();

            if (cards.Count == 0)
                return string.Empty;
            else
            {
                string output = "\nCards:\n";

                foreach (var card in cards)
                    output += $"{card.Formated()}\n";

                return output;
            }
        }

        private static string AwayCards(MatchEvent match)
        {
            var cards = match.cards.Where(c => c.away_fault.Length > 0).ToList();

            if (cards.Count == 0)
                return string.Empty;
            else
            {
                string output = "\nCards:\n";

                foreach (var card in cards)
                    output += $"{card.Formated()}\n";

                return output;
            }
        }

        private static string HomeStats(MatchEvent match)
        {
            string output = "\nHome statistics:\n";

            foreach (var stat in match.statistics)
                output += $"{stat.FormatedType()}\t: {stat.home}\n";

            return output;
        }

        private static string AwayStats(MatchEvent match)
        {
            string output = "\nAway statistics:\n";

            foreach (var stat in match.statistics)
                output += $"{stat.FormatedType()}\t: {stat.away}\n";

            return output;
        }

        #endregion

        #region H2H

        public static void SetH2H(StackPanel t1Matches, StackPanel t1VSt2Matches, StackPanel t2Matches, H2H h2h)
        {
            DataConverter.LastLoadedMatches = new List<Match>();

            FillMatchesPanel(t1Matches, h2h.firstTeam_lastResults);
            FillMatchesPanel(t1VSt2Matches, h2h.firstTeam_VS_secondTeam);
            FillMatchesPanel(t2Matches, h2h.secondTeam_lastResults);
        }

        private static void FillMatchesPanel(StackPanel panel, List<Match> matches)
        {
            panel.Children.Clear();
            int i = 0;

            foreach (var match in matches)
            {
                var matchInfo = new TextBlock();

                if (match.IsLive())
                {
                    matchInfo.Inlines.Add(new Run($"{DataConverter.LastLoadedMatches.Count + i++}#| ") { Foreground = Brushes.Black });
                    matchInfo.Inlines.Add(new Run($"Live!") { Foreground = Brushes.Red });
                    matchInfo.Inlines.Add(new Run($" | {match.ToString()}") { Foreground = Brushes.Black });
                    matchInfo.PreviewMouseDown += h2hPanel.MatchBlock_PreviewMouseDown;
                }
                else
                {
                    matchInfo.Inlines.Add(new Run($"{DataConverter.LastLoadedMatches.Count + i++}# {match.ToString()}") { Foreground = Brushes.Black });
                    matchInfo.PreviewMouseDown += h2hPanel.MatchBlock_PreviewMouseDown;
                }

                panel.Children.Add(matchInfo);
            }

            DataConverter.LastLoadedMatches.AddRange(matches);
        }

        #endregion
    }
}
