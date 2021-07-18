using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsKhoThanhPham_tbNhapKho : clsDBInteractionBase
	{
        //H_ThanhPham_NhapKho_SA_NgayThang
        public DataTable SA_NgayThang(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[H_ThanhPham_NhapKho_SA_NgayThang]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("H_ThanhPham_NhapKho_SA_NgayThang");
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
                throw new Exception("H_ThanhPham_NhapKho_SA_NgayThang", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SelectOne_W_ThamChieu_SoChungTu_XuatKho_DaiLy()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_KhoThanhPham_tbNhapKho_SelectOne_W_ThamChieu_SoChungTu_XuatKho_DaiLy]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_KhoThanhPham_tbNhapKho_SelectOne_W_ThamChieu_SoChungTu_XuatKho_DaiLy");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_KhoThanhPham_tbNhapKho_SelectOne_W_ThamChieu_SoChungTu_XuatKho_DaiLy", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable SelectAll_W_DaiLy_hienThi_DaNhapKho()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_KhoThanhPham_tbNhapKho_SelectAll_W_DaiLy_hienThi_DaNhapKho]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_KhoThanhPham_tbNhapKho_SelectAll_W_DaiLy_hienThi_DaNhapKho");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
               // scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_ThanhPham", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho_ThanhPham));

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_KhoThanhPham_tbNhapKho_SelectAll_W_DaiLy_hienThi_DaNhapKho", ex);
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
