namespace CtyTinLuong
{
    partial class Tr_frmChiTietChamCong_PhienDich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tr_frmChiTietChamCong_PhienDich));
            this.btLUU = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSoCont = new System.Windows.Forms.TextBox();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSoToKhai = new System.Windows.Forms.TextBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookMaDML = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtNgay = new System.Windows.Forms.NumericUpDown();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookMaDML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // btLUU
            // 
            this.btLUU.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLUU.Location = new System.Drawing.Point(501, 211);
            this.btLUU.Name = "btLUU";
            this.btLUU.Size = new System.Drawing.Size(108, 23);
            this.btLUU.TabIndex = 67;
            this.btLUU.Text = "Lưu và đóng";
            this.btLUU.Click += new System.EventHandler(this.btLUU_Click);
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(616, 211);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 66;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem7,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(674, 133);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtSoCont;
            this.layoutControlItem18.CustomizationFormText = "Số cont";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(674, 36);
            this.layoutControlItem18.Text = "Số cont";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(68, 13);
            // 
            // txtSoCont
            // 
            this.txtSoCont.Location = new System.Drawing.Point(73, 99);
            this.txtSoCont.Name = "txtSoCont";
            this.txtSoCont.Size = new System.Drawing.Size(599, 20);
            this.txtSoCont.TabIndex = 25;
            this.txtSoCont.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhuCapXang_KeyPress);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtSoToKhai;
            this.layoutControlItem7.CustomizationFormText = "Lương cố định (*)";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem7.Text = "Số tờ khai";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(68, 13);
            // 
            // txtSoToKhai
            // 
            this.txtSoToKhai.Location = new System.Drawing.Point(73, 75);
            this.txtSoToKhai.Name = "txtSoToKhai";
            this.txtSoToKhai.Size = new System.Drawing.Size(599, 20);
            this.txtSoToKhai.TabIndex = 30;
            this.txtSoToKhai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLuongCoDinh_KeyPress);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbKhachHang);
            this.layoutControl1.Controls.Add(this.txtNgay);
            this.layoutControl1.Controls.Add(this.searchLookMaDML);
            this.layoutControl1.Controls.Add(this.txtTenNhanVien);
            this.layoutControl1.Controls.Add(this.txtSoToKhai);
            this.layoutControl1.Controls.Add(this.txtSoCont);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(777, 87, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(674, 133);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // searchLookMaDML
            // 
            this.searchLookMaDML.EditValue = "";
            this.searchLookMaDML.Location = new System.Drawing.Point(73, 2);
            this.searchLookMaDML.Name = "searchLookMaDML";
            this.searchLookMaDML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.searchLookMaDML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookMaDML.Properties.NullText = "";
            this.searchLookMaDML.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookMaDML.Size = new System.Drawing.Size(261, 20);
            this.searchLookMaDML.StyleController = this.layoutControl1;
            this.searchLookMaDML.TabIndex = 38;
            this.searchLookMaDML.EditValueChanged += new System.EventHandler(this.searchLookMaDML_EditValueChanged);
            this.searchLookMaDML.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.searchLookMaDML_CustomDisplayText);
            this.searchLookMaDML.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchLookMaDML_KeyPress);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(409, 2);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(263, 20);
            this.txtTenNhanVien.TabIndex = 37;
            this.txtTenNhanVien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNhanVien_KeyPress);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.txtTenNhanVien;
            this.layoutControlItem26.Location = new System.Drawing.Point(336, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(338, 24);
            this.layoutControlItem26.Text = "Tên nhân viên";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.searchLookMaDML;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(336, 24);
            this.layoutControlItem27.Text = "Mã công nhân";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(68, 13);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(16, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 152);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Copy;
            this.simpleButton1.Location = new System.Drawing.Point(379, 211);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 23);
            this.simpleButton1.TabIndex = 70;
            this.simpleButton1.Text = "Copy tạo mới";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtNgay
            // 
            this.txtNgay.Location = new System.Drawing.Point(73, 26);
            this.txtNgay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtNgay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(599, 20);
            this.txtNgay.TabIndex = 39;
            this.txtNgay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNgay;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem1.Text = "Ngày";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(73, 50);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(599, 21);
            this.cbKhachHang.TabIndex = 40;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbKhachHang;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(674, 25);
            this.layoutControlItem2.Text = "Khách hàng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // Tr_frmChiTietChamCong_PhienDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 242);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btLUU);
            this.Controls.Add(this.btThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Tr_frmChiTietChamCong_PhienDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tr_frmChiTietChamCong_PhienDich-->Chi tiết chấm công phiên dịch";
            this.Load += new System.EventHandler(this.Tr_frmChiTietChamCong_PhienDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookMaDML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btLUU;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private System.Windows.Forms.TextBox txtSoCont;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.TextBox txtSoToKhai;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookMaDML;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.NumericUpDown txtNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}