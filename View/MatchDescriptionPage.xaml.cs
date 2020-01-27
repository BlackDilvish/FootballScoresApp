using FootballScoresApp.ViewModel;
using FootballScoresApp.ViewModel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FootballScoresApp.View
{
    public partial class MatchDescriptionPage : UserControl, ISwitchable
    {
        int MatchID { get; set; }

        public MatchDescriptionPage()
        {
            InitializeComponent();
        }

        private void RefreshTime(object sender, EventArgs e)
        {
            var match = DataController.GetEvent(MatchID);

            InfoWriter.SetFixturesHeader(txtTeam1Name, txtTeam2Name, txtResult, match);
            InfoWriter.GetExtraInfo(txtExtraInfo, match);
        }

        public void UtilizeState(object state)
        {
            MatchID = int.Parse(state as string);
            var match = DataController.GetEvent(MatchID);

            InfoWriter.SetFixturesHeader(txtTeam1Name, txtTeam2Name, txtResult, match);
            InfoWriter.GetExtraInfo(txtExtraInfo, match);

            InfoWriter.GetFullFixtureDescription(txtTeam1Description, txtTeam2Description, match);

            if(match.match_live.Equals("1"))
                Refresher.AddRefresher(10, RefreshTime);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Refresher.StopRefresher();
            Switcher.Switch(new FixturesPage(), (DateTime.Now.ToString("yyyy-MM-dd"), (DateTime.Now.ToString("yyyy-MM-dd"))));
        }

        private void btnShowLineup_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetLineupInfo(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void ClearDescriptions()
        {
            txtTeam1Description.Text = string.Empty;
            txtTeam2Description.Text = string.Empty;
        }

        private void btnScorer_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetGoalScorers(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void btnSubs_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetSubstitutions(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void btnCards_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetCards(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetStatistics(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void btnAllInfo_Click(object sender, RoutedEventArgs e)
        {
            ClearDescriptions();
            InfoWriter.GetFullFixtureDescription(txtTeam1Description, txtTeam2Description, DataController.GetEvent(MatchID));
        }

        private void btnH2H_Click(object sender, RoutedEventArgs e)
        {
            var match = DataController.GetEvent(MatchID);

            Refresher.StopRefresher();
            Switcher.Switch(new h2hPanel(), (match.match_hometeam_name, match.match_awayteam_name));
        }

        private void btnStandings_Click(object sender, RoutedEventArgs e)
        {
            Refresher.StopRefresher();

            try
            {
                Switcher.Switch(new StandingsPage(), int.Parse(DataController.GetEvent(MatchID).league_id));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
