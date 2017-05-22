using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PublicRandomData
{
    /// <summary>
    /// LoginWnd.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWnd : Window
    {
        public LoginWnd()
        {
            InitializeComponent();
            Loaded += LoginWnd_Loaded;
        }

        private void LoginWnd_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWnd main = new MainWnd();
            main.Show();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button).Tag.ToString();
            switch(tag)
            {
                case "Close":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
