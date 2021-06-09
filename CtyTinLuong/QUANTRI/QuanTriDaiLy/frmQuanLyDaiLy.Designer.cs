namespace CtyTinLuong
{
    partial class frmQuanLyDaiLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyDaiLy));
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
            this.clSoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_DaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaDaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenDaiLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clDaiDien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btCooy = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.checked_ALL = new DevExpress.XtraEditors.CheckEdit();
            this.checkTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.checkNgungTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCooy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(897, 628);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 69;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
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
            this.clSoDienThoai.OptionsColumn.FixedWidth = true;
            this.clSoDienThoai.Visible = true;
            this.clSoDienThoai.VisibleIndex = 4;
            this.clSoDienThoai.Width = 130;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_DaiLy,
            this.clMaDaiLy,
            this.clTenDaiLy,
            this.clDiaChi,
            this.clSoDienThoai,
            this.clGhiChu,
            this.clXoa,
            this.clNgungTheoDoi,
            this.clDaiDien,
            this.clKhoa,
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
            // clID_DaiLy
            // 
            this.clID_DaiLy.Caption = "ID_DaiLy";
            this.clID_DaiLy.FieldName = "ID_DaiLy";
            this.clID_DaiLy.Name = "clID_DaiLy";
            // 
            // clMaDaiLy
            // 
            this.clMaDaiLy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clMaDaiLy.AppearanceHeader.Options.UseFont = true;
            this.clMaDaiLy.AppearanceHeader.Options.UseTextOptions = true;
            this.clMaDaiLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clMaDaiLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clMaDaiLy.Caption = "Mã";
            this.clMaDaiLy.FieldName = "MaDaiLy";
            this.clMaDaiLy.Name = "clMaDaiLy";
            this.clMaDaiLy.OptionsColumn.AllowEdit = false;
            this.clMaDaiLy.OptionsColumn.FixedWidth = true;
            this.clMaDaiLy.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clMaDaiLy.Visible = true;
            this.clMaDaiLy.VisibleIndex = 1;
            this.clMaDaiLy.Width = 80;
            // 
            // clTenDaiLy
            // 
            this.clTenDaiLy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clTenDaiLy.AppearanceHeader.Options.UseFont = true;
            this.clTenDaiLy.AppearanceHeader.Options.UseTextOptions = true;
            this.clTenDaiLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clTenDaiLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenDaiLy.Caption = "Tên đại lý ";
            this.clTenDaiLy.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clTenDaiLy.FieldName = "TenDaiLy";
            this.clTenDaiLy.Name = "clTenDaiLy";
            this.clTenDaiLy.OptionsColumn.AllowEdit = false;
            this.clTenDaiLy.Visible = true;
            this.clTenDaiLy.VisibleIndex = 2;
            this.clTenDaiLy.Width = 290;
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
            this.clDiaChi.OptionsColumn.FixedWidth = true;
            this.clDiaChi.Visible = true;
            this.clDiaChi.VisibleIndex = 3;
            this.clDiaChi.Width = 181;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // clGhiChu
            // 
            this.clGhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clGhiChu.AppearanceHeader.Options.UseFont = true;
            this.clGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.clGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clGhiChu.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clGhiChu.Caption = "Ghi chú";
            this.clGhiChu.FieldName = "GhiChu";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.OptionsColumn.AllowEdit = false;
            this.clGhiChu.OptionsColumn.FixedWidth = true;
            this.clGhiChu.Visible = true;
            this.clGhiChu.VisibleIndex = 5;
            this.clGhiChu.Width = 138;
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
            this.clXoa.Width = 40;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            editorButtonImageOptions1.Image = global::CtyTinLuong.Properties.Resources.ico_Exit;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btXoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btXoa_ButtonClick);
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
            this.clNgungTheoDoi.VisibleIndex = 6;
            this.clNgungTheoDoi.Width = 40;
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
            // 
            // clDaiDien
            // 
            this.clDaiDien.Caption = "Đại diện";
            this.clDaiDien.FieldName = "DaiDien";
            this.clDaiDien.Name = "clDaiDien";
            // 
            // clKhoa
            // 
            this.clKhoa.Caption = "Khoá";
            this.clKhoa.FieldName = "Khoa";
            this.clKhoa.Name = "clKhoa";
            this.clKhoa.OptionsColumn.AllowEdit = false;
            this.clKhoa.OptionsColumn.FixedWidth = true;
            this.clKhoa.Width = 40;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Copy";
            this.gridColumn1.ColumnEdit = this.btCooy;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 40;
            // 
            // btCooy
            // 
            this.btCooy.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.btCooy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btCooy.Name = "btCooy";
            this.btCooy.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btCooy.Click += new System.EventHandler(this.btCooy_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.checkBoTheoDoi,
            this.btCHiTiet,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.btCooy});
            this.gridControl1.Size = new System.Drawing.Size(960, 579);
            this.gridControl1.TabIndex = 70;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.btThemMoi.Location = new System.Drawing.Point(12, 14);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(32, 23);
            this.btThemMoi.TabIndex = 74;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // checked_ALL
            // 
            this.checked_ALL.Location = new System.Drawing.Point(697, 12);
            this.checked_ALL.Name = "checked_ALL";
            this.checked_ALL.Properties.Caption = "Tất cả";
            this.checked_ALL.Size = new System.Drawing.Size(56, 19);
            this.checked_ALL.TabIndex = 73;
            this.checked_ALL.CheckedChanged += new System.EventHandler(this.checked_ALL_CheckedChanged);
            // 
            // checkTheoDoi
            // 
            this.checkTheoDoi.Location = new System.Drawing.Point(759, 12);
            this.checkTheoDoi.Name = "checkTheoDoi";
            this.checkTheoDoi.Properties.Caption = "Đang theo dõi";
            this.checkTheoDoi.Size = new System.Drawing.Size(103, 19);
            this.checkTheoDoi.TabIndex = 71;
            this.checkTheoDoi.CheckedChanged += new System.EventHandler(this.checkTheoDoi_CheckedChanged);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(868, 14);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.Properties.Caption = "Ngừng theo dõi";
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(104, 19);
            this.checkNgungTheoDoi.TabIndex = 72;
            this.checkNgungTheoDoi.CheckedChanged += new System.EventHandler(this.checkNgungTheoDoi_CheckedChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(50, 14);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(39, 23);
            this.btRefresh.TabIndex = 76;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // frmQuanLyDaiLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btThemMoi);
            this.Controls.Add(this.checked_ALL);
            this.Controls.Add(this.checkTheoDoi);
            this.Controls.Add(this.checkNgungTheoDoi);
            this.Name = "frmQuanLyDaiLy";
            this.Text = "Danh mục Đại Lý";
            this.Load += new System.EventHandler(this.frmQuanLyDaiLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCooy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraGrid.Columns.GridColumn clSoDienThoai;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clMaDaiLy;
        private DevExpress.XtraGrid.Columns.GridColumn clTenDaiLy;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDiaChi;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn clGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraEditors.CheckEdit checked_ALL;
        private DevExpress.XtraEditors.CheckEdit checkTheoDoi;
        private DevExpress.XtraEditors.CheckEdit checkNgungTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clDaiDien;
        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn clKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCooy;
    }
}