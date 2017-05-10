using System.Collections.Generic;

namespace v2rayN.Mode
{
    /// <summary>
    /// v2ray配置文件实体类
    /// 例子SampleConfig.txt
    /// </summary>
    public class V2rayConfig
    {
        /// <summary>
        /// 日志配置
        /// </summary>
        public Log log { get; set; }
        /// <summary>
        /// 传入连接配置
        /// </summary>
        public Inbound inbound { get; set; }
        /// <summary>
        /// 传出连接配置
        /// </summary>
        public Outbound outbound { get; set; }
        /// <summary>
        /// 额外的传出连接配置
        /// </summary>
        public List<OutboundDetourItem> outboundDetour { get; set; }
        /// <summary>
        /// DNS 配置
        /// </summary>
        public Dns dns { get; set; }
        /// <summary>
        /// 路由配置
        /// </summary>
        public Routing routing { get; set; }
    }

    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        public string access { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string loglevel { get; set; }
    }

    public class Inboundsettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string auth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool udp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
    }

    public class Inbound
    {
        /// <summary>
        /// 
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string listen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Inboundsettings settings { get; set; }
    }

    public class UsersItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int alterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string security { get; set; }
    }

    public class VnextItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UsersItem> users { get; set; }
    }

    public class Outboundsettings
    {
        /// <summary>
        /// 
        /// </summary>
        public List<VnextItem> vnext { get; set; }
    }

    public class Mux
    {
        /// <summary>
        /// 
        /// </summary>
        public bool enabled { get; set; }
    }

    public class Outbound
    {
        /// <summary>
        /// 
        /// </summary>
        public string protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Outboundsettings settings { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Mux mux { get; set; }
    }

    public class OutboundDetoursettings
    {
    }

    public class OutboundDetourItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OutboundDetoursettings settings { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tag { get; set; }
    }

    public class Dns
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> servers { get; set; }
    }

    public class RulesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string outboundTag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> ip { get; set; }
    }

    public class Routingsettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string domainStrategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RulesItem> rules { get; set; }
    }

    public class Routing
    {
        /// <summary>
        /// 
        /// </summary>
        public string strategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Routingsettings settings { get; set; }
    }
}
