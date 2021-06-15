using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsTamUng_New : clsDBInteractionBase
	{
        //pr_TamUng_ChiTietTamUng_SA_W_NgayThang_DaiLy
        public DataTable SA_W_NgayThang_DaiLy()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_TamUng_ChiTietTamUng_SA_W_NgayThang_DaiLy]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_TamUng_ChiTietTamUng_SA_W_NgayThang_DaiLy");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTamUng", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTamUng));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TamUng", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TamUng));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iKhauTruLuongThang));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang_Nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iKhauTruLuongThang_Nam));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckTamUngDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckTamUngDaiLy));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_TamUng_ChiTietTamUng_SA_W_NgayThang_DaiLy", ex);
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
