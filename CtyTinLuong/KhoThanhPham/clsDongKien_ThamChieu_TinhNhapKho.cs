using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsDongKien_ThamChieu_TinhNhapKho : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bTonTai, m_bNgungTheoDois;
			private SqlDouble		m_fDonGia, m_fSoLuongNhap;
			private SqlInt32		m_iID_ThamChieu, m_iID_NhapKho_DongKien, m_iID_NhapKho_ThanhPham, m_iID_VTHH;
		#endregion


		public clsDongKien_ThamChieu_TinhNhapKho()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_ThamChieu_TinhNhapKho_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_DongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKho_DongKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_ThanhPham", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKho_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongNhap", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDois", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDois));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieu));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ThamChieu = (SqlInt32)scmCmdToExecute.Parameters["@iID_ThamChieu"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_ThamChieu_TinhNhapKho::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_ThamChieu_TinhNhapKho_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_DongKien", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKho_DongKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_NhapKho_ThanhPham", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_NhapKho_ThanhPham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongNhap", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDois", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDois));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_ThamChieu_TinhNhapKho::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_ThamChieu_TinhNhapKho_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieu));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_ThamChieu_TinhNhapKho::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_ThamChieu_TinhNhapKho_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_ThamChieu_TinhNhapKho");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ThamChieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ThamChieu));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ThamChieu = (Int32)dtToReturn.Rows[0]["ID_ThamChieu"];
					m_iID_NhapKho_DongKien = (Int32)dtToReturn.Rows[0]["ID_NhapKho_DongKien"];
					m_iID_NhapKho_ThanhPham = (Int32)dtToReturn.Rows[0]["ID_NhapKho_ThanhPham"];
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_fSoLuongNhap = (double)dtToReturn.Rows[0]["SoLuongNhap"];
					m_fDonGia = (double)dtToReturn.Rows[0]["DonGia"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_bNgungTheoDois = (bool)dtToReturn.Rows[0]["NgungTheoDois"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsDongKien_ThamChieu_TinhNhapKho::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_DongKien_ThamChieu_TinhNhapKho_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("DongKien_ThamChieu_TinhNhapKho");
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
				throw new Exception("clsDongKien_ThamChieu_TinhNhapKho::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ThamChieu
		{
			get
			{
				return m_iID_ThamChieu;
			}
			set
			{
				SqlInt32 iID_ThamChieuTmp = (SqlInt32)value;
				if(iID_ThamChieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ThamChieu", "iID_ThamChieu can't be NULL");
				}
				m_iID_ThamChieu = value;
			}
		}


		public SqlInt32 iID_NhapKho_DongKien
		{
			get
			{
				return m_iID_NhapKho_DongKien;
			}
			set
			{
				SqlInt32 iID_NhapKho_DongKienTmp = (SqlInt32)value;
				if(iID_NhapKho_DongKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NhapKho_DongKien", "iID_NhapKho_DongKien can't be NULL");
				}
				m_iID_NhapKho_DongKien = value;
			}
		}


		public SqlInt32 iID_NhapKho_ThanhPham
		{
			get
			{
				return m_iID_NhapKho_ThanhPham;
			}
			set
			{
				SqlInt32 iID_NhapKho_ThanhPhamTmp = (SqlInt32)value;
				if(iID_NhapKho_ThanhPhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_NhapKho_ThanhPham", "iID_NhapKho_ThanhPham can't be NULL");
				}
				m_iID_NhapKho_ThanhPham = value;
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


		public SqlDouble fSoLuongNhap
		{
			get
			{
				return m_fSoLuongNhap;
			}
			set
			{
				SqlDouble fSoLuongNhapTmp = (SqlDouble)value;
				if(fSoLuongNhapTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongNhap", "fSoLuongNhap can't be NULL");
				}
				m_fSoLuongNhap = value;
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


		public SqlBoolean bNgungTheoDois
		{
			get
			{
				return m_bNgungTheoDois;
			}
			set
			{
				SqlBoolean bNgungTheoDoisTmp = (SqlBoolean)value;
				if(bNgungTheoDoisTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bNgungTheoDois", "bNgungTheoDois can't be NULL");
				}
				m_bNgungTheoDois = value;
			}
		}
		#endregion
	}
}
