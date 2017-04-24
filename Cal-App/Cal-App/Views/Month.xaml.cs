
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
                //button29.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click_Popup(object sender, RoutedEventArgs e)
        {
            var bigGrid = this.Parent as Grid;
            var year = bigGrid.Parent as Year;
            var grid1 = year.Parent as Grid;
            var popups = grid1.Children[0] as Popups;
            var grid2 = popups.Content as Grid;
            var popLink = grid2.Children[0] as Popup;
            if (popLink.IsOpen == false)
            {
                popLink.IsOpen = true;
            }
            else
            {
                popLink.IsOpen = false;
            }
        }
        public void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            set1.Opacity = 1;
        }
        public void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            set1.Opacity = 0;
        }
        private void Button_Click_Event(object sender, RoutedEventArgs e)
        {
            var bigGrid = this.Parent as Grid;
            var year = bigGrid.Parent as Year;
            var grid1 = year.Parent as Grid;
            var popups = grid1.Children[0] as Popups;
            var grid2 = popups.Content as Grid;
            var popLink = grid2.Children[0] as Popup;
            if (popups.isEventOn)
            {
                Button button = new Button();
                button = (Button)e.OriginalSource;
                var dt = button.DataContext as MonthModel;
                var year1 = dt.Year;
                var monthNr = dt.Number;
                var day = (int)button.Content ;
                var popEvent = grid2.Children[1] as Popup;
                popLink.IsOpen = false;
                var grid3 = popEvent.Child as Grid;
                var googleEvents = grid3.Children[0] as TextBlock;
                var googleCal = new GoogleCal();
                googleEvents.Text = String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), googleCal.GetEvents(year1, monthNr, day));
                if (popEvent.IsOpen == false)
                {
                    popEvent.IsOpen = true;
                }
            }
            popLink.IsOpen = false;
        }
        private void Button_Click_Event1(object sender, RoutedEventArgs e)
        {
            var bigGrid = this.Parent as Grid;
            var year = bigGrid.Parent as Year;
            var grid1 = year.Parent as Grid;
            var popups = grid1.Children[0] as Popups;
            var grid2 = popups.Content as Grid;
            var popLink = grid2.Children[0] as Popup;
            var popEvent= grid2.Children[1] as Popup;
            if (popups.isEventOn)
            {
                Button button = new Button();
                button = (Button)e.OriginalSource;
                var year1 = DateTime.Now.Year; ;
                var monthNr = DateTime.Now.Month;
                var day = DateTime.Now.Day;
                popLink.IsOpen = false;
                var grid3 = popEvent.Child as Grid;
                var googleEvents = grid3.Children[0] as TextBlock;
                var googleCal = new GoogleCal();
                googleEvents.Text = String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(year1, monthNr, day), googleCal.GetEvents(year1, monthNr, day));
                if (popEvent.IsOpen == false)
                {
                    popEvent.IsOpen = true;
                }
            }
            popLink.IsOpen = false;
        }
    }
}
