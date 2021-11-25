
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
    /// <summary>
    /// Purpose: Data Access class for the table 'Phieu_tbPhieu'.
    /// </summary>
    public partial class clsThin : clsDBInteractionBase
    {
        public DataTable Tr_Select_IDMuaHang_from_IDVTHH_Date(int idvthh, DateTime NgayThang)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Select_IDMuaHang_from_IDVTHH_Date]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@NgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, NgayThang));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Select_IDMuaHang_from_IDVTHH_Date", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public bool Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(int id, bool DaSuDung)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaSuDung", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DaSuDung));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsDinhMuc_DinhMuc_Luong_TheoSanLuong::Update::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable Tr_Select_CreateMaKhachHang()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Select_CreateMaKhachHang]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("CreateMaKH");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Select_CreateMaKhachHang", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Select_CreateMaDinhMucSL()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Select_CreateMaDinhMucSL]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("CreateMaDinhMucSL");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Select_CreateMaDinhMucSL", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Select_CreateMaNhanSu()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Select_CreateMaNhanSu]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("SelectOneMaNhanSu");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("SelectOneMaNhanSu", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public DataTable T_TongPhieuSX(DateTime ngay_batdau, DateTime ngay_ketthuc, string ma_phieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_TongPhieuSX]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_TongPhieuSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ma_phieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ma_phieu));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public bool Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(int ID_ChiTietChamCong_ToGapDan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietChamCong_ToGapDan", SqlDbType.Int, 4, 
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_ChiTietChamCong_ToGapDan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete::Delete::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public bool Tr_T_ChamCom_Delete(int ID_ChamCom)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_T_ChamCom_Delete]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamCom", SqlDbType.Int, 4,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_ChamCom));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete::Delete::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public DataTable T_PhieuSX_SF(int sotrang, DateTime ngay_batdau, DateTime ngay_ketthuc, string ma_phieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_PhieuSX_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_PhieuSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@SoTrang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, sotrang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ma_phieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ma_phieu));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_PhieuSX_SF", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_NhanSu_tbBoPhan_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_tbBoPhan_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_TongPhieuSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_NhanSu_tbBoPhan_SA", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_LoaiHangSX_SF(int loai)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LoaiHangSX_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiHangSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@loai", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, loai));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_LoaiHangSX_SF", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO(int ID_VTHH, int thang, int nam)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiHangSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public DataTable T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(int nam
            , int thang, int ID_BoPhan, int ID_VTHH, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_NganHang_TaiKhoanKeToanCon_SelectOne(int ID_TKme, string SoTKcon)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_NganHang_TaiKhoanKeToanCon_SelectOne]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanMe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_TKme));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoTaiKhoanCon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SoTKcon));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang(int thang, int nam, int ID_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang_CaLV(int thang, int nam, int ID_BoPhan, bool CaLamViec)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang_CaLV]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectOneCN_TMC(int nam, int thang, int iID_BoPhan, int iID_CongNhan, int iID_LoaiCong)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectOneCN_TMC]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_LoaiCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_LoaiCong));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectOneCN_TMC::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_ToInCatDot_DongBao(int nam, int thang, int May_IN, int May_CAT, int May_DOT, int iID_BoPhan, bool DongBao1_type, bool DongBao2_type)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_ToInCatDot_DongBao]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_IN", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_IN));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_CAT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_CAT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_DOT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_DOT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bDongBao1_Type", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DongBao1_type));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bDongBao2_Type", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DongBao2_type));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_ToInCatDot_SelectOne::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_ToInCatDot_SelectOne(int nam, int thang, int May_IN, int May_CAT, int May_DOT, string CaLamViec, int iID_BoPhan, int iID_CongNhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_ToInCatDot_SelectOne]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_IN", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_IN));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_CAT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_CAT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_DOT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_DOT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bCaLamViec", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_ToInCatDot_SelectOne::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public DataTable Tr_Phieu_ChiTietPhieu_New_XuatGiayCat_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_XuatGiayCat_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_XuatGiayCat_NXT_ChiTiet::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_MH_tbChiTietMuaHang_GiayCuon_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_MH_tbChiTietMuaHang_GiayCuon_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_MH_tbChiTietMuaHang_GiayCuon_NXT_ChiTiet::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT_ChiTiet::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_NhapGiayCat_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_NhapGiayCat_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_NhapGiayCat_NXT_ChiTiet::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_MayIn_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int iID_BoPhan, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_MayIn_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_MayIn_NXT_ChiTiet::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_MayCat_NXT_ChiTiet(DateTime ngay_batdau, DateTime ngay_ketthuc, int iID_BoPhan, int idvthh)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_MayCat_NXT_ChiTiet]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_Vthh", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idvthh));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_ToInCat_NXT::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_ToInCat_NXT(DateTime ngay_batdau, DateTime ngay_ketthuc, int iID_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_ToInCat_NXT]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_ToInCat_NXT::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_MH_tbChiTietMuaHang_GiayCuon_NXT(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_MH_tbChiTietMuaHang_GiayCuon_NXT]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_MH_tbChiTietMuaHang_GiayCuon_NXT::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_GiayCuon_NXT::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_MayCat_NXT(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_MayCat_NXT]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_Phieu_ChiTietPhieu_New_MayCat_NXT::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(int nam, int thang, int May_IN, int May_CAT, int May_DOT, string CaLamViec, int iID_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_IN", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_IN));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_CAT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_CAT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ibMay_DOT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, May_DOT));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bCaLamViec", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_BoPhan));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_Huu_CongNhat_MaHang_ToGapDan_CaiMacDinh_Select(int nam, int thang)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_MaHang_ToGapDan_CaiMacDinh_Select]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        //
        public DataTable Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_TDK_Select(int nam
            , int thang, int ID_BoPhan, int ID_VTHH, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_TDK_Select]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

       

        //Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD
        public DataTable Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(int nam
            , int thang, int ngay, int ID_BoPhan, int ID_VTHH, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@Ngay", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ngay));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_PMC]
        public DataTable Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_PMC(int nam
            , int thang, int ID_BoPhan, int ID_VTHH, string ten_nhanvien, bool CaLamViec)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_PMC]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PMC::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public DataTable Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_TDB_Select(int nam
           , int thang, int ID_BoPhan, int ID_VTHH, string ten_nhanvien, bool CaLamViec)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_TDB_Select]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PMC::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_Phieu_ChiTietPhieu_New_SF(int nam
            , int thang, bool in_, bool cat_, bool dot_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Phieu_ChiTietPhieu_New_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_Phieu_ChiTietPhieu_New_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@in", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, in_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@cat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, cat_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dot", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dot_));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_Phieu_ChiTietPhieu_New_SF::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_ChamCom_SF(int nam
            , int thang, int ID_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_ChamCom_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TGD_SF(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public DataTable Tr_BTTL_TGD(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_TGD]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_BTTL_TGD_new(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_TGD_new]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public DataTable Tr_BTTL_TDK(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_TDK]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_BTTL_TDB(int nam, int thang, int id_bophan, bool CaLamViec)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_TDB]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public DataTable Tr_BTTL_PMC(int nam, int thang, int id_bophan, bool CaLamViec)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_PMC]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CaLamViec));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TMC_SF(int nam, int thang, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TMC_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TGD_Mau()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_Mau]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                
                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_BTTL_TGD_Mau::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_LgTrNhiem_DB_DK_S(int nam, int thang, int id_bophan, bool isTangCa)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_LgTrNhiem_DB_DK_S]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@isTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, isTangCa));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_LgTrNhiem_DB_DK_S::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public void Tr_LgTrNhiem_DB_DK_I(int iThang, int iNam, double LuongTrachNhiem, int id_bophan, bool bIsTangCa, bool bGuiDuLieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_LgTrNhiem_DB_DK_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fLuongTrachNhiem", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, LuongTrachNhiem));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bIsTangCa));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_LgTrNhiem_DB_DK_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }



        public void Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(int iID_CongNhan, int iNgayInput, int iThang, int iNam, int iID_VTHH, float fSanLuongNgay,
            int iID_DinhMuc_Luong_SanLuong, bool bGuiDuLieu, bool bIsTangCa, int id_bophan, int ID_DinhMucLuong_CongNhat, int ID_LoaiCong)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgayInput", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNgayInput));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuongNgay", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fSanLuongNgay));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong_SanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_DinhMuc_Luong_SanLuong));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bIsTangCa));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_DinhMucLuong_CongNhat));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_LoaiCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_LoaiCong));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }


        public void Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(int iID_CongNhan, int iNgayInput, int iThang, int iNam, int iID_VTHH, float fSanLuongNgay,
            int iID_DinhMuc_Luong_SanLuong, bool bGuiDuLieu, bool bIsTangCa, int id_bophan, int ID_DinhMucLuong_CongNhat, int ID_LoaiCong, int ID_ChiTietChamCong_ToGapDan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgayInput", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNgayInput));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuongNgay", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fSanLuongNgay));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong_SanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_DinhMuc_Luong_SanLuong));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bIsTangCa));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_DinhMucLuong_CongNhat));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_LoaiCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_LoaiCong));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_ChiTietChamCong_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_ChiTietChamCong_ToGapDan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public void T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(int iID_CongNhan, int iThang, int iNam
            , int iID_VTHH, int iID_DinhMuc_Luong_SanLuong, float fNgay1, float fNgay2, float fNgay3, float fNgay4
            , float fNgay5, float fNgay6, float fNgay7, float fNgay8, float fNgay9
            , float fNgay10, float fNgay11, float fNgay12, float fNgay13
            , float fNgay14, float fNgay15, float fNgay16, float fNgay17, float fNgay18, float fNgay19
            , float fNgay20, float fNgay21, float fNgay22, float fNgay23, float fNgay24, float fNgay25
            , float fNgay26, float fNgay27, float fNgay28, float fNgay29, float fNgay30, float fNgay31
            , float fSanLuong, bool bGuiDuLieu, bool bIsTangCa, int id_bophan, int ID_DinhMucLuong_CongNhat,
             int ID_LoaiCong)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong_SanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_DinhMuc_Luong_SanLuong));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay1));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay2));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay3));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay4));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay5));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay6));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay7));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay8));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay9));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay10));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay11));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay12));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay13));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay14));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay15));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay16));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay17));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay18));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay19));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay20));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay21));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay22));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay23));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay24));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay25));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay26));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay27));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay28));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay29));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay30));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay31));


                scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fSanLuong));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bIsTangCa));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_DinhMucLuong_CongNhat));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_LoaiCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_LoaiCong));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public void T_BTTL_TGD_I(int iID_ChamCom, int iID_CongNhan, int iThang, int iNam
            , float fNgay1, float fNgay2, float fNgay3, float fNgay4
            , float fNgay5, float fNgay6, float fNgay7, float fNgay8, float fNgay9
            , float fNgay10, float fNgay11, float fNgay12, float fNgay13
            , float fNgay14, float fNgay15, float fNgay16, float fNgay17, float fNgay18, float fNgay19
            , float fNgay20, float fNgay21, float fNgay22, float fNgay23, float fNgay24, float fNgay25
            , float fNgay26, float fNgay27, float fNgay28, float fNgay29, float fNgay30, float fNgay31
            , bool bGuiDuLieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamCom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_ChamCom));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay1));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay2));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay3));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay4));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay5));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay6));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay7));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay8));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay9));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay10));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay11));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay12));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay13));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay14));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay15));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay16));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay17));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay18));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay19));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay20));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay21));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay22));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay23));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay24));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay25));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay26));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay27));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay28));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay29));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay30));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay31));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_BTTL_TGD_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable T_NhanSu_SF(string lst_id_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@lst_id_BoPhan", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_id_BoPhan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public DataTable Tr_NhanSu_TGD(string lst_id_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_NhanSu_TGD]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@lst_id_BoPhan", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_id_BoPhan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_LoaiCong_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LoaiCong_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiCong_SA");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                 
                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_LoaiCong_SA::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_DML_CN_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DML_CN_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                 
                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("[T_DML_CN_SA]::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_NhanSu_tbBoPhan_SO(string tenbophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_tbBoPhan_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_NhanSu_tbBoPhan_SO");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenBoPhan", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tenbophan));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_NhanSu_tbBoPhan_SO", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_DM_SO(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DM_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataSet T_LockUp_DaiLy_ChiTietChoNhapKho_Moi()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_DaiLy_ChiTietChoNhapKho_Moi]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_DaiLy_ChiTietChoNhapKho_Moi");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataSet T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataSet T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataSet T_LockUp_frmChiTietMuaHang3333333333()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_frmChiTietMuaHang3333333333]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_frmChiTietMuaHang3333333333");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_BTTL_SF(int nam, int thang, int id_bophan, bool isTangCa)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@isTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, isTangCa));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_BTTL_SF_CheckIsTangCa(int nam, int thang, int id_bophan, bool isTangCa)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_SF_CheckIsTangCa]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, isTangCa));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::Tr_BTTL_SF_CheckIsTangCa::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable Tr_BTTL_SF_NoCheckTime(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_BTTL_SF_NoCheckTime]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public bool Tr_Replace_AllMaDM(int id, string maDM)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Replace_AllMaDM]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaDinhMuc", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, maDM));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsDinhMuc_DinhMuc_Luong_TheoSanLuong::Update::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public bool Tr_Replace_All(int id, string macn, string tencn)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Replace_All]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaNhanVien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, macn));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenNhanVien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tencn));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsTr_DinhMuc_Luong::Update::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

    }
}
