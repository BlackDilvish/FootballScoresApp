﻿using System;
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
using FootballScoresApp.View;

namespace FootballScoresApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RestClient.InitRestClient();
            DataConverter.InitDictionary();

            Switcher.pageSwitcher = this;
            Switcher.Switch(new HomePage());
        }

        #region ChangingPages

        public void Navigate(UserControl nextPage)
        {
            Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }

        #endregion
    }
}
