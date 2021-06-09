using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public class clsHUU_CaiMacDinh_DinhMuc_SanXuat : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		m_iID_DinhMucLuong_TheoSanLuong, m_iID_MacDinhSanXuat;
			private SqlString		m_sNoiDung;
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_TheoSanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_TheoSanLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNoiDung", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNoiDung));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MacDinhSanXuat", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MacDinhSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_MacDinhSanXuat = (SqlInt32)scmCmdToExecute.Parameters["@iID_MacDinhSanXuat"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_TheoSanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_TheoSanLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNoiDung", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNoiDung));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Update' reported the ErrorCode: " + m_iErrorCode);
				}

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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CaiMacDinh_DinhMuc_SanXuat_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CaiMacDinh_DinhMuc_SanXuat_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_MacDinhSanXuat = (Int32)dtToReturn.Rows[0]["ID_MacDinhSanXuat"];
					m_iID_DinhMucLuong_TheoSanLuong = (Int32)dtToReturn.Rows[0]["ID_DinhMucLuong_TheoSanLuong"];
					m_sNoiDung = (string)dtToReturn.Rows[0]["NoiDung"];
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CaiMacDinh_DinhMuc_SanXuat_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

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


		public SqlInt32 iID_DinhMucLuong_TheoSanLuong
		{
			get
			{
				return m_iID_DinhMucLuong_TheoSanLuong;
			}
			set
			{
				SqlInt32 iID_DinhMucLuong_TheoSanLuongTmp = (SqlInt32)value;
				if(iID_DinhMucLuong_TheoSanLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucLuong_TheoSanLuong", "iID_DinhMucLuong_TheoSanLuong can't be NULL");
				}
				m_iID_DinhMucLuong_TheoSanLuong = value;
			}
		}


		public SqlString sNoiDung
		{
			get
			{
				return m_sNoiDung;
			}
			set
			{
				SqlString sNoiDungTmp = (SqlString)value;
				if(sNoiDungTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sNoiDung", "sNoiDung can't be NULL");
				}
				m_sNoiDung = value;
			}
		}
		#endregion
	}
}
