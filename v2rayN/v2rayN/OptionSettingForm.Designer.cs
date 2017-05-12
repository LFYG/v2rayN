namespace v2rayN
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBypassChinasites = new System.Windows.Forms.CheckBox();
            this.chkBypassChinaip = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(251, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(163, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkudpEnabled);
            this.groupBox1.Controls.Add(this.chklogEnabled);
            this.groupBox1.Controls.Add(this.cmbloglevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtlocalPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 173);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // chkudpEnabled
            // 
            this.chkudpEnabled.AutoSize = true;
            this.chkudpEnabled.Location = new System.Drawing.Point(112, 62);
            this.chkudpEnabled.Name = "chkudpEnabled";
            this.chkudpEnabled.Size = new System.Drawing.Size(66, 16);
            this.chkudpEnabled.TabIndex = 10;
            this.chkudpEnabled.Text = "开启UDP";
            this.chkudpEnabled.UseVisualStyleBackColor = true;
            // 
            // chklogEnabled
            // 
            this.chklogEnabled.AutoSize = true;
            this.chklogEnabled.Location = new System.Drawing.Point(112, 90);
            this.chklogEnabled.Name = "chklogEnabled";
            this.chklogEnabled.Size = new System.Drawing.Size(96, 16);
            this.chklogEnabled.TabIndex = 9;
            this.chklogEnabled.Text = "记录本地日志";
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
            this.cmbloglevel.Location = new System.Drawing.Point(112, 112);
            this.cmbloglevel.Name = "cmbloglevel";
            this.cmbloglevel.Size = new System.Drawing.Size(143, 20);
            this.cmbloglevel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "日志等级";
            // 
            // txtlocalPort
            // 
            this.txtlocalPort.Location = new System.Drawing.Point(112, 24);
            this.txtlocalPort.Name = "txtlocalPort";
            this.txtlocalPort.Size = new System.Drawing.Size(143, 21);
            this.txtlocalPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 28);
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
            this.panel1.Size = new System.Drawing.Size(351, 10);
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
            this.tabControl1.Size = new System.Drawing.Size(351, 205);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(343, 179);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  基础设置  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkBypassChinaip);
            this.tabPage2.Controls.Add(this.chkBypassChinasites);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(343, 179);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  路由设置  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 60);
            this.panel2.TabIndex = 11;
            // 
            // chkBypassChinasites
            // 
            this.chkBypassChinasites.AutoSize = true;
            this.chkBypassChinasites.Location = new System.Drawing.Point(22, 19);
            this.chkBypassChinasites.Name = "chkBypassChinasites";
            this.chkBypassChinasites.Size = new System.Drawing.Size(96, 16);
            this.chkBypassChinasites.TabIndex = 10;
            this.chkBypassChinasites.Text = "绕过大陆地址";
            this.chkBypassChinasites.UseVisualStyleBackColor = true;
            // 
            // chkBypassChinaip
            // 
            this.chkBypassChinaip.AutoSize = true;
            this.chkBypassChinaip.Location = new System.Drawing.Point(22, 41);
            this.chkBypassChinaip.Name = "chkBypassChinaip";
            this.chkBypassChinaip.Size = new System.Drawing.Size(84, 16);
            this.chkBypassChinaip.TabIndex = 11;
            this.chkBypassChinaip.Text = "绕过大陆IP";
            this.chkBypassChinaip.UseVisualStyleBackColor = true;
            // 
            // OptionSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(351, 275);
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
            this.tabPage2.PerformLayout();
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
    }
}