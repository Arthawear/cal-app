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

namespace Cal_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var uc = this.Content as UserControl;
            var element = uc.DataContext as Views.FrameworkElement;
            this.DataContext = element;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var uc = this.Content as UserControl;
            var bigGrid = uc.Content as Grid;
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
            var Element = uc.DataContext as Views.FrameworkElement;
            Element.ResizeMode = "None";
        }
    }
}

