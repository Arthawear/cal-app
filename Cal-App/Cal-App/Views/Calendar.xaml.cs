using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            var grid = this.Content as Grid;
            var popups = grid.Children[0] as Popups;
            var year = grid.Children[1] as Year;
            showYearTxtBlock.Text = year.Element.Year.ToString();

        }
        
        private void Button_ClickPrevYear(object sender, RoutedEventArgs e)
        {
            var grid = this.Content as Grid;
            var popups = grid.Children[0] as Popups;
            var year = grid.Children[1] as Year;
            string culture = year.Culture;
            int yearNr = int.Parse(showYearTxtBlock.Text);
            int prevYear = yearNr - 1;
            showYearTxtBlock.Text = prevYear.ToString();
            popups.yearTxtBox.Text = showYearTxtBlock.Text;
            year.Element.Year = int.Parse(showYearTxtBlock.Text);
            var cols = year.bigGrid.ColumnDefinitions;
            var rows = year.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                popups.Button_comboClickViewThin(sender, e);
            }
            
            year.YearToCal = year.RunYear(year.Element.Year,culture);
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < year.bigGrid.Children.Count; i++)
            {
                var month = year.bigGrid.Children[i] as Month;
                if (i == currentMonth)
                {
                    month.UserControl_Loaded(sender, e);
                }
                if (i == 2 && year.Element.Year % 4 == 0 && popups.isEventOn)
                {
                    month.button29.Visibility = Visibility.Visible;
                }
            }
            if (year.Element.Year != currentYear)
            {
                popups.currentCombo.Visibility = Visibility.Collapsed;
                popups.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                popups.currentCombo.Visibility = Visibility.Visible;
                popups.threeMonthCombo.Visibility = Visibility.Visible;
            }
            var window = this.Parent as Window;
            window.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_ClickNextYear(object sender, RoutedEventArgs e)
        {
            var grid = this.Content as Grid;
            var popups = grid.Children[0] as Popups;
            var year = grid.Children[1] as Year;
            string culture = year.Culture;
            int yearNr = int.Parse(showYearTxtBlock.Text);
                int nextYear = yearNr + 1;
            showYearTxtBlock.Text = nextYear.ToString();
            popups.yearTxtBox.Text = showYearTxtBlock.Text;
            year.Element.Year = int.Parse(showYearTxtBlock.Text);
            var cols = year.bigGrid.ColumnDefinitions;
            var rows = year.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                popups.Button_comboClickViewThin(sender, e);
            }
            
            year.YearToCal = year.RunYear(year.Element.Year,culture);
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < year.bigGrid.Children.Count; i++)
            {
                var month = year.bigGrid.Children[i] as Month;
                if (i == currentMonth)
                {
                    month.UserControl_Loaded(sender, e);
                }
                if (i == 2 && year.Element.Year % 4 == 0 && popups.isEventOn)
                {
                    month.button29.Visibility = Visibility.Visible;
                }
            }
            if (year.Element.Year != currentYear)
            {
                popups.currentCombo.Visibility = Visibility.Collapsed;
                popups.threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                popups.currentCombo.Visibility = Visibility.Visible;
                popups.threeMonthCombo.Visibility = Visibility.Visible;
            }
            var window = this.Parent as Window;
            window.ResizeMode = ResizeMode.NoResize;
        }
    }
}
