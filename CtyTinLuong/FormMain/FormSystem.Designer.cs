namespace CtyTinLuong.FormMain
{
    partial class FormSystem
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
            this.btnSaoLuuCSDL = new System.Windows.Forms.Button();
            this.btnPhucHoiCSDL = new System.Windows.Forms.Button();
            this.btnThietLapBanDau = new System.Windows.Forms.Button();
            this.btnChuyenDLSangNamMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaoLuuCSDL
            // 
            this.btnSaoLuuCSDL.FlatAppearance.BorderSize = 0;
            this.btnSaoLuuCSDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuuCSDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuuCSDL.Location = new System.Drawing.Point(12, 12);
            this.btnSaoLuuCSDL.Name = "btnSaoLuuCSDL";
            this.btnSaoLuuCSDL.Size = new System.Drawing.Size(431, 210);
            this.btnSaoLuuCSDL.TabIndex = 0;
            this.btnSaoLuuCSDL.Text = "Sao lưu CSDL";
            this.btnSaoLuuCSDL.UseVisualStyleBackColor = true;
            // 
            // btnPhucHoiCSDL
            // 
            this.btnPhucHoiCSDL.FlatAppearance.BorderSize = 0;
            this.btnPhucHoiCSDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhucHoiCSDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhucHoiCSDL.Location = new System.Drawing.Point(447, 12);
            this.btnPhucHoiCSDL.Name = "btnPhucHoiCSDL";
            this.btnPhucHoiCSDL.Size = new System.Drawing.Size(407, 210);
            this.btnPhucHoiCSDL.TabIndex = 0;
            this.btnPhucHoiCSDL.Text = "Phục hồi CSDL";
            this.btnPhucHoiCSDL.UseVisualStyleBackColor = true;
            this.btnPhucHoiCSDL.Click += new System.EventHandler(this.btnPhucHoiCSDL_Click);
            // 
            // btnThietLapBanDau
            // 
            this.btnThietLapBanDau.FlatAppearance.BorderSize = 0;
            this.btnThietLapBanDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThietLapBanDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThietLapBanDau.Location = new System.Drawing.Point(12, 226);
            this.btnThietLapBanDau.Name = "btnThietLapBanDau";
            this.btnThietLapBanDau.Size = new System.Drawing.Size(431, 221);
            this.btnThietLapBanDau.TabIndex = 0;
            this.btnThietLapBanDau.Text = "Thiết lập ban đầu";
            this.btnThietLapBanDau.UseVisualStyleBackColor = true;
            this.btnThietLapBanDau.Click += new System.EventHandler(this.btnThietLapBanDau_Click);
            // 
            // btnChuyenDLSangNamMoi
            // 
            this.btnChuyenDLSangNamMoi.FlatAppearance.BorderSize = 0;
            this.btnChuyenDLSangNamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenDLSangNamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenDLSangNamMoi.Location = new System.Drawing.Point(447, 226);
            this.btnChuyenDLSangNamMoi.Name = "btnChuyenDLSangNamMoi";
            this.btnChuyenDLSangNamMoi.Size = new System.Drawing.Size(407, 221);
            this.btnChuyenDLSangNamMoi.TabIndex = 0;
            this.btnChuyenDLSangNamMoi.Text = "Chuyển dữ liệu sang năm mới";
            this.btnChuyenDLSangNamMoi.UseVisualStyleBackColor = true;
            // 
            // FormSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 461);
            this.Controls.Add(this.btnChuyenDLSangNamMoi);
            this.Controls.Add(this.btnPhucHoiCSDL);
            this.Controls.Add(this.btnThietLapBanDau);
            this.Controls.Add(this.btnSaoLuuCSDL);
            this.Name = "FormSystem";
            this.Text = "        HỆ THỐNG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaoLuuCSDL;
        private System.Windows.Forms.Button btnPhucHoiCSDL;
        private System.Windows.Forms.Button btnThietLapBanDau;
        private System.Windows.Forms.Button btnChuyenDLSangNamMoi;
    }
}