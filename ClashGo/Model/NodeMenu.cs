using ClashGo.Utils;
using ClashGo.ViewModel;
using ClashGo.ViewModel.Common;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Model
{
    public class NodeInfo:ViewModelBase
    {

        private string expander;

        public string Expander
        {
            get { return expander; }
            set { expander = value; OnPropertyChanged(); }
        }


        private List<InfoNode> node;

        public List<InfoNode> Node
        {
            get { return  node; }
            set {  node = value; OnPropertyChanged(); }
        }

        private int nodeIndex;

        public int NodeIndex
        {
            get { return nodeIndex; }
            set { nodeIndex = value; OnPropertyChanged(); }
        }


        //点
        private BaseCommand nodeChanged;

        /// <summary>
        /// 传参操作
        /// </summary>
        public BaseCommand NodeChanged
        {
            get
            {
                if (nodeChanged == null)
                {
                    nodeChanged = new BaseCommand(new Action<object>((para) =>
                    {
                        //MessageBox.Show("hello");
                        string url = "http://127.0.0.1:9090/proxies/";
                        string selector = Expander;
                        string url1 = url + selector;
                       
                        InfoNode infoNode = (InfoNode)para;//将参数转换为字符串
                        infoNode.IsSelected = true;
                        string jsonData = "{\"name\":\"" + infoNode.Name.ToString() + "\"}";
                        string a = new HttpUtils().WebPut(url1, jsonData);

                    }));
                }
                return nodeChanged;
            }
        }
    }
}
