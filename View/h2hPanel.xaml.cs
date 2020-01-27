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
    public partial class h2hPanel : UserControl, ISwitchable
    {
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }


        public h2hPanel()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            var clubs = (ValueTuple<string, string>) state;

            FirstTeam = clubs.Item1;
            SecondTeam = clubs.Item2;

            SetHeaders();
            InfoWriter.SetH2H(spT1LastMatches, spT1vsT2LastMatches, spT2LastMatches, DataController.GetH2H(FirstTeam, SecondTeam));
        }

        public static void MatchBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var inline = (sender as TextBlock).Inlines.FirstInline;
            var inlineText = new TextRange(inline.ContentStart, inline.ContentEnd);

            int index = int.Parse(inlineText.Text.Split('#')[0]);

            if(DataController.GetEvent(int.Parse(DataConverter.LastLoadedMatches[index].match_id)) != null)
            {
                try
                {
                    Switcher.Switch(new MatchDescriptionPage(), DataConverter.LastLoadedMatches[index].match_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                };
            }
            else
                MessageBox.Show("Brak danych o meczu w bazie");

        }

        private void SetHeaders()
        {
            txtT1Name.Text = FirstTeam;
            txtT2Name.Text = SecondTeam;
            txtT1vsT2.Text = FirstTeam + " vs. " + SecondTeam;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FixturesPage(), (DateTime.Now.ToString("yyyy-MM-dd"), (DateTime.Now.ToString("yyyy-MM-dd"))));
        }
    }
}
