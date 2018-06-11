using System;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image IM = null;
        BitmapImage btm = null;
        Button btn = null;
        List<String> paths = new List<String>();
        System.Windows.Forms.FolderBrowserDialog FBI = new System.Windows.Forms.FolderBrowserDialog();

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (FBI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                paths.AddRange(Directory.GetFiles(FBI.SelectedPath));

                foreach (var item in paths)
                {
                    btm = new BitmapImage();
                    btn = new Button();
                    IM = new Image();
                    btm.BeginInit();
                    btm.UriSource = new Uri(item, UriKind.Absolute);
                    btm.EndInit();
                    IM.Source = btm;
                    SP_1.Children.Add(btn);
                    btn.Content = IM;
                    btn.Click += Btn_Click;
                }
                
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            im_1.Source=((sender as Button).Content as Image).Source;
            
        }

        private void EX_1_Expanded(object sender, RoutedEventArgs e)
        {
           
            EX_1.Content = im_1.Source.ToString();   
        }

        private void EX_1_Collapsed(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
