using Cal_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace Cal_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid; 
            var year=grid.Children[1] as Year;
            var element = year.DataContext as Views.FrameworkElement;
            this.DataContext = element;
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid;
            var year = grid.Children[1] as Year;
            
            var bigGrid = year.Content as Grid;
            var cols = bigGrid.ColumnDefinitions;
            var rows = bigGrid.RowDefinitions;
            if (cols.Count == 2 && rows.Count == 6)
            {
                Width = Height / 3;
            }
            else if (cols.Count == 4)
            {
                Width = Height * 4 / 3;
            }
            else if (cols.Count == 1 && rows.Count == 1)
            {
                Width = Height;
            }
            else if (cols.Count == 1 && rows.Count == 3)
            {
                Width = Height / 3;
            }
            FontSize = Width / (cols.Count * 15);
            this.ResizeMode = ResizeMode.NoResize;
        }
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            dispatcherTimer.Stop();
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid;
            var year = grid.Children[1] as Year;
            var bigGrid = year.Content as Grid;
            for (int i = 1; i < bigGrid.Children.Count; i++)
            {
                var month = bigGrid.Children[i] as Month;
                month.UserControl_MouseEnter(sender, e);
            }
        }
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            var calendar = this.Content as Views.Calendar;
            var grid = calendar.Content as Grid;
            var popups = grid.Children[0] as Popups;
            var year = grid.Children[1] as Year;
            var bigGrid = year.bigGrid;
            var grid1 = popups.Content as Grid;
            var popLink = grid1.Children[0] as Popup;
            var popEvent = grid1.Children[1] as Popup;
            if (!(popLink.IsOpen || popEvent.IsOpen))
            {
                for (int i = 1; i < bigGrid.Children.Count; i++)
                {
                    var month = bigGrid.Children[i] as Month;
                    month.UserControl_MouseLeave(sender, e);
                }
                if (this.ResizeMode == ResizeMode.CanResizeWithGrip)
                {
                    dispatcherTimer.Start();
                }
            }
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.ResizeMode = ResizeMode.NoResize;
        }
    }
}

