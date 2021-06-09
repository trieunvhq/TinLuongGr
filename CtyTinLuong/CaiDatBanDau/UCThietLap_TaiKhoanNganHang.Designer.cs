namespace CtyTinLuong
{
    partial class UCThietLap_TaiKhoanNganHang
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_TaiKhoanKeToanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clID_TaiKhoanKeToanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clSoTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clCoKhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNoKhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.checkBoTheoDoi,
            this.btCHiTiet,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemMemoEdit3,
            this.repositoryItemMemoEdit4,
            this.repositoryItemGridLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(724, 572);
            this.gridControl1.TabIndex = 93;
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
            this.clTenTaiKhoanMe,
            this.clCoKhong,
            this.clNoKhong});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NoKhong", this.clNoKhong, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CoKhong", this.clCoKhong, "{0:#,##0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
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
            // clID_TaiKhoanKeToanCon
            // 
            this.clID_TaiKhoanKeToanCon.Caption = "ID_TaiKhoanKeToanCon";
            this.clID_TaiKhoanKeToanCon.FieldName = "ID_TaiKhoanKeToanCon";
            this.clID_TaiKhoanKeToanCon.Name = "clID_TaiKhoanKeToanCon";
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
            this.clXoa.Width = 60;
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            this.clNgungTheoDoi.Width = 60;
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
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
            this.clSoTaiKhoanCon.Caption = "TK con";
            this.clSoTaiKhoanCon.ColumnEdit = this.repositoryItemGridLookUpEdit1;
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
            this.clTenTaiKhoanCon.VisibleIndex = 3;
            this.clTenTaiKhoanCon.Width = 285;
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
            this.clSoTaiKhoanMe.Caption = "TK mẹ";
            this.clSoTaiKhoanMe.FieldName = "SoTaiKhoanMe";
            this.clSoTaiKhoanMe.Name = "clSoTaiKhoanMe";
            this.clSoTaiKhoanMe.OptionsColumn.AllowEdit = false;
            this.clSoTaiKhoanMe.OptionsColumn.FixedWidth = true;
            this.clSoTaiKhoanMe.Visible = true;
            this.clSoTaiKhoanMe.VisibleIndex = 2;
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
            this.clTenTaiKhoanMe.Width = 150;
            // 
            // repositoryItemMemoEdit4
            // 
            this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
            // 
            // clCoKhong
            // 
            this.clCoKhong.AppearanceCell.Options.UseTextOptions = true;
            this.clCoKhong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clCoKhong.Caption = "Có";
            this.clCoKhong.DisplayFormat.FormatString = "{0:#,##0}";
            this.clCoKhong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clCoKhong.FieldName = "CoKhong";
            this.clCoKhong.GroupFormat.FormatString = "{0:#,##0}";
            this.clCoKhong.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clCoKhong.Name = "clCoKhong";
            this.clCoKhong.OptionsColumn.FixedWidth = true;
            this.clCoKhong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CoKhong", "{0:#,##0}")});
            this.clCoKhong.Visible = true;
            this.clCoKhong.VisibleIndex = 4;
            this.clCoKhong.Width = 150;
            // 
            // clNoKhong
            // 
            this.clNoKhong.AppearanceCell.Options.UseTextOptions = true;
            this.clNoKhong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clNoKhong.Caption = "Nợ";
            this.clNoKhong.DisplayFormat.FormatString = "{0:#,##0}";
            this.clNoKhong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNoKhong.FieldName = "NoKhong";
            this.clNoKhong.GroupFormat.FormatString = "{0:#,##0}";
            this.clNoKhong.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clNoKhong.Name = "clNoKhong";
            this.clNoKhong.OptionsColumn.FixedWidth = true;
            this.clNoKhong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NoKhong", "{0:#,##0}")});
            this.clNoKhong.Visible = true;
            this.clNoKhong.VisibleIndex = 5;
            this.clNoKhong.Width = 150;
            // 
            // btCHiTiet
            // 
            this.btCHiTiet.AutoHeight = false;
            this.btCHiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.notebook, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.btCHiTiet.Name = "btCHiTiet";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // btLuu
            // 
            this.btLuu.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLuu.Location = new System.Drawing.Point(630, 581);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(94, 22);
            this.btLuu.TabIndex = 89;
            this.btLuu.Text = "Chỉ lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Image = global::CtyTinLuong.Properties.Resources.ico_Forward;
            this.simpleButton1.Location = new System.Drawing.Point(535, 581);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 22);
            this.simpleButton1.TabIndex = 94;
            this.simpleButton1.Text = "Lưu và gửi";
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
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Lưu ý chỉ một lần duy nhất ấn gửi dữ liệu";
            // 
            // UCThietLap_TaiKhoanNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.gridControl1);
            this.Name = "UCThietLap_TaiKhoanNganHang";
            this.Size = new System.Drawing.Size(727, 606);
            this.Load += new System.EventHandler(this.UCThietLap_TaiKhoanNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanCon;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanMe;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn clCoKhong;
        private DevExpress.XtraGrid.Columns.GridColumn clNoKhong;
        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private System.Windows.Forms.Label label1;
    }
}
