﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_frmPrintBangChamCong_TBX : Form
    {

        private int _thang;
        private int _nam;

        public Tr_frmPrintBangChamCong_TBX(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        private void Tr_frmBangChamCong_TBX_Load(object sender, EventArgs e)
        {
            Tr_PrintBangChamCong_TBX xtr111 = new Tr_PrintBangChamCong_TBX(_thang, _nam);

            DataSet_TinLuong ds = new DataSet_TinLuong();

            clsThin cls1 = new clsThin();

            DataTable dt3 = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");


            xtr111.DataSource = null;
            xtr111.DataSource = dt3;


            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}