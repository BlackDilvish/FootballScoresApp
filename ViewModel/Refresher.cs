using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FootballScoresApp.ViewModel
{
    public static class Refresher
    {
        public static void AddRefresher(double cooldown, EventHandler handler)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(cooldown)
            };

            timer.Tick += handler;
            timer.Start();
        }
    }
}
