using System;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN
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
                VmessItem vmessItem = config.vmess[EditIndex];

                txtAddress.Text = vmessItem.address;
                txtPort.Text = vmessItem.port.ToString();
                txtId.Text = vmessItem.id;
                txtAlterId.Text = vmessItem.alterId.ToString();
                cmbSecurity.Text = vmessItem.security;
                cmbNetwork.Text = vmessItem.network;
                txtRemarks.Text = vmessItem.remarks;
            }
            else
            {
                txtAddress.Text = "";
                txtPort.Text = "";
                txtId.Text = "";
                txtAlterId.Text = "0";
                cmbSecurity.Text = "none";
                cmbNetwork.Text = "tcp";
                txtRemarks.Text = "";
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

            if (string.IsNullOrEmpty(address))
            {
                UI.Show("请填写地址");
                return;
            }
            if (string.IsNullOrEmpty(port) || !Utils.IsNumberic(port))
            {
                UI.Show("请填写正确格式端口");
                return;
            }
            if (string.IsNullOrEmpty(id))
            {
                UI.Show("请填写用户ID");
                return;
            }
            if (string.IsNullOrEmpty(alterId) || !Utils.IsNumberic(alterId))
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

    }
}
