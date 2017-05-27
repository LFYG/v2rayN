using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN.Forms
{
    public partial class QRCodeForm : BaseForm
    {
        public int Index { get; set; }

        public QRCodeForm()
        {
            InitializeComponent();
        }

        private void QRCodeForm_Load(object sender, EventArgs e)
        {
        }

        private void QRCodeForm_Shown(object sender, EventArgs e)
        {
            if (Index >= 0)
            {
                VmessQRCode vmessQRCode = null;
                if (ConfigHandler.GetVmessQRCode(config, Index, ref vmessQRCode) != 0)
                {
                    return;
                }
                string url = Utils.ToJson(vmessQRCode);
                url = Utils.Base64Encode(url);
                url = string.Format("vmess://{0}", url);
                picQRCode.Image = QRCodeHelper.GetQRCode(url);
                txtUrl.Text = url;
            }
        }

    }
}
