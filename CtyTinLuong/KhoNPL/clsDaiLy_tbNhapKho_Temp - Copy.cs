using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDaiLy_tbNhapKho_Temp : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTrangThaiXuatNhap_Kho_BTP, m_bTonTai, m_bNgungTheoDoi, m_bTrangThaiXuatNhap_Kho_NPL, m_bTrangThaiXuatNhap_KhoDaiLy, m_bBool_TonDauKy;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fSoLuongThanhPhamQuyDoi, m_fSoLuongXuat_BaoBe, m_fTongTienHang, m_fSoLuongXuat_BaoTo, m_fSoLuongTonThanhPhamQuyDoi;
			private SqlInt32		m_iHangDoT_1_hangNhu_2_ConLai3, m_iID_DaiLy, m_iID_NguoiNhap, m_iID_DinhMucDot_BaoTo, m_iID_NhapKhoDaiLy, m_iID_DinhMucDot_BaoBe, m_iID_VTHH_TPQuyDoi, m_iID_DinhMucNguenPhuLieu;
			private SqlString		m_sGhiChu, m_sDienGiai, m_sThamChieu, m_sSoChungTu;
		#endregion


		public clsDaiLy_tbNhapKho_Temp()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoTo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoBe", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoBe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucNguenPhuLieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucNguenPhuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_TPQuyDoi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_TPQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongTonThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongTonThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_KhoDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_KhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_Kho_BTP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_Kho_BTP));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_Kho_NPL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_Kho_NPL));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bBool_TonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBool_TonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHangDoT_1_hangNhu_2_ConLai3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHangDoT_1_hangNhu_2_ConLai3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_NhapKhoDaiLy = (SqlInt32)scmCmdToExecute.Parameters["@iID_NhapKhoDaiLy"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbNhapKho_Temp_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbNhapKho_Temp::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTongTienHang", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTongTienHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoTo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongXuat_BaoBe", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongXuat_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoTo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucDot_BaoBe", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucDot_BaoBe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucNguenPhuLieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucNguenPhuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_TPQuyDoi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_TPQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongTonThanhPhamQuyDoi", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongTonThanhPhamQuyDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_KhoDaiLy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_KhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_Kho_BTP", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_Kho_BTP));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap_Kho_NPL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap_Kho_NPL));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sThamChieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bBool_TonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBool_TonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
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
					throw new Exception("Stored Procedure 'pr_DaiLy_tbNhapKho_Temp_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbNhapKho_Temp::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbNhapKho_Temp_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbNhapKho_Temp::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbNhapKho_Temp");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDaiLy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDaiLy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DaiLy_tbNhapKho_Temp_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_NhapKhoDaiLy = (Int32)dtToReturn.Rows[0]["ID_NhapKhoDaiLy"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_fTongTienHang = (double)dtToReturn.Rows[0]["TongTienHang"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_fSoLuongXuat_BaoTo = (double)dtToReturn.Rows[0]["SoLuongXuat_BaoTo"];
					m_fSoLuongXuat_BaoBe = (double)dtToReturn.Rows[0]["SoLuongXuat_BaoBe"];
					m_iID_DinhMucDot_BaoTo = (Int32)dtToReturn.Rows[0]["ID_DinhMucDot_BaoTo"];
					m_iID_DinhMucDot_BaoBe = (Int32)dtToReturn.Rows[0]["ID_DinhMucDot_BaoBe"];
					m_iID_DinhMucNguenPhuLieu = (Int32)dtToReturn.Rows[0]["ID_DinhMucNguenPhuLieu"];
					m_iID_VTHH_TPQuyDoi = (Int32)dtToReturn.Rows[0]["ID_VTHH_TPQuyDoi"];
					m_fSoLuongThanhPhamQuyDoi = (double)dtToReturn.Rows[0]["SoLuongThanhPhamQuyDoi"];
					m_fSoLuongTonThanhPhamQuyDoi = (double)dtToReturn.Rows[0]["SoLuongTonThanhPhamQuyDoi"];
					m_iID_NguoiNhap = (Int32)dtToReturn.Rows[0]["ID_NguoiNhap"];
					m_bTrangThaiXuatNhap_KhoDaiLy = (bool)dtToReturn.Rows[0]["TrangThaiXuatNhap_KhoDaiLy"];
					m_bTrangThaiXuatNhap_Kho_BTP = (bool)dtToReturn.Rows[0]["TrangThaiXuatNhap_Kho_BTP"];
					m_bTrangThaiXuatNhap_Kho_NPL = (bool)dtToReturn.Rows[0]["TrangThaiXuatNhap_Kho_NPL"];
					m_iID_DaiLy = (Int32)dtToReturn.Rows[0]["ID_DaiLy"];
					m_sThamChieu = (string)dtToReturn.Rows[0]["ThamChieu"];
					m_bBool_TonDauKy = (bool)dtToReturn.Rows[0]["Bool_TonDauKy"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_iHangDoT_1_hangNhu_2_ConLai3 = (Int32)dtToReturn.Rows[0]["HangDoT_1_hangNhu_2_ConLai3"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbNhapKho_Temp::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DaiLy_tbNhapKho_Temp_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DaiLy_tbNhapKho_Temp");
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
					throw new Exception("Stored Procedure 'pr_DaiLy_tbNhapKho_Temp_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDaiLy_tbNhapKho_Temp::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_NhapKhoDaiLy
		{
			get
			{
				return m_iID_NhapKhoDaiLy;
			}
			set
			{
				SqlInt32 iID_NhapKhoDaiLyTmp = (SqlInt32)value;
				if(iID_NhapKhoDaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NhapKhoDaiLy", "iID_NhapKhoDaiLy can't be NULL");
				}
				m_iID_NhapKhoDaiLy = value;
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


		public SqlInt32 iID_VTHH_TPQuyDoi
		{
			get
			{
				return m_iID_VTHH_TPQuyDoi;
			}
			set
			{
				SqlInt32 iID_VTHH_TPQuyDoiTmp = (SqlInt32)value;
				if(iID_VTHH_TPQuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_TPQuyDoi", "iID_VTHH_TPQuyDoi can't be NULL");
				}
				m_iID_VTHH_TPQuyDoi = value;
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


		public SqlDouble fSoLuongTonThanhPhamQuyDoi
		{
			get
			{
				return m_fSoLuongTonThanhPhamQuyDoi;
			}
			set
			{
				SqlDouble fSoLuongTonThanhPhamQuyDoiTmp = (SqlDouble)value;
				if(fSoLuongTonThanhPhamQuyDoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongTonThanhPhamQuyDoi", "fSoLuongTonThanhPhamQuyDoi can't be NULL");
				}
				m_fSoLuongTonThanhPhamQuyDoi = value;
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


		public SqlBoolean bTrangThaiXuatNhap_KhoDaiLy
		{
			get
			{
				return m_bTrangThaiXuatNhap_KhoDaiLy;
			}
			set
			{
				SqlBoolean bTrangThaiXuatNhap_KhoDaiLyTmp = (SqlBoolean)value;
				if(bTrangThaiXuatNhap_KhoDaiLyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiXuatNhap_KhoDaiLy", "bTrangThaiXuatNhap_KhoDaiLy can't be NULL");
				}
				m_bTrangThaiXuatNhap_KhoDaiLy = value;
			}
		}


		public SqlBoolean bTrangThaiXuatNhap_Kho_BTP
		{
			get
			{
				return m_bTrangThaiXuatNhap_Kho_BTP;
			}
			set
			{
				SqlBoolean bTrangThaiXuatNhap_Kho_BTPTmp = (SqlBoolean)value;
				if(bTrangThaiXuatNhap_Kho_BTPTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiXuatNhap_Kho_BTP", "bTrangThaiXuatNhap_Kho_BTP can't be NULL");
				}
				m_bTrangThaiXuatNhap_Kho_BTP = value;
			}
		}


		public SqlBoolean bTrangThaiXuatNhap_Kho_NPL
		{
			get
			{
				return m_bTrangThaiXuatNhap_Kho_NPL;
			}
			set
			{
				SqlBoolean bTrangThaiXuatNhap_Kho_NPLTmp = (SqlBoolean)value;
				if(bTrangThaiXuatNhap_Kho_NPLTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiXuatNhap_Kho_NPL", "bTrangThaiXuatNhap_Kho_NPL can't be NULL");
				}
				m_bTrangThaiXuatNhap_Kho_NPL = value;
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


		public SqlBoolean bBool_TonDauKy
		{
			get
			{
				return m_bBool_TonDauKy;
			}
			set
			{
				SqlBoolean bBool_TonDauKyTmp = (SqlBoolean)value;
				if(bBool_TonDauKyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBool_TonDauKy", "bBool_TonDauKy can't be NULL");
				}
				m_bBool_TonDauKy = value;
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
