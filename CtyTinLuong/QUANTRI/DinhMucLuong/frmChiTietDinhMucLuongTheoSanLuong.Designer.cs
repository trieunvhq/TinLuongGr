namespace CtyTinLuong
{
    partial class frmChiTietDinhMucLuongTheoSanLuong
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
            this.components = new System.ComponentModel.Container();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkNgungTheoDoi = new System.Windows.Forms.CheckBox();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDonGiaThuong = new System.Windows.Forms.TextBox();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDonGiaTang = new System.Windows.Forms.TextBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMaDinhMuc = new System.Windows.Forms.TextBox();
            this.btLUU = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridMaVTHH = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtTenVTHH = new System.Windows.Forms.TextBox();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxSanLuongThuong = new System.Windows.Forms.TextBox();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaVTHH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(397, 263);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 63;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.checkNgungTheoDoi;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 203);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(2, 205);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(447, 20);
            this.checkNgungTheoDoi.TabIndex = 15;
            this.checkNgungTheoDoi.Text = "Ngừng theo dõi";
            this.checkNgungTheoDoi.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDonGiaThuong;
            this.layoutControlItem4.CustomizationFormText = "Lương ngày thường";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 155);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem4.Text = "Đơn giá sản lượng thường (đ)";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(142, 13);
            // 
            // txtDonGiaThuong
            // 
            this.txtDonGiaThuong.Location = new System.Drawing.Point(147, 157);
            this.txtDonGiaThuong.Name = "txtDonGiaThuong";
            this.txtDonGiaThuong.Size = new System.Drawing.Size(302, 20);
            this.txtDonGiaThuong.TabIndex = 7;
            this.txtDonGiaThuong.TextChanged += new System.EventHandler(this.txtDonGiaThuong_TextChanged);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtDienGiai;
            this.layoutControlItem10.CustomizationFormText = "Diễn giải";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(451, 35);
            this.layoutControlItem10.Text = "Diễn giải";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(142, 13);
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(147, 26);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(302, 31);
            this.txtDienGiai.TabIndex = 13;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDonGiaTang;
            this.layoutControlItem6.CustomizationFormText = "Lương chủ nhật";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 179);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem6.Text = "Đơn giá sản lượng tăng (đ)";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(142, 13);
            // 
            // txtDonGiaTang
            // 
            this.txtDonGiaTang.Location = new System.Drawing.Point(147, 181);
            this.txtDonGiaTang.Name = "txtDonGiaTang";
            this.txtDonGiaTang.Size = new System.Drawing.Size(302, 20);
            this.txtDonGiaTang.TabIndex = 9;
            this.txtDonGiaTang.TextChanged += new System.EventHandler(this.txtDonGiaTang_TextChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMaDinhMuc;
            this.layoutControlItem2.CustomizationFormText = "Mã Định mức lương";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem2.Text = "Mã Định mức";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(142, 13);
            // 
            // txtMaDinhMuc
            // 
            this.txtMaDinhMuc.Location = new System.Drawing.Point(147, 2);
            this.txtMaDinhMuc.Name = "txtMaDinhMuc";
            this.txtMaDinhMuc.Size = new System.Drawing.Size(302, 20);
            this.txtMaDinhMuc.TabIndex = 5;
            // 
            // btLUU
            // 
            this.btLUU.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLUU.Location = new System.Drawing.Point(316, 263);
            this.btLUU.Name = "btLUU";
            this.btLUU.Size = new System.Drawing.Size(75, 23);
            this.btLUU.TabIndex = 64;
            this.btLUU.Text = "Lưu lại";
            this.btLUU.Click += new System.EventHandler(this.btLUU_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem10,
            this.layoutControlItem4,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(451, 227);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.gridMaVTHH;
            this.layoutControlItem14.CustomizationFormText = "Mã VTHH";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 59);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem14.Text = "Mã VTHH";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(142, 13);
            // 
            // gridMaVTHH
            // 
            this.gridMaVTHH.Location = new System.Drawing.Point(147, 61);
            this.gridMaVTHH.Name = "gridMaVTHH";
            this.gridMaVTHH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridMaVTHH.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridMaVTHH.Size = new System.Drawing.Size(123, 20);
            this.gridMaVTHH.StyleController = this.layoutControl1;
            this.gridMaVTHH.TabIndex = 17;
            this.gridMaVTHH.EditValueChanged += new System.EventHandler(this.gridMaVTHH_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clMaVT,
            this.clTenVTHH,
            this.clID_VTHH});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // clMaVT
            // 
            this.clMaVT.Caption = "Mã";
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 0;
            // 
            // clTenVTHH
            // 
            this.clTenVTHH.Caption = "Tên";
            this.clTenVTHH.FieldName = "TenVTHH";
            this.clTenVTHH.Name = "clTenVTHH";
            this.clTenVTHH.Visible = true;
            this.clTenVTHH.VisibleIndex = 1;
            this.clTenVTHH.Width = 309;
            // 
            // clID_VTHH
            // 
            this.clID_VTHH.Caption = "ID_VTHH";
            this.clID_VTHH.FieldName = "ID_VTHH";
            this.clID_VTHH.Name = "clID_VTHH";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtMaxSanLuongThuong);
            this.layoutControl1.Controls.Add(this.txtDVT);
            this.layoutControl1.Controls.Add(this.txtTenVTHH);
            this.layoutControl1.Controls.Add(this.gridMaVTHH);
            this.layoutControl1.Controls.Add(this.checkNgungTheoDoi);
            this.layoutControl1.Controls.Add(this.txtDienGiai);
            this.layoutControl1.Controls.Add(this.txtDonGiaTang);
            this.layoutControl1.Controls.Add(this.txtDonGiaThuong);
            this.layoutControl1.Controls.Add(this.txtMaDinhMuc);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(777, 87, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(451, 227);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(147, 109);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(76, 20);
            this.txtDVT.TabIndex = 19;
            // 
            // txtTenVTHH
            // 
            this.txtTenVTHH.Location = new System.Drawing.Point(147, 85);
            this.txtTenVTHH.Name = "txtTenVTHH";
            this.txtTenVTHH.ReadOnly = true;
            this.txtTenVTHH.Size = new System.Drawing.Size(302, 20);
            this.txtTenVTHH.TabIndex = 18;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(272, 59);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(179, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtTenVTHH;
            this.layoutControlItem1.CustomizationFormText = "Tên VTHH";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 83);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem1.Text = "Tên VTHH";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(142, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDVT;
            this.layoutControlItem3.CustomizationFormText = "ĐVT";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 107);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(225, 24);
            this.layoutControlItem3.Text = "ĐVT";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(142, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(225, 107);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(226, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 246);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Mã VTHH có thể để trống không chọn";
            // 
            // txtMaxSanLuongThuong
            // 
            this.txtMaxSanLuongThuong.Location = new System.Drawing.Point(147, 133);
            this.txtMaxSanLuongThuong.Name = "txtMaxSanLuongThuong";
            this.txtMaxSanLuongThuong.Size = new System.Drawing.Size(302, 20);
            this.txtMaxSanLuongThuong.TabIndex = 20;
            this.txtMaxSanLuongThuong.Text = "0";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtMaxSanLuongThuong;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 131);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(451, 24);
            this.layoutControlItem5.Text = "Giới hạn Sản lượng thường";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(142, 13);
            // 
            // frmChiTietDinhMucLuongTheoSanLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 296);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btLUU);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietDinhMucLuongTheoSanLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết định mức Lương theo sản lượng";
            this.Load += new System.EventHandler(this.frmChiTietDinhMucLuongTheoSanLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaVTHH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private System.Windows.Forms.CheckBox checkNgungTheoDoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.TextBox txtDonGiaThuong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private System.Windows.Forms.TextBox txtDienGiai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.TextBox txtDonGiaTang;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.TextBox txtMaDinhMuc;
        private DevExpress.XtraEditors.SimpleButton btLUU;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.GridLookUpEdit gridMaVTHH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtTenVTHH;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxSanLuongThuong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}