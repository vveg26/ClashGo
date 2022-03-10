using ClashGo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Model
{
    public class InfoNode:ViewModelBase
    {   

        //是否选中
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;OnPropertyChanged(); }
        }
        //节点信息
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        //通信协议TODO
        private string protocol;

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }



    }
}
