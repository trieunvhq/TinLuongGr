namespace CtyTinLuong
{
    partial class DaiLy_ChiTietChoXuatKho_Moi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DaiLy_ChiTietChoXuatKho_Moi));
            this.btLuu_Dong = new DevExpress.XtraEditors.SimpleButton();
            this.btPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btLuu_Dong
            // 
            this.btLuu_Dong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btLuu_Dong.ImageOptions.Image")));
            this.btLuu_Dong.Location = new System.Drawing.Point(697, 451);
            this.btLuu_Dong.Name = "btLuu_Dong";
            this.btLuu_Dong.Size = new System.Drawing.Size(88, 23);
            this.btLuu_Dong.TabIndex = 142;
            this.btLuu_Dong.Text = "Xuất kho";
            // 
            // btPrint
            // 
            this.btPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btPrint.ImageOptions.Image")));
            this.btPrint.Location = new System.Drawing.Point(606, 451);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(85, 23);
            this.btPrint.TabIndex = 141;
            this.btPrint.Text = "Print";
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.ImageOptions.Image = global::CtyTinLuong.Properties.Resources.ico_Abort;
            this.btThoat.Location = new System.Drawing.Point(791, 451);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 140;
            this.btThoat.Text = "Thoát";
            // 
            // DaiLy_ChiTietChoXuatKho_Moi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 486);
            this.Controls.Add(this.btLuu_Dong);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btThoat);
            this.Name = "DaiLy_ChiTietChoXuatKho_Moi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết xuất kho";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btLuu_Dong;
        private DevExpress.XtraEditors.SimpleButton btPrint;
        private DevExpress.XtraEditors.SimpleButton btThoat;
    }
}