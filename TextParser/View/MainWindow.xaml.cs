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
using Microsoft.Win32;
using TextParser.Controller;

namespace TextParser
{

    public partial class MainWindow : Window
    {
        TextController t = new TextController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ParserButton_Click(object sender, RoutedEventArgs e)
        {
            ParserButton.IsEnabled = false;
            Answer.Text = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.FilterIndex = 2;
            openDialog.Multiselect = true;
            Nullable<bool> openResult = openDialog.ShowDialog();
            if (openResult == true)
            {
                string[] filenames = openDialog.FileNames;
                t.Reader(filenames);
            }
            Answer.Text = t.ChangeAnswer();
            t.Parser(PunctBox.IsChecked.Value,CountWord.Text);
            Answer.Text = t.ChangeAnswer();
            for(int i = 0; i < t.GetFIleCount();i++)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                Nullable<bool> saveResult = saveDialog.ShowDialog();
                t.Writter(saveDialog.FileName, i);
                Answer.Text = t.ChangeAnswer();
            }
            Answer.Text += "Работа с файлами окончена. \r\n";
            ParserButton.IsEnabled = true;
        }
    }
}
