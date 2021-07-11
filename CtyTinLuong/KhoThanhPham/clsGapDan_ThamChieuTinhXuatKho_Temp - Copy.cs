using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsGapDan_ThamChieuTinhXuatKho_Temp : clsDBInteractionBase
	{
        //pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_ID_XuatKho_moi
        public DataTable SA_ID_XuatKho_moi(int xxiID_XuatKho_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_ID_XuatKho_moi]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_ID_XuatKho_moi");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_xuatkho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, xxiID_XuatKho_));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_ID_XuatKho_moi", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SA_W_ID_XuatKho(int xxiID_XuatKho_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_W_ID_XuatKho]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_W_ID_XuatKho");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, xxiID_XuatKho_));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ThamChieuTinhXuatKho_Temp_SA_NgayThang", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public void Delete_ALL_W_ID_XuatKhoDaiLy(int xxiID_XuatKho_)
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ThamChieuTinhXuatKho_Temp_Delete_ALL_W_ID_XuatKho]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, xxiID_XuatKho_));
                
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ThamChieuTinhXuatKho_Temp_Delete_ALL_W_ID_XuatKho::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public void Update_ALL_TonTai(int xxiID_XuatKho_, bool xxTontai_)
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_GapDan_ThamChieuTinhXuatKho_Temp_Update_ALL_TonTai]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, xxiID_XuatKho_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@btontai_", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, xxTontai_));

                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_GapDan_ThamChieuTinhXuatKho_Temp_Update_ALL_TonTai::Error occured.", ex);
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
