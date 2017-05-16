using System;
using System.Windows.Forms;
using v2rayN.Handler;

namespace v2rayN
{
    public partial class OptionSettingForm : BaseForm
    {
        public OptionSettingForm()
        {
            InitializeComponent();
        }

        private void OptionSettingForm_Load(object sender, EventArgs e)
        {
            //日志
            chklogEnabled.Checked = config.logEnabled;
            cmbloglevel.Text = config.loglevel;

            //路由
            chkBypassChinasites.Checked = config.chinasites;
            chkBypassChinaip.Checked = config.chinaip;

            //本地监听
            if (config.inbound.Count > 0)
            {
                txtlocalPort.Text = config.inbound[0].localPort.ToString();
                cmbprotocol.Text = config.inbound[0].protocol.ToString();
                chkudpEnabled.Checked = config.inbound[0].udpEnabled;
                if (config.inbound.Count > 1)
                {
                    txtlocalPort2.Text = config.inbound[1].localPort.ToString();
                    cmbprotocol2.Text = config.inbound[1].protocol.ToString();
                    chkudpEnabled2.Checked = config.inbound[1].udpEnabled;
                    chkAllowIn2.Checked = true;
                }
                else
                {
                    chkAllowIn2.Checked = false;
                }
                chkAllowIn2State();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //日志
            bool logEnabled = chklogEnabled.Checked;
            string loglevel = cmbloglevel.Text;

            //路由
            bool bypassChinasites = chkBypassChinasites.Checked;
            bool bypassChinaip = chkBypassChinaip.Checked;

            //本地监听
            string localPort = txtlocalPort.Text;
            string protocol = cmbprotocol.Text;
            bool udpEnabled = chkudpEnabled.Checked;
            if (Utils.IsNullOrEmpty(localPort) || !Utils.IsNumberic(localPort))
            {
                UI.Show("请填写本地监听端口");
                return;
            }
            if (Utils.IsNullOrEmpty(protocol))
            {
                UI.Show("请选择协议");
                return;
            }
            config.inbound[0].localPort = Convert.ToInt32(localPort);
            config.inbound[0].protocol = protocol;
            config.inbound[0].udpEnabled = udpEnabled;

            //本地监听2
            string localPort2 = txtlocalPort2.Text;
            string protocol2 = cmbprotocol2.Text;
            bool udpEnabled2 = chkudpEnabled2.Checked;
            if (chkAllowIn2.Checked)
            {
                if (Utils.IsNullOrEmpty(localPort2) || !Utils.IsNumberic(localPort2))
                {
                    UI.Show("请填写本地监听端口2");
                    return;
                }
                if (Utils.IsNullOrEmpty(protocol2))
                {
                    UI.Show("请选择协议2");
                    return;
                }
                if (config.inbound.Count < 2)
                {
                    config.inbound.Add(new Mode.InItem());
                }
                config.inbound[1].localPort = Convert.ToInt32(localPort2);
                config.inbound[1].protocol = protocol2;
                config.inbound[1].udpEnabled = udpEnabled2;
            }
            else
            {
                if (config.inbound.Count > 1)
                {
                    config.inbound.RemoveAt(1);
                }
            }

            //日志     
            config.logEnabled = logEnabled;
            config.loglevel = loglevel;

            //路由
            config.chinasites = bypassChinasites;
            config.chinaip = bypassChinaip;

            if (ConfigHandler.SaveConfig(ref config) == 0)
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

        private void chkAllowIn2_CheckedChanged(object sender, EventArgs e)
        {
            chkAllowIn2State();
        }
        private void chkAllowIn2State()
        {
            bool blAllow2 = chkAllowIn2.Checked;
            txtlocalPort2.Enabled =
            cmbprotocol2.Enabled =
            chkudpEnabled2.Enabled = blAllow2;
        }
    }
}
