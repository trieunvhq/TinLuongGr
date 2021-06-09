using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsBanHang_tbBanHang : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTrangThaiBanHang, m_bCheck_BaoVe, m_bTrangThai_KhoThanhPham, m_bNgungTheoDoi, m_bTonTai, m_bCheck_LaiXe, m_bTienUSD, m_bDaXong;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fTienVAT, m_fPhanTramVAT, m_fTongTienHangChuaVAT, m_fTongTienHangCoVAT, m_fTiGia;
			private SqlInt32		m_iID_BanHang, m_iID_KeHoachSanXuat, m_iID_NguoiBan, m_iID_KhachHang, m_iID_TKNo, m_iID_TKVAT, m_iID_TKCo;
			private SqlString		m_sSoChungTu, m_sMaSoCongTeNo, m_sSoHoaDon, m_sDienGiai, m_sThamChieu;
		#endregion


		public clsBanHang_tbBanHang()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_BanHang_tbBanHang_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHoaDon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHoaDon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHangChuaVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHangChuaVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHangCoVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHangCoVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiBan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiBan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKVAT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTienVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTienVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiBanHang", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiBanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThai_KhoThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThai_KhoThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bcheck_BaoVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bcheck_LaiXe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaSoCongTeNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaSoCongTeNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_BanHang = (SqlInt32)scmCmdToExecute.Parameters["@iID_BanHang"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_BanHang_tbBanHang_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsBanHang_tbBanHang::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_BanHang_tbBanHang_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHoaDon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHoaDon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHangChuaVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHangChuaVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHangCoVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHangCoVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiBan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiBan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKVAT", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTienVAT", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTienVAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiBanHang", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiBanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThai_KhoThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThai_KhoThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bcheck_BaoVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bcheck_LaiXe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaSoCongTeNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaSoCongTeNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_BanHang_tbBanHang_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsBanHang_tbBanHang::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_BanHang_tbBanHang_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_BanHang_tbBanHang_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsBanHang_tbBanHang::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_BanHang_tbBanHang_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("BanHang_tbBanHang");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_BanHang_tbBanHang_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_BanHang = (Int32)dtToReturn.Rows[0]["ID_BanHang"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_sSoHoaDon = (string)dtToReturn.Rows[0]["SoHoaDon"];
					m_iID_KhachHang = (Int32)dtToReturn.Rows[0]["ID_KhachHang"];
					m_fTongTienHangChuaVAT = (double)dtToReturn.Rows[0]["TongTienHangChuaVAT"];
					m_fTongTienHangCoVAT = (double)dtToReturn.Rows[0]["TongTienHangCoVAT"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iID_NguoiBan = (Int32)dtToReturn.Rows[0]["ID_NguoiBan"];
					m_iID_TKNo = dtToReturn.Rows[0]["ID_TKNo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKNo"];
					m_iID_TKCo = dtToReturn.Rows[0]["ID_TKCo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKCo"];
					m_iID_TKVAT = dtToReturn.Rows[0]["ID_TKVAT"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKVAT"];
					m_bTienUSD = (bool)dtToReturn.Rows[0]["TienUSD"];
					m_fPhanTramVAT = (double)dtToReturn.Rows[0]["PhanTramVAT"];
					m_fTienVAT = (double)dtToReturn.Rows[0]["TienVAT"];
					m_bTrangThaiBanHang = (bool)dtToReturn.Rows[0]["TrangThaiBanHang"];
					m_bTrangThai_KhoThanhPham = (bool)dtToReturn.Rows[0]["TrangThai_KhoThanhPham"];
					m_bCheck_BaoVe = (bool)dtToReturn.Rows[0]["check_BaoVe"];
					m_bCheck_LaiXe = (bool)dtToReturn.Rows[0]["check_LaiXe"];
					m_sThamChieu = (string)dtToReturn.Rows[0]["ThamChieu"];
					m_bDaXong = (bool)dtToReturn.Rows[0]["DaXong"];
					m_iID_KeHoachSanXuat = dtToReturn.Rows[0]["ID_KeHoachSanXuat"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_KeHoachSanXuat"];
					m_sMaSoCongTeNo = (string)dtToReturn.Rows[0]["MaSoCongTeNo"];
					m_fTiGia = (double)dtToReturn.Rows[0]["TiGia"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsBanHang_tbBanHang::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_BanHang_tbBanHang_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("BanHang_tbBanHang");
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
					throw new Exception("Stored Procedure 'pr_BanHang_tbBanHang_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsBanHang_tbBanHang::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_BanHang
		{
			get
			{
				return m_iID_BanHang;
			}
			set
			{
				SqlInt32 iID_BanHangTmp = (SqlInt32)value;
				if(iID_BanHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_BanHang", "iID_BanHang can't be NULL");
				}
				m_iID_BanHang = value;
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


		public SqlString sSoHoaDon
		{
			get
			{
				return m_sSoHoaDon;
			}
			set
			{
				SqlString sSoHoaDonTmp = (SqlString)value;
				if(sSoHoaDonTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoHoaDon", "sSoHoaDon can't be NULL");
				}
				m_sSoHoaDon = value;
			}
		}


		public SqlInt32 iID_KhachHang
		{
			get
			{
				return m_iID_KhachHang;
			}
			set
			{
				SqlInt32 iID_KhachHangTmp = (SqlInt32)value;
				if(iID_KhachHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_KhachHang", "iID_KhachHang can't be NULL");
				}
				m_iID_KhachHang = value;
			}
		}


		public SqlDouble fTongTienHangChuaVAT
		{
			get
			{
				return m_fTongTienHangChuaVAT;
			}
			set
			{
				SqlDouble fTongTienHangChuaVATTmp = (SqlDouble)value;
				if(fTongTienHangChuaVATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTongTienHangChuaVAT", "fTongTienHangChuaVAT can't be NULL");
				}
				m_fTongTienHangChuaVAT = value;
			}
		}


		public SqlDouble fTongTienHangCoVAT
		{
			get
			{
				return m_fTongTienHangCoVAT;
			}
			set
			{
				SqlDouble fTongTienHangCoVATTmp = (SqlDouble)value;
				if(fTongTienHangCoVATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTongTienHangCoVAT", "fTongTienHangCoVAT can't be NULL");
				}
				m_fTongTienHangCoVAT = value;
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


		public SqlInt32 iID_NguoiBan
		{
			get
			{
				return m_iID_NguoiBan;
			}
			set
			{
				SqlInt32 iID_NguoiBanTmp = (SqlInt32)value;
				if(iID_NguoiBanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NguoiBan", "iID_NguoiBan can't be NULL");
				}
				m_iID_NguoiBan = value;
			}
		}


		public SqlInt32 iID_TKNo
		{
			get
			{
				return m_iID_TKNo;
			}
			set
			{
				SqlInt32 iID_TKNoTmp = (SqlInt32)value;
				if(iID_TKNoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TKNo", "iID_TKNo can't be NULL");
				}
				m_iID_TKNo = value;
			}
		}


		public SqlInt32 iID_TKCo
		{
			get
			{
				return m_iID_TKCo;
			}
			set
			{
				SqlInt32 iID_TKCoTmp = (SqlInt32)value;
				if(iID_TKCoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TKCo", "iID_TKCo can't be NULL");
				}
				m_iID_TKCo = value;
			}
		}


		public SqlInt32 iID_TKVAT
		{
			get
			{
				return m_iID_TKVAT;
			}
			set
			{
				SqlInt32 iID_TKVATTmp = (SqlInt32)value;
				if(iID_TKVATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TKVAT", "iID_TKVAT can't be NULL");
				}
				m_iID_TKVAT = value;
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


		public SqlDouble fPhanTramVAT
		{
			get
			{
				return m_fPhanTramVAT;
			}
			set
			{
				SqlDouble fPhanTramVATTmp = (SqlDouble)value;
				if(fPhanTramVATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fPhanTramVAT", "fPhanTramVAT can't be NULL");
				}
				m_fPhanTramVAT = value;
			}
		}


		public SqlDouble fTienVAT
		{
			get
			{
				return m_fTienVAT;
			}
			set
			{
				SqlDouble fTienVATTmp = (SqlDouble)value;
				if(fTienVATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTienVAT", "fTienVAT can't be NULL");
				}
				m_fTienVAT = value;
			}
		}


		public SqlBoolean bTrangThaiBanHang
		{
			get
			{
				return m_bTrangThaiBanHang;
			}
			set
			{
				SqlBoolean bTrangThaiBanHangTmp = (SqlBoolean)value;
				if(bTrangThaiBanHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiBanHang", "bTrangThaiBanHang can't be NULL");
				}
				m_bTrangThaiBanHang = value;
			}
		}


		public SqlBoolean bTrangThai_KhoThanhPham
		{
			get
			{
				return m_bTrangThai_KhoThanhPham;
			}
			set
			{
				SqlBoolean bTrangThai_KhoThanhPhamTmp = (SqlBoolean)value;
				if(bTrangThai_KhoThanhPhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThai_KhoThanhPham", "bTrangThai_KhoThanhPham can't be NULL");
				}
				m_bTrangThai_KhoThanhPham = value;
			}
		}


		public SqlBoolean bCheck_BaoVe
		{
			get
			{
				return m_bCheck_BaoVe;
			}
			set
			{
				SqlBoolean bCheck_BaoVeTmp = (SqlBoolean)value;
				if(bCheck_BaoVeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_BaoVe", "bCheck_BaoVe can't be NULL");
				}
				m_bCheck_BaoVe = value;
			}
		}


		public SqlBoolean bCheck_LaiXe
		{
			get
			{
				return m_bCheck_LaiXe;
			}
			set
			{
				SqlBoolean bCheck_LaiXeTmp = (SqlBoolean)value;
				if(bCheck_LaiXeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_LaiXe", "bCheck_LaiXe can't be NULL");
				}
				m_bCheck_LaiXe = value;
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


		public SqlBoolean bDaXong
		{
			get
			{
				return m_bDaXong;
			}
			set
			{
				SqlBoolean bDaXongTmp = (SqlBoolean)value;
				if(bDaXongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaXong", "bDaXong can't be NULL");
				}
				m_bDaXong = value;
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


		public SqlString sMaSoCongTeNo
		{
			get
			{
				return m_sMaSoCongTeNo;
			}
			set
			{
				SqlString sMaSoCongTeNoTmp = (SqlString)value;
				if(sMaSoCongTeNoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaSoCongTeNo", "sMaSoCongTeNo can't be NULL");
				}
				m_sMaSoCongTeNo = value;
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
		#endregion
	}
}
