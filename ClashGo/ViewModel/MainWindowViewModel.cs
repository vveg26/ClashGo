using ClashGo.Model;
using ClashGo.Utils;
using ClashGo.ViewModel.Common;
using HandyControl.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ClashGo.ViewModel.Command
{
    public class MainWindowViewModel : ViewModelBase
    {
        string profilesDir = AppDomain.CurrentDomain.BaseDirectory+"profiles\\"; //clah yaml文件路径
        string configfile = AppDomain.CurrentDomain.BaseDirectory+"config\\config.yaml";//配置文件路径

        private List<RadioButton> radiolist = new List<RadioButton>();

        public List<RadioButton> Radiolist
        {
            get { return radiolist; }
            set { radiolist = value; OnPropertyChanged(); }
        }

        private List<Expander> expanderlist = new List<Expander>();

        public List<Expander> ExpanderList
        {
            get { return expanderlist; }
            set { expanderlist = value; OnPropertyChanged(); }
        }



        private List<NodeInfo> nodeList=new List<NodeInfo>();

        public List<NodeInfo> NodeList
        {
            get { return nodeList; }
            set { nodeList = value; OnPropertyChanged(); }
        }




        public void Test1()
        {
            /*            NodeInfo nodeInfo = new NodeInfo();
                        nodeInfo.Expander = "XXX";
                        List<string> lst = new List<string>() { "a", "b", "v" };
                        nodeInfo.Node = lst;
                        List<NodeInfo> nodeList1 = new List<NodeInfo>();
                        nodeList1.Add(nodeInfo);
                        NodeList = nodeList1;*/


             

            JsonDo utils = new JsonDo();
            string proxiesUrl = "http://127.0.0.1:9090/proxies";
            string jsonData = new HttpUtils().WebGet(proxiesUrl);
            string jsontest = new JsonDo().JsonRead(jsonData, "proxies");
            Dictionary<string, string> map = new Dictionary<string, string>();
            map = utils.JsonGetAllKV(jsontest);


            List<NodeInfo> fistList = new List<NodeInfo>();
            


            foreach (var x in map)
            {
                int index = 0;
                if (configBase.Mode.Equals("Direct"))
                {
                    break;
                }


                string str = x.Key;

                string str1 = x.Value;
                JArray jarray = (JArray)utils.JsonReadAll(str1, "all");//全部节点

                NodeInfo nodeInfo = new NodeInfo();
                List<InfoNode> secondList = new List<InfoNode>();
                


                //   secondList.ItemsPanel = warp;
                //二级菜单


                nodeInfo.Expander = str;



                string now = utils.JsonRead(str1, "now");//当前选择节点

                if (jarray != null)
                {
                    if (configBase.Mode.Equals("Rule") && str.Equals("GLOBAL"))//如果是规则就全局
                    {
                        continue;
                    }
                    foreach (string node in jarray)
                    {
                        /*                        ListBoxItem secondItem = new ListBoxItem();
                                                secondItem.Content = node;
                                                secondItem.Tag = item.Header;
                                                secondItem.Width = 200.00;*/
                        index++;
                        InfoNode infoNode = new InfoNode();

                        infoNode.Name = node;
                        

                        // secondItem.Click += DemoClick;
                        if (node.Equals(now))
                        {
                            // secondItem.IsChecked = true;
                            // secondItem.IsSelected = true;
                            infoNode.IsSelected = true;
                            nodeInfo.NodeIndex = index;
                        }
                        secondList.Add(infoNode);
                        // secondList.Items.Add(secondItem);

                    }
                    nodeInfo.Node = secondList;
                }
                else
                {
                    continue;
                }

                fistList.Add(nodeInfo);



            }

            NodeList = fistList;
            




        }



        public void TEST()
        {

            JsonDo utils = new JsonDo();
            string proxiesUrl = "http://127.0.0.1:9090/proxies";
            string jsonData = new HttpUtils().WebGet(proxiesUrl);
            string jsontest = new JsonDo().JsonRead(jsonData, "proxies");
            Dictionary<string, string> map = new Dictionary<string, string>();
            map = utils.JsonGetAllKV(jsontest);

            List<Expander> fistList = new List<Expander>();//一级菜单

           


            foreach (var x in map)
            {
                if (configBase.Mode.Equals("Direct"))
                {
                    break;
                }
                Expander item = new Expander();
                item.Width = 600.00;
                
                string str = x.Key;

                string str1 = x.Value;
                JArray jarray = (JArray)utils.JsonReadAll(str1, "all");//全部节点


                ListBox secondList = new ListBox();
                
                

                //   secondList.ItemsPanel = warp;
                //二级菜单


                item.Header = str;



                string now = utils.JsonRead(str1, "now");//当前选择节点

                if (jarray != null)
                {
                    if (configBase.Mode.Equals("Rule") && str.Equals("GLOBAL"))//如果是规则就全局
                    {
                        continue;
                    }
                    foreach (string node in jarray)
                    {
                        ListBoxItem secondItem = new ListBoxItem();
                        secondItem.Content = node;
                        secondItem.Tag = item.Header;
                        secondItem.Width = 200.00;

                       // secondItem.Click += DemoClick;
                        if (secondItem.Content.Equals(now))
                        {
                           // secondItem.IsChecked = true;
                            secondItem.IsSelected = true;
                        }

                        secondList.Items.Add(secondItem);
                    }
                    item.Content = secondList;
                }
                else
                {
                    continue;
                }

                fistList.Add(item);



            }

            ExpanderList = fistList;
            OnPropertyChanged("ExpanderList");



        }




        public List<string> ModeList { get; set; } = new List<string>()
        {
            "Rule","Direct","Global"
        };
        private ConfigInfo configBase = new ConfigInfo(); //配置文件基本信息

        //配置文件
        public ConfigInfo ConfigBase
        {
            get { return configBase; }
            set { configBase = value; OnPropertyChanged(); }
        }

        private string profileName;

        public string ProfileName
        {
            get { return profileName; }
            set { profileName = value; OnPropertyChanged(); }
        }


        private BaseCommand controlPanel; //打开控制面板

        private BaseCommand setSystemProxy; //设置系统代理

        private BaseCommand exit;//退出

        private BaseCommand mainLoad; //主程序启动时执行

        private BaseCommand profileComboBoxChanged; //可选框改变时

        private BaseCommand modeComboBoxChanged;

        private BaseCommand nodeMenuUpdate; //更新节点

        private BaseCommand generalShow;

        private BaseCommand profilesShow;

        private BaseCommand proxiesShow;

        private BaseCommand otherSettingShow;




        private UIType ui=new UIType();

        public UIType UI
        {
            get { return ui; }
            set { ui = value; OnPropertyChanged(); }
        }

        public BaseCommand GeneralShow
        {
            get
            {
                if (generalShow == null)
                {
                    generalShow = new BaseCommand(new Action<object>(o =>
                    {
                        
                        UI.Clear();
                        UI.General = "Visible";

                    }));
                }
                return generalShow;
            }
        }
        public BaseCommand ProxiesShow
        {
            get
            {
                if (proxiesShow == null)
                {
                    proxiesShow = new BaseCommand(new Action<object>(o =>
                    {

                        UI.Clear();
                        UI.Proxies = "Visible";

                    }));
                }
                return proxiesShow;
            }
        }

        public BaseCommand ProfilesShow
        {
            get
            {
                if (profilesShow == null)
                {
                    profilesShow = new BaseCommand(new Action<object>(o =>
                    {

                        UI.Clear();
                        UI.Profiles = "Visible";

                    }));
                }
                return profilesShow;
            }
        }
        public BaseCommand OtherSettingShow
        {
            get
            {
                if (otherSettingShow == null)
                {
                    otherSettingShow = new BaseCommand(new Action<object>(o =>
                    {

                        UI.Clear();
                        UI.OtherSetting = "Visible";
                    }));
                }
                return otherSettingShow;
            }
        }




        public BaseCommand NodeMenuUpdate
        {
            get
            {
                if (nodeMenuUpdate == null)
                {
                    nodeMenuUpdate = new BaseCommand(new Action<object>(o =>
                    {
                        NodeMenuShow();
                        

                    }));
                }
                return nodeMenuUpdate;
            }
        }


        public BaseCommand ModeComboBoxChanged
        {
            get
            {
                if (modeComboBoxChanged == null)
                {
                    modeComboBoxChanged = new BaseCommand(new Action<object>(o =>
                    {

                        string configUrl = "http://127.0.0.1:9090/configs";
                        
                       
                        string jsonConfigData = "{\"mode\":\"" + configBase.Mode + "\"}";//基础配置信息
                        new HttpUtils().WebPatch(configUrl, jsonConfigData);


                    }));
                }
                return modeComboBoxChanged;
            }
        }

        public List<MenuItem> NodeMenu { get; set; } = new List<MenuItem>(); //节点菜单列表

        private List<string> profilesList; //FQ配置文件集合 

        public List<string> ProfilesList 
        {
            get {


                UtilsCommon utils = new UtilsCommon();
                string path = AppDomain.CurrentDomain.BaseDirectory + @"profiles";
                List<FileInfo> files = utils.GetFiles(path, ".yaml");
                List<string> list = new List<string>() ;
                foreach (FileInfo file in files)
                {
                    list.Add(file.Name);
                }
                profilesList = list;

                return profilesList; }
            set { profilesList = value;OnPropertyChanged(); } //通知变化
        }






        //控制面板
        public BaseCommand ControlPanel
        {
            get
            {
                if (controlPanel == null)
                {
                   controlPanel = new BaseCommand(new Action<object>(o =>
                    {
                        
                        System.Diagnostics.Process.Start("explorer.exe", "http://127.0.0.1:9090/ui");
                    }));
                }
                return controlPanel;
            }
        }
        //可选框改变时
        public BaseCommand ProfileComboboxChanged
        {
            get
            {
                if (profileComboBoxChanged == null)
                {
                    profileComboBoxChanged = new BaseCommand(new Action<object>(o =>
                    {

                        //TODO 启动配置文件
                        string profilePath = profilesDir+ConfigBase.LastYaml;
                        string jsonReloadData = JsonConvert.SerializeObject(new
                        {
                            path = profilePath //配置文件路径

                        });
                        try
                        {   
                           
                          new HttpUtils().WebPut("http://127.0.0.1:9090/configs?force=false", jsonReloadData);//切换配置文件

                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.MessageBox.Show(ex.ToString() + "配置文件存在问题");

                        }


                    }));
                }
                return profileComboBoxChanged ;
            }
        }

        public BaseCommand SetSystemProxy
        {
            get
            {
                if (setSystemProxy == null)
                {
                    setSystemProxy = new BaseCommand(new Action<object>(o =>
                    {

                        if (ConfigBase.SystemProxy)
                        {
                            
                            new SetSystemProxyUtils().SetProxy("127.0.0.1:"+ConfigBase.MixedPort);
                        }
                        else
                        {
                            new SetSystemProxyUtils().UnSetProxy();
                        }
                        

                        new YML(configfile).modify("system-proxy", configBase.SystemProxy.ToString());
                    }));
                }
                return setSystemProxy;
            }
        }

        public BaseCommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new BaseCommand(new Action<object>(o =>
                    {
                        new UtilsCommon().KillProcess("clash");
                        Application.Current.Shutdown();
                    }));
                }
                return exit;
            }
        }





        //开启Clash
        public BaseCommand MainLoad
        {
            get
            {
                if (mainLoad  == null)
                {
                    mainLoad  = new BaseCommand(new Action<object>(o =>
                    {
                       
                        string allowlan;
                        if (ConfigBase.AllowLan.ToString().Equals("True"))
                        {
                            allowlan = "true";
                        }
                        else
                        {
                            allowlan = "false";
                        }


                        ProfileName = ConfigBase.LastYaml; //初始化combobox

                        string cmdStr = @"clash -d ./ -f ./profiles/" + ProfileName + " -ext-ctl " + ConfigBase.ExternalController + " -ext-ui ui";
                        new Cmd().CmdLine(cmdStr);

                        NodeMenuShow();
                        Test1();


                        string jsonConfigData = "{\"port\":" + ConfigBase.Port.ToString() + ",\"socks-port\":" + ConfigBase.SocksPort.ToString() + ",\"mode\":\"" + ConfigBase.Mode.ToString() + "\",\"allow-lan\":" + allowlan + ",\"log-level\":\"" + ConfigBase.LogLevel.ToString() + "\",\"mixed-port\":" + ConfigBase.MixedPort.ToString() + "}";//基础配置信息
                                                                                                                                                                                                                                                                                                                                                      //string jsonConfigData = "{\"port\":7890,\"socks-port\":7891,\"mode\":\"Rule\",\"allow-lan\":false,\"log-level\":\"info\",\"mixed-port\": 7893}";//基础配置信息          
                        string a = new HttpUtils().WebPatch("http://127.0.0.1:9090/configs", jsonConfigData);


                                             

                    }));
                }
                return mainLoad ;
            }
        }

        private void NodeMenuShow()
        {
            JsonDo utils = new JsonDo();
            string proxiesUrl = "http://127.0.0.1:9090/proxies";
            string jsonData = new HttpUtils().WebGet(proxiesUrl);
            string jsontest = new JsonDo().JsonRead(jsonData, "proxies");
            Dictionary<string, string> map = new Dictionary<string, string>();
            map = utils.JsonGetAllKV(jsontest);

            List<MenuItem> fistList = new List<MenuItem>();//一级菜单


            foreach (var x in map)
            {
                if (configBase.Mode.Equals("Direct"))
                {
                    break;
                }
                MenuItem item = new MenuItem();
                string str = x.Key;

                string str1 = x.Value;
                JArray jarray = (JArray)utils.JsonReadAll(str1, "all");//全部节点


                List<MenuItem> secondList = new List<MenuItem>();
                //二级菜单


                item.Header = str;



                string now = utils.JsonRead(str1, "now");//当前选择节点

                if (jarray != null)
                {
                    if (configBase.Mode.Equals("Rule") && str.Equals("GLOBAL"))//如果是规则就全局
                    {
                        continue;
                    }
                    foreach (string node in jarray)
                    {
                        MenuItem secondItem = new MenuItem();
                        secondItem.Header = node;
                        secondItem.Tag = item.Header;

                        secondItem.Click += DemoClick;
                        if (secondItem.Header.Equals(now))
                        {
                            secondItem.IsChecked = true;
                        }

                        secondList.Add(secondItem);
                    }
                    item.ItemsSource = secondList;
                }
                else
                {
                    continue;
                }

                fistList.Add(item);



            }

            NodeMenu = fistList;
            OnPropertyChanged("NodeMenu");
        }



        /// <summary>
        /// 菜单栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DemoClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
           // MenuItem itemParent = (MenuItem)item.Parent;
           string son = item.Tag as string;
            foreach(MenuItem itemx in NodeMenu)
            {
                string parent = itemx.Header as string;
                if (son.Equals(parent))
                {   
                    
                    foreach(MenuItem itemy in itemx.Items)
                    {
                        itemy.IsChecked= false;
                    }
                }
            }

            string url = "http://127.0.0.1:9090/proxies/";
            string selector = (string)item.Tag;
            string url1 = url + selector;
            string jsonData = "{\"name\":\"" + (string)item.Header + "\"}";
            string a = new HttpUtils().WebPut(url1, jsonData);
            item.IsChecked = true;

        }

    }




}
