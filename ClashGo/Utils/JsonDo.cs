using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Utils
{
    internal class JsonDo
    {
        #region Json操作方法
        /// <summary>
        /// 读取Json文件的Key和Value
        /// </summary>
        /// <param name="jsonstr">json字符串</param>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public string JsonRead(string jsonstr, string key)
        {

            JObject obj = JObject.Parse(jsonstr);

            //Console.WriteLine(obj.Count);
            foreach (var x in obj)
            {
                if (x.Key == key)
                {
                    return x.Value.ToString();
                    
                }
            }
            return null;
        }
        //获取Key的Value
        //调用方法 JArray lists = (JArray) utils.JsonReadAll(jsonDataGlobal, "all");
        public Object JsonReadAll(string jsonstr, string key)
        {

            JObject obj = JObject.Parse(jsonstr);

            //Console.WriteLine(obj.Count);
            foreach (var x in obj)
            {
                if (x.Key == key)
                {
                    return x.Value;
                    
                }
            }
            return null;
        }
        /// <summary>
        /// 获取json字符串中所有的KV
        /// </summary>
        /// <param name="jsonData">json字符串</param>
        /// <returns>map</returns>
        public Dictionary<string, string> JsonGetAllKV(string jsonData)
        {
            JObject obj = JObject.Parse(jsonData);
            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (var x in obj)
            {
                map.Add(x.Key, x.Value.ToString());
            }
            return map;
        }
        /// <summary>
        /// 获取对应json字符串的Key数组
        /// </summary>
        /// <param name="key"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
/*        public Array GetArray(string key, string jsonData)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = js.Deserialize<dynamic>(jsonData);
            Array lists = data[key];
            return lists;
        }*/

        #endregion
    }
}
