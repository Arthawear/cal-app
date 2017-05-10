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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = settings.yearTxtBox;
            binding.Path = new PropertyPath("Text");
            binding.Mode = BindingMode.TwoWay;
            showYearTxtBlock.SetBinding(TextBlock.TextProperty, binding);
            binding = new Binding();
            binding.Source = this;
            binding.Path = new PropertyPath("DataContext");
            binding.Mode = BindingMode.TwoWay;
            yearToCalendar.SetBinding(DataContextProperty, binding);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            int currentMonth = DateTime.Now.Month;
            //for the three months view in case if the current month is January or December - the third or the first month in the view is in different year 
            if (yearToCalendar.YearNumber == DateTime.Now.Year && (currentMonth == 1 || currentMonth == 12))
            {
                var grids = yearToCalendar.bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    var month = yearToCalendar.bigGrid.Children[i] as Month;
                    var monthModel = month.DataContext as MonthModel;
                    MonthModel current = new MonthModel(monthModel.Number, monthModel.Year, yearToCalendar.ShowHolidays, monthModel.Culture, monthModel.IsEventOn);
                    month.DataContext = current;
                }
            }
            else
            yearToCalendar.RunYear(yearToCalendar.YearNumber, yearToCalendar.Culture, yearToCalendar.IsEventOn);
            if (yearToCalendar.Culture == "hu-HU" || yearToCalendar.Culture == "HU")
            {
                settings.yearContent.Text = "Év";
                settings.languageContent.Content = "Nyelv";
                settings.viewContent.Content = "Nézet";
                settings.backgroundContent.Content = "Háttér";
                settings.eventContent.Text = "Események";
                settings.weekEndContent.Text = "Hétvégék";
                settings.printContent.Text = "Nyomtatás";
                settings.exitContent.Text = "Kilépés";
                eventsToCalendar.eventPopupContent.Text = "Események";
                settingsContent.Text = "Beállítások";
            }
            else
            {
                settings.yearContent.Text = "Year";
                settings.languageContent.Content = "Language";
                settings.viewContent.Content = "View";
                settings.backgroundContent.Content = "Background";
                settings.eventContent.Text = "Events";
                settings.weekEndContent.Text = "Weekends";
                settings.printContent.Text = "Print";
                settings.exitContent.Text = "Exit";
                eventsToCalendar.eventPopupContent.Text = "Events";
                settingsContent.Text = "Settings";
            }
        }
        /// <summary>
        /// Sets the previous year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickPrevYear(object sender, RoutedEventArgs e)
        {
            int yearNr = int.Parse(showYearTxtBlock.Text);
            int prevYear = yearNr - 1;
            showYearTxtBlock.Text = prevYear.ToString();
            yearToCalendar.YearNumber = prevYear;
            UserControl_Loaded(sender, e);
            var cols = yearToCalendar.bigGrid.ColumnDefinitions;
            var rows = yearToCalendar.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                settings.Button_comboClickViewThin(sender, e);
            }
            var monthModel = yearToCalendar.grid2.DataContext as MonthModel;
            Binding binding = new Binding();
            binding.Source = monthModel.Leap;
            yearToCalendar.grid2.button29.SetBinding(VisibilityProperty, binding);
            binding = new Binding();
            binding.Source = monthModel.IsEventOn;
            yearToCalendar.grid2.button29.SetBinding(IsEnabledProperty, binding);
            //sets the view combos, if other year than the current, the one month view and the three months view is disabled
            int currentYear = DateTime.Now.Year;
            if (yearToCalendar.YearNumber != currentYear)
            {
                settings.currentCombo.Visibility = Visibility.Collapsed;
                settings.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                settings.currentCombo.Visibility = Visibility.Visible;
                settings.threeMonthCombo.Visibility = Visibility.Visible;
            }
            ////var window = this.Parent as Window;
            ////window.ResizeMode = ResizeMode.NoResize;
            ////set1.Opacity = 0;
        }
        /// <summary>
        /// Sets the next year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickNextYear(object sender, RoutedEventArgs e)
        {
            int yearNr = int.Parse(showYearTxtBlock.Text);
            int nextYear = yearNr + 1;
            showYearTxtBlock.Text = nextYear.ToString();
            yearToCalendar.YearNumber = nextYear;
            UserControl_Loaded(sender, e);
            var cols = yearToCalendar.bigGrid.ColumnDefinitions;
            var rows = yearToCalendar.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                settings.Button_comboClickViewThin(sender, e);
            }
            var monthModel = yearToCalendar.grid2.DataContext as MonthModel;
            Binding binding = new Binding();
            binding.Source = monthModel.Leap;
            yearToCalendar.grid2.button29.SetBinding(VisibilityProperty, binding);
            binding = new Binding();
            binding.Source = monthModel.IsEventOn;
            yearToCalendar.grid2.button29.SetBinding(IsEnabledProperty, binding);
            //sets the view combos, if othe year then the current, the one month view and the three months view is disabled
            int currentYear = DateTime.Now.Year;
            if (yearToCalendar.YearNumber != currentYear)
            {
                settings.currentCombo.Visibility = Visibility.Collapsed;
                settings.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                settings.currentCombo.Visibility = Visibility.Visible;
                settings.threeMonthCombo.Visibility = Visibility.Visible;
            }
            
            //var window = this.Parent as Window;
            //window.ResizeMode = ResizeMode.NoResize;
            //set1.Opacity = 0;
        }
        /// <summary>
        /// Opens the Settings popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_Click_Popup(object sender, RoutedEventArgs e)
        {
            if (popLink.IsOpen == false)
            {
                popLink.IsOpen = true;
            }
            else
            {
                popLink.IsOpen = false;
            }
        }
        
    }
}
