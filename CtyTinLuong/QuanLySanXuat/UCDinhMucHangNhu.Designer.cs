namespace CtyTinLuong
{
    partial class UCDinhMucHangNhu
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkHangSot = new System.Windows.Forms.CheckBox();
            this.checkHangCuc = new System.Windows.Forms.CheckBox();
            this.checkHangNhu = new System.Windows.Forms.CheckBox();
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_DinhMuc_Dot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgayThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clLoaiGiay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuongKiemTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViTinh1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTrongLuongKiemTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoLuongQuyDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDonViQuyDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clQuyRaKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPhePham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDoCao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoKG_MotBao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoKienMotBao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_VTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(837, 4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(24, 22);
            this.btRefresh.StyleController = this.layoutControl1;
            this.btRefresh.TabIndex = 81;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkHangSot);
            this.layoutControl1.Controls.Add(this.checkHangCuc);
            this.layoutControl1.Controls.Add(this.checkHangNhu);
            this.layoutControl1.Controls.Add(this.btThemMoi);
            this.layoutControl1.Controls.Add(this.btRefresh);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(894, 587);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkHangSot
            // 
            this.checkHangSot.Location = new System.Drawing.Point(274, 4);
            this.checkHangSot.Name = "checkHangSot";
            this.checkHangSot.Size = new System.Drawing.Size(350, 20);
            this.checkHangSot.TabIndex = 84;
            this.checkHangSot.Text = "Hàng Sọt";
            this.checkHangSot.UseVisualStyleBackColor = true;
            this.checkHangSot.CheckedChanged += new System.EventHandler(this.checkHangSot_CheckedChanged);
            // 
            // checkHangCuc
            // 
            this.checkHangCuc.Location = new System.Drawing.Point(144, 4);
            this.checkHangCuc.Name = "checkHangCuc";
            this.checkHangCuc.Size = new System.Drawing.Size(126, 20);
            this.checkHangCuc.TabIndex = 83;
            this.checkHangCuc.Text = "Hàng Cục";
            this.checkHangCuc.UseVisualStyleBackColor = true;
            this.checkHangCuc.CheckedChanged += new System.EventHandler(this.checkHangCuc_CheckedChanged);
            // 
            // checkHangNhu
            // 
            this.checkHangNhu.Location = new System.Drawing.Point(4, 4);
            this.checkHangNhu.Name = "checkHangNhu";
            this.checkHangNhu.Size = new System.Drawing.Size(136, 20);
            this.checkHangNhu.TabIndex = 82;
            this.checkHangNhu.Text = "Hàng Nhũ";
            this.checkHangNhu.UseVisualStyleBackColor = true;
            this.checkHangNhu.CheckedChanged += new System.EventHandler(this.checkHangNhu_CheckedChanged);
            // 
            // btThemMoi
            // 
            this.btThemMoi.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Add;
            this.btThemMoi.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btThemMoi.Location = new System.Drawing.Point(865, 4);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(25, 22);
            this.btThemMoi.StyleController = this.layoutControl1;
            this.btThemMoi.TabIndex = 80;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(4, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(886, 553);
            this.gridControl1.TabIndex = 76;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
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
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_DinhMuc_Dot,
            this.clNgayThang,
            this.clCa,
            this.clSoHieu,
            this.clMaVT,
            this.clTenVT,
            this.clLoaiGiay,
            this.clSoLuongKiemTra,
            this.clDonViTinh1,
            this.clTrongLuongKiemTra,
            this.clSoLuongQuyDoi,
            this.clDonViQuyDoi,
            this.clQuyRaKien,
            this.clPhePham,
            this.clDoCao,
            this.clSoKG_MotBao,
            this.clSoKienMotBao,
            this.clNgungTheoDoi,
            this.clXoa,
            this.clGhiChu,
            this.clID_VTHH,
            this.clKhoa});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
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
            this.clSTT.Width = 40;
            // 
            // clID_DinhMuc_Dot
            // 
            this.clID_DinhMuc_Dot.Caption = "ID_DinhMuc_Dot";
            this.clID_DinhMuc_Dot.FieldName = "ID_DinhMuc_Dot";
            this.clID_DinhMuc_Dot.Name = "clID_DinhMuc_Dot";
            // 
            // clNgayThang
            // 
            this.clNgayThang.Caption = "Ngày";
            this.clNgayThang.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clNgayThang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayThang.FieldName = "NgayThang";
            this.clNgayThang.GroupFormat.FormatString = "dd/MM/yyyy";
            this.clNgayThang.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNgayThang.Name = "clNgayThang";
            this.clNgayThang.OptionsColumn.AllowEdit = false;
            this.clNgayThang.Visible = true;
            this.clNgayThang.VisibleIndex = 2;
            this.clNgayThang.Width = 102;
            // 
            // clCa
            // 
            this.clCa.Caption = "Ca";
            this.clCa.FieldName = "Ca";
            this.clCa.Name = "clCa";
            this.clCa.OptionsColumn.AllowEdit = false;
            this.clCa.Width = 113;
            // 
            // clSoHieu
            // 
            this.clSoHieu.Caption = "Số hiệu";
            this.clSoHieu.FieldName = "SoHieu";
            this.clSoHieu.Name = "clSoHieu";
            this.clSoHieu.OptionsColumn.AllowEdit = false;
            this.clSoHieu.Visible = true;
            this.clSoHieu.VisibleIndex = 1;
            this.clSoHieu.Width = 68;
            // 
            // clMaVT
            // 
            this.clMaVT.Caption = "Mã VT";
            this.clMaVT.FieldName = "MaVT";
            this.clMaVT.Name = "clMaVT";
            this.clMaVT.OptionsColumn.AllowEdit = false;
            this.clMaVT.Visible = true;
            this.clMaVT.VisibleIndex = 3;
            this.clMaVT.Width = 79;
            // 
            // clTenVT
            // 
            this.clTenVT.AppearanceCell.Options.UseTextOptions = true;
            this.clTenVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clTenVT.Caption = "Tên VT";
            this.clTenVT.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clTenVT.FieldName = "TenVTHH";
            this.clTenVT.Name = "clTenVT";
            this.clTenVT.OptionsColumn.AllowEdit = false;
            this.clTenVT.Visible = true;
            this.clTenVT.VisibleIndex = 4;
            this.clTenVT.Width = 155;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clLoaiGiay
            // 
            this.clLoaiGiay.Caption = "Loại giấy";
            this.clLoaiGiay.FieldName = "LoaiGiay";
            this.clLoaiGiay.Name = "clLoaiGiay";
            // 
            // clSoLuongKiemTra
            // 
            this.clSoLuongKiemTra.Caption = "SL 1";
            this.clSoLuongKiemTra.FieldName = "SoLuongKiemTra";
            this.clSoLuongKiemTra.Name = "clSoLuongKiemTra";
            this.clSoLuongKiemTra.OptionsColumn.AllowEdit = false;
            // 
            // clDonViTinh1
            // 
            this.clDonViTinh1.Caption = "ĐVT";
            this.clDonViTinh1.FieldName = "DonViTinh1";
            this.clDonViTinh1.Name = "clDonViTinh1";
            // 
            // clTrongLuongKiemTra
            // 
            this.clTrongLuongKiemTra.Caption = "TL";
            this.clTrongLuongKiemTra.FieldName = "TrongLuongKiemTra";
            this.clTrongLuongKiemTra.Name = "clTrongLuongKiemTra";
            this.clTrongLuongKiemTra.OptionsColumn.AllowEdit = false;
            // 
            // clSoLuongQuyDoi
            // 
            this.clSoLuongQuyDoi.Caption = "SL";
            this.clSoLuongQuyDoi.FieldName = "SoLuongQuyDoi";
            this.clSoLuongQuyDoi.Name = "clSoLuongQuyDoi";
            // 
            // clDonViQuyDoi
            // 
            this.clDonViQuyDoi.Caption = "ĐVT";
            this.clDonViQuyDoi.FieldName = "DonViQuyDoi";
            this.clDonViQuyDoi.Name = "clDonViQuyDoi";
            // 
            // clQuyRaKien
            // 
            this.clQuyRaKien.Caption = "Kien";
            this.clQuyRaKien.FieldName = "QuyRaKien";
            this.clQuyRaKien.Name = "clQuyRaKien";
            this.clQuyRaKien.OptionsColumn.AllowEdit = false;
            // 
            // clPhePham
            // 
            this.clPhePham.Caption = "Phe";
            this.clPhePham.FieldName = "PhePham";
            this.clPhePham.Name = "clPhePham";
            this.clPhePham.OptionsColumn.AllowEdit = false;
            // 
            // clDoCao
            // 
            this.clDoCao.Caption = "Cao";
            this.clDoCao.FieldName = "DoCao";
            this.clDoCao.Name = "clDoCao";
            this.clDoCao.OptionsColumn.AllowEdit = false;
            this.clDoCao.Width = 107;
            // 
            // clSoKG_MotBao
            // 
            this.clSoKG_MotBao.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoKG_MotBao.AppearanceCell.Options.UseFont = true;
            this.clSoKG_MotBao.Caption = "Kg/ 1bao";
            this.clSoKG_MotBao.FieldName = "SoKG_MotBao";
            this.clSoKG_MotBao.Name = "clSoKG_MotBao";
            this.clSoKG_MotBao.OptionsColumn.AllowEdit = false;
            this.clSoKG_MotBao.Visible = true;
            this.clSoKG_MotBao.VisibleIndex = 6;
            this.clSoKG_MotBao.Width = 82;
            // 
            // clSoKienMotBao
            // 
            this.clSoKienMotBao.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoKienMotBao.AppearanceCell.Options.UseFont = true;
            this.clSoKienMotBao.Caption = "Cục / 1 bao";
            this.clSoKienMotBao.FieldName = "SoKienMotBao";
            this.clSoKienMotBao.Name = "clSoKienMotBao";
            this.clSoKienMotBao.OptionsColumn.AllowEdit = false;
            this.clSoKienMotBao.Visible = true;
            this.clSoKienMotBao.VisibleIndex = 5;
            this.clSoKienMotBao.Width = 104;
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
            this.clNgungTheoDoi.OptionsColumn.AllowEdit = false;
            this.clNgungTheoDoi.OptionsColumn.FixedWidth = true;
            this.clNgungTheoDoi.Visible = true;
            this.clNgungTheoDoi.VisibleIndex = 7;
            this.clNgungTheoDoi.Width = 60;
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
            this.clXoa.VisibleIndex = 8;
            this.clXoa.Width = 35;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            editorButtonImageOptions2.Image = global::CtyTinLuong.Properties.Resources.ico_Exit;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // clGhiChu
            // 
            this.clGhiChu.Caption = "Ghi chú";
            this.clGhiChu.FieldName = "GhiChu";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.Width = 113;
            // 
            // clID_VTHH
            // 
            this.clID_VTHH.Caption = "ID_VTHH";
            this.clID_VTHH.FieldName = "ID_VTHH";
            this.clID_VTHH.Name = "clID_VTHH";
            // 
            // clKhoa
            // 
            this.clKhoa.Caption = "Khoá";
            this.clKhoa.FieldName = "Khoa";
            this.clKhoa.Name = "clKhoa";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(894, 587);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(890, 557);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btRefresh;
            this.layoutControlItem2.Location = new System.Drawing.Point(833, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(28, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btThemMoi;
            this.layoutControlItem3.Location = new System.Drawing.Point(861, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(29, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(624, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(209, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkHangNhu;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(140, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.checkHangCuc;
            this.layoutControlItem5.Location = new System.Drawing.Point(140, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem5.Text = "Hàng Cục";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkHangSot;
            this.layoutControlItem6.Location = new System.Drawing.Point(270, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(354, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 606);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            // 
            // UCDinhMucHangNhu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCDinhMucHangNhu";
            this.Size = new System.Drawing.Size(900, 606);
            this.Load += new System.EventHandler(this.UCDinhMucHangNhu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn clKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn clID_VTHH;
        private DevExpress.XtraGrid.Columns.GridColumn clGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clSoKienMotBao;
        private DevExpress.XtraGrid.Columns.GridColumn clSoKG_MotBao;
        private DevExpress.XtraGrid.Columns.GridColumn clDoCao;
        private DevExpress.XtraGrid.Columns.GridColumn clPhePham;
        private DevExpress.XtraGrid.Columns.GridColumn clQuyRaKien;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViQuyDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuongQuyDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clTrongLuongKiemTra;
        private DevExpress.XtraGrid.Columns.GridColumn clDonViTinh1;
        private DevExpress.XtraGrid.Columns.GridColumn clSoLuongKiemTra;
        private DevExpress.XtraGrid.Columns.GridColumn clLoaiGiay;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clTenVT;
        private DevExpress.XtraGrid.Columns.GridColumn clMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn clSoHieu;
        private DevExpress.XtraGrid.Columns.GridColumn clCa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgayThang;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DinhMuc_Dot;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.CheckBox checkHangSot;
        private System.Windows.Forms.CheckBox checkHangCuc;
        private System.Windows.Forms.CheckBox checkHangNhu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
