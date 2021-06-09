using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDaiLy_tbXuatKho : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bCheck_LaiXe, m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False, m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe, m_bCheck_BaoVe, m_bCheck_DaiLy, m_bTrangThai_XuatKho_DaiLy_GuiDuLieu, m_bDaXuatKho, m_bTonTai;
			private SqlDateTime		m_daThoiGian_BaoVe, m_daThoiGian_DaiLy, m_daNgayChungTu, m_daThoiGian_KhoiTao, m_daThoiGian_LaiXe;
			private SqlDouble		m_fSoLuongThanhPhamQuyDoi, m_fTongTienHang, m_fSoLuongXuat_BaoBe, m_fDonGia, m_fSoLuongXuat_BaoTo;
			private SqlInt32		m_iHangDoT_1_hangNhu_2_ConLai3, m_iID_ThamChieuNhapKho, m_iID_DinhMucDot_BaoTo, m_iID_DinhMucDot_BaoBe, m_iID_XuatKhoDaiLy, m_iID_VTHH, m_iID_DinhMucNguenPhuLieu, m_iID_TKCo, m_iID_DaiLy, m_iID_TKNo, m_iID_NguoiNhap;
			private SqlString		m_sDienGiai, m_sSoChungTu, m_sGhiChu;
		#endregion


		public clsDaiLy_tbXuatKho()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbXuatKho_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoTo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoBe", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoBe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucNguenPhuLieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucNguenPhuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_BaoVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_LaiXe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_DaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_KhoiTao", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_KhoiTao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_LaiXe", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_BaoVe", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_DaiLy", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThai_XuatKho_DaiLy_GuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThai_XuatKho_DaiLy_GuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieuNhapKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieuNhapKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHangDoT_1_hangNhu_2_ConLai3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHangDoT_1_hangNhu_2_ConLai3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_XuatKhoDaiLy = (SqlInt32)scmCmdToExecute.Parameters["@iID_XuatKhoDaiLy"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbXuatKho_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbXuatKho::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbXuatKho_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoTo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoBe", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoBe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucNguenPhuLieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucNguenPhuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TKCo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TKCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_BaoVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_LaiXe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_DaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_KhoiTao", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_KhoiTao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_LaiXe", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_LaiXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_BaoVe", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_BaoVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daThoiGian_DaiLy", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daThoiGian_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThai_XuatKho_DaiLy_GuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThai_XuatKho_DaiLy_GuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieuNhapKho", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieuNhapKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHangDoT_1_hangNhu_2_ConLai3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHangDoT_1_hangNhu_2_ConLai3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbXuatKho_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbXuatKho::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbXuatKho_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbXuatKho_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbXuatKho::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbXuatKho_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbXuatKho");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbXuatKho_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_XuatKhoDaiLy = (Int32)dtToReturn.Rows[0]["ID_XuatKhoDaiLy"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuongXuat_BaoTo = (double)dtToReturn.Rows[0]["SoLuongXuat_BaoTo"];
					m_fSoLuongXuat_BaoBe = (double)dtToReturn.Rows[0]["SoLuongXuat_BaoBe"];
					m_fSoLuongThanhPhamQuyDoi = (double)dtToReturn.Rows[0]["SoLuongThanhPhamQuyDoi"];
					m_fDonGia = (double)dtToReturn.Rows[0]["DonGia"];
					m_fTongTienHang = (double)dtToReturn.Rows[0]["TongTienHang"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iID_DinhMucDot_BaoTo = (Int32)dtToReturn.Rows[0]["ID_DinhMucDot_BaoTo"];
					m_iID_DinhMucDot_BaoBe = (Int32)dtToReturn.Rows[0]["ID_DinhMucDot_BaoBe"];
					m_iID_DinhMucNguenPhuLieu = (Int32)dtToReturn.Rows[0]["ID_DinhMucNguenPhuLieu"];
					m_iID_NguoiNhap = (Int32)dtToReturn.Rows[0]["ID_NguoiNhap"];
					m_iID_TKNo = dtToReturn.Rows[0]["ID_TKNo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKNo"];
					m_iID_TKCo = dtToReturn.Rows[0]["ID_TKCo"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_TKCo"];
					m_iID_DaiLy = (Int32)dtToReturn.Rows[0]["ID_DaiLy"];
					m_bCheck_BaoVe = (bool)dtToReturn.Rows[0]["Check_BaoVe"];
					m_bCheck_LaiXe = (bool)dtToReturn.Rows[0]["Check_LaiXe"];
					m_bCheck_DaiLy = (bool)dtToReturn.Rows[0]["Check_DaiLy"];
					m_daThoiGian_KhoiTao = dtToReturn.Rows[0]["ThoiGian_KhoiTao"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["ThoiGian_KhoiTao"];
					m_daThoiGian_LaiXe = dtToReturn.Rows[0]["ThoiGian_LaiXe"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["ThoiGian_LaiXe"];
					m_daThoiGian_BaoVe = dtToReturn.Rows[0]["ThoiGian_BaoVe"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["ThoiGian_BaoVe"];
					m_daThoiGian_DaiLy = dtToReturn.Rows[0]["ThoiGian_DaiLy"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["ThoiGian_DaiLy"];
					m_bTrangThai_XuatKho_DaiLy_GuiDuLieu = (bool)dtToReturn.Rows[0]["TrangThai_XuatKho_DaiLy_GuiDuLieu"];
					m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = (bool)dtToReturn.Rows[0]["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"];
					m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = (bool)dtToReturn.Rows[0]["CheckNhapKho_ThanhPham_True_nhapKhoBTP_False"];
					m_bDaXuatKho = (bool)dtToReturn.Rows[0]["DaXuatKho"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_iID_ThamChieuNhapKho = (Int32)dtToReturn.Rows[0]["ID_ThamChieuNhapKho"];
					m_iHangDoT_1_hangNhu_2_ConLai3 = dtToReturn.Rows[0]["HangDoT_1_hangNhu_2_ConLai3"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["HangDoT_1_hangNhu_2_ConLai3"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbXuatKho::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbXuatKho_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbXuatKho");
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
					throw new Exception("Stored Procedure 'pr_DaiLy_tbXuatKho_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbXuatKho::SelectAll::Error occured.", ex);
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


		public SqlDouble fSoLuongXuat_BaoTo
		{
			get
			{
				return m_fSoLuongXuat_BaoTo;
			}
			set
			{
				SqlDouble fSoLuongXuat_BaoToTmp = (SqlDouble)value;
				if(fSoLuongXuat_BaoToTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongXuat_BaoTo", "fSoLuongXuat_BaoTo can't be NULL");
				}
				m_fSoLuongXuat_BaoTo = value;
			}
		}


		public SqlDouble fSoLuongXuat_BaoBe
		{
			get
			{
				return m_fSoLuongXuat_BaoBe;
			}
			set
			{
				SqlDouble fSoLuongXuat_BaoBeTmp = (SqlDouble)value;
				if(fSoLuongXuat_BaoBeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongXuat_BaoBe", "fSoLuongXuat_BaoBe can't be NULL");
				}
				m_fSoLuongXuat_BaoBe = value;
			}
		}


		public SqlDouble fSoLuongThanhPhamQuyDoi
		{
			get
			{
				return m_fSoLuongThanhPhamQuyDoi;
			}
			set
			{
				SqlDouble fSoLuongThanhPhamQuyDoiTmp = (SqlDouble)value;
				if(fSoLuongThanhPhamQuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongThanhPhamQuyDoi", "fSoLuongThanhPhamQuyDoi can't be NULL");
				}
				m_fSoLuongThanhPhamQuyDoi = value;
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


		public SqlInt32 iID_DinhMucDot_BaoTo
		{
			get
			{
				return m_iID_DinhMucDot_BaoTo;
			}
			set
			{
				SqlInt32 iID_DinhMucDot_BaoToTmp = (SqlInt32)value;
				if(iID_DinhMucDot_BaoToTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucDot_BaoTo", "iID_DinhMucDot_BaoTo can't be NULL");
				}
				m_iID_DinhMucDot_BaoTo = value;
			}
		}


		public SqlInt32 iID_DinhMucDot_BaoBe
		{
			get
			{
				return m_iID_DinhMucDot_BaoBe;
			}
			set
			{
				SqlInt32 iID_DinhMucDot_BaoBeTmp = (SqlInt32)value;
				if(iID_DinhMucDot_BaoBeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucDot_BaoBe", "iID_DinhMucDot_BaoBe can't be NULL");
				}
				m_iID_DinhMucDot_BaoBe = value;
			}
		}


		public SqlInt32 iID_DinhMucNguenPhuLieu
		{
			get
			{
				return m_iID_DinhMucNguenPhuLieu;
			}
			set
			{
				SqlInt32 iID_DinhMucNguenPhuLieuTmp = (SqlInt32)value;
				if(iID_DinhMucNguenPhuLieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucNguenPhuLieu", "iID_DinhMucNguenPhuLieu can't be NULL");
				}
				m_iID_DinhMucNguenPhuLieu = value;
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


		public SqlBoolean bCheck_DaiLy
		{
			get
			{
				return m_bCheck_DaiLy;
			}
			set
			{
				SqlBoolean bCheck_DaiLyTmp = (SqlBoolean)value;
				if(bCheck_DaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_DaiLy", "bCheck_DaiLy can't be NULL");
				}
				m_bCheck_DaiLy = value;
			}
		}


		public SqlDateTime daThoiGian_KhoiTao
		{
			get
			{
				return m_daThoiGian_KhoiTao;
			}
			set
			{
				SqlDateTime daThoiGian_KhoiTaoTmp = (SqlDateTime)value;
				if(daThoiGian_KhoiTaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daThoiGian_KhoiTao", "daThoiGian_KhoiTao can't be NULL");
				}
				m_daThoiGian_KhoiTao = value;
			}
		}


		public SqlDateTime daThoiGian_LaiXe
		{
			get
			{
				return m_daThoiGian_LaiXe;
			}
			set
			{
				SqlDateTime daThoiGian_LaiXeTmp = (SqlDateTime)value;
				if(daThoiGian_LaiXeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daThoiGian_LaiXe", "daThoiGian_LaiXe can't be NULL");
				}
				m_daThoiGian_LaiXe = value;
			}
		}


		public SqlDateTime daThoiGian_BaoVe
		{
			get
			{
				return m_daThoiGian_BaoVe;
			}
			set
			{
				SqlDateTime daThoiGian_BaoVeTmp = (SqlDateTime)value;
				if(daThoiGian_BaoVeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daThoiGian_BaoVe", "daThoiGian_BaoVe can't be NULL");
				}
				m_daThoiGian_BaoVe = value;
			}
		}


		public SqlDateTime daThoiGian_DaiLy
		{
			get
			{
				return m_daThoiGian_DaiLy;
			}
			set
			{
				SqlDateTime daThoiGian_DaiLyTmp = (SqlDateTime)value;
				if(daThoiGian_DaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daThoiGian_DaiLy", "daThoiGian_DaiLy can't be NULL");
				}
				m_daThoiGian_DaiLy = value;
			}
		}


		public SqlBoolean bTrangThai_XuatKho_DaiLy_GuiDuLieu
		{
			get
			{
				return m_bTrangThai_XuatKho_DaiLy_GuiDuLieu;
			}
			set
			{
				SqlBoolean bTrangThai_XuatKho_DaiLy_GuiDuLieuTmp = (SqlBoolean)value;
				if(bTrangThai_XuatKho_DaiLy_GuiDuLieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThai_XuatKho_DaiLy_GuiDuLieu", "bTrangThai_XuatKho_DaiLy_GuiDuLieu can't be NULL");
				}
				m_bTrangThai_XuatKho_DaiLy_GuiDuLieu = value;
			}
		}


		public SqlBoolean bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe
		{
			get
			{
				return m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe;
			}
			set
			{
				SqlBoolean bTrangThaiXuatNhap_ThanhPham_TuDaiLyVeTmp = (SqlBoolean)value;
				if(bTrangThaiXuatNhap_ThanhPham_TuDaiLyVeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe", "bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe can't be NULL");
				}
				m_bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = value;
			}
		}


		public SqlBoolean bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False
		{
			get
			{
				return m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False;
			}
			set
			{
				SqlBoolean bCheckNhapKho_ThanhPham_True_nhapKhoBTP_FalseTmp = (SqlBoolean)value;
				if(bCheckNhapKho_ThanhPham_True_nhapKhoBTP_FalseTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False", "bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False can't be NULL");
				}
				m_bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = value;
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


		public SqlInt32 iID_ThamChieuNhapKho
		{
			get
			{
				return m_iID_ThamChieuNhapKho;
			}
			set
			{
				SqlInt32 iID_ThamChieuNhapKhoTmp = (SqlInt32)value;
				if(iID_ThamChieuNhapKhoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ThamChieuNhapKho", "iID_ThamChieuNhapKho can't be NULL");
				}
				m_iID_ThamChieuNhapKho = value;
			}
		}


		public SqlInt32 iHangDoT_1_hangNhu_2_ConLai3
		{
			get
			{
				return m_iHangDoT_1_hangNhu_2_ConLai3;
			}
			set
			{
				SqlInt32 iHangDoT_1_hangNhu_2_ConLai3Tmp = (SqlInt32)value;
				if(iHangDoT_1_hangNhu_2_ConLai3Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iHangDoT_1_hangNhu_2_ConLai3", "iHangDoT_1_hangNhu_2_ConLai3 can't be NULL");
				}
				m_iHangDoT_1_hangNhu_2_ConLai3 = value;
			}
		}
		#endregion
	}
}
