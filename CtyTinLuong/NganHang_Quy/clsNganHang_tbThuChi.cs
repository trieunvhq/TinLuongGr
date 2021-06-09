using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsNganHang_tbThuChi : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTienUSD, m_bTonTai, m_bDaGhiSo;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fSoTien, m_fTiGia;
			private SqlInt32		m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4, m_iBienMuaHang1_BanHang2_ConLai_0, m_iID_NguoiLap, m_iID_DoiTuong, m_iID_ThuChi;
			private SqlString		m_sSoChungTu, m_sDoiTuong, m_sThamChieu, m_sDienGiai;
		#endregion


		public clsNganHang_tbThuChi()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDoiTuong", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiLap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiLap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienMuaHang1_BanHang2_ConLai_0", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienMuaHang1_BanHang2_ConLai_0));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ThuChi = (SqlInt32)scmCmdToExecute.Parameters["@iID_ThuChi"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDoiTuong", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiLap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiLap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBienMuaHang1_BanHang2_ConLai_0", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBienMuaHang1_BanHang2_ConLai_0));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_tbThuChi");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThuChi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThuChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ThuChi = (Int32)dtToReturn.Rows[0]["ID_ThuChi"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_fSoTien = (double)dtToReturn.Rows[0]["SoTien"];
					m_sThamChieu = (string)dtToReturn.Rows[0]["ThamChieu"];
					m_iID_DoiTuong = (Int32)dtToReturn.Rows[0]["ID_DoiTuong"];
					m_sDoiTuong = dtToReturn.Rows[0]["DoiTuong"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DoiTuong"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iID_NguoiLap = (Int32)dtToReturn.Rows[0]["ID_NguoiLap"];
					m_bTienUSD = (bool)dtToReturn.Rows[0]["TienUSD"];
					m_fTiGia = (double)dtToReturn.Rows[0]["TiGia"];
					m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = (Int32)dtToReturn.Rows[0]["BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4"];
					m_iBienMuaHang1_BanHang2_ConLai_0 = (Int32)dtToReturn.Rows[0]["BienMuaHang1_BanHang2_ConLai_0"];
					m_bDaGhiSo = (bool)dtToReturn.Rows[0]["DaGhiSo"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_tbThuChi_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_tbThuChi");
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
					throw new Exception("Stored Procedure 'pr_NganHang_tbThuChi_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_tbThuChi::SelectAll::Error occured.", ex);
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


		public SqlDateTime daNgayChungTu
		{
			get
			{
				return m_daNgayChungTu;
			}
			set
			{
				SqlDateTime daNgayChungTuTmp = (SqlDateTime)value;
				if(daNgayChungTuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayChungTu", "daNgayChungTu can't be NULL");
				}
				m_daNgayChungTu = value;
			}
		}


		public SqlString sSoChungTu
		{
			get
			{
				return m_sSoChungTu;
			}
			set
			{
				SqlString sSoChungTuTmp = (SqlString)value;
				if(sSoChungTuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoChungTu", "sSoChungTu can't be NULL");
				}
				m_sSoChungTu = value;
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


		public SqlString sThamChieu
		{
			get
			{
				return m_sThamChieu;
			}
			set
			{
				SqlString sThamChieuTmp = (SqlString)value;
				if(sThamChieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sThamChieu", "sThamChieu can't be NULL");
				}
				m_sThamChieu = value;
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


		public SqlString sDoiTuong
		{
			get
			{
				return m_sDoiTuong;
			}
			set
			{
				SqlString sDoiTuongTmp = (SqlString)value;
				if(sDoiTuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDoiTuong", "sDoiTuong can't be NULL");
				}
				m_sDoiTuong = value;
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


		public SqlInt32 iID_NguoiLap
		{
			get
			{
				return m_iID_NguoiLap;
			}
			set
			{
				SqlInt32 iID_NguoiLapTmp = (SqlInt32)value;
				if(iID_NguoiLapTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NguoiLap", "iID_NguoiLap can't be NULL");
				}
				m_iID_NguoiLap = value;
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


		public SqlInt32 iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4
		{
			get
			{
				return m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4;
			}
			set
			{
				SqlInt32 iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4Tmp = (SqlInt32)value;
				if(iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4", "iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 can't be NULL");
				}
				m_iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = value;
			}
		}


		public SqlInt32 iBienMuaHang1_BanHang2_ConLai_0
		{
			get
			{
				return m_iBienMuaHang1_BanHang2_ConLai_0;
			}
			set
			{
				SqlInt32 iBienMuaHang1_BanHang2_ConLai_0Tmp = (SqlInt32)value;
				if(iBienMuaHang1_BanHang2_ConLai_0Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iBienMuaHang1_BanHang2_ConLai_0", "iBienMuaHang1_BanHang2_ConLai_0 can't be NULL");
				}
				m_iBienMuaHang1_BanHang2_ConLai_0 = value;
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
		#endregion
	}
}
