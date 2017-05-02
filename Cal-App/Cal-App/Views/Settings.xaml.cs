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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public bool isEventOn = false;
        public Settings()
        {
            InitializeComponent();
        }
        public void Button_comboClickViewThin(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            var bigGrid = year.bigGrid;
            var grids = bigGrid.Children;
            for (int i = 1; i < grids.Count; i++)
            {
                if (grids[i] is UserControl)
                {
                    var uc = grids[i] as UserControl;
                    var grid = uc.Content as Grid;
                    var gridSecond = grid.Children[0] as Grid;
                    if (grid != null)
                    {
                        grid.Visibility = Visibility.Visible;
                    }
                }
            }
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            var rows = bigGrid.RowDefinitions;
            var cols = bigGrid.ColumnDefinitions;
            if (cols.Count != 2 && rows.Count != 6)
            {
                rows.Clear();
                cols.Clear();
                var col1 = new ColumnDefinition();
                var col2 = new ColumnDefinition();
                var row1 = new RowDefinition();
                var row2 = new RowDefinition();
                var row3 = new RowDefinition();
                var row4 = new RowDefinition();
                var row5 = new RowDefinition();
                var row6 = new RowDefinition();
                cols.Add(col1);
                cols.Add(col2);
                rows.Add(row1);
                rows.Add(row2);
                rows.Add(row3);
                rows.Add(row4);
                rows.Add(row5);
                rows.Add(row6);
                Grid.SetRow(year.grid1, 0); Grid.SetColumn(year.grid1, 0);
                Grid.SetRow(year.grid2, 0); Grid.SetColumn(year.grid2, 1);
                Grid.SetRow(year.grid3, 1); Grid.SetColumn(year.grid3, 0);
                Grid.SetRow(year.grid4, 1); Grid.SetColumn(year.grid4, 1);
                Grid.SetRow(year.grid5, 2); Grid.SetColumn(year.grid5, 0);
                Grid.SetRow(year.grid6, 2); Grid.SetColumn(year.grid6, 1);
                Grid.SetRow(year.grid7, 3); Grid.SetColumn(year.grid7, 0);
                Grid.SetRow(year.grid8, 3); Grid.SetColumn(year.grid8, 1);
                Grid.SetRow(year.grid9, 4); Grid.SetColumn(year.grid9, 0);
                Grid.SetRow(year.grid10, 4); Grid.SetColumn(year.grid10, 1);
                Grid.SetRow(year.grid11, 5); Grid.SetColumn(year.grid11, 0);
                Grid.SetRow(year.grid12, 5); Grid.SetColumn(year.grid12, 1);
                window.MinHeight = 750;
                window.MaxHeight = 1200;
                window.MaxWidth = this.MaxHeight / 3;
                window.MinWidth = this.MinHeight / 3;
                window.Height = 800;
                window.MaxHeight = 1800;
                window.MaxWidth = this.MaxHeight / 3;
                window.MinHeight = 750;
                window.MinWidth = this.MinHeight / 3;
                string path = "M151,1L2416,1C2498,1,2566,68,2566,151L2566,6680C2566,6762,2498,6830,2416,6830L151,6830C69,6830,1,6762,1,6680L1,151C1,68,69,1,151,1z";
                Binding pathBinding = new Binding();
                pathBinding.Source = path;
                var data = year.WinBack.Data;
                year.WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            window.DispatcherTimer_Tick(sender, e);
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewLarge(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            var bigGrid = year.bigGrid;
            var grids = bigGrid.Children;
            for (int i = 1; i < grids.Count; i++)
            {
                if (grids[i] is UserControl)
                {
                    var uc = grids[i] as UserControl;
                    var grid = uc.Content as Grid;
                    if (grid != null)
                    {
                        grid.Visibility = Visibility.Visible;
                    }
                }
            }
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            var rows = bigGrid.RowDefinitions;
            var cols = bigGrid.ColumnDefinitions;
            if (!(cols.Count == 4 && rows.Count == 3))
            {
                rows.Clear();
                cols.Clear();
                var col1 = new ColumnDefinition();
                var col2 = new ColumnDefinition();
                var col3 = new ColumnDefinition();
                var col4 = new ColumnDefinition();
                var row1 = new RowDefinition();
                var row2 = new RowDefinition();
                var row3 = new RowDefinition();
                cols.Add(col1);
                cols.Add(col2);
                cols.Add(col3);
                cols.Add(col4);
                rows.Add(row1);
                rows.Add(row2);
                rows.Add(row3);
                Grid.SetRow(year.grid1, 0); Grid.SetColumn(year.grid1, 0);
                Grid.SetRow(year.grid2, 0); Grid.SetColumn(year.grid2, 1);
                Grid.SetRow(year.grid3, 0); Grid.SetColumn(year.grid3, 2);
                Grid.SetRow(year.grid4, 0); Grid.SetColumn(year.grid4, 3);
                Grid.SetRow(year.grid5, 1); Grid.SetColumn(year.grid5, 0);
                Grid.SetRow(year.grid6, 1); Grid.SetColumn(year.grid6, 1);
                Grid.SetRow(year.grid7, 1); Grid.SetColumn(year.grid7, 2);
                Grid.SetRow(year.grid8, 1); Grid.SetColumn(year.grid8, 3);
                Grid.SetRow(year.grid9, 2); Grid.SetColumn(year.grid9, 0);
                Grid.SetRow(year.grid10, 2); Grid.SetColumn(year.grid10, 1);
                Grid.SetRow(year.grid11, 2); Grid.SetColumn(year.grid11, 2);
                Grid.SetRow(year.grid12, 2); Grid.SetColumn(year.grid12, 3);
                window.MinHeight = 150;
                window.MaxHeight = 1000;
                window.MaxWidth = 1333;
                window.MinWidth = 200;
                window.Height = 750;
                window.MaxHeight = 900;
                window.MaxWidth = MaxHeight * 4 / 3;
                window.MinHeight = 450;
                window.MinWidth = MinHeight * 4 / 3;
                string path = "M2394,4273L5874,4273C5954,4273,6019,4339,6019,4419L6019,7274C6019,7354,5954,7420,5874,7420L2394,7420C2314,7420,2248,7354,2248,7274L2248,4419C2248,4339,2314,4273,2394,4273z";
                Binding pathBinding = new Binding();
                pathBinding.Source = path;
                var data = year.WinBack.Data;
                year.WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            window.DispatcherTimer_Tick(sender, e);
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewOneMonth(object sender, RoutedEventArgs e)
        {
            int currentYear0 = DateTime.Now.Year;
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            var bigGrid = year.bigGrid;
            var dc0 = year.grid1.DataContext as MonthModel;
            int year1 = dc0.Year;
            if (year1 != currentYear0)
            {
                popLink.IsOpen = false;
                return;
            }
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            var rows = bigGrid.RowDefinitions;
            var cols = bigGrid.ColumnDefinitions;
            if (!(cols.Count == 1 && rows.Count == 1))
            {
                rows.Clear();
                cols.Clear();
                var col1 = new ColumnDefinition();
                var row1 = new RowDefinition();
                cols.Add(col1);
                rows.Add(row1);
                int currentMonth = DateTime.Now.Month;
                var grids = bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    if (grids[i] is UserControl)
                    {
                        var uc1 = grids[i] as UserControl;
                        var grid = uc1.Content as Grid;
                        if (grid != null)
                        {
                            grid.Visibility = Visibility.Hidden;
                        }
                        if (i == currentMonth)
                        {
                            grid.Visibility = Visibility.Visible;
                            Grid.SetRow(uc1, 0); Grid.SetColumn(uc1, 0);
                        }
                    }
                }
                window.MaxWidth = 300;
                window.MinWidth = 150;
                window.MinHeight = 150;
                window.MaxHeight = 300;
                window.Height = 400;
                window.MaxHeight = 1000;
                window.MaxWidth = 1000;
                string path = "M63,0L764,0C798,0,827,32,827,72L827,873C827,913,798,945,764,945L63,945C28,945,0,913,0,873L0,72C0,32,28,0,63,0z";
                Binding pathBinding = new Binding();
                pathBinding.Source = path;
                var data = year.WinBack.Data;
                year.WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            window.DispatcherTimer_Tick(sender, e);
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewThreeMonths(object sender, RoutedEventArgs e)
        {
            int currentYear0 = DateTime.Now.Year;
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            var bigGrid = year.bigGrid;
            var dc0 = year.grid1.DataContext as MonthModel;
            int year1 = dc0.Year;
            if (year1 != currentYear0)
            {
                popLink.IsOpen = false;
                return;
            }
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            var rows = bigGrid.RowDefinitions;
            var cols = bigGrid.ColumnDefinitions;
            if (!(cols.Count == 1 && rows.Count == 3))
            {
                rows.Clear();
                cols.Clear();
                var col1 = new ColumnDefinition();
                var row1 = new RowDefinition();
                var row2 = new RowDefinition();
                var row3 = new RowDefinition();
                cols.Add(col1);
                rows.Add(row1);
                rows.Add(row2);
                rows.Add(row3);
                int currentMonth = DateTime.Now.Month;
                string gridName = "grid" + currentMonth;
                var grids = bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    var uc1 = grids[i] as UserControl;
                    var grid = uc1.Content as Grid;
                    grid.Visibility = Visibility.Hidden;
                    if (i == currentMonth - 1)
                    {
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 0); Grid.SetColumn(uc1, 0);
                    }
                    if (i == currentMonth)
                    {
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 1); Grid.SetColumn(uc1, 0);
                    }
                    if (i == currentMonth + 1)
                    {
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 2); Grid.SetColumn(uc1, 0);
                    }
                    if (currentMonth == 1)
                    {
                        int currentYear = DateTime.Now.Year;
                        var dc = year.grid12.DataContext as MonthModel;
                        bool holiday = dc.ShowHolidays;
                        string culture = dc.Culture;
                        MonthModel dec = new MonthModel(12, currentYear - 1, holiday, culture);
                        var gridChild = year.grid12.Content as Grid;
                        gridChild.Visibility = Visibility.Visible;
                        year.grid12.DataContext = dec;
                        Grid.SetRow(year.grid12, 0); Grid.SetColumn(year.grid12, 0);
                    }
                    if (currentMonth == 12)
                    {
                        int currentYear = DateTime.Now.Year;
                        var dc = year.grid1.DataContext as MonthModel;
                        bool holiday = dc.ShowHolidays;
                        string culture = dc.Culture;
                        MonthModel jan = new MonthModel(1, currentYear + 1, holiday, culture);
                        var gridChild = year.grid1.Content as Grid;
                        gridChild.Visibility = Visibility.Visible;
                        year.grid1.DataContext = jan;
                        Grid.SetRow(year.grid1, 2); Grid.SetColumn(year.grid1, 0);
                    }
                }
                window.MaxWidth = 200;
                window.MinWidth = 200;
                window.MinHeight = 600;
                window.MaxHeight = 600;
                window.Height = 700;
                window.MaxHeight = 1200;
                window.MaxWidth = MaxHeight / 3;
                window.MinHeight = 300;
                window.MinWidth = MinHeight / 3;
                string path = "M151,1L2416,1C2498,1,2566,68,2566,151L2566,6680C2566,6762,2498,6830,2416,6830L151,6830C69,6830,1,6762,1,6680L1,151C1,68,69,1,151,1z";
                Binding pathBinding = new Binding();
                pathBinding.Source = path;
                var data = year.WinBack.Data;
                year.WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            window.DispatcherTimer_Tick(sender, e);
            popLink.IsOpen = false;
        }

        private void Button_ClickSetYear(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            var year = grid0.Children[1] as Year;
            string text = yearTxtBox.Text;
            int a = DateTime.Now.Year;
            bool isNumber = Int32.TryParse(yearTxtBox.Text, out a);
            if (a==0)
            {
                yearTxtBox.Text = calendar.showYearTxtBlock.Text;
                popLink.IsOpen = false;
                return;
            }
            year.Element.Year = a;
            string culture = year.Culture;
            var cols = year.bigGrid.ColumnDefinitions;
            var rows = year.bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                this.Button_comboClickViewThin(sender, e);
            }

            year.YearToCal = year.RunYear(year.Element.Year, culture);
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < year.bigGrid.Children.Count; i++)
            {
                var month = year.bigGrid.Children[i] as Month;
                if (i == currentMonth)
                {
                    month.UserControl_Loaded(sender, e);
                }
                if (i == 2 && year.Element.Year % 4 == 0 && isEventOn)
                {
                    month.button29.Visibility = Visibility.Visible;
                }
            }
            if (year.Element.Year != currentYear)
            {
                currentCombo.Visibility = Visibility.Collapsed;
                threeMonthCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                currentCombo.Visibility = Visibility.Visible;
                threeMonthCombo.Visibility = Visibility.Visible;
            }
            popLink.IsOpen = false;
            calendar.showYearTxtBlock.Text = year.Element.Year.ToString();
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender, e);
        }

        private void Button_comboClick(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            ComboBoxItem a = (ComboBoxItem)e.OriginalSource;
            Binding binding = new Binding();
            binding.Source = a;
            binding.Path = new PropertyPath("Background");
            binding.Mode = BindingMode.TwoWay;
            year.WinBack.SetBinding(Path.FillProperty, binding);
            popLink.IsOpen = false;
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender, e);
        }

        private void Button_ClickEventOn(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            var bigGrid = year.bigGrid;
            Button button = new Button();
            button = (Button)e.OriginalSource;
            if (!isEventOn)
            {
                isEventOn = true;
                button.Content = "Események Ki";
                for (int i = 1; i < bigGrid.Children.Count; i++)
                {
                    var month = bigGrid.Children[i] as Month;
                    var grid1 = month.Content as Grid;
                    var grid2 = grid1.Children[0] as Grid;
                    for (int j = 2; j < grid2.Children.Count - 1; j++)
                    {
                        if (grid2.Children[j] is Button)
                        {
                            var button1 = grid2.Children[j] as Button;
                            button1.Visibility = Visibility.Visible;
                        }
                    }
                    month.UserControl_Loaded(sender, e);
                }
            }
            else if (isEventOn)
            {
                isEventOn = false;
                button.Content = "Események Be";
                for (int i = 1; i < bigGrid.Children.Count; i++)
                {
                    var month = bigGrid.Children[i] as Month;
                    var grid1 = month.Content as Grid;
                    var grid2 = grid1.Children[0] as Grid;
                    for (int j = 2; j < grid2.Children.Count; j++)
                    {
                        if (grid2.Children[j] is Button)
                        {
                            var button1 = grid2.Children[j] as Button;
                            button1.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
            popLink.IsOpen = false;
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender, e);
        }

        private void Button_ClickHolidays(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            if (!year.ShowHolidays)
            {
                year.ShowHolidays = true;
            }
            else
                year.ShowHolidays = false;
            int currentMonth = DateTime.Now.Month;
            if (currentMonth == 1 || currentMonth == 12)
            {
                var grids = year.bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    var month = year.bigGrid.Children[i] as Month;
                    var monthModel = month.DataContext as MonthModel;
                    int currentYear = monthModel.Year;
                    int monthNumber = monthModel.Number;
                    string culture = monthModel.Culture;
                    MonthModel current = new MonthModel(monthNumber, currentYear, year.ShowHolidays, culture);
                    month.DataContext = current;
                }
            }
            else
            {
                string culture = year.Culture;
                year.YearToCal = year.RunYear(year.Element.Year, culture);
            }
            popLink.IsOpen = false;
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender, e);
        }

        private void Button_ClickPrint(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            popLink.IsOpen = false;
            var whiteColour = calendar.showYearTxtBlock.Foreground;
            var year = grid0.Children[1] as Year;
            var grids = year.bigGrid.Children;
            int currentMonthNumber = DateTime.Now.Month;
            Month currentMonth = new Month();
            Visibility currentDaySquareVisibility = new Visibility();
            for (int i = 1; i < grids.Count; i++)
            {
                var month = year.bigGrid.Children[i] as Month;
                if (i == currentMonthNumber)
                {
                    currentMonth = month;
                    currentDaySquareVisibility = currentMonth.CurrentDaySquare.Visibility;
                    currentMonth.CurrentDaySquare.Visibility = Visibility.Collapsed;
                }
            }
            calendar.showYearTxtBlock.Foreground = Black.Background;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(calendar, "Calendar Printing.");
            calendar.showYearTxtBlock.Foreground = whiteColour;
            currentMonth.CurrentDaySquare.Visibility = currentDaySquareVisibility;
            window.DispatcherTimer_Tick(sender, e);
        }
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var calendar = grid0.Parent as Calendar;
            var window = calendar.Parent as Window;
            window.Close();
        }
        private void SetLanguage(object sender, RoutedEventArgs e)
        {
            var comboItem = e.OriginalSource as ComboBoxItem;
            string newCulture = comboItem.Content.ToString();
            var popLink = this.Parent as Popup;
            var grid0 = popLink.Parent as Grid;
            var year = grid0.Children[1] as Year;
            for (int i = 1; i < year.bigGrid.Children.Count; i++)
            {
                var month = year.bigGrid.Children[i] as Month;
                var monthModel = month.DataContext as MonthModel;
                int currentYear = monthModel.Year;
                int monthNumber = monthModel.Number;
                bool showHolidays = monthModel.ShowHolidays;
                MonthModel current = new MonthModel(monthNumber, currentYear, showHolidays, newCulture);
                month.DataContext = current;
            }
            year.Culture = newCulture;
            popLink.IsOpen = false;
            var calendar = grid0.Parent as Calendar;
            calendar.showYearTxtBlock.Text = year.Element.Year.ToString();
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender, e);
        }
    }
}
