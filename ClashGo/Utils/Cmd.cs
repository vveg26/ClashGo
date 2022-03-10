using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Utils
{
    public class Cmd
    {
        /// <summary>
        /// 命令行工具
        /// </summary>
        /// <param name="cmdStr">cmd命令</param>
        public void CmdLine(string cmdStr)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";//要启动的应用程序
            p.StartInfo.UseShellExecute = false;//不使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//允许输出信息
            p.StartInfo.RedirectStandardError = true;//允许输出错误
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            p.StandardInput.WriteLine(cmdStr);//向cmd窗口发送输入命令
            p.StandardInput.AutoFlush = true;//自动刷新
            //p.Close();
        }
    }
}
