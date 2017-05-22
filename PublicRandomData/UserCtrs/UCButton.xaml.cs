using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PublicRandomData.UserCtrs
{
    /// <summary>
    /// UCButton.xaml 的交互逻辑
    /// </summary>
    public partial class UCButton : UserControl,INotifyPropertyChanged
    {
        public static readonly DependencyProperty CellWidthProperty = DependencyProperty.Register("CellWidth", typeof(double), typeof(UCButton), new PropertyMetadata(50d));
        public static readonly DependencyProperty CellHeightProperty = DependencyProperty.Register("CellHeight", typeof(double), typeof(UCButton), new PropertyMetadata(50d));
        public static readonly DependencyProperty HCellCountProperty = DependencyProperty.Register("HCellCount", typeof(int), typeof(UCButton), new PropertyMetadata(1));
        public static readonly DependencyProperty VCellCountProperty = DependencyProperty.Register("VCellCount", typeof(int), typeof(UCButton), new PropertyMetadata(1));

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string pro)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pro));
        }
        public UCButton()
        {
            InitializeComponent();
        }

        public double CellWidth
        {
            get { return (double)GetValue(CellWidthProperty); }
            set { SetValue(CellWidthProperty, value); OnPropertyChanged("CellWidth"); }
        }

        public double CellHeight
        {
            get { return (double)GetValue(CellHeightProperty); }
            set { SetValue(CellHeightProperty, value); OnPropertyChanged("CellHeight"); }
        }

        public int HCellCount
        {
            get { return (int)GetValue(HCellCountProperty); }
            set { SetValue(HCellCountProperty, value); OnPropertyChanged("ControlWidth"); }
        }

        public int VCellCount
        {
            get { return (int)GetValue(VCellCountProperty); }
            set { SetValue(VCellCountProperty, value); OnPropertyChanged("ControlHeight"); }
        }

        public double ControlWidth
        {
            get { return HCellCount * CellWidth; }
        }
        public double ControlHeight
        {
            get { return VCellCount * CellHeight; }
        }

    }
}
