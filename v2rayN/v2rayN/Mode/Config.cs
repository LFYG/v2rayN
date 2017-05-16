using System.Collections.Generic;

namespace v2rayN.Mode
{
    /// <summary>
    /// 本软件配置文件实体类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 本地监听
        /// </summary>
        public List<InItem> inbound { get; set; }

        /// <summary>
        /// 允许日志
        /// </summary>
        public bool logEnabled { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string loglevel { get; set; }

        /// <summary>
        /// 默认配置序号
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// vmess服务器信息
        /// </summary>
        public List<VmessItem> vmess { get; set; }

        /// <summary>
        /// 是否需要重启服务V2ray
        /// </summary>
        public bool reloadV2ray { get; set; }

        /// <summary>
        /// 路由=>绕过大陆网址
        /// </summary>
        public bool chinasites { get; set; }

        /// <summary>
        /// 路由=>绕过大陆ip
        /// </summary>
        public bool chinaip { get; set; }

        #region 函数

        public string address()
        {
            if (index < 0)
            {
                return string.Empty;
            }
            return vmess[index].address;
        }

        public int port()
        {
            if (index < 0)
            {
                return 1080;
            }
            return vmess[index].port;
        }

        public string id()
        {
            if (index < 0)
            {
                return string.Empty;
            }
            return vmess[index].id;
        }

        public int alterId()
        {
            if (index < 0)
            {
                return 0;
            }
            return vmess[index].alterId;
        }

        public string security()
        {
            if (index < 0)
            {
                return string.Empty;
            }
            return vmess[index].security;
        }

        public string remarks()
        {
            if (index < 0)
            {
                return string.Empty;
            }
            return vmess[index].remarks;
        }
        public string network()
        {
            if (index < 0 || Utils.IsNullOrEmpty(vmess[index].network))
            {
                return "tcp";
            }
            return vmess[index].network;
        }
        public TcpSettings tcpSettings()
        {
            if (index < 0)
            {
                return null;
            }
            return vmess[index].tcpSettings;
        }

        #endregion
    }

    public class VmessItem
    {
        /// <summary>
        /// 远程服务器地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 远程服务器端口
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// 远程服务器ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 远程服务器额外ID
        /// </summary>
        public int alterId { get; set; }
        /// <summary>
        /// 本地安全策略
        /// </summary>
        public string security { get; set; }
        /// <summary>
        /// tcp,kcp,ws
        /// </summary>
        public string network { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remarks { get; set; }

        /// <summary>
        ///  Tcp传输额外设置，直接复制给v2ray
        /// </summary>
        public TcpSettings tcpSettings { get; set; }
    }


    public class InItem
    {
        /// <summary>
        /// 本地监听端口
        /// </summary>
        public int localPort { get; set; }

        /// <summary>
        /// 协议，默认为socks
        /// </summary>
        public string protocol { get; set; }

        /// <summary>
        /// 允许udp
        /// </summary>
        public bool udpEnabled { get; set; }
    }
}
