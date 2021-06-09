namespace CtyTinLuong
{
    partial class frmPrint_NguoiKy
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
            this.components = new System.ComponentModel.Container();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMaNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_NhanSu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clID_DangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoTenNV = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(544, 360);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(56, 22);
            this.btThoat.StyleController = this.layoutControl1;
            this.btThoat.TabIndex = 73;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.btLuu);
            this.layoutControl1.Controls.Add(this.btThoat);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 13);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(604, 386);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btLuu
            // 
            this.btLuu.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLuu.Location = new System.Drawing.Point(463, 360);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(77, 22);
            this.btLuu.StyleController = this.layoutControl1;
            this.btLuu.TabIndex = 78;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(4, 4);
            this.gridControl1.MainView = this.gridView13;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridMaNhanVien,
            this.memoTenNV});
            this.gridControl1.Size = new System.Drawing.Size(596, 352);
            this.gridControl1.TabIndex = 27;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView13});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView13
            // 
            this.gridView13.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView13.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView13.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView13.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView13.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView13.Appearance.Row.Options.UseTextOptions = true;
            this.gridView13.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView13.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView13.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clChucVu,
            this.clHoTen,
            this.clMaNhanVien,
            this.clID,
            this.clID_NhanSu,
            this.clID_DangNhap,
            this.clHienThi});
            this.gridView13.GridControl = this.gridControl1;
            this.gridView13.Name = "gridView13";
            this.gridView13.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView13.OptionsView.RowAutoHeight = true;
            this.gridView13.OptionsView.ShowFooter = true;
            this.gridView13.OptionsView.ShowGroupPanel = false;
            this.gridView13.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView13_CustomDrawCell);
            this.gridView13.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView13_CellValueChanged);
            // 
            // clSTT
            // 
            this.clSTT.Caption = "STT";
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 35;
            // 
            // clChucVu
            // 
            this.clChucVu.AppearanceCell.Options.UseTextOptions = true;
            this.clChucVu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clChucVu.Caption = "Chức vụ";
            this.clChucVu.FieldName = "ChucVu";
            this.clChucVu.Name = "clChucVu";
            this.clChucVu.OptionsColumn.AllowEdit = false;
            this.clChucVu.Visible = true;
            this.clChucVu.VisibleIndex = 2;
            this.clChucVu.Width = 153;
            // 
            // clHoTen
            // 
            this.clHoTen.AppearanceCell.Options.UseTextOptions = true;
            this.clHoTen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.clHoTen.Caption = "Họ tên";
            this.clHoTen.FieldName = "HoTen";
            this.clHoTen.Name = "clHoTen";
            this.clHoTen.Visible = true;
            this.clHoTen.VisibleIndex = 3;
            this.clHoTen.Width = 191;
            // 
            // clMaNhanVien
            // 
            this.clMaNhanVien.Caption = "Mã NV";
            this.clMaNhanVien.ColumnEdit = this.gridMaNhanVien;
            this.clMaNhanVien.FieldName = "MaNhanVien";
            this.clMaNhanVien.Name = "clMaNhanVien";
            this.clMaNhanVien.Visible = true;
            this.clMaNhanVien.VisibleIndex = 1;
            this.clMaNhanVien.Width = 88;
            // 
            // gridMaNhanVien
            // 
            this.gridMaNhanVien.AutoHeight = false;
            this.gridMaNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridMaNhanVien.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID_NhanSu", "ID_NhanSu", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNhanVien", "Mã NV", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhanVien", "Họ tên", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.gridMaNhanVien.Name = "gridMaNhanVien";
            // 
            // clID
            // 
            this.clID.Caption = "ID";
            this.clID.FieldName = "ID";
            this.clID.Name = "clID";
            this.clID.OptionsColumn.AllowEdit = false;
            this.clID.Width = 116;
            // 
            // clID_NhanSu
            // 
            this.clID_NhanSu.Caption = "ID_NhanSu";
            this.clID_NhanSu.FieldName = "ID_NhanSu";
            this.clID_NhanSu.Name = "clID_NhanSu";
            this.clID_NhanSu.Width = 76;
            // 
            // clID_DangNhap
            // 
            this.clID_DangNhap.Caption = "ID_DangNhap";
            this.clID_DangNhap.FieldName = "ID_DangNhap";
            this.clID_DangNhap.Name = "clID_DangNhap";
            // 
            // memoTenNV
            // 
            this.memoTenNV.Name = "memoTenNV";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(604, 386);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(600, 356);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(540, 356);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(60, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(229, 356);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(230, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btLuu;
            this.layoutControlItem1.Location = new System.Drawing.Point(459, 356);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(604, 399);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            // 
            // clHienThi
            // 
            this.clHienThi.Caption = "HienThi";
            this.clHienThi.FieldName = "HienThi";
            this.clHienThi.Name = "clHienThi";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 22);
            this.label1.TabIndex = 79;
            this.label1.Text = "Có thể gõ trực tiếp họ tên";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.label1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 356);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(229, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmPrint_NguoiKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btThoat;
            this.ClientSize = new System.Drawing.Size(604, 399);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrint_NguoiKy";
            this.Text = "Cài đặt mặc định người ký";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrint_NguoiKy_FormClosed);
            this.Load += new System.EventHandler(this.frmPrint_NguoiKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoTenNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn clHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn clMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn clID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridMaNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memoTenNV;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn clID_NhanSu;
        private DevExpress.XtraGrid.Columns.GridColumn clID_DangNhap;
        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn clHienThi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}