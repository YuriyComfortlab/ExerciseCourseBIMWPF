using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            //if ((bool)radioButtonDark.IsEnabled)
            //{
            //    ThemeChange("Dark.xaml");
            //}
            //else if ((bool)radioButtonLight.IsPressed)
            //{
            //    ThemeChange("Light.xaml");
            //}

        }
        private void radioButtonDark_Checked(object sender, RoutedEventArgs e)
        {
            ThemeChange("Dark.xaml");
        }
        private void radioButtonLight_Checked(object sender, RoutedEventArgs e)
        {
            ThemeChange("Light.xaml");
        }


        private void ThemeChange(string path)
        {
            Application.Current.Resources.Clear();
            Uri uri = new Uri(path, UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        string filePath = null;


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)  //шрифт
        {
            string fontName = ((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }

        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)        //размер
        {
            string fontSize = ((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }
        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            var colorFonts = (sender as ComboBox).SelectedValue;
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFrom(colorFonts);
            if (textBox != null)
            {
                textBox.Foreground = brush;
            }
        }       //цвет шрифта


        private void ToggleButton_Checked(object sender, RoutedEventArgs e) //bold
        {
            if (textBox != null)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)   //normal
        {
            if (textBox != null)
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }
        private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontStyle = FontStyles.Italic;
            }

        }
        private void ToggleButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }
        private void ToggleButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
        }
        private void ToggleButton_Unchecked_2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.TextDecorations = null;
            }
        }

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (textBox != null)
        //    {
        //        textBox.Foreground = Brushes.Black;
        //    }
        //}
        //private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        //{
        //    if (textBox != null)
        //    {
        //        textBox.Foreground = Brushes.Red;
        //    }
        //}

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Текстовые файлы (*.txt, *.txt2)|*.txt;*.txt2|Все файлы (*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        textBox.Text = File.ReadAllText(openFileDialog.FileName);
        //    }
        //}

        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        File.WriteAllText(saveFileDialog.FileName, textBox.Text);
        //    }
        //}

        //private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}



        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Text = null;
        }
        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt, *.txt2)|*.txt;*.txt2|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                Redactor.Title = filePath + " - TextEditor";
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (filePath != null && textBox != null)
            {
                File.WriteAllText(filePath, textBox.Text);
            }
            else
            {
                SaveFile();
            }
        }
        private void SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();
        }
        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
