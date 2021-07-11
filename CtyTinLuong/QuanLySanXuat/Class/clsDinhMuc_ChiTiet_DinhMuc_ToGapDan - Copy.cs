using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDinhMuc_ChiTiet_DinhMuc_ToGapDan : clsDBInteractionBase
	{
        public DataTable SA_ID_DinhMuc_VT_Phu(int iiID_Dinhmuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Phu]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Phu");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iiID_Dinhmuc));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@SoLuongXuat_", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, xsoluongxuat_));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Phu", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable SA_ID_DinhMuc_VT_Chinh(int iiID_Dinhmuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Chinh]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Chinh");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iiID_Dinhmuc));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@SoLuongXuat_", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, xsoluongxuat_));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_VT_Chinh", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SA_ID_DinhMuc_ThanhPham( int iiID_Dinhmuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_ThanhPham]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_ThanhPham");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iiID_Dinhmuc));
                //scmCmdToExecute.Parameters.Add(new SqlParameter("@SoLuongXuat_", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, xsoluongxuat_));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_ID_DinhMuc_ThanhPham", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SA_IDDM_W_SoLuong(double xsoluongxuat_, int iiID_Dinhmuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_IDDM_W_SoLuong]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_IDDM_W_SoLuong");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iiID_Dinhmuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@SoLuongXuat_", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, xsoluongxuat_));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SA_IDDM_W_SoLuong", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public void Delete_ALL_W_ID_DinhMuc_ToGapDan()
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Delete_ALL_W_ID_DinhMuc_ToGapDan]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Delete_ALL_W_ID_DinhMuc_ToGapDan::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable SelectAll_W_ID_DinhMuc_ToGapDan()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectAll_W_ID_DinhMuc_ToGapDan]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectAll_W_ID_DinhMuc_ToGapDan");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectAll_W_ID_DinhMuc_ToGapDan", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH", ex);
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
