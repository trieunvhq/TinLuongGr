using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsTbKhachHang : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bNgungTheoDoi, m_bKhoa;
			private SqlInt32		m_iID_KhachHang, m_iID_TaiKhoanKeToan;
			private SqlString		m_sMaSoThue, m_sTenKH, m_sChiNhanh, m_sSoTaiKhoan, m_sMaKH, m_sDaiDien, m_sEmail, m_sSoDienThoai, m_sDienGiai, m_sTinh_ThanhPho, m_sTenNganHang, m_sDiaChi;
		#endregion


		public clsTbKhachHang()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tbKhachHang_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaKH", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaKH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaSoThue", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaSoThue));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenKH", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenKH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDiaChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoDienThoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sEmail));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoTaiKhoan", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenNganHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenNganHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTinh_ThanhPho", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTinh_ThanhPho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sChiNhanh", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sChiNhanh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDaiDien", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDaiDien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_KhachHang = (SqlInt32)scmCmdToExecute.Parameters["@iID_KhachHang"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKhachHang_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKhachHang::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKhachHang_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaKH", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaKH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaSoThue", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaSoThue));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenKH", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenKH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDiaChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoDienThoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sEmail));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoTaiKhoan", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenNganHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenNganHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTinh_ThanhPho", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTinh_ThanhPho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sChiNhanh", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sChiNhanh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDaiDien", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDaiDien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bKhoa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bKhoa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKhachHang_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKhachHang::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKhachHang_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKhachHang_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKhachHang::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKhachHang_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKhachHang");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKhachHang_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_KhachHang = (Int32)dtToReturn.Rows[0]["ID_KhachHang"];
					m_sMaKH = (string)dtToReturn.Rows[0]["MaKH"];
					m_sMaSoThue = (string)dtToReturn.Rows[0]["MaSoThue"];
					m_sTenKH = (string)dtToReturn.Rows[0]["TenKH"];
					m_sDiaChi = (string)dtToReturn.Rows[0]["DiaChi"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_sSoDienThoai = (string)dtToReturn.Rows[0]["SoDienThoai"];
					m_sEmail = (string)dtToReturn.Rows[0]["Email"];
					m_sSoTaiKhoan = (string)dtToReturn.Rows[0]["SoTaiKhoan"];
					m_sTenNganHang = (string)dtToReturn.Rows[0]["TenNganHang"];
					m_sTinh_ThanhPho = (string)dtToReturn.Rows[0]["Tinh_ThanhPho"];
					m_sChiNhanh = (string)dtToReturn.Rows[0]["ChiNhanh"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_sDaiDien = (string)dtToReturn.Rows[0]["DaiDien"];
					m_iID_TaiKhoanKeToan = (Int32)dtToReturn.Rows[0]["ID_TaiKhoanKeToan"];
					m_bKhoa = (bool)dtToReturn.Rows[0]["Khoa"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKhachHang::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKhachHang_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKhachHang");
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
					throw new Exception("Stored Procedure 'pr_tbKhachHang_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKhachHang::SelectAll::Error occured.", ex);
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


		public SqlString sMaKH
		{
			get
			{
				return m_sMaKH;
			}
			set
			{
				SqlString sMaKHTmp = (SqlString)value;
				if(sMaKHTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaKH", "sMaKH can't be NULL");
				}
				m_sMaKH = value;
			}
		}


		public SqlString sMaSoThue
		{
			get
			{
				return m_sMaSoThue;
			}
			set
			{
				SqlString sMaSoThueTmp = (SqlString)value;
				if(sMaSoThueTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaSoThue", "sMaSoThue can't be NULL");
				}
				m_sMaSoThue = value;
			}
		}


		public SqlString sTenKH
		{
			get
			{
				return m_sTenKH;
			}
			set
			{
				SqlString sTenKHTmp = (SqlString)value;
				if(sTenKHTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTenKH", "sTenKH can't be NULL");
				}
				m_sTenKH = value;
			}
		}


		public SqlString sDiaChi
		{
			get
			{
				return m_sDiaChi;
			}
			set
			{
				SqlString sDiaChiTmp = (SqlString)value;
				if(sDiaChiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDiaChi", "sDiaChi can't be NULL");
				}
				m_sDiaChi = value;
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


		public SqlString sSoDienThoai
		{
			get
			{
				return m_sSoDienThoai;
			}
			set
			{
				SqlString sSoDienThoaiTmp = (SqlString)value;
				if(sSoDienThoaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoDienThoai", "sSoDienThoai can't be NULL");
				}
				m_sSoDienThoai = value;
			}
		}


		public SqlString sEmail
		{
			get
			{
				return m_sEmail;
			}
			set
			{
				SqlString sEmailTmp = (SqlString)value;
				if(sEmailTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sEmail", "sEmail can't be NULL");
				}
				m_sEmail = value;
			}
		}


		public SqlString sSoTaiKhoan
		{
			get
			{
				return m_sSoTaiKhoan;
			}
			set
			{
				SqlString sSoTaiKhoanTmp = (SqlString)value;
				if(sSoTaiKhoanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoTaiKhoan", "sSoTaiKhoan can't be NULL");
				}
				m_sSoTaiKhoan = value;
			}
		}


		public SqlString sTenNganHang
		{
			get
			{
				return m_sTenNganHang;
			}
			set
			{
				SqlString sTenNganHangTmp = (SqlString)value;
				if(sTenNganHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTenNganHang", "sTenNganHang can't be NULL");
				}
				m_sTenNganHang = value;
			}
		}


		public SqlString sTinh_ThanhPho
		{
			get
			{
				return m_sTinh_ThanhPho;
			}
			set
			{
				SqlString sTinh_ThanhPhoTmp = (SqlString)value;
				if(sTinh_ThanhPhoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTinh_ThanhPho", "sTinh_ThanhPho can't be NULL");
				}
				m_sTinh_ThanhPho = value;
			}
		}


		public SqlString sChiNhanh
		{
			get
			{
				return m_sChiNhanh;
			}
			set
			{
				SqlString sChiNhanhTmp = (SqlString)value;
				if(sChiNhanhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sChiNhanh", "sChiNhanh can't be NULL");
				}
				m_sChiNhanh = value;
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


		public SqlString sDaiDien
		{
			get
			{
				return m_sDaiDien;
			}
			set
			{
				SqlString sDaiDienTmp = (SqlString)value;
				if(sDaiDienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDaiDien", "sDaiDien can't be NULL");
				}
				m_sDaiDien = value;
			}
		}


		public SqlInt32 iID_TaiKhoanKeToan
		{
			get
			{
				return m_iID_TaiKhoanKeToan;
			}
			set
			{
				SqlInt32 iID_TaiKhoanKeToanTmp = (SqlInt32)value;
				if(iID_TaiKhoanKeToanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TaiKhoanKeToan", "iID_TaiKhoanKeToan can't be NULL");
				}
				m_iID_TaiKhoanKeToan = value;
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
		#endregion
	}
}
