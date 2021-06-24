using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public class clsTraLuong_ChiTietTraLuong_new : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bCheckDaiLy, m_bNgungTheoDoi;
			private SqlDouble		m_fSoTien;
			private SqlInt32		m_iID_ChiTietTraLuong, m_iID_TraLuong, m_iID_DoiTuong, m_iLuong_Nam, m_iLuong_Thang;
			private SqlString		m_sGhiChu;
		#endregion


		public clsTraLuong_ChiTietTraLuong_new()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_TraLuong_ChiTietTraLuong_new_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TraLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iLuong_Thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iLuong_Thang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iLuong_Nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iLuong_Nam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTraLuong", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietTraLuong = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietTraLuong"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_TraLuong_ChiTietTraLuong_new_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTraLuong_ChiTietTraLuong_new::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_TraLuong_ChiTietTraLuong_new_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTraLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TraLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iLuong_Thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iLuong_Thang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iLuong_Nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iLuong_Nam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_TraLuong_ChiTietTraLuong_new_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTraLuong_ChiTietTraLuong_new::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_TraLuong_ChiTietTraLuong_new_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTraLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_TraLuong_ChiTietTraLuong_new_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTraLuong_ChiTietTraLuong_new::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_TraLuong_ChiTietTraLuong_new_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("TraLuong_ChiTietTraLuong_new");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietTraLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_TraLuong_ChiTietTraLuong_new_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietTraLuong = (Int32)dtToReturn.Rows[0]["ID_ChiTietTraLuong"];
					m_iID_TraLuong = (Int32)dtToReturn.Rows[0]["ID_TraLuong"];
					m_iID_DoiTuong = (Int32)dtToReturn.Rows[0]["ID_DoiTuong"];
					m_iLuong_Thang = (Int32)dtToReturn.Rows[0]["Luong_Thang"];
					m_iLuong_Nam = (Int32)dtToReturn.Rows[0]["Luong_Nam"];
					m_bCheckDaiLy = (bool)dtToReturn.Rows[0]["CheckDaiLy"];
					m_fSoTien = (double)dtToReturn.Rows[0]["SoTien"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTraLuong_ChiTietTraLuong_new::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_TraLuong_ChiTietTraLuong_new_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("TraLuong_ChiTietTraLuong_new");
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
					throw new Exception("Stored Procedure 'pr_TraLuong_ChiTietTraLuong_new_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTraLuong_ChiTietTraLuong_new::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietTraLuong
		{
			get
			{
				return m_iID_ChiTietTraLuong;
			}
			set
			{
				SqlInt32 iID_ChiTietTraLuongTmp = (SqlInt32)value;
				if(iID_ChiTietTraLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietTraLuong", "iID_ChiTietTraLuong can't be NULL");
				}
				m_iID_ChiTietTraLuong = value;
			}
		}


		public SqlInt32 iID_TraLuong
		{
			get
			{
				return m_iID_TraLuong;
			}
			set
			{
				SqlInt32 iID_TraLuongTmp = (SqlInt32)value;
				if(iID_TraLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TraLuong", "iID_TraLuong can't be NULL");
				}
				m_iID_TraLuong = value;
			}
		}


		public SqlInt32 iID_DoiTuong
		{
			get
			{
				return m_iID_DoiTuong;
			}
			set
			{
				SqlInt32 iID_DoiTuongTmp = (SqlInt32)value;
				if(iID_DoiTuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DoiTuong", "iID_DoiTuong can't be NULL");
				}
				m_iID_DoiTuong = value;
			}
		}


		public SqlInt32 iLuong_Thang
		{
			get
			{
				return m_iLuong_Thang;
			}
			set
			{
				SqlInt32 iLuong_ThangTmp = (SqlInt32)value;
				if(iLuong_ThangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iLuong_Thang", "iLuong_Thang can't be NULL");
				}
				m_iLuong_Thang = value;
			}
		}


		public SqlInt32 iLuong_Nam
		{
			get
			{
				return m_iLuong_Nam;
			}
			set
			{
				SqlInt32 iLuong_NamTmp = (SqlInt32)value;
				if(iLuong_NamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iLuong_Nam", "iLuong_Nam can't be NULL");
				}
				m_iLuong_Nam = value;
			}
		}


		public SqlBoolean bCheckDaiLy
		{
			get
			{
				return m_bCheckDaiLy;
			}
			set
			{
				SqlBoolean bCheckDaiLyTmp = (SqlBoolean)value;
				if(bCheckDaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheckDaiLy", "bCheckDaiLy can't be NULL");
				}
				m_bCheckDaiLy = value;
			}
		}


		public SqlDouble fSoTien
		{
			get
			{
				return m_fSoTien;
			}
			set
			{
				SqlDouble fSoTienTmp = (SqlDouble)value;
				if(fSoTienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoTien", "fSoTien can't be NULL");
				}
				m_fSoTien = value;
			}
		}


		public SqlString sGhiChu
		{
			get
			{
				return m_sGhiChu;
			}
			set
			{
				SqlString sGhiChuTmp = (SqlString)value;
				if(sGhiChuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sGhiChu", "sGhiChu can't be NULL");
				}
				m_sGhiChu = value;
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
		#endregion
	}
}
