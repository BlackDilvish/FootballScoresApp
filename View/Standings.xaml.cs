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
            InfoWriter.SetStandings(txtStandings, (int)state);
        }

        void InitLeaguesButtons()
        {
            foreach (var league in DataConverter.LeagueDictionary)
                cbLeagueBox.Items.Add(league.Key);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HomePage());
        }

        private void cbLeagueBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoWriter.SetStandings(txtStandings, (DataConverter.LeagueID(cbLeagueBox.SelectedItem.ToString())));
        }
    }
}
