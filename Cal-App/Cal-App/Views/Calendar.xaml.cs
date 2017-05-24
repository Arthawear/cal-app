using CalApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        /// <summary>
        /// Implements a calendar
        /// </summary>
        public Calendar()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = yearToCalendar;
            settings.popLink.SetBinding(Popup.PlacementTargetProperty, binding);
        }
        /// <summary>
        /// Sets the previous year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickPrevYear(object sender, RoutedEventArgs e)
        {
            int yearNr = int.Parse(yearNumber.showYearTxtBlock.Text, CultureInfo.CurrentCulture);
            int prevYear = yearNr - 1;
            yearNumber.showYearTxtBlock.Text = prevYear.ToString(CultureInfo.CurrentCulture);
            var yearModel = DataContext as YearModel;
            yearModel.Number = prevYear;
            settings.SetYear(yearModel);
            if (yearModel.ViewColumnNumber == 1)
            {
                settings.ButtonComboClickViewThin(sender, e);
            }
        }
        /// <summary>
        /// Sets the next year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickNextYear(object sender, RoutedEventArgs e)
        {
            int yearNr = int.Parse(yearNumber.showYearTxtBlock.Text, CultureInfo.CurrentCulture);
            int nextYear = yearNr + 1;
            yearNumber.showYearTxtBlock.Text = nextYear.ToString(CultureInfo.CurrentCulture);
            var yearModel = DataContext as YearModel;
            yearModel.Number = nextYear;
            settings.SetYear(yearModel);
            if (yearModel.ViewColumnNumber == 1)
            {
                settings.ButtonComboClickViewThin(sender, e);
            }
        }
        /// <summary>
        /// Opens the Settings popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_Click_Popup(object sender, RoutedEventArgs e)
        {
            if (settings.popLink.IsOpen == false)
            {
                settings.popLink.IsOpen = true;
            }
            else
            {
                settings.popLink.IsOpen = false;
            }
        }
        /// <summary>
        /// Shuts down the Events popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickExitEvent(object sender, RoutedEventArgs e)
        {
            popEvent.IsOpen = false;
        }
        /// <summary>
        /// Shuts down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
        /// <summary>
        /// Moves popups with parent window
        /// </summary>
        internal void MovePopups()
        {
            if (popEvent.IsOpen)
            {
                popEvent.IsOpen = false;
                popEvent.IsOpen = true;
            }
            if (settings.popLink.IsOpen)
            {
                settings.popLink.IsOpen = false;
                settings.popLink.IsOpen = true;
            }
        }
    }
}
