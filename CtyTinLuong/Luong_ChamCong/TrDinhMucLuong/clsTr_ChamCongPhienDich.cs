///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'Tr_ChamCongPhienDich'
// Generated by LLBLGen v1.3.5996.26197 Final on: Tuesday, October 19, 2021, 7:10:11 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	/// <summary>
	/// Purpose: Data Access class for the table 'Tr_ChamCongPhienDich'.
	/// </summary>
	public class clsTr_ChamCongPhienDich : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		m_daNgayThang;
			private SqlInt32		m_iID_KhachHang, m_iID_ChamConPhienDich, m_iID_CongNhan;
			private SqlString		m_sDienGiai, m_sSoCont, m_sSoToKhai;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public clsTr_ChamCongPhienDich()
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
		///		 <LI>iID_CongNhan. May be SqlInt32.Null</LI>
		///		 <LI>daNgayThang. May be SqlDateTime.Null</LI>
		///		 <LI>iID_KhachHang. May be SqlInt32.Null</LI>
		///		 <LI>sSoToKhai. May be SqlString.Null</LI>
		///		 <LI>sSoCont. May be SqlString.Null</LI>
		///		 <LI>sDienGiai. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>iID_ChamConPhienDich</LI>
		/// </UL>
		/// </remarks>
		public bool Tr_ChamCongPhienDich_Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_ChamCongPhienDich_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoToKhai", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoToKhai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoCont", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoCont));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamConPhienDich", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamConPhienDich));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChamConPhienDich = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChamConPhienDich"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_ChamCongPhienDich::Insert::Error occured.", ex);
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
		///		 <LI>iID_ChamConPhienDich</LI>
		///		 <LI>iID_CongNhan. May be SqlInt32.Null</LI>
		///		 <LI>daNgayThang. May be SqlDateTime.Null</LI>
		///		 <LI>iID_KhachHang. May be SqlInt32.Null</LI>
		///		 <LI>sSoToKhai. May be SqlString.Null</LI>
		///		 <LI>sSoCont. May be SqlString.Null</LI>
		///		 <LI>sDienGiai. May be SqlString.Null</LI>
		/// </UL>
		/// </remarks>
		public bool Tr_ChamCongPhienDich_Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_ChamCongPhienDich_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamConPhienDich", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamConPhienDich));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_KhachHang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_KhachHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoToKhai", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoToKhai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoCont", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoCont));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_ChamCongPhienDich::Update::Error occured.", ex);
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
		///		 <LI>iID_ChamConPhienDich</LI>
		/// </UL>
		/// </remarks>
		public bool Tr_ChamCongPhienDich_Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_ChamCongPhienDich_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamConPhienDich", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamConPhienDich));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_ChamCongPhienDich::Delete::Error occured.", ex);
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
		///		 <LI>iID_ChamConPhienDich</LI>
		/// </UL>
		///		 <LI>iID_ChamConPhienDich</LI>
		///		 <LI>iID_CongNhan</LI>
		///		 <LI>daNgayThang</LI>
		///		 <LI>iID_KhachHang</LI>
		///		 <LI>sSoToKhai</LI>
		///		 <LI>sSoCont</LI>
		///		 <LI>sDienGiai</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public DataTable Tr_ChamCongPhienDich_SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_ChamCongPhienDich_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_ChamCongPhienDich");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamConPhienDich", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamConPhienDich));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChamConPhienDich = (Int32)dtToReturn.Rows[0]["ID_ChamConPhienDich"];
					m_iID_CongNhan = dtToReturn.Rows[0]["ID_CongNhan"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_CongNhan"];
					m_daNgayThang = dtToReturn.Rows[0]["NgayThang"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["NgayThang"];
					m_iID_KhachHang = dtToReturn.Rows[0]["ID_KhachHang"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_KhachHang"];
					m_sSoToKhai = dtToReturn.Rows[0]["SoToKhai"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["SoToKhai"];
					m_sSoCont = dtToReturn.Rows[0]["SoCont"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["SoCont"];
					m_sDienGiai = dtToReturn.Rows[0]["DienGiai"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DienGiai"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_ChamCongPhienDich::SelectOne::Error occured.", ex);
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
		public DataTable Tr_ChamCongPhienDich_SelectAll(DateTime ngay_batdau, DateTime ngay_ketthuc, int idcn, string tenKhachHang)
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[Tr_ChamCongPhienDich_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_ChamCongPhienDich");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{

				// Open connection.
				m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, idcn));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenKhachHang", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tenKhachHang));

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_ChamCongPhienDich::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}

        public DataTable Tr_KhachHang_PhienDich_SelectAll()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_KhachHang_PhienDich_SelectAll]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("Tr_KhachHang_PhienDich");
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
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsTr_ChamCongPhienDich::SelectAll::Error occured.", ex);
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
        public SqlInt32 iID_ChamConPhienDich
		{
			get
			{
				return m_iID_ChamConPhienDich;
			}
			set
			{
				SqlInt32 iID_ChamConPhienDichTmp = (SqlInt32)value;
				if(iID_ChamConPhienDichTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChamConPhienDich", "iID_ChamConPhienDich can't be NULL");
				}
				m_iID_ChamConPhienDich = value;
			}
		}


		public SqlInt32 iID_CongNhan
		{
			get
			{
				return m_iID_CongNhan;
			}
			set
			{
				SqlInt32 iID_CongNhanTmp = (SqlInt32)value;
				if(iID_CongNhanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_CongNhan", "iID_CongNhan can't be NULL");
				}
				m_iID_CongNhan = value;
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


		public SqlString sSoToKhai
		{
			get
			{
				return m_sSoToKhai;
			}
			set
			{
				SqlString sSoToKhaiTmp = (SqlString)value;
				if(sSoToKhaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoToKhai", "sSoToKhai can't be NULL");
				}
				m_sSoToKhai = value;
			}
		}


		public SqlString sSoCont
		{
			get
			{
				return m_sSoCont;
			}
			set
			{
				SqlString sSoContTmp = (SqlString)value;
				if(sSoContTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoCont", "sSoCont can't be NULL");
				}
				m_sSoCont = value;
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
		#endregion
	}
}
