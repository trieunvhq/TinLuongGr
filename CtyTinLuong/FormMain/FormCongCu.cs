﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.FormMain
{
    public partial class FormCongCu : Form
    {
        public FormCongCu()
        {
            InitializeComponent();
        }

        private void FormCongCu_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            //label1.ForeColor = ThemeColor.SecondaryColor;

        }


        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau ff = new frmDoiMatKhau();
            ff.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static bool mb_Add_TK = false;
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            mb_Add_TK = true;
            frmChiTietTaiKhoan ff = new frmChiTietTaiKhoan();
            ff.Show();
        }
    }
}
