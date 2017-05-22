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
    /// MainWnd.xaml 的交互逻辑
    /// </summary>
    public partial class MainWnd : Window
    {
        public MainWnd()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
                return;
            Point _p= e.GetPosition(root);
            if (e.GetPosition(root).Y > 60) return;    
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button).Tag.ToString();
            switch (tag)
            {
                case "set":
                    break;
                case "help":
                    Units.LoggerTool.Info("tag", "this is message");
                    Units.LoggerTool.Info("this is message");
                    Units.LoggerTool.Info("{0},{1}",new string[]{ "this is message","rain"});
                    break;
                case "quit":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
