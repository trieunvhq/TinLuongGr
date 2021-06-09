using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsPhieu_tbPhieu : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDaKetThuc, m_bNgungTheoDoi, m_bCheck_In, m_bCheck_Dot, m_bCheck_Cat, m_bGuiDuLieu, m_bTonTai;
			private SqlDateTime		m_daNgayLapPhieu;
			private SqlInt32		m_iBienTrangThai, m_iID_CaTruong, m_iID_SoPhieu;
			private SqlString		m_sCaSanXuat, m_sMaPhieu, m_sGhiChu;
		#endregion


		public clsPhieu_tbPhieu()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_tbPhieu_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaPhieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayLapPhieu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayLapPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CaTruong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CaTruong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCaSanXuat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCaSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_In", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_In));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_Cat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_Cat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_Dot", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienTrangThai", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienTrangThai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaKetThuc", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaKetThuc));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_SoPhieu = (SqlInt32)scmCmdToExecute.Parameters["@iID_SoPhieu"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_tbPhieu_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_tbPhieu::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_tbPhieu_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaPhieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayLapPhieu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayLapPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CaTruong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CaTruong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCaSanXuat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCaSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_In", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_In));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_Cat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_Cat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_Dot", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienTrangThai", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienTrangThai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaKetThuc", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaKetThuc));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_tbPhieu_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_tbPhieu::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_tbPhieu_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_tbPhieu_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_tbPhieu::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_tbPhieu_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Phieu_tbPhieu");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_tbPhieu_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_SoPhieu = (Int32)dtToReturn.Rows[0]["ID_SoPhieu"];
					m_sMaPhieu = (string)dtToReturn.Rows[0]["MaPhieu"];
					m_daNgayLapPhieu = (DateTime)dtToReturn.Rows[0]["NgayLapPhieu"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bGuiDuLieu = (bool)dtToReturn.Rows[0]["GuiDuLieu"];
					m_iID_CaTruong = (Int32)dtToReturn.Rows[0]["ID_CaTruong"];
					m_sCaSanXuat = (string)dtToReturn.Rows[0]["CaSanXuat"];
					m_bCheck_In = (bool)dtToReturn.Rows[0]["Check_In"];
					m_bCheck_Cat = (bool)dtToReturn.Rows[0]["Check_Cat"];
					m_bCheck_Dot = (bool)dtToReturn.Rows[0]["Check_Dot"];
					m_iBienTrangThai = (Int32)dtToReturn.Rows[0]["BienTrangThai"];
					m_bDaKetThuc = (bool)dtToReturn.Rows[0]["DaKetThuc"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_tbPhieu::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_tbPhieu_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Phieu_tbPhieu");
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
					throw new Exception("Stored Procedure 'pr_Phieu_tbPhieu_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_tbPhieu::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_SoPhieu
		{
			get
			{
				return m_iID_SoPhieu;
			}
			set
			{
				SqlInt32 iID_SoPhieuTmp = (SqlInt32)value;
				if(iID_SoPhieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_SoPhieu", "iID_SoPhieu can't be NULL");
				}
				m_iID_SoPhieu = value;
			}
		}


		public SqlString sMaPhieu
		{
			get
			{
				return m_sMaPhieu;
			}
			set
			{
				SqlString sMaPhieuTmp = (SqlString)value;
				if(sMaPhieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaPhieu", "sMaPhieu can't be NULL");
				}
				m_sMaPhieu = value;
			}
		}


		public SqlDateTime daNgayLapPhieu
		{
			get
			{
				return m_daNgayLapPhieu;
			}
			set
			{
				SqlDateTime daNgayLapPhieuTmp = (SqlDateTime)value;
				if(daNgayLapPhieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayLapPhieu", "daNgayLapPhieu can't be NULL");
				}
				m_daNgayLapPhieu = value;
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


		public SqlBoolean bGuiDuLieu
		{
			get
			{
				return m_bGuiDuLieu;
			}
			set
			{
				SqlBoolean bGuiDuLieuTmp = (SqlBoolean)value;
				if(bGuiDuLieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bGuiDuLieu", "bGuiDuLieu can't be NULL");
				}
				m_bGuiDuLieu = value;
			}
		}


		public SqlInt32 iID_CaTruong
		{
			get
			{
				return m_iID_CaTruong;
			}
			set
			{
				SqlInt32 iID_CaTruongTmp = (SqlInt32)value;
				if(iID_CaTruongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_CaTruong", "iID_CaTruong can't be NULL");
				}
				m_iID_CaTruong = value;
			}
		}


		public SqlString sCaSanXuat
		{
			get
			{
				return m_sCaSanXuat;
			}
			set
			{
				SqlString sCaSanXuatTmp = (SqlString)value;
				if(sCaSanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sCaSanXuat", "sCaSanXuat can't be NULL");
				}
				m_sCaSanXuat = value;
			}
		}


		public SqlBoolean bCheck_In
		{
			get
			{
				return m_bCheck_In;
			}
			set
			{
				SqlBoolean bCheck_InTmp = (SqlBoolean)value;
				if(bCheck_InTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_In", "bCheck_In can't be NULL");
				}
				m_bCheck_In = value;
			}
		}


		public SqlBoolean bCheck_Cat
		{
			get
			{
				return m_bCheck_Cat;
			}
			set
			{
				SqlBoolean bCheck_CatTmp = (SqlBoolean)value;
				if(bCheck_CatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_Cat", "bCheck_Cat can't be NULL");
				}
				m_bCheck_Cat = value;
			}
		}


		public SqlBoolean bCheck_Dot
		{
			get
			{
				return m_bCheck_Dot;
			}
			set
			{
				SqlBoolean bCheck_DotTmp = (SqlBoolean)value;
				if(bCheck_DotTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_Dot", "bCheck_Dot can't be NULL");
				}
				m_bCheck_Dot = value;
			}
		}


		public SqlInt32 iBienTrangThai
		{
			get
			{
				return m_iBienTrangThai;
			}
			set
			{
				SqlInt32 iBienTrangThaiTmp = (SqlInt32)value;
				if(iBienTrangThaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iBienTrangThai", "iBienTrangThai can't be NULL");
				}
				m_iBienTrangThai = value;
			}
		}


		public SqlBoolean bDaKetThuc
		{
			get
			{
				return m_bDaKetThuc;
			}
			set
			{
				SqlBoolean bDaKetThucTmp = (SqlBoolean)value;
				if(bDaKetThucTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaKetThuc", "bDaKetThuc can't be NULL");
				}
				m_bDaKetThuc = value;
			}
		}
		#endregion
	}
}
