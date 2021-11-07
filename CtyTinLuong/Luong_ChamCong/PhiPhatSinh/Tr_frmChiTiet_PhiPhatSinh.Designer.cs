namespace CtyTinLuong
{
    partial class Tr_frmChiTiet_PhiPhatSinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tr_frmChiTiet_PhiPhatSinh));
            this.btLUU = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTienTru = new System.Windows.Forms.TextBox();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookBoPhan = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radioCa2 = new System.Windows.Forms.RadioButton();
            this.radioCa1 = new System.Windows.Forms.RadioButton();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.txtTenPhi = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookBoPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLUU
            // 
            this.btLUU.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Save;
            this.btLUU.Location = new System.Drawing.Point(501, 310);
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
            this.btThoat.Location = new System.Drawing.Point(616, 310);
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
            this.layoutControlItem27,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(674, 266);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtTienTru;
            this.layoutControlItem18.CustomizationFormText = "Số cont";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem18.Text = "Tiền trừ";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(46, 13);
            // 
            // txtTienTru
            // 
            this.txtTienTru.Location = new System.Drawing.Point(51, 50);
            this.txtTienTru.Name = "txtTienTru";
            this.txtTienTru.Size = new System.Drawing.Size(621, 20);
            this.txtTienTru.TabIndex = 25;
            this.txtTienTru.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoCont_KeyPress);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtTienCong;
            this.layoutControlItem7.CustomizationFormText = "Lương cố định (*)";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem7.Text = "Tiền cộng";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(46, 13);
            // 
            // txtTienCong
            // 
            this.txtTienCong.Location = new System.Drawing.Point(51, 26);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(621, 20);
            this.txtTienCong.TabIndex = 30;
            this.txtTienCong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoToKhai_KeyPress);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.searchLookBoPhan;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem27.Text = "Bộ phận";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(46, 13);
            // 
            // searchLookBoPhan
            // 
            this.searchLookBoPhan.EditValue = "";
            this.searchLookBoPhan.Location = new System.Drawing.Point(51, 2);
            this.searchLookBoPhan.Name = "searchLookBoPhan";
            this.searchLookBoPhan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.searchLookBoPhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookBoPhan.Properties.NullText = "";
            this.searchLookBoPhan.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookBoPhan.Size = new System.Drawing.Size(621, 20);
            this.searchLookBoPhan.StyleController = this.layoutControl1;
            this.searchLookBoPhan.TabIndex = 38;
            this.searchLookBoPhan.EditValueChanged += new System.EventHandler(this.searchLookMaDML_EditValueChanged);
            this.searchLookBoPhan.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.searchLookMaDML_CustomDisplayText);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.radioCa2);
            this.layoutControl1.Controls.Add(this.radioCa1);
            this.layoutControl1.Controls.Add(this.txtDienGiai);
            this.layoutControl1.Controls.Add(this.txtTenPhi);
            this.layoutControl1.Controls.Add(this.searchLookBoPhan);
            this.layoutControl1.Controls.Add(this.txtTienCong);
            this.layoutControl1.Controls.Add(this.txtTienTru);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(777, 87, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(674, 266);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // radioCa2
            // 
            this.radioCa2.Location = new System.Drawing.Point(53, 239);
            this.radioCa2.Name = "radioCa2";
            this.radioCa2.Size = new System.Drawing.Size(619, 25);
            this.radioCa2.TabIndex = 42;
            this.radioCa2.TabStop = true;
            this.radioCa2.Text = "Tổ 2";
            this.radioCa2.UseVisualStyleBackColor = true;
            // 
            // radioCa1
            // 
            this.radioCa1.Location = new System.Drawing.Point(2, 239);
            this.radioCa1.Name = "radioCa1";
            this.radioCa1.Size = new System.Drawing.Size(47, 25);
            this.radioCa1.TabIndex = 41;
            this.radioCa1.TabStop = true;
            this.radioCa1.Text = "Tổ 1";
            this.radioCa1.UseVisualStyleBackColor = true;
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(51, 98);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(621, 137);
            this.txtDienGiai.TabIndex = 40;
            // 
            // txtTenPhi
            // 
            this.txtTenPhi.Location = new System.Drawing.Point(51, 74);
            this.txtTenPhi.Name = "txtTenPhi";
            this.txtTenPhi.Size = new System.Drawing.Size(621, 20);
            this.txtTenPhi.TabIndex = 39;
            this.txtTenPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenPhi_KeyPress);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtTenPhi;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem1.Text = "Tên phí";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDienGiai;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(674, 141);
            this.layoutControlItem2.Text = "Diễn giải";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.radioCa1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 237);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(51, 29);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.radioCa2;
            this.layoutControlItem4.Location = new System.Drawing.Point(51, 237);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(623, 29);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 285);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Copy;
            this.simpleButton1.Location = new System.Drawing.Point(379, 310);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 23);
            this.simpleButton1.TabIndex = 70;
            this.simpleButton1.Text = "Copy tạo mới";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Tr_frmChiTiet_PhiPhatSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 345);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btLUU);
            this.Controls.Add(this.btThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Tr_frmChiTiet_PhiPhatSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tr_frmChiTiet_PhiPhatSinh-->Chi tiết phí phát sinh";
            this.Load += new System.EventHandler(this.Tr_frmChiTiet_PhiPhatSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookBoPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btLUU;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private System.Windows.Forms.TextBox txtTienTru;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.TextBox txtTienCong;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private System.Windows.Forms.TextBox txtTenPhi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.TextBox txtDienGiai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.RadioButton radioCa2;
        private System.Windows.Forms.RadioButton radioCa1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}