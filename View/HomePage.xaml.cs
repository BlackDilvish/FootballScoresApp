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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var match in DataController.GetEvents("2019-12-29", "2019-12-29").Where(m => m.match_live.Equals("1")))
                tbxTemp.Text += match.match_hometeam_name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new StandingsPage(), DataConverter.LeagueID("Premier League"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ClubInfo(), (DataConverter.LeagueID("Premier League"), 2611));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FixturesPage(), (DateTime.Now.ToString("yyyy-MM-dd"), (DateTime.Now.ToString("yyyy-MM-dd"))));
        }
    }
}
