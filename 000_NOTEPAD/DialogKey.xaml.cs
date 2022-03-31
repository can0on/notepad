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

namespace _000_NOTEPAD
{
    /// <summary>
    /// Logika interakcji dla klasy DialogKey.xaml
    /// </summary>
    public partial class DialogKey : Window
    {
        public DialogKey()
        {
            InitializeComponent();
        }

        private void OkClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
