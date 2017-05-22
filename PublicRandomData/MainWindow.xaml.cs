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

namespace PublicRandomData
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string PdfPath = "";
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "My-First-PDF-File";
            //dlg.DefaultExt = ".pdf";
            dlg.Filter = "text document(.pdf)|*.pdf|压缩文件(.zip)|*.zip";
            string _content = "单个部门通过规范化、无纸化途径落实“双随机、一公开”工作要求，即在本单位监管职责范围内和监管过程中随机抽取检查对象，/n随机选派执法检查人员，抽查情况及查处结果及时向社会公开。";
            if (!(bool)dlg.ShowDialog())
            {
                return;
            }
            PdfPath = dlg.FileName;
            string _tag = (sender as Button).Tag.ToString();
            switch(_tag)
            {
                case "Demo":
                    Units.PDFTool.CreateDemo(PdfPath, _content);
                    break;
                case "Table":
                    Units.PDFTool.CreateTablePdf(PdfPath,_content);
                    break;
                case "Watermark":
                    Units.PDFTool.AddWatermark(PdfPath, @"C:\Users\Administrator\Desktop\chart\new.pdf", @"../../Imgs/logo.png");
                    break;
                case "ZIP":
                    Units.ZipTool.ZipDirectory(@"D:\zip", PdfPath,"123456");
                    break;
                default:
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(PdfPath))
                System.Diagnostics.Process.Start(PdfPath);
        }
    }
}
