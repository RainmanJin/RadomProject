using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PublicRandomData.Models
{
    public class MenuModel
    {
        public int _Index{get;set;}
        public string _Title { get; set; }
        public string _IconFont { get; set; }
        public ImageSource _IconSource { get; set; }
        public string _MenuTag { get; set; }
        public SolidColorBrush _BackBrush { get; set; }
    }
}
