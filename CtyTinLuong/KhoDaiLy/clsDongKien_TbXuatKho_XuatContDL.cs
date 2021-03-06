///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'DongKien_TbXuatKho_XuatContDL'
// Generated by LLBLGen v1.3.5996.26197 Final on: Wednesday, December 1, 2021, 2:48:16 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'DongKien_TbXuatKho_XuatContDL'.
	/// </summary>
	public class clsDongKien_TbXuatKho_XuatContDL : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bDaXuatKho, m_bTonTai, m_bNgungTheoDoi;
			private SqlDateTime		m_daNgayThang;
			private SqlInt32		m_iID_XuatContDongKien, m_iID_NguoiLap;
			private SqlString		m_sGhiChu, m_sSoChungTu, m_sDienGiai;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public clsDongKien_TbXuatKho_XuatContDL()
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
		///		 <LI>daNgayThang. May be SqlDateTime.Null</LI>
		///		 <LI>sSoChungTu. May be SqlString.Null</LI>
		///		 <LI>iID_NguoiLap. May be SqlInt32.Null</LI>
		///		 <LI>sDienGiai. May be SqlString.Null</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bDaXuatKho</LI>
		///		 <LI>sGhiChu</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iID_XuatContDongKien</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DongKien_TbXuatKho_XuatContDL_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiLap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiLap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatContDongKien", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatContDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_XuatContDongKien = (SqlInt32)scmCmdToExecute.Parameters["@iID_XuatContDongKien"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbXuatKho_XuatContDL::Insert::Error occured.", ex);
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
		///		 <LI>iID_XuatContDongKien</LI>
		///		 <LI>daNgayThang. May be SqlDateTime.Null</LI>
		///		 <LI>sSoChungTu. May be SqlString.Null</LI>
		///		 <LI>iID_NguoiLap. May be SqlInt32.Null</LI>
		///		 <LI>sDienGiai. May be SqlString.Null</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bDaXuatKho</LI>
		///		 <LI>sGhiChu</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DongKien_TbXuatKho_XuatContDL_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatContDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatContDongKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoChungTu", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoChungTu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NguoiLap", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NguoiLap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaXuatKho", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaXuatKho));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbXuatKho_XuatContDL::Update::Error occured.", ex);
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
		///		 <LI>iID_XuatContDongKien</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DongKien_TbXuatKho_XuatContDL_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatContDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatContDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbXuatKho_XuatContDL::Delete::Error occured.", ex);
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
		///		 <LI>iID_XuatContDongKien</LI>
		/// </UL>
		///		 <LI>iID_XuatContDongKien</LI>
		///		 <LI>daNgayThang</LI>
		///		 <LI>sSoChungTu</LI>
		///		 <LI>iID_NguoiLap</LI>
		///		 <LI>sDienGiai</LI>
		///		 <LI>bTonTai</LI>
		///		 <LI>bNgungTheoDoi</LI>
		///		 <LI>bDaXuatKho</LI>
		///		 <LI>sGhiChu</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_DongKien_TbXuatKho_XuatContDL_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_TbXuatKho_XuatContDL");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_XuatContDongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_XuatContDongKien));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_XuatContDongKien = (Int32)dtToReturn.Rows[0]["ID_XuatContDongKien"];
					m_daNgayThang = dtToReturn.Rows[0]["NgayThang"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["NgayThang"];
					m_sSoChungTu = dtToReturn.Rows[0]["SoChungTu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["SoChungTu"];
					m_iID_NguoiLap = dtToReturn.Rows[0]["ID_NguoiLap"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_NguoiLap"];
					m_sDienGiai = dtToReturn.Rows[0]["DienGiai"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DienGiai"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_bDaXuatKho = (bool)dtToReturn.Rows[0]["DaXuatKho"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_TbXuatKho_XuatContDL::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[Tr_DongKien_TbXuatKho_XuatContDL_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_TbXuatKho_XuatContDL");
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
				throw new Exception("clsDongKien_TbXuatKho_XuatContDL::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_XuatContDongKien
		{
			get
			{
				return m_iID_XuatContDongKien;
			}
			set
			{
				SqlInt32 iID_XuatContDongKienTmp = (SqlInt32)value;
				if(iID_XuatContDongKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_XuatContDongKien", "iID_XuatContDongKien can't be NULL");
				}
				m_iID_XuatContDongKien = value;
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


		public SqlInt32 iID_NguoiLap
		{
			get
			{
				return m_iID_NguoiLap;
			}
			set
			{
				SqlInt32 iID_NguoiLapTmp = (SqlInt32)value;
				if(iID_NguoiLapTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NguoiLap", "iID_NguoiLap can't be NULL");
				}
				m_iID_NguoiLap = value;
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
		#endregion
	}
}
