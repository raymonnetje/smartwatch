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
        String timeformat;
        Creator createFactory;
        Iterator tweetIterator;

        /// <summary>
        /// Initialize the variables
        /// Start a thread for getting the time from the singleton
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            createFactory = new Creator();
            timeformat = "HH:mm";
            runningApp = true;
            Thread timeNow = new Thread(new ThreadStart(getCurrentTime));
            timeNow.Start();
        }

        /// <summary>
        /// Get the time every 2 seconds while the app is running
        /// </summary>
        public void getCurrentTime()
        {
            while (runningApp == true)
            {
                currentTime = Time._instance.getTime();
                writeTime(currentTime, timeformat);
                Thread.Sleep(500);
            }
            
        }

        /// <summary>
        /// Write the current time in labelTime
        /// Write the current date in Label_Datum
        /// Checking when using am or pm in the if else statement 
        /// </summary>
        /// <param name="currentTime">The current time object</param>
        /// <param name="timeformat">The right time format string</param>
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
                else
                {
                    LabelState.Dispatcher.Invoke(() => LabelState.Content = "");
                }
            }
            catch (TaskCanceledException exception)
            {
                runningApp = false;
                Console.WriteLine(exception);
                
            }
        }

        /// <summary>
        /// Get by number of month the righteous month name
        /// </summary>
        /// <param name="month">number of month</param>
        /// <returns>Dutch month name</returns>
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

        /// <summary>
        /// Check if the state is 12 or 24 hour format.
        /// Change the variable timeformat for displaying the right timeformat.
        /// </summary>
        /// <param name="twelveOrtwentyfour">state in string</param>
        public void changeTimeFormat(string twelveOrtwentyfour)
        {
            if (twelveOrtwentyfour == "Smartwatch.TwelveHoursFormat")
            {
                timeformat = "hh:mm";
            }
            else
            {
                timeformat = "HH:mm";
            }
        }

        /// <summary>
        /// Change the state from 12 to 24 or 24 to 12 hour format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonState_Click(object sender, RoutedEventArgs e)
        {
            IWatch watchObj = createFactory.ReturnInstanceType();
            Console.WriteLine(watchObj.ToString());
            changeTimeFormat(watchObj.ToString());
        }

        /// <summary>
        /// Open the twitter block with tweets and display the next/ previous buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTwitter_Click(object sender, RoutedEventArgs e)
        {
            ButtonState.Visibility = System.Windows.Visibility.Hidden;
            Button_Twitter.Visibility = System.Windows.Visibility.Hidden;
            ButtonTwitterPrevious.Visibility = System.Windows.Visibility.Visible;
            ButtonTwitterNext.Visibility = System.Windows.Visibility.Visible;
            TwitterTextBox.Visibility = System.Windows.Visibility.Visible;

            tweetIterator = createFactory.ReturnTweets();
            

            TwitterTextBox.Text = tweetIterator.First().Message;
        }

        /// <summary>
        /// Go back to the clock view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            ButtonState.Visibility = System.Windows.Visibility.Visible;
            Button_Twitter.Visibility = System.Windows.Visibility.Visible;
            ButtonTwitterPrevious.Visibility = System.Windows.Visibility.Hidden;
            ButtonTwitterNext.Visibility = System.Windows.Visibility.Hidden;
            TwitterTextBox.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Show the previous tweet if exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTwitterPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (!tweetIterator.IsAtBegin)
            {
                Tweet _tempTweet = tweetIterator.Previous();
                if (_tempTweet != null)
                {
                    TwitterTextBox.Text = _tempTweet.Message;
                }
            }
            
        }

        /// <summary>
        /// Show the next tweet if exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTwitterNext_Click(object sender, RoutedEventArgs e)
        {
            if (!tweetIterator.IsAtEnd)
            {
                Tweet _tempTweet = tweetIterator.Next();
                if (_tempTweet != null)
                {
                    TwitterTextBox.Text = _tempTweet.Message;
                }
            }
        }
    }
}
