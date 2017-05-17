namespace v2rayN.Forms
{
    partial class OptionSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAllowIn2 = new System.Windows.Forms.CheckBox();
            this.chkudpEnabled2 = new System.Windows.Forms.CheckBox();
            this.cmbprotocol2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtlocalPort2 = new System.Windows.Forms.TextBox();
            this.cmbprotocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkudpEnabled = new System.Windows.Forms.CheckBox();
            this.chklogEnabled = new System.Windows.Forms.CheckBox();
            this.cmbloglevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlocalPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBypassChinasites = new System.Windows.Forms.CheckBox();
            this.chkBypassChinaip = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkmuxEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(355, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(267, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkmuxEnabled);
            this.groupBox1.Controls.Add(this.chkAllowIn2);
            this.groupBox1.Controls.Add(this.chkudpEnabled2);
            this.groupBox1.Controls.Add(this.cmbprotocol2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtlocalPort2);
            this.groupBox1.Controls.Add(this.cmbprotocol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkudpEnabled);
            this.groupBox1.Controls.Add(this.chklogEnabled);
            this.groupBox1.Controls.Add(this.cmbloglevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtlocalPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 260);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // chkAllowIn2
            // 
            this.chkAllowIn2.AutoSize = true;
            this.chkAllowIn2.Location = new System.Drawing.Point(13, 65);
            this.chkAllowIn2.Name = "chkAllowIn2";
            this.chkAllowIn2.Size = new System.Drawing.Size(102, 16);
            this.chkAllowIn2.TabIndex = 19;
            this.chkAllowIn2.Text = "本地监听端口2";
            this.chkAllowIn2.UseVisualStyleBackColor = true;
            this.chkAllowIn2.CheckedChanged += new System.EventHandler(this.chkAllowIn2_CheckedChanged);
            // 
            // chkudpEnabled2
            // 
            this.chkudpEnabled2.AutoSize = true;
            this.chkudpEnabled2.Location = new System.Drawing.Point(369, 64);
            this.chkudpEnabled2.Name = "chkudpEnabled2";
            this.chkudpEnabled2.Size = new System.Drawing.Size(66, 16);
            this.chkudpEnabled2.TabIndex = 18;
            this.chkudpEnabled2.Text = "开启UDP";
            this.chkudpEnabled2.UseVisualStyleBackColor = true;
            // 
            // cmbprotocol2
            // 
            this.cmbprotocol2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbprotocol2.FormattingEnabled = true;
            this.cmbprotocol2.Items.AddRange(new object[] {
            "socks",
            "http"});
            this.cmbprotocol2.Location = new System.Drawing.Point(257, 62);
            this.cmbprotocol2.Name = "cmbprotocol2";
            this.cmbprotocol2.Size = new System.Drawing.Size(97, 20);
            this.cmbprotocol2.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "协议";
            // 
            // txtlocalPort2
            // 
            this.txtlocalPort2.Location = new System.Drawing.Point(124, 62);
            this.txtlocalPort2.Name = "txtlocalPort2";
            this.txtlocalPort2.Size = new System.Drawing.Size(78, 21);
            this.txtlocalPort2.TabIndex = 14;
            // 
            // cmbprotocol
            // 
            this.cmbprotocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbprotocol.FormattingEnabled = true;
            this.cmbprotocol.Items.AddRange(new object[] {
            "socks",
            "http"});
            this.cmbprotocol.Location = new System.Drawing.Point(257, 25);
            this.cmbprotocol.Name = "cmbprotocol";
            this.cmbprotocol.Size = new System.Drawing.Size(97, 20);
            this.cmbprotocol.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "协议";
            // 
            // chkudpEnabled
            // 
            this.chkudpEnabled.AutoSize = true;
            this.chkudpEnabled.Location = new System.Drawing.Point(369, 27);
            this.chkudpEnabled.Name = "chkudpEnabled";
            this.chkudpEnabled.Size = new System.Drawing.Size(66, 16);
            this.chkudpEnabled.TabIndex = 10;
            this.chkudpEnabled.Text = "开启UDP";
            this.chkudpEnabled.UseVisualStyleBackColor = true;
            // 
            // chklogEnabled
            // 
            this.chklogEnabled.AutoSize = true;
            this.chklogEnabled.Location = new System.Drawing.Point(124, 190);
            this.chklogEnabled.Name = "chklogEnabled";
            this.chklogEnabled.Size = new System.Drawing.Size(156, 16);
            this.chklogEnabled.TabIndex = 9;
            this.chklogEnabled.Text = "记录本地日志(默认关闭)";
            this.chklogEnabled.UseVisualStyleBackColor = true;
            // 
            // cmbloglevel
            // 
            this.cmbloglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloglevel.FormattingEnabled = true;
            this.cmbloglevel.Items.AddRange(new object[] {
            "debug",
            "info",
            "warning",
            "error",
            "none"});
            this.cmbloglevel.Location = new System.Drawing.Point(124, 212);
            this.cmbloglevel.Name = "cmbloglevel";
            this.cmbloglevel.Size = new System.Drawing.Size(125, 20);
            this.cmbloglevel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "日志等级";
            // 
            // txtlocalPort
            // 
            this.txtlocalPort.Location = new System.Drawing.Point(124, 25);
            this.txtlocalPort.Name = "txtlocalPort";
            this.txtlocalPort.Size = new System.Drawing.Size(78, 21);
            this.txtlocalPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地监听端口";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 10);
            this.panel1.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 292);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(466, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  基础设置  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(466, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  路由设置  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBypassChinasites);
            this.groupBox2.Controls.Add(this.chkBypassChinaip);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 260);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // chkBypassChinasites
            // 
            this.chkBypassChinasites.AutoSize = true;
            this.chkBypassChinasites.Location = new System.Drawing.Point(29, 20);
            this.chkBypassChinasites.Name = "chkBypassChinasites";
            this.chkBypassChinasites.Size = new System.Drawing.Size(96, 16);
            this.chkBypassChinasites.TabIndex = 10;
            this.chkBypassChinasites.Text = "绕过大陆地址";
            this.chkBypassChinasites.UseVisualStyleBackColor = true;
            // 
            // chkBypassChinaip
            // 
            this.chkBypassChinaip.AutoSize = true;
            this.chkBypassChinaip.Location = new System.Drawing.Point(29, 42);
            this.chkBypassChinaip.Name = "chkBypassChinaip";
            this.chkBypassChinaip.Size = new System.Drawing.Size(84, 16);
            this.chkBypassChinaip.TabIndex = 11;
            this.chkBypassChinaip.Text = "绕过大陆IP";
            this.chkBypassChinaip.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 302);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 60);
            this.panel2.TabIndex = 11;
            // 
            // chkmuxEnabled
            // 
            this.chkmuxEnabled.AutoSize = true;
            this.chkmuxEnabled.Location = new System.Drawing.Point(124, 159);
            this.chkmuxEnabled.Name = "chkmuxEnabled";
            this.chkmuxEnabled.Size = new System.Drawing.Size(174, 16);
            this.chkmuxEnabled.TabIndex = 20;
            this.chkmuxEnabled.Text = "开启Mux多路复用(默认开启)";
            this.chkmuxEnabled.UseVisualStyleBackColor = true;
            // 
            // OptionSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(474, 362);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OptionSettingForm";
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.OptionSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbloglevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlocalPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chklogEnabled;
        private System.Windows.Forms.CheckBox chkudpEnabled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkBypassChinasites;
        private System.Windows.Forms.CheckBox chkBypassChinaip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbprotocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbprotocol2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtlocalPort2;
        private System.Windows.Forms.CheckBox chkudpEnabled2;
        private System.Windows.Forms.CheckBox chkAllowIn2;
        private System.Windows.Forms.CheckBox chkmuxEnabled;
    }
}