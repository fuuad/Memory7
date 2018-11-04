using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// script voor timer functies
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// De variablen worden hier aangemaakt. 
        /// </summary>
        private static DispatcherTimer dt;
        private static int increment = 0;
        private static Label timerLabel;

        /// <summary>
        /// call
        /// </summary>
        /// <param name="TimerLabel"></param>
        public Timer(Label TimerLabel)
        {
            timerLabel = TimerLabel;
        }

        /// <summary>
        /// In deze method word de timer aangemaakt en krijgt hij waardes mee.
        /// </summary>
        public static void StartTimer()
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        /// <summary>
        /// Hier telt de timer op en krijgt hij zijn minuten en seconde counter.
        /// </summary>
        public static void dtTicker(object sender, EventArgs e)
        {
            increment++;
            timerLabel.Content = string.Format("{0:d2}:{1:d2}", increment / 60, increment % 60);
        }

        /// <summary>
        /// stopt de timer
        /// </summary>
        public static void StopTimer()
        {
            dt.Stop();
        }

        /// <summary>
        /// Hier word de timer gestopt en gereset naar 0. begint dan weer met tellen.
        /// </summary>
        public static void Resetbutton()
        {
            dt.Stop();
            increment = 0;
            timerLabel.Content = string.Format("{0:d2}:{1:d2}", increment / 60, increment % 60);
        }
    }
}
