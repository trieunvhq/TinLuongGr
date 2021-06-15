///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'TamUng_ChiTietTamUng'
// Generated by LLBLGen v1.3.5996.26197 Final on: Tuesday, June 15, 2021, 3:08:10 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'TamUng_ChiTietTamUng'.
	/// </summary>
	public partial class clsTamUng_ChiTietTamUng : clsDBInteractionBase
	{
        //pr_TamUng_ChiTietTamUng_Update_ALL_TonTai_W_ID_TamUng
        public void Update_ALL_TonTai_W_ID_TamUng()
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_TamUng_ChiTietTamUng_Update_ALL_TonTai_W_ID_TamUng]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTamUng", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTamUng));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TamUng", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TamUng));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iKhauTruLuongThang));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang_Nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iKhauTruLuongThang_Nam));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckTamUngDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckTamUngDaiLy));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_TamUng_ChiTietTamUng_Update_ALL_TonTai_W_ID_TamUng::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable SA_W_ID_TamUng()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_TamUng_ChiTietTamUng_SA_W_ID_TamUng]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_TamUng_ChiTietTamUng_SA_W_ID_TamUng");
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
                throw new Exception("pr_TamUng_ChiTietTamUng_SA_W_ID_TamUng", ex);
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
