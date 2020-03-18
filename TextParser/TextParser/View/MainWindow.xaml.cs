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

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.Multiselect = true;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                string[] filenames = dialog.FileNames;
                t.Reader(filenames);
            }
            Answer.Text = t._text.GetAnswer();

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < t._text.GetWords().Count; i++)
            {
                int temp;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                Nullable<bool> result = dialog.ShowDialog();
                try
                {
                    if (CountWord.Text == "")
                        temp = 0;
                    else
                        temp = Convert.ToInt32(CountWord.Text);
                    string[] filenames = dialog.FileNames;
                    t.Writter(dialog.FileName, RadioPunct.IsChecked.Value, temp, i);
                    Answer.Text = t._text.GetAnswer();
                }
                catch (Exception ex)
                {
                    Answer.Text = ex.Message;
                }
            }
        }
    }
}
