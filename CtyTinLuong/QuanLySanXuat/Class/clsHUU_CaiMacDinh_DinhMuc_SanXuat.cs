using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsHUU_CaiMacDinh_DinhMuc_SanXuat : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		m_iID_DinhMucLuong, m_iID_VTHH_Vao, m_iID_VTHH_Ra, m_iID_MacDinhSanXuat, m_iID_LoaiMay;
		#endregion


		public clsHUU_CaiMacDinh_DinhMuc_SanXuat()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_LoaiMay", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_LoaiMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Ra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Ra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Vao", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MacDinhSanXuat", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MacDinhSanXuat));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_MacDinhSanXuat = (SqlInt32)scmCmdToExecute.Parameters["@iID_MacDinhSanXuat"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CaiMacDinh_DinhMuc_SanXuat::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MacDinhSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MacDinhSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_LoaiMay", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_LoaiMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Ra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Ra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Vao", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Vao));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CaiMacDinh_DinhMuc_SanXuat::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override bool Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MacDinhSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MacDinhSanXuat));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CaiMacDinh_DinhMuc_SanXuat::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override DataTable SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CaiMacDinh_DinhMuc_SanXuat_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_CaiMacDinh_DinhMuc_SanXuat");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MacDinhSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MacDinhSanXuat));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_MacDinhSanXuat = (Int32)dtToReturn.Rows[0]["ID_MacDinhSanXuat"];
					m_iID_LoaiMay = (Int32)dtToReturn.Rows[0]["ID_LoaiMay"];
					m_iID_VTHH_Ra = (Int32)dtToReturn.Rows[0]["ID_VTHH_Ra"];
					m_iID_DinhMucLuong = (Int32)dtToReturn.Rows[0]["ID_DinhMucLuong"];
					m_iID_VTHH_Vao = (Int32)dtToReturn.Rows[0]["ID_VTHH_Vao"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CaiMacDinh_DinhMuc_SanXuat::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}


		public override DataTable SelectAll()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CaiMacDinh_DinhMuc_SanXuat_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_CaiMacDinh_DinhMuc_SanXuat");
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
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CaiMacDinh_DinhMuc_SanXuat::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlInt32 iID_MacDinhSanXuat
		{
			get
			{
				return m_iID_MacDinhSanXuat;
			}
			set
			{
				SqlInt32 iID_MacDinhSanXuatTmp = (SqlInt32)value;
				if(iID_MacDinhSanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_MacDinhSanXuat", "iID_MacDinhSanXuat can't be NULL");
				}
				m_iID_MacDinhSanXuat = value;
			}
		}


		public SqlInt32 iID_LoaiMay
		{
			get
			{
				return m_iID_LoaiMay;
			}
			set
			{
				SqlInt32 iID_LoaiMayTmp = (SqlInt32)value;
				if(iID_LoaiMayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_LoaiMay", "iID_LoaiMay can't be NULL");
				}
				m_iID_LoaiMay = value;
			}
		}


		public SqlInt32 iID_VTHH_Ra
		{
			get
			{
				return m_iID_VTHH_Ra;
			}
			set
			{
				SqlInt32 iID_VTHH_RaTmp = (SqlInt32)value;
				if(iID_VTHH_RaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_Ra", "iID_VTHH_Ra can't be NULL");
				}
				m_iID_VTHH_Ra = value;
			}
		}


		public SqlInt32 iID_DinhMucLuong
		{
			get
			{
				return m_iID_DinhMucLuong;
			}
			set
			{
				SqlInt32 iID_DinhMucLuongTmp = (SqlInt32)value;
				if(iID_DinhMucLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucLuong", "iID_DinhMucLuong can't be NULL");
				}
				m_iID_DinhMucLuong = value;
			}
		}


		public SqlInt32 iID_VTHH_Vao
		{
			get
			{
				return m_iID_VTHH_Vao;
			}
			set
			{
				SqlInt32 iID_VTHH_VaoTmp = (SqlInt32)value;
				if(iID_VTHH_VaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_Vao", "iID_VTHH_Vao can't be NULL");
				}
				m_iID_VTHH_Vao = value;
			}
		}
		#endregion
	}
}
