namespace CtyTinLuong
{
    partial class frmQuanLyMayMoc
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
            this.btThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.checked_ALL = new DevExpress.XtraEditors.CheckEdit();
            this.checkTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.checkNgungTheoDoi = new DevExpress.XtraEditors.CheckEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clid_loai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clid_tinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clNgungTheoDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkBoTheoDoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btCHiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btThemMoi
            // 
            this.btThemMoi.Image = global::CtyTinLuong.Properties.Resources.ico_Add;
            this.btThemMoi.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btThemMoi.Location = new System.Drawing.Point(12, 13);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(32, 23);
            this.btThemMoi.TabIndex = 74;
            this.btThemMoi.ToolTip = "Refesh";
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // checked_ALL
            // 
            this.checked_ALL.Location = new System.Drawing.Point(697, 11);
            this.checked_ALL.Name = "checked_ALL";
            this.checked_ALL.Properties.Caption = "Tất cả";
            this.checked_ALL.Size = new System.Drawing.Size(56, 19);
            this.checked_ALL.TabIndex = 73;
            this.checked_ALL.CheckedChanged += new System.EventHandler(this.checked_ALL_CheckedChanged);
            // 
            // checkTheoDoi
            // 
            this.checkTheoDoi.Location = new System.Drawing.Point(759, 11);
            this.checkTheoDoi.Name = "checkTheoDoi";
            this.checkTheoDoi.Properties.Caption = "Đang theo dõi";
            this.checkTheoDoi.Size = new System.Drawing.Size(103, 19);
            this.checkTheoDoi.TabIndex = 71;
            this.checkTheoDoi.CheckedChanged += new System.EventHandler(this.checkTheoDoi_CheckedChanged);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(868, 13);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.Properties.Caption = "Ngừng theo dõi";
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(104, 19);
            this.checkNgungTheoDoi.TabIndex = 72;
            this.checkNgungTheoDoi.CheckedChanged += new System.EventHandler(this.checkNgungTheoDoi_CheckedChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clid,
            this.clid_loai,
            this.clid_tinhtrang,
            this.clten,
            this.clghichu,
            this.clXoa,
            this.clNgungTheoDoi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
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
            // clid
            // 
            this.clid.Caption = "id";
            this.clid.FieldName = "id";
            this.clid.Name = "clid";
            // 
            // clid_loai
            // 
            this.clid_loai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clid_loai.AppearanceHeader.Options.UseFont = true;
            this.clid_loai.AppearanceHeader.Options.UseTextOptions = true;
            this.clid_loai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clid_loai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clid_loai.Caption = "id_loai";
            this.clid_loai.FieldName = "id_loai";
            this.clid_loai.Name = "clid_loai";
            this.clid_loai.OptionsColumn.AllowEdit = false;
            this.clid_loai.OptionsColumn.FixedWidth = true;
            this.clid_loai.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.clid_loai.Width = 71;
            // 
            // clid_tinhtrang
            // 
            this.clid_tinhtrang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clid_tinhtrang.AppearanceHeader.Options.UseFont = true;
            this.clid_tinhtrang.AppearanceHeader.Options.UseTextOptions = true;
            this.clid_tinhtrang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clid_tinhtrang.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clid_tinhtrang.Caption = "id_tinhtrang";
            this.clid_tinhtrang.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clid_tinhtrang.FieldName = "id_tinhtrang";
            this.clid_tinhtrang.Name = "clid_tinhtrang";
            this.clid_tinhtrang.OptionsColumn.AllowEdit = false;
            this.clid_tinhtrang.Width = 141;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clten
            // 
            this.clten.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clten.AppearanceHeader.Options.UseFont = true;
            this.clten.AppearanceHeader.Options.UseTextOptions = true;
            this.clten.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clten.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clten.Caption = "Tên máy";
            this.clten.ColumnEdit = this.repositoryItemMemoEdit2;
            this.clten.FieldName = "ten";
            this.clten.Name = "clten";
            this.clten.OptionsColumn.AllowEdit = false;
            this.clten.Visible = true;
            this.clten.VisibleIndex = 1;
            this.clten.Width = 172;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // clghichu
            // 
            this.clghichu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clghichu.AppearanceHeader.Options.UseFont = true;
            this.clghichu.AppearanceHeader.Options.UseTextOptions = true;
            this.clghichu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clghichu.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clghichu.Caption = "Ghi chú";
            this.clghichu.FieldName = "ghichu";
            this.clghichu.Name = "clghichu";
            this.clghichu.OptionsColumn.AllowEdit = false;
            this.clghichu.Visible = true;
            this.clghichu.VisibleIndex = 2;
            this.clghichu.Width = 124;
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
            this.clNgungTheoDoi.VisibleIndex = 3;
            this.clNgungTheoDoi.Width = 60;
            // 
            // checkBoTheoDoi
            // 
            this.checkBoTheoDoi.AutoHeight = false;
            this.checkBoTheoDoi.Caption = "Check";
            this.checkBoTheoDoi.Name = "checkBoTheoDoi";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btXoa,
            this.checkBoTheoDoi,
            this.btCHiTiet,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.gridControl1.Size = new System.Drawing.Size(960, 579);
            this.gridControl1.TabIndex = 70;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btCHiTiet
            // 
            this.btCHiTiet.AutoHeight = false;
            this.btCHiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CtyTinLuong.Properties.Resources.notebook, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btCHiTiet.Name = "btCHiTiet";
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(897, 627);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 69;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // frmQuanLyMayMoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btThoat;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btThemMoi);
            this.Controls.Add(this.checked_ALL);
            this.Controls.Add(this.checkTheoDoi);
            this.Controls.Add(this.checkNgungTheoDoi);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyMayMoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Máy sản xuất";
            this.Load += new System.EventHandler(this.frmQuanLyMayMoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checked_ALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNgungTheoDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCHiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btThemMoi;
        private DevExpress.XtraEditors.CheckEdit checked_ALL;
        private DevExpress.XtraEditors.CheckEdit checkTheoDoi;
        private DevExpress.XtraEditors.CheckEdit checkNgungTheoDoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clid;
        private DevExpress.XtraGrid.Columns.GridColumn clid_loai;
        private DevExpress.XtraGrid.Columns.GridColumn clid_tinhtrang;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clten;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn clghichu;
        private DevExpress.XtraGrid.Columns.GridColumn clXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btXoa;
        private DevExpress.XtraGrid.Columns.GridColumn clNgungTheoDoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkBoTheoDoi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btCHiTiet;
        private DevExpress.XtraEditors.SimpleButton btThoat;
    }
}