using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ : Form
    {
        private int _thang, _nam, _id_bophan;
        private int _idVTHH = 0;
        private bool isload = true;
        DataTable _dtvthh, _data;

        private bool KiemTraLuu()
        {

            DataTable dv3 = (DataTable)gridControl1.DataSource;

            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtThang.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn tháng ");
                return false;
            }
            else if (txtNam.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn năm ");
                return false;
            }

            else return true;
        }


        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls1 = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
                cls1.iThang = Convert.ToInt32(txtThang.Text.ToString());
                cls1.iNam = Convert.ToInt32(txtNam.Text.ToString());
                // xoá trước
                cls1.Tr_CaiMacDinhMaHang_TDB_delete_thang_nam();
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();

                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    if (checkIDVTHH_All(Convert.ToInt32(dv3.Rows[i]["ID_VTHH"].ToString())))
                    {
                        cls1.iID_VTHH = Convert.ToInt32(dv3.Rows[i]["ID_VTHH"].ToString());
                        cls1.iThang = Convert.ToInt32(txtThang.Text.ToString());
                        cls1.iNam = Convert.ToInt32(txtNam.Text.ToString());
                        cls1.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(dv3.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString());
                        cls1.Tr_CaiMacDinhMaHang_TDB_Insert();
                    }
                }
                MessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        private void HienThi_themMoi()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            dt2.Columns.Add("id_bophan");
            dt2.Columns.Add("TenBoPhan");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");//  
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("NgungTheoDoi", typeof(bool));
            gridControl1.DataSource = dt2;
        }

        private void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }

            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            //dt2.Columns.Add("id_bophan");
            //dt2.Columns.Add("TenBoPhan");
            //dt2.Columns.Add("ID_VTHH");
            //dt2.Columns.Add("MaVT");// tb VTHH
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("Thang", typeof(int));
            //dt2.Columns.Add("Nam", typeof(int));
            //dt2.Columns.Add("NgungTheoDoi", typeof(bool));
            _data.Clear();
            clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK();
            DataTable dt3 = cls.Tr_MaHangToGD_DB_DK_SelectBoPhan(_thang, _nam, _id_bophan);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = _data.NewRow();
                _ravi["ID_MaHangToGD_DB_DK"] = Convert.ToInt32(dt3.Rows[i]["ID_MaHangToGD_DB_DK"].ToString());
                _ravi["id_bophan"] = Convert.ToInt32(dt3.Rows[i]["id_bophan"].ToString());
                _ravi["TenBoPhan"] = dt3.Rows[i]["TenBoPhan"].ToString();
                _ravi["ID_VTHH"] = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                _ravi["Thang"] = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                _ravi["Nam"] = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                _ravi["NgungTheoDoi"] = Convert.ToBoolean(dt3.Rows[i]["NgungTheoDoi"].ToString());
                _data.Rows.Add(_ravi);
            }

            gridControl1.DataSource = _data;
            isload = false;
        }

        public Tr_frmCaiMacDinnhMaHangTGD_DB_DK_()
        {
            InitializeComponent();

            _data = new DataTable();
            _data.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            _data.Columns.Add("id_bophan");
            _data.Columns.Add("TenBoPhan");
            _data.Columns.Add("ID_VTHH");
            _data.Columns.Add("MaVT");// tb VTHH
            _data.Columns.Add("TenVTHH");
            _data.Columns.Add("DonViTinh");
            _data.Columns.Add("DonGia", typeof(double));
            _data.Columns.Add("Thang", typeof(int));
            _data.Columns.Add("Nam", typeof(int));
            _data.Columns.Add("NgungTheoDoi", typeof(bool));

            _thang = DateTime.Now.Month;
            _nam = DateTime.Now.Year;
            txtNam.Text = _nam.ToString();
            txtThang.Text = _thang.ToString();

            _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
            if (_id_bophan == 0) return;
            radioGapDan.Checked = true;
        }

        private void Tr_frmCaiMacDinnhMaHangTGD_DB_DK__Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            _dtvthh = clsvthhh.SelectAll();
            _dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = _dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            repositoryItemSearchLookUpEdit1.DataSource = newdtvthh;
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";

            //Thay caption:
            repositoryItemSearchLookUpEdit1.View.Columns.Clear();//xóa caption cũ
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("ID_VTHH", "ID");
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("MaVT", "Mã vật tư");
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("TenVTHH", "Tên hàng hóa");
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("TenNhomVTHH", "Nhóm vật tư");

            repositoryItemSearchLookUpEdit1.View.Columns["ID_VTHH"].Visible = false;

            LoadData(true);

            //clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            //DataTable dtdm = clsdm.SelectAll();
            //dtdm.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            //DataView dvdm = dtdm.DefaultView;
            //DataTable newdtdm = dvdm.ToTable();

            //repositoryItemGridLookUpEdit2.DataSource = newdtdm;
            //repositoryItemGridLookUpEdit2.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            //repositoryItemGridLookUpEdit2.DisplayMember = "MaDinhMuc";


            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            //dt2.Columns.Add("id_bophan");
            //dt2.Columns.Add("TenBoPhan");
            //dt2.Columns.Add("ID_VTHH");
            //dt2.Columns.Add("MaVT");// tb VTHH
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("Thang", typeof(int));
            //dt2.Columns.Add("Nam", typeof(int));
            //dt2.Columns.Add("NgungTheoDoi", typeof(bool));
            //gridControl1.DataSource = dt2;

            //DateTime ngayhomnay = DateTime.Today;
            //int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            //int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            //txtNam.Text = nam.ToString();
            //txtThang.Text = thang.ToString();
            Cursor.Current = Cursors.Default;
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gridView1.GetFocusedRowCellValue(ID_MaHangToGD_DB_DK) == null
                    || gridView1.GetFocusedRowCellValue(ID_MaHangToGD_DB_DK).ToString() == ""
                    || gridView1.GetFocusedRowCellValue(ID_MaHangToGD_DB_DK).ToString() == "0")
                {
                    return;
                }

                //int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NhanSu).ToString());
                int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_MaHangToGD_DB_DK).ToString());

                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa hàng hóa: " + gridView1.GetFocusedRowCellValue(clTenVTHH).ToString(), "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    using (clsTr_MaHangToGD_DB_DK clsThin_ = new clsTr_MaHangToGD_DB_DK())
                    {
                        if (clsThin_.Tr_MaHangToGD_DB_DK_Delete(ID_ChiTietChamCong_TGD))
                        {
                            LoadData(false);
                        }
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Lỗi xóa hàng hóa khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT)
            {
                if (e.Value == null && e.Value.ToString() == "") return;
                int id_MaHang = 0;
                double dongia = 0;
                bool ngungtheodoi = false;

                int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                if  (!(gridView1.GetRowCellValue(e.RowHandle, ID_MaHangToGD_DB_DK) is DBNull))
                    id_MaHang = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, ID_MaHangToGD_DB_DK));

                if (!(gridView1.GetRowCellValue(e.RowHandle, DonGia) is DBNull))
                    dongia = CheckString.ConvertToDouble_My(gridView4.GetRowCellValue(e.RowHandle, DonGia));

                if (!(gridView1.GetRowCellValue(e.RowHandle, NgungTheoDoi) is DBNull))
                    ngungtheodoi = Convert.ToBoolean(gridView4.GetRowCellValue(e.RowHandle, NgungTheoDoi));

                for (int i = 0; i < _dtvthh.Rows.Count; i++)
                {
                    if (kk == Convert.ToInt32(_dtvthh.Rows[i]["ID_VTHH"].ToString()))
                    {
                        string maHang = _dtvthh.Rows[i]["MaVT"].ToString();
                        string tenVThh = _dtvthh.Rows[i]["TenVTHH"].ToString();
                        string donVT = _dtvthh.Rows[i]["DonViTinh"].ToString();

                        gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                        gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, tenVThh);
                        gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, donVT);
                        _idVTHH = kk;

                        //
                        using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
                        {
                            if (id_MaHang == 0)
                            {
                                cls.iThang = _thang;
                                cls.iNam = _nam;
                                cls.iID_VTHH = kk;
                                cls.iId_bophan = _id_bophan;
                                cls.fDonGia = dongia;
                                cls.bNgungTheoDoi = ngungtheodoi;

                                if (checkIDVTHH_All(kk))
                                {
                                    if (checkIDVTHH_TrongBoPhan(kk))
                                    {
                                        MessageBox.Show("Không thể thêm mã hàng " + maHang + ". Bởi vì mã hàng " + maHang + " đã tồn tại trong bộ phận này!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("Mã hàng " + maHang + " đã được thêm cho bộ phận khác. Bạn có muốn thêm cho bộ phận này không?",
                                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                            return;
                                    }
                                }

                                cls.Tr_MaHangToGD_DB_DK_Insert();
                                LoadData(false);
                            }
                            else
                            {
                                cls.iID_MaHangToGD_DB_DK = id_MaHang;
                                cls.iThang = _thang;
                                cls.iNam = _nam;
                                cls.iID_VTHH = kk;
                                cls.iId_bophan = _id_bophan;
                                cls.fDonGia = dongia;
                                cls.bNgungTheoDoi = ngungtheodoi;

                                if (checkIDVTHH_Update(id_MaHang, kk)) return;
                                else
                                {
                                    if (checkIDVTHH_All(kk))
                                    {
                                        if (checkIDVTHH_TrongBoPhan(kk))
                                        {
                                            MessageBox.Show("Không thể chọn mã hàng " + maHang + ". Bởi vì mã hàng " + maHang + " đã tồn tại trong bộ phận này!",
                                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("Mã hàng " + maHang + " đã được thêm cho bộ phận khác. Bạn có muốn chọn cho bộ phận này không?",
                                                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                                return;
                                        }
                                    }
                                }
                                cls.Tr_MaHangToGD_DB_DK_Update();
                            }
                        }

                        break;
                    }
                }
            }
            else if (e.Column == DonGia)
            {
                if (e.Value != null && e.Value.ToString() != "" && !(gridView4.GetRowCellValue(e.RowHandle, clMaVT) is DBNull))
                {
                    int idvthh = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, clMaVT));
                    int id_MaHang = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, ID_MaHangToGD_DB_DK));
                    double dongia = CheckString.ConvertToDouble_My(gridView4.GetRowCellValue(e.RowHandle, DonGia));
                    bool ngungtheodoi = Convert.ToBoolean(gridView4.GetRowCellValue(e.RowHandle, NgungTheoDoi));
                    //string maHang = Convert.ToString(gridView4.GetRowCellValue(e.RowHandle, ID_MaHangToGD_DB_DK));
                    //
                    using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
                    {
                        cls.iID_MaHangToGD_DB_DK = id_MaHang;
                        cls.iThang = _thang;
                        cls.iNam = _nam;
                        cls.iID_VTHH = idvthh;
                        cls.iId_bophan = _id_bophan;
                        cls.fDonGia = dongia;
                        cls.bNgungTheoDoi = ngungtheodoi;

                        cls.Tr_MaHangToGD_DB_DK_Update();
                        //if (id_MaHang == 0)
                        //{
                        //    cls.iThang = _thang;
                        //    cls.iNam = _nam;
                        //    cls.iID_VTHH = idvthh;
                        //    cls.iId_bophan = _id_bophan;
                        //    cls.fDonGia = dongia;
                        //    cls.bNgungTheoDoi = ngungtheodoi;
                        //    cls.Tr_MaHangToGD_DB_DK_Insert();
                        //    LoadData(false);
                        //}
                        //else
                        //{
                        //    cls.iID_MaHangToGD_DB_DK = id_MaHang;
                        //    cls.iThang = _thang;
                        //    cls.iNam = _nam;
                        //    cls.iID_VTHH = idvthh;
                        //    cls.iId_bophan = _id_bophan;
                        //    cls.fDonGia = dongia;
                        //    cls.bNgungTheoDoi = ngungtheodoi;

                        //    if (!checkIDVTHH_Update(id_MaHang, idvthh))
                        //    {
                        //        if (checkIDVTHH_All(idvthh))
                        //        {
                        //            if (checkIDVTHH_TrongBoPhan(idvthh))
                        //            {
                        //                MessageBox.Show("Không thể chọn mã hàng. Bởi vì mã hàng đã tồn tại trong bộ phận này!",
                        //                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //                return;
                        //            }
                        //            else
                        //            {
                        //                if (MessageBox.Show("Mã hàng đã được thêm cho bộ phận khác. Bạn có muốn chọn cho bộ phận này không?",
                        //                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        //                    return;
                        //            }
                        //        }
                        //    }

                        //    cls.Tr_MaHangToGD_DB_DK_Update();
                        //}
                    }
                }
            }
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //GridView view = sender as GridView;
            //DataView dv = view.DataSource as DataView;
            //if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            //{
            //    e.Visible = false;
            //    e.Handled = true;
            //}
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            //LuuDuLieu();
        }

        private bool checkIDVTHH_Update(int ID_MaHang, int idvthh)
        {
            bool result = false;

            //for (int i = 0; i < _data.Rows.Count; i++)
            //{
            //    if (idvthh == Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString())
            //        && ID_MaHang == Convert.ToInt32(_data.Rows[i]["ID_MaHangToGD_DB_DK"].ToString()))
            //    {
            //        result = true;
            //        break;
            //    }
            //}

            using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
            {
                int thang = Convert.ToInt32(txtThang.Value);
                int nam = Convert.ToInt32(txtNam.Value);
                cls.iThang = thang;
                cls.iNam = nam;
                DataTable dt3 = cls.Tr_MaHangToGD_DB_DK_SelectAll();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (idvthh == Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString())
                    && ID_MaHang == Convert.ToInt32(dt3.Rows[i]["ID_MaHangToGD_DB_DK"].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        //Kiểm tra idvthh trong tháng đã tồn tại chưa:
        private bool checkIDVTHH_All(int IdVthh)
        {
            bool result = false;

            using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
            {
                int thang = Convert.ToInt32(txtThang.Value);
                int nam = Convert.ToInt32(txtNam.Value);
                cls.iThang = thang;
                cls.iNam = nam;
                DataTable dt3 = cls.Tr_MaHangToGD_DB_DK_SelectAll();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (IdVthh == Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString())
                        && thang == Convert.ToInt32(dt3.Rows[i]["Thang"].ToString())
                        && nam == Convert.ToInt32(dt3.Rows[i]["Nam"].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private bool checkIDVTHH_TrongBoPhan(int IdVthh)
        {
            bool result = false;

            using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
            {
                int thang = Convert.ToInt32(txtThang.Value);
                int nam = Convert.ToInt32(txtNam.Value);
                cls.iThang = thang;
                cls.iNam = nam;
                DataTable dt3 = cls.Tr_MaHangToGD_DB_DK_SelectAll();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (IdVthh == Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString())
                        && thang == Convert.ToInt32(dt3.Rows[i]["Thang"].ToString())
                        && nam == Convert.ToInt32(dt3.Rows[i]["Nam"].ToString())
                        && _id_bophan == Convert.ToInt32(dt3.Rows[i]["id_bophan"].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioGapDan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGapDan.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
                if (_id_bophan == 0) return;
                LoadData(false);
            }
        }

        private void radioDongBao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDongBao.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ đóng bao"); 
                if (_id_bophan == 0) return;
                LoadData(false);
            }
        }

        private void gridView4_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //if (e.Column == clMaVT)
            //{
            //    string tt = gridView4.GetFocusedRowCellValue(clMaVT).ToString();
            //}
        }

        private void radioDongKien_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDongKien.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ đóng kiện");
                if (_id_bophan == 0) return;
                LoadData(false);
            }
        }

        private void gridView4_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["STT"], view.RowCount.ToString());
            view.SetRowCellValue(e.RowHandle, view.Columns["ID_MaHangToGD_DB_DK"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["DonGia"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["NgungTheoDoi"], false);
        }

        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");

                }
            }
            return _id_bophan;
        }
    }
}
