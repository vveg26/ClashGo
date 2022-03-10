using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClashGo.Utils
{
    public class UtilsCommon
    {
        #region 读取Ini文件的操作
        //需要调用GetPrivateProfileString的重载
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, Byte[] retVal, int size, string filePath);

        /// <summary>
        /// 获取指定Section，指定Key的Value
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="iniFilePath">ini文件的地址</param>
        /// <returns>Value</returns>
        public string IniReadValue(string Section, string Key, string iniFilePath)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp, 255, iniFilePath);
            return temp.ToString();
        }
        /// <summary>
        /// 获取指定Section中的所有键值对
        /// </summary>
        /// <param name="SectionName"></param>
        /// <param name="iniFilePath">ini路径</param>
        /// <returns>键值对字典</returns>
        public Dictionary<string, string> IniReadMap(string SectionName, string iniFilePath)
        {
            // List<string> result = new List<string>();
            Dictionary<string, string> resultMap = new Dictionary<string, string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(SectionName, null, null, buf, buf.Length, iniFilePath);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    //将键值对存入到字典中
                    resultMap.Add(Encoding.Default.GetString(buf, j, i - j), IniReadValue(SectionName, Encoding.Default.GetString(buf, j, i - j), iniFilePath));//获取Key和Valuve
                                                                                                                                                                // result.Add(IniReadValue(SectionName, Encoding.Default.GetString(buf, j, i - j),iniFilename));//获取Value
                    j = i + 1;
                }
            return resultMap;
        }
        #endregion


        #region 文件操作方法
        /// <summary>
        /// 将文本写入文件的第一行
        /// </summary>
        /// <param name="filenPath">文件名</param>
        /// <param name="str">写入字符串</param>
        public void WriteFirstLine(string filePath, string str)
        {
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(filePath))
            {
                writer.WriteLine(str);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, filePath, true);
        }
        /// <summary>
        /// 拷贝文件到另一个文件夹下
        /// </summary>
        /// <param name="sourceName">源文件路径</param>
        /// <param name="folderPath">目标路径（目标文件夹）</param>
        public void CopyToFile(string sourceName, string folderPath)
        {
            //例子：
            //源文件路径
            //string sourceName = @"D:\Source\Test.txt";
            //目标路径:项目下的NewTest文件夹,(如果没有就创建该文件夹)
            //string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NewTest");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //当前文件如果不用新的文件名，那么就用原文件文件名
            string fileName = Path.GetFileName(sourceName);
            //这里可以给文件换个新名字，如下：
            //string fileName = string.Format("{0}.{1}", "newFileText", "txt");

            //目标整体路径
            string targetPath = Path.Combine(folderPath, fileName);

            //Copy到新文件下
            FileInfo file = new FileInfo(sourceName);
            if (file.Exists)
            {
                //true 为覆盖已存在的同名文件，false 为不覆盖
                file.CopyTo(targetPath, true);
            }
        }
        #endregion






        /// <summary>
        /// Kill进程
        /// </summary>
        /// <param name="processName"></param>
        /// <exception cref="Exception"></exception>
        public void KillProcess(string processName)
        {
            //获得进程对象，以用来操作  
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程   
            try
            {
                //获得需要杀死的进程名  
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    //立即杀死进程  
                    thisproc.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }




        /// <summary>
        /// 获得目录下所有文件或指定文件类型文件(包含所有子文件夹)
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
        /// <returns>List<FileInfo></returns>
        public List<System.IO.FileInfo> GetFiles(string path, string ExtName)
        {

            try
            {
                List<FileInfo> lst = new List<FileInfo>();
                string[] dir = System.IO.Directory.GetDirectories(path);// 文件夹列表
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
                System.IO.FileInfo[] files = directoryInfo.GetFiles();
                if (files.Length != 0 || dir.Length != 0) // 当前目录文件或文件夹不能为空
                {
                    foreach (System.IO.FileInfo f in files)
                    {
                        if (ExtName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir)
                    {
                        GetFiles(d, ExtName);
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
