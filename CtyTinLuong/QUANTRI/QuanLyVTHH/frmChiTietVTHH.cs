using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmChiTietVTHH : Form
    {
        int bienmacdinh=0;
        public static MemoryStream stmBLOBData22222;
        private bool KiemTraLuu()
        {
            if (txtMaVT.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã VT ");
                return false;
            }
            else if (txtTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên ");
                return false;
            }
            else if (cbDVT.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có ĐVT ");
                return false;
            }
            else return true;

        }
       
       
 

        private void Luu_Du_Lieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
               
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                
                if (textBox1.Text.ToString() != "")
                {
                    MemoryStream stremxx = new MemoryStream();
                    pictureEdit1.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stremxx.ToArray();
                    cls.blobHinhAnh = pic;
                }

                cls.sMaVT = txtMaVT.Text.ToString();
                cls.sTenVTHH = txtTen.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.sQuyCach = txtQuyCach.Text.ToString();
                cls.sDonViTinh = cbDVT.Text.ToString();
                cls.sGhiChu = txtGhiChu.Text.ToString();
                cls.iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4 = bienmacdinh;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = checNgungTheoDoi.Checked;
                cls.fDoCao_Dot = Convert.ToDouble(txtDoCao.Text);
                if (frmVatTuHangHoa.mbSua == true)
                {
                    cls.iID_VTHH = frmVatTuHangHoa.miID_Sua_VTHH;
                    cls.Update();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                else
                {
                    cls.Insert();
                    MessageBox.Show("Đã thêm mới");
                    this.Close();
                }
               
            }

        }
        private void HienThi_SuaThongTin_VTHH()
        {
            

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = frmVatTuHangHoa.miID_Sua_VTHH;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "")
                {
                    comboBox1.Text = "* Khác";
                }
                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "0")
                {
                    comboBox1.Text = "* Khác";
                }
                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "1")
                {
                    comboBox1.Text = "1. Vào máy IN";
                }
                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "2")
                {
                    comboBox1.Text = "2. Ra máy IN - Vào máy CẮT";
                }
                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "3")
                {
                    comboBox1.Text = "3. Ra máy CẮT - Vào máy ĐỘT";
                }
                if (dt.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"].ToString() == "4")
                {
                    comboBox1.Text = "4. Ra máy ĐỘT";
                }
            
                txtMaVT.Text = dt.Rows[0]["MaVT"].ToString();
                txtTen.Text = dt.Rows[0]["TenVTHH"].ToString();
                cbDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
                txtQuyCach.Text = dt.Rows[0]["QuyCach"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                if(dt.Rows[0]["HinhAnh"].ToString()!="")
                {
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(dt.Rows[0]["HinhAnh"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    pictureEdit1.Image = Image.FromStream(stmBLOBData);
                 
                    textBox1.Text = dt.Rows[0]["HinhAnh"].ToString();
                }

                checNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
            }

        }
        public frmChiTietVTHH()
        {
            InitializeComponent();
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietVTHH_Load(object sender, EventArgs e)
        {
            clsTbDonViTinh cls = new clsTbDonViTinh();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;          
            DataTable dxxxx = dv.ToTable();
            cbDVT.DataSource = dxxxx;
            cbDVT.DisplayMember = "DonViTinh";
            cbDVT.ValueMember = "ID_DonViTinh";
            if (frmVatTuHangHoa.mbSua == true)
                HienThi_SuaThongTin_VTHH();
            else if (frmVatTuHangHoa.mbCopy == true)
                HienThi_SuaThongTin_VTHH();
            
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_Du_Lieu();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Stream mystremmxx = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image file(*.jpg; *.jpeg; *.bmp)| *.jpg;*.jpeg;*.bmp";
            if(ff.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    if ((mystremmxx = ff.OpenFile()) != null)
                    {
                        
                        string filename = ff.FileName;
                        textBox1.Text = filename.ToString();
                        //pictureBox1.Load(filename);
                        pictureEdit1.Image = Image.FromFile(filename);
                        //if (mystremmxx.Length > 512000)
                        //{
                        //    MessageBox.Show("Dung lượng ảnh quá lớn");
                        //}
                        //else
                        //{
                        //    pictureBox1.Load(filename);
                        //}
                    }
                }
                catch
                {

                }
                
            }
        }

        private void pictureEdit1_DoubleClick_1(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit1.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();

                stmBLOBData22222 = new MemoryStream(pic);
                frmAnhLON ff = new CtyTinLuong.frmAnhLON();
                ff.Show();
            }
            else
                MessageBox.Show("Chưa có ảnh");
               
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            clsTbVatTuHangHoa cls = new CtyTinLuong.clsTbVatTuHangHoa();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text.ToString() == "* Khác")
                bienmacdinh = 0;
            if (comboBox1.Text.ToString() == "1. Vào máy IN")
                bienmacdinh = 1;
            if (comboBox1.Text.ToString() == "2. Ra máy IN - Vào máy CẮT")
                bienmacdinh = 2;
            if (comboBox1.Text.ToString() == "3. Ra máy CẮT - Vào máy ĐỘT")
                bienmacdinh = 3;
            if (comboBox1.Text.ToString() == "4. Ra máy ĐỘT")
                bienmacdinh = 4;          

        }
    }
}
