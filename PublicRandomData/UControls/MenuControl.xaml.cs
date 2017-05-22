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
using PublicRandomData.Models;

namespace PublicRandomData.UControls
{
    /// <summary>
    /// MenuControl.xaml 的交互逻辑
    /// </summary>
    public partial class MenuControl : UserControl, INotifyPropertyChanged
    {
        #region perperty

        private List<MenuModel> _UserMenus;

        public List<MenuModel> UserMenus
        {
            get { return _UserMenus; }
            set { _UserMenus = value; OnPropertyChanged("UserMenus"); }
        }


        #endregion
        public MenuControl()
        {
            InitializeComponent();
            Loaded += MenuControl_Loaded;
        }

        void MenuControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitData(UserType.BaseDataManager);
            this.DataContext = this;
        }

        void InitData(UserType uType)
        {
            if (UserMenus == null)
                UserMenus = new List<MenuModel>();
            UserMenus.Add(new MenuModel() { _Index = 0,_BackBrush=Brushes.Orange, _Title = "企业管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 1,_BackBrush=Brushes.Green, _Title = "检查人员管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 2,_BackBrush=Brushes.Black, _Title = "监管事项管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 3,_BackBrush=Brushes.Red, _Title = "随机抽取配对", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 4,_BackBrush=Brushes.PaleGreen, _Title = "检查任务管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 5,_BackBrush=Brushes.RoyalBlue, _Title = "账号权限管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 6,_BackBrush=Brushes.Orange, _Title = "区域管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 7,_BackBrush=Brushes.Orange, _Title = "部门管理", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 8,_BackBrush=Brushes.Orange, _Title = "数据导入导出", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 9,_BackBrush=Brushes.Orange, _Title = "系统连接设置", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 10,_BackBrush=Brushes.Orange ,_Title = "数据库备份与还原", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 11,_BackBrush=Brushes.Orange ,_Title = "历史监管任务数据", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 12,_BackBrush=Brushes.Orange ,_Title = "查询统计与报表", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 13,_BackBrush=Brushes.Orange ,_Title = "数据文件加密", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 14,_BackBrush=Brushes.Orange ,_Title = "文件格式转换与压缩", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 15,_BackBrush=Brushes.Orange ,_Title = "管理员日志查询", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 16,_BackBrush=Brushes.Orange ,_Title = "安装手册与操作手册编写", _IconFont = "\uf0d1" });
            UserMenus.Add(new MenuModel() { _Index = 17,_BackBrush=Brushes.Orange ,_Title = "运维与技术支持", _IconFont = "\uf0d1" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
