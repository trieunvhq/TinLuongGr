using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDinhMuc_tbDinhMuc_DOT : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTonTai, m_bKhoa;
			private SqlDateTime		m_daNgayThang;
			private SqlDouble		m_fDoCao, m_fSoLuongQuyDoi, m_fPhePham, m_fQuyRaKien, m_fSoKG_MotBao, m_fSoKienMotBao, m_fTrongLuongKiemTra, m_fSoLuongKiemTra;
			private SqlInt32		m_iID_VTHH, m_iID_DinhMuc_Dot, m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;
			private SqlString		m_sGhiChu, m_sDonViQuyDoi, m_sLoaiGiay, m_sSoHieu, m_sCa;
		#endregion


		public clsDinhMuc_tbDinhMuc_DOT()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_tbDinhMuc_DOT_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCa", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiGiay", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiGiay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongKiemTra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongKiemTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTrongLuongKiemTra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTrongLuongKiemTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonViQuyDoi", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonViQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fQuyRaKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fQuyRaKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKG_MotBao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKG_MotBao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKienMotBao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKienMotBao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Dot", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_DinhMuc_Dot = (SqlInt32)scmCmdToExecute.Parameters["@iID_DinhMuc_Dot"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_tbDinhMuc_DOT_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_tbDinhMuc_DOT::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_tbDinhMuc_DOT_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Dot", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCa", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiGiay", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiGiay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongKiemTra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongKiemTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTrongLuongKiemTra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTrongLuongKiemTra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonViQuyDoi", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonViQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fQuyRaKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fQuyRaKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKG_MotBao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKG_MotBao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKienMotBao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKienMotBao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_tbDinhMuc_DOT_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_tbDinhMuc_DOT::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_tbDinhMuc_DOT_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Dot", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_tbDinhMuc_DOT_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_tbDinhMuc_DOT::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_tbDinhMuc_DOT_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DinhMuc_tbDinhMuc_DOT");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Dot", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DinhMuc_tbDinhMuc_DOT_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_DinhMuc_Dot = (Int32)dtToReturn.Rows[0]["ID_DinhMuc_Dot"];
					m_daNgayThang = (DateTime)dtToReturn.Rows[0]["NgayThang"];
					m_sCa = (string)dtToReturn.Rows[0]["Ca"];
					m_sSoHieu = (string)dtToReturn.Rows[0]["SoHieu"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_sLoaiGiay = (string)dtToReturn.Rows[0]["LoaiGiay"];
					m_fSoLuongKiemTra = (double)dtToReturn.Rows[0]["SoLuongKiemTra"];
					m_fTrongLuongKiemTra = (double)dtToReturn.Rows[0]["TrongLuongKiemTra"];
					m_fSoLuongQuyDoi = (double)dtToReturn.Rows[0]["SoLuongQuyDoi"];
					m_sDonViQuyDoi = (string)dtToReturn.Rows[0]["DonViQuyDoi"];
					m_fQuyRaKien = (double)dtToReturn.Rows[0]["QuyRaKien"];
					m_fPhePham = (double)dtToReturn.Rows[0]["PhePham"];
					m_fDoCao = (double)dtToReturn.Rows[0]["DoCao"];
					m_fSoKG_MotBao = (double)dtToReturn.Rows[0]["SoKG_MotBao"];
					m_fSoKienMotBao = (double)dtToReturn.Rows[0]["SoKienMotBao"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bKhoa = (bool)dtToReturn.Rows[0]["Khoa"];
					m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = (Int32)dtToReturn.Rows[0]["HangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_tbDinhMuc_DOT::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DinhMuc_tbDinhMuc_DOT_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DinhMuc_tbDinhMuc_DOT");
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
					throw new Exception("Stored Procedure 'pr_DinhMuc_tbDinhMuc_DOT_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDinhMuc_tbDinhMuc_DOT::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_DinhMuc_Dot
		{
			get
			{
				return m_iID_DinhMuc_Dot;
			}
			set
			{
				SqlInt32 iID_DinhMuc_DotTmp = (SqlInt32)value;
				if(iID_DinhMuc_DotTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMuc_Dot", "iID_DinhMuc_Dot can't be NULL");
				}
				m_iID_DinhMuc_Dot = value;
			}
		}


		public SqlDateTime daNgayThang
		{
			get
			{
				return m_daNgayThang;
			}
			set
			{
				SqlDateTime daNgayThangTmp = (SqlDateTime)value;
				if(daNgayThangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayThang", "daNgayThang can't be NULL");
				}
				m_daNgayThang = value;
			}
		}


		public SqlString sCa
		{
			get
			{
				return m_sCa;
			}
			set
			{
				SqlString sCaTmp = (SqlString)value;
				if(sCaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sCa", "sCa can't be NULL");
				}
				m_sCa = value;
			}
		}


		public SqlString sSoHieu
		{
			get
			{
				return m_sSoHieu;
			}
			set
			{
				SqlString sSoHieuTmp = (SqlString)value;
				if(sSoHieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoHieu", "sSoHieu can't be NULL");
				}
				m_sSoHieu = value;
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


		public SqlString sLoaiGiay
		{
			get
			{
				return m_sLoaiGiay;
			}
			set
			{
				SqlString sLoaiGiayTmp = (SqlString)value;
				if(sLoaiGiayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sLoaiGiay", "sLoaiGiay can't be NULL");
				}
				m_sLoaiGiay = value;
			}
		}


		public SqlDouble fSoLuongKiemTra
		{
			get
			{
				return m_fSoLuongKiemTra;
			}
			set
			{
				SqlDouble fSoLuongKiemTraTmp = (SqlDouble)value;
				if(fSoLuongKiemTraTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongKiemTra", "fSoLuongKiemTra can't be NULL");
				}
				m_fSoLuongKiemTra = value;
			}
		}


		public SqlDouble fTrongLuongKiemTra
		{
			get
			{
				return m_fTrongLuongKiemTra;
			}
			set
			{
				SqlDouble fTrongLuongKiemTraTmp = (SqlDouble)value;
				if(fTrongLuongKiemTraTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTrongLuongKiemTra", "fTrongLuongKiemTra can't be NULL");
				}
				m_fTrongLuongKiemTra = value;
			}
		}


		public SqlDouble fSoLuongQuyDoi
		{
			get
			{
				return m_fSoLuongQuyDoi;
			}
			set
			{
				SqlDouble fSoLuongQuyDoiTmp = (SqlDouble)value;
				if(fSoLuongQuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongQuyDoi", "fSoLuongQuyDoi can't be NULL");
				}
				m_fSoLuongQuyDoi = value;
			}
		}


		public SqlString sDonViQuyDoi
		{
			get
			{
				return m_sDonViQuyDoi;
			}
			set
			{
				SqlString sDonViQuyDoiTmp = (SqlString)value;
				if(sDonViQuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDonViQuyDoi", "sDonViQuyDoi can't be NULL");
				}
				m_sDonViQuyDoi = value;
			}
		}


		public SqlDouble fQuyRaKien
		{
			get
			{
				return m_fQuyRaKien;
			}
			set
			{
				SqlDouble fQuyRaKienTmp = (SqlDouble)value;
				if(fQuyRaKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fQuyRaKien", "fQuyRaKien can't be NULL");
				}
				m_fQuyRaKien = value;
			}
		}


		public SqlDouble fPhePham
		{
			get
			{
				return m_fPhePham;
			}
			set
			{
				SqlDouble fPhePhamTmp = (SqlDouble)value;
				if(fPhePhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fPhePham", "fPhePham can't be NULL");
				}
				m_fPhePham = value;
			}
		}


		public SqlDouble fDoCao
		{
			get
			{
				return m_fDoCao;
			}
			set
			{
				SqlDouble fDoCaoTmp = (SqlDouble)value;
				if(fDoCaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDoCao", "fDoCao can't be NULL");
				}
				m_fDoCao = value;
			}
		}


		public SqlDouble fSoKG_MotBao
		{
			get
			{
				return m_fSoKG_MotBao;
			}
			set
			{
				SqlDouble fSoKG_MotBaoTmp = (SqlDouble)value;
				if(fSoKG_MotBaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoKG_MotBao", "fSoKG_MotBao can't be NULL");
				}
				m_fSoKG_MotBao = value;
			}
		}


		public SqlDouble fSoKienMotBao
		{
			get
			{
				return m_fSoKienMotBao;
			}
			set
			{
				SqlDouble fSoKienMotBaoTmp = (SqlDouble)value;
				if(fSoKienMotBaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoKienMotBao", "fSoKienMotBao can't be NULL");
				}
				m_fSoKienMotBao = value;
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


		public SqlInt32 iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0
		{
			get
			{
				return m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;
			}
			set
			{
				SqlInt32 iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0Tmp = (SqlInt32)value;
				if(iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0", "iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 can't be NULL");
				}
				m_iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = value;
			}
		}
		#endregion
	}
}
