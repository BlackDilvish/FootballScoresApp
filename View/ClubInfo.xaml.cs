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

namespace FootballScoresApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy ClubInfo.xaml
    /// </summary>
    public partial class ClubInfo : UserControl, ISwitchable
    {
        private int CurrentClubId { get; set; } 

        public ClubInfo()
        {
            InitializeComponent();

            foreach (var league in DataConverter.LeagueDictionary)
                cbxLeagueBox.Items.Add(league.Key);

            cbxClubBox.IsEnabled = false;
            btnChangeClub.IsEnabled = false;
        }

        public void UtilizeState(object state)
        {
            var clubInfo = (ValueTuple<int, int>) state;
            var loadedTeam = DataController.GetTeam(clubInfo.Item1, clubInfo.Item2)[0];

            InfoWriter.SetClubInfo(loadedTeam, txtTeamName, txtTeamInfo, imgBadge);
        }

        private void cbxLeagueBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxClubBox.IsEnabled)
                cbxClubBox.Items.Clear();
            else
                cbxClubBox.IsEnabled = true;

            foreach (var team in DataController.GetTeams(DataConverter.LeagueID(cbxLeagueBox.SelectedItem as string)))
                cbxClubBox.Items.Add(team.team_name);
        }

        private void cbxClubBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnChangeClub.IsEnabled = true;

            if (cbxClubBox.SelectedItem == null)
                return;

            try
            {
                CurrentClubId = int.Parse(DataController.GetTeams(DataConverter.LeagueID(cbxLeagueBox.SelectedItem as string)).Where(t => t.team_name == (cbxClubBox.SelectedItem as string)).FirstOrDefault().team_key);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnChangeClub_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ClubInfo(), (DataConverter.LeagueID(cbxLeagueBox.SelectedItem as string), CurrentClubId));
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HomePage());
        }
    }
}
