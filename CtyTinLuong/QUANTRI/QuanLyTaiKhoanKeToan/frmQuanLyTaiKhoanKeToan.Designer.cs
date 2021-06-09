namespace CtyTinLuong
{
    partial class frmQuanLyTaiKhoanKeToan
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyTaiKhoanKeToan));
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.checked_ALL = new DevExpress.XtraEditors.CheckEdit();
            this.checkNgungTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clID_TaiKhoanKeToanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clID_TaiKhoanKeToanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clSoTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.checkTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btThemMoi_Me = new DevExpress.XtraEditors.SimpleButton();
            this.btThemMoi_Con = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(293, 16);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(39, 23);
            this.btRefresh.TabIndex = 97;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // checked_ALL
            // 
            this.checked_ALL.Location = new System.Drawing.Point(697, 12);
            this.checked_ALL.Name = "checked_ALL";
            this.checked_ALL.Properties.Caption = "Tất cả";
            this.checked_ALL.Size = new System.Drawing.Size(56, 19);
            this.checked_ALL.TabIndex = 95;
            this.checked_ALL.CheckedChanged += new System.EventHandler(this.checked_ALL_CheckedChanged);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(868, 14);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.Properties.Caption = "Ngừng theo dõi";
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(104, 19);
            this.checkNgungTheoDoi.TabIndex = 94;
            this.checkNgungTheoDoi.CheckedChanged += new System.EventHandler(this.checkNgungTheoDoi_CheckedChanged);
            // 
            // btCHiTiet
            // 
            this.btCHiTiet.AutoHeight = false;
            this.btCHiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.notebook, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btCHiTiet.Name = "btCHiTiet";
            this.btCHiTiet.Click += new System.EventHandler(this.btCHiTiet_Click);
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
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
            this.clNgungTheoDoi.VisibleIndex = 5;
            this.clNgungTheoDoi.Width = 60;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
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
            this.clXoa.VisibleIndex = 6;
            this.clXoa.Width = 60;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clID_TaiKhoanKeToanCon
            // 
            this.clID_TaiKhoanKeToanCon.Caption = "ID_TaiKhoanKeToanCon";
            this.clID_TaiKhoanKeToanCon.FieldName = "ID_TaiKhoanKeToanCon";
            this.clID_TaiKhoanKeToanCon.Name = "clID_TaiKhoanKeToanCon";
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
            this.clSTT.Width = 50;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clID_TaiKhoanKeToanCon,
            this.clXoa,
            this.clNgungTheoDoi,
            this.clID_TaiKhoanKeToanMe,
            this.clSoTaiKhoanCon,
            this.clTenTaiKhoanCon,
            this.clSoTaiKhoanMe,
            this.clTenTaiKhoanMe});
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
            // clID_TaiKhoanKeToanMe
            // 
            this.clID_TaiKhoanKeToanMe.Caption = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.FieldName = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.Name = "clID_TaiKhoanKeToanMe";
            // 
            // clSoTaiKhoanCon
            // 
            this.clSoTaiKhoanCon.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoTaiKhoanCon.AppearanceCell.Options.UseFont = true;
            this.clSoTaiKhoanCon.AppearanceCell.Options.UseTextOptions = true;
            this.clSoTaiKhoanCon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoTaiKhoanCon.Caption = "Số TK";
            this.clSoTaiKhoanCon.FieldName = "SoTaiKhoanCon";
            this.clSoTaiKhoanCon.Name = "clSoTaiKhoanCon";
            this.clSoTaiKhoanCon.OptionsColumn.AllowEdit = false;
            this.clSoTaiKhoanCon.OptionsColumn.FixedWidth = true;
            this.clSoTaiKhoanCon.Visible = true;
            this.clSoTaiKhoanCon.VisibleIndex = 1;
            this.clSoTaiKhoanCon.Width = 100;
            // 
            // clTenTaiKhoanCon
            // 
            this.clTenTaiKhoanCon.AppearanceCell.Options.UseTextOptions = true;
            this.clTenTaiKhoanCon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clTenTaiKhoanCon.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clTenTaiKhoanCon.Caption = "Tên Tài khoản";
            this.clTenTaiKhoanCon.ColumnEdit = this.repositoryItemMemoEdit3;
            this.clTenTaiKhoanCon.FieldName = "TenTaiKhoanCon";
            this.clTenTaiKhoanCon.Name = "clTenTaiKhoanCon";
            this.clTenTaiKhoanCon.OptionsColumn.AllowEdit = false;
            this.clTenTaiKhoanCon.Visible = true;
            this.clTenTaiKhoanCon.VisibleIndex = 2;
            this.clTenTaiKhoanCon.Width = 417;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // clSoTaiKhoanMe
            // 
            this.clSoTaiKhoanMe.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoTaiKhoanMe.AppearanceCell.Options.UseFont = true;
            this.clSoTaiKhoanMe.AppearanceCell.Options.UseTextOptions = true;
            this.clSoTaiKhoanMe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoTaiKhoanMe.Caption = "Số TK mẹ";
            this.clSoTaiKhoanMe.FieldName = "SoTaiKhoanMe";
            this.clSoTaiKhoanMe.Name = "clSoTaiKhoanMe";
            this.clSoTaiKhoanMe.OptionsColumn.AllowEdit = false;
            this.clSoTaiKhoanMe.OptionsColumn.FixedWidth = true;
            this.clSoTaiKhoanMe.Visible = true;
            this.clSoTaiKhoanMe.VisibleIndex = 3;
            this.clSoTaiKhoanMe.Width = 105;
            // 
            // clTenTaiKhoanMe
            // 
            this.clTenTaiKhoanMe.AppearanceCell.Options.UseTextOptions = true;
            this.clTenTaiKhoanMe.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clTenTaiKhoanMe.Caption = "Tên TK mẹ";
            this.clTenTaiKhoanMe.ColumnEdit = this.repositoryItemMemoEdit4;
            this.clTenTaiKhoanMe.FieldName = "TenTaiKhoanMe";
            this.clTenTaiKhoanMe.Name = "clTenTaiKhoanMe";
            this.clTenTaiKhoanMe.OptionsColumn.AllowEdit = false;
            this.clTenTaiKhoanMe.OptionsColumn.FixedWidth = true;
            this.clTenTaiKhoanMe.Visible = true;
            this.clTenTaiKhoanMe.VisibleIndex = 4;
            this.clTenTaiKhoanMe.Width = 150;
            // 
            // repositoryItemMemoEdit4
            // 
            this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
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
            this.repositoryItemMemoEdit3,
            this.repositoryItemMemoEdit4});
            this.gridControl1.Size = new System.Drawing.Size(960, 579);
            this.gridControl1.TabIndex = 92;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // checkTheoDoi
            // 
            this.checkTheoDoi.Location = new System.Drawing.Point(759, 12);
            this.checkTheoDoi.Name = "checkTheoDoi";
            this.checkTheoDoi.Properties.Caption = "Đang theo dõi";
            this.checkTheoDoi.Size = new System.Drawing.Size(103, 19);
            this.checkTheoDoi.TabIndex = 93;
            this.checkTheoDoi.CheckedChanged += new System.EventHandler(this.checkTheoDoi_CheckedChanged);
            // 
            // btThoat
            // 
            this.btThoat.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(897, 628);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 91;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "label1";
            // 
            // btThemMoi_Me
            // 
            this.btThemMoi_Me.Image = ((System.Drawing.Image)(resources.GetObject("btThemMoi_Me.Image")));
            this.btThemMoi_Me.Location = new System.Drawing.Point(15, 16);
            this.btThemMoi_Me.Name = "btThemMoi_Me";
            this.btThemMoi_Me.Size = new System.Drawing.Size(133, 23);
            this.btThemMoi_Me.TabIndex = 99;
            this.btThemMoi_Me.Text = "Thêm mới TK mẹ";
            // 
            // btThemMoi_Con
            // 
            this.btThemMoi_Con.Image = ((System.Drawing.Image)(resources.GetObject("btThemMoi_Con.Image")));
            this.btThemMoi_Con.Location = new System.Drawing.Point(154, 16);
            this.btThemMoi_Con.Name = "btThemMoi_Con";
            this.btThemMoi_Con.Size = new System.Drawing.Size(133, 23);
            this.btThemMoi_Con.TabIndex = 100;
            this.btThemMoi_Con.Text = "Thêm mới TK con";
            this.btThemMoi_Con.Click += new System.EventHandler(this.btThemMoi_Con_Click);
            // 
            // frmQuanLyTaiKhoanKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.btThemMoi_Con);
            this.Controls.Add(this.btThemMoi_Me);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.checked_ALL);
            this.Controls.Add(this.checkNgungTheoDoi);
            this.Controls.Add(this.checkTheoDoi);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyTaiKhoanKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản kế toán";
            this.Load += new System.EventHandler(this.frmQuanLyTaiKhoanKeToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraEditors.CheckEdit checked_ALL;
        private DevExpress.XtraEditors.CheckEdit checkNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.CheckEdit checkTheoDoi;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanMe;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btThemMoi_Me;
        private DevExpress.XtraEditors.SimpleButton btThemMoi_Con;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit4;
    }
}