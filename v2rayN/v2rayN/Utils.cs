using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace v2rayN
{
    class Utils
    {
        private static string autoRunName = "v2rayNAutoRun";
        private static string autoRunRegPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        #region 资源Json操作

        /// <summary>
        /// 获取嵌入文本资源
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static string GetEmbedText(string res)
        {
            string result = string.Empty;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(res))
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
            }
            return result;
        }


        /// <summary>
        /// 取得存储资源
        /// </summary>
        /// <returns></returns>
        public static string LoadResource(string res)
        {
            string result = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(res))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(string strJson)
        {
            try
            {
                T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strJson);
                return obj;
            }
            catch
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>("");
            }
        }

        /// <summary>
        /// 保存成json文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int ToJsonFile(Object obj, string filePath)
        {
            int result = -1;
            try
            {
                using (StreamWriter file = System.IO.File.CreateText(filePath))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, obj);
                }
                result = 0;
            }
            catch
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// List<string>转逗号分隔的字符串
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string List2String(List<string> lst)
        {
            try
            {
                return string.Join(",", lst.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 逗号分隔的字符串,转List<string>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> String2List(string str)
        {
            try
            {
                return new List<string>(str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            }
            catch
            {
                return new List<string>();
            }
        }

        #endregion

        #region 数据检查

        /// <summary>
        /// 判断输入的是否是数字
        /// </summary>
        /// <param name="oText"></param>
        /// <returns></returns>
        public static bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 文本
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            if (text.Equals("null"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证IP地址是否合法
        /// </summary>
        /// <param name="ip"></param>        
        public static bool IsIP(string ip)
        {
            //如果为空
            if (IsNullOrEmpty(ip))
            {
                return false;
            }

            //清除要验证字符串中的空格
            //ip = ip.Trim();

            //模式字符串
            string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";

            //验证
            return IsMatch(ip, pattern);
        }

        /// <summary>
        /// 验证Domain地址是否合法
        /// </summary>
        /// <param name="domain"></param>        
        public static bool IsDomain(string domain)
        {
            //如果为空
            if (IsNullOrEmpty(domain))
            {
                return false;
            }

            //清除要验证字符串中的空格
            //domain = domain.Trim();

            //模式字符串
            string pattern = @"^(?=^.{3,255}$)[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";

            //验证
            return IsMatch(domain, pattern);
        }

        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        #endregion

        #region 开机自动启动

        /// <summary>
        /// 开机自动启动
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public static int SetAutoRun(bool run)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine.CreateSubKey(autoRunRegPath);
                if (run)
                {
                    string exePath = Application.ExecutablePath;
                    regKey.SetValue(autoRunName, exePath);
                }
                else
                {
                    regKey.DeleteValue(autoRunName, false);
                }
                regKey.Close();
            }
            catch
            {
            }
            return 0;
        }

        /// <summary>
        /// 是否已经设置开机自动启动
        /// </summary>
        /// <returns></returns>
        public static bool IsAutoRun()
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine.CreateSubKey(autoRunRegPath);
                string value = regKey.GetValue(autoRunName).ToString();
                string exePath = GetExePath();
                if (value.Equals(exePath))
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// 获取启动了应用程序的可执行文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetPath(string fileName)
        {
            string StartupPath = System.Windows.Forms.Application.StartupPath;
            if (Utils.IsNullOrEmpty(fileName))
            {
                return StartupPath;
            }
            return string.Format("{0}\\{1}", StartupPath, fileName);

        }

        /// <summary>
        /// 获取启动了应用程序的可执行文件的路径及文件名
        /// </summary>
        /// <returns></returns>
        public static string GetExePath()
        {
            return System.Windows.Forms.Application.ExecutablePath;
        }

        #endregion

        #region 测速

        /// <summary>
        /// Ping
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static long Ping(string host)
        {
            long roundtripTime = 0;
            try
            {
                long totalTime = 0;
                int timeout = 120;
                int echoNum = 3;
                Ping pingSender = new Ping();
                for (int i = 0; i < echoNum; i++)
                {
                    PingReply reply = pingSender.Send(host, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        totalTime += reply.RoundtripTime;
                    }
                }
                roundtripTime = totalTime / echoNum;
            }
            catch
            {
                return -1;
            }
            return roundtripTime;
        }

        #endregion

        #region 杂项

        /// <summary>
        /// 取得版本
        /// </summary>
        /// <returns></returns>
        public static string GetVersion()
        {
            try
            {
                string location = GetExePath();
                return string.Format("v2rayN - V{0} - {1}",
                        FileVersionInfo.GetVersionInfo(location).FileVersion.ToString(),
                        File.GetLastWriteTime(location).ToString("yyyy/MM/dd"));
            }
            catch
            {
                return string.Empty;
            }
        }


        #endregion
    }
}
