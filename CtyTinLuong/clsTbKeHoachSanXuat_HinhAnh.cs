using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsTbKeHoachSanXuat_HinhAnh : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBinary		m_blobHinhAnh;
			private SqlInt32		m_iID_HinhAnhKeHoach, m_iID_KeHoachSanXuat;
		#endregion


		public clsTbKeHoachSanXuat_HinhAnh()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_HinhAnh_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@blobHinhAnh", SqlDbType.Image, m_blobHinhAnh.Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_blobHinhAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_HinhAnhKeHoach", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_HinhAnhKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_HinhAnhKeHoach = (SqlInt32)scmCmdToExecute.Parameters["@iID_HinhAnhKeHoach"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_HinhAnh_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat_HinhAnh::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_HinhAnh_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_HinhAnhKeHoach", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_HinhAnhKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@blobHinhAnh", SqlDbType.Image, m_blobHinhAnh.Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_blobHinhAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_HinhAnh_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat_HinhAnh::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_HinhAnh_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_HinhAnhKeHoach", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_HinhAnhKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_HinhAnh_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat_HinhAnh::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_HinhAnh_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKeHoachSanXuat_HinhAnh");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_HinhAnhKeHoach", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_HinhAnhKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_HinhAnh_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_HinhAnhKeHoach = (Int32)dtToReturn.Rows[0]["ID_HinhAnhKeHoach"];
					m_iID_KeHoachSanXuat = (Int32)dtToReturn.Rows[0]["ID_KeHoachSanXuat"];
					m_blobHinhAnh = (byte[])dtToReturn.Rows[0]["HinhAnh"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat_HinhAnh::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_HinhAnh_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKeHoachSanXuat_HinhAnh");
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
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_HinhAnh_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat_HinhAnh::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_HinhAnhKeHoach
		{
			get
			{
				return m_iID_HinhAnhKeHoach;
			}
			set
			{
				SqlInt32 iID_HinhAnhKeHoachTmp = (SqlInt32)value;
				if(iID_HinhAnhKeHoachTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_HinhAnhKeHoach", "iID_HinhAnhKeHoach can't be NULL");
				}
				m_iID_HinhAnhKeHoach = value;
			}
		}


		public SqlInt32 iID_KeHoachSanXuat
		{
			get
			{
				return m_iID_KeHoachSanXuat;
			}
			set
			{
				SqlInt32 iID_KeHoachSanXuatTmp = (SqlInt32)value;
				if(iID_KeHoachSanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_KeHoachSanXuat", "iID_KeHoachSanXuat can't be NULL");
				}
				m_iID_KeHoachSanXuat = value;
			}
		}


		public SqlBinary blobHinhAnh
		{
			get
			{
				return m_blobHinhAnh;
			}
			set
			{
				SqlBinary blobHinhAnhTmp = (SqlBinary)value;
				if(blobHinhAnhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("blobHinhAnh", "blobHinhAnh can't be NULL");
				}
				m_blobHinhAnh = value;
			}
		}
		#endregion
	}
}
