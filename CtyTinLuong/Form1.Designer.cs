namespace CtyTinLuong
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.gridTK_me = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clID_TaiKhoanKeToanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTenTaiKhoanMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDienGiaiMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTenTKMe = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTK_me.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Tai khoan ke toan Me";
            // 
            // gridTK_me
            // 
            this.gridTK_me.Location = new System.Drawing.Point(181, 12);
            this.gridTK_me.Name = "gridTK_me";
            this.gridTK_me.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridTK_me.Properties.View = this.gridView8;
            this.gridTK_me.Size = new System.Drawing.Size(362, 20);
            this.gridTK_me.TabIndex = 83;
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
            // txtTenTKMe
            // 
            this.txtTenTKMe.Location = new System.Drawing.Point(181, 49);
            this.txtTenTKMe.Name = "txtTenTKMe";
            this.txtTenTKMe.Size = new System.Drawing.Size(362, 20);
            this.txtTenTKMe.TabIndex = 84;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 458);
            this.Controls.Add(this.txtTenTKMe);
            this.Controls.Add(this.gridTK_me);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTK_me.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GridLookUpEdit gridTK_me;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn clID_TaiKhoanKeToanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clSoTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clTenTaiKhoanMe;
        private DevExpress.XtraGrid.Columns.GridColumn clDienGiaiMe;
        private System.Windows.Forms.TextBox txtTenTKMe;
    }
}