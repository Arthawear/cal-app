using Cal_App.Models;
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
        private bool showHolidays = false;
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
        public YearModel RunYear(int year)
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
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = this.Parent as Grid;
            var calendar = grid.Parent as Calendar;
            var window = calendar.Parent as Window;
            window.DragMove();
            window.ResizeMode = ResizeMode.NoResize;
        }
    }
}
