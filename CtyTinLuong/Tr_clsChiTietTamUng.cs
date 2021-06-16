﻿///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'Phieu_tbPhieu'
// Generated by LLBLGen v1.3.5996.26197 Final on: Sunday, January 03, 2021, 11:35:25 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{

    /// </summary>
    public partial class Tr_clsChiTietTamUng : clsDBInteractionBase
    {

        public DataTable ReturnTotalTamUng(int ID_CN, int thang, int nam)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_Return_TamUng_ChiTietTU]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("Tr_Return_TamUng_ChiTietTU");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CN", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_CN));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iKhauTruLuongThang_Nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_Return_TamUng_ChiTietTU", ex);
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
