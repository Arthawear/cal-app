
using CalApp.Models;
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

namespace CalApp.Views
{
    /// <summary>
    /// Interaction logic for Month.xaml
    /// </summary>
    public partial class Month : UserControl
    {
        /// <summary>
        /// Implements a month UI
        /// </summary>
        public Month()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opens the event popup, and asks for one day's events from google account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private async void Button_Click_EventAsync(object sender, RoutedEventArgs e)
        {
            var yearModel = eventsToCalendar.DataContext as YearModel;
            yearModel.IsEventPopupOpen = true;
            Button button = new Button();
            button = (Button)e.OriginalSource;
            var googleCal = new GoogleCal();
            var monthModel = button.DataContext as MonthModel;
            var day = (int)button.Content;
            var events = googleCal.GetEvents(monthModel.Year, monthModel.Number, day);
            yearModel.EventsText= String.Format("        {0:yyyy.MM.dd}\n\n{1}", new DateTime(monthModel.Year, monthModel.Number, day), await events);
        }
    }
}
