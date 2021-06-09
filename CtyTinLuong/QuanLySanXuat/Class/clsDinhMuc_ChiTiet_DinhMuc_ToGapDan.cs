using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDinhMuc_ChiTiet_DinhMuc_ToGapDan : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bCheck_VatTu_Phu, m_bCheck_VatTu_Chinh, m_bCheck_ThanhPham, m_bTonTai;
			private SqlDouble		m_fSoLuong;
			private SqlInt32		m_iID_ChiTiet_DinhMuc_ToGapDan, m_iID_VTHH, m_iID_DinhMuc_ToGapDan;
		#endregion


		public clsDinhMuc_ChiTiet_DinhMuc_ToGapDan()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_ThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Chinh", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Chinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Phu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Phu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTiet_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTiet_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTiet_DinhMuc_ToGapDan = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTiet_DinhMuc_ToGapDan"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_ChiTiet_DinhMuc_ToGapDan::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTiet_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTiet_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_ThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Chinh", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Chinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_VatTu_Phu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_VatTu_Phu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_ChiTiet_DinhMuc_ToGapDan::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTiet_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTiet_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_ChiTiet_DinhMuc_ToGapDan::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DinhMuc_ChiTiet_DinhMuc_ToGapDan");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTiet_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTiet_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTiet_DinhMuc_ToGapDan = (Int32)dtToReturn.Rows[0]["ID_ChiTiet_DinhMuc_ToGapDan"];
					m_iID_DinhMuc_ToGapDan = (Int32)dtToReturn.Rows[0]["ID_DinhMuc_ToGapDan"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuong = (double)dtToReturn.Rows[0]["SoLuong"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bCheck_ThanhPham = (bool)dtToReturn.Rows[0]["Check_ThanhPham"];
					m_bCheck_VatTu_Chinh = (bool)dtToReturn.Rows[0]["Check_VatTu_Chinh"];
					m_bCheck_VatTu_Phu = (bool)dtToReturn.Rows[0]["Check_VatTu_Phu"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_ChiTiet_DinhMuc_ToGapDan::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DinhMuc_ChiTiet_DinhMuc_ToGapDan");
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
					throw new Exception("Stored Procedure 'pr_DinhMuc_ChiTiet_DinhMuc_ToGapDan_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_ChiTiet_DinhMuc_ToGapDan::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTiet_DinhMuc_ToGapDan
		{
			get
			{
				return m_iID_ChiTiet_DinhMuc_ToGapDan;
			}
			set
			{
				SqlInt32 iID_ChiTiet_DinhMuc_ToGapDanTmp = (SqlInt32)value;
				if(iID_ChiTiet_DinhMuc_ToGapDanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTiet_DinhMuc_ToGapDan", "iID_ChiTiet_DinhMuc_ToGapDan can't be NULL");
				}
				m_iID_ChiTiet_DinhMuc_ToGapDan = value;
			}
		}


		public SqlInt32 iID_DinhMuc_ToGapDan
		{
			get
			{
				return m_iID_DinhMuc_ToGapDan;
			}
			set
			{
				SqlInt32 iID_DinhMuc_ToGapDanTmp = (SqlInt32)value;
				if(iID_DinhMuc_ToGapDanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMuc_ToGapDan", "iID_DinhMuc_ToGapDan can't be NULL");
				}
				m_iID_DinhMuc_ToGapDan = value;
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


		public SqlDouble fSoLuong
		{
			get
			{
				return m_fSoLuong;
			}
			set
			{
				SqlDouble fSoLuongTmp = (SqlDouble)value;
				if(fSoLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuong", "fSoLuong can't be NULL");
				}
				m_fSoLuong = value;
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


		public SqlBoolean bCheck_ThanhPham
		{
			get
			{
				return m_bCheck_ThanhPham;
			}
			set
			{
				SqlBoolean bCheck_ThanhPhamTmp = (SqlBoolean)value;
				if(bCheck_ThanhPhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_ThanhPham", "bCheck_ThanhPham can't be NULL");
				}
				m_bCheck_ThanhPham = value;
			}
		}


		public SqlBoolean bCheck_VatTu_Chinh
		{
			get
			{
				return m_bCheck_VatTu_Chinh;
			}
			set
			{
				SqlBoolean bCheck_VatTu_ChinhTmp = (SqlBoolean)value;
				if(bCheck_VatTu_ChinhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_VatTu_Chinh", "bCheck_VatTu_Chinh can't be NULL");
				}
				m_bCheck_VatTu_Chinh = value;
			}
		}


		public SqlBoolean bCheck_VatTu_Phu
		{
			get
			{
				return m_bCheck_VatTu_Phu;
			}
			set
			{
				SqlBoolean bCheck_VatTu_PhuTmp = (SqlBoolean)value;
				if(bCheck_VatTu_PhuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_VatTu_Phu", "bCheck_VatTu_Phu can't be NULL");
				}
				m_bCheck_VatTu_Phu = value;
			}
		}
		#endregion
	}
}
