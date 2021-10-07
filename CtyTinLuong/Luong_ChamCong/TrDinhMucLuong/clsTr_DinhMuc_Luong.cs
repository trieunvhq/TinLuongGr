///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'Tr_DinhMuc_Luong'
// Generated by LLBLGen v1.3.5996.26197 Final on: Thursday, October 7, 2021, 2:07:35 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'Tr_DinhMuc_Luong'.
	/// </summary>
	public class clsTr_DinhMuc_Luong : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDachamcong, m_bTontai, m_bNgungtheodoi;
			private SqlDateTime		m_daDen_ngay, m_daTu_ngay;
			private SqlDecimal		m_dcPhuCapBaoHiem, m_dcLuongCoBanTinhBaoHiem, m_dcTrachNhiem, m_dcDinhMucLuongTangCa, m_dcDinhMucLuongTheoGio, m_dcBaoHiem, m_dcPhuCapDienthoai, m_dcPhuCapXangXe, m_dcLuongCoDinh, m_dcPhuCapTienAn, m_dcPhuCapVeSinhMay;
			private SqlDouble		m_fPhanTramBaoHiem;
			private SqlInt32		m_iId_nhanvien, m_iHinhThucTinhLuong, m_iId;
			private SqlString		m_sDienGiai;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public clsTr_DinhMuc_Luong()
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
		///		 <LI>iId_nhanvien. May be SqlInt32.Null</LI>
		///		 <LI>daTu_ngay. May be SqlDateTime.Null</LI>
		///		 <LI>daDen_ngay. May be SqlDateTime.Null</LI>
		///		 <LI>bDachamcong. May be SqlBoolean.Null</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcPhuCapBaoHiem. May be SqlDecimal.Null</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		///		 <LI>bTontai. May be SqlBoolean.Null</LI>
		///		 <LI>bNgungtheodoi. May be SqlBoolean.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iId</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DinhMuc_Luong_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid_nhanvien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId_nhanvien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@datu_ngay", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daTu_ngay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daden_ngay", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDen_ngay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bdachamcong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDachamcong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramBaoHiem", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoBanTinhBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoBanTinhBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTheoGio", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTheoGio));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTangCa", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHinhThucTinhLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHinhThucTinhLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@btontai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTontai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bngungtheodoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungtheodoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iId = (SqlInt32)scmCmdToExecute.Parameters["@iid"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_DinhMuc_Luong::Insert::Error occured.", ex);
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
		///		 <LI>iId</LI>
		///		 <LI>iId_nhanvien. May be SqlInt32.Null</LI>
		///		 <LI>daTu_ngay. May be SqlDateTime.Null</LI>
		///		 <LI>daDen_ngay. May be SqlDateTime.Null</LI>
		///		 <LI>bDachamcong. May be SqlBoolean.Null</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcPhuCapBaoHiem. May be SqlDecimal.Null</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		///		 <LI>bTontai. May be SqlBoolean.Null</LI>
		///		 <LI>bNgungtheodoi. May be SqlBoolean.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DinhMuc_Luong_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid_nhanvien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId_nhanvien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@datu_ngay", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daTu_ngay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daden_ngay", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDen_ngay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bdachamcong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDachamcong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhanTramBaoHiem", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhanTramBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoBanTinhBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoBanTinhBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTheoGio", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTheoGio));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcDinhMucLuongTangCa", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcDinhMucLuongTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iHinhThucTinhLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iHinhThucTinhLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@btontai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTontai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bngungtheodoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungtheodoi));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_DinhMuc_Luong::Update::Error occured.", ex);
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
		///		 <LI>iId</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DinhMuc_Luong_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_DinhMuc_Luong::Delete::Error occured.", ex);
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
		///		 <LI>iId</LI>
		/// </UL>
		///		 <LI>iId</LI>
		///		 <LI>iId_nhanvien</LI>
		///		 <LI>daTu_ngay</LI>
		///		 <LI>daDen_ngay</LI>
		///		 <LI>bDachamcong</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>dcLuongCoDinh</LI>
		///		 <LI>dcPhuCapXangXe</LI>
		///		 <LI>dcPhuCapDienthoai</LI>
		///		 <LI>dcPhuCapVeSinhMay</LI>
		///		 <LI>dcPhuCapTienAn</LI>
		///		 <LI>dcTrachNhiem</LI>
		///		 <LI>fPhanTramBaoHiem</LI>
		///		 <LI>dcLuongCoBanTinhBaoHiem</LI>
		///		 <LI>dcPhuCapBaoHiem</LI>
		///		 <LI>dcBaoHiem</LI>
		///		 <LI>dcDinhMucLuongTheoGio</LI>
		///		 <LI>dcDinhMucLuongTangCa</LI>
		///		 <LI>iHinhThucTinhLuong</LI>
		///		 <LI>bTontai</LI>
		///		 <LI>bNgungtheodoi</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DinhMuc_Luong_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_DinhMuc_Luong");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iId = (Int32)dtToReturn.Rows[0]["id"];
					m_iId_nhanvien = dtToReturn.Rows[0]["id_nhanvien"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["id_nhanvien"];
					m_daTu_ngay = dtToReturn.Rows[0]["tu_ngay"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["tu_ngay"];
					m_daDen_ngay = dtToReturn.Rows[0]["den_ngay"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["den_ngay"];
					m_bDachamcong = dtToReturn.Rows[0]["dachamcong"] == System.DBNull.Value ? SqlBoolean.Null : (bool)dtToReturn.Rows[0]["dachamcong"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_dcLuongCoDinh = (Decimal)dtToReturn.Rows[0]["LuongCoDinh"];
					m_dcPhuCapXangXe = (Decimal)dtToReturn.Rows[0]["PhuCapXangXe"];
					m_dcPhuCapDienthoai = (Decimal)dtToReturn.Rows[0]["PhuCapDienthoai"];
					m_dcPhuCapVeSinhMay = (Decimal)dtToReturn.Rows[0]["PhuCapVeSinhMay"];
					m_dcPhuCapTienAn = (Decimal)dtToReturn.Rows[0]["PhuCapTienAn"];
					m_dcTrachNhiem = (Decimal)dtToReturn.Rows[0]["TrachNhiem"];
					m_fPhanTramBaoHiem = (double)dtToReturn.Rows[0]["PhanTramBaoHiem"];
					m_dcLuongCoBanTinhBaoHiem = (Decimal)dtToReturn.Rows[0]["LuongCoBanTinhBaoHiem"];
					m_dcPhuCapBaoHiem = dtToReturn.Rows[0]["PhuCapBaoHiem"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)dtToReturn.Rows[0]["PhuCapBaoHiem"];
					m_dcBaoHiem = (Decimal)dtToReturn.Rows[0]["BaoHiem"];
					m_dcDinhMucLuongTheoGio = (Decimal)dtToReturn.Rows[0]["DinhMucLuongTheoGio"];
					m_dcDinhMucLuongTangCa = (Decimal)dtToReturn.Rows[0]["DinhMucLuongTangCa"];
					m_iHinhThucTinhLuong = (Int32)dtToReturn.Rows[0]["HinhThucTinhLuong"];
					m_bTontai = dtToReturn.Rows[0]["tontai"] == System.DBNull.Value ? SqlBoolean.Null : (bool)dtToReturn.Rows[0]["tontai"];
					m_bNgungtheodoi = dtToReturn.Rows[0]["ngungtheodoi"] == System.DBNull.Value ? SqlBoolean.Null : (bool)dtToReturn.Rows[0]["ngungtheodoi"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_DinhMuc_Luong::SelectOne::Error occured.", ex);
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
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DinhMuc_Luong_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_DinhMuc_Luong");
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
				throw new Exception("clsTr_DinhMuc_Luong::SelectAll::Error occured.", ex);
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
		public SqlInt32 iId
		{
			get
			{
				return m_iId;
			}
			set
			{
				SqlInt32 iIdTmp = (SqlInt32)value;
				if(iIdTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iId", "iId can't be NULL");
				}
				m_iId = value;
			}
		}


		public SqlInt32 iId_nhanvien
		{
			get
			{
				return m_iId_nhanvien;
			}
			set
			{
				SqlInt32 iId_nhanvienTmp = (SqlInt32)value;
				if(iId_nhanvienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iId_nhanvien", "iId_nhanvien can't be NULL");
				}
				m_iId_nhanvien = value;
			}
		}


		public SqlDateTime daTu_ngay
		{
			get
			{
				return m_daTu_ngay;
			}
			set
			{
				SqlDateTime daTu_ngayTmp = (SqlDateTime)value;
				if(daTu_ngayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daTu_ngay", "daTu_ngay can't be NULL");
				}
				m_daTu_ngay = value;
			}
		}


		public SqlDateTime daDen_ngay
		{
			get
			{
				return m_daDen_ngay;
			}
			set
			{
				SqlDateTime daDen_ngayTmp = (SqlDateTime)value;
				if(daDen_ngayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daDen_ngay", "daDen_ngay can't be NULL");
				}
				m_daDen_ngay = value;
			}
		}


		public SqlBoolean bDachamcong
		{
			get
			{
				return m_bDachamcong;
			}
			set
			{
				SqlBoolean bDachamcongTmp = (SqlBoolean)value;
				if(bDachamcongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDachamcong", "bDachamcong can't be NULL");
				}
				m_bDachamcong = value;
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


		public SqlDecimal dcPhuCapBaoHiem
		{
			get
			{
				return m_dcPhuCapBaoHiem;
			}
			set
			{
				SqlDecimal dcPhuCapBaoHiemTmp = (SqlDecimal)value;
				if(dcPhuCapBaoHiemTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcPhuCapBaoHiem", "dcPhuCapBaoHiem can't be NULL");
				}
				m_dcPhuCapBaoHiem = value;
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


		public SqlBoolean bTontai
		{
			get
			{
				return m_bTontai;
			}
			set
			{
				SqlBoolean bTontaiTmp = (SqlBoolean)value;
				if(bTontaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTontai", "bTontai can't be NULL");
				}
				m_bTontai = value;
			}
		}


		public SqlBoolean bNgungtheodoi
		{
			get
			{
				return m_bNgungtheodoi;
			}
			set
			{
				SqlBoolean bNgungtheodoiTmp = (SqlBoolean)value;
				if(bNgungtheodoiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bNgungtheodoi", "bNgungtheodoi can't be NULL");
				}
				m_bNgungtheodoi = value;
			}
		}
		#endregion
	}
}
