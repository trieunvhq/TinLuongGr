using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsTbKeHoachSanXuat : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bNgungTheoDoi, m_bDaHoanThanh;
			private SqlDateTime		m_daNgayDuKienXuat, m_daNgayXuatThucTe, m_daNgayDatHang;
			private SqlDouble		m_fSoCountner, m_fSoLuongThucXuat, m_fSoLuong;
			private SqlInt32		m_iID_KeHoachSanXuat, m_iID_BanHang, m_iID_KhachHang, m_iID_VTHH;
			private SqlString		m_sQuyCach, m_sDienGiai, m_sGhiChu, m_sMaKeHoach;
		#endregion


		public clsTbKeHoachSanXuat()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayDatHang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayDatHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaKeHoach", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuyCach", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuyCach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayDuKienXuat", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayDuKienXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayXuatThucTe", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayXuatThucTe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThucXuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThucXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoCountner", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoCountner));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaHoanThanh", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaHoanThanh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_KeHoachSanXuat = (SqlInt32)scmCmdToExecute.Parameters["@iID_KeHoachSanXuat"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayDatHang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayDatHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaKeHoach", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaKeHoach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuyCach", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuyCach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayDuKienXuat", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayDuKienXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayXuatThucTe", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayXuatThucTe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongThucXuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongThucXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoCountner", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoCountner));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BanHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_BanHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaHoanThanh", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaHoanThanh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKeHoachSanXuat");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KeHoachSanXuat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KeHoachSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_KeHoachSanXuat = (Int32)dtToReturn.Rows[0]["ID_KeHoachSanXuat"];
					m_daNgayDatHang = (DateTime)dtToReturn.Rows[0]["NgayDatHang"];
					m_sMaKeHoach = (string)dtToReturn.Rows[0]["MaKeHoach"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_iID_KhachHang = (Int32)dtToReturn.Rows[0]["ID_KhachHang"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuong = (double)dtToReturn.Rows[0]["SoLuong"];
					m_sQuyCach = (string)dtToReturn.Rows[0]["QuyCach"];
					m_daNgayDuKienXuat = (DateTime)dtToReturn.Rows[0]["NgayDuKienXuat"];
					m_daNgayXuatThucTe = (DateTime)dtToReturn.Rows[0]["NgayXuatThucTe"];
					m_fSoLuongThucXuat = (double)dtToReturn.Rows[0]["SoLuongThucXuat"];
					m_fSoCountner = (double)dtToReturn.Rows[0]["SoCountner"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iID_BanHang = dtToReturn.Rows[0]["ID_BanHang"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_BanHang"];
					m_bDaHoanThanh = (bool)dtToReturn.Rows[0]["DaHoanThanh"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbKeHoachSanXuat_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbKeHoachSanXuat");
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
					throw new Exception("Stored Procedure 'pr_tbKeHoachSanXuat_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbKeHoachSanXuat::SelectAll::Error occured.", ex);
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


		public SqlDateTime daNgayDatHang
		{
			get
			{
				return m_daNgayDatHang;
			}
			set
			{
				SqlDateTime daNgayDatHangTmp = (SqlDateTime)value;
				if(daNgayDatHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayDatHang", "daNgayDatHang can't be NULL");
				}
				m_daNgayDatHang = value;
			}
		}


		public SqlString sMaKeHoach
		{
			get
			{
				return m_sMaKeHoach;
			}
			set
			{
				SqlString sMaKeHoachTmp = (SqlString)value;
				if(sMaKeHoachTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaKeHoach", "sMaKeHoach can't be NULL");
				}
				m_sMaKeHoach = value;
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


		public SqlString sQuyCach
		{
			get
			{
				return m_sQuyCach;
			}
			set
			{
				SqlString sQuyCachTmp = (SqlString)value;
				if(sQuyCachTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sQuyCach", "sQuyCach can't be NULL");
				}
				m_sQuyCach = value;
			}
		}


		public SqlDateTime daNgayDuKienXuat
		{
			get
			{
				return m_daNgayDuKienXuat;
			}
			set
			{
				SqlDateTime daNgayDuKienXuatTmp = (SqlDateTime)value;
				if(daNgayDuKienXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayDuKienXuat", "daNgayDuKienXuat can't be NULL");
				}
				m_daNgayDuKienXuat = value;
			}
		}


		public SqlDateTime daNgayXuatThucTe
		{
			get
			{
				return m_daNgayXuatThucTe;
			}
			set
			{
				SqlDateTime daNgayXuatThucTeTmp = (SqlDateTime)value;
				if(daNgayXuatThucTeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayXuatThucTe", "daNgayXuatThucTe can't be NULL");
				}
				m_daNgayXuatThucTe = value;
			}
		}


		public SqlDouble fSoLuongThucXuat
		{
			get
			{
				return m_fSoLuongThucXuat;
			}
			set
			{
				SqlDouble fSoLuongThucXuatTmp = (SqlDouble)value;
				if(fSoLuongThucXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongThucXuat", "fSoLuongThucXuat can't be NULL");
				}
				m_fSoLuongThucXuat = value;
			}
		}


		public SqlDouble fSoCountner
		{
			get
			{
				return m_fSoCountner;
			}
			set
			{
				SqlDouble fSoCountnerTmp = (SqlDouble)value;
				if(fSoCountnerTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoCountner", "fSoCountner can't be NULL");
				}
				m_fSoCountner = value;
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


		public SqlBoolean bDaHoanThanh
		{
			get
			{
				return m_bDaHoanThanh;
			}
			set
			{
				SqlBoolean bDaHoanThanhTmp = (SqlBoolean)value;
				if(bDaHoanThanhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaHoanThanh", "bDaHoanThanh can't be NULL");
				}
				m_bDaHoanThanh = value;
			}
		}
		#endregion
	}
}
