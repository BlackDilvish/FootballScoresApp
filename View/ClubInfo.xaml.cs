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
        public ClubInfo()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            var clubInfo = (ValueTuple<int, int>) state;
            var loadedTeam = DataController.GetTeam(clubInfo.Item1, clubInfo.Item2)[0];

            InfoWriter.SetClubInfo(loadedTeam, txtTeamName, txtTeamInfo, imgBadge);
        }

        
    }
}
