using v2rayN.Mode;

namespace v2rayN.Handler
{
    /// <summary>
    /// v2ray配置文件处理类
    /// </summary>
    class V2rayConfigHandler
    {
        public static string v2rayConfigRes = "config.json";
        public static string SampleRes = "v2rayN.Mode.SampleConfig.txt";
        /// <summary>
        /// 生成v2ray的配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int GenerateConfigFile(Config config, out string msg)
        {
            msg = string.Empty;

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
            if (string.IsNullOrEmpty(result))
            {
                msg = "取得默认配置失败";
                return -1;
            }

            //转成Json
            V2rayConfig conf = Utils.FromJson<V2rayConfig>(result);
            if (conf == null)
            {
                msg = "生成默认配置失败";
                return -1;
            }

            //修改配置
            conf.inbound.port = config.localPort;
            if (config.logEnabled)
            {
                conf.log.loglevel = config.loglevel;
            }
            else
            {
                conf.log.loglevel = "";
                conf.log.access = "";
                conf.log.error = "";
            }
            conf.inbound.settings.udp = config.udpEnabled;

            VnextItem vnextItem;
            if (conf.outbound.settings.vnext.Count <= 0)
            {
                vnextItem = new VnextItem();
                conf.outbound.settings.vnext.Add(vnextItem);
            }
            else
            {
                vnextItem = conf.outbound.settings.vnext[0];
            }
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

            usersItem.id = config.id();
            usersItem.alterId = config.alterId();
            usersItem.security = config.security();


            Utils.ToJsonFile(conf, v2rayConfigRes);

            msg = string.Format("配置成功 \r\n{0}({1}:{2})", config.remarks(), config.address(), config.port());

            return 0;
        }


    }
}
