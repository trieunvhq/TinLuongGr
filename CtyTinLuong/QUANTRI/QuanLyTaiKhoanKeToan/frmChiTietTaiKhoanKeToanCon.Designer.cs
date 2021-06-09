namespace CtyTinLuong
{
    partial class frmChiTietTaiKhoanKeToanCon
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
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtTenTKMe = new System.Windows.Forms.TextBox();
            this.gridTK_me = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDienGiaiMe = new System.Windows.Forms.TextBox();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtSoTKCon = new System.Windows.Forms.TextBox();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDienGiaiCon = new System.Windows.Forms.TextBox();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtGhiChuCon = new System.Windows.Forms.TextBox();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.clID_TaiKhoanKeToanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDienGiaiMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTenTKCon = new System.Windows.Forms.TextBox();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkNgungTheoDoi = new System.Windows.Forms.CheckBox();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTK_me.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // btLuu
            // 
            this.btLuu.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLuu.Location = new System.Drawing.Point(395, 344);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 4;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(476, 344);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataLayoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(538, 311);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.checkNgungTheoDoi);
            this.dataLayoutControl1.Controls.Add(this.txtTenTKCon);
            this.dataLayoutControl1.Controls.Add(this.txtGhiChuCon);
            this.dataLayoutControl1.Controls.Add(this.txtDienGiaiCon);
            this.dataLayoutControl1.Controls.Add(this.txtSoTKCon);
            this.dataLayoutControl1.Controls.Add(this.txtDienGiaiMe);
            this.dataLayoutControl1.Controls.Add(this.txtTenTKMe);
            this.dataLayoutControl1.Controls.Add(this.gridTK_me);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 13);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(538, 298);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(538, 298);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtTenTKMe
            // 
            this.txtTenTKMe.Location = new System.Drawing.Point(81, 26);
            this.txtTenTKMe.Name = "txtTenTKMe";
            this.txtTenTKMe.ReadOnly = true;
            this.txtTenTKMe.Size = new System.Drawing.Size(455, 20);
            this.txtTenTKMe.TabIndex = 86;
            // 
            // gridTK_me
            // 
            this.gridTK_me.Location = new System.Drawing.Point(81, 2);
            this.gridTK_me.Name = "gridTK_me";
            this.gridTK_me.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridTK_me.Properties.View = this.gridView8;
            this.gridTK_me.Size = new System.Drawing.Size(186, 20);
            this.gridTK_me.StyleController = this.dataLayoutControl1;
            this.gridTK_me.TabIndex = 85;
            this.gridTK_me.EditValueChanged += new System.EventHandler(this.gridTK_me_EditValueChanged);
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clID_TaiKhoanKeToanMe,
            this.clSoTaiKhoanMe,
            this.clTenTaiKhoanMe,
            this.clDienGiaiMe});
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridTK_me;
            this.layoutControlItem1.CustomizationFormText = "TK Kế toán mẹ";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(269, 24);
            this.layoutControlItem1.Text = "TK Kế toán mẹ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenTKMe;
            this.layoutControlItem2.CustomizationFormText = "Tên TK Mẹ";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem2.Text = "Tên TK Mẹ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // txtDienGiaiMe
            // 
            this.txtDienGiaiMe.Location = new System.Drawing.Point(81, 50);
            this.txtDienGiaiMe.Multiline = true;
            this.txtDienGiaiMe.Name = "txtDienGiaiMe";
            this.txtDienGiaiMe.ReadOnly = true;
            this.txtDienGiaiMe.Size = new System.Drawing.Size(455, 45);
            this.txtDienGiaiMe.TabIndex = 87;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDienGiaiMe;
            this.layoutControlItem3.CustomizationFormText = "Diễn giải TK Me";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(538, 49);
            this.layoutControlItem3.Text = "Diễn giải TK Me";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(269, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(269, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtSoTKCon
            // 
            this.txtSoTKCon.Location = new System.Drawing.Point(81, 99);
            this.txtSoTKCon.Name = "txtSoTKCon";
            this.txtSoTKCon.Size = new System.Drawing.Size(455, 20);
            this.txtSoTKCon.TabIndex = 88;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSoTKCon;
            this.layoutControlItem4.CustomizationFormText = "Số TK Con";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem4.Text = "Số TK Con";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 13);
            // 
            // txtDienGiaiCon
            // 
            this.txtDienGiaiCon.Location = new System.Drawing.Point(81, 147);
            this.txtDienGiaiCon.Multiline = true;
            this.txtDienGiaiCon.Name = "txtDienGiaiCon";
            this.txtDienGiaiCon.Size = new System.Drawing.Size(455, 59);
            this.txtDienGiaiCon.TabIndex = 90;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDienGiaiCon;
            this.layoutControlItem6.CustomizationFormText = "Diễn giải TK con";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 145);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(538, 63);
            this.layoutControlItem6.Text = "Diễn giải TK con";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(75, 13);
            // 
            // txtGhiChuCon
            // 
            this.txtGhiChuCon.Location = new System.Drawing.Point(81, 210);
            this.txtGhiChuCon.Multiline = true;
            this.txtGhiChuCon.Name = "txtGhiChuCon";
            this.txtGhiChuCon.Size = new System.Drawing.Size(455, 62);
            this.txtGhiChuCon.TabIndex = 91;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtGhiChuCon;
            this.layoutControlItem7.CustomizationFormText = "Ghi chú TK Con";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 208);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(538, 66);
            this.layoutControlItem7.Text = "Ghi chú TK Con";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(75, 13);
            // 
            // clID_TaiKhoanKeToanMe
            // 
            this.clID_TaiKhoanKeToanMe.Caption = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.FieldName = "ID_TaiKhoanKeToanMe";
            this.clID_TaiKhoanKeToanMe.Name = "clID_TaiKhoanKeToanMe";
            // 
            // clSoTaiKhoanMe
            // 
            this.clSoTaiKhoanMe.Caption = "TK";
            this.clSoTaiKhoanMe.FieldName = "SoTaiKhoanMe";
            this.clSoTaiKhoanMe.Name = "clSoTaiKhoanMe";
            this.clSoTaiKhoanMe.Visible = true;
            this.clSoTaiKhoanMe.VisibleIndex = 0;
            this.clSoTaiKhoanMe.Width = 80;
            // 
            // clTenTaiKhoanMe
            // 
            this.clTenTaiKhoanMe.Caption = "Tên TK";
            this.clTenTaiKhoanMe.FieldName = "TenTaiKhoanMe";
            this.clTenTaiKhoanMe.Name = "clTenTaiKhoanMe";
            this.clTenTaiKhoanMe.Visible = true;
            this.clTenTaiKhoanMe.VisibleIndex = 1;
            this.clTenTaiKhoanMe.Width = 304;
            // 
            // clDienGiaiMe
            // 
            this.clDienGiaiMe.Caption = "Diễn giải";
            this.clDienGiaiMe.FieldName = "DienGiaiMe";
            this.clDienGiaiMe.Name = "clDienGiaiMe";
            this.clDienGiaiMe.Width = 60;
            // 
            // txtTenTKCon
            // 
            this.txtTenTKCon.Location = new System.Drawing.Point(81, 123);
            this.txtTenTKCon.Name = "txtTenTKCon";
            this.txtTenTKCon.Size = new System.Drawing.Size(455, 20);
            this.txtTenTKCon.TabIndex = 92;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtTenTKCon;
            this.layoutControlItem5.CustomizationFormText = "Tên TK Con";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem5.Text = "Tên TK Con";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(75, 13);
            // 
            // checkNgungTheoDoi
            // 
            this.checkNgungTheoDoi.Location = new System.Drawing.Point(2, 276);
            this.checkNgungTheoDoi.Name = "checkNgungTheoDoi";
            this.checkNgungTheoDoi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkNgungTheoDoi.Size = new System.Drawing.Size(534, 20);
            this.checkNgungTheoDoi.TabIndex = 93;
            this.checkNgungTheoDoi.Text = "Ngừng theo dõi";
            this.checkNgungTheoDoi.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkNgungTheoDoi;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 274);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(538, 24);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // frmChiTietTaiKhoanKeToanCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietTaiKhoanKeToanCon";
            this.Text = "Chi tiết Tài khoản Con";
            this.Load += new System.EventHandler(this.frmChiTietTaiKhoanKeToanCon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTK_me.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.TextBox txtGhiChuCon;
        private System.Windows.Forms.TextBox txtDienGiaiCon;
        private System.Windows.Forms.TextBox txtSoTKCon;
        private System.Windows.Forms.TextBox txtDienGiaiMe;
        private System.Windows.Forms.TextBox txtTenTKMe;
        private DevExpress.XtraEditors.GridLookUpEdit gridTK_me;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clDienGiaiMe;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.TextBox txtTenTKCon;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.CheckBox checkNgungTheoDoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}