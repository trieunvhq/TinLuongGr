namespace CtyTinLuong
{
    partial class frmMuaHang2222
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
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDinhMucNPL = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDinhMucDOt = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navMuaHang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.btThooat = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navChiTiet_ALL = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(251, 14);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(727, 606);
            this.panelControl1.TabIndex = 71;
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "Phải trả";
            this.navBarItem8.Name = "navBarItem8";
            // 
            // navBarItemDinhMucNPL
            // 
            this.navBarItemDinhMucNPL.Caption = "Định mức NPL";
            this.navBarItemDinhMucNPL.Name = "navBarItemDinhMucNPL";
            // 
            // navBarItemDinhMucDOt
            // 
            this.navBarItemDinhMucDOt.Caption = "Định mức Đột";
            this.navBarItemDinhMucDOt.Name = "navBarItemDinhMucDOt";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem25,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12,
            this.navBarItem7,
            this.navBarItem3,
            this.navMuaHang,
            this.navBarItemDinhMucDOt,
            this.navBarItemDinhMucNPL,
            this.navBarItem8,
            this.navBarItem1,
            this.navChiTiet_ALL});
            this.navBarControl1.Location = new System.Drawing.Point(6, 14);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 238;
            this.navBarControl1.Size = new System.Drawing.Size(238, 606);
            this.navBarControl1.TabIndex = 69;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Mua hàng";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMuaHang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navChiTiet_ALL)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navMuaHang
            // 
            this.navMuaHang.Caption = "Mua hàng ";
            this.navMuaHang.Name = "navMuaHang";
            this.navMuaHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemMuaHang_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Trả lại hàng mua";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked_3);
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
            // navBarItem9
            // 
            this.navBarItem9.Caption = "Tổng hợp tồn kho";
            this.navBarItem9.Name = "navBarItem9";
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "navBarItem10";
            this.navBarItem10.Name = "navBarItem10";
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "navBarItem11";
            this.navBarItem11.Name = "navBarItem11";
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "navBarItem12";
            this.navBarItem12.Name = "navBarItem12";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "3. Xuất kho";
            this.navBarItem7.Name = "navBarItem7";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "4. Lệnh sản xuất";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // btThooat
            // 
            this.btThooat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThooat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThooat.Location = new System.Drawing.Point(903, 626);
            this.btThooat.Name = "btThooat";
            this.btThooat.Size = new System.Drawing.Size(75, 23);
            this.btThooat.TabIndex = 70;
            this.btThooat.Text = "Thoát";
            this.btThooat.Click += new System.EventHandler(this.btThooat_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 626);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 72;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cài mặc định người ký";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Công nợ";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            // 
            // navChiTiet_ALL
            // 
            this.navChiTiet_ALL.Caption = "Chi tiết _ALL";
            this.navChiTiet_ALL.Name = "navChiTiet_ALL";
            this.navChiTiet_ALL.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navChiTiet_ALL_LinkClicked);
            // 
            // frmMuaHang2222
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btThooat;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.btThooat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMuaHang2222";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mua hàng";
            this.Load += new System.EventHandler(this.frmMuaHang2222_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDinhMucNPL;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDinhMucDOt;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navMuaHang;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraEditors.SimpleButton btThooat;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navChiTiet_ALL;
    }
}