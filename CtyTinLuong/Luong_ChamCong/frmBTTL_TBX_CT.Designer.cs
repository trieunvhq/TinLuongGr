namespace CtyTinLuong
{
    partial class frmBTTL_TBX_CT
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenLoaiCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SanLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongTrachNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThucNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KyNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnPrintTQ = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions3.Image = global::CtyTinLuong.Properties.Resources.ico_Delete;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Tháng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "Năm:";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clTenNhanVien,
            this.TenLoaiCong,
            this.DonGia,
            this.SanLuong,
            this.TongLuong,
            this.LuongTrachNhiem,
            this.TongTien,
            this.TamUng,
            this.ThucNhan,
            this.KyNhan});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1106, 496, 260, 232);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // clSTT
            // 
            this.clSTT.AppearanceCell.Options.UseTextOptions = true;
            this.clSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSTT.AppearanceHeader.Options.UseFont = true;
            this.clSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.clSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT.Caption = "STT";
            this.clSTT.FieldName = "STT";
            this.clSTT.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 30;
            // 
            // clTenNhanVien
            // 
            this.clTenNhanVien.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clTenNhanVien.AppearanceCell.Options.UseFont = true;
            this.clTenNhanVien.Caption = "HỌ TÊN";
            this.clTenNhanVien.ColumnEdit = this.repositoryItemMemoEdit3;
            this.clTenNhanVien.FieldName = "TenNhanVien";
            this.clTenNhanVien.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clTenNhanVien.Name = "clTenNhanVien";
            this.clTenNhanVien.OptionsColumn.AllowEdit = false;
            this.clTenNhanVien.Visible = true;
            this.clTenNhanVien.VisibleIndex = 1;
            this.clTenNhanVien.Width = 130;
            // 
            // TenLoaiCong
            // 
            this.TenLoaiCong.AppearanceCell.Options.UseTextOptions = true;
            this.TenLoaiCong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TenLoaiCong.Caption = "CÔNG";
            this.TenLoaiCong.FieldName = "TenLoaiCong";
            this.TenLoaiCong.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.TenLoaiCong.Name = "TenLoaiCong";
            this.TenLoaiCong.OptionsColumn.AllowEdit = false;
            this.TenLoaiCong.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TenLoaiCong.Visible = true;
            this.TenLoaiCong.VisibleIndex = 2;
            this.TenLoaiCong.Width = 91;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DonGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DonGia.Caption = "LƯƠNG CƠ BẢN";
            this.DonGia.FieldName = "DonGia";
            this.DonGia.MinWidth = 10;
            this.DonGia.Name = "DonGia";
            this.DonGia.OptionsColumn.AllowEdit = false;
            this.DonGia.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsColumn.FixedWidth = true;
            this.DonGia.OptionsFilter.AllowAutoFilter = false;
            this.DonGia.OptionsFilter.AllowFilter = false;
            this.DonGia.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ShowEmptyDateFilter = false;
            this.DonGia.Visible = true;
            this.DonGia.VisibleIndex = 3;
            this.DonGia.Width = 91;
            // 
            // SanLuong
            // 
            this.SanLuong.AppearanceCell.Options.UseTextOptions = true;
            this.SanLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SanLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SanLuong.Caption = "NGÀY CÔNG";
            this.SanLuong.FieldName = "SanLuong";
            this.SanLuong.MinWidth = 10;
            this.SanLuong.Name = "SanLuong";
            this.SanLuong.OptionsColumn.AllowEdit = false;
            this.SanLuong.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsColumn.FixedWidth = true;
            this.SanLuong.OptionsFilter.AllowAutoFilter = false;
            this.SanLuong.OptionsFilter.AllowFilter = false;
            this.SanLuong.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.SanLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.SanLuong.OptionsFilter.ShowEmptyDateFilter = false;
            this.SanLuong.Visible = true;
            this.SanLuong.VisibleIndex = 4;
            this.SanLuong.Width = 91;
            // 
            // TongLuong
            // 
            this.TongLuong.AppearanceCell.Options.UseTextOptions = true;
            this.TongLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TongLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TongLuong.Caption = "TỔNG LƯƠNG";
            this.TongLuong.FieldName = "TongLuong";
            this.TongLuong.MinWidth = 10;
            this.TongLuong.Name = "TongLuong";
            this.TongLuong.OptionsColumn.AllowEdit = false;
            this.TongLuong.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsColumn.FixedWidth = true;
            this.TongLuong.OptionsFilter.AllowAutoFilter = false;
            this.TongLuong.OptionsFilter.AllowFilter = false;
            this.TongLuong.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.TongLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.TongLuong.OptionsFilter.ShowEmptyDateFilter = false;
            this.TongLuong.Visible = true;
            this.TongLuong.VisibleIndex = 5;
            this.TongLuong.Width = 91;
            // 
            // LuongTrachNhiem
            // 
            this.LuongTrachNhiem.AppearanceCell.Options.UseTextOptions = true;
            this.LuongTrachNhiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.LuongTrachNhiem.Caption = "L.TRÁCH NHIỆM";
            this.LuongTrachNhiem.FieldName = "LuongTrachNhiem";
            this.LuongTrachNhiem.Name = "LuongTrachNhiem";
            this.LuongTrachNhiem.OptionsColumn.AllowEdit = false;
            this.LuongTrachNhiem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.LuongTrachNhiem.Visible = true;
            this.LuongTrachNhiem.VisibleIndex = 6;
            this.LuongTrachNhiem.Width = 91;
            // 
            // TongTien
            // 
            this.TongTien.AppearanceCell.Options.UseTextOptions = true;
            this.TongTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TongTien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TongTien.Caption = "TỔNG";
            this.TongTien.FieldName = "TongTien";
            this.TongTien.MinWidth = 10;
            this.TongTien.Name = "TongTien";
            this.TongTien.OptionsColumn.AllowEdit = false;
            this.TongTien.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsColumn.FixedWidth = true;
            this.TongTien.OptionsFilter.AllowAutoFilter = false;
            this.TongTien.OptionsFilter.AllowFilter = false;
            this.TongTien.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.TongTien.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.TongTien.OptionsFilter.ShowEmptyDateFilter = false;
            this.TongTien.Visible = true;
            this.TongTien.VisibleIndex = 7;
            this.TongTien.Width = 91;
            // 
            // TamUng
            // 
            this.TamUng.AppearanceCell.Options.UseTextOptions = true;
            this.TamUng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TamUng.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TamUng.Caption = "TRỪ TẠM ỨNG";
            this.TamUng.FieldName = "TamUng";
            this.TamUng.MinWidth = 10;
            this.TamUng.Name = "TamUng";
            this.TamUng.OptionsColumn.AllowEdit = false;
            this.TamUng.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsColumn.FixedWidth = true;
            this.TamUng.OptionsFilter.AllowAutoFilter = false;
            this.TamUng.OptionsFilter.AllowFilter = false;
            this.TamUng.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.TamUng.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.TamUng.OptionsFilter.ShowEmptyDateFilter = false;
            this.TamUng.Visible = true;
            this.TamUng.VisibleIndex = 8;
            this.TamUng.Width = 91;
            // 
            // ThucNhan
            // 
            this.ThucNhan.AppearanceCell.Options.UseTextOptions = true;
            this.ThucNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ThucNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ThucNhan.Caption = "THỰC NHẬN";
            this.ThucNhan.FieldName = "ThucNhan";
            this.ThucNhan.MinWidth = 10;
            this.ThucNhan.Name = "ThucNhan";
            this.ThucNhan.OptionsColumn.AllowEdit = false;
            this.ThucNhan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsColumn.FixedWidth = true;
            this.ThucNhan.OptionsFilter.AllowAutoFilter = false;
            this.ThucNhan.OptionsFilter.AllowFilter = false;
            this.ThucNhan.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ThucNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ThucNhan.OptionsFilter.ShowEmptyDateFilter = false;
            this.ThucNhan.Tag = "Thuc";
            this.ThucNhan.Visible = true;
            this.ThucNhan.VisibleIndex = 9;
            this.ThucNhan.Width = 91;
            // 
            // KyNhan
            // 
            this.KyNhan.AppearanceCell.Options.UseTextOptions = true;
            this.KyNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KyNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.KyNhan.Caption = "KÝ NHẬN";
            this.KyNhan.FieldName = "KyNhan";
            this.KyNhan.MinWidth = 10;
            this.KyNhan.Name = "KyNhan";
            this.KyNhan.OptionsColumn.AllowEdit = false;
            this.KyNhan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsColumn.FixedWidth = true;
            this.KyNhan.OptionsFilter.AllowAutoFilter = false;
            this.KyNhan.OptionsFilter.AllowFilter = false;
            this.KyNhan.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.NotLike;
            this.KyNhan.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ShowEmptyDateFilter = false;
            this.KyNhan.Width = 80;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 39);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(908, 538);
            this.gridControl1.TabIndex = 115;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btnPrintTQ
            // 
            this.btnPrintTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTQ.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTQ.Appearance.Options.UseFont = true;
            this.btnPrintTQ.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrintTQ.Location = new System.Drawing.Point(741, 592);
            this.btnPrintTQ.Name = "btnPrintTQ";
            this.btnPrintTQ.Size = new System.Drawing.Size(82, 25);
            this.btnPrintTQ.TabIndex = 149;
            this.btnPrintTQ.Text = "Tổng quát";
            this.btnPrintTQ.Click += new System.EventHandler(this.btnPrintTQ_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrint.Location = new System.Drawing.Point(656, 592);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 25);
            this.btnPrint.TabIndex = 148;
            this.btnPrint.Text = "Chi tiết";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(826, 592);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(82, 25);
            this.btThoat.TabIndex = 146;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(519, 12);
            this.txtNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(70, 20);
            this.txtNam.TabIndex = 170;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.txtNam.Leave += new System.EventHandler(this.txtNam_Leave);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(361, 12);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(66, 20);
            this.txtThang.TabIndex = 169;
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Leave += new System.EventHandler(this.txtThang_Leave);
            // 
            // frmBTTL_TBX_CT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.btnPrintTQ);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmBTTL_TBX_CT";
            this.Size = new System.Drawing.Size(913, 635);
            this.Load += new System.EventHandler(this.frmBTTL_TBX_CT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn SanLuong;
        private DevExpress.XtraGrid.Columns.GridColumn TongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn TongTien;
        private DevExpress.XtraGrid.Columns.GridColumn TamUng;
        private DevExpress.XtraGrid.Columns.GridColumn ThucNhan;
        private DevExpress.XtraGrid.Columns.GridColumn KyNhan;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn LuongTrachNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn TenLoaiCong;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.SimpleButton btnPrintTQ;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.NumericUpDown txtNam;
        private System.Windows.Forms.NumericUpDown txtThang;
    }
}