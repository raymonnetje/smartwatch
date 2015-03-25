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

        public MainWindow()
        {
            InitializeComponent();
            runningApp = true;
            changeState = new TimeStateClient(new AmFormat());
            Thread timeNow = new Thread(new ThreadStart(getCurrentTime));
            timeNow.Start();
        }

        public void getCurrentTime()
        {
            while (runningApp == true)
            {
                currentTime = Time._instance.getTime();
                writeTime(currentTime);
                //labelTime.Dispatcher.Invoke(() => labelTime.Content = currentTime.ToString());
                Thread.Sleep(3000);
            }
            
        }

        public void writeTime(DateTime currentTime)
        {
            try
            {
                labelTime.Dispatcher.Invoke(() => labelTime.Content = currentTime.ToString("hh:mm"));
            }
            catch (TaskCanceledException exception)
            {
                runningApp = false;
                Console.WriteLine(exception);
                
            }
        }

        public void changeTimeFormat(string amOrPm)
        {
            if (amOrPm == "Smartwatch.AmFormat")
            {
                LabelState.Content = "AM";
            }
            else
            {
                LabelState.Content = "PM";
            }
        }

        private void ButtonState_Click(object sender, RoutedEventArgs e)
        {
            changeState.Request();
            changeTimeFormat(changeState.State.ToString());
        }
    }
}
