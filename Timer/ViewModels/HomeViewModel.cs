using Caliburn.Micro;
using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;



namespace Timer.ViewModels
{

    // TODO: Re-enable Settings button
    public class HomeViewModel : Screen
    {
        TimeSpan oneSecond = TimeSpan.Parse("0:0:01");
        DispatcherTimer countdownTimer = new DispatcherTimer();
        TimeSpan _timeRemaining = TimeSpan.Parse("2:0:0");
        TimeSpan _warningTime = TimeSpan.Parse("0:0:15");
        private int _setHours;
        private int _setMinutes;
        private int _setSeconds;
        private string _startButtonText = "Start Timer";
        private string _settingsVisible = "Collapsed";
        private string _timerVisible = "Visible";

        public HomeViewModel()
        {
            countdownTimer.Interval = oneSecond;
            countdownTimer.Tick += CountdownTimer_Tick;

            ApplicationView.PreferredLaunchViewSize = new Size(350, 250);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(350, 250));

        }

        private void CountdownTimer_Tick(object sender, object e)
        {

            if (TimeRemaining < oneSecond)
            {
                countdownTimer.Stop();
            }
            else
            {
                TimeRemaining -= oneSecond;
            }

            if (TimeRemaining < WarningTime)
            {

            }
        }

        public TimeSpan WarningTime
        {
            get
            {
                return _warningTime;
            }
            set
            {
                _warningTime = value;
                NotifyOfPropertyChange(() => WarningTime);
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

        public int SetHours
        {
            get { return _setHours; }
            set
            {
                _setHours = value;
                NotifyOfPropertyChange(() => SetHours);
            }
        }

        public int SetMinutes
        {
            get { return _setMinutes; }
            set
            {
                _setMinutes = value;
                NotifyOfPropertyChange(() => SetMinutes);
            }
        }

        public int SetSeconds
        {
            get { return _setSeconds; }
            set
            {
                _setSeconds = value;
                NotifyOfPropertyChange(() => SetSeconds);
            }
        }
        public string StartButtonText
        {
            get
            {
                return _startButtonText;
            }
            set
            {
                _startButtonText = value;
                NotifyOfPropertyChange(() => StartButtonText);
            }
        }

        public string SettingsVisible
        {
            get { return _settingsVisible; }
            set
            {
                _settingsVisible = value;
                NotifyOfPropertyChange(() => SettingsVisible);
            }
        }

        public string TimerVisible
        {
            get { return _timerVisible; }
            set
            {
                _timerVisible = value;
                NotifyOfPropertyChange(() => TimerVisible);
            }
        }

        public void SetTime()
        {
            int hours = SetHours;
            int minutes = SetMinutes;
            int seconds = SetSeconds;

            TimeRemaining = TimeSpan.Parse($"{hours}:{minutes}:{seconds}");
            SettingsVisible = "Collapsed";
            TimerVisible = "Visible";
        }

        public void StartButton()
        {

            if (countdownTimer.IsEnabled == false)
            {
                // The countdown timer is not running
                countdownTimer.Start();
                StartButtonText = "Stop Timer";
            }
            else
            {
                countdownTimer.Stop();
                StartButtonText = "Start Timer";
            }

        }

        public void SettingsButton()
        {
            // Set timer selection to current time remaining
            SetHours = TimeRemaining.Hours;
            SetMinutes = TimeRemaining.Minutes;
            SetSeconds = TimeRemaining.Seconds;

            SettingsVisible = "Visible";
            TimerVisible = "Collapsed";
            
        }

        public void ExitButton()
        {
            Application.Current.Exit();
        }
    }
}
