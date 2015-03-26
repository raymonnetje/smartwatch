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
                //labelTime.Dispatcher.Invoke(() => labelTime.Content = currentTime.ToString());
                Thread.Sleep(2000);
            }
            
        }

        public void writeTime(DateTime currentTime, string timeformat)
        {
            try
            {
                labelTime.Dispatcher.Invoke(() => labelTime.Content = currentTime.ToString(timeformat));
            }
            catch (TaskCanceledException exception)
            {
                runningApp = false;
                Console.WriteLine(exception);
                
            }
        }

        public void changeTimeFormat(string twelveOrtwentyfour)
        {
            if (twelveOrtwentyfour == "Smartwatch.TwelveHoursFormat")
            {
                LabelState.Content = "TwelveHoursFormat";
                timeformat = "hh:mm";
            }
            else
            {
                LabelState.Content = "TwentyFourHoursFormat";
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
