﻿namespace CtyTinLuong
{
    partial class frmBTTL_TrgCa_CT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBTTL_TrgCa_CT));
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.btGuiDuLieu = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheDoHienThi = new System.Windows.Forms.Button();
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
            // btGuiDuLieu
            // 
            this.btGuiDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGuiDuLieu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuiDuLieu.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btGuiDuLieu.Appearance.Options.UseFont = true;
            this.btGuiDuLieu.Appearance.Options.UseForeColor = true;
            this.btGuiDuLieu.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Forward;
            this.btGuiDuLieu.Location = new System.Drawing.Point(563, 590);
            this.btGuiDuLieu.Name = "btGuiDuLieu";
            this.btGuiDuLieu.Size = new System.Drawing.Size(173, 31);
            this.btGuiDuLieu.TabIndex = 118;
            this.btGuiDuLieu.Text = "Gửi dữ liệu bảng lương ";
            this.btGuiDuLieu.Click += new System.EventHandler(this.btGuiDuLieu_Click);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::CtyTinLuong.Properties.Resources.ico_Delete;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.Appearance.Options.UseForeColor = true;
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(826, 590);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 31);
            this.btThoat.TabIndex = 116;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(24, 590);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(149, 13);
            this.linkLabel1.TabIndex = 123;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cài định mức  toàn danh sách";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.KyNhan});
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
            this.ColTenVTHH.Caption = "CÔNG";
            this.ColTenVTHH.FieldName = "TenVTHH";
            this.ColTenVTHH.Name = "ColTenVTHH";
            this.ColTenVTHH.OptionsColumn.AllowEdit = false;
            this.ColTenVTHH.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColTenVTHH.Visible = true;
            this.ColTenVTHH.VisibleIndex = 2;
            this.ColTenVTHH.Width = 69;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DonGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DonGia.Caption = "LƯƠNG CƠ BẢN";
            this.DonGia.FieldName = "DonGia";
            this.DonGia.MinWidth = 10;
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
            this.DonGia.Width = 80;
            // 
            // ColSanLuong
            // 
            this.ColSanLuong.AppearanceCell.Options.UseTextOptions = true;
            this.ColSanLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColSanLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColSanLuong.Caption = "NGÀY CÔNG";
            this.ColSanLuong.FieldName = "SanLuong";
            this.ColSanLuong.MinWidth = 10;
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
            this.ColSanLuong.Width = 80;
            // 
            // ColTongLuong
            // 
            this.ColTongLuong.AppearanceCell.Options.UseTextOptions = true;
            this.ColTongLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTongLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTongLuong.Caption = "TỔNG";
            this.ColTongLuong.FieldName = "TongLuong";
            this.ColTongLuong.MaxWidth = 100;
            this.ColTongLuong.MinWidth = 100;
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
            this.ColTongLuong.Width = 93;
            // 
            // ColLuongTrachNhiem
            // 
            this.ColLuongTrachNhiem.AppearanceCell.Options.UseTextOptions = true;
            this.ColLuongTrachNhiem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColLuongTrachNhiem.Caption = "L.TRÁCH NHIỆM";
            this.ColLuongTrachNhiem.FieldName = "LuongTrachNhiem";
            this.ColLuongTrachNhiem.MaxWidth = 100;
            this.ColLuongTrachNhiem.MinWidth = 100;
            this.ColLuongTrachNhiem.Name = "ColLuongTrachNhiem";
            this.ColLuongTrachNhiem.OptionsColumn.AllowEdit = false;
            this.ColLuongTrachNhiem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColLuongTrachNhiem.Visible = true;
            this.ColLuongTrachNhiem.VisibleIndex = 5;
            this.ColLuongTrachNhiem.Width = 100;
            // 
            // ColTongTien
            // 
            this.ColTongTien.AppearanceCell.Options.UseTextOptions = true;
            this.ColTongTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTongTien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTongTien.Caption = "TỔNG";
            this.ColTongTien.FieldName = "TongTien";
            this.ColTongTien.MaxWidth = 100;
            this.ColTongTien.MinWidth = 100;
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
            this.ColTongTien.VisibleIndex = 6;
            this.ColTongTien.Width = 93;
            // 
            // ColTamUng
            // 
            this.ColTamUng.AppearanceCell.Options.UseTextOptions = true;
            this.ColTamUng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColTamUng.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColTamUng.Caption = "TẠM ỨNG";
            this.ColTamUng.FieldName = "TamUng";
            this.ColTamUng.MaxWidth = 100;
            this.ColTamUng.MinWidth = 100;
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
            this.ColTamUng.VisibleIndex = 7;
            this.ColTamUng.Width = 92;
            // 
            // ColThucNhan
            // 
            this.ColThucNhan.AppearanceCell.Options.UseTextOptions = true;
            this.ColThucNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ColThucNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ColThucNhan.Caption = "THỰC LĨNH";
            this.ColThucNhan.FieldName = "ThucNhan";
            this.ColThucNhan.MaxWidth = 100;
            this.ColThucNhan.MinWidth = 100;
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
            this.ColThucNhan.VisibleIndex = 8;
            this.ColThucNhan.Width = 99;
            // 
            // KyNhan
            // 
            this.KyNhan.AppearanceCell.Options.UseTextOptions = true;
            this.KyNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KyNhan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.KyNhan.Caption = "KÝ NHẬN";
            this.KyNhan.FieldName = "KyNhan";
            this.KyNhan.MinWidth = 10;
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
            this.KyNhan.Visible = true;
            this.KyNhan.VisibleIndex = 9;
            this.KyNhan.Width = 88;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 39);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(908, 538);
            this.gridControl1.TabIndex = 115;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.Location = new System.Drawing.Point(742, 590);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 31);
            this.btnPrint.TabIndex = 140;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 590);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 145;
            this.label2.Text = "Double click để sửa định mức";
            // 
            // btnCheDoHienThi
            // 
            this.btnCheDoHienThi.Location = new System.Drawing.Point(742, 9);
            this.btnCheDoHienThi.Name = "btnCheDoHienThi";
            this.btnCheDoHienThi.Size = new System.Drawing.Size(168, 23);
            this.btnCheDoHienThi.TabIndex = 146;
            this.btnCheDoHienThi.Text = "Thay đổi chế độ hiển thị";
            this.btnCheDoHienThi.UseVisualStyleBackColor = true;
            this.btnCheDoHienThi.Click += new System.EventHandler(this.btnCheDoHienThi_Click);
            // 
            // frmBTTL_TrgCa_CT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.btnCheDoHienThi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btGuiDuLieu);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmBTTL_TrgCa_CT";
            this.Size = new System.Drawing.Size(913, 635);
            this.Load += new System.EventHandler(this.frmBTTL_TrgCa_CT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btGuiDuLieu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.LinkLabel linkLabel1;
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
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private System.Windows.Forms.Button btnCheDoHienThi;
    }
}