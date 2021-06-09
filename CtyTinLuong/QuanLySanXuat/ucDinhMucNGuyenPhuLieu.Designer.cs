namespace CtyTinLuong
{
    partial class ucDinhMucNGuyenPhuLieu
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.checkTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.checkNgungTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.checked_ALL = new DevExpress.XtraEditors.CheckEdit();
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaDinhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clID_DinhMuc_NPL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH_ThanhPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH_Chinh1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH_Chinh2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVTHH2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViTinh2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBooL_NguyenPhuLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuong2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(50, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(39, 23);
            this.btRefresh.TabIndex = 81;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // checkTheoDoi
            // 
            this.checkTheoDoi.Location = new System.Drawing.Point(525, 3);
            this.checkTheoDoi.Name = "checkTheoDoi";
            this.checkTheoDoi.Properties.Caption = "Đang theo dõi";
            this.checkTheoDoi.Size = new System.Drawing.Size(90, 19);
            this.checkTheoDoi.TabIndex = 77;
            this.checkTheoDoi.CheckedChanged += new System.EventHandler(this.checkTheoDoi_CheckedChanged);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(621, 3);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.Properties.Caption = "Ngừng theo dõi";
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(100, 19);
            this.checkNgungTheoDoi.TabIndex = 78;
            this.checkNgungTheoDoi.CheckedChanged += new System.EventHandler(this.checkNgungTheoDoi_CheckedChanged);
            // 
            // checked_ALL
            // 
            this.checked_ALL.Location = new System.Drawing.Point(463, 3);
            this.checked_ALL.Name = "checked_ALL";
            this.checked_ALL.Properties.Caption = "Tất cả";
            this.checked_ALL.Size = new System.Drawing.Size(56, 19);
            this.checked_ALL.TabIndex = 79;
            this.checked_ALL.CheckedChanged += new System.EventHandler(this.checked_ALL_CheckedChanged);
            // 
            // btThemMoi
            // 
            this.btThemMoi.Image = global::CtyTinLuong.Properties.Resources.ico_Add;
            this.btThemMoi.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btThemMoi.Location = new System.Drawing.Point(5, 3);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(39, 23);
            this.btThemMoi.TabIndex = 80;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa});
            this.gridControl1.Size = new System.Drawing.Size(716, 323);
            this.gridControl1.TabIndex = 82;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clMaDinhMuc,
            this.clDienGiai,
            this.clXoa,
            this.clID_DinhMuc_NPL,
            this.clNgungTheoDoi,
            this.clNgayLap,
            this.clID_VTHH_ThanhPham,
            this.clID_VTHH_Chinh1,
            this.clID_VTHH_Chinh2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // clSTT
            // 
            this.clSTT.AppearanceCell.Options.UseTextOptions = true;
            this.clSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.clSTT.Width = 30;
            // 
            // clMaDinhMuc
            // 
            this.clMaDinhMuc.AppearanceCell.Options.UseTextOptions = true;
            this.clMaDinhMuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clMaDinhMuc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaDinhMuc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clMaDinhMuc.AppearanceHeader.Options.UseFont = true;
            this.clMaDinhMuc.AppearanceHeader.Options.UseTextOptions = true;
            this.clMaDinhMuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clMaDinhMuc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaDinhMuc.Caption = "Mã ĐM";
            this.clMaDinhMuc.FieldName = "MaDinhMuc";
            this.clMaDinhMuc.Name = "clMaDinhMuc";
            this.clMaDinhMuc.OptionsColumn.AllowEdit = false;
            this.clMaDinhMuc.OptionsColumn.FixedWidth = true;
            this.clMaDinhMuc.Visible = true;
            this.clMaDinhMuc.VisibleIndex = 1;
            this.clMaDinhMuc.Width = 80;
            // 
            // clDienGiai
            // 
            this.clDienGiai.AppearanceCell.Options.UseTextOptions = true;
            this.clDienGiai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clDienGiai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDienGiai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDienGiai.AppearanceHeader.Options.UseFont = true;
            this.clDienGiai.AppearanceHeader.Options.UseTextOptions = true;
            this.clDienGiai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clDienGiai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDienGiai.Caption = "Diễn giải";
            this.clDienGiai.FieldName = "DienGiai";
            this.clDienGiai.Name = "clDienGiai";
            this.clDienGiai.OptionsColumn.AllowEdit = false;
            this.clDienGiai.OptionsColumn.FixedWidth = true;
            this.clDienGiai.Visible = true;
            this.clDienGiai.VisibleIndex = 2;
            this.clDienGiai.Width = 339;
            // 
            // clXoa
            // 
            this.clXoa.AppearanceCell.Options.UseTextOptions = true;
            this.clXoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clXoa.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clXoa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clXoa.AppearanceHeader.Options.UseFont = true;
            this.clXoa.AppearanceHeader.Options.UseTextOptions = true;
            this.clXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clXoa.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clXoa.Caption = "Xóa";
            this.clXoa.ColumnEdit = this.btXoa;
            this.clXoa.Name = "clXoa";
            this.clXoa.OptionsColumn.FixedWidth = true;
            this.clXoa.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clXoa.Visible = true;
            this.clXoa.VisibleIndex = 4;
            this.clXoa.Width = 35;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // clID_DinhMuc_NPL
            // 
            this.clID_DinhMuc_NPL.Caption = "ID_DinhMuc_NPL";
            this.clID_DinhMuc_NPL.FieldName = "ID_DinhMuc_NPL";
            this.clID_DinhMuc_NPL.Name = "clID_DinhMuc_NPL";
            // 
            // clNgungTheoDoi
            // 
            this.clNgungTheoDoi.AppearanceCell.Options.UseTextOptions = true;
            this.clNgungTheoDoi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgungTheoDoi.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNgungTheoDoi.AppearanceHeader.Options.UseFont = true;
            this.clNgungTheoDoi.AppearanceHeader.Options.UseTextOptions = true;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgungTheoDoi.Caption = "Ngừng";
            this.clNgungTheoDoi.FieldName = "NgungTheoDoi";
            this.clNgungTheoDoi.Name = "clNgungTheoDoi";
            this.clNgungTheoDoi.OptionsColumn.FixedWidth = true;
            this.clNgungTheoDoi.Visible = true;
            this.clNgungTheoDoi.VisibleIndex = 3;
            this.clNgungTheoDoi.Width = 40;
            // 
            // clNgayLap
            // 
            this.clNgayLap.AppearanceCell.Options.UseTextOptions = true;
            this.clNgayLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgayLap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgayLap.Caption = "Ngày lập";
            this.clNgayLap.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clNgayLap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayLap.FieldName = "NgayLap";
            this.clNgayLap.GroupFormat.FormatString = "dd/MM/yyyy";
            this.clNgayLap.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayLap.Name = "clNgayLap";
            this.clNgayLap.OptionsColumn.AllowEdit = false;
            this.clNgayLap.OptionsColumn.FixedWidth = true;
            this.clNgayLap.Width = 120;
            // 
            // clID_VTHH_ThanhPham
            // 
            this.clID_VTHH_ThanhPham.Caption = "ID_VTHH_ThanhPham";
            this.clID_VTHH_ThanhPham.FieldName = "ID_VTHH_ThanhPham";
            this.clID_VTHH_ThanhPham.Name = "clID_VTHH_ThanhPham";
            // 
            // clID_VTHH_Chinh1
            // 
            this.clID_VTHH_Chinh1.Caption = "ID_VTHH_Chinh1";
            this.clID_VTHH_Chinh1.FieldName = "ID_VTHH_Chinh1";
            this.clID_VTHH_Chinh1.Name = "clID_VTHH_Chinh1";
            // 
            // clID_VTHH_Chinh2
            // 
            this.clID_VTHH_Chinh2.Caption = "ID_VTHH_Chinh2";
            this.clID_VTHH_Chinh2.FieldName = "ID_VTHH_Chinh2";
            this.clID_VTHH_Chinh2.Name = "clID_VTHH_Chinh2";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(5, 361);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl2.Size = new System.Drawing.Size(716, 242);
            this.gridControl2.TabIndex = 83;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT2,
            this.clMaVT,
            this.clTenVTHH2,
            this.clDonViTinh2,
            this.clBooL_NguyenPhuLieu,
            this.clSoLuong2});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.NewItemRowText = "Thêm mới tại đây";
            this.gridView2.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView2_CustomDrawCell);
            // 
            // clSTT2
            // 
            this.clSTT2.AppearanceCell.Options.UseTextOptions = true;
            this.clSTT2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSTT2.AppearanceHeader.Options.UseFont = true;
            this.clSTT2.AppearanceHeader.Options.UseTextOptions = true;
            this.clSTT2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT2.Caption = "STT";
            this.clSTT2.Name = "clSTT2";
            this.clSTT2.OptionsColumn.AllowEdit = false;
            this.clSTT2.OptionsColumn.FixedWidth = true;
            this.clSTT2.Visible = true;
            this.clSTT2.VisibleIndex = 0;
            this.clSTT2.Width = 50;
            // 
            // clMaVT
            // 
            this.clMaVT.AppearanceCell.Options.UseTextOptions = true;
            this.clMaVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clMaVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clMaVT.AppearanceHeader.Options.UseFont = true;
            this.clMaVT.AppearanceHeader.Options.UseTextOptions = true;
            this.clMaVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clMaVT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaVT.Caption = "Mã VT";
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.OptionsColumn.AllowEdit = false;
            this.clMaVT.OptionsColumn.FixedWidth = true;
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 1;
            this.clMaVT.Width = 100;
            // 
            // clTenVTHH2
            // 
            this.clTenVTHH2.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVTHH2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVTHH2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenVTHH2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clTenVTHH2.AppearanceHeader.Options.UseFont = true;
            this.clTenVTHH2.AppearanceHeader.Options.UseTextOptions = true;
            this.clTenVTHH2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clTenVTHH2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenVTHH2.Caption = "Tên VT";
            this.clTenVTHH2.FieldName = "TenVTHH";
            this.clTenVTHH2.Name = "clTenVTHH2";
            this.clTenVTHH2.OptionsColumn.AllowEdit = false;
            this.clTenVTHH2.Visible = true;
            this.clTenVTHH2.VisibleIndex = 2;
            this.clTenVTHH2.Width = 532;
            // 
            // clDonViTinh2
            // 
            this.clDonViTinh2.AppearanceCell.Options.UseTextOptions = true;
            this.clDonViTinh2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clDonViTinh2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDonViTinh2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDonViTinh2.AppearanceHeader.Options.UseFont = true;
            this.clDonViTinh2.AppearanceHeader.Options.UseTextOptions = true;
            this.clDonViTinh2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clDonViTinh2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDonViTinh2.Caption = "ĐVT";
            this.clDonViTinh2.FieldName = "DonViTinh";
            this.clDonViTinh2.Name = "clDonViTinh2";
            this.clDonViTinh2.OptionsColumn.AllowEdit = false;
            this.clDonViTinh2.OptionsColumn.FixedWidth = true;
            this.clDonViTinh2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clDonViTinh2.Visible = true;
            this.clDonViTinh2.VisibleIndex = 4;
            this.clDonViTinh2.Width = 100;
            // 
            // clBooL_NguyenPhuLieu
            // 
            this.clBooL_NguyenPhuLieu.Caption = "BoL";
            this.clBooL_NguyenPhuLieu.FieldName = "BooL_NguyenPhuLieu";
            this.clBooL_NguyenPhuLieu.Name = "clBooL_NguyenPhuLieu";
            this.clBooL_NguyenPhuLieu.OptionsColumn.AllowEdit = false;
            this.clBooL_NguyenPhuLieu.OptionsColumn.FixedWidth = true;
            this.clBooL_NguyenPhuLieu.Visible = true;
            this.clBooL_NguyenPhuLieu.VisibleIndex = 5;
            this.clBooL_NguyenPhuLieu.Width = 80;
            // 
            // clSoLuong2
            // 
            this.clSoLuong2.AppearanceCell.Options.UseTextOptions = true;
            this.clSoLuong2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoLuong2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSoLuong2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoLuong2.AppearanceHeader.Options.UseFont = true;
            this.clSoLuong2.AppearanceHeader.Options.UseTextOptions = true;
            this.clSoLuong2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoLuong2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSoLuong2.Caption = "Số lượng";
            this.clSoLuong2.FieldName = "SoLuong";
            this.clSoLuong2.Name = "clSoLuong2";
            this.clSoLuong2.OptionsColumn.AllowEdit = false;
            this.clSoLuong2.OptionsColumn.FixedWidth = true;
            this.clSoLuong2.Visible = true;
            this.clSoLuong2.VisibleIndex = 3;
            this.clSoLuong2.Width = 100;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // ucDinhMucNGuyenPhuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.checkTheoDoi);
            this.Controls.Add(this.checkNgungTheoDoi);
            this.Controls.Add(this.checked_ALL);
            this.Controls.Add(this.btThemMoi);
            this.Name = "ucDinhMucNGuyenPhuLieu";
            this.Size = new System.Drawing.Size(727, 606);
            this.Load += new System.EventHandler(this.ucDinhMucNGuyenPhuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraEditors.CheckEdit checkTheoDoi;
        private DevExpress.XtraEditors.CheckEdit checkNgungTheoDoi;
        private DevExpress.XtraEditors.CheckEdit checked_ALL;
        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clMaDinhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn clDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DinhMuc_NPL;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clNgayLap;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT2;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVTHH2;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh2;
        private DevExpress.XtraGrid.Columns.GridColumn clBooL_NguyenPhuLieu;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuong2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH_ThanhPham;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH_Chinh1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH_Chinh2;
    }
}
