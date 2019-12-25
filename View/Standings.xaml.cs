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
    /// <summary>
    /// Logika interakcji dla klasy Standings.xaml
    /// </summary>
    public partial class Standings : UserControl, ISwitchable
    {
        public Standings()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            int leagueID = (int)state;

            txtStandings.Text += Headers.TeamStandingsHeader() + "\n\n";

            foreach (var team in DataController.GetStandings(leagueID))
                txtStandings.Text += $"{team.ShortStandings()}\n";
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HomePage());
        }
    }
}
