using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDaiLy_tbNhapKho_Temp : clsDBInteractionBase
	{
        //pr_DaiLy_tbNhapKho_Temp_SA_NgayThang_ChoGhiSo
        public DataTable SA_NgayThang_ChoGhiSo(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_SA_NgayThang_ChoGhiSo]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DaiLy_tbNhapKho_Temp_SA_NgayThang_ChoGhiSo");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DaiLy_tbNhapKho_Temp_SA_NgayThang_ChoGhiSo", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SA_NgayThang(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_SA_NgayThang]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_DaiLy_tbNhapKho_Temp_SA_NgayThang");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_DaiLy_tbNhapKho_Temp_SA_NgayThang", ex);
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
