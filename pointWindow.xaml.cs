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
using System.Windows.Shapes;

namespace app
{
    /// <summary>
    /// Interaction logic for pointWindow.xaml
    /// </summary>
    public partial class pointWindow : Window
    {
        private double x=1800;
        private double y=500;
        public pointWindow(Window window)
        {
            window.Left = x;
            window.Top = y;
            InitializeComponent();
        }

        public void Update()
        {

        }

    }
}
