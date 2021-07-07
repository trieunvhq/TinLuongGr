namespace CtyTinLuong
{
    partial class NganHang_frm_ChiTiet_MuaHang_banHang
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3});
            this.gridControl1.Size = new System.Drawing.Size(722, 469);
            this.gridControl1.TabIndex = 96;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView4.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView4.Appearance.Row.Options.UseTextOptions = true;
            this.gridView4.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView4.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView4.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT2,
            this.clSoLuong,
            this.clDonGia,
            this.clTenVTHH,
            this.clDonViTinh,
            this.clThanhTien,
            this.clMaVT,
            this.clGhiChu});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", this.clThanhTien, "")});
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView4.OptionsView.RowAutoHeight = true;
            this.gridView4.OptionsView.ShowFooter = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // clSTT2
            // 
            this.clSTT2.Caption = "STT";
            this.clSTT2.Name = "clSTT2";
            this.clSTT2.OptionsColumn.AllowEdit = false;
            this.clSTT2.OptionsColumn.FixedWidth = true;
            this.clSTT2.Visible = true;
            this.clSTT2.VisibleIndex = 0;
            this.clSTT2.Width = 43;
            // 
            // clSoLuong
            // 
            this.clSoLuong.Caption = "Số lượng";
            this.clSoLuong.FieldName = "SoLuong";
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.OptionsColumn.AllowEdit = false;
            this.clSoLuong.OptionsColumn.FixedWidth = true;
            this.clSoLuong.Visible = true;
            this.clSoLuong.VisibleIndex = 3;
            this.clSoLuong.Width = 80;
            // 
            // clDonGia
            // 
            this.clDonGia.AppearanceCell.Options.UseTextOptions = true;
            this.clDonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clDonGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDonGia.Caption = "Đơn giá (đ)";
            this.clDonGia.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDonGia.FieldName = "DonGia";
            this.clDonGia.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clDonGia.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.OptionsColumn.AllowEdit = false;
            this.clDonGia.Visible = true;
            this.clDonGia.VisibleIndex = 5;
            this.clDonGia.Width = 156;
            // 
            // clTenVTHH
            // 
            this.clTenVTHH.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVTHH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVTHH.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenVTHH.Caption = "Tên hàng hóa";
            this.clTenVTHH.ColumnEdit = this.repositoryItemMemoEdit3;
            this.clTenVTHH.FieldName = "TenVTHH";
            this.clTenVTHH.Name = "clTenVTHH";
            this.clTenVTHH.OptionsColumn.AllowEdit = false;
            this.clTenVTHH.OptionsColumn.ReadOnly = true;
            this.clTenVTHH.Visible = true;
            this.clTenVTHH.VisibleIndex = 2;
            this.clTenVTHH.Width = 255;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // clDonViTinh
            // 
            this.clDonViTinh.Caption = "ĐVT";
            this.clDonViTinh.FieldName = "DonViTinh";
            this.clDonViTinh.Name = "clDonViTinh";
            this.clDonViTinh.OptionsColumn.AllowEdit = false;
            this.clDonViTinh.OptionsColumn.FixedWidth = true;
            this.clDonViTinh.Visible = true;
            this.clDonViTinh.VisibleIndex = 4;
            this.clDonViTinh.Width = 60;
            // 
            // clThanhTien
            // 
            this.clThanhTien.AppearanceCell.Options.UseTextOptions = true;
            this.clThanhTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clThanhTien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clThanhTien.Caption = "Thành tiền (đ)";
            this.clThanhTien.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThanhTien.FieldName = "ThanhTien";
            this.clThanhTien.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clThanhTien.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.OptionsColumn.AllowEdit = false;
            this.clThanhTien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:#,##0.00}")});
            this.clThanhTien.Visible = true;
            this.clThanhTien.VisibleIndex = 6;
            this.clThanhTien.Width = 131;
            // 
            // clMaVT
            // 
            this.clMaVT.Caption = "Mã VT";
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.OptionsColumn.AllowEdit = false;
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 1;
            this.clMaVT.Width = 73;
            // 
            // clGhiChu
            // 
            this.clGhiChu.Caption = "Ghi chú";
            this.clGhiChu.ColumnEdit = this.repositoryItemMemoEdit3;
            this.clGhiChu.FieldName = "GhiChu";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.OptionsColumn.AllowEdit = false;
            this.clGhiChu.Visible = true;
            this.clGhiChu.VisibleIndex = 7;
            this.clGhiChu.Width = 101;
            // 
            // NganHang_frm_ChiTiet_MuaHang_banHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 469);
            this.Controls.Add(this.gridControl1);
            this.Name = "NganHang_frm_ChiTiet_MuaHang_banHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đơn hàng";
            this.Load += new System.EventHandler(this.NganHang_frm_ChiTiet_MuaHang_banHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT2;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn clDonGia;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn clThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clGhiChu;
    }
}