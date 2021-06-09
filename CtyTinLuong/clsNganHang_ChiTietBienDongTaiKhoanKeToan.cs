using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsNganHang_ChiTietBienDongTaiKhoanKeToan : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDaGhiSo, m_bNgungTheoDoi, m_bBBool_TonDauKy, m_bTienUSD, m_bTonTai;
			private SqlDateTime		m_daNgayThang;
			private SqlDouble		m_fNo, m_fCo, m_fTiGia;
			private SqlInt32		m_iTrangThai_MuaHang1_BanHang2_VAT3, m_iID_ChungTu, m_iID_DoiTuong, m_iID_ChiTietBienDongTaiKhoan, m_iID_TaiKhoanKeToanCon;
			private SqlString		m_sDienGiai, m_sSoChungTu;
		#endregion


		public clsNganHang_ChiTietBienDongTaiKhoanKeToan()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChungTu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fCo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbBool_TonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBBool_TonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iTrangThai_MuaHang1_BanHang2_VAT3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iTrangThai_MuaHang1_BanHang2_VAT3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietBienDongTaiKhoan", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietBienDongTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietBienDongTaiKhoan = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietBienDongTaiKhoan"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_ChiTietBienDongTaiKhoanKeToan::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietBienDongTaiKhoan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietBienDongTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChungTu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DoiTuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DoiTuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_TaiKhoanKeToanCon", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_TaiKhoanKeToanCon));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fCo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fCo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTienUSD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTienUSD));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTiGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTiGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaGhiSo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaGhiSo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbBool_TonDauKy", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBBool_TonDauKy));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iTrangThai_MuaHang1_BanHang2_VAT3", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iTrangThai_MuaHang1_BanHang2_VAT3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_ChiTietBienDongTaiKhoanKeToan::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietBienDongTaiKhoan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietBienDongTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_ChiTietBienDongTaiKhoanKeToan_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_ChiTietBienDongTaiKhoanKeToan::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_ChiTietBienDongTaiKhoanKeToan_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_ChiTietBienDongTaiKhoanKeToan");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietBienDongTaiKhoan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietBienDongTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_NganHang_ChiTietBienDongTaiKhoanKeToan_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietBienDongTaiKhoan = (Int32)dtToReturn.Rows[0]["ID_ChiTietBienDongTaiKhoan"];
					m_iID_ChungTu = (Int32)dtToReturn.Rows[0]["ID_ChungTu"];
					m_iID_DoiTuong = (Int32)dtToReturn.Rows[0]["ID_DoiTuong"];
					m_sSoChungTu = (string)dtToReturn.Rows[0]["SoChungTu"];
					m_daNgayThang = (DateTime)dtToReturn.Rows[0]["NgayThang"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_iID_TaiKhoanKeToanCon = (Int32)dtToReturn.Rows[0]["ID_TaiKhoanKeToanCon"];
					m_fCo = (double)dtToReturn.Rows[0]["Co"];
					m_fNo = (double)dtToReturn.Rows[0]["No"];
					m_bTienUSD = (bool)dtToReturn.Rows[0]["TienUSD"];
					m_fTiGia = (double)dtToReturn.Rows[0]["TiGia"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bDaGhiSo = (bool)dtToReturn.Rows[0]["DaGhiSo"];
					m_bBBool_TonDauKy = (bool)dtToReturn.Rows[0]["bBool_TonDauKy"];
					m_iTrangThai_MuaHang1_BanHang2_VAT3 = (Int32)dtToReturn.Rows[0]["TrangThai_MuaHang1_BanHang2_VAT3"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_ChiTietBienDongTaiKhoanKeToan::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_NganHang_ChiTietBienDongTaiKhoanKeToan_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("NganHang_ChiTietBienDongTaiKhoanKeToan");
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
					throw new Exception("Stored Procedure 'pr_NganHang_ChiTietBienDongTaiKhoanKeToan_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsNganHang_ChiTietBienDongTaiKhoanKeToan::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietBienDongTaiKhoan
		{
			get
			{
				return m_iID_ChiTietBienDongTaiKhoan;
			}
			set
			{
				SqlInt32 iID_ChiTietBienDongTaiKhoanTmp = (SqlInt32)value;
				if(iID_ChiTietBienDongTaiKhoanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietBienDongTaiKhoan", "iID_ChiTietBienDongTaiKhoan can't be NULL");
				}
				m_iID_ChiTietBienDongTaiKhoan = value;
			}
		}


		public SqlInt32 iID_ChungTu
		{
			get
			{
				return m_iID_ChungTu;
			}
			set
			{
				SqlInt32 iID_ChungTuTmp = (SqlInt32)value;
				if(iID_ChungTuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChungTu", "iID_ChungTu can't be NULL");
				}
				m_iID_ChungTu = value;
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


		public SqlInt32 iID_TaiKhoanKeToanCon
		{
			get
			{
				return m_iID_TaiKhoanKeToanCon;
			}
			set
			{
				SqlInt32 iID_TaiKhoanKeToanConTmp = (SqlInt32)value;
				if(iID_TaiKhoanKeToanConTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_TaiKhoanKeToanCon", "iID_TaiKhoanKeToanCon can't be NULL");
				}
				m_iID_TaiKhoanKeToanCon = value;
			}
		}


		public SqlDouble fCo
		{
			get
			{
				return m_fCo;
			}
			set
			{
				SqlDouble fCoTmp = (SqlDouble)value;
				if(fCoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fCo", "fCo can't be NULL");
				}
				m_fCo = value;
			}
		}


		public SqlDouble fNo
		{
			get
			{
				return m_fNo;
			}
			set
			{
				SqlDouble fNoTmp = (SqlDouble)value;
				if(fNoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNo", "fNo can't be NULL");
				}
				m_fNo = value;
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


		public SqlBoolean bBBool_TonDauKy
		{
			get
			{
				return m_bBBool_TonDauKy;
			}
			set
			{
				SqlBoolean bBBool_TonDauKyTmp = (SqlBoolean)value;
				if(bBBool_TonDauKyTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBBool_TonDauKy", "bBBool_TonDauKy can't be NULL");
				}
				m_bBBool_TonDauKy = value;
			}
		}


		public SqlInt32 iTrangThai_MuaHang1_BanHang2_VAT3
		{
			get
			{
				return m_iTrangThai_MuaHang1_BanHang2_VAT3;
			}
			set
			{
				SqlInt32 iTrangThai_MuaHang1_BanHang2_VAT3Tmp = (SqlInt32)value;
				if(iTrangThai_MuaHang1_BanHang2_VAT3Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iTrangThai_MuaHang1_BanHang2_VAT3", "iTrangThai_MuaHang1_BanHang2_VAT3 can't be NULL");
				}
				m_iTrangThai_MuaHang1_BanHang2_VAT3 = value;
			}
		}
		#endregion
	}
}
