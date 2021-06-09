namespace CtyTinLuong
{
    partial class frmNhaCungCap
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaCungCap));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clSoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clMaNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_TaiKhoanKeToanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btCopy = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.checked_ALL = new DevExpress.XtraEditors.CheckEdit();
            this.checkNgungTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.checkTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(897, 626);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 57;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.checkBoTheoDoi,
            this.btCHiTiet,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.btCopy});
            this.gridControl1.Size = new System.Drawing.Size(960, 579);
            this.gridControl1.TabIndex = 58;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID,
            this.clTen,
            this.clDiaChi,
            this.clSoDienThoai,
            this.clDienGiai,
            this.clXoa,
            this.clNgungTheoDoi,
            this.clMaNCC,
            this.clSoTaiKhoanCon,
            this.ID_TaiKhoanKeToanCon,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.clSTT.Width = 43;
            // 
            // clID
            // 
            this.clID.Caption = "ID_NhaCungCap";
            this.clID.FieldName = "ID_NhaCungCap";
            this.clID.Name = "clID";
            // 
            // clTen
            // 
            this.clTen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clTen.AppearanceHeader.Options.UseFont = true;
            this.clTen.AppearanceHeader.Options.UseTextOptions = true;
            this.clTen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clTen.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTen.Caption = "Tên NCC";
            this.clTen.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clTen.FieldName = "TenNhaCungCap";
            this.clTen.Name = "clTen";
            this.clTen.OptionsColumn.AllowEdit = false;
            this.clTen.Visible = true;
            this.clTen.VisibleIndex = 3;
            this.clTen.Width = 151;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clDiaChi
            // 
            this.clDiaChi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDiaChi.AppearanceHeader.Options.UseFont = true;
            this.clDiaChi.AppearanceHeader.Options.UseTextOptions = true;
            this.clDiaChi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clDiaChi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDiaChi.Caption = "Địa chỉ";
            this.clDiaChi.ColumnEdit = this.repositoryItemMemoEdit2;
            this.clDiaChi.FieldName = "DiaChi";
            this.clDiaChi.Name = "clDiaChi";
            this.clDiaChi.OptionsColumn.AllowEdit = false;
            this.clDiaChi.Visible = true;
            this.clDiaChi.VisibleIndex = 4;
            this.clDiaChi.Width = 185;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // clSoDienThoai
            // 
            this.clSoDienThoai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoDienThoai.AppearanceHeader.Options.UseFont = true;
            this.clSoDienThoai.AppearanceHeader.Options.UseTextOptions = true;
            this.clSoDienThoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoDienThoai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSoDienThoai.Caption = "SĐT";
            this.clSoDienThoai.FieldName = "SoDienThoai";
            this.clSoDienThoai.Name = "clSoDienThoai";
            this.clSoDienThoai.OptionsColumn.AllowEdit = false;
            this.clSoDienThoai.Visible = true;
            this.clSoDienThoai.VisibleIndex = 5;
            this.clSoDienThoai.Width = 133;
            // 
            // clDienGiai
            // 
            this.clDienGiai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDienGiai.AppearanceHeader.Options.UseFont = true;
            this.clDienGiai.AppearanceHeader.Options.UseTextOptions = true;
            this.clDienGiai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clDienGiai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clDienGiai.Caption = "Diễn giải";
            this.clDienGiai.FieldName = "DienGiai";
            this.clDienGiai.Name = "clDienGiai";
            this.clDienGiai.OptionsColumn.AllowEdit = false;
            this.clDienGiai.Visible = true;
            this.clDienGiai.VisibleIndex = 6;
            this.clDienGiai.Width = 144;
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
            this.clXoa.Width = 35;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            editorButtonImageOptions1.Image = global::CtyTinLuong.Properties.Resources.ico_Exit;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btXoa.Name = "btXoa";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // clNgungTheoDoi
            // 
            this.clNgungTheoDoi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNgungTheoDoi.AppearanceHeader.Options.UseFont = true;
            this.clNgungTheoDoi.AppearanceHeader.Options.UseTextOptions = true;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clNgungTheoDoi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clNgungTheoDoi.Caption = "Bỏ";
            this.clNgungTheoDoi.ColumnEdit = this.checkBoTheoDoi;
            this.clNgungTheoDoi.FieldName = "NgungTheoDoi";
            this.clNgungTheoDoi.Name = "clNgungTheoDoi";
            this.clNgungTheoDoi.OptionsColumn.FixedWidth = true;
            this.clNgungTheoDoi.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clNgungTheoDoi.Visible = true;
            this.clNgungTheoDoi.VisibleIndex = 7;
            this.clNgungTheoDoi.Width = 60;
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
            // 
            // clMaNCC
            // 
            this.clMaNCC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clMaNCC.AppearanceHeader.Options.UseFont = true;
            this.clMaNCC.AppearanceHeader.Options.UseTextOptions = true;
            this.clMaNCC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clMaNCC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaNCC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clMaNCC.Caption = "Mã NCC";
            this.clMaNCC.FieldName = "MaNhaCungCap";
            this.clMaNCC.Name = "clMaNCC";
            this.clMaNCC.OptionsColumn.AllowEdit = false;
            this.clMaNCC.OptionsColumn.FixedWidth = true;
            this.clMaNCC.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clMaNCC.Visible = true;
            this.clMaNCC.VisibleIndex = 1;
            this.clMaNCC.Width = 71;
            // 
            // clSoTaiKhoanCon
            // 
            this.clSoTaiKhoanCon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoTaiKhoanCon.AppearanceHeader.Options.UseFont = true;
            this.clSoTaiKhoanCon.AppearanceHeader.Options.UseTextOptions = true;
            this.clSoTaiKhoanCon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoTaiKhoanCon.Caption = "TK";
            this.clSoTaiKhoanCon.FieldName = "SoTaiKhoanCon";
            this.clSoTaiKhoanCon.Name = "clSoTaiKhoanCon";
            this.clSoTaiKhoanCon.OptionsColumn.AllowEdit = false;
            this.clSoTaiKhoanCon.Visible = true;
            this.clSoTaiKhoanCon.VisibleIndex = 2;
            this.clSoTaiKhoanCon.Width = 80;
            // 
            // ID_TaiKhoanKeToanCon
            // 
            this.ID_TaiKhoanKeToanCon.Caption = "ID_TaiKhoanKeToanCon";
            this.ID_TaiKhoanKeToanCon.FieldName = "ID_TaiKhoanKeToanCon";
            this.ID_TaiKhoanKeToanCon.Name = "ID_TaiKhoanKeToanCon";
            this.ID_TaiKhoanKeToanCon.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Copy";
            this.gridColumn1.ColumnEdit = this.btCopy;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 40;
            // 
            // btCopy
            // 
            this.btCopy.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.btCopy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btCopy.Name = "btCopy";
            this.btCopy.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // btCHiTiet
            // 
            this.btCHiTiet.AutoHeight = false;
            editorButtonImageOptions3.Image = global::CtyTinLuong.Properties.Resources.notebook;
            this.btCHiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btCHiTiet.Name = "btCHiTiet";
            // 
            // btThemMoi
            // 
            this.btThemMoi.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Add;
            this.btThemMoi.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btThemMoi.Location = new System.Drawing.Point(12, 12);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(32, 23);
            this.btThemMoi.TabIndex = 62;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // checked_ALL
            // 
            this.checked_ALL.Location = new System.Drawing.Point(697, 10);
            this.checked_ALL.Name = "checked_ALL";
            this.checked_ALL.Properties.Caption = "Tất cả";
            this.checked_ALL.Size = new System.Drawing.Size(56, 19);
            this.checked_ALL.TabIndex = 61;
            this.checked_ALL.CheckedChanged += new System.EventHandler(this.checked_ALL_CheckedChanged);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(868, 12);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.Properties.Caption = "Ngừng theo dõi";
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(104, 19);
            this.checkNgungTheoDoi.TabIndex = 60;
            this.checkNgungTheoDoi.CheckedChanged += new System.EventHandler(this.checkNgungTheoDoi_CheckedChanged);
            // 
            // checkTheoDoi
            // 
            this.checkTheoDoi.Location = new System.Drawing.Point(759, 10);
            this.checkTheoDoi.Name = "checkTheoDoi";
            this.checkTheoDoi.Properties.Caption = "Đang theo dõi";
            this.checkTheoDoi.Size = new System.Drawing.Size(103, 19);
            this.checkTheoDoi.TabIndex = 59;
            this.checkTheoDoi.CheckedChanged += new System.EventHandler(this.checkTheoDoi_CheckedChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(50, 12);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(39, 23);
            this.btRefresh.TabIndex = 90;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btThemMoi);
            this.Controls.Add(this.checked_ALL);
            this.Controls.Add(this.checkNgungTheoDoi);
            this.Controls.Add(this.checkTheoDoi);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNhaCungCap";
            this.Text = "Nhà cung cấp";
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID;
        private DevExpress.XtraGrid.Columns.GridColumn clTen;
        private DevExpress.XtraGrid.Columns.GridColumn clDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn clSoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn clDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clMaNCC;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraEditors.CheckEdit checked_ALL;
        private DevExpress.XtraEditors.CheckEdit checkNgungTheoDoi;
        private DevExpress.XtraEditors.CheckEdit checkTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn ID_TaiKhoanKeToanCon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCopy;
    }
}