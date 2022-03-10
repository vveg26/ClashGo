using ClashGo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Model
{
    public class UIType :ViewModelBase
    {
        private string general = "Visible";

        public  string General //基础配置
        {
            get { return general; }
            set { general = value; OnPropertyChanged(); }
        }

        private string proxies= "Collapsed";   //节点

        public string Proxies
        {
            get { return proxies; }
            set { proxies = value; OnPropertyChanged(); }
        }

        private string profiles="Collapsed";  //配置列表

        public string Profiles
        {
            get { return profiles; }
            set { profiles = value; OnPropertyChanged(); }
        }


        private string otherSetting= "Collapsed";

        public string OtherSetting
        {
            get { return otherSetting; }
            set { otherSetting = value; OnPropertyChanged(); }
        }

        public void Clear()
        {
            Profiles = "Collapsed";
            General = "Collapsed";
            OtherSetting = "Collapsed";
            Proxies = "Collapsed";
        }

    }
}
