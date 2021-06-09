namespace CtyTinLuong
{
    partial class UCSanXuat_CaiDatMacDinh
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
            this.btRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.clNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaDinhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDinhMuc_KhongTang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDinhMuc_Tang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clID_DinhMuc_Luong_SanLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_MacDinhSanXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_DinhMuc_Luong_SanLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaDinhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::CtyTinLuong.Properties.Resources.ico_Update;
            this.btRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btRefresh.Location = new System.Drawing.Point(5, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(39, 23);
            this.btRefresh.TabIndex = 81;
            this.btRefresh.ToolTip = "Refesh";
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            this.clNoiDung,
            this.clMaDinhMuc,
            this.clDienGiai,
            this.clDinhMuc_KhongTang,
            this.clDinhMuc_Tang,
            this.clID_DinhMuc_Luong_SanLuong,
            this.clID_MacDinhSanXuat});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(716, 571);
            this.gridControl1.TabIndex = 76;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // clNoiDung
            // 
            this.clNoiDung.AppearanceCell.Options.UseTextOptions = true;
            this.clNoiDung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clNoiDung.Caption = "Nội dung";
            this.clNoiDung.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clNoiDung.FieldName = "NoiDung";
            this.clNoiDung.Name = "clNoiDung";
            this.clNoiDung.OptionsColumn.AllowEdit = false;
            this.clNoiDung.Visible = true;
            this.clNoiDung.VisibleIndex = 1;
            this.clNoiDung.Width = 126;
            // 
            // clMaDinhMuc
            // 
            this.clMaDinhMuc.Caption = "Mã Định mức";
            this.clMaDinhMuc.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.clMaDinhMuc.FieldName = "MaDinhMuc";
            this.clMaDinhMuc.Name = "clMaDinhMuc";
            this.clMaDinhMuc.Visible = true;
            this.clMaDinhMuc.VisibleIndex = 2;
            this.clMaDinhMuc.Width = 106;
            // 
            // clDienGiai
            // 
            this.clDienGiai.Caption = "Diễn giải";
            this.clDienGiai.FieldName = "DienGiai";
            this.clDienGiai.Name = "clDienGiai";
            this.clDienGiai.Visible = true;
            this.clDienGiai.VisibleIndex = 3;
            this.clDienGiai.Width = 136;
            // 
            // clDinhMuc_KhongTang
            // 
            this.clDinhMuc_KhongTang.Caption = "ĐM- Không tăng";
            this.clDinhMuc_KhongTang.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clDinhMuc_KhongTang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDinhMuc_KhongTang.FieldName = "DinhMuc_KhongTang";
            this.clDinhMuc_KhongTang.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clDinhMuc_KhongTang.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDinhMuc_KhongTang.Name = "clDinhMuc_KhongTang";
            this.clDinhMuc_KhongTang.Visible = true;
            this.clDinhMuc_KhongTang.VisibleIndex = 4;
            this.clDinhMuc_KhongTang.Width = 136;
            // 
            // clDinhMuc_Tang
            // 
            this.clDinhMuc_Tang.Caption = "ĐM-Tăng";
            this.clDinhMuc_Tang.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.clDinhMuc_Tang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDinhMuc_Tang.FieldName = "DinhMuc_Tang";
            this.clDinhMuc_Tang.GroupFormat.FormatString = "{0:#,##0.00}";
            this.clDinhMuc_Tang.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDinhMuc_Tang.Name = "clDinhMuc_Tang";
            this.clDinhMuc_Tang.Visible = true;
            this.clDinhMuc_Tang.VisibleIndex = 5;
            this.clDinhMuc_Tang.Width = 144;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID_DinhMuc_Luong_SanLuong,
            this.MaDinhMuc,
            this.DienGiai});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clID_DinhMuc_Luong_SanLuong
            // 
            this.clID_DinhMuc_Luong_SanLuong.Caption = "ID_DinhMuc_Luong_SanLuong";
            this.clID_DinhMuc_Luong_SanLuong.FieldName = "ID_DinhMuc_Luong_SanLuong";
            this.clID_DinhMuc_Luong_SanLuong.Name = "clID_DinhMuc_Luong_SanLuong";
            // 
            // clID_MacDinhSanXuat
            // 
            this.clID_MacDinhSanXuat.Caption = "ID_MacDinhSanXuat";
            this.clID_MacDinhSanXuat.FieldName = "ID_MacDinhSanXuat";
            this.clID_MacDinhSanXuat.Name = "clID_MacDinhSanXuat";
            // 
            // ID_DinhMuc_Luong_SanLuong
            // 
            this.ID_DinhMuc_Luong_SanLuong.Caption = "ID_DinhMuc_Luong_SanLuong";
            this.ID_DinhMuc_Luong_SanLuong.FieldName = "ID_DinhMuc_Luong_SanLuong";
            this.ID_DinhMuc_Luong_SanLuong.Name = "ID_DinhMuc_Luong_SanLuong";
            // 
            // MaDinhMuc
            // 
            this.MaDinhMuc.Caption = "Mã ĐM";
            this.MaDinhMuc.FieldName = "MaDinhMuc";
            this.MaDinhMuc.Name = "MaDinhMuc";
            this.MaDinhMuc.Visible = true;
            this.MaDinhMuc.VisibleIndex = 0;
            this.MaDinhMuc.Width = 120;
            // 
            // DienGiai
            // 
            this.DienGiai.Caption = "Diễn giải";
            this.DienGiai.FieldName = "DienGiai";
            this.DienGiai.Name = "DienGiai";
            this.DienGiai.Visible = true;
            this.DienGiai.VisibleIndex = 1;
            this.DienGiai.Width = 264;
            // 
            // UCSanXuat_CaiDatMacDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.gridControl1);
            this.Name = "UCSanXuat_CaiDatMacDinh";
            this.Size = new System.Drawing.Size(727, 606);
            this.Load += new System.EventHandler(this.UCSanXuat_CaiDatMacDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn clNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn clMaDinhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn clDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn clDinhMuc_KhongTang;
        private DevExpress.XtraGrid.Columns.GridColumn clDinhMuc_Tang;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DinhMuc_Luong_SanLuong;
        private DevExpress.XtraGrid.Columns.GridColumn clID_MacDinhSanXuat;
        private DevExpress.XtraGrid.Columns.GridColumn ID_DinhMuc_Luong_SanLuong;
        private DevExpress.XtraGrid.Columns.GridColumn MaDinhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn DienGiai;
    }
}
