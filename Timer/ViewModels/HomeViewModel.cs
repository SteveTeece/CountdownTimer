using Caliburn.Micro;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;


namespace Timer.ViewModels
{
    public class HomeViewModel : Screen
    {
        TimeSpan oneSecond = TimeSpan.Parse("0:0:01");
        DispatcherTimer countdownTimer = new DispatcherTimer();
        TimeSpan _timeRemaining;

        public HomeViewModel()
        {
            
            TimeRemaining = TimeSpan.Parse("2:0:0");

            countdownTimer.Interval = oneSecond;
            countdownTimer.Tick += CountdownTimer_Tick;

            ApplicationView.PreferredLaunchViewSize = new Size(300, 200);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(300, 200));

        }

        private void CountdownTimer_Tick(object sender, object e)
        {
            TimeRemaining -= oneSecond;
            
            if (TimeRemaining < oneSecond)
            {
                countdownTimer.Stop();
            }
        }

        public TimeSpan TimeRemaining
        {
            get { return _timeRemaining; }
            set
            {
                _timeRemaining = value;
                NotifyOfPropertyChange(() => TimeRemaining);
            }
        }

            private void SettingsButton(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }

        public List<string> Activities { get; set; }



        public void StartButton()
        {
            
            if (countdownTimer.IsEnabled == false)
            {
                // The countdown timer is not running
                countdownTimer.Start();

                // TODO: Change the text on the button to read "Stop Timer"
                
            }
            else
            {
                countdownTimer.Stop();

                // TODO: Change the text on the button to read "Start Timer"
            }

        }
    }
}
