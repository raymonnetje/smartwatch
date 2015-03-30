using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Smartwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime currentTime;
        Boolean runningApp;
        TimeStateClient changeState;
        String timeformat = "HH:mm";

        public MainWindow()
        {
            InitializeComponent();
            runningApp = true;
            LabelState.Dispatcher.Invoke(() => LabelState.Opacity = 0);
            changeState = new TimeStateClient(new TwentyFourHoursFormat());
            Thread timeNow = new Thread(new ThreadStart(getCurrentTime));
            timeNow.Start();
        }

        public void getCurrentTime()
        {
            while (runningApp == true)
            {
                currentTime = Time._instance.getTime();
                writeTime(currentTime, timeformat);
                Thread.Sleep(2000);
            }
            
        }

        public void writeTime(DateTime currentTime, string timeformat)
        {
            try
            {
                labelTime.Dispatcher.Invoke(() => labelTime.Content = currentTime.ToString(timeformat));
                Label_Datum.Dispatcher.Invoke(() => Label_Datum.Content = currentTime.Day.ToString() + " " + getMonthName(currentTime.Month.ToString()));
                if ((timeformat == "hh:mm") && (currentTime.Hour >= 12))
                {
                    LabelState.Dispatcher.Invoke(() => LabelState.Content = "PM");
                }
                else if ((timeformat == "hh:mm") && (currentTime.Hour < 12))
                {
                    LabelState.Dispatcher.Invoke(() => LabelState.Content = "AM");
                }
            }
            catch (TaskCanceledException exception)
            {
                runningApp = false;
                Console.WriteLine(exception);
                
            }
        }

        public string getMonthName(string month)
        {
            switch (month)
            {
                case "1": return "Januari";
                case "2": return "Februari";
                case "3": return "Maart";
                case "4": return "April";
                case "5": return "Mei";
                case "6": return "Juni";
                case "7": return "Juli";
                case "8": return "Augustus";
                case "9": return "September";
                case "10": return "Oktober";
                case "11": return "November";
                case "12": return "December";
                default: return "N.B.";
            }
        }

        public void changeTimeFormat(string twelveOrtwentyfour)
        {
            if (twelveOrtwentyfour == "Smartwatch.TwelveHoursFormat")
            {
                LabelState.Dispatcher.Invoke(() => LabelState.Opacity = 100);
                timeformat = "hh:mm";
            }
            else
            {
                LabelState.Dispatcher.Invoke(() => LabelState.Opacity = 0);
                timeformat = "HH:mm";
            }
        }

        private void ButtonState_Click(object sender, RoutedEventArgs e)
        {
            changeState.Request();
            changeTimeFormat(changeState.State.ToString());
        }
    }
}
