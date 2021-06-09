namespace CtyTinLuong
{
    partial class UCBangLuong
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_ChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCapXangXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCapDienthoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCapVeSinhMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuCapTienAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrachNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TruTienAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaoHiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTienDaTraLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clThucNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGuiDuLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btThemMoi
            // 
            this.btThemMoi.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Add;
            this.btThemMoi.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btThemMoi.Location = new System.Drawing.Point(1158, 3);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(25, 22);
            this.btThemMoi.StyleController = this.layoutControl1;
            this.btThemMoi.TabIndex = 96;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(1130, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(24, 22);
            this.btRefresh.StyleController = this.layoutControl1;
            this.btRefresh.TabIndex = 95;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.repositoryItemDateEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1180, 559);
            this.gridControl1.TabIndex = 97;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_ChamCong,
            this.Thang,
            this.Nam,
            this.TongLuong,
            this.PhuCapXangXe,
            this.PhuCapDienthoai,
            this.PhuCapVeSinhMay,
            this.PhuCapTienAn,
            this.TrachNhiem,
            this.TruTienAn,
            this.TamUng,
            this.BaoHiem,
            this.SoTienDaTraLuong,
            this.clThucNhan,
            this.clGuiDuLieu,
            this.clGhiChu,
            this.clNgungTheoDoi,
            this.clXoa});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 169;
            // 
            // clID_ChamCong
            // 
            this.clID_ChamCong.Caption = "ID_ChamCong";
            this.clID_ChamCong.FieldName = "ID_ChamCong";
            this.clID_ChamCong.Name = "clID_ChamCong";
            // 
            // Thang
            // 
            this.Thang.AppearanceCell.Options.UseTextOptions = true;
            this.Thang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Thang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Thang.Caption = "Tháng";
            this.Thang.FieldName = "Thang";
            this.Thang.Name = "Thang";
            this.Thang.OptionsColumn.AllowEdit = false;
            this.Thang.OptionsColumn.FixedWidth = true;
            this.Thang.Visible = true;
            this.Thang.VisibleIndex = 1;
            this.Thang.Width = 551;
            // 
            // Nam
            // 
            this.Nam.AppearanceCell.Options.UseTextOptions = true;
            this.Nam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Nam.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Nam.Caption = "Năm";
            this.Nam.FieldName = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.OptionsColumn.AllowEdit = false;
            this.Nam.Visible = true;
            this.Nam.VisibleIndex = 2;
            this.Nam.Width = 489;
            // 
            // TongLuong
            // 
            this.TongLuong.AppearanceCell.Options.UseTextOptions = true;
            this.TongLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TongLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TongLuong.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TongLuong.Caption = "Tổng lương";
            this.TongLuong.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.TongLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TongLuong.FieldName = "LuongLonNhat";
            this.TongLuong.GroupFormat.FormatString = "{0:#,##0.00}";
            this.TongLuong.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TongLuong.Name = "TongLuong";
            this.TongLuong.OptionsColumn.AllowEdit = false;
            this.TongLuong.OptionsColumn.FixedWidth = true;
            this.TongLuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LuongLonNhat", "{0:#,##0.00}")});
            this.TongLuong.Width = 100;
            // 
            // PhuCapXangXe
            // 
            this.PhuCapXangXe.AppearanceCell.Options.UseTextOptions = true;
            this.PhuCapXangXe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PhuCapXangXe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PhuCapXangXe.Caption = "Xăng";
            this.PhuCapXangXe.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapXangXe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapXangXe.FieldName = "PhuCapXangXe";
            this.PhuCapXangXe.GroupFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapXangXe.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapXangXe.Name = "PhuCapXangXe";
            this.PhuCapXangXe.OptionsColumn.AllowEdit = false;
            this.PhuCapXangXe.OptionsColumn.FixedWidth = true;
            this.PhuCapXangXe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhuCapXangXe", "{0:#,##0.00}")});
            this.PhuCapXangXe.Width = 90;
            // 
            // PhuCapDienthoai
            // 
            this.PhuCapDienthoai.AppearanceCell.Options.UseTextOptions = true;
            this.PhuCapDienthoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PhuCapDienthoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PhuCapDienthoai.Caption = "Điện thoại";
            this.PhuCapDienthoai.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapDienthoai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapDienthoai.FieldName = "PhuCapDienthoai";
            this.PhuCapDienthoai.GroupFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapDienthoai.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapDienthoai.Name = "PhuCapDienthoai";
            this.PhuCapDienthoai.OptionsColumn.AllowEdit = false;
            this.PhuCapDienthoai.OptionsColumn.FixedWidth = true;
            this.PhuCapDienthoai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhuCapDienthoai", "{0:#,##0.00}")});
            this.PhuCapDienthoai.Width = 90;
            // 
            // PhuCapVeSinhMay
            // 
            this.PhuCapVeSinhMay.AppearanceCell.Options.UseTextOptions = true;
            this.PhuCapVeSinhMay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PhuCapVeSinhMay.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PhuCapVeSinhMay.Caption = "Vệ sinh";
            this.PhuCapVeSinhMay.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapVeSinhMay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapVeSinhMay.FieldName = "PhuCapVeSinhMay";
            this.PhuCapVeSinhMay.GroupFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapVeSinhMay.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapVeSinhMay.Name = "PhuCapVeSinhMay";
            this.PhuCapVeSinhMay.OptionsColumn.AllowEdit = false;
            this.PhuCapVeSinhMay.OptionsColumn.FixedWidth = true;
            this.PhuCapVeSinhMay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhuCapVeSinhMay", "{0:#,##0.00}")});
            this.PhuCapVeSinhMay.Width = 90;
            // 
            // PhuCapTienAn
            // 
            this.PhuCapTienAn.AppearanceCell.Options.UseTextOptions = true;
            this.PhuCapTienAn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PhuCapTienAn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PhuCapTienAn.Caption = "PC Ăn";
            this.PhuCapTienAn.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapTienAn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapTienAn.FieldName = "PhuCapTienAn";
            this.PhuCapTienAn.GroupFormat.FormatString = "{0:#,##0.00}";
            this.PhuCapTienAn.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PhuCapTienAn.Name = "PhuCapTienAn";
            this.PhuCapTienAn.OptionsColumn.AllowEdit = false;
            this.PhuCapTienAn.OptionsColumn.FixedWidth = true;
            this.PhuCapTienAn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhuCapTienAn", "{0:#,##0.00}")});
            this.PhuCapTienAn.Width = 90;
            // 
            // TrachNhiem
            // 
            this.TrachNhiem.AppearanceCell.Options.UseTextOptions = true;
            this.TrachNhiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TrachNhiem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TrachNhiem.Caption = "Trách nhiệm";
            this.TrachNhiem.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.TrachNhiem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TrachNhiem.FieldName = "TrachNhiem";
            this.TrachNhiem.GroupFormat.FormatString = "{0:#,##0.00}";
            this.TrachNhiem.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TrachNhiem.Name = "TrachNhiem";
            this.TrachNhiem.OptionsColumn.AllowEdit = false;
            this.TrachNhiem.OptionsColumn.FixedWidth = true;
            this.TrachNhiem.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TrachNhiem", "{0:#,##0.00}")});
            this.TrachNhiem.Width = 90;
            // 
            // TruTienAn
            // 
            this.TruTienAn.AppearanceCell.Options.UseTextOptions = true;
            this.TruTienAn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TruTienAn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TruTienAn.Caption = "Trừ ăn";
            this.TruTienAn.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.TruTienAn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TruTienAn.FieldName = "TruTienAn";
            this.TruTienAn.GroupFormat.FormatString = "{0:#,##0.00}";
            this.TruTienAn.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TruTienAn.Name = "TruTienAn";
            this.TruTienAn.OptionsColumn.AllowEdit = false;
            this.TruTienAn.OptionsColumn.FixedWidth = true;
            this.TruTienAn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TruTienAn", "{0:#,##0.00}")});
            this.TruTienAn.Width = 90;
            // 
            // TamUng
            // 
            this.TamUng.AppearanceCell.Options.UseTextOptions = true;
            this.TamUng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TamUng.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TamUng.Caption = "Tạm ứng";
            this.TamUng.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.TamUng.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TamUng.FieldName = "TamUng";
            this.TamUng.GroupFormat.FormatString = "{0:#,##0.00}";
            this.TamUng.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TamUng.Name = "TamUng";
            this.TamUng.OptionsColumn.AllowEdit = false;
            this.TamUng.OptionsColumn.FixedWidth = true;
            this.TamUng.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TamUng", "{0:#,##0.00}")});
            this.TamUng.Width = 90;
            // 
            // BaoHiem
            // 
            this.BaoHiem.AppearanceCell.Options.UseTextOptions = true;
            this.BaoHiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.BaoHiem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.BaoHiem.Caption = "Bảo hiểm";
            this.BaoHiem.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.BaoHiem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.BaoHiem.FieldName = "BaoHiem";
            this.BaoHiem.GroupFormat.FormatString = "{0:#,##0.00}";
            this.BaoHiem.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.BaoHiem.Name = "BaoHiem";
            this.BaoHiem.OptionsColumn.AllowEdit = false;
            this.BaoHiem.OptionsColumn.FixedWidth = true;
            this.BaoHiem.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BaoHiem", "{0:#,##0.00}")});
            this.BaoHiem.Width = 90;
            // 
            // SoTienDaTraLuong
            // 
            this.SoTienDaTraLuong.AppearanceCell.Options.UseTextOptions = true;
            this.SoTienDaTraLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SoTienDaTraLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SoTienDaTraLuong.Caption = "Đã trả";
            this.SoTienDaTraLuong.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.SoTienDaTraLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SoTienDaTraLuong.FieldName = "SoTienDaTraLuong";
            this.SoTienDaTraLuong.GroupFormat.FormatString = "{0:#,##0.00}";
            this.SoTienDaTraLuong.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SoTienDaTraLuong.Name = "SoTienDaTraLuong";
            this.SoTienDaTraLuong.OptionsColumn.AllowEdit = false;
            this.SoTienDaTraLuong.OptionsColumn.FixedWidth = true;
            this.SoTienDaTraLuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTienDaTraLuong", "{0:#,##0.00}")});
            this.SoTienDaTraLuong.Width = 100;
            // 
            // clThucNhan
            // 
            this.clThucNhan.AppearanceCell.Options.UseTextOptions = true;
            this.clThucNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clThucNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clThucNhan.Caption = "Thực nhận";
            this.clThucNhan.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clThucNhan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThucNhan.FieldName = "ThucNhan";
            this.clThucNhan.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clThucNhan.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clThucNhan.Name = "clThucNhan";
            this.clThucNhan.OptionsColumn.AllowEdit = false;
            this.clThucNhan.OptionsColumn.FixedWidth = true;
            this.clThucNhan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThucNhan", "{0:#,##0.00}")});
            this.clThucNhan.Width = 100;
            // 
            // clGuiDuLieu
            // 
            this.clGuiDuLieu.Caption = "Gửi";
            this.clGuiDuLieu.ColumnEdit = this.repositoryItemCheckEdit2;
            this.clGuiDuLieu.FieldName = "GuiDuLieu";
            this.clGuiDuLieu.Name = "clGuiDuLieu";
            this.clGuiDuLieu.OptionsColumn.AllowEdit = false;
            this.clGuiDuLieu.OptionsColumn.FixedWidth = true;
            this.clGuiDuLieu.Width = 30;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // clGhiChu
            // 
            this.clGhiChu.Caption = "Ghi chú";
            this.clGhiChu.FieldName = "GhiChu";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.OptionsColumn.FixedWidth = true;
            this.clGhiChu.Width = 20;
            // 
            // clNgungTheoDoi
            // 
            this.clNgungTheoDoi.AppearanceCell.Options.UseTextOptions = true;
            this.clNgungTheoDoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgungTheoDoi.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgungTheoDoi.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clNgungTheoDoi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNgungTheoDoi.AppearanceHeader.Options.UseFont = true;
            this.clNgungTheoDoi.AppearanceHeader.Options.UseTextOptions = true;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clNgungTheoDoi.Caption = "Bỏ";
            this.clNgungTheoDoi.ColumnEdit = this.repositoryItemCheckEdit1;
            this.clNgungTheoDoi.FieldName = "NgungTheoDoi";
            this.clNgungTheoDoi.Name = "clNgungTheoDoi";
            this.clNgungTheoDoi.OptionsColumn.FixedWidth = true;
            this.clNgungTheoDoi.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clNgungTheoDoi.Width = 60;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // clXoa
            // 
            this.clXoa.Caption = "Xóa";
            this.clXoa.ColumnEdit = this.btXoa;
            this.clXoa.Name = "clXoa";
            this.clXoa.OptionsColumn.FixedWidth = true;
            this.clXoa.Width = 30;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            editorButtonImageOptions4.Image = global::CtyTinLuong.Properties.Resources.ico_Delete;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(1188, 606);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btRefresh);
            this.layoutControl1.Controls.Add(this.btThemMoi);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(1, 14);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1186, 591);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1186, 591);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1184, 563);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btThemMoi;
            this.layoutControlItem2.Location = new System.Drawing.Point(1155, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(29, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btRefresh;
            this.layoutControlItem3.Location = new System.Drawing.Point(1127, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(28, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1106, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UCBangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCBangLuong";
            this.Size = new System.Drawing.Size(1188, 606);
            this.Load += new System.EventHandler(this.UCBangLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_ChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn Thang;
        private DevExpress.XtraGrid.Columns.GridColumn Nam;
        private DevExpress.XtraGrid.Columns.GridColumn TongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn TamUng;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn BaoHiem;
        private DevExpress.XtraGrid.Columns.GridColumn clThucNhan;
        private DevExpress.XtraGrid.Columns.GridColumn clGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn clGuiDuLieu;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn PhuCapXangXe;
        private DevExpress.XtraGrid.Columns.GridColumn PhuCapDienthoai;
        private DevExpress.XtraGrid.Columns.GridColumn PhuCapVeSinhMay;
        private DevExpress.XtraGrid.Columns.GridColumn PhuCapTienAn;
        private DevExpress.XtraGrid.Columns.GridColumn TrachNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn TruTienAn;
        private DevExpress.XtraGrid.Columns.GridColumn SoTienDaTraLuong;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
