using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsGapDan_ChiTiet_NhapKho_Temp : clsDBInteractionBase
	{
        public void Delete_ALL_W_ID( int xxid_)
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ChiTiet_NhapKho_Temp_Delete_ALL_W_ID]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
              
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, xxid_));
               
                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ChiTiet_NhapKho_Temp_Delete_ALL_W_ID::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable SA_W_ID_NK_HienThi_(int id_nhapkho_, int id_dinhmuc, double soluongxuat_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NK_HienThi_]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NK_HienThi_");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_nhapkho_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_dinhmuc", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_dinhmuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@soluongxuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, soluongxuat_));
                m_scoMainConnection.Open();
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NK_HienThi_", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public void Update_ALL_tonTai()
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ChiTiet_NhapKho_Temp_Update_ALL_tonTai]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKho));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongNhap", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongNhap));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongTon", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongTon));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaNhapKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaNhapKho));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bBoolTonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBoolTonDauKy));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_ThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_ThanhPham));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Chinh", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Chinh));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Phu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Phu));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietNhapKho", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietNhapKho));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ChiTiet_NhapKho_Temp_Update_ALL_tonTai::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable SA_W_ID_NhapKho(int _ID_NhapKho_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NhapKho]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NhapKho");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ID_NhapKho_));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
                m_scoMainConnection.Open();
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ChiTiet_NhapKho_Temp_SA_W_ID_NhapKho", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
    }
}