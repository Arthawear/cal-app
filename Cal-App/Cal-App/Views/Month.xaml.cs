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
    /// Interaction logic for Month.xaml
    /// </summary>
    public partial class Month : UserControl
    {
        public Month()
        {
            InitializeComponent();

        }

        private void Button_Click_Popup(object sender, RoutedEventArgs e)
        {
            var month = this as UserControl;
            var bigGrid = month.Parent as Grid;
            var coll = bigGrid.Children;
            var popLink = coll[0] as Popup;
            if (popLink.IsOpen == false)
            {
                popLink.IsOpen = true;

            }
            else
            {
                popLink.IsOpen = false;
            }
        }

        public void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            set1.Opacity = 1;
        }

        public void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            set1.Opacity = 0;
        }
    }
}
