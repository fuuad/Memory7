using System;
using System.Windows;
using System.Windows.Threading;

namespace Timer
{
    class Timer
    {
        /// <summary>
        /// De variablen worden hier aangemaakt. 
        /// </summary>
        private DispatcherTimer dt;
        private int increment = 0;
        private string timerLabel;

        /// <summary>
        /// In deze method word de timer aangemaakt en krijgt hij waardes mee.
        /// </summary>

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        /// <summary>
        /// Hier telt de timer op en krijgt hij zijn minuten en seconde counter.
        /// </summary>

        private void dtTicker(object sender, EventArgs e)
        {
            increment++;
            timerLabel = string.Format("{0:d2}:{1:d2}", increment / 60, increment % 60);

        }
        public void StopTimer()
        {
            dt.Stop();
        }

        /// <summary>
        /// Hier word de timer gestopt en gereset naar 0. begint dan weer met tellen.
        /// </summary>
        private void Resetbutton()

        {
            dt.Stop();
            increment = 0;
            TimerLabel.Content = string.Format("{0:d2}:{1:d2}", increment / 60, increment % 60);
            dt.Start();
        }

    }
}
