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
            showYearTxtBlock.Text = yearToCalendar.Element.Year.ToString();
        }
        private void Button_ClickPrevYear(object sender, RoutedEventArgs e)
        {
            string culture = yearToCalendar.Culture;
            int yearNr = int.Parse(showYearTxtBlock.Text);
            int nextYear = yearNr - 1;
            showYearTxtBlock.Text = nextYear.ToString();
            settings.yearTxtBox.Text = showYearTxtBlock.Text;
            yearToCalendar.Element.Year = int.Parse(showYearTxtBlock.Text);
            var cols = yearToCalendar.bigGrid.ColumnDefinitions;
            var rows = yearToCalendar.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                settings.Button_comboClickViewThin(sender, e);
            }
            yearToCalendar.YearToCal = yearToCalendar.RunYear(yearToCalendar.Element.Year, culture);
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < yearToCalendar.bigGrid.Children.Count; i++)
            {
                var month = yearToCalendar.bigGrid.Children[i] as Month;
                if (i == currentMonth)
                {
                    month.UserControl_Loaded(sender, e);
                }
                if (i == 2 && yearToCalendar.Element.Year % 4 == 0 && settings.isEventOn)
                {
                    month.button29.Visibility = Visibility.Visible;
                }
            }
            if (yearToCalendar.Element.Year != currentYear)
            {
                settings.currentCombo.Visibility = Visibility.Collapsed;
                settings.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                settings.currentCombo.Visibility = Visibility.Visible;
                settings.threeMonthCombo.Visibility = Visibility.Visible;
            }
            var window = this.Parent as Window;
            window.ResizeMode = ResizeMode.NoResize;
            set1.Opacity = 0;
        }
        private void Button_ClickNextYear(object sender, RoutedEventArgs e)
        {
            string culture = yearToCalendar.Culture;
            int yearNr = int.Parse(showYearTxtBlock.Text);
            int nextYear = yearNr + 1;
            showYearTxtBlock.Text = nextYear.ToString();
            settings.yearTxtBox.Text = showYearTxtBlock.Text;
            yearToCalendar.Element.Year = int.Parse(showYearTxtBlock.Text);
            var cols = yearToCalendar.bigGrid.ColumnDefinitions;
            var rows = yearToCalendar.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                settings.Button_comboClickViewThin(sender, e);
            }
            yearToCalendar.YearToCal = yearToCalendar.RunYear(yearToCalendar.Element.Year,culture);
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < yearToCalendar.bigGrid.Children.Count; i++)
            {
                var month = yearToCalendar.bigGrid.Children[i] as Month;
                if (i == currentMonth)
                {
                    month.UserControl_Loaded(sender, e);
                }
                if (i == 2 && yearToCalendar.Element.Year % 4 == 0 && settings.isEventOn)
                {
                    month.button29.Visibility = Visibility.Visible;
                }
            }
            if (yearToCalendar.Element.Year != currentYear)
            {
                settings.currentCombo.Visibility = Visibility.Collapsed;
                settings.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                settings.currentCombo.Visibility = Visibility.Visible;
                settings.threeMonthCombo.Visibility = Visibility.Visible;
            }
            var window = this.Parent as Window;
            window.ResizeMode = ResizeMode.NoResize;
            set1.Opacity = 0;
        }
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
