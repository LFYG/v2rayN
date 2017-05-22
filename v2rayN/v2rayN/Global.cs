using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace v2rayN
{
    class Global
    {
        #region 常量

        /// <summary>
        /// 本软件配置文件名
        /// </summary>
        public const string ConfigFileName = "guiNConfig.json";

        /// <summary>
        /// v2ray配置文件名
        /// </summary>
        public const string v2rayConfigFileName = "config.json";

        /// <summary>
        /// v2ray配置样例文件名
        /// </summary>
        public const string v2raySampleFileName = "v2rayN.Mode.SampleConfig.txt";
        /// <summary>
        /// v2ray配置Httprequest文件名
        /// </summary>
        public const string v2raySampleHttprequestFileName = "v2rayN.Mode.SampleHttprequest.txt";
        /// <summary>
        /// v2ray配置Httpresponse文件名
        /// </summary>
        public const string v2raySampleHttpresponseFileName = "v2rayN.Mode.SampleHttpresponse.txt";


        /// <summary>
        /// 默认加密方式
        /// </summary>
        public const string DefaultSecurity = "aes-128-gcm";

        /// <summary>
        /// 默认传输协议
        /// </summary>
        public const string DefaultNetwork = "tcp";

        /// <summary>
        /// Tcp伪装http
        /// </summary>
        public const string TcpHeaderHttp = "http";

        /// <summary>
        /// None值
        /// </summary>
        public const string None = "none";

        /// <summary>
        /// 代理 tag值
        /// </summary>
        public const string agentTag = "agentout";

        /// <summary>
        /// 直连 tag值
        /// </summary>
        public const string directTag = "direct";

        /// <summary>
        /// 阻止 tag值
        /// </summary>
        public const string blockTag = "blockout";

        #endregion

        #region 全局变量

        /// <summary>
        /// 是否需要重启服务V2ray
        /// </summary>
        public static bool reloadV2ray { get; set; }


        #endregion
    }
}
