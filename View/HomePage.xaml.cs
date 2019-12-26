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
            tbxTemp.Text = string.Empty;

            //foreach (var country in DataController.GetCountries())
            //    tbxTemp.Text += country + "\n";

            foreach (var league in DataController.GetLeagues())
                tbxTemp.Text += league + "\n";

            foreach (var ev in DataController.GetEvent("2019-12-20", "2019-12-29", 149, 242383))
                tbxTemp.Text += ev + "\n";

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Standings(), DataConverter.LeagueID("Championship"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ClubInfo(), (148, 2611));
        }
    }
}
