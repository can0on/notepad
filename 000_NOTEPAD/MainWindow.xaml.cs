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
using System.IO;
using Microsoft.Win32;

namespace _000_NOTEPAD
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        string fileName = "";
        public MainWindow()
        {
            InitializeComponent();

            openFileDialog.Filter = "Text files|*.txt|All files|*.*";
            saveFileDialog.Filter = "Text files|*.txt|All files|*.*";

            Notepad.Focus();
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno stworzyć nowy plik? Niezapisane zmiany przepadną", "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                Notepad.Clear();
                fileName = "";
            }
        }

        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                Notepad.Text = File.ReadAllText(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
            }
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (fileName != "")
                File.WriteAllText(fileName, Notepad.Text);
            else
                SaveAsCommand(sender, e);
        }

        private void SaveAsCommand( object sender, ExecutedRoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, Notepad.Text);
                fileName = saveFileDialog.FileName;
            }
        }

        private void CloseClicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zamknąć?", "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void InsertSmiley(object sender, RoutedEventArgs e)
        {
            Notepad.SelectedText = "😃";
            Notepad.SelectionStart++;
            Notepad.SelectionLength = 0;
        }

        private void InsertSad(object sender, RoutedEventArgs e)
        {
            Notepad.SelectedText = "😥";
            Notepad.SelectionStart++;
            Notepad.SelectionLength = 0;
        }

        private void InsertStar(object sender, RoutedEventArgs e)
        {
            Notepad.SelectedText = "★";
            Notepad.SelectionStart++;
            Notepad.SelectionLength = 0;
        }
        private void InsertHeart(object sender, RoutedEventArgs e)
        {
            Notepad.SelectedText = "❤️";
            Notepad.SelectionStart++;
            Notepad.SelectionLength = 0;
        }

        private void InsertLike(object sender, RoutedEventArgs e)
        {
            Notepad.SelectedText = "👍🏻";
            Notepad.SelectionStart++;
            Notepad.SelectionLength = 0;
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            DialogKey dialog = new DialogKey();
            if (dialog.ShowDialog() == true)
            {
                int key = int.Parse(dialog.Key.Text);
                Notepad.Text = Caesar.Encrypt(Notepad.Text, key);
            }
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            DialogKey dialog = new DialogKey();
            if (dialog.ShowDialog() == true)
            {
                int key = int.Parse(dialog.Key.Text);
                Notepad.Text = Caesar.Decrypt(Notepad.Text, key);
            }
        }
    }
}
