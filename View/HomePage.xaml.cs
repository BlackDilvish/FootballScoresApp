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
    public partial class HomePage : UserControl, ISwitchable
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btnFixtures_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FixturesPage(), (DateTime.Now.ToString("yyyy-MM-dd"), (DateTime.Now.ToString("yyyy-MM-dd"))));
        }

        private void btnStandings_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new StandingsPage(), DataConverter.LeagueID("Premier League"));
        }

        private void btnClubInfo_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ClubInfo(), (DataConverter.LeagueID("Premier League"), 2611));
        }
    }
}
