using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicRandomData.Models
{
    public class UserModel
    {
        public int _Index { get; set; }
        public string _Caption { get; set; }
        public UserType _UserType { get; set; }
        public List<MenuModel> _LimitData  { get; set; }
    }
}
