namespace CtyTinLuong
{
    partial class frmQuanLyKhoDaiLy
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navLuongDaiLy = new DevExpress.XtraNavBar.NavBarItem();
            this.navTamUng = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navNhapKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navXuatKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.btThooat = new DevExpress.XtraEditors.SimpleButton();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navNhapKhoGapDan = new DevExpress.XtraNavBar.NavBarItem();
            this.navXuatKhoGapDan = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.btGuiDuLieuLuong = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(216, 14);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(900, 606);
            this.panelControl1.TabIndex = 68;
            // 
            // navBarItem25
            // 
            this.navBarItem25.Caption = "* Tất cả";
            this.navBarItem25.Name = "navBarItem25";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "6. Chính thức";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.Tag = "Chính thức";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "5. Thử việc";
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.Tag = "Thử việc";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "4. Học việc";
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.Tag = "Học việc";
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "Báo cáo NXT_ALL";
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem10_LinkClicked);
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "NXT_Theo ĐL";
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem9_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Báo cáo";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem9),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navLuongDaiLy),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navTamUng),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem8),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem11),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem13)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navLuongDaiLy
            // 
            this.navLuongDaiLy.Caption = "Bảng lương tổng đại lý";
            this.navLuongDaiLy.Name = "navLuongDaiLy";
            this.navLuongDaiLy.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navLuongDaiLy_LinkClicked);
            // 
            // navTamUng
            // 
            this.navTamUng.Caption = "Tạm ứng đại lý";
            this.navTamUng.Name = "navTamUng";
            this.navTamUng.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navTamUng_LinkClicked);
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "Trả lương đại lý";
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem8_LinkClicked_1);
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "Bảng chi tiết lương ĐL";
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem11_LinkClicked);
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "BC Tồn kho";
            this.navBarItem13.Name = "navBarItem13";
            this.navBarItem13.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem13_LinkClicked);
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "4. xxxxxxxxx";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "3. Xuất kho";
            this.navBarItem7.Name = "navBarItem7";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Nhập Xuất";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navNhapKho),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navXuatKho),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navNhapKho
            // 
            this.navNhapKho.Caption = "Nhập kho";
            this.navNhapKho.Name = "navNhapKho";
            this.navNhapKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navNhapKho_LinkClicked);
            // 
            // navXuatKho
            // 
            this.navXuatKho.Caption = "Xuất kho";
            this.navXuatKho.Name = "navXuatKho";
            this.navXuatKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navXuatKho_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Nhập kho _ALL";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Xuất kho_ALL";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            // 
            // btThooat
            // 
            this.btThooat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThooat.Location = new System.Drawing.Point(1041, 626);
            this.btThooat.Name = "btThooat";
            this.btThooat.Size = new System.Drawing.Size(75, 23);
            this.btThooat.TabIndex = 67;
            this.btThooat.Text = "Thoát";
            this.btThooat.Click += new System.EventHandler(this.btThooat_Click);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem25,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem7,
            this.navBarItem3,
            this.navNhapKho,
            this.navXuatKho,
            this.navBarItem1,
            this.navBarItem2,
            this.navLuongDaiLy,
            this.navTamUng,
            this.navBarItem8,
            this.navBarItem11,
            this.navNhapKhoGapDan,
            this.navXuatKhoGapDan,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem12,
            this.navBarItem13});
            this.navBarControl1.Location = new System.Drawing.Point(6, 13);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 188;
            this.navBarControl1.Size = new System.Drawing.Size(188, 606);
            this.navBarControl1.TabIndex = 66;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Gấp dán";
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navNhapKhoGapDan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navXuatKhoGapDan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navNhapKhoGapDan
            // 
            this.navNhapKhoGapDan.Caption = "Nhập kho";
            this.navNhapKhoGapDan.Name = "navNhapKhoGapDan";
            this.navNhapKhoGapDan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navNhapKhoGapDan_LinkClicked);
            // 
            // navXuatKhoGapDan
            // 
            this.navXuatKhoGapDan.Caption = "Xuất kho";
            this.navXuatKhoGapDan.Name = "navXuatKhoGapDan";
            this.navXuatKhoGapDan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navXuatKhoGapDan_LinkClicked);
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "Báo cáo NXT";
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem12_LinkClicked);
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "Nhập kho _ Khác";
            this.navBarItem14.Name = "navBarItem14";
            this.navBarItem14.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem14_LinkClicked);
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "Xuất Kho _ Khác";
            this.navBarItem15.Name = "navBarItem15";
            this.navBarItem15.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem15_LinkClicked);
            // 
            // btGuiDuLieuLuong
            // 
            this.btGuiDuLieuLuong.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Forward;
            this.btGuiDuLieuLuong.Location = new System.Drawing.Point(216, 629);
            this.btGuiDuLieuLuong.Name = "btGuiDuLieuLuong";
            this.btGuiDuLieuLuong.Size = new System.Drawing.Size(145, 23);
            this.btGuiDuLieuLuong.TabIndex = 70;
            this.btGuiDuLieuLuong.Text = "Gửi dữ liệu Lương Đại lý";
            this.btGuiDuLieuLuong.Click += new System.EventHandler(this.btGuiDuLieuLuong_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 639);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 71;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cài mặc định người ký";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmQuanLyKhoDaiLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 661);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btGuiDuLieuLuong);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btThooat);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyKhoDaiLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đại lý";
            this.Load += new System.EventHandler(this.frmQuanLyKhoDaiLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraEditors.SimpleButton btThooat;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarItem navNhapKho;
        private DevExpress.XtraNavBar.NavBarItem navXuatKho;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navLuongDaiLy;
        private DevExpress.XtraNavBar.NavBarItem navTamUng;
        private DevExpress.XtraEditors.SimpleButton btGuiDuLieuLuong;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navNhapKhoGapDan;
        private DevExpress.XtraNavBar.NavBarItem navXuatKhoGapDan;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}