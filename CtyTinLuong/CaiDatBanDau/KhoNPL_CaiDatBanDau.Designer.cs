namespace CtyTinLuong
{
    partial class KhoNPL_CaiDatBanDau
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_ChiTietTonDauKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTonTai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clID_VTHH2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa2,
            this.repositoryItemGridLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(724, 572);
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
            this.clSTT,
            this.clID_ChiTietTonDauKy,
            this.clSoLuong,
            this.clDonGia,
            this.clTonTai,
            this.clNgungTheoDoi,
            this.clTenVTHH,
            this.clDonViTinh,
            this.clHienThi,
            this.clThanhTien,
            this.clXoa,
            this.clMaVT,
            this.clID_VTHH});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", this.clThanhTien, "")});
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView4.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView4.OptionsView.RowAutoHeight = true;
            this.gridView4.OptionsView.ShowFooter = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView4_CustomDrawCell);
            this.gridView4.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView4_InitNewRow);
            this.gridView4.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView4_CellValueChanged);
            this.gridView4.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView4_ValidateRow);
            this.gridView4.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.gridView4_CustomRowFilter);
            // 
            // clSTT
            // 
            this.clSTT.Caption = "STT";
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 43;
            // 
            // clID_ChiTietTonDauKy
            // 
            this.clID_ChiTietTonDauKy.Caption = "ID_ChiTietTonDauKy";
            this.clID_ChiTietTonDauKy.FieldName = "ID_ChiTietTonDauKy";
            this.clID_ChiTietTonDauKy.Name = "clID_ChiTietTonDauKy";
            // 
            // clSoLuong
            // 
            this.clSoLuong.Caption = "Số lượng";
            this.clSoLuong.FieldName = "SoLuong";
            this.clSoLuong.Name = "clSoLuong";
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
            this.clDonGia.Visible = true;
            this.clDonGia.VisibleIndex = 5;
            this.clDonGia.Width = 160;
            // 
            // clTonTai
            // 
            this.clTonTai.Caption = "TonTai";
            this.clTonTai.FieldName = "TonTai";
            this.clTonTai.Name = "clTonTai";
            // 
            // clNgungTheoDoi
            // 
            this.clNgungTheoDoi.Caption = "NgungTheoDoi";
            this.clNgungTheoDoi.FieldName = "NgungTheoDoi";
            this.clNgungTheoDoi.Name = "clNgungTheoDoi";
            // 
            // clTenVTHH
            // 
            this.clTenVTHH.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVTHH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVTHH.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenVTHH.Caption = "Tên hàng hóa";
            this.clTenVTHH.FieldName = "TenVTHH";
            this.clTenVTHH.Name = "clTenVTHH";
            this.clTenVTHH.OptionsColumn.AllowEdit = false;
            this.clTenVTHH.OptionsColumn.ReadOnly = true;
            this.clTenVTHH.Visible = true;
            this.clTenVTHH.VisibleIndex = 2;
            this.clTenVTHH.Width = 261;
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
            // clHienThi
            // 
            this.clHienThi.Caption = "HienThi";
            this.clHienThi.FieldName = "HienThi";
            this.clHienThi.Name = "clHienThi";
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
            this.clThanhTien.Width = 160;
            // 
            // clXoa
            // 
            this.clXoa.Caption = "Xóa";
            this.clXoa.ColumnEdit = this.btXoa2;
            this.clXoa.Name = "clXoa";
            this.clXoa.OptionsColumn.FixedWidth = true;
            this.clXoa.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clXoa.Visible = true;
            this.clXoa.VisibleIndex = 7;
            this.clXoa.Width = 40;
            // 
            // btXoa2
            // 
            this.btXoa2.AutoHeight = false;
            this.btXoa2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Delete, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btXoa2.Name = "btXoa2";
            this.btXoa2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btXoa2.Click += new System.EventHandler(this.btXoa2_Click);
            // 
            // clMaVT
            // 
            this.clMaVT.Caption = "Mã VT";
            this.clMaVT.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 1;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            this.repositoryItemGridLookUpEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemGridLookUpEdit1_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clID_VTHH2,
            this.clMaVT2,
            this.clTenVTHH2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // clID_VTHH2
            // 
            this.clID_VTHH2.Caption = "ID_VTHH";
            this.clID_VTHH2.FieldName = "ID_VTHH";
            this.clID_VTHH2.Name = "clID_VTHH2";
            this.clID_VTHH2.Width = 88;
            // 
            // clMaVT2
            // 
            this.clMaVT2.Caption = "Mã";
            this.clMaVT2.FieldName = "MaVT";
            this.clMaVT2.Name = "clMaVT2";
            this.clMaVT2.Visible = true;
            this.clMaVT2.VisibleIndex = 0;
            this.clMaVT2.Width = 90;
            // 
            // clTenVTHH2
            // 
            this.clTenVTHH2.Caption = "Tên VT";
            this.clTenVTHH2.FieldName = "TenVTHH";
            this.clTenVTHH2.Name = "clTenVTHH2";
            this.clTenVTHH2.Visible = true;
            this.clTenVTHH2.VisibleIndex = 1;
            this.clTenVTHH2.Width = 206;
            // 
            // clID_VTHH
            // 
            this.clID_VTHH.Caption = "ID_VTHH";
            this.clID_VTHH.FieldName = "ID_VTHH";
            this.clID_VTHH.Name = "clID_VTHH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Lưu ý chỉ một lần duy nhất ấn gửi dữ liệu";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Image = global::CtyTinLuong.Properties.Resources.ico_Forward;
            this.simpleButton1.Location = new System.Drawing.Point(538, 581);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 22);
            this.simpleButton1.TabIndex = 97;
            this.simpleButton1.Text = "Lưu và gửi";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.simpleButton2.Location = new System.Drawing.Point(633, 581);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(94, 22);
            this.simpleButton2.TabIndex = 96;
            this.simpleButton2.Text = "Chỉ lưu";
            // 
            // KhoNPL_CaiDatBanDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.gridControl1);
            this.Name = "KhoNPL_CaiDatBanDau";
            this.Size = new System.Drawing.Size(727, 606);
            this.Load += new System.EventHandler(this.KhoNPL_CaiDatBanDau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_ChiTietTonDauKy;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn clDonGia;
        private DevExpress.XtraGrid.Columns.GridColumn clTonTai;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn clHienThi;
        private DevExpress.XtraGrid.Columns.GridColumn clThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa2;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH2;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT2;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH2;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
