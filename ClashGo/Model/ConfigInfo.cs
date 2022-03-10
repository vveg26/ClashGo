using ClashGo.Utils;
using ClashGo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Model
{
    public class ConfigInfo:ViewModelBase
    {
        private int port;//端口
        private int socksPort;//socks端口
        private int mixedPort;//混合端口
        private bool allowLan;//允许局域网
        private string mode; //模式
        private string logLevel;//日志等级
        private string externalController; //外部端口
        private string lastYaml;//配置文件
        private bool systemProxy;//系统代理


        string configUrl = "http://127.0.0.1:9090/configs";
        string configfile = AppDomain.CurrentDomain.BaseDirectory + "config\\config.yaml";

        public void SaveToConfig(object value,string key)
        {   
            string jsonConfigData = "{\"" + key + "\":\"" + value + "\"}";//基础配置信息
            new HttpUtils().WebPatch(configUrl, jsonConfigData);
            YML yml = new YML(configfile); yml.modify(key, value.ToString()); yml.save();
        }

        public void SaveToConfigNotStr(object value, string key)
        {
            string jsonConfigData = "{\"" + key + "\":" + value + "}";//基础配置信息
            new HttpUtils().WebPatch(configUrl, jsonConfigData);
            YML yml = new YML(configfile); yml.modify(key, value.ToString()); yml.save();
        }


        public string GetInConfig(string key)
        {
            YML yml = new YML(configfile);
            return yml.read(key);
        }




        public bool SystemProxy
        {
            get { systemProxy = bool.Parse(GetInConfig("system-proxy")); return systemProxy; }
            set { systemProxy = value; OnPropertyChanged(); SaveToConfigNotStr(value, "system-proxy"); }
        }


        public string LastYaml
        {
            get { lastYaml = GetInConfig("last-yaml"); return lastYaml; }
            set { lastYaml = value; OnPropertyChanged(); SaveToConfig(value, "last-yaml"); }
        }


        public string ExternalController
        {
            get { externalController = GetInConfig("external-controller"); return externalController; }
            set { externalController = value; OnPropertyChanged(); SaveToConfig(value, "external-controller"); }
        }


        public  string LogLevel
        {
            get { logLevel = GetInConfig("log-level"); return logLevel; }
            set { logLevel = value; OnPropertyChanged(); SaveToConfig(value, "log-level"); }
        }


        public string Mode
        {
            get { mode = GetInConfig("mode"); return mode; }
            set { mode = value; OnPropertyChanged(); SaveToConfig(value, "mode"); }
        }


        public bool AllowLan
        {
            get { allowLan = bool.Parse(GetInConfig("allow-lan")); return allowLan; }
            set { allowLan = value; OnPropertyChanged(); SaveToConfigNotStr(value,"allw-lan"); }
        }



        public int MixedPort
        {
            get { mixedPort = int.Parse(GetInConfig("mixed-port")); return mixedPort; }
            set { mixedPort = value; OnPropertyChanged(); SaveToConfigNotStr(value,"mixed-port"); }
        }


        public int SocksPort
        {
            get { socksPort = int.Parse(GetInConfig("socks-port")); return socksPort; }
            set { socksPort = value; OnPropertyChanged(); SaveToConfigNotStr(value, "socks-port"); }
        }


        public int Port
        {
            get { port = int.Parse(GetInConfig("port")); return port; }
            set { port = value; OnPropertyChanged(); SaveToConfigNotStr(value, "port"); }
        }

    }
}
