using CalApp.Models;
using CalApp.Storage;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        private bool isEventOn = false;
        public Settings()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets the calendar view to thin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        public void ButtonComboClickViewThin(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            yearModel.Data = yearModel.pathData[0];
            yearModel.ViewColumnNumber = 2;
            int currentMonth = DateTime.Now.Month;
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].SetRowAndColumn(yearModel.Items1[i].Number, 2,6);
                yearModel.Items1[i].Visibility = "Visible";
                if (yearModel.Number==DateTime.Now.Year&&(currentMonth == 1 || currentMonth == 12)&&(i==0||i==11))
                {
                    yearModel.Items1[i].ArrangeDays(yearModel.Number, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.Items1[i].ShowHolidays);
                }
            }
            popLink.IsOpen = false;
        }
        /// <summary>
        /// Sets the calendar view to large
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_comboClickViewLarge(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            yearModel.Data = yearModel.pathData[1];
            yearModel.ViewColumnNumber = 4;
            int currentMonth = DateTime.Now.Month;
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].SetRowAndColumn(yearModel.Items1[i].Number, 4,3);
                yearModel.Items1[i].Visibility = "Visible";
                if (yearModel.Number == DateTime.Now.Year && (currentMonth == 1 || currentMonth == 12) && (i == 0 || i == 11))
                {
                    yearModel.Items1[i].ArrangeDays(yearModel.Number, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.Items1[i].ShowHolidays);
                }
            }
            popLink.IsOpen = false;
        }
        /// <summary>
        /// Sets the calendar view to one month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        internal void Button_comboClickViewOneMonth(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            yearModel.Data = yearModel.pathData[2];
            yearModel.ViewColumnNumber = 1;
            yearModel.ViewRowNumber = 1;
            popLink.IsOpen = false;
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].SetRowAndColumn(yearModel.Items1[i].Number, 1, 1);
            }
        }
        /// <summary>
        /// Sets the calendar view to three months
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        internal void Button_comboClickViewThreeMonths(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            yearModel.Data = yearModel.pathData[0];
            yearModel.ViewColumnNumber = 1;
            yearModel.ViewRowNumber = 3;
            popLink.IsOpen = false;
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].SetRowAndColumn(yearModel.Items1[i].Number, 1,3);
            }
        }
        /// <summary>
        /// Sets the calendar's year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void ButtonClickSetYear(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            int a = DateTime.Now.Year;
            bool isNumber = Int32.TryParse(yearTxtBox.Text, out a);
            if (!isNumber)
            {
                yearTxtBox.Text = yearModel.Number.ToString(CultureInfo.CurrentCulture);
                popLink.IsOpen = false;
                return;
            }
            yearModel.Number = a;
            SetYear(yearModel);
            if (yearModel.ViewColumnNumber == 1)
            {
                this.ButtonComboClickViewThin(sender, e);
            }
            popLink.IsOpen = false;
        }
        /// <summary>
        /// sets the view combos, if other year then the current, the one month view and the three months view is disabled
        /// </summary>
        /// <param name="yearModel"></param>
        internal void SetYear(YearModel yearModel)
        {
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                if (i==1)
                {
                    yearModel.Items1[i].GetNumberOfDays(yearModel.Items1[i].Number, yearModel.Number);
                }
                yearModel.Items1[i].ArrangeDays(yearModel.Number, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.Items1[i].ShowHolidays);
            }
            if (yearModel.Number != DateTime.Now.Year)
            {
                currentCombo.Visibility = Visibility.Collapsed;
                threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                currentCombo.Visibility = Visibility.Visible;
                threeMonthCombo.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Sets the calendar background color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_comboClick(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            ComboBoxItem a = (ComboBoxItem)e.OriginalSource;
            yearModel.BackgroundColor = a.Background.ToString();
            popLink.IsOpen = false;
        }
        /// <summary>
        /// Enable/Disable google events buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickEventOn(object sender, RoutedEventArgs e)
        {
            if (!isEventOn)
            {
                isEventOn = true;
            }
            else if (isEventOn)
            {
                isEventOn = false;
            }
            var yearModel = DataContext as YearModel;
            yearModel.IsEventOn = isEventOn;
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].IsEventOn = isEventOn;
            }
            popLink.IsOpen = false;
        }
        /// <summary>
        /// Sets to show/or not the weekends with different color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickHolidays(object sender, RoutedEventArgs e)
        {
            var yearModel = DataContext as YearModel;
            if (!yearModel.ShowHolidays)
            {
                yearModel.ShowHolidays = true;
                for (int i = 0; i < yearModel.Items1.Count; i++)
                {
                    yearModel.Items1[i].ShowHolidays = true;
                    yearModel.Items1[i].ArrangeDays(yearModel.Items1[i].Year, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.Items1[i].ShowHolidays);
                }
            }
            else
            {
                yearModel.ShowHolidays = false;
                for (int i = 0; i < yearModel.Items1.Count; i++)
                {
                    yearModel.Items1[i].ShowHolidays = false;
                    yearModel.Items1[i].ArrangeDays(yearModel.Items1[i].Year, yearModel.Items1[i].Number, yearModel.Items1[i].NumberOfDays, yearModel.Items1[i].ShowHolidays);
                }
            } 
            popLink.IsOpen = false;
        }
        /// <summary>
        /// Prints the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickPrint(object sender, RoutedEventArgs e)
        {
            popLink.IsOpen = false;
            var modelToPrint= DataContext as YearModel;
            if (modelToPrint.Number== DateTime.Now.Year)
            {
                modelToPrint.Items1[DateTime.Now.Month - 1].Thickness = 0;
            }
            var calendarToPrint = new Calendar();
            calendarToPrint.DataContext = modelToPrint;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(calendarToPrint, "Calendar Printing.");

        }
        /// <summary>
        /// Shuts down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
        /// <summary>
        /// Sets the calendar's display language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        internal void SetLanguage(object sender, RoutedEventArgs e)
        {
            var comboItem = e.OriginalSource as ComboBoxItem;
            string newCulture = comboItem.Content.ToString();
            var yearModel = DataContext as YearModel;
            yearModel.SetTexts(newCulture);
            for (int i = 0; i < yearModel.Items1.Count; i++)
            {
                yearModel.Items1[i].SetNames(yearModel.Items1[i].Number, newCulture);
            }
            popLink.IsOpen = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            var location = parentWindow.PointToScreen(new Point(0, 0));
            int currentMonth = DateTime.Now.Month;
            string savedSettingsFilePath = "SavedSettings.json";
            var yearModel = DataContext as YearModel;
            var fileStorage = new FileStorage<object[]>();
            fileStorage.SetModel(savedSettingsFilePath, new object[] { yearModel.Number, yearModel.Culture, yearModel.ViewColumnNumber,
                yearModel.IsEventOn, yearModel.ShowHolidays, yearModel.BackgroundColor, yearModel.Data, yearModel.ViewRowNumber, location.X, location.Y});
            popLink.IsOpen = false;
        }
    }
}
