using Cal_App.Asset;
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
            var dayInt = DateTime.Now.Day;
            var dc = this.DataContext as MonthModel;
            if (year == dc.Year && monthNr == dc.Number)
            {
                CurrentDaySquare.Visibility = Visibility.Visible;
                CurrentDayButton.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentDaySquare.Visibility = Visibility.Hidden;
                CurrentDayButton.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_Popup(object sender, RoutedEventArgs e)
        {
            var month = this as UserControl;
            var bigGrid = month.Parent as Grid;
            var coll = bigGrid.Children;
            var grid1 = coll[0] as Grid;
            var popLink = grid1.Children[0] as Popup;
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
            var month = this as UserControl;
            var bigGrid = month.Parent as Grid;
            var ucYear = bigGrid.Parent as Year;
            var coll = bigGrid.Children;
            var grid1 = coll[0] as Grid;
            var popLink = grid1.Children[0] as Popup;
            if (ucYear.isEventOn)
            {
                Button button = new Button();
                button = (Button)e.OriginalSource;
                var dt = button.DataContext as MonthModel;
                var year = dt.Year;
                var monthNr = dt.Number;
                var day = button.Content as string;
                var dayInt = int.Parse(day);
                var popEvent = grid1.Children[1] as Popup;
                popLink.IsOpen = false;
                var grid2 = popEvent.Child as Grid;
                var googleEvents = grid2.Children[0] as TextBlock;
                var googleCal = new GoogleCal();
                googleEvents.Text = String.Format("Események\n {0:yyyy.MM.dd}\n\n{1}", new DateTime(year, monthNr, dayInt), googleCal.GetEvents(year, monthNr, dayInt));
                if (popEvent.IsOpen == false)
                {
                    popEvent.IsOpen = true;
                }
                //else
                //{
                //    popEvent.IsOpen = false;
                //}
            }
            popLink.IsOpen = false;
        }

        private void Button_Click_Event1(object sender, RoutedEventArgs e)
        {
            var month = this as UserControl;
            var bigGrid = month.Parent as Grid;
            var ucYear = bigGrid.Parent as Year;
            var coll = bigGrid.Children;
            var grid1 = coll[0] as Grid;
            var popEvent = grid1.Children[1] as Popup;
            var popLink = grid1.Children[0] as Popup;
            if (ucYear.isEventOn)
            {
                Button button = new Button();
                button = (Button)e.OriginalSource;
                //var dt = button.DataContext as MonthModel;
                var year = DateTime.Now.Year; ;
                var monthNr = DateTime.Now.Month;
                //var day = button.Content as string;
                var dayInt = DateTime.Now.Day;
                popLink.IsOpen = false;
                var grid2 = popEvent.Child as Grid;
                var googleEvents = grid2.Children[0] as TextBlock;
                var googleCal = new GoogleCal();
                googleEvents.Text = String.Format("Események\n {0:yyyy.MM.dd}\n\n{1}", new DateTime(year, monthNr, dayInt), googleCal.GetEvents(year, monthNr, dayInt));
                if (popEvent.IsOpen == false)
                {
                    popEvent.IsOpen = true;
                }
            }
            popLink.IsOpen = false;
        }


    }
}
