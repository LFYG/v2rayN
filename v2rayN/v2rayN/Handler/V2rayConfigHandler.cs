using System.Collections.Generic;
using v2rayN.Mode;

namespace v2rayN.Handler
{
    /// <summary>
    /// v2ray配置文件处理类
    /// </summary>
    class V2rayConfigHandler
    {
        private static string v2rayConfigRes = Global.v2rayConfigFileName;
        private static string SampleRes = Global.v2raySampleFileName;

        /// <summary>
        /// 生成v2ray的配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int GenerateConfigFile(Config config, out string msg)
        {
            msg = string.Empty;

            try
            {
                //检查GUI设置
                if (config == null
                    || config.index < 0
                    || config.vmess.Count <= 0
                    || config.index > config.vmess.Count - 1
                    )
                {
                    msg = "请先检查服务器设置";
                    return -1;
                }

                msg = "初始化配置";

                //取得默认配置（取得V2raySampleConfig
                string result = Utils.GetEmbedText(SampleRes);
                if (Utils.IsNullOrEmpty(result))
                {
                    msg = "取得默认配置失败";
                    return -1;
                }

                //转成Json
                V2rayConfig v2rayConfig = Utils.FromJson<V2rayConfig>(result);
                if (v2rayConfig == null)
                {
                    msg = "生成默认配置失败";
                    return -1;
                }

                //开始修改配置
                //本地端口
                inbound(config, ref v2rayConfig);

                //额外的传入连接配置
                inboundDetour(config, ref v2rayConfig);

                //路由
                routing(config, ref v2rayConfig);

                //vmess协议服务器配置
                outbound(config, ref v2rayConfig);

                Utils.ToJsonFile(v2rayConfig, Utils.GetPath(v2rayConfigRes));

                msg = string.Format("配置成功 \r\n{0}({1}:{2})", config.remarks(), config.address(), config.port());
            }
            catch
            {
                msg = "异常，生成默认配置失败";
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 本地端口
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int inbound(Config config, ref V2rayConfig v2rayConfig)
        {
            try
            {
                //日志
                if (config.logEnabled)
                {
                    v2rayConfig.log.loglevel = config.loglevel;
                }
                else
                {
                    v2rayConfig.log.loglevel = "";
                    v2rayConfig.log.access = "";
                    v2rayConfig.log.error = "";
                }

                //端口
                v2rayConfig.inbound.port = config.inbound[0].localPort;
                v2rayConfig.inbound.protocol = config.inbound[0].protocol;

                //开启udp
                v2rayConfig.inbound.settings.udp = config.inbound[0].udpEnabled;
            }
            catch
            {
            }
            return 0;
        }


        /// <summary>
        /// 额外的传入连接配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int inboundDetour(Config config, ref V2rayConfig v2rayConfig)
        {
            try
            {
                //只有一个监听
                if (config.inbound.Count <= 1)
                {
                    return 0;
                }

                List<Inbound> inboundDetour = new List<Inbound>();
                v2rayConfig.inboundDetour = inboundDetour;

                //处理额外每个监听
                for (int k = 1; k < config.inbound.Count; k++)
                {
                    Inbound inbound = new Inbound();
                    inboundDetour.Add(inbound);

                    inbound.port = config.inbound[k].localPort;
                    inbound.listen = v2rayConfig.inbound.listen;
                    inbound.protocol = config.inbound[k].protocol;

                    Inboundsettings settings = new Inboundsettings();
                    inbound.settings = settings;
                    settings.auth = v2rayConfig.inbound.settings.auth;
                    settings.udp = config.inbound[k].udpEnabled;
                    settings.ip = v2rayConfig.inbound.settings.ip;
                }
            }
            catch
            {
            }
            return 0;
        }


        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int routing(Config config, ref V2rayConfig v2rayConfig)
        {
            try
            {
                if (v2rayConfig.routing != null
                  && v2rayConfig.routing.settings != null
                  && v2rayConfig.routing.settings.rules != null)
                {
                    //自定义
                    //需代理
                    routingUserRule(config.useragent, Global.agentTag, ref v2rayConfig);
                    //直连
                    routingUserRule(config.userdirect, Global.directTag, ref v2rayConfig);
                    //阻止
                    routingUserRule(config.userblock, Global.blockTag, ref v2rayConfig);

                    //绕过大陆网址
                    if (config.chinasites)
                    {
                        RulesItem rulesItem = new RulesItem();
                        rulesItem.type = "chinasites";
                        rulesItem.outboundTag = Global.directTag;
                        v2rayConfig.routing.settings.rules.Add(rulesItem);
                    }
                    //绕过大陆ip
                    if (config.chinaip)
                    {
                        RulesItem rulesItem = new RulesItem();
                        rulesItem.type = "chinaip";
                        rulesItem.outboundTag = Global.directTag;
                        v2rayConfig.routing.settings.rules.Add(rulesItem);
                    }
                }

            }
            catch
            {
            }
            return 0;
        }
        private static int routingUserRule(List<string> userRule, string tag, ref V2rayConfig v2rayConfig)
        {
            try
            {
                if (userRule != null
                    && userRule.Count > 0)
                {
                    //Domain
                    RulesItem rulesDomain = new RulesItem();
                    rulesDomain.type = "field";
                    rulesDomain.outboundTag = tag;
                    rulesDomain.domain = new List<string>();

                    //IP
                    RulesItem rulesIP = new RulesItem();
                    rulesIP.type = "field";
                    rulesIP.outboundTag = tag;
                    rulesIP.ip = new List<string>();

                    for (int k = 0; k < userRule.Count; k++)
                    {
                        string url = userRule[k].Trim();
                        if (Utils.IsNullOrEmpty(url))
                        {
                            continue;
                        }
                        if (Utils.IsIP(url))
                        {
                            rulesIP.ip.Add(url);
                        }
                        else if (Utils.IsDomain(url))
                        {
                            rulesDomain.domain.Add(url);
                        }
                    }
                    if (rulesDomain.domain.Count > 0)
                    {
                        v2rayConfig.routing.settings.rules.Add(rulesDomain);
                    }
                    if (rulesIP.ip.Count > 0)
                    {
                        v2rayConfig.routing.settings.rules.Add(rulesIP);
                    }
                }
            }
            catch
            {
            }
            return 0;
        }


        /// <summary>
        /// vmess协议服务器配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int outbound(Config config, ref V2rayConfig v2rayConfig)
        {
            try
            {
                VnextItem vnextItem;
                if (v2rayConfig.outbound.settings.vnext.Count <= 0)
                {
                    vnextItem = new VnextItem();
                    v2rayConfig.outbound.settings.vnext.Add(vnextItem);
                }
                else
                {
                    vnextItem = v2rayConfig.outbound.settings.vnext[0];
                }
                //远程服务器地址和端口
                vnextItem.address = config.address();
                vnextItem.port = config.port();

                UsersItem usersItem;
                if (vnextItem.users.Count <= 0)
                {
                    usersItem = new UsersItem();
                    vnextItem.users.Add(usersItem);
                }
                else
                {
                    usersItem = vnextItem.users[0];
                }
                //远程服务器用户ID
                usersItem.id = config.id();
                usersItem.alterId = config.alterId();
                usersItem.security = config.security();

                //Mux
                v2rayConfig.outbound.mux.enabled = config.muxEnabled;

                //远程服务器底层传输配置
                v2rayConfig.outbound.streamSettings.network = config.network();

                //streamSettings
                switch (config.network())
                {
                    //kcp基本配置暂时是默认值，用户能自己设置伪装类型
                    case "kcp":
                        Kcpsettings kcpsettings = new Kcpsettings();
                        kcpsettings.mtu = 1350;
                        kcpsettings.tti = 50;
                        kcpsettings.uplinkCapacity = 12;
                        kcpsettings.downlinkCapacity = 100;
                        kcpsettings.congestion = false;
                        kcpsettings.readBufferSize = 2;
                        kcpsettings.writeBufferSize = 2;
                        kcpsettings.header = new Header();
                        kcpsettings.header.type = config.headerType();
                        v2rayConfig.outbound.streamSettings.kcpsettings = kcpsettings;
                        break;
                    //ws
                    case "ws":
                        break;
                    default:
                        //tcp带http伪装
                        if (config.headerType().Equals(Global.TcpHeaderHttp))
                        {
                            TcpSettings tcpSettings = new TcpSettings();
                            tcpSettings.connectionReuse = true;
                            tcpSettings.header = new Header();
                            tcpSettings.header.type = config.headerType();

                            //request填入自定义Host
                            string request = Utils.GetEmbedText(Global.v2raySampleHttprequestFileName);
                            request = request.Replace("$requestHost$", string.Format("\"{0}\"", config.requestHost()));
                            string response = Utils.GetEmbedText(Global.v2raySampleHttpresponseFileName);

                            tcpSettings.header.request = Utils.FromJson<object>(request);
                            tcpSettings.header.response = Utils.FromJson<object>(response);
                            v2rayConfig.outbound.streamSettings.tcpSettings = tcpSettings;
                        }
                        break;
                }
            }
            catch
            {
            }
            return 0;
        }
    }
}
