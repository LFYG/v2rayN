using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN.Forms
{
    public partial class MainForm : BaseForm
    {
        private V2rayHandler v2rayHandler;

        #region Window 事件

        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Text = Utils.GetVersion();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigHandler.LoadConfig(ref config);
            v2rayHandler = new V2rayHandler();
            v2rayHandler.ProcessEvent += v2rayHandler_ProcessEvent;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitServersView();
            RefreshServers();

            LoadV2ray();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                HideForm();
                return;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideForm();
            }
        }

        #endregion

        #region 显示服务器 listview 和 menu

        /// <summary>
        /// 刷新服务器
        /// </summary>
        private void RefreshServers()
        {
            RefreshServersView();
            RefreshServersMenu();
        }

        /// <summary>
        /// 初始化服务器列表
        /// </summary>
        private void InitServersView()
        {
            lvServers.Items.Clear();

            lvServers.GridLines = true;
            lvServers.FullRowSelect = true;
            lvServers.View = View.Details;
            lvServers.Scrollable = true;
            lvServers.MultiSelect = false;
            lvServers.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            lvServers.Columns.Add("默认", 40, HorizontalAlignment.Center);
            lvServers.Columns.Add("别名(remarks)", 120, HorizontalAlignment.Left);
            lvServers.Columns.Add("地址(address)", 110, HorizontalAlignment.Left);
            lvServers.Columns.Add("端口(port)", 80, HorizontalAlignment.Left);
            lvServers.Columns.Add("用户ID(id)", 110, HorizontalAlignment.Left);
            lvServers.Columns.Add("额外ID(alterId)", 110, HorizontalAlignment.Left);
            lvServers.Columns.Add("加密方式(security)", 120, HorizontalAlignment.Left);
            lvServers.Columns.Add("传输协议(network)", 120, HorizontalAlignment.Left);
            lvServers.Columns.Add("延迟(Latency)", 100, HorizontalAlignment.Left);

        }

        /// <summary>
        /// 刷新服务器列表
        /// </summary>
        private void RefreshServersView()
        {
            lvServers.Items.Clear();

            for (int k = 0; k < config.vmess.Count; k++)
            {
                string def = string.Empty;
                if (config.index.Equals(k))
                {
                    def = "√";
                }

                VmessItem item = config.vmess[k];
                ListViewItem lvItem = new ListViewItem(new string[] {  
                                                def,
                                                item.remarks,
                                                item.address,
                                                item.port.ToString(),
                                                item.id,
                                                item.alterId.ToString(),
                                                item.security,
                                                item.network,
                                                ""});
                lvServers.Items.Add(lvItem);
            }

        }

        /// <summary>
        /// 刷新托盘服务器菜单
        /// </summary>
        private void RefreshServersMenu()
        {
            menuServers.DropDownItems.Clear();

            for (int k = 0; k < config.vmess.Count; k++)
            {
                VmessItem item = config.vmess[k];
                string name = string.Format("{0}({1}:{2})", item.remarks, item.address, item.port);

                ToolStripMenuItem ts = new ToolStripMenuItem(name);
                ts.Tag = k;
                if (config.index.Equals(k))
                {
                    ts.Checked = true;
                }
                ts.Click += new EventHandler(ts_Click);
                menuServers.DropDownItems.Add(ts);
            }
        }
        private void ts_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem ts = (ToolStripItem)sender;
                int index = Convert.ToInt32(ts.Tag);
                SetDefaultServer(index);
            }
            catch
            {
            }
        }

        #endregion

        #region v2ray 操作

        /// <summary>
        /// 载入V2ray
        /// </summary>
        private void LoadV2ray()
        {
            if (Global.reloadV2ray)
            {
                ClearMsg();
            }
            v2rayHandler.LoadV2ray(config);
            Global.reloadV2ray = false;
        }

        /// <summary>
        /// 关闭V2ray
        /// </summary>
        private void CloseV2ray()
        {
            ConfigHandler.ToJsonFile(config);

            v2rayHandler.V2rayStop();
        }

        #endregion

        #region 功能按钮

        private void btnOptionSetting_Click(object sender, EventArgs e)
        {
            OptionSettingForm fm = new OptionSettingForm();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            AddServerForm fm = new AddServerForm();
            fm.EditIndex = -1;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }
        private void btnEditServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedIndices.Count <= 0)
            {
                UI.Show("请先选择服务器");
                return;
            }
            AddServerForm fm = new AddServerForm();
            fm.EditIndex = lvServers.SelectedIndices[0];
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }
        private void btnRemoveServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedIndices.Count <= 0)
            {
                UI.Show("请先选择服务器");
                return;
            }
            if (UI.ShowYesNo("是否确定移除服务器?") == DialogResult.No)
            {
                return;
            }

            int index = lvServers.SelectedIndices[0];
            if (ConfigHandler.RemoveServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        private void btnCopyServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedIndices.Count <= 0)
            {
                UI.Show("请先选择服务器");
                return;
            }

            int index = lvServers.SelectedIndices[0];
            if (ConfigHandler.CopyServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
            }
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedIndices.Count <= 0)
            {
                UI.Show("请先选择服务器");
                return;
            }
            int index = lvServers.SelectedIndices[0];
            SetDefaultServer(index);
        }

        private void btnSpeedTest_Click(object sender, EventArgs e)
        {
            bgwPing.RunWorkerAsync();
        }

        /// <summary>
        /// 设置默认服务器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int SetDefaultServer(int index)
        {
            if (index < 0)
            {
                UI.Show("请先选择服务器");
                return -1;
            }
            if (ConfigHandler.SetDefaultServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
            return 0;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Global.reloadV2ray = true;
            LoadV2ray();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.Close();
        }

        private void lvServers_DoubleClick(object sender, EventArgs e)
        {
            btnEditServer_Click(null, null);
        }
        #endregion


        #region 提示信息

        /// <summary>
        /// 消息委托
        /// </summary>
        /// <param name="notify"></param>
        /// <param name="msg"></param>
        void v2rayHandler_ProcessEvent(bool notify, string msg)
        {
            try
            {
                AppendText(msg);
                if (notify)
                {
                    notifyMsg(msg);
                }
            }
            catch
            {
            }
        }

        delegate void AppendTextDelegate(string text);
        void AppendText(string text)
        {
            if (this.txtMsgBox.InvokeRequired)
            {
                Invoke(new AppendTextDelegate(AppendText), new object[] { text });
            }
            else
            {
                //this.txtMsgBox.AppendText(text);
                ShowMsg(text);
            }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            this.txtMsgBox.AppendText(msg);
            if (!msg.EndsWith("\r\n"))
            {
                this.txtMsgBox.AppendText("\r\n");
            }
        }

        /// <summary>
        /// 清除信息
        /// </summary>
        private void ClearMsg()
        {
            this.txtMsgBox.Clear();
        }

        /// <summary>
        /// 托盘信息
        /// </summary>
        /// <param name="msg"></param>
        private void notifyMsg(string msg)
        {
            notifyMain.Text = msg;
        }

        #endregion


        #region 托盘事件

        private void notifyMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowForm();
            }
        }
        private void menuOpenMain_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            CloseV2ray();

            this.Visible = false;
            this.Close();
            //this.Dispose();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Global.UpdateUrl);
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            //this.notifyIcon1.Visible = false;
        }

        private void HideForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.notifyMain.Visible = true;
        }
        #endregion

        #region 后台测速

        private void bgwPing_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                for (int k = 0; k < config.vmess.Count; k++)
                {
                    long time = Utils.Ping(config.vmess[k].address);
                    bgwPing.ReportProgress(k, string.Format("{0}ms", time));
                }
            }
            catch
            {
            }
        }
        private void bgwPing_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                int k = e.ProgressPercentage;
                string time = Convert.ToString(e.UserState);
                lvServers.Items[k].SubItems[lvServers.Items[k].SubItems.Count - 1].Text = time;

            }
            catch
            {
            }
        }

        #endregion
    }
}
