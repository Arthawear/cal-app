using CalApp.Models;
using CalApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //A timer for delay the hiding of the window resize grip, the header with year number and the settings sign
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            var yearModel= new YearModel(DateTime.Now.Year, false, CultureInfo.CurrentCulture.ToString(), false, 2, "Visible");
            this.DataContext = yearModel;
            //sets the timer
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            //sets the window size to different screens
            var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MaxHeight = screenHeight*4/5;
            
        }
        /// <summary>
        /// Shows up the window resize grip, the header with year number and the settings sign  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            dispatcherTimer.Stop();
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            calendar.yearPanel.Visibility = Visibility.Visible;
            calendar.set1.Opacity = 1;
        }
        /// <summary>
        /// Sets a timer for hide the window resize grip, the header with year number and the settings sign
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!(calendar.settings.popLink.IsOpen || calendar.popEvent.IsOpen ))
            {
                if (this.ResizeMode == ResizeMode.CanResizeWithGrip)
                {
                    dispatcherTimer.Start();
                }
            }
        }
        /// <summary>
        /// Hides the window resize grip, the header with year number and the settings sign
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        public void DispatcherTimerTick(object sender, EventArgs e)
        {
            this.ResizeMode = ResizeMode.NoResize;
            calendar.yearPanel.Visibility = Visibility.Collapsed;
            calendar.set1.Opacity = 0;
        }
        /// <summary>
        /// Method for dragging the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            this.DispatcherTimerTick(sender, e);
        }
    }
}

