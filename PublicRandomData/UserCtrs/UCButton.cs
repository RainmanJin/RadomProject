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

namespace PublicRandomData.UserCtrs
{
    public class UCButton : Button
    {
        static ImageSource Def_Img = new BitmapImage(new Uri("Imgs/default.jpg", UriKind.RelativeOrAbsolute));
        public static readonly DependencyProperty SubTitleVisibilityProperty = DependencyProperty.Register("SubTitleVisibility", typeof(Visibility), typeof(UCButton), new PropertyMetadata(Visibility.Collapsed));
        public static readonly DependencyProperty BKImageSourceProperty = DependencyProperty.Register("BKImageSource", typeof(ImageSource), typeof(UCButton), new PropertyMetadata(Def_Img));
        public static readonly DependencyProperty BKSolidBrushProperty = DependencyProperty.Register("BKSolidBrush", typeof(SolidColorBrush), typeof(UCButton),new PropertyMetadata(Brushes.Orange));
        public static readonly DependencyProperty SubBKSolidBrushProperty = DependencyProperty.Register("SubBKSolidBrush", typeof(SolidColorBrush), typeof(UCButton), new PropertyMetadata(Brushes.Orange));
        public static readonly DependencyProperty TitleContentProperty = DependencyProperty.Register("TitleContent", typeof(string), typeof(UCButton), new PropertyMetadata("Default Title"));
        public static readonly DependencyProperty SubTitleContentProperty = DependencyProperty.Register("SubTitleContent", typeof(string), typeof(UCButton), new PropertyMetadata("Default SubTitle"));
        public Visibility SubTitleVisibility
        {
            get { return (Visibility)GetValue(SubTitleVisibilityProperty); }
            set { SetValue(SubTitleVisibilityProperty, value); }
        }
        public string SubTitleContent
        {
            get { return (string)GetValue(SubTitleContentProperty); }
            set { SetValue(SubTitleContentProperty, value); }
        }
        public string TitleContent
        {
            get { return (string)GetValue(TitleContentProperty); }
            set { SetValue(TitleContentProperty, value); }
        }
        public ImageSource BKImageSource
        {
            get { return (ImageSource)GetValue(BKImageSourceProperty); }
            set { SetValue(BKImageSourceProperty, value); }
        }
        public SolidColorBrush SubBKSolidBrush
        {
            get { return (SolidColorBrush)GetValue(SubBKSolidBrushProperty); }
            set { SetValue(SubBKSolidBrushProperty, value); }
        }
        public SolidColorBrush BKSolidBrush
        {
            get { return (SolidColorBrush)GetValue(BKSolidBrushProperty); }
            set { SetValue(BKSolidBrushProperty, value); }
        }
        static UCButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UCButton), new FrameworkPropertyMetadata(typeof(UCButton)));
        }
    }
}
