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

        public MainWindow()
        {
            InitializeComponent();
            runningApp = true;
            Thread timeNow = new Thread(new ThreadStart(getCurrentTime));
            timeNow.Start();
            
            //Console.WriteLine(Time._instance.getTime());
        }

        public void getCurrentTime()
        {
            while (runningApp == true)
            {
                currentTime = Time._instance.getTime();
                Console.WriteLine(currentTime.ToString());
                Thread.Sleep(3000);
            }
            
        }
    }
}
