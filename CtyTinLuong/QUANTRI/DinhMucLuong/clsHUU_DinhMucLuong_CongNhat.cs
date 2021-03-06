///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'HUU_DinhMucLuong_CongNhat'
// Generated by LLBLGen v1.3.5996.26197 Final on: Sunday, March 21, 2021, 9:22:40 AM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'HUU_DinhMucLuong_CongNhat'.
	/// </summary>
	public partial  class clsHUU_DinhMucLuong_CongNhat : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTonTai;
			private SqlDecimal		m_dcLuongCoBanTinhBaoHiem, m_dcPhuCapTienAn, m_dcDinhMucLuongTangCa, m_dcDinhMucLuongTheoGio, 
                                    m_dcBaoHiem, m_dcPhuCapBaoHiem, m_dcPhuCapXangXe, m_dcLuongCoDinh, m_dcTrachNhiem, m_dcPhuCapVeSinhMay, m_dcPhuCapDienthoai;
			private SqlDouble		m_fPhanTramBaoHiem;
			private SqlInt32		m_iHinhThucTinhLuong, m_iID_DinhMucLuong_CongNhat;
			private SqlString		m_sMaDinhMucLuongCongNhat, m_sDienGiai;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public clsHUU_DinhMucLuong_CongNhat()
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
		///		 <LI>sMaDinhMucLuongCongNhat</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iID_DinhMucLuong_CongNhat</LI>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_DinhMucLuong_CongNhat_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaDinhMucLuongCongNhat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaDinhMucLuongCongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramBaoHiem", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoBanTinhBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoBanTinhBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem)); 
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapBaoHiem)); 
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTheoGio", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTheoGio));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTangCa", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHinhThucTinhLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHinhThucTinhLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_DinhMucLuong_CongNhat = (SqlInt32)scmCmdToExecute.Parameters["@iID_DinhMucLuong_CongNhat"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_DinhMucLuong_CongNhat_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_DinhMucLuong_CongNhat::Insert::Error occured.", ex);
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
		///		 <LI>iID_DinhMucLuong_CongNhat</LI>
		///		 <LI>sMaDinhMucLuongCongNhat</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_DinhMucLuong_CongNhat_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaDinhMucLuongCongNhat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaDinhMucLuongCongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramBaoHiem", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoBanTinhBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoBanTinhBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapBaoHiem));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTheoGio", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTheoGio));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTangCa", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHinhThucTinhLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHinhThucTinhLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_DinhMucLuong_CongNhat_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_DinhMucLuong_CongNhat::Update::Error occured.", ex);
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
		///		 <LI>iID_DinhMucLuong_CongNhat</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_DinhMucLuong_CongNhat_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_DinhMucLuong_CongNhat_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_DinhMucLuong_CongNhat::Delete::Error occured.", ex);
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
		///		 <LI>iID_DinhMucLuong_CongNhat</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iErrorCode</LI>
		///		 <LI>iID_DinhMucLuong_CongNhat</LI>
		///		 <LI>sMaDinhMucLuongCongNhat</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_DinhMucLuong_CongNhat_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_DinhMucLuong_CongNhat");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_DinhMucLuong_CongNhat_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_DinhMucLuong_CongNhat = (Int32)dtToReturn.Rows[0]["ID_DinhMucLuong_CongNhat"];
					m_sMaDinhMucLuongCongNhat = (string)dtToReturn.Rows[0]["MaDinhMucLuongCongNhat"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_dcLuongCoDinh = (Decimal)dtToReturn.Rows[0]["LuongCoDinh"];
					m_dcPhuCapXangXe = (Decimal)dtToReturn.Rows[0]["PhuCapXangXe"];
					m_dcPhuCapDienthoai = (Decimal)dtToReturn.Rows[0]["PhuCapDienthoai"];
					m_dcPhuCapVeSinhMay = (Decimal)dtToReturn.Rows[0]["PhuCapVeSinhMay"];
					m_dcPhuCapTienAn = (Decimal)dtToReturn.Rows[0]["PhuCapTienAn"];
					m_dcTrachNhiem = (Decimal)dtToReturn.Rows[0]["TrachNhiem"];
					m_fPhanTramBaoHiem = (double)dtToReturn.Rows[0]["PhanTramBaoHiem"];
					m_dcLuongCoBanTinhBaoHiem = (Decimal)dtToReturn.Rows[0]["LuongCoBanTinhBaoHiem"];
					m_dcBaoHiem = (Decimal)dtToReturn.Rows[0]["BaoHiem"];
                    m_dcPhuCapBaoHiem = (Decimal)dtToReturn.Rows[0]["PhuCapBaoHiem"];
                    m_dcDinhMucLuongTheoGio = (Decimal)dtToReturn.Rows[0]["DinhMucLuongTheoGio"];
					m_dcDinhMucLuongTangCa = (Decimal)dtToReturn.Rows[0]["DinhMucLuongTangCa"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_iHinhThucTinhLuong = (Int32)dtToReturn.Rows[0]["HinhThucTinhLuong"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_DinhMucLuong_CongNhat::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_DinhMucLuong_CongNhat_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_DinhMucLuong_CongNhat");
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
					throw new Exception("Stored Procedure 'pr_HUU_DinhMucLuong_CongNhat_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_DinhMucLuong_CongNhat::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_DinhMucLuong_CongNhat
		{
			get
			{
				return m_iID_DinhMucLuong_CongNhat;
			}
			set
			{
				SqlInt32 iID_DinhMucLuong_CongNhatTmp = (SqlInt32)value;
				if(iID_DinhMucLuong_CongNhatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMucLuong_CongNhat", "iID_DinhMucLuong_CongNhat can't be NULL");
				}
				m_iID_DinhMucLuong_CongNhat = value;
			}
		}


		public SqlString sMaDinhMucLuongCongNhat
		{
			get
			{
				return m_sMaDinhMucLuongCongNhat;
			}
			set
			{
				SqlString sMaDinhMucLuongCongNhatTmp = (SqlString)value;
				if(sMaDinhMucLuongCongNhatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaDinhMucLuongCongNhat", "sMaDinhMucLuongCongNhat can't be NULL");
				}
				m_sMaDinhMucLuongCongNhat = value;
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


		public SqlDecimal dcLuongCoDinh
		{
			get
			{
				return m_dcLuongCoDinh;
			}
			set
			{
				SqlDecimal dcLuongCoDinhTmp = (SqlDecimal)value;
				if(dcLuongCoDinhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongCoDinh", "dcLuongCoDinh can't be NULL");
				}
				m_dcLuongCoDinh = value;
			}
		}


		public SqlDecimal dcPhuCapXangXe
		{
			get
			{
				return m_dcPhuCapXangXe;
			}
			set
			{
				SqlDecimal dcPhuCapXangXeTmp = (SqlDecimal)value;
				if(dcPhuCapXangXeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcPhuCapXangXe", "dcPhuCapXangXe can't be NULL");
				}
				m_dcPhuCapXangXe = value;
			}
		}


		public SqlDecimal dcPhuCapDienthoai
		{
			get
			{
				return m_dcPhuCapDienthoai;
			}
			set
			{
				SqlDecimal dcPhuCapDienthoaiTmp = (SqlDecimal)value;
				if(dcPhuCapDienthoaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcPhuCapDienthoai", "dcPhuCapDienthoai can't be NULL");
				}
				m_dcPhuCapDienthoai = value;
			}
		}


		public SqlDecimal dcPhuCapVeSinhMay
		{
			get
			{
				return m_dcPhuCapVeSinhMay;
			}
			set
			{
				SqlDecimal dcPhuCapVeSinhMayTmp = (SqlDecimal)value;
				if(dcPhuCapVeSinhMayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcPhuCapVeSinhMay", "dcPhuCapVeSinhMay can't be NULL");
				}
				m_dcPhuCapVeSinhMay = value;
			}
		}


		public SqlDecimal dcPhuCapTienAn
		{
			get
			{
				return m_dcPhuCapTienAn;
			}
			set
			{
				SqlDecimal dcPhuCapTienAnTmp = (SqlDecimal)value;
				if(dcPhuCapTienAnTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcPhuCapTienAn", "dcPhuCapTienAn can't be NULL");
				}
				m_dcPhuCapTienAn = value;
			}
		}


		public SqlDecimal dcTrachNhiem
		{
			get
			{
				return m_dcTrachNhiem;
			}
			set
			{
				SqlDecimal dcTrachNhiemTmp = (SqlDecimal)value;
				if(dcTrachNhiemTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcTrachNhiem", "dcTrachNhiem can't be NULL");
				}
				m_dcTrachNhiem = value;
			}
		}


		public SqlDouble fPhanTramBaoHiem
		{
			get
			{
				return m_fPhanTramBaoHiem;
			}
			set
			{
				SqlDouble fPhanTramBaoHiemTmp = (SqlDouble)value;
				if(fPhanTramBaoHiemTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fPhanTramBaoHiem", "fPhanTramBaoHiem can't be NULL");
				}
				m_fPhanTramBaoHiem = value;
			}
		}


		public SqlDecimal dcLuongCoBanTinhBaoHiem
		{
			get
			{
				return m_dcLuongCoBanTinhBaoHiem;
			}
			set
			{
				SqlDecimal dcLuongCoBanTinhBaoHiemTmp = (SqlDecimal)value;
				if(dcLuongCoBanTinhBaoHiemTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongCoBanTinhBaoHiem", "dcLuongCoBanTinhBaoHiem can't be NULL");
				}
				m_dcLuongCoBanTinhBaoHiem = value;
			}
		}

        
        public SqlDecimal dcBaoHiem
		{
			get
			{
				return m_dcBaoHiem;
			}
			set
			{
				SqlDecimal dcBaoHiemTmp = (SqlDecimal)value;
				if(dcBaoHiemTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcBaoHiem", "dcBaoHiem can't be NULL");
				}
				m_dcBaoHiem = value;
			}
		}

        public SqlDecimal dcPhuCapBaoHiem
        {
            get
            {
                return m_dcPhuCapBaoHiem;
            }
            set
            {
                SqlDecimal dcPhuCapBaoHiemTmp = (SqlDecimal)value;
                if (dcPhuCapBaoHiemTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("dcPhuCapBaoHiem", "dcPhuCapBaoHiem can't be NULL");
                }
                m_dcPhuCapBaoHiem = value;
            }
        }


        public SqlDecimal dcDinhMucLuongTheoGio
		{
			get
			{
				return m_dcDinhMucLuongTheoGio;
			}
			set
			{
				SqlDecimal dcDinhMucLuongTheoGioTmp = (SqlDecimal)value;
				if(dcDinhMucLuongTheoGioTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcDinhMucLuongTheoGio", "dcDinhMucLuongTheoGio can't be NULL");
				}
				m_dcDinhMucLuongTheoGio = value;
			}
		}


		public SqlDecimal dcDinhMucLuongTangCa
		{
			get
			{
				return m_dcDinhMucLuongTangCa;
			}
			set
			{
				SqlDecimal dcDinhMucLuongTangCaTmp = (SqlDecimal)value;
				if(dcDinhMucLuongTangCaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcDinhMucLuongTangCa", "dcDinhMucLuongTangCa can't be NULL");
				}
				m_dcDinhMucLuongTangCa = value;
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


		public SqlInt32 iHinhThucTinhLuong
		{
			get
			{
				return m_iHinhThucTinhLuong;
			}
			set
			{
				SqlInt32 iHinhThucTinhLuongTmp = (SqlInt32)value;
				if(iHinhThucTinhLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iHinhThucTinhLuong", "iHinhThucTinhLuong can't be NULL");
				}
				m_iHinhThucTinhLuong = value;
			}
		}
		#endregion
	}
}
