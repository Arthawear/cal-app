
using Cal_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Cal_App.Views
{
    /// <summary>
    /// Interaction logic for Month.xaml
    /// </summary>
    public partial class Month : UserControl
    {
        public Month()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Loads the Month view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var monthModel = this.DataContext as MonthModel;
            Binding binding = new Binding();
            binding.Source = monthModel.BackgroundColour;
            path.SetBinding(Path.FillProperty, binding);
            if (monthModel.Year == DateTime.Now.Year && monthModel.Number == DateTime.Now.Month)
            {
                CurrentDaySquare.Visibility = Visibility.Visible;
                CurrentDayButton.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentDaySquare.Visibility = Visibility.Hidden;
                CurrentDayButton.Visibility = Visibility.Hidden;
            }
            if (monthModel.Days.Length<31)
            {
                button31.IsEnabled = false;
                button31.Visibility = Visibility.Hidden;
                if (monthModel.Days.Length < 30)
                {
                    button30.IsEnabled = false;
                    button30.Visibility = Visibility.Hidden;
                    if (monthModel.Days.Length < 29)
                    {
                        button29.IsEnabled = false;
                        button29.Visibility = Visibility.Hidden;
                    }
                }
            }
            if (monthModel.Number==2)
            {
                binding = new Binding();
                binding.Source = monthModel.Leap;
                button29.SetBinding(VisibilityProperty, binding);
                binding = new Binding();
                binding.Source = monthModel.IsEventOn;
                button29.SetBinding(IsEnabledProperty, binding);
            }
        }
        /// <summary>
        /// Opens the event popup, and asks for one day's events from google account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private async void Button_Click_EventAsync(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button = (Button)e.OriginalSource;
            var googleCal = new GoogleCal();
            var dt = button.DataContext as MonthModel;
            var year1 = dt.Year;
            var monthNr = dt.Number;
            var day = (int)button.Content;
            var events0 = googleCal.GetEvents(year1, monthNr, day);
            var grid = this.Parent as Grid;
            var year = grid.Parent as Year;
            var grid0 = year.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            if (calendar.popEvent.IsOpen == false)
            {
                calendar.popEvent.IsOpen = true;
            }
            calendar.eventsToCalendar.GoogleEvents.Text= String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), await events0);
        }
        /// <summary>
        /// Opens the event popup, and asks for the current day's events from google account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private async void Button_Click_Event1Async(object sender, RoutedEventArgs e)
        {
            var googleCal = new GoogleCal();
            var year1 = DateTime.Now.Year; ;
            var monthNr = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var events = googleCal.GetEvents(year1, monthNr, day);
            var grid = this.Parent as Grid;
            var year = grid.Parent as Year;
            var grid0 = year.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            if (calendar.popEvent.IsOpen == false)
            {
                calendar.popEvent.IsOpen = true;
            }
            calendar.eventsToCalendar.GoogleEvents.Text = String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), await events);
        }
    }
}
