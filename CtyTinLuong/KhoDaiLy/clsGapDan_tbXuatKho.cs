using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsGapDan_tbXuatKho : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bCheckNhapKhoThanhPham, m_bTrangThaiNhapKhoBTP_ThanhPham, m_bDaXuatKho, m_bTonTai;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fSoLuongThanhPham_QuyDoi, m_fDonGia_ThanhPham_QuyDoi, m_fTongTienHang;
			private SqlInt32		m_iID_TKNo, m_iID_XuatKho, m_iID_TKCo, m_iID_DinhMuc_ToGapDan, m_iID_VTHH_ThanhPham_QuyDoi, m_iID_NguoiNhap;
			private SqlString		m_sNguoiGiaoHang, m_sDienGiai, m_sSoChungTu, m_sThamChieu;
		#endregion


		public clsGapDan_tbXuatKho()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_GapDan_tbXuatKho_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_ThanhPham_QuyDoi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_ThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_ThanhPham_QuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_ThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPham_QuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiNhapKhoBTP_ThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiNhapKhoBTP_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNguoiGiaoHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNguoiGiaoHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckNhapKhoThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckNhapKhoThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_XuatKho = (SqlInt32)scmCmdToExecute.Parameters["@iID_XuatKho"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_GapDan_tbXuatKho_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsGapDan_tbXuatKho::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_GapDan_tbXuatKho_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_ToGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_ToGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_ThanhPham_QuyDoi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_ThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_ThanhPham_QuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_ThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPham_QuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPham_QuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiNhapKhoBTP_ThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiNhapKhoBTP_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNguoiGiaoHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNguoiGiaoHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckNhapKhoThanhPham", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckNhapKhoThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_GapDan_tbXuatKho_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsGapDan_tbXuatKho::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_GapDan_tbXuatKho_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_GapDan_tbXuatKho_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsGapDan_tbXuatKho::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_GapDan_tbXuatKho_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("GapDan_tbXuatKho");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_GapDan_tbXuatKho_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_XuatKho = (Int32)dtToReturn.Rows[0]["ID_XuatKho"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_fTongTienHang = (double)dtToReturn.Rows[0]["TongTienHang"];
					m_iID_DinhMuc_ToGapDan = (Int32)dtToReturn.Rows[0]["ID_DinhMuc_ToGapDan"];
					m_iID_VTHH_ThanhPham_QuyDoi = (Int32)dtToReturn.Rows[0]["ID_VTHH_ThanhPham_QuyDoi"];
					m_fDonGia_ThanhPham_QuyDoi = (double)dtToReturn.Rows[0]["DonGia_ThanhPham_QuyDoi"];
					m_fSoLuongThanhPham_QuyDoi = (double)dtToReturn.Rows[0]["SoLuongThanhPham_QuyDoi"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iID_NguoiNhap = (Int32)dtToReturn.Rows[0]["ID_NguoiNhap"];
					m_iID_TKNo = dtToReturn.Rows[0]["ID_TKNo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKNo"];
					m_iID_TKCo = dtToReturn.Rows[0]["ID_TKCo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKCo"];
					m_sThamChieu = (string)dtToReturn.Rows[0]["ThamChieu"];
					m_bDaXuatKho = (bool)dtToReturn.Rows[0]["DaXuatKho"];
					m_bTrangThaiNhapKhoBTP_ThanhPham = (bool)dtToReturn.Rows[0]["TrangThaiNhapKhoBTP_ThanhPham"];
					m_sNguoiGiaoHang = (string)dtToReturn.Rows[0]["NguoiGiaoHang"];
					m_bCheckNhapKhoThanhPham = (bool)dtToReturn.Rows[0]["CheckNhapKhoThanhPham"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsGapDan_tbXuatKho::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_GapDan_tbXuatKho_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("GapDan_tbXuatKho");
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
					throw new Exception("Stored Procedure 'pr_GapDan_tbXuatKho_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsGapDan_tbXuatKho::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_XuatKho
		{
			get
			{
				return m_iID_XuatKho;
			}
			set
			{
				SqlInt32 iID_XuatKhoTmp = (SqlInt32)value;
				if(iID_XuatKhoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_XuatKho", "iID_XuatKho can't be NULL");
				}
				m_iID_XuatKho = value;
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


		public SqlDouble fTongTienHang
		{
			get
			{
				return m_fTongTienHang;
			}
			set
			{
				SqlDouble fTongTienHangTmp = (SqlDouble)value;
				if(fTongTienHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTongTienHang", "fTongTienHang can't be NULL");
				}
				m_fTongTienHang = value;
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


		public SqlInt32 iID_VTHH_ThanhPham_QuyDoi
		{
			get
			{
				return m_iID_VTHH_ThanhPham_QuyDoi;
			}
			set
			{
				SqlInt32 iID_VTHH_ThanhPham_QuyDoiTmp = (SqlInt32)value;
				if(iID_VTHH_ThanhPham_QuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_ThanhPham_QuyDoi", "iID_VTHH_ThanhPham_QuyDoi can't be NULL");
				}
				m_iID_VTHH_ThanhPham_QuyDoi = value;
			}
		}


		public SqlDouble fDonGia_ThanhPham_QuyDoi
		{
			get
			{
				return m_fDonGia_ThanhPham_QuyDoi;
			}
			set
			{
				SqlDouble fDonGia_ThanhPham_QuyDoiTmp = (SqlDouble)value;
				if(fDonGia_ThanhPham_QuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDonGia_ThanhPham_QuyDoi", "fDonGia_ThanhPham_QuyDoi can't be NULL");
				}
				m_fDonGia_ThanhPham_QuyDoi = value;
			}
		}


		public SqlDouble fSoLuongThanhPham_QuyDoi
		{
			get
			{
				return m_fSoLuongThanhPham_QuyDoi;
			}
			set
			{
				SqlDouble fSoLuongThanhPham_QuyDoiTmp = (SqlDouble)value;
				if(fSoLuongThanhPham_QuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongThanhPham_QuyDoi", "fSoLuongThanhPham_QuyDoi can't be NULL");
				}
				m_fSoLuongThanhPham_QuyDoi = value;
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


		public SqlInt32 iID_NguoiNhap
		{
			get
			{
				return m_iID_NguoiNhap;
			}
			set
			{
				SqlInt32 iID_NguoiNhapTmp = (SqlInt32)value;
				if(iID_NguoiNhapTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NguoiNhap", "iID_NguoiNhap can't be NULL");
				}
				m_iID_NguoiNhap = value;
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


		public SqlBoolean bTrangThaiNhapKhoBTP_ThanhPham
		{
			get
			{
				return m_bTrangThaiNhapKhoBTP_ThanhPham;
			}
			set
			{
				SqlBoolean bTrangThaiNhapKhoBTP_ThanhPhamTmp = (SqlBoolean)value;
				if(bTrangThaiNhapKhoBTP_ThanhPhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiNhapKhoBTP_ThanhPham", "bTrangThaiNhapKhoBTP_ThanhPham can't be NULL");
				}
				m_bTrangThaiNhapKhoBTP_ThanhPham = value;
			}
		}


		public SqlString sNguoiGiaoHang
		{
			get
			{
				return m_sNguoiGiaoHang;
			}
			set
			{
				SqlString sNguoiGiaoHangTmp = (SqlString)value;
				if(sNguoiGiaoHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sNguoiGiaoHang", "sNguoiGiaoHang can't be NULL");
				}
				m_sNguoiGiaoHang = value;
			}
		}


		public SqlBoolean bCheckNhapKhoThanhPham
		{
			get
			{
				return m_bCheckNhapKhoThanhPham;
			}
			set
			{
				SqlBoolean bCheckNhapKhoThanhPhamTmp = (SqlBoolean)value;
				if(bCheckNhapKhoThanhPhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheckNhapKhoThanhPham", "bCheckNhapKhoThanhPham can't be NULL");
				}
				m_bCheckNhapKhoThanhPham = value;
			}
		}
		#endregion
	}
}
