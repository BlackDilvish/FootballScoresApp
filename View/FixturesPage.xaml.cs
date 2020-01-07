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
    
    public partial class FixturesPage : UserControl, ISwitchable
    {
        private int CurrentClubId { get; set; }
        private string FromDate { get; set; }
        private string ToDate { get; set; }

        public FixturesPage()
        {
            InitializeComponent();
            LoadLeagues();

            Refresher.AddRefresher(10, RefreshResults);
        }

        public void UtilizeState(object state)
        {
            var dateRange = (ValueTuple<string, string>)state;

            FromDate = dateRange.Item1;
            ToDate = dateRange.Item2;

            InfoWriter.SetFixtures(txtDate, spFixturesCanvas, FromDate, ToDate);
        }

        public static void MatchBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var inline = (sender as TextBlock).Inlines.FirstInline;
            var inlineText = new TextRange(inline.ContentStart, inline.ContentEnd);

            int index = int.Parse(inlineText.Text.Split('#')[0]);

            try
            {
                Refresher.StopRefresher();
                Switcher.Switch(new MatchDescriptionPage(), DataConverter.LastLoadedEvents[index].match_id);        
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
            
        }

        private void LoadLeagues()
        {
            cbxClubBox.IsEnabled = false;

            cbxLeagueBox.Items.Add("Wszystkie");
            foreach (var league in DataConverter.LeagueDictionary.Keys)
                cbxLeagueBox.Items.Add(league);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpDateFrom.SelectedDate == null || dpDateTo.SelectedDate == null)
                MessageBox.Show("Wybierz datę", "Brak daty", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (cbxLeagueBox.SelectedItem == null || cbxLeagueBox.SelectedItem.ToString() == "Wszystkie")
                InfoWriter.SetFixtures(txtDate, spFixturesCanvas, FromDate, ToDate);
            else if (cbxClubBox.SelectedItem == null)
                InfoWriter.SetFixtures(txtDate, spFixturesCanvas, FromDate, ToDate, DataConverter.LeagueID(cbxLeagueBox.SelectedItem.ToString()));
            else
                InfoWriter.SetFixtures(txtDate, spFixturesCanvas, FromDate, ToDate, DataConverter.LeagueID(cbxLeagueBox.SelectedItem.ToString()), CurrentClubId);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Refresher.StopRefresher();
            Switcher.Switch(new HomePage());
        }

        private void cbxLeagueBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxLeagueBox.SelectedItem.ToString() == "Wszystkie")
            {
                cbxClubBox.Items.Clear();
                cbxClubBox.IsEnabled = false;
                return;
            }

            if (cbxClubBox.IsEnabled)
                cbxClubBox.Items.Clear();
            else
                cbxClubBox.IsEnabled = true;

            foreach (var team in DataController.GetTeams(DataConverter.LeagueID(cbxLeagueBox.SelectedItem as string)))
                cbxClubBox.Items.Add(team.team_name);
        }

        private void cbxClubBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxClubBox.SelectedItem == null)
                return;

            try
            {
                CurrentClubId = int.Parse(DataController.GetTeams(DataConverter.LeagueID(cbxLeagueBox.SelectedItem as string)).Where(t => t.team_name == (cbxClubBox.SelectedItem as string)).FirstOrDefault().team_key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dpDateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FromDate = dpDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd");

            dpDateTo.BlackoutDates.Clear();
            dpDateTo.SelectedDate = dpDateFrom.SelectedDate.Value;
            dpDateTo.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddYears(-200), dpDateFrom.SelectedDate.Value.AddDays(-1)));
        }

        private void dpDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDate = dpDateTo.SelectedDate.Value.ToString("yyyy-MM-dd");
        }

        private void RefreshResults(object sender, EventArgs e)
        {
            if (FromDate.Equals(DateTime.Now.ToString("yyyy-MM-dd")) && ToDate.Equals(DateTime.Now.ToString("yyyy-MM-dd")))
                InfoWriter.SetFixtures(txtDate, spFixturesCanvas, FromDate, ToDate);
        }
    }
}
