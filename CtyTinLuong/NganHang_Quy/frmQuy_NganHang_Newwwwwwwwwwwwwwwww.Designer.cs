namespace CtyTinLuong
{
    partial class frmQuy_NganHang_Newwwwwwwwwwwwwwwww
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBaoCo = new DevExpress.XtraNavBar.NavBarItem();
            this.navBaoNo = new DevExpress.XtraNavBar.NavBarItem();
            this.navPhieuThu = new DevExpress.XtraNavBar.NavBarItem();
            this.navPhieuChi = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navCongNo = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btThooat = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem25,
            this.navBarItem7,
            this.navBarItem3,
            this.navBaoCo,
            this.navCongNo,
            this.navBaoNo,
            this.navPhieuThu,
            this.navPhieuChi,
            this.navBarItem1});
            this.navBarControl1.Location = new System.Drawing.Point(12, 12);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 157;
            this.navBarControl1.Size = new System.Drawing.Size(157, 606);
            this.navBarControl1.TabIndex = 73;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Nghiệp vụ";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBaoCo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBaoNo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navPhieuThu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navPhieuChi)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBaoCo
            // 
            this.navBaoCo.Caption = "Báo Có";
            this.navBaoCo.Name = "navBaoCo";
            this.navBaoCo.Tag = ((short)(1));
            this.navBaoCo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBaoCo_LinkClicked);
            // 
            // navBaoNo
            // 
            this.navBaoNo.Caption = "Báo Nợ";
            this.navBaoNo.Name = "navBaoNo";
            this.navBaoNo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBaoNo_LinkClicked);
            // 
            // navPhieuThu
            // 
            this.navPhieuThu.Caption = "Phiếu thu";
            this.navPhieuThu.Name = "navPhieuThu";
            this.navPhieuThu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navPhieuThu_LinkClicked);
            // 
            // navPhieuChi
            // 
            this.navPhieuChi.Caption = "Phiếu chi";
            this.navPhieuChi.Name = "navPhieuChi";
            this.navPhieuChi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navPhieuChi_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Báo cáo";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navCongNo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navCongNo
            // 
            this.navCongNo.Caption = "Công nợ";
            this.navCongNo.Name = "navCongNo";
            this.navCongNo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navCongNo_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Chi tiết tài khoản";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "4. Học việc";
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.Tag = "Học việc";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "5. Thử việc";
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.Tag = "Thử việc";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "6. Chính thức";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.Tag = "Chính thức";
            // 
            // navBarItem25
            // 
            this.navBarItem25.Caption = "* Tất cả";
            this.navBarItem25.Name = "navBarItem25";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "3. Xuất kho";
            this.navBarItem7.Name = "navBarItem7";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "4. xxxxxxxxx";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(175, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(969, 606);
            this.panelControl1.TabIndex = 75;
            // 
            // btThooat
            // 
            this.btThooat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThooat.Location = new System.Drawing.Point(1069, 624);
            this.btThooat.Name = "btThooat";
            this.btThooat.Size = new System.Drawing.Size(75, 23);
            this.btThooat.TabIndex = 76;
            this.btThooat.Text = "Thoát";
            this.btThooat.Click += new System.EventHandler(this.btThooat_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 624);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 77;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cài mặc định người ký";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmQuy_NganHang_Newwwwwwwwwwwwwwwww
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 655);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btThooat);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.Name = "frmQuy_NganHang_Newwwwwwwwwwwwwwwww";
            this.Text = "Quản lý Quỹ Ngân hàng";
            this.Load += new System.EventHandler(this.frmQuy_NganHang_Newwwwwwwwwwwwwwwww_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBaoCo;
        private DevExpress.XtraNavBar.NavBarItem navBaoNo;
        private DevExpress.XtraNavBar.NavBarItem navPhieuThu;
        private DevExpress.XtraNavBar.NavBarItem navPhieuChi;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navCongNo;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btThooat;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
    }
}