using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsNganHang_TaiKhoanKeToanCon : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTonTai, m_bKhoa;
			private SqlInt32		m_iID_TaiKhoanKeToanCon, m_iID_TaiKhoanKeToanMe;
			private SqlString		m_sGhiChuCon, m_sSoTaiKhoanCon, m_sTenTaiKhoanCon, m_sDienGiaiCon;
		#endregion


		public clsNganHang_TaiKhoanKeToanCon()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_TaiKhoanKeToanCon_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanMe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanMe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoTaiKhoanCon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoTaiKhoanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenTaiKhoanCon", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenTaiKhoanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiaiCon", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiaiCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChuCon", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChuCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_TaiKhoanKeToanCon = (SqlInt32)scmCmdToExecute.Parameters["@iID_TaiKhoanKeToanCon"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_TaiKhoanKeToanCon_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_TaiKhoanKeToanCon::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_TaiKhoanKeToanCon_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanMe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanMe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoTaiKhoanCon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoTaiKhoanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenTaiKhoanCon", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenTaiKhoanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiaiCon", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiaiCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChuCon", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChuCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_TaiKhoanKeToanCon_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_TaiKhoanKeToanCon::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_TaiKhoanKeToanCon_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_TaiKhoanKeToanCon_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_TaiKhoanKeToanCon::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_TaiKhoanKeToanCon_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_TaiKhoanKeToanCon");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_TaiKhoanKeToanCon_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_TaiKhoanKeToanCon = (Int32)dtToReturn.Rows[0]["ID_TaiKhoanKeToanCon"];
					m_iID_TaiKhoanKeToanMe = (Int32)dtToReturn.Rows[0]["ID_TaiKhoanKeToanMe"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_sSoTaiKhoanCon = (string)dtToReturn.Rows[0]["SoTaiKhoanCon"];
					m_sTenTaiKhoanCon = (string)dtToReturn.Rows[0]["TenTaiKhoanCon"];
					m_sDienGiaiCon = (string)dtToReturn.Rows[0]["DienGiaiCon"];
					m_sGhiChuCon = (string)dtToReturn.Rows[0]["GhiChuCon"];
					m_bKhoa = (bool)dtToReturn.Rows[0]["Khoa"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_TaiKhoanKeToanCon::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_TaiKhoanKeToanCon_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_TaiKhoanKeToanCon");
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
					throw new Exception("Stored Procedure 'pr_NganHang_TaiKhoanKeToanCon_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_TaiKhoanKeToanCon::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_TaiKhoanKeToanCon
		{
			get
			{
				return m_iID_TaiKhoanKeToanCon;
			}
			set
			{
				SqlInt32 iID_TaiKhoanKeToanConTmp = (SqlInt32)value;
				if(iID_TaiKhoanKeToanConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TaiKhoanKeToanCon", "iID_TaiKhoanKeToanCon can't be NULL");
				}
				m_iID_TaiKhoanKeToanCon = value;
			}
		}


		public SqlInt32 iID_TaiKhoanKeToanMe
		{
			get
			{
				return m_iID_TaiKhoanKeToanMe;
			}
			set
			{
				SqlInt32 iID_TaiKhoanKeToanMeTmp = (SqlInt32)value;
				if(iID_TaiKhoanKeToanMeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TaiKhoanKeToanMe", "iID_TaiKhoanKeToanMe can't be NULL");
				}
				m_iID_TaiKhoanKeToanMe = value;
			}
		}


		public SqlBoolean bNgungTheoDoi
		{
			get
			{
				return m_bNgungTheoDoi;
			}
			set
			{
				SqlBoolean bNgungTheoDoiTmp = (SqlBoolean)value;
				if(bNgungTheoDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bNgungTheoDoi", "bNgungTheoDoi can't be NULL");
				}
				m_bNgungTheoDoi = value;
			}
		}


		public SqlBoolean bTonTai
		{
			get
			{
				return m_bTonTai;
			}
			set
			{
				SqlBoolean bTonTaiTmp = (SqlBoolean)value;
				if(bTonTaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTonTai", "bTonTai can't be NULL");
				}
				m_bTonTai = value;
			}
		}


		public SqlString sSoTaiKhoanCon
		{
			get
			{
				return m_sSoTaiKhoanCon;
			}
			set
			{
				SqlString sSoTaiKhoanConTmp = (SqlString)value;
				if(sSoTaiKhoanConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoTaiKhoanCon", "sSoTaiKhoanCon can't be NULL");
				}
				m_sSoTaiKhoanCon = value;
			}
		}


		public SqlString sTenTaiKhoanCon
		{
			get
			{
				return m_sTenTaiKhoanCon;
			}
			set
			{
				SqlString sTenTaiKhoanConTmp = (SqlString)value;
				if(sTenTaiKhoanConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTenTaiKhoanCon", "sTenTaiKhoanCon can't be NULL");
				}
				m_sTenTaiKhoanCon = value;
			}
		}


		public SqlString sDienGiaiCon
		{
			get
			{
				return m_sDienGiaiCon;
			}
			set
			{
				SqlString sDienGiaiConTmp = (SqlString)value;
				if(sDienGiaiConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDienGiaiCon", "sDienGiaiCon can't be NULL");
				}
				m_sDienGiaiCon = value;
			}
		}


		public SqlString sGhiChuCon
		{
			get
			{
				return m_sGhiChuCon;
			}
			set
			{
				SqlString sGhiChuConTmp = (SqlString)value;
				if(sGhiChuConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sGhiChuCon", "sGhiChuCon can't be NULL");
				}
				m_sGhiChuCon = value;
			}
		}


		public SqlBoolean bKhoa
		{
			get
			{
				return m_bKhoa;
			}
			set
			{
				SqlBoolean bKhoaTmp = (SqlBoolean)value;
				if(bKhoaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bKhoa", "bKhoa can't be NULL");
				}
				m_bKhoa = value;
			}
		}
		#endregion
	}
}
