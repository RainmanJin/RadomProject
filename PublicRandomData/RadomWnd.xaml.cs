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
    /// RadomWnd.xaml 的交互逻辑
    /// </summary>
    public partial class RadomWnd : Window
    {
        List<SolidColorBrush> _brushs=new List<SolidColorBrush>();
        SolidColorBrush no1 = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        SolidColorBrush no2 = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        SolidColorBrush no3 = new SolidColorBrush(Color.FromRgb(255, 0, 255));
        SolidColorBrush no4 = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        SolidColorBrush no5 = new SolidColorBrush(Color.FromRgb(0, 0, 255));

        int count_no1, count_no2, count_no3, count_no4, count_no5;
        public RadomWnd()
        {
            InitializeComponent();
        }

        int GetNum(string txt)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(txt))
                return ret;
            else
            {
                int.TryParse(txt, out ret);
            }
            return ret;
        }

        void initControl()
        {
            _brushs.Clear();
            wPanel.Children.Clear();
            txtResult.Text = "";
            count_no1 = 0;
            count_no2 = 0;
            count_no3 = 0;
            count_no4 = 0;
            count_no5 = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            initControl();
            int sum = 0;
            sum += GetNum(txtbNO1.Text);
            int no1_c = sum;
            sum += GetNum(txtbNO2.Text);
            int no2_c = sum;
            sum += GetNum(txtbNO3.Text);
            int no3_c = sum;
            sum += GetNum(txtbNO4.Text);
            int no4_c = sum;
            sum += GetNum(txtbNO5.Text);
            int no5_c = sum;
            int _index = 0;
            for (int i = 0; i < sum; i++)
            {
                if (i < no1_c)
                {
                    _brushs.Add(no1);
                    continue;
                }
                else if (i < no2_c)
                {
                    _brushs.Add(no2);
                    continue;
                }
                else if (i < no3_c)
                {
                    _brushs.Add(no3);
                    continue;
                }
                else if (i < no4_c)
                {
                    _brushs.Add(no4);
                    continue;
                }
                else
                {
                    _brushs.Add(no5);
                    continue;
                }
            }
            //List<SolidColorBrush> new_list = _brushs;
            Random rom = new Random();
            for (int i = 0; i < sum; i++)
            {
                int old_index = rom.Next(0, sum - 1);
                SolidColorBrush temp = _brushs[old_index];
                _brushs[old_index] = _brushs[i];
                _brushs[i] = temp;
            }
            int no = 0;

            while(no++<100)
            {
                Ellipse bb = new Ellipse();
                bb.Height = 10;
                bb.Width = 10;
                int index = rom.Next(0, sum - 1);
                if (_brushs[index] == no1) count_no1++;
                if (_brushs[index] == no2) count_no2++;
                if (_brushs[index] == no3) count_no3++;
                if (_brushs[index] == no4) count_no4++;
                if (_brushs[index] == no5) count_no5++;
                bb.Fill = _brushs[index];
                wPanel.Children.Add(bb);
                //System.Threading.Thread.Sleep(10);
            }
            txtResult.Text = string.Format("NO.1: {0} ; NO.2: {1} ; NO.3: {2} ; NO.4: {3} ; NO.5: {4} ", count_no1, count_no2, count_no3, count_no4, count_no5);
        }
    }
}
