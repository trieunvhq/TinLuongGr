using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDaiLy_BangLuong : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bNgungTheoDoi, m_bDaTraLuong;
			private SqlDecimal		m_dcTamUng, m_dcSoTienDaTra, m_dcLuongDaiLy;
			private SqlInt32		m_iThang, m_iID_DaiLy, m_iNam, m_iID_BangLuong;
			private SqlString		m_sDienGiai;
		#endregion


		public clsDaiLy_BangLuong()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_BangLuong_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongDaiLy", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTamUng", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTamUng));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcSoTienDaTra", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcSoTienDaTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaTraLuong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BangLuong", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BangLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_BangLuong = (SqlInt32)scmCmdToExecute.Parameters["@iID_BangLuong"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_BangLuong_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_BangLuong::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_BangLuong_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BangLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BangLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongDaiLy", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTamUng", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTamUng));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcSoTienDaTra", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcSoTienDaTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaTraLuong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_BangLuong_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_BangLuong::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_BangLuong_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BangLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BangLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_BangLuong_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_BangLuong::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_BangLuong_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_BangLuong");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BangLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BangLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_BangLuong_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_BangLuong = (Int32)dtToReturn.Rows[0]["ID_BangLuong"];
					m_iID_DaiLy = (Int32)dtToReturn.Rows[0]["ID_DaiLy"];
					m_iThang = (Int32)dtToReturn.Rows[0]["Thang"];
					m_iNam = (Int32)dtToReturn.Rows[0]["Nam"];
					m_dcLuongDaiLy = (Decimal)dtToReturn.Rows[0]["LuongDaiLy"];
					m_dcTamUng = (Decimal)dtToReturn.Rows[0]["TamUng"];
					m_dcSoTienDaTra = (Decimal)dtToReturn.Rows[0]["SoTienDaTra"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bDaTraLuong = (bool)dtToReturn.Rows[0]["DaTraLuong"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_BangLuong::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_BangLuong_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_BangLuong");
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
					throw new Exception("Stored Procedure 'pr_DaiLy_BangLuong_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_BangLuong::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_BangLuong
		{
			get
			{
				return m_iID_BangLuong;
			}
			set
			{
				SqlInt32 iID_BangLuongTmp = (SqlInt32)value;
				if(iID_BangLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_BangLuong", "iID_BangLuong can't be NULL");
				}
				m_iID_BangLuong = value;
			}
		}


		public SqlInt32 iID_DaiLy
		{
			get
			{
				return m_iID_DaiLy;
			}
			set
			{
				SqlInt32 iID_DaiLyTmp = (SqlInt32)value;
				if(iID_DaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DaiLy", "iID_DaiLy can't be NULL");
				}
				m_iID_DaiLy = value;
			}
		}


		public SqlInt32 iThang
		{
			get
			{
				return m_iThang;
			}
			set
			{
				SqlInt32 iThangTmp = (SqlInt32)value;
				if(iThangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iThang", "iThang can't be NULL");
				}
				m_iThang = value;
			}
		}


		public SqlInt32 iNam
		{
			get
			{
				return m_iNam;
			}
			set
			{
				SqlInt32 iNamTmp = (SqlInt32)value;
				if(iNamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iNam", "iNam can't be NULL");
				}
				m_iNam = value;
			}
		}


		public SqlDecimal dcLuongDaiLy
		{
			get
			{
				return m_dcLuongDaiLy;
			}
			set
			{
				SqlDecimal dcLuongDaiLyTmp = (SqlDecimal)value;
				if(dcLuongDaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongDaiLy", "dcLuongDaiLy can't be NULL");
				}
				m_dcLuongDaiLy = value;
			}
		}


		public SqlDecimal dcTamUng
		{
			get
			{
				return m_dcTamUng;
			}
			set
			{
				SqlDecimal dcTamUngTmp = (SqlDecimal)value;
				if(dcTamUngTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcTamUng", "dcTamUng can't be NULL");
				}
				m_dcTamUng = value;
			}
		}


		public SqlDecimal dcSoTienDaTra
		{
			get
			{
				return m_dcSoTienDaTra;
			}
			set
			{
				SqlDecimal dcSoTienDaTraTmp = (SqlDecimal)value;
				if(dcSoTienDaTraTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcSoTienDaTra", "dcSoTienDaTra can't be NULL");
				}
				m_dcSoTienDaTra = value;
			}
		}


		public SqlString sDienGiai
		{
			get
			{
				return m_sDienGiai;
			}
			set
			{
				SqlString sDienGiaiTmp = (SqlString)value;
				if(sDienGiaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDienGiai", "sDienGiai can't be NULL");
				}
				m_sDienGiai = value;
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


		public SqlBoolean bDaTraLuong
		{
			get
			{
				return m_bDaTraLuong;
			}
			set
			{
				SqlBoolean bDaTraLuongTmp = (SqlBoolean)value;
				if(bDaTraLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaTraLuong", "bDaTraLuong can't be NULL");
				}
				m_bDaTraLuong = value;
			}
		}
		#endregion
	}
}
