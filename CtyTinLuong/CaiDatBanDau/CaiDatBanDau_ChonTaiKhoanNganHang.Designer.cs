namespace CtyTinLuong
{
    partial class CaiDatBanDau_ChonTaiKhoanNganHang
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clTenTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clTenTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_TaiKhoanKeToanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_TaiKhoanKeToanCon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.checkChon = new DevExpress.XtraEditors.CheckEdit();
            this.btDongY = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "label1";
            // 
            // btThoat
            // 
            this.btThoat.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(897, 628);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 101;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // repositoryItemMemoEdit4
            // 
            this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
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
            this.clTenTaiKhoanMe.VisibleIndex = 2;
            this.clTenTaiKhoanMe.Width = 150;
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
            this.clSoTaiKhoanMe.VisibleIndex = 1;
            this.clSoTaiKhoanMe.Width = 105;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
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
            this.clTenTaiKhoanCon.VisibleIndex = 4;
            this.clTenTaiKhoanCon.Width = 417;
            // 
            // clSoTaiKhoanCon
            // 
            this.clSoTaiKhoanCon.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSoTaiKhoanCon.AppearanceCell.Options.UseFont = true;
            this.clSoTaiKhoanCon.AppearanceCell.Options.UseTextOptions = true;
            this.clSoTaiKhoanCon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSoTaiKhoanCon.Caption = "Số TK Con";
            this.clSoTaiKhoanCon.FieldName = "SoTaiKhoanCon";
            this.clSoTaiKhoanCon.Name = "clSoTaiKhoanCon";
            this.clSoTaiKhoanCon.OptionsColumn.AllowEdit = false;
            this.clSoTaiKhoanCon.OptionsColumn.FixedWidth = true;
            this.clSoTaiKhoanCon.Visible = true;
            this.clSoTaiKhoanCon.VisibleIndex = 3;
            this.clSoTaiKhoanCon.Width = 100;
            // 
            // clID_TaiKhoanKeToanMe
            // 
            this.clID_TaiKhoanKeToanMe.Caption = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.FieldName = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.Name = "clID_TaiKhoanKeToanMe";
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
            this.clChon,
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
            // clChon
            // 
            this.clChon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clChon.AppearanceHeader.Options.UseFont = true;
            this.clChon.AppearanceHeader.Options.UseTextOptions = true;
            this.clChon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clChon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clChon.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clChon.Caption = "Chọn";
            this.clChon.ColumnEdit = this.repositoryItemCheckEdit1;
            this.clChon.FieldName = "Chon";
            this.clChon.Name = "clChon";
            this.clChon.OptionsColumn.FixedWidth = true;
            this.clChon.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clChon.Visible = true;
            this.clChon.VisibleIndex = 5;
            this.clChon.Width = 60;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 37);
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
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(960, 585);
            this.gridControl1.TabIndex = 102;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btXoa
            // 
            this.btXoa.AutoHeight = false;
            this.btXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.ico_Exit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.btXoa.Name = "btXoa";
            this.btXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
            // 
            // btCHiTiet
            // 
            this.btCHiTiet.AutoHeight = false;
            this.btCHiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.notebook, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
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
            // checkChon
            // 
            this.checkChon.Location = new System.Drawing.Point(889, 12);
            this.checkChon.Name = "checkChon";
            this.checkChon.Properties.Caption = "Chọn tất cả";
            this.checkChon.Size = new System.Drawing.Size(83, 19);
            this.checkChon.TabIndex = 104;
            this.checkChon.CheckedChanged += new System.EventHandler(this.checkChon_CheckedChanged);
            // 
            // btDongY
            // 
            this.btDongY.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btDongY.Image = global::CtyTinLuong.Properties.Resources.ico_Check;
            this.btDongY.Location = new System.Drawing.Point(816, 628);
            this.btDongY.Name = "btDongY";
            this.btDongY.Size = new System.Drawing.Size(75, 23);
            this.btDongY.TabIndex = 108;
            this.btDongY.Text = "Đồng ý";
            this.btDongY.Click += new System.EventHandler(this.btDongY_Click);
            // 
            // CaiDatBanDau_ChonTaiKhoanNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.btDongY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.checkChon);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaiDatBanDau_ChonTaiKhoanNganHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaiDatBanDau_ChonTaiKhoanNganHang";
            this.Load += new System.EventHandler(this.CaiDatBanDau_ChonTaiKhoanNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChon.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanMe;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanMe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanCon;
        private DevExpress.XtraGrid.Columns.GridColumn clChon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.CheckEdit checkChon;
        private DevExpress.XtraEditors.SimpleButton btDongY;
    }
}