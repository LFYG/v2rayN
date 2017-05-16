using System;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN
{
    public partial class AddServerForm : BaseForm
    {
        public int EditIndex { get; set; }
        private TcpSettings tcpSettings;

        public AddServerForm()
        {
            InitializeComponent();
        }

        private void AddServerForm_Load(object sender, EventArgs e)
        {
            if (EditIndex >= 0)
            {
                VmessItem vmessItem = config.vmess[EditIndex];

                txtAddress.Text = vmessItem.address;
                txtPort.Text = vmessItem.port.ToString();
                txtId.Text = vmessItem.id;
                txtAlterId.Text = vmessItem.alterId.ToString();
                cmbSecurity.Text = vmessItem.security;
                cmbNetwork.Text = vmessItem.network;
                txtRemarks.Text = vmessItem.remarks;

                tcpSettings = vmessItem.tcpSettings;
            }
            else
            {
                ClearServer();
            }
            SettcpSettings();
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
            cmbSecurity.Text = "none";
            cmbNetwork.Text = "tcp";
            txtRemarks.Text = "";
            tcpSettings = null;
        }
        private void SettcpSettings()
        {
            if (tcpSettings != null)
            {
                chktcpSettings.Checked = true;
            }
            else
            {
                chktcpSettings.Checked = false;
            }
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
            if (tcpSettings != null)
            {
                vmessItem.tcpSettings = tcpSettings;
            }

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
                txtRemarks.Text = "import";

                txtAddress.Text = v2rayConfig.outbound.settings.vnext[0].address;
                txtPort.Text = v2rayConfig.outbound.settings.vnext[0].port.ToString();
                txtId.Text = v2rayConfig.outbound.settings.vnext[0].users[0].id;
                txtAlterId.Text = v2rayConfig.outbound.settings.vnext[0].users[0].alterId.ToString();


                //tcp kcp
                if (v2rayConfig.outbound.streamSettings != null
                    && v2rayConfig.outbound.streamSettings.network != null
                    && !Utils.IsNullOrEmpty(v2rayConfig.outbound.streamSettings.network))
                {
                    cmbNetwork.Text = v2rayConfig.outbound.streamSettings.network;
                }

                //http伪装
                if (v2rayConfig.outbound.streamSettings != null
                    && v2rayConfig.outbound.streamSettings.tcpSettings != null)
                {
                    tcpSettings = v2rayConfig.outbound.streamSettings.tcpSettings;
                }

                SettcpSettings();
            }
            catch
            {
                UI.Show("异常，不是正确的客户端配置文件，请检查");
                return;
            }

        }

    }
}
