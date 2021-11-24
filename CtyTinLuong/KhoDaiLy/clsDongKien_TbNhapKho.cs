using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDongKien_TbNhapKho : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDaNhapKho, m_bTonTai, m_bBoolTonDauKy, m_bNgungTheoDoi;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fDonGia, m_fThanhTien, m_fSoLuong;
			private SqlInt32		m_iGapDan_1_DaiLy_2, m_iID_XuatKho_ThamChieu, m_iID_NguoiNhap, m_iID_NhapKhoDongKien, m_iID_VTHH;
			private SqlString		m_sSoChungTu, m_sNguoiGiaoHang, m_sDienGiai;
		#endregion


		public clsDongKien_TbNhapKho()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho_ThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fThanhTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fThanhTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaNhapKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaNhapKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNguoiGiaoHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNguoiGiaoHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bboolTonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBoolTonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iGapDan_1_DaiLy_2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iGapDan_1_DaiLy_2));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDongKien", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_NhapKhoDongKien = (SqlInt32)scmCmdToExecute.Parameters["@iID_NhapKhoDongKien"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbNhapKho::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDongKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKho_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKho_ThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiNhap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayChungTu", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fThanhTien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fThanhTien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaNhapKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaNhapKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sNguoiGiaoHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sNguoiGiaoHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bboolTonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBoolTonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iGapDan_1_DaiLy_2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iGapDan_1_DaiLy_2));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbNhapKho::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbNhapKho::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_TbNhapKho");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_NhapKhoDongKien = (Int32)dtToReturn.Rows[0]["ID_NhapKhoDongKien"];
					m_iID_XuatKho_ThamChieu = (Int32)dtToReturn.Rows[0]["ID_XuatKho_ThamChieu"];
					m_iID_NguoiNhap = (Int32)dtToReturn.Rows[0]["ID_NguoiNhap"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_daNgayChungTu = (DateTime)dtToReturn.Rows[0]["NgayChungTu"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuong = (double)dtToReturn.Rows[0]["SoLuong"];
					m_fDonGia = (double)dtToReturn.Rows[0]["DonGia"];
					m_fThanhTien = (double)dtToReturn.Rows[0]["ThanhTien"];
					m_bDaNhapKho = (bool)dtToReturn.Rows[0]["DaNhapKho"];
					m_sNguoiGiaoHang = (string)dtToReturn.Rows[0]["NguoiGiaoHang"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bBoolTonDauKy = (bool)dtToReturn.Rows[0]["boolTonDauKy"];
					m_iGapDan_1_DaiLy_2 = (Int32)dtToReturn.Rows[0]["GapDan_1_DaiLy_2"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbNhapKho::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_TbNhapKho");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbNhapKho::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_NhapKhoDongKien
		{
			get
			{
				return m_iID_NhapKhoDongKien;
			}
			set
			{
				SqlInt32 iID_NhapKhoDongKienTmp = (SqlInt32)value;
				if(iID_NhapKhoDongKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NhapKhoDongKien", "iID_NhapKhoDongKien can't be NULL");
				}
				m_iID_NhapKhoDongKien = value;
			}
		}


		public SqlInt32 iID_XuatKho_ThamChieu
		{
			get
			{
				return m_iID_XuatKho_ThamChieu;
			}
			set
			{
				SqlInt32 iID_XuatKho_ThamChieuTmp = (SqlInt32)value;
				if(iID_XuatKho_ThamChieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_XuatKho_ThamChieu", "iID_XuatKho_ThamChieu can't be NULL");
				}
				m_iID_XuatKho_ThamChieu = value;
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


		public SqlDouble fThanhTien
		{
			get
			{
				return m_fThanhTien;
			}
			set
			{
				SqlDouble fThanhTienTmp = (SqlDouble)value;
				if(fThanhTienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fThanhTien", "fThanhTien can't be NULL");
				}
				m_fThanhTien = value;
			}
		}


		public SqlBoolean bDaNhapKho
		{
			get
			{
				return m_bDaNhapKho;
			}
			set
			{
				SqlBoolean bDaNhapKhoTmp = (SqlBoolean)value;
				if(bDaNhapKhoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaNhapKho", "bDaNhapKho can't be NULL");
				}
				m_bDaNhapKho = value;
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


		public SqlBoolean bBoolTonDauKy
		{
			get
			{
				return m_bBoolTonDauKy;
			}
			set
			{
				SqlBoolean bBoolTonDauKyTmp = (SqlBoolean)value;
				if(bBoolTonDauKyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBoolTonDauKy", "bBoolTonDauKy can't be NULL");
				}
				m_bBoolTonDauKy = value;
			}
		}


		public SqlInt32 iGapDan_1_DaiLy_2
		{
			get
			{
				return m_iGapDan_1_DaiLy_2;
			}
			set
			{
				SqlInt32 iGapDan_1_DaiLy_2Tmp = (SqlInt32)value;
				if(iGapDan_1_DaiLy_2Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iGapDan_1_DaiLy_2", "iGapDan_1_DaiLy_2 can't be NULL");
				}
				m_iGapDan_1_DaiLy_2 = value;
			}
		}
		#endregion
	}
}
