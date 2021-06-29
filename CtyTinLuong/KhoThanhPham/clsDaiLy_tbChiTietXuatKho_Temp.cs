using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDaiLy_tbChiTietXuatKho_Temp : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDaXuatKho, m_bNgungTheoDoi, m_bTonTai;
			private SqlDouble		m_fSoLuongXuat, m_fDonGia;
			private SqlInt32		m_iNhapKho_TP_1_BTP_2_NPL_3, m_iID_DaiLy, m_iID_VTHH, m_iID_XuatKhoDaiLy, m_iID_ChiTietXuatKho_DaiLy;
			private SqlString		m_sGhiChu;
		#endregion


		public clsDaiLy_tbChiTietXuatKho_Temp()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbChiTietXuatKho_Temp_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNhapKho_TP_1_BTP_2_NPL_3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNhapKho_TP_1_BTP_2_NPL_3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietXuatKho_DaiLy", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietXuatKho_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietXuatKho_DaiLy = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietXuatKho_DaiLy"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbChiTietXuatKho_Temp_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbChiTietXuatKho_Temp::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbChiTietXuatKho_Temp_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietXuatKho_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietXuatKho_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNhapKho_TP_1_BTP_2_NPL_3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNhapKho_TP_1_BTP_2_NPL_3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbChiTietXuatKho_Temp_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbChiTietXuatKho_Temp::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbChiTietXuatKho_Temp_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietXuatKho_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietXuatKho_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbChiTietXuatKho_Temp_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbChiTietXuatKho_Temp::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbChiTietXuatKho_Temp_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbChiTietXuatKho_Temp");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietXuatKho_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietXuatKho_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbChiTietXuatKho_Temp_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietXuatKho_DaiLy = (Int32)dtToReturn.Rows[0]["ID_ChiTietXuatKho_DaiLy"];
					m_iID_XuatKhoDaiLy = (Int32)dtToReturn.Rows[0]["ID_XuatKhoDaiLy"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuongXuat = (double)dtToReturn.Rows[0]["SoLuongXuat"];
					m_fDonGia = (double)dtToReturn.Rows[0]["DonGia"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_iID_DaiLy = (Int32)dtToReturn.Rows[0]["ID_DaiLy"];
					m_bDaXuatKho = (bool)dtToReturn.Rows[0]["DaXuatKho"];
					m_iNhapKho_TP_1_BTP_2_NPL_3 = (Int32)dtToReturn.Rows[0]["NhapKho_TP_1_BTP_2_NPL_3"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbChiTietXuatKho_Temp::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbChiTietXuatKho_Temp_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbChiTietXuatKho_Temp");
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
					throw new Exception("Stored Procedure 'pr_DaiLy_tbChiTietXuatKho_Temp_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbChiTietXuatKho_Temp::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietXuatKho_DaiLy
		{
			get
			{
				return m_iID_ChiTietXuatKho_DaiLy;
			}
			set
			{
				SqlInt32 iID_ChiTietXuatKho_DaiLyTmp = (SqlInt32)value;
				if(iID_ChiTietXuatKho_DaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietXuatKho_DaiLy", "iID_ChiTietXuatKho_DaiLy can't be NULL");
				}
				m_iID_ChiTietXuatKho_DaiLy = value;
			}
		}


		public SqlInt32 iID_XuatKhoDaiLy
		{
			get
			{
				return m_iID_XuatKhoDaiLy;
			}
			set
			{
				SqlInt32 iID_XuatKhoDaiLyTmp = (SqlInt32)value;
				if(iID_XuatKhoDaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_XuatKhoDaiLy", "iID_XuatKhoDaiLy can't be NULL");
				}
				m_iID_XuatKhoDaiLy = value;
			}
		}


		public SqlInt32 iID_VTHH
		{
			get
			{
				return m_iID_VTHH;
			}
			set
			{
				SqlInt32 iID_VTHHTmp = (SqlInt32)value;
				if(iID_VTHHTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH", "iID_VTHH can't be NULL");
				}
				m_iID_VTHH = value;
			}
		}


		public SqlDouble fSoLuongXuat
		{
			get
			{
				return m_fSoLuongXuat;
			}
			set
			{
				SqlDouble fSoLuongXuatTmp = (SqlDouble)value;
				if(fSoLuongXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongXuat", "fSoLuongXuat can't be NULL");
				}
				m_fSoLuongXuat = value;
			}
		}


		public SqlDouble fDonGia
		{
			get
			{
				return m_fDonGia;
			}
			set
			{
				SqlDouble fDonGiaTmp = (SqlDouble)value;
				if(fDonGiaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDonGia", "fDonGia can't be NULL");
				}
				m_fDonGia = value;
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


		public SqlBoolean bDaXuatKho
		{
			get
			{
				return m_bDaXuatKho;
			}
			set
			{
				SqlBoolean bDaXuatKhoTmp = (SqlBoolean)value;
				if(bDaXuatKhoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaXuatKho", "bDaXuatKho can't be NULL");
				}
				m_bDaXuatKho = value;
			}
		}


		public SqlInt32 iNhapKho_TP_1_BTP_2_NPL_3
		{
			get
			{
				return m_iNhapKho_TP_1_BTP_2_NPL_3;
			}
			set
			{
				SqlInt32 iNhapKho_TP_1_BTP_2_NPL_3Tmp = (SqlInt32)value;
				if(iNhapKho_TP_1_BTP_2_NPL_3Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iNhapKho_TP_1_BTP_2_NPL_3", "iNhapKho_TP_1_BTP_2_NPL_3 can't be NULL");
				}
				m_iNhapKho_TP_1_BTP_2_NPL_3 = value;
			}
		}
		#endregion
	}
}
