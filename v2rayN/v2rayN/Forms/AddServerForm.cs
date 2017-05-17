using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN.Forms
{
    public partial class AddServerForm : BaseForm
    {
        public int EditIndex { get; set; }

        public AddServerForm()
        {
            InitializeComponent();
        }

        private void AddServerForm_Load(object sender, EventArgs e)
        {
            if (EditIndex >= 0)
            {
                BindingServer();
            }
            else
            {
                ClearServer();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindingServer()
        {
            VmessItem vmessItem = config.vmess[EditIndex];

            txtAddress.Text = vmessItem.address;
            txtPort.Text = vmessItem.port.ToString();
            txtId.Text = vmessItem.id;
            txtAlterId.Text = vmessItem.alterId.ToString();
            cmbSecurity.Text = vmessItem.security;
            cmbNetwork.Text = vmessItem.network;
            txtRemarks.Text = vmessItem.remarks;

            cmbHeaderType.Text = vmessItem.headerType;
            txtRequestHost.Text = vmessItem.requestHost;
        }


        /// <summary>
        /// 清除设置
        /// </summary>
        private void ClearServer()
        {
            txtAddress.Text = "";
            txtPort.Text = "";
            txtId.Text = "";
            txtAlterId.Text = "0";
            cmbSecurity.Text = Global.DefaultSecurity;
            cmbNetwork.Text = Global.DefaultNetwork;
            txtRemarks.Text = "";

            cmbHeaderType.Text = Global.None;
            txtRequestHost.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text;
            string port = txtPort.Text;
            string id = txtId.Text;
            string alterId = txtAlterId.Text;
            string security = cmbSecurity.Text;
            string network = cmbNetwork.Text;
            string remarks = txtRemarks.Text;

            string headerType = cmbHeaderType.Text;
            string requestHost = txtRequestHost.Text;

            if (Utils.IsNullOrEmpty(address))
            {
                UI.Show("请填写地址");
                return;
            }
            if (Utils.IsNullOrEmpty(port) || !Utils.IsNumberic(port))
            {
                UI.Show("请填写正确格式端口");
                return;
            }
            if (Utils.IsNullOrEmpty(id))
            {
                UI.Show("请填写用户ID");
                return;
            }
            if (Utils.IsNullOrEmpty(alterId) || !Utils.IsNumberic(alterId))
            {
                UI.Show("请填写正确格式额外ID");
                return;
            }

            VmessItem vmessItem = new VmessItem();
            vmessItem.address = address;
            vmessItem.port = Convert.ToInt32(port);
            vmessItem.id = id;
            vmessItem.alterId = Convert.ToInt32(alterId);
            vmessItem.security = security;
            vmessItem.network = network;
            vmessItem.remarks = remarks;

            vmessItem.headerType = headerType;
            vmessItem.requestHost = requestHost;

            if (ConfigHandler.AddServer(ref config, vmessItem, EditIndex) == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                UI.Show("操作失败，请检查重试");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ClearServer();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Config|*.json|所有文件|*.*";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = fileDialog.FileName;
            if (Utils.IsNullOrEmpty(fileName))
            {
                return;
            }

            //载入配置文件 
            string result = Utils.LoadResource(fileName);
            if (Utils.IsNullOrEmpty(result))
            {
                UI.Show("读取配置文件失败");
                return;
            }

            //转成Json
            V2rayConfig v2rayConfig = Utils.FromJson<V2rayConfig>(result);
            if (v2rayConfig == null)
            {
                UI.Show("转换配置文件失败");
                return;
            }

            try
            {
                if (v2rayConfig.outbound == null
                    || Utils.IsNullOrEmpty(v2rayConfig.outbound.protocol)
                    || v2rayConfig.outbound.protocol != "vmess"
                    || v2rayConfig.outbound.settings == null
                    || v2rayConfig.outbound.settings.vnext == null
                    || v2rayConfig.outbound.settings.vnext.Count <= 0
                    || v2rayConfig.outbound.settings.vnext[0].users == null
                    || v2rayConfig.outbound.settings.vnext[0].users.Count <= 0)
                {
                    UI.Show("不是正确的客户端配置文件，请检查");
                    return;
                }

                txtAddress.Text = v2rayConfig.outbound.settings.vnext[0].address;
                txtPort.Text = v2rayConfig.outbound.settings.vnext[0].port.ToString();
                txtId.Text = v2rayConfig.outbound.settings.vnext[0].users[0].id;
                txtAlterId.Text = v2rayConfig.outbound.settings.vnext[0].users[0].alterId.ToString();

                txtRemarks.Text = string.Format("import@{0}", DateTime.Now.ToShortDateString());

                //tcp or kcp
                if (v2rayConfig.outbound.streamSettings != null
                    && v2rayConfig.outbound.streamSettings.network != null
                    && !Utils.IsNullOrEmpty(v2rayConfig.outbound.streamSettings.network))
                {
                    cmbNetwork.Text = v2rayConfig.outbound.streamSettings.network;
                }

                //tcp伪装http
                if (v2rayConfig.outbound.streamSettings != null
                    && v2rayConfig.outbound.streamSettings.tcpSettings != null
                    && v2rayConfig.outbound.streamSettings.tcpSettings.header != null
                    && !Utils.IsNullOrEmpty(v2rayConfig.outbound.streamSettings.tcpSettings.header.type))
                {
                    if (v2rayConfig.outbound.streamSettings.tcpSettings.header.type.Equals(Global.TcpHeaderHttp))
                    {
                        cmbHeaderType.Text = v2rayConfig.outbound.streamSettings.tcpSettings.header.type;
                        string request = Convert.ToString(v2rayConfig.outbound.streamSettings.tcpSettings.header.request);
                        if (!Utils.IsNullOrEmpty(request))
                        {
                            V2rayTcpRequest v2rayTcpRequest = JsonConvert.DeserializeObject<V2rayTcpRequest>(request);
                            if (v2rayTcpRequest != null
                                && v2rayTcpRequest.headers != null
                                && v2rayTcpRequest.headers.Host != null
                                && v2rayTcpRequest.headers.Host.Count > 0)
                            {
                                txtRequestHost.Text = v2rayTcpRequest.headers.Host[0];
                            }
                        }
                    }
                }
                //kcp伪装
                if (v2rayConfig.outbound.streamSettings != null
                    && v2rayConfig.outbound.streamSettings.kcpsettings != null
                    && v2rayConfig.outbound.streamSettings.kcpsettings.header != null
                    && !Utils.IsNullOrEmpty(v2rayConfig.outbound.streamSettings.kcpsettings.header.type))
                {
                    cmbHeaderType.Text = v2rayConfig.outbound.streamSettings.kcpsettings.header.type;
                }

            }
            catch
            {
                UI.Show("异常，不是正确的客户端配置文件，请检查");
                return;
            }

        }

    }
}
