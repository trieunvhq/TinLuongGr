namespace CtyTinLuong
{
    partial class Tr_frmBCNXT_MayIn
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
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVTHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TonDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Xuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Let = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnPrintTQ = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::CtyTinLuong.Properties.Resources.ico_Delete;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
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
            this.MaVT,
            this.TenVTHH,
            this.DonViTinh,
            this.TonDau,
            this.Nhap,
            this.Xuat,
            this.Ton,
            this.Let});
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
            // TenVTHH
            // 
            this.TenVTHH.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenVTHH.AppearanceCell.Options.UseFont = true;
            this.TenVTHH.Caption = "Tên hàng";
            this.TenVTHH.ColumnEdit = this.repositoryItemMemoEdit3;
            this.TenVTHH.FieldName = "TenVTHH";
            this.TenVTHH.Name = "TenVTHH";
            this.TenVTHH.OptionsColumn.AllowEdit = false;
            this.TenVTHH.Visible = true;
            this.TenVTHH.VisibleIndex = 2;
            this.TenVTHH.Width = 250;
            // 
            // DonViTinh
            // 
            this.DonViTinh.AppearanceCell.Options.UseTextOptions = true;
            this.DonViTinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DonViTinh.Caption = "ĐVT";
            this.DonViTinh.FieldName = "DonViTinh";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.OptionsColumn.AllowEdit = false;
            this.DonViTinh.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DonViTinh.Visible = true;
            this.DonViTinh.VisibleIndex = 3;
            this.DonViTinh.Width = 70;
            // 
            // MaVT
            // 
            this.MaVT.AppearanceCell.Options.UseTextOptions = true;
            this.MaVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MaVT.Caption = "Mã hàng";
            this.MaVT.FieldName = "MaVT";
            this.MaVT.MinWidth = 10;
            this.MaVT.Name = "MaVT";
            this.MaVT.OptionsColumn.AllowEdit = false;
            this.MaVT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsColumn.FixedWidth = true;
            this.MaVT.OptionsFilter.AllowAutoFilter = false;
            this.MaVT.OptionsFilter.AllowFilter = false;
            this.MaVT.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.MaVT.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.MaVT.OptionsFilter.ShowEmptyDateFilter = false;
            this.MaVT.Visible = true;
            this.MaVT.VisibleIndex = 1;
            this.MaVT.Width = 70;
            // 
            // TonDau
            // 
            this.TonDau.AppearanceCell.Options.UseTextOptions = true;
            this.TonDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TonDau.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TonDau.Caption = "Tồn đầu";
            this.TonDau.FieldName = "TonDau";
            this.TonDau.MinWidth = 10;
            this.TonDau.Name = "TonDau";
            this.TonDau.OptionsColumn.AllowEdit = false;
            this.TonDau.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsColumn.FixedWidth = true;
            this.TonDau.OptionsFilter.AllowAutoFilter = false;
            this.TonDau.OptionsFilter.AllowFilter = false;
            this.TonDau.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.TonDau.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.TonDau.OptionsFilter.ShowEmptyDateFilter = false;
            this.TonDau.Visible = true;
            this.TonDau.VisibleIndex = 4;
            this.TonDau.Width = 91;
            // 
            // Nhap
            // 
            this.Nhap.AppearanceCell.Options.UseTextOptions = true;
            this.Nhap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Nhap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Nhap.Caption = "Nhập";
            this.Nhap.FieldName = "Nhap";
            this.Nhap.MinWidth = 10;
            this.Nhap.Name = "Nhap";
            this.Nhap.OptionsColumn.AllowEdit = false;
            this.Nhap.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsColumn.FixedWidth = true;
            this.Nhap.OptionsFilter.AllowAutoFilter = false;
            this.Nhap.OptionsFilter.AllowFilter = false;
            this.Nhap.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.Nhap.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.Nhap.OptionsFilter.ShowEmptyDateFilter = false;
            this.Nhap.Visible = true;
            this.Nhap.VisibleIndex = 5;
            this.Nhap.Width = 91;
            // 
            // Xuat
            // 
            this.Xuat.AppearanceCell.Options.UseTextOptions = true;
            this.Xuat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Xuat.Caption = "Xuất";
            this.Xuat.FieldName = "Xuat";
            this.Xuat.Name = "Xuat";
            this.Xuat.OptionsColumn.AllowEdit = false;
            this.Xuat.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Xuat.Visible = true;
            this.Xuat.VisibleIndex = 6;
            this.Xuat.Width = 91;
            // 
            // Ton
            // 
            this.Ton.AppearanceCell.Options.UseTextOptions = true;
            this.Ton.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Ton.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Ton.Caption = "Tồn";
            this.Ton.FieldName = "Ton";
            this.Ton.MinWidth = 10;
            this.Ton.Name = "Ton";
            this.Ton.OptionsColumn.AllowEdit = false;
            this.Ton.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsColumn.FixedWidth = true;
            this.Ton.OptionsFilter.AllowAutoFilter = false;
            this.Ton.OptionsFilter.AllowFilter = false;
            this.Ton.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.Ton.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.Ton.OptionsFilter.ShowEmptyDateFilter = false;
            this.Ton.Visible = true;
            this.Ton.VisibleIndex = 7;
            this.Ton.Width = 91;
            // 
            // Let
            // 
            this.Let.AppearanceCell.Options.UseTextOptions = true;
            this.Let.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Let.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Let.Caption = "Lết";
            this.Let.FieldName = "Let";
            this.Let.MinWidth = 10;
            this.Let.Name = "Let";
            this.Let.OptionsColumn.AllowEdit = false;
            this.Let.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsColumn.FixedWidth = true;
            this.Let.OptionsFilter.AllowAutoFilter = false;
            this.Let.OptionsFilter.AllowFilter = false;
            this.Let.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.Let.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.ImmediateUpdatePopupExcelFilter = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.Let.OptionsFilter.ShowEmptyDateFilter = false;
            this.Let.Visible = true;
            this.Let.VisibleIndex = 8;
            this.Let.Width = 91;
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
            // btnPrintTQ
            // 
            this.btnPrintTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTQ.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTQ.Appearance.Options.UseFont = true;
            this.btnPrintTQ.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrintTQ.Location = new System.Drawing.Point(741, 592);
            this.btnPrintTQ.Name = "btnPrintTQ";
            this.btnPrintTQ.Size = new System.Drawing.Size(82, 25);
            this.btnPrintTQ.TabIndex = 149;
            this.btnPrintTQ.Text = "Tổng quát";
            this.btnPrintTQ.Click += new System.EventHandler(this.btnPrintTQ_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Print;
            this.btnPrint.Location = new System.Drawing.Point(656, 592);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 25);
            this.btnPrint.TabIndex = 148;
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
            this.btThoat.Location = new System.Drawing.Point(826, 592);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(82, 25);
            this.btThoat.TabIndex = 146;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(519, 12);
            this.txtNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(70, 20);
            this.txtNam.TabIndex = 170;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.txtNam.Leave += new System.EventHandler(this.txtNam_Leave);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(361, 12);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(66, 20);
            this.txtThang.TabIndex = 169;
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Leave += new System.EventHandler(this.txtThang_Leave);
            // 
            // Tr_frmBCNXT_MayIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.btnPrintTQ);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridControl1);
            this.Name = "Tr_frmBCNXT_MayIn";
            this.Size = new System.Drawing.Size(913, 635);
            this.Load += new System.EventHandler(this.Tr_frmBCNXT_MayIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSTT;
        private DevExpress.XtraGrid.Columns.GridColumn TenVTHH;
        private DevExpress.XtraGrid.Columns.GridColumn MaVT;
        private DevExpress.XtraGrid.Columns.GridColumn TonDau;
        private DevExpress.XtraGrid.Columns.GridColumn Nhap;
        private DevExpress.XtraGrid.Columns.GridColumn Ton;
        private DevExpress.XtraGrid.Columns.GridColumn Let;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Xuat;
        private DevExpress.XtraGrid.Columns.GridColumn DonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.SimpleButton btnPrintTQ;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.NumericUpDown txtNam;
        private System.Windows.Forms.NumericUpDown txtThang;
    }
}