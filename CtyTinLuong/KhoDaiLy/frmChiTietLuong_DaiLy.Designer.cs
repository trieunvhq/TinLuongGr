namespace CtyTinLuong
{
    partial class frmChiTietLuong_DaiLy
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_XuatKhoDaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgayChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuongXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTongTienHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_DaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaDaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenDaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btLayDuLieu = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1152, 450);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_XuatKhoDaiLy,
            this.clNgayChungTu,
            this.clSoChungTu,
            this.clSoLuongXuat,
            this.DonGia,
            this.clTongTienHang,
            this.clID_DaiLy,
            this.clMaDaiLy,
            this.clTenDaiLy,
            this.clMaVT,
            this.clTenVTHH,
            this.clDonViTinh,
            this.clID_VTHH});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTienHang", this.clTongTienHang, "{0:#,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuongXuat", this.clSoLuongXuat, "{0:#,##0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // clSTT
            // 
            this.clSTT.Caption = "STT";
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 40;
            // 
            // clID_XuatKhoDaiLy
            // 
            this.clID_XuatKhoDaiLy.Caption = "ID_XuatKhoDaiLy";
            this.clID_XuatKhoDaiLy.FieldName = "ID_XuatKhoDaiLy";
            this.clID_XuatKhoDaiLy.Name = "clID_XuatKhoDaiLy";
            // 
            // clNgayChungTu
            // 
            this.clNgayChungTu.Caption = "Ngày tháng";
            this.clNgayChungTu.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clNgayChungTu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayChungTu.FieldName = "NgayChungTu";
            this.clNgayChungTu.GroupFormat.FormatString = "dd/MM/yyyy";
            this.clNgayChungTu.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayChungTu.Name = "clNgayChungTu";
            this.clNgayChungTu.OptionsColumn.AllowEdit = false;
            this.clNgayChungTu.OptionsColumn.FixedWidth = true;
            this.clNgayChungTu.Visible = true;
            this.clNgayChungTu.VisibleIndex = 1;
            // 
            // clSoChungTu
            // 
            this.clSoChungTu.Caption = "Số";
            this.clSoChungTu.FieldName = "SoChungTu";
            this.clSoChungTu.Name = "clSoChungTu";
            this.clSoChungTu.OptionsColumn.AllowEdit = false;
            this.clSoChungTu.OptionsColumn.FixedWidth = true;
            this.clSoChungTu.Visible = true;
            this.clSoChungTu.VisibleIndex = 2;
            // 
            // clSoLuongXuat
            // 
            this.clSoLuongXuat.Caption = "Số lượng";
            this.clSoLuongXuat.FieldName = "SoLuongNhap";
            this.clSoLuongXuat.Name = "clSoLuongXuat";
            this.clSoLuongXuat.OptionsColumn.AllowEdit = false;
            this.clSoLuongXuat.OptionsColumn.FixedWidth = true;
            this.clSoLuongXuat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuongXuat", "{0:#,##0}")});
            this.clSoLuongXuat.Visible = true;
            this.clSoLuongXuat.VisibleIndex = 6;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DonGia.Caption = "Đơn giá";
            this.DonGia.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.DonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonGia.FieldName = "DonGia";
            this.DonGia.GroupFormat.FormatString = "{0:#,##0.00}";
            this.DonGia.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DonGia.Name = "DonGia";
            this.DonGia.OptionsColumn.AllowEdit = false;
            this.DonGia.OptionsColumn.FixedWidth = true;
            this.DonGia.Visible = true;
            this.DonGia.VisibleIndex = 8;
            this.DonGia.Width = 130;
            // 
            // clTongTienHang
            // 
            this.clTongTienHang.AppearanceCell.Options.UseTextOptions = true;
            this.clTongTienHang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clTongTienHang.Caption = "Thành tiền";
            this.clTongTienHang.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clTongTienHang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clTongTienHang.FieldName = "TongTienHang";
            this.clTongTienHang.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clTongTienHang.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clTongTienHang.Name = "clTongTienHang";
            this.clTongTienHang.OptionsColumn.AllowEdit = false;
            this.clTongTienHang.OptionsColumn.FixedWidth = true;
            this.clTongTienHang.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTienHang", "{0:#,##0.00}")});
            this.clTongTienHang.Visible = true;
            this.clTongTienHang.VisibleIndex = 9;
            this.clTongTienHang.Width = 130;
            // 
            // clID_DaiLy
            // 
            this.clID_DaiLy.Caption = "ID_DaiLy";
            this.clID_DaiLy.FieldName = "ID_DaiLy";
            this.clID_DaiLy.Name = "clID_DaiLy";
            // 
            // clMaDaiLy
            // 
            this.clMaDaiLy.AppearanceCell.Options.UseTextOptions = true;
            this.clMaDaiLy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clMaDaiLy.Caption = "Mã ĐL";
            this.clMaDaiLy.FieldName = "MaDaiLy";
            this.clMaDaiLy.Name = "clMaDaiLy";
            this.clMaDaiLy.OptionsColumn.AllowEdit = false;
            this.clMaDaiLy.OptionsColumn.FixedWidth = true;
            // 
            // clTenDaiLy
            // 
            this.clTenDaiLy.AppearanceCell.Options.UseTextOptions = true;
            this.clTenDaiLy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenDaiLy.Caption = "Tên Đại lý";
            this.clTenDaiLy.FieldName = "TenDaiLy";
            this.clTenDaiLy.Name = "clTenDaiLy";
            this.clTenDaiLy.OptionsColumn.AllowEdit = false;
            this.clTenDaiLy.Visible = true;
            this.clTenDaiLy.VisibleIndex = 4;
            this.clTenDaiLy.Width = 256;
            // 
            // clMaVT
            // 
            this.clMaVT.AppearanceCell.Options.UseTextOptions = true;
            this.clMaVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clMaVT.Caption = "Mã hàng";
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.OptionsColumn.AllowEdit = false;
            this.clMaVT.OptionsColumn.FixedWidth = true;
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 3;
            // 
            // clTenVTHH
            // 
            this.clTenVTHH.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVTHH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVTHH.Caption = "Tên hàng";
            this.clTenVTHH.FieldName = "TenVTHH";
            this.clTenVTHH.Name = "clTenVTHH";
            this.clTenVTHH.OptionsColumn.AllowEdit = false;
            this.clTenVTHH.Visible = true;
            this.clTenVTHH.VisibleIndex = 5;
            this.clTenVTHH.Width = 259;
            // 
            // clDonViTinh
            // 
            this.clDonViTinh.Caption = "ĐVT";
            this.clDonViTinh.FieldName = "DonViTinh";
            this.clDonViTinh.Name = "clDonViTinh";
            this.clDonViTinh.OptionsColumn.AllowEdit = false;
            this.clDonViTinh.OptionsColumn.FixedWidth = true;
            this.clDonViTinh.Visible = true;
            this.clDonViTinh.VisibleIndex = 7;
            // 
            // clID_VTHH
            // 
            this.clID_VTHH.Caption = "ID_VTHH";
            this.clID_VTHH.FieldName = "ID_VTHH";
            this.clID_VTHH.Name = "clID_VTHH";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataLayoutControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(1156, 493);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtNam);
            this.dataLayoutControl1.Controls.Add(this.txtThang);
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.btRefresh);
            this.dataLayoutControl1.Controls.Add(this.btPrint);
            this.dataLayoutControl1.Controls.Add(this.btLayDuLieu);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 13);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1156, 480);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(553, 2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(401, 20);
            this.txtNam.TabIndex = 97;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(35, 2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(481, 20);
            this.txtThang.TabIndex = 96;
            this.txtThang.TextChanged += new System.EventHandler(this.txtThang_TextChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(1123, 2);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(31, 22);
            this.btRefresh.StyleController = this.dataLayoutControl1;
            this.btRefresh.TabIndex = 82;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btPrint
            // 
            this.btPrint.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btPrint.Location = new System.Drawing.Point(958, 2);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(61, 22);
            this.btPrint.StyleController = this.dataLayoutControl1;
            this.btPrint.TabIndex = 95;
            this.btPrint.Text = "Print";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btLayDuLieu
            // 
            this.btLayDuLieu.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.button_yellow;
            this.btLayDuLieu.Location = new System.Drawing.Point(1023, 2);
            this.btLayDuLieu.Name = "btLayDuLieu";
            this.btLayDuLieu.Size = new System.Drawing.Size(96, 22);
            this.btLayDuLieu.StyleController = this.dataLayoutControl1;
            this.btLayDuLieu.TabIndex = 89;
            this.btLayDuLieu.Text = "Lấy dữ liệu";
            this.btLayDuLieu.Click += new System.EventHandler(this.btLayDuLieu_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1156, 480);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btLayDuLieu;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(1021, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btPrint;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(956, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(65, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btRefresh;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(1121, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(35, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1156, 454);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtThang;
            this.layoutControlItem7.CustomizationFormText = "Tháng";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(518, 26);
            this.layoutControlItem7.Text = "Tháng";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(30, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNam;
            this.layoutControlItem1.CustomizationFormText = "Năm";
            this.layoutControlItem1.Location = new System.Drawing.Point(518, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(438, 26);
            this.layoutControlItem1.Text = "Năm";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(30, 13);
            // 
            // frmChiTietLuong_DaiLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 493);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChiTietLuong_DaiLy";
            this.Text = "frmChiTietLuong_DaiLy";
            this.Load += new System.EventHandler(this.frmChiTietLuong_DaiLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraEditors.SimpleButton btPrint;
        private DevExpress.XtraEditors.SimpleButton btLayDuLieu;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_XuatKhoDaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clNgayChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn clSoChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuongXuat;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn clTongTienHang;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clMaDaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clTenDaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH;
    }
}