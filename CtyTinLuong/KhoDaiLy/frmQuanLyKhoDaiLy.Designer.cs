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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyKhoDaiLy));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBangLuongDaiLy = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navNhapKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navXuatKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navChoNhapKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navChoXuatKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navNhapKhoGapDan = new DevExpress.XtraNavBar.NavBarItem();
            this.navXuatKhoGapDan = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(228, 14);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(921, 606);
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
            this.navBarItem10.Caption = "Báo cáo Nhập- Xuất - Tồn";
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem10_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Báo cáo";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem13),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBangLuongDaiLy)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "Báo cáo Tồn Kho";
            this.navBarItem13.Name = "navBarItem13";
            this.navBarItem13.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem13_LinkClicked);
            // 
            // navBangLuongDaiLy
            // 
            this.navBangLuongDaiLy.Caption = "Bảng lương Đại lý";
            this.navBangLuongDaiLy.Name = "navBangLuongDaiLy";
            this.navBangLuongDaiLy.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBangLuongDaiLy_LinkClicked);
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
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navChoNhapKho),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navChoXuatKho)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navNhapKho
            // 
            this.navNhapKho.Caption = "Đã Nhập kho";
            this.navNhapKho.Name = "navNhapKho";
            this.navNhapKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navNhapKho_LinkClicked);
            // 
            // navXuatKho
            // 
            this.navXuatKho.Caption = "Đã Xuất kho";
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
            // navChoNhapKho
            // 
            this.navChoNhapKho.Caption = "Chờ nhập kho";
            this.navChoNhapKho.Name = "navChoNhapKho";
            this.navChoNhapKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navChoNhapKho_LinkClicked);
            // 
            // navChoXuatKho
            // 
            this.navChoXuatKho.Caption = "Chờ xuất kho";
            this.navChoXuatKho.Name = "navChoXuatKho";
            this.navChoXuatKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem9_LinkClicked);
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
            this.navBarItem10,
            this.navBarItem7,
            this.navBarItem3,
            this.navNhapKho,
            this.navXuatKho,
            this.navBarItem1,
            this.navBarItem2,
            this.navNhapKhoGapDan,
            this.navXuatKhoGapDan,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem12,
            this.navBarItem13,
            this.navBangLuongDaiLy,
            this.navChoNhapKho,
            this.navChoXuatKho});
            this.navBarControl1.Location = new System.Drawing.Point(6, 13);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 216;
            this.navBarControl1.Size = new System.Drawing.Size(216, 606);
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
            this.ClientSize = new System.Drawing.Size(1156, 662);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmQuanLyKhoDaiLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đại Lý";
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
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarItem navNhapKho;
        private DevExpress.XtraNavBar.NavBarItem navXuatKho;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navNhapKhoGapDan;
        private DevExpress.XtraNavBar.NavBarItem navXuatKhoGapDan;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraNavBar.NavBarItem navBangLuongDaiLy;
        private DevExpress.XtraNavBar.NavBarItem navChoNhapKho;
        private DevExpress.XtraNavBar.NavBarItem navChoXuatKho;
    }
}