namespace CtyTinLuong
{
    partial class frmBTTL_PTH
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColSanLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLuongTrachNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColThucNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KyNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCongBaoHiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TruBaoHiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnPrintTQ = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions2.Image = global::CtyTinLuong.Properties.Resources.ico_Delete;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Tháng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "Năm:";
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(360, 12);
            this.txtThang.MaxLength = 2;
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(64, 20);
            this.txtThang.TabIndex = 1;
            this.txtThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThang_KeyPress);
            this.txtThang.Leave += new System.EventHandler(this.txtThang_Leave);
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(517, 12);
            this.txtNam.MaxLength = 4;
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(68, 20);
            this.txtNam.TabIndex = 2;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            this.txtNam.Leave += new System.EventHandler(this.txtNam_Leave);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSTT,
            this.clTenNhanVien,
            this.ColTenVTHH,
            this.DonGia,
            this.ColSanLuong,
            this.ColTongLuong,
            this.ColLuongTrachNhiem,
            this.ColTongTien,
            this.ColTamUng,
            this.ColThucNhan,
            this.KyNhan,
            this.ColCongBaoHiem,
            this.TruBaoHiem,
            this.gridColumn2});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1106, 496, 260, 232);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm mới tại đây";
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // clSTT
            // 
            this.clSTT.AppearanceCell.Options.UseTextOptions = true;
            this.clSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.clSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSTT.AppearanceHeader.Options.UseFont = true;
            this.clSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.clSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clSTT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.clSTT.Caption = "STT";
            this.clSTT.FieldName = "STT";
            this.clSTT.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clSTT.Name = "clSTT";
            this.clSTT.OptionsColumn.AllowEdit = false;
            this.clSTT.OptionsColumn.FixedWidth = true;
            this.clSTT.Visible = true;
            this.clSTT.VisibleIndex = 0;
            this.clSTT.Width = 30;
            // 
            // clTenNhanVien
            // 
            this.clTenNhanVien.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clTenNhanVien.AppearanceCell.Options.UseFont = true;
            this.clTenNhanVien.Caption = "HỌ TÊN";
            this.clTenNhanVien.ColumnEdit = this.repositoryItemMemoEdit3;
            this.clTenNhanVien.FieldName = "TenNhanVien";
            this.clTenNhanVien.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clTenNhanVien.Name = "clTenNhanVien";
            this.clTenNhanVien.OptionsColumn.AllowEdit = false;
            this.clTenNhanVien.Visible = true;
            this.clTenNhanVien.VisibleIndex = 1;
            this.clTenNhanVien.Width = 120;
            // 
            // ColTenVTHH
            // 
            this.ColTenVTHH.AppearanceCell.Options.UseTextOptions = true;
            this.ColTenVTHH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColTenVTHH.Caption = "CÔNG";
            this.ColTenVTHH.FieldName = "TenVTHH";
            this.ColTenVTHH.MinWidth = 50;
            this.ColTenVTHH.Name = "ColTenVTHH";
            this.ColTenVTHH.OptionsColumn.AllowEdit = false;
            this.ColTenVTHH.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColTenVTHH.Visible = true;
            this.ColTenVTHH.VisibleIndex = 2;
            this.ColTenVTHH.Width = 82;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DonGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DonGia.Caption = "LƯƠNG CƠ BẢN";
            this.DonGia.FieldName = "DonGia";
            this.DonGia.MinWidth = 50;
            this.DonGia.Name = "DonGia";
            this.DonGia.OptionsColumn.AllowEdit = false;
            this.DonGia.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsColumn.FixedWidth = true;
            this.DonGia.OptionsFilter.AllowAutoFilter = false;
            this.DonGia.OptionsFilter.AllowFilter = false;
            this.DonGia.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.DonGia.OptionsFilter.ShowEmptyDateFilter = false;
            // 
            // ColSanLuong
            // 
            this.ColSanLuong.AppearanceCell.Options.UseTextOptions = true;
            this.ColSanLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColSanLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColSanLuong.Caption = "NGÀY CÔNG";
            this.ColSanLuong.FieldName = "SanLuong";
            this.ColSanLuong.MinWidth = 50;
            this.ColSanLuong.Name = "ColSanLuong";
            this.ColSanLuong.OptionsColumn.AllowEdit = false;
            this.ColSanLuong.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsColumn.FixedWidth = true;
            this.ColSanLuong.OptionsFilter.AllowAutoFilter = false;
            this.ColSanLuong.OptionsFilter.AllowFilter = false;
            this.ColSanLuong.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ColSanLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ColSanLuong.OptionsFilter.ShowEmptyDateFilter = false;
            this.ColSanLuong.Visible = true;
            this.ColSanLuong.VisibleIndex = 3;
            this.ColSanLuong.Width = 70;
            // 
            // ColTongLuong
            // 
            this.ColTongLuong.AppearanceCell.Options.UseTextOptions = true;
            this.ColTongLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTongLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTongLuong.Caption = "TỔNG";
            this.ColTongLuong.FieldName = "TongLuong";
            this.ColTongLuong.MinWidth = 50;
            this.ColTongLuong.Name = "ColTongLuong";
            this.ColTongLuong.OptionsColumn.AllowEdit = false;
            this.ColTongLuong.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsColumn.FixedWidth = true;
            this.ColTongLuong.OptionsFilter.AllowAutoFilter = false;
            this.ColTongLuong.OptionsFilter.AllowFilter = false;
            this.ColTongLuong.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ColTongLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongLuong.OptionsFilter.ShowEmptyDateFilter = false;
            this.ColTongLuong.Visible = true;
            this.ColTongLuong.VisibleIndex = 4;
            this.ColTongLuong.Width = 82;
            // 
            // ColLuongTrachNhiem
            // 
            this.ColLuongTrachNhiem.AppearanceCell.Options.UseTextOptions = true;
            this.ColLuongTrachNhiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColLuongTrachNhiem.Caption = "L.TRÁCH NHIỆM";
            this.ColLuongTrachNhiem.FieldName = "LuongTrachNhiem";
            this.ColLuongTrachNhiem.MinWidth = 50;
            this.ColLuongTrachNhiem.Name = "ColLuongTrachNhiem";
            this.ColLuongTrachNhiem.OptionsColumn.AllowEdit = false;
            this.ColLuongTrachNhiem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColLuongTrachNhiem.Visible = true;
            this.ColLuongTrachNhiem.VisibleIndex = 6;
            this.ColLuongTrachNhiem.Width = 82;
            // 
            // ColTongTien
            // 
            this.ColTongTien.AppearanceCell.Options.UseTextOptions = true;
            this.ColTongTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTongTien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTongTien.Caption = "TỔNG LƯƠNG";
            this.ColTongTien.FieldName = "TongTien";
            this.ColTongTien.MinWidth = 50;
            this.ColTongTien.Name = "ColTongTien";
            this.ColTongTien.OptionsColumn.AllowEdit = false;
            this.ColTongTien.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsColumn.FixedWidth = true;
            this.ColTongTien.OptionsFilter.AllowAutoFilter = false;
            this.ColTongTien.OptionsFilter.AllowFilter = false;
            this.ColTongTien.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ColTongTien.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ColTongTien.OptionsFilter.ShowEmptyDateFilter = false;
            this.ColTongTien.Visible = true;
            this.ColTongTien.VisibleIndex = 7;
            this.ColTongTien.Width = 82;
            // 
            // ColTamUng
            // 
            this.ColTamUng.AppearanceCell.Options.UseTextOptions = true;
            this.ColTamUng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTamUng.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTamUng.Caption = "TẠM ỨNG";
            this.ColTamUng.FieldName = "TamUng";
            this.ColTamUng.MinWidth = 50;
            this.ColTamUng.Name = "ColTamUng";
            this.ColTamUng.OptionsColumn.AllowEdit = false;
            this.ColTamUng.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsColumn.FixedWidth = true;
            this.ColTamUng.OptionsFilter.AllowAutoFilter = false;
            this.ColTamUng.OptionsFilter.AllowFilter = false;
            this.ColTamUng.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ColTamUng.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ColTamUng.OptionsFilter.ShowEmptyDateFilter = false;
            this.ColTamUng.Visible = true;
            this.ColTamUng.VisibleIndex = 9;
            this.ColTamUng.Width = 82;
            // 
            // ColThucNhan
            // 
            this.ColThucNhan.AppearanceCell.Options.UseTextOptions = true;
            this.ColThucNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColThucNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColThucNhan.Caption = "THỰC LĨNH";
            this.ColThucNhan.FieldName = "ThucNhan";
            this.ColThucNhan.MinWidth = 50;
            this.ColThucNhan.Name = "ColThucNhan";
            this.ColThucNhan.OptionsColumn.AllowEdit = false;
            this.ColThucNhan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsColumn.FixedWidth = true;
            this.ColThucNhan.OptionsFilter.AllowAutoFilter = false;
            this.ColThucNhan.OptionsFilter.AllowFilter = false;
            this.ColThucNhan.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.ColThucNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.ColThucNhan.OptionsFilter.ShowEmptyDateFilter = false;
            this.ColThucNhan.Tag = "Thuc";
            this.ColThucNhan.Visible = true;
            this.ColThucNhan.VisibleIndex = 10;
            this.ColThucNhan.Width = 82;
            // 
            // KyNhan
            // 
            this.KyNhan.AppearanceCell.Options.UseTextOptions = true;
            this.KyNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KyNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.KyNhan.Caption = "KÝ NHẬN";
            this.KyNhan.FieldName = "KyNhan";
            this.KyNhan.MinWidth = 50;
            this.KyNhan.Name = "KyNhan";
            this.KyNhan.OptionsColumn.AllowEdit = false;
            this.KyNhan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsColumn.FixedWidth = true;
            this.KyNhan.OptionsFilter.AllowAutoFilter = false;
            this.KyNhan.OptionsFilter.AllowFilter = false;
            this.KyNhan.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.NotLike;
            this.KyNhan.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.KyNhan.OptionsFilter.ShowEmptyDateFilter = false;
            // 
            // ColCongBaoHiem
            // 
            this.ColCongBaoHiem.AppearanceCell.Options.UseTextOptions = true;
            this.ColCongBaoHiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColCongBaoHiem.Caption = "CỘNG BẢO HIỂM";
            this.ColCongBaoHiem.FieldName = "CongBaoHiem";
            this.ColCongBaoHiem.MinWidth = 50;
            this.ColCongBaoHiem.Name = "ColCongBaoHiem";
            this.ColCongBaoHiem.OptionsColumn.AllowEdit = false;
            this.ColCongBaoHiem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColCongBaoHiem.Visible = true;
            this.ColCongBaoHiem.VisibleIndex = 5;
            this.ColCongBaoHiem.Width = 82;
            // 
            // TruBaoHiem
            // 
            this.TruBaoHiem.AppearanceCell.Options.UseTextOptions = true;
            this.TruBaoHiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TruBaoHiem.Caption = "TRỪ BẢO HIỂM";
            this.TruBaoHiem.FieldName = "BaoHiem";
            this.TruBaoHiem.MinWidth = 50;
            this.TruBaoHiem.Name = "TruBaoHiem";
            this.TruBaoHiem.OptionsColumn.AllowEdit = false;
            this.TruBaoHiem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TruBaoHiem.Visible = true;
            this.TruBaoHiem.VisibleIndex = 8;
            this.TruBaoHiem.Width = 82;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(910, 538);
            this.gridControl1.TabIndex = 115;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // btnPrintTQ
            // 
            this.btnPrintTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTQ.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTQ.Appearance.Options.UseFont = true;
            this.btnPrintTQ.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrintTQ.Location = new System.Drawing.Point(742, 593);
            this.btnPrintTQ.Name = "btnPrintTQ";
            this.btnPrintTQ.Size = new System.Drawing.Size(82, 25);
            this.btnPrintTQ.TabIndex = 150;
            this.btnPrintTQ.Text = "Tổng quát";
            this.btnPrintTQ.Click += new System.EventHandler(this.btnPrintTQ_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrint.Location = new System.Drawing.Point(657, 593);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 25);
            this.btnPrint.TabIndex = 149;
            this.btnPrint.Text = "Chi tiết";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(827, 593);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(82, 25);
            this.btThoat.TabIndex = 147;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // frmBTTL_PTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.btnPrintTQ);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmBTTL_PTH";
            this.Size = new System.Drawing.Size(913, 635);
            this.Load += new System.EventHandler(this.frmBTTL_PTH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtNam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn clTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn ColSanLuong;
        private DevExpress.XtraGrid.Columns.GridColumn ColTongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn ColTongTien;
        private DevExpress.XtraGrid.Columns.GridColumn ColTamUng;
        private DevExpress.XtraGrid.Columns.GridColumn ColThucNhan;
        private DevExpress.XtraGrid.Columns.GridColumn KyNhan;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn ColLuongTrachNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn ColTenVTHH;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn ColCongBaoHiem;
        private DevExpress.XtraGrid.Columns.GridColumn TruBaoHiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnPrintTQ;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btThoat;
    }
}