﻿using Cal_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Year.xaml
    /// </summary>
    public class FrameworkElement : UIElement, INotifyPropertyChanged
    {
        private string resizeMode = "CanResizeWithGrip";
        public static readonly DependencyProperty YearProperty;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Year
        {
            get
            {
                return (int)GetValue(YearProperty);
            }

            set
            {
                SetValue(YearProperty, value);
            }
        }

        public string ResizeMode
        {
            get
            {

                return this.resizeMode;

            }

            set
            {
                if (this.resizeMode != value)
                {
                    this.resizeMode = value;
                    this.OnPropertyChanged("ResizeMode");
                }

            }
        }
        static FrameworkElement()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(DateTime.Now.Year);
            metadata.AffectsArrange = true;
            metadata.AffectsMeasure = true;
            metadata.AffectsParentArrange = true;
            metadata.AffectsParentMeasure = true;
            metadata.AffectsRender = true;
            YearProperty = DependencyProperty.Register("Year", typeof(int), typeof(FrameworkElement), metadata);
        }
    }
    public partial class Year : UserControl, INotifyPropertyChanged
    {
        private YearModel yearToCal;
        private string white = "#FEFEFE";
        private string transparent = "#00FFFFFF";
        private bool showHolidays = false;
        public bool isEventOn = false;
        private FrameworkElement element = new FrameworkElement();
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public YearModel YearToCal
        {
            get
            {
                return this.yearToCal;
            }

            set
            {
                if (this.yearToCal != value)
                {
                    this.yearToCal = value;
                    this.OnPropertyChanged("YearToCal");
                }

            }
        }


        public FrameworkElement Element
        {
            get
            {
                return this.element;
            }

            set
            {
                if (this.element != value)
                {
                    this.element = value;
                    this.OnPropertyChanged("Element");
                }
            }
        }

        public bool ShowHolidays
        {
            get
            {
                return this.showHolidays;
            }

            set
            {
                if (this.showHolidays != value)
                {
                    this.showHolidays = value;
                    this.OnPropertyChanged("ShowHolidays");
                }

            }
        }



        public Year()
        {
            InitializeComponent();
            element.ResizeMode = "None";
            DataContext = Element;
            this.YearToCal = RunYear(Element.Year);
            for (int i = 1; i < bigGrid.Children.Count; i++)
            {
                var month = bigGrid.Children[i] as UserControl;
                var dt = month.DataContext as MonthModel;
                Binding binding = new Binding();
                binding.Source = dt.BackgroundColour;
                var grid = month.Content as Grid;
                var back = grid.Background as VisualBrush;
                var path = back.Visual as Path;
                path.SetBinding(Path.FillProperty, binding);
                if (i == 2)
                {
                    var gridSecond = grid.Children[0] as Grid;
                    var set1 = gridSecond.Children[0] as TextBlock;
                    string color = white;
                    Binding binding1 = new Binding();
                    binding1.Source = color;
                    set1.SetBinding(ForegroundProperty, binding1);
                }
            }
        }
        private YearModel RunYear(int year)
        {
            YearModel months = new YearModel(year, ShowHolidays);
            grid1.DataContext = months.Items1[0];
            grid2.DataContext = months.Items1[1];
            grid3.DataContext = months.Items1[2];
            grid4.DataContext = months.Items1[3];
            grid5.DataContext = months.Items1[4];
            grid6.DataContext = months.Items1[5];
            grid7.DataContext = months.Items1[6];
            grid8.DataContext = months.Items1[7];
            grid9.DataContext = months.Items1[8];
            grid10.DataContext = months.Items1[9];
            grid11.DataContext = months.Items1[10];
            grid12.DataContext = months.Items1[11];
            return months;
        }

        private void Button_ClickSetYear(object sender, RoutedEventArgs e)
        {
            this.Element.Year = int.Parse(yearTxtBox.Text);
            var cols = bigGrid.ColumnDefinitions;
            var rows = bigGrid.RowDefinitions;
            if (cols.Count == 1 && (rows.Count == 1 || rows.Count == 3))
            {
                this.Button_comboClickViewThin(sender, e);
            }
            this.YearToCal = RunYear(Element.Year);
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < bigGrid.Children.Count; i++)
            {
                if (i == currentMonth)
                {
                    var month = bigGrid.Children[i] as Month;
                    month.UserControl_Loaded(sender, e);
                }
            }

            popLink.IsOpen = false;
            var uc = this as UserControl;
            var window = uc.Parent as Window;
            this.Element.ResizeMode = "None";
        }

        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            var uc = this as UserControl;
            var window = uc.Parent as Window;
            window.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var uc = this as UserControl;
            var window = uc.Parent as Window;
            window.DragMove();
            this.Element.ResizeMode = "None";
        }

        private void Button_comboClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem a = (ComboBoxItem)e.OriginalSource;
            Binding binding = new Binding();
            binding.Source = a;
            binding.Path = new PropertyPath("Background");
            binding.Mode = BindingMode.TwoWay;
            WinBack.SetBinding(Path.FillProperty, binding);
            popLink.IsOpen = false;
            this.Element.ResizeMode = "None";
        }



        private void Button_comboClickViewLarge(object sender, RoutedEventArgs e)
        {
            var grids = bigGrid.Children;
            for (int i = 1; i < grids.Count; i++)
            {
                if (grids[i] is UserControl)
                {
                    var uc = grids[i] as UserControl;
                    var grid = uc.Content as Grid;
                    var gridSecond = grid.Children[0] as Grid;
                    var set2 = gridSecond.Children[0] as TextBlock;
                    if (grid != null)
                    {
                        grid.Opacity = 1;
                        grid.Visibility = Visibility.Visible;
                        string color = transparent;
                        Binding binding = new Binding();
                        binding.Source = color;
                        set2.SetBinding(ForegroundProperty, binding);
                    }
                    if (i == 4)
                    {
                        string color = white;
                        Binding binding = new Binding();
                        binding.Source = color;
                        set2.SetBinding(ForegroundProperty, binding);
                    }
                }
            }
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
                Grid.SetRow(grid1, 0); Grid.SetColumn(grid1, 0);
                Grid.SetRow(grid2, 0); Grid.SetColumn(grid2, 1);
                Grid.SetRow(grid3, 0); Grid.SetColumn(grid3, 2);
                Grid.SetRow(grid4, 0); Grid.SetColumn(grid4, 3);
                Grid.SetRow(grid5, 1); Grid.SetColumn(grid5, 0);
                Grid.SetRow(grid6, 1); Grid.SetColumn(grid6, 1);
                Grid.SetRow(grid7, 1); Grid.SetColumn(grid7, 2);
                Grid.SetRow(grid8, 1); Grid.SetColumn(grid8, 3);
                Grid.SetRow(grid9, 2); Grid.SetColumn(grid9, 0);
                Grid.SetRow(grid10, 2); Grid.SetColumn(grid10, 1);
                Grid.SetRow(grid11, 2); Grid.SetColumn(grid11, 2);
                Grid.SetRow(grid12, 2); Grid.SetColumn(grid12, 3);
                var uc = this as UserControl;
                var window = uc.Parent as Window;
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
                var data = WinBack.Data;
                WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            this.Element.ResizeMode = "None";
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewThin(object sender, RoutedEventArgs e)
        {
            var grids = bigGrid.Children;
            for (int i = 1; i < grids.Count; i++)
            {
                if (grids[i] is UserControl)
                {
                    var uc = grids[i] as UserControl;
                    var grid = uc.Content as Grid;
                    var gridSecond = grid.Children[0] as Grid;
                    var set3 = gridSecond.Children[0] as TextBlock;
                    if (grid != null)
                    {
                        grid.Opacity = 1;
                        grid.Visibility = Visibility.Visible;
                        string color = transparent;
                        Binding binding = new Binding();
                        binding.Source = color;
                        set3.SetBinding(ForegroundProperty, binding);
                    }
                    if (i == 2)
                    {
                        string color = white;
                        Binding binding = new Binding();
                        binding.Source = color;
                        set3.SetBinding(ForegroundProperty, binding);
                    }
                }
            }
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
                Grid.SetRow(grid1, 0); Grid.SetColumn(grid1, 0);
                Grid.SetRow(grid2, 0); Grid.SetColumn(grid2, 1);
                Grid.SetRow(grid3, 1); Grid.SetColumn(grid3, 0);
                Grid.SetRow(grid4, 1); Grid.SetColumn(grid4, 1);
                Grid.SetRow(grid5, 2); Grid.SetColumn(grid5, 0);
                Grid.SetRow(grid6, 2); Grid.SetColumn(grid6, 1);
                Grid.SetRow(grid7, 3); Grid.SetColumn(grid7, 0);
                Grid.SetRow(grid8, 3); Grid.SetColumn(grid8, 1);
                Grid.SetRow(grid9, 4); Grid.SetColumn(grid9, 0);
                Grid.SetRow(grid10, 4); Grid.SetColumn(grid10, 1);
                Grid.SetRow(grid11, 5); Grid.SetColumn(grid11, 0);
                Grid.SetRow(grid12, 5); Grid.SetColumn(grid12, 1);
                var uc = this as UserControl;
                var window = uc.Parent as Window;
                window.MinHeight = 750;
                window.MaxHeight = 1200;
                window.MaxWidth = this.MaxHeight / 3;
                window.MinWidth = this.MinHeight / 3;
                window.Height = 800;
                window.MaxHeight = 1800;
                window.MaxWidth = this.MaxHeight / 3;
                window.MinHeight = 750;
                window.MinWidth = this.MinHeight / 3;
                //this.MaxWidth = 350;
                string path = "M151,1L2416,1C2498,1,2566,68,2566,151L2566,6680C2566,6762,2498,6830,2416,6830L151,6830C69,6830,1,6762,1,6680L1,151C1,68,69,1,151,1z";
                Binding pathBinding = new Binding();
                pathBinding.Source = path;
                var data = WinBack.Data;
                WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            this.Element.ResizeMode = "None";
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewOneMonth(object sender, RoutedEventArgs e)
        {
            int currentYear0 = DateTime.Now.Year;
            var dc0 = grid1.DataContext as MonthModel;
            int year = dc0.Year;
            if (year != currentYear0)
            {
                popLink.IsOpen = false;
                return;
            }
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
                //currentMonth = 12;
                var grids = bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    if (grids[i] is UserControl)
                    {
                        var uc1 = grids[i] as UserControl;
                        var grid = uc1.Content as Grid;
                        var gridSecond = grid.Children[0] as Grid;
                        var set3 = gridSecond.Children[0] as TextBlock;
                        if (grid != null)
                        {
                            grid.Opacity = 0;
                            grid.Visibility = Visibility.Hidden;
                            string color = transparent;
                            Binding binding = new Binding();
                            binding.Source = color;
                            set3.SetBinding(ForegroundProperty, binding);
                        }
                        if (i == currentMonth)
                        {
                            grid.Opacity = 1;
                            grid.Visibility = Visibility.Visible;
                            Grid.SetRow(uc1, 0); Grid.SetColumn(uc1, 0);
                            string color = white;
                            Binding binding = new Binding();
                            binding.Source = color;
                            set3.SetBinding(ForegroundProperty, binding);
                        }
                    }
                }
                var uc = this as UserControl;
                var window = uc.Parent as Window;
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
                var data = WinBack.Data;
                WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            this.Element.ResizeMode = "None";
            popLink.IsOpen = false;
        }

        private void Button_comboClickViewThreeMonths(object sender, RoutedEventArgs e)
        {
            int currentYear0 = DateTime.Now.Year;
            var dc0 = grid1.DataContext as MonthModel;
            int year = dc0.Year;
            if (year != currentYear0)
            {
                popLink.IsOpen = false;
                return;
            }
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
                //currentMonth = 12;
                string gridName = "grid" + currentMonth;
                var grids = bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    var uc1 = grids[i] as UserControl;
                    var grid = uc1.Content as Grid;
                    grid.Opacity = 0;
                    grid.Visibility = Visibility.Hidden;
                    var gridSecond = grid.Children[0] as Grid;
                    var set5 = gridSecond.Children[0] as TextBlock;
                    string color0 = transparent;
                    Binding binding0 = new Binding();
                    binding0.Source = color0;
                    set5.SetBinding(ForegroundProperty, binding0);
                    if (i == currentMonth - 1)
                    {
                        grid.Opacity = 1;
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 0); Grid.SetColumn(uc1, 0);
                        string color = white;
                        Binding binding = new Binding();
                        binding.Source = color;
                        set5.SetBinding(ForegroundProperty, binding);
                    }
                    if (i == currentMonth)
                    {
                        grid.Opacity = 1;
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 1); Grid.SetColumn(uc1, 0);
                    }
                    if (i == currentMonth + 1)
                    {
                        grid.Opacity = 1;
                        grid.Visibility = Visibility.Visible;
                        Grid.SetRow(uc1, 2); Grid.SetColumn(uc1, 0);
                    }
                    if (currentMonth == 1)
                    {
                        int currentYear = DateTime.Now.Year;
                        var dc = grid12.DataContext as MonthModel;
                        bool holiday = dc.ShowHolidays;
                        MonthModel dec = new MonthModel(12, currentYear - 1, holiday);
                        var gridChild = grid12.Content as Grid;
                        gridChild.Opacity = 1;
                        gridChild.Visibility = Visibility.Visible;
                        grid12.DataContext = dec;
                        string color = "#FEFEFE";
                        Binding binding = new Binding();
                        binding.Source = color;
                        set5.SetBinding(ForegroundProperty, binding);
                        Grid.SetRow(grid12, 0); Grid.SetColumn(grid12, 0);
                    }
                    if (currentMonth == 12)
                    {
                        int currentYear = DateTime.Now.Year;
                        var dc = grid1.DataContext as MonthModel;
                        bool holiday = dc.ShowHolidays;
                        MonthModel jan = new MonthModel(1, currentYear + 1, holiday);
                        var gridChild = grid1.Content as Grid;
                        gridChild.Opacity = 1;
                        gridChild.Visibility = Visibility.Visible;
                        grid1.DataContext = jan;
                        Grid.SetRow(grid1, 2); Grid.SetColumn(grid1, 0);
                    }
                }
                var uc = this as UserControl;
                var window = uc.Parent as Window;
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
                var data = WinBack.Data;
                WinBack.SetBinding(Path.DataProperty, pathBinding);
            }
            this.Element.ResizeMode = "None";
            popLink.IsOpen = false;
        }
        private void Button_ClickHolidays(object sender, RoutedEventArgs e)
        {

            if (!ShowHolidays)
            {
                ShowHolidays = true;
            }
            else
                ShowHolidays = false;
            int currentMonth = DateTime.Now.Month;
            if (currentMonth == 1 || currentMonth == 12)
            {

                var grids = bigGrid.Children;
                for (int i = 1; i < grids.Count; i++)
                {
                    var grid = grids[i] as Grid;
                    var dc = grid.DataContext as MonthModel;
                    int currentYear = dc.Year;
                    int monthNumber = dc.Number;
                    MonthModel current = new MonthModel(monthNumber, currentYear, ShowHolidays);
                    grid.DataContext = current;
                }
            }
            else
                this.YearToCal = RunYear(Element.Year);
            popLink.IsOpen = false;
            this.Element.ResizeMode = "None";
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Element.ResizeMode = "CanResizeWithGrip";
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < bigGrid.Children.Count; i++)
            {
                var month = bigGrid.Children[i] as Month;
                month.UserControl_MouseEnter(sender, e);
            }
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < bigGrid.Children.Count; i++)
            {
                var month = bigGrid.Children[i] as Month;
                month.UserControl_MouseLeave(sender, e);
            }
        }

        private void Button_ClickPrint(object sender, RoutedEventArgs e)
        {
            this.Element.ResizeMode = "None";
            popLink.IsOpen = false;
            var uc = this as UserControl;
            var window = uc.Parent as Window;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(window, "Window Printing.");
        }


        private void Button_ClickExitEvent(object sender, RoutedEventArgs e)
        {
            popEvent.IsOpen = false;
        }

        private void Button_ClickEventOn(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button = (Button)e.OriginalSource;
            if (!isEventOn)
            {
                isEventOn = true;
                button.Content = "Események Ki";

            }
            else if (isEventOn)
            {
                isEventOn = false;
                button.Content = "Események Be";
            }
            popLink.IsOpen = false;
            this.Element.ResizeMode = "None";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}