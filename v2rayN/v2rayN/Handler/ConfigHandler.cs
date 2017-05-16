using System.Collections.Generic;
using v2rayN.Mode;

namespace v2rayN.Handler
{
    /// <summary>
    /// 本软件配置文件处理类
    /// </summary>
    class ConfigHandler
    {
        public static string configRes = "guiNConfig.json";

        /// <summary>
        /// 载入配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int LoadConfig(ref Config config)
        {
            //载入配置文件 
            string result = Utils.LoadResource(configRes);
            if (!Utils.IsNullOrEmpty(result))
            {
                //转成Json
                config = Utils.FromJson<Config>(result);
            }
            if (config == null)
            {
                config = new Config();
                config.index = -1;
                config.logEnabled = false;
                config.loglevel = "warning";
                config.vmess = new List<VmessItem>();

                //路由
                config.chinasites = false;
                config.chinaip = false;
            }

            //本地监听
            if (config.inbound == null)
            {
                config.inbound = new List<InItem>();
                InItem inItem = new InItem();
                inItem.protocol = "socks";
                inItem.localPort = 1080;
                inItem.udpEnabled = true;

                config.inbound.Add(inItem);
            }

            if (config == null
                || config.index < 0
                || config.vmess.Count <= 0
                || config.index > config.vmess.Count - 1
                )
            {
                config.reloadV2ray = false;
            }
            else
            {
                config.reloadV2ray = true;
            }

            return 0;
        }

        /// <summary>
        /// 添加服务器或编辑
        /// </summary>
        /// <param name="config"></param>
        /// <param name="vmessItem"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int AddServer(ref Config config, VmessItem vmessItem, int index)
        {
            if (index >= 0)
            {
                //修改
                config.vmess[index] = vmessItem;
                if (config.index.Equals(index))
                {
                    config.reloadV2ray = true;
                }
            }
            else
            {
                //添加
                config.vmess.Add(vmessItem);
                if (config.vmess.Count == 1)
                {
                    config.index = 0;
                    config.reloadV2ray = true;
                }
            }

            ToJsonFile(config);

            return 0;
        }

        /// <summary>
        /// 移除服务器
        /// </summary>
        /// <param name="config"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int RemoveServer(ref Config config, int index)
        {
            if (index < 0 || index > config.vmess.Count - 1)
            {
                return -1;
            }

            //删除
            config.vmess.RemoveAt(index);


            //移除的是默认的
            if (config.index.Equals(index))
            {
                if (config.vmess.Count > 0)
                {
                    config.index = 0;
                }
                else
                {
                    config.index = -1;
                }
                config.reloadV2ray = true;
            }
            else if (index < config.index)//移除默认之前的
            {
                config.index--;
                config.reloadV2ray = true;
            }

            ToJsonFile(config);

            return 0;
        }

        /// <summary>
        /// 复制服务器
        /// </summary>
        /// <param name="config"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int CopyServer(ref Config config, int index)
        {
            if (index < 0 || index > config.vmess.Count - 1)
            {
                return -1;
            }

            VmessItem vmessItem = new VmessItem();
            vmessItem.address = config.vmess[index].address;
            vmessItem.port = config.vmess[index].port;
            vmessItem.id = config.vmess[index].id;
            vmessItem.alterId = config.vmess[index].alterId;
            vmessItem.security = config.vmess[index].security;
            vmessItem.network = config.vmess[index].network;
            vmessItem.tcpSettings = config.vmess[index].tcpSettings;
            vmessItem.remarks = string.Format("{0}-副本", config.vmess[index].remarks);
            config.vmess.Add(vmessItem);

            ToJsonFile(config);

            return 0;
        }

        /// <summary>
        /// 设置默认服务器
        /// </summary>
        /// <param name="config"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int SetDefaultServer(ref Config config, int index)
        {
            if (index < 0 || index > config.vmess.Count - 1)
            {
                return -1;
            }

            ////和现在相同
            //if (config.index.Equals(index))
            //{
            //    return -1;
            //}
            config.index = index;
            config.reloadV2ray = true;

            ToJsonFile(config);

            return 0;
        }

        /// <summary>
        /// 保参数
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int SaveConfig(ref Config config)
        {
            config.reloadV2ray = true;

            ToJsonFile(config);

            return 0;
        }

        /// <summary>
        /// 存储文件
        /// </summary>
        /// <param name="config"></param>
        public static void ToJsonFile(Config config)
        {
            Utils.ToJsonFile(config, configRes);
        }

    }
}
