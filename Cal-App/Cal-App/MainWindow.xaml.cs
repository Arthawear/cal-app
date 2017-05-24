using CalApp.Models;
using CalApp.Storage;
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
        ////A timer for delay the hiding of the window resize grip, the header with year number and the settings sign
        //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        string savedSettingsFilePath = "SavedSettings.json";
        /// <summary>
        /// Implementing the application UI
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var yearModel = LoadSettings();
            this.DataContext = yearModel;
            ////sets the timer
            //dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            //sets the window size to different screens
            var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MaxHeight = screenHeight*4/5;
            //dispatcherTimer.Start();
        }
        /// <summary>
        /// Loads the YearModel from saved settings file, or initializes a new YearModel
        /// </summary>
        /// <returns>The saved or a new YearModel</returns>
        protected YearModel LoadSettings()
        {
            var yearModel = new YearModel(DateTime.Now.Year, true, CultureInfo.CurrentCulture.ToString(), true, 2,6, "Visible");
            try
            {
                var fileStorage = new FileStorage<object[]>();
                var settingsSaved = fileStorage.GetModel(savedSettingsFilePath);
                yearModel.Number = Convert.ToInt32(settingsSaved[0],CultureInfo.CurrentCulture);
                yearModel.Culture = (string)settingsSaved[1];
                yearModel.ViewColumnNumber = Convert.ToInt32(settingsSaved[2], CultureInfo.CurrentCulture);
                yearModel.IsEventOn = (bool)settingsSaved[3];
                yearModel.ShowHolidays = (bool)settingsSaved[4];
                yearModel.BackgroundColor = (string)settingsSaved[5];
                yearModel.Data = (string)settingsSaved[6];
                yearModel.ViewRowNumber = Convert.ToInt32(settingsSaved[7], CultureInfo.CurrentCulture);
                Left = Convert.ToDouble(settingsSaved[8], CultureInfo.CurrentCulture);
                Top = Convert.ToDouble(settingsSaved[9], CultureInfo.CurrentCulture);
                yearModel.SetTexts(yearModel.Culture);
                calendar.settings.SetYear(yearModel);
                for (int i = 0; i < yearModel.Items1.Count; i++)
                {
                    yearModel.Items1[i].SetNames(yearModel.Items1[i].Number, yearModel.Culture);
                    if (i == 1)
                    {
                        yearModel.Items1[i].GetNumberOfDays(yearModel.Items1[i].Number, yearModel.Number);
                    }
                    yearModel.Items1[i].ArrangeDays(yearModel.Number, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.ShowHolidays);
                    yearModel.Items1[i].IsEventOn = yearModel.IsEventOn;
                    yearModel.Items1[i].SetRowAndColumn(yearModel.Items1[i].Number, yearModel.ViewColumnNumber, yearModel.ViewRowNumber);
                }
                return yearModel;
            }
            catch (Exception)
            {
                return yearModel;
            }
        }
        /// <summary>
        /// Shows up the window resize grip, the header with year number and the settings sign  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            //dispatcherTimer.Stop();
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            calendar.yearPanel.Visibility = Visibility.Visible;
            calendar.set1.Visibility = Visibility.Visible;
            calendar.exitButton.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Sets a timer for hide the window resize grip, and the header 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!(calendar.settings.popLink.IsOpen || calendar.popEvent.IsOpen))
            {
                //dispatcherTimer.Start();
                this.ResizeMode = ResizeMode.NoResize;
                calendar.yearPanel.Visibility = Visibility.Hidden;
                calendar.set1.Visibility = Visibility.Hidden;
                calendar.exitButton.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Hides the window resize grip, and the header 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        ////public void DispatcherTimerTick(object sender, EventArgs e)
        ////{
        ////    this.ResizeMode = ResizeMode.NoResize;
        ////    calendar.yearPanel.Visibility = Visibility.Hidden;
        ////    calendar.set1.Visibility = Visibility.Hidden;
        ////    calendar.exitButton.Visibility = Visibility.Hidden;
        ////}
        /// <summary>
        /// Method for dragging the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            calendar.MovePopups();
            //this.dispatcherTimer.Start();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            calendar.MovePopups();
        }
    }
}

