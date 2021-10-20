///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'DongKien_TbNhapKho'
// Generated by LLBLGen v1.3.5996.26197 Final on: Wednesday, October 20, 2021, 8:12:40 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'DongKien_TbNhapKho'.
	/// </summary>
	public partial class clsDongKien_TbNhapKho : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bDaNhapKho, m_bBoolTonDauKy, m_bNgungTheoDoi;
			private SqlDateTime		m_daNgayChungTu;
			private SqlDouble		m_fDonGia, m_fThanhTien, m_fSoLuong;
			private SqlInt32		m_iID_NhapKhoDongKien, m_iID_NguoiNhap, m_iID_XuatKhoGapDan, m_iID_VTHH;
			private SqlString		m_sNguoiGiaoHang, m_sDienGiai, m_sSoChungTu;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public clsDongKien_TbNhapKho()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>iID_XuatKhoGapDan</LI>
		///		 <LI>iID_NguoiNhap</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>daNgayChungTu</LI>
		///		 <LI>sSoChungTu</LI>
		///		 <LI>iID_VTHH</LI>
		///		 <LI>fSoLuong</LI>
		///		 <LI>fDonGia</LI>
		///		 <LI>fThanhTien</LI>
		///		 <LI>bDaNhapKho</LI>
		///		 <LI>sNguoiGiaoHang</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bBoolTonDauKy</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iID_NhapKhoDongKien</LI>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_TbNhapKho_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoGapDan));
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKhoDongKien", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKhoDongKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_NhapKhoDongKien = (SqlInt32)scmCmdToExecute.Parameters["@iID_NhapKhoDongKien"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DongKien_TbNhapKho_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

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


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>iID_NhapKhoDongKien</LI>
		///		 <LI>iID_XuatKhoGapDan</LI>
		///		 <LI>iID_NguoiNhap</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>daNgayChungTu</LI>
		///		 <LI>sSoChungTu</LI>
		///		 <LI>iID_VTHH</LI>
		///		 <LI>fSoLuong</LI>
		///		 <LI>fDonGia</LI>
		///		 <LI>fThanhTien</LI>
		///		 <LI>bDaNhapKho</LI>
		///		 <LI>sNguoiGiaoHang</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bBoolTonDauKy</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatKhoGapDan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatKhoGapDan));
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DongKien_TbNhapKho_Update' reported the ErrorCode: " + m_iErrorCode);
				}

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


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>iID_NhapKhoDongKien</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DongKien_TbNhapKho_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

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


		/// <summary>
		/// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>iID_NhapKhoDongKien</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		///		 <LI>iID_NhapKhoDongKien</LI>
		///		 <LI>iID_XuatKhoGapDan</LI>
		///		 <LI>iID_NguoiNhap</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>daNgayChungTu</LI>
		///		 <LI>sSoChungTu</LI>
		///		 <LI>iID_VTHH</LI>
		///		 <LI>fSoLuong</LI>
		///		 <LI>fDonGia</LI>
		///		 <LI>fThanhTien</LI>
		///		 <LI>bDaNhapKho</LI>
		///		 <LI>sNguoiGiaoHang</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bBoolTonDauKy</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DongKien_TbNhapKho_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_NhapKhoDongKien = (Int32)dtToReturn.Rows[0]["ID_NhapKhoDongKien"];
					m_iID_XuatKhoGapDan = (Int32)dtToReturn.Rows[0]["ID_XuatKhoGapDan"];
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


		/// <summary>
		/// Purpose: SelectAll method. This method will Select all rows from the table.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
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
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_DongKien_TbNhapKho_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

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


		public SqlInt32 iID_XuatKhoGapDan
		{
			get
			{
				return m_iID_XuatKhoGapDan;
			}
			set
			{
				SqlInt32 iID_XuatKhoGapDanTmp = (SqlInt32)value;
				if(iID_XuatKhoGapDanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_XuatKhoGapDan", "iID_XuatKhoGapDan can't be NULL");
				}
				m_iID_XuatKhoGapDan = value;
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
		#endregion
	}
}
