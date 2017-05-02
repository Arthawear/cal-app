
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
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var year = DateTime.Now.Year; ;
            var monthNr = DateTime.Now.Month;
            var monthModel = this.DataContext as MonthModel;
            if (year == monthModel.Year && monthNr == monthModel.Number)
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
            if (monthModel.Year%4==0&& button29.IsEnabled == false)
            {
                button29.IsEnabled = true;
            }
            var bigGrid = this.Parent as Grid;
        }
        private void Button_Click_Event(object sender, RoutedEventArgs e)
        {
            var grid = this.Parent as Grid;
            var year = grid.Parent as Year;
            var grid0 = year.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            if (calendar.popEvent.IsOpen == false)
            {
                calendar.popEvent.IsOpen = true;
            }
            Button button = new Button();
            button = (Button)e.OriginalSource;
            var googleCal = new GoogleCal();
            var dt = button.DataContext as MonthModel;
            var year1 = dt.Year;
            var monthNr = dt.Number;
            var day = (int)button.Content;
            var events = googleCal.GetEvents(year1, monthNr, day);
            var events1 = calendar.popEvent.Child as Events;
            events1.GoogleEvents.Text = String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), events);
        }
        private void Button_Click_Event1(object sender, RoutedEventArgs e)
        {
            var grid = this.Parent as Grid;
            var year = grid.Parent as Year;
            var grid0 = year.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            if (calendar.popEvent.IsOpen == false)
            {
                calendar.popEvent.IsOpen = true;
            }
            var googleCal = new GoogleCal();
            var year1 = DateTime.Now.Year; ;
            var monthNr = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var events = googleCal.GetEvents(year1, monthNr, day);
            var events1 = calendar.popEvent.Child as Events;
            events1.GoogleEvents.Text = String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), events);
        }
    }
}
