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
using FootballScoresApp.ViewModel;
using FootballScoresApp.ViewModel.Controllers;

namespace FootballScoresApp.View
{
    public partial class StandingsPage : UserControl, ISwitchable
    {
        public StandingsPage()
        {
            InitializeComponent();
            InitLeaguesButtons();
        }

        public void UtilizeState(object state)
        {
            SetTable((int) state);
        }

        void InitLeaguesButtons()
        {
            foreach (var league in DataConverter.LeagueDictionary)
            {
                var button = new Button { Content = league.Key };
                button.Click += new RoutedEventHandler(btnChangeLeague_Click);

                splLeaguesButtons.Children.Add(button);
            }
        }

        void SetTable(int leagueID)
        {
            txtStandings.Text = InfoWriter.TeamStandingsHeader() + "\n\n";

            foreach (var team in DataController.GetStandings(leagueID))
                txtStandings.Text += $"{team.ShortStandings()}\n";
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HomePage());
        }

        private void btnChangeLeague_Click(object sender, RoutedEventArgs e)
        {
            SetTable(DataConverter.LeagueID((sender as Button).Content.ToString()));
        }
    }
}
