namespace CtyTinLuong
{
    partial class frmImPortDuLieu
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
            this.btDinhMucNPL = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btDaiLy = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btDinhMucNPL
            // 
            this.btDinhMucNPL.Location = new System.Drawing.Point(13, 23);
            this.btDinhMucNPL.Name = "btDinhMucNPL";
            this.btDinhMucNPL.Size = new System.Drawing.Size(118, 32);
            this.btDinhMucNPL.TabIndex = 0;
            this.btDinhMucNPL.Text = "Định mức NPL";
            this.btDinhMucNPL.UseVisualStyleBackColor = true;
            this.btDinhMucNPL.Click += new System.EventHandler(this.btDinhMucNPL_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chi tiết  Định mức NPL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btDaiLy
            // 
            this.btDaiLy.Location = new System.Drawing.Point(12, 344);
            this.btDaiLy.Name = "btDaiLy";
            this.btDaiLy.Size = new System.Drawing.Size(118, 32);
            this.btDaiLy.TabIndex = 2;
            this.btDaiLy.Text = "Danh sách đại lý";
            this.btDaiLy.UseVisualStyleBackColor = true;
            this.btDaiLy.Click += new System.EventHandler(this.btDaiLy_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "tai khoan con";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(203, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 32);
            this.button3.TabIndex = 4;
            this.button3.Text = " tai khoan Mẹ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(254, 32);
            this.button4.TabIndex = 5;
            this.button4.Text = "Update Mã NCC nvachar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(192, 32);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(217, 23);
            this.simpleButton1.TabIndex = 92;
            this.simpleButton1.Text = "Lấy tk ke toan NCC";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(254, 32);
            this.button5.TabIndex = 93;
            this.button5.Text = "Update Nhân sự nvachar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 204);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(254, 32);
            this.button6.TabIndex = 94;
            this.button6.Text = "Sửa dữ liệu tbNhanSu";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmImPortDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 400);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btDaiLy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btDinhMucNPL);
            this.Name = "frmImPortDuLieu";
            this.Text = "frmImPortDuLieu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDinhMucNPL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btDaiLy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}