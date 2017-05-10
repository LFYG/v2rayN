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
            txtlocalPort.Text = config.localPort.ToString();
            chkudpEnabled.Checked = config.udpEnabled;
            chklogEnabled.Checked = config.logEnabled;
            cmbloglevel.Text = config.loglevel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string localPort = txtlocalPort.Text;
            bool udpEnabled = chkudpEnabled.Checked;
            bool logEnabled = chklogEnabled.Checked;
            string loglevel = cmbloglevel.Text;

            if (string.IsNullOrEmpty(localPort) || !Utils.IsNumberic(localPort))
            {
                UI.Show("请填写本地监听端口");
                return;
            }

            config.localPort = Convert.ToInt32(localPort);
            config.udpEnabled = udpEnabled;
            config.logEnabled = logEnabled;
            config.loglevel = loglevel;

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
    }
}
