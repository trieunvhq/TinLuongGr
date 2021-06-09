using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsNganHang_tbThuChi_ChiTietThuChi : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTonTai, m_bTienUSD, m_bDaGhiSo;
			private SqlDouble		m_fTiGia, m_fCo, m_fNo;
			private SqlInt32		m_iID_ThuChi, m_iID_TaiKhoanKeToanCon, m_iID_ChiTietThuChi;
			private SqlString		m_sGhiChu;
		#endregion


		public clsNganHang_tbThuChi_ChiTietThuChi()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_ChiTietThuChi_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fCo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietThuChi", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietThuChi = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietThuChi"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_ChiTietThuChi_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi_ChiTietThuChi::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_ChiTietThuChi_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fCo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_ChiTietThuChi_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi_ChiTietThuChi::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_ChiTietThuChi_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_ChiTietThuChi_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi_ChiTietThuChi::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_ChiTietThuChi_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_tbThuChi_ChiTietThuChi");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_ChiTietThuChi_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietThuChi = (Int32)dtToReturn.Rows[0]["ID_ChiTietThuChi"];
					m_iID_ThuChi = (Int32)dtToReturn.Rows[0]["ID_ThuChi"];
					m_iID_TaiKhoanKeToanCon = (Int32)dtToReturn.Rows[0]["ID_TaiKhoanKeToanCon"];
					m_fCo = (double)dtToReturn.Rows[0]["Co"];
					m_fNo = (double)dtToReturn.Rows[0]["No"];
					m_bTienUSD = (bool)dtToReturn.Rows[0]["TienUSD"];
					m_fTiGia = (double)dtToReturn.Rows[0]["TiGia"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bDaGhiSo = (bool)dtToReturn.Rows[0]["DaGhiSo"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi_ChiTietThuChi::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_ChiTietThuChi_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_tbThuChi_ChiTietThuChi");
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
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_ChiTietThuChi_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi_ChiTietThuChi::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietThuChi
		{
			get
			{
				return m_iID_ChiTietThuChi;
			}
			set
			{
				SqlInt32 iID_ChiTietThuChiTmp = (SqlInt32)value;
				if(iID_ChiTietThuChiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietThuChi", "iID_ChiTietThuChi can't be NULL");
				}
				m_iID_ChiTietThuChi = value;
			}
		}


		public SqlInt32 iID_ThuChi
		{
			get
			{
				return m_iID_ThuChi;
			}
			set
			{
				SqlInt32 iID_ThuChiTmp = (SqlInt32)value;
				if(iID_ThuChiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ThuChi", "iID_ThuChi can't be NULL");
				}
				m_iID_ThuChi = value;
			}
		}


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


		public SqlDouble fCo
		{
			get
			{
				return m_fCo;
			}
			set
			{
				SqlDouble fCoTmp = (SqlDouble)value;
				if(fCoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fCo", "fCo can't be NULL");
				}
				m_fCo = value;
			}
		}


		public SqlDouble fNo
		{
			get
			{
				return m_fNo;
			}
			set
			{
				SqlDouble fNoTmp = (SqlDouble)value;
				if(fNoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNo", "fNo can't be NULL");
				}
				m_fNo = value;
			}
		}


		public SqlBoolean bTienUSD
		{
			get
			{
				return m_bTienUSD;
			}
			set
			{
				SqlBoolean bTienUSDTmp = (SqlBoolean)value;
				if(bTienUSDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTienUSD", "bTienUSD can't be NULL");
				}
				m_bTienUSD = value;
			}
		}


		public SqlDouble fTiGia
		{
			get
			{
				return m_fTiGia;
			}
			set
			{
				SqlDouble fTiGiaTmp = (SqlDouble)value;
				if(fTiGiaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTiGia", "fTiGia can't be NULL");
				}
				m_fTiGia = value;
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


		public SqlBoolean bDaGhiSo
		{
			get
			{
				return m_bDaGhiSo;
			}
			set
			{
				SqlBoolean bDaGhiSoTmp = (SqlBoolean)value;
				if(bDaGhiSoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaGhiSo", "bDaGhiSo can't be NULL");
				}
				m_bDaGhiSo = value;
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
		#endregion
	}
}
