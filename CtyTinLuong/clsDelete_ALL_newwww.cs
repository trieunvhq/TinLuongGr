using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
    public partial class clsDelete_ALL_newwww : clsDBInteractionBase
    {
        public void HUU_Delete_ALL()
        {

            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[HUU_Delete_ALL]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            scmCmdToExecute.Connection = m_scoMainConnection;
            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("HUU_Delete_ALL::Error occured.", ex);
            }
            finally
            {
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
    }
}
