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
    /// Logika interakcji dla klasy h2hPanel.xaml
    /// </summary>
    public partial class h2hPanel : UserControl, ISwitchable
    {
        public h2hPanel()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            var clubs = (ValueTuple<string, string>) state;
            var h2hInfo = DataController.GetH2H(clubs.Item1, clubs.Item2);


            foreach (var match in h2hInfo.firstTeam_lastResults)
                spT1LastMatches.Children.Add(new TextBlock { Text = $"{match.match_hometeam_name + " vs " + match.match_awayteam_name}\n" });

            foreach (var match in h2hInfo.firstTeam_VS_secondTeam)
                spT1vsT2LastMatches.Children.Add(new TextBlock { Text = $"{match.match_hometeam_name + " vs " + match.match_awayteam_name}\n" });

            foreach (var match in h2hInfo.secondTeam_lastResults)
                spT2LastMatches.Children.Add(new TextBlock { Text = $"{match.match_hometeam_name + " vs " + match.match_awayteam_name}\n" });
        }
    }
}
