using Cal_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Cal_App
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
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid; 
            var year=grid.Children[1] as Year;
            var element = year.DataContext as Views.FrameworkElement;
            this.DataContext = element;
            //sets the timer
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            //sets the window size to different screens
            var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Height = screenHeight*4/5;
        }
        /// <summary>
        /// Sets the proper proportion of the window and font sizes when window size changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid;
            var year = grid.Children[1] as Year;
            var bigGrid = year.Content as Grid;
            var cols = bigGrid.ColumnDefinitions;
            var rows = bigGrid.RowDefinitions;
            if (cols.Count == 2 && rows.Count == 6)
            {
                Width = Height / 3;
            }
            else if (cols.Count == 4)
            {
                Width = Height * 4 / 3;
            }
            else if (cols.Count == 1 && rows.Count == 1)
            {
                Width = Height;
            }
            else if (cols.Count == 1 && rows.Count == 3)
            {
                Width = Height / 3;
            }
            FontSize = Width / (cols.Count * 15);
            calendar.showYearTxtBlock.FontSize = Height/15;
            calendar.yearPanel.Visibility = Visibility.Collapsed;
            this.ResizeMode = ResizeMode.NoResize;
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
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid;
            var year = grid.Children[1] as Year;
            var bigGrid = year.Content as Grid;
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
            var calendar = this.Content as Views.Calendar;
            if (!(calendar.popLink.IsOpen || calendar.popEvent.IsOpen))
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
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.ResizeMode = ResizeMode.NoResize;
            var calendar = this.Content as Views.Calendar;
            calendar.yearPanel.Visibility = Visibility.Collapsed;
            calendar.set1.Opacity = 0;
        }
    }
}

