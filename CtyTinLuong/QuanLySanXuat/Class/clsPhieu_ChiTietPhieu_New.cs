using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsPhieu_ChiTietPhieu_New : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bBMay_DOT, m_bTrangThaiXuatNhap, m_bBMay_CAT, m_bBMay_IN, m_bTrangThaiTaoLenhSanXuat, m_bGuiDuLieu;
			private SqlDateTime		m_daNgaySanXuat;
			private SqlDouble		m_fSanLuong_Tong, m_fSanLuong_Thuong, m_fSanLuong_TangCa, m_fSoKG_MotBao_May_Dot, m_fDoCao_Dot, m_fDonGia_Xuat, m_fPhePham, m_fDonGia_Vao, m_fSoLuong_Vao;
			private SqlInt32		m_iID_CongNhan, m_iID_CaTruong, m_iID_SoPhieu, m_iID_May, m_iID_VTHH_Ra, m_iID_VTHH_Vao, m_iID_DinhMuc_Luong, m_iID_ChiTietPhieu;
			private SqlString		m_sCaSanXuat, m_sGhiChu;
		#endregion


		public clsPhieu_ChiTietPhieu_New()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_ChiTietPhieu_New_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_May", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_May));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CaTruong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CaTruong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgaySanXuat", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgaySanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCaSanXuat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCaSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Luong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_IN", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_IN));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_CAT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_CAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_DOT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_DOT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Vao", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong_Vao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_Vao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Ra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Ra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_Thuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_Thuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_TangCa", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_TangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_Tong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_Tong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_Xuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_Xuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKG_MotBao_May_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKG_MotBao_May_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiTaoLenhSanXuat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiTaoLenhSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietPhieu", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietPhieu = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietPhieu"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_ChiTietPhieu_New_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_ChiTietPhieu_New::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_ChiTietPhieu_New_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_SoPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_SoPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_May", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_May));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CaTruong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CaTruong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgaySanXuat", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgaySanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sCaSanXuat", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCaSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMuc_Luong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_IN", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_IN));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_CAT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_CAT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bbMay_DOT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bBMay_DOT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Vao", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong_Vao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_Vao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_Vao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH_Ra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH_Ra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_Thuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_Thuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_TangCa", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_TangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong_Tong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSanLuong_Tong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDonGia_Xuat", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDonGia_Xuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiXuatNhap", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiXuatNhap));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoKG_MotBao_May_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoKG_MotBao_May_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTrangThaiTaoLenhSanXuat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTrangThaiTaoLenhSanXuat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_ChiTietPhieu_New_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_ChiTietPhieu_New::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_ChiTietPhieu_New_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_ChiTietPhieu_New_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_ChiTietPhieu_New::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_ChiTietPhieu_New_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Phieu_ChiTietPhieu_New");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietPhieu", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietPhieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_Phieu_ChiTietPhieu_New_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietPhieu = (Int32)dtToReturn.Rows[0]["ID_ChiTietPhieu"];
					m_iID_SoPhieu = (Int32)dtToReturn.Rows[0]["ID_SoPhieu"];
					m_iID_May = (Int32)dtToReturn.Rows[0]["ID_May"];
					m_iID_CongNhan = (Int32)dtToReturn.Rows[0]["ID_CongNhan"];
					m_iID_CaTruong = (Int32)dtToReturn.Rows[0]["ID_CaTruong"];
					m_daNgaySanXuat = (DateTime)dtToReturn.Rows[0]["NgaySanXuat"];
					m_sCaSanXuat = (string)dtToReturn.Rows[0]["CaSanXuat"];
					m_iID_DinhMuc_Luong = (Int32)dtToReturn.Rows[0]["ID_DinhMuc_Luong"];
					m_bBMay_IN = (bool)dtToReturn.Rows[0]["bMay_IN"];
					m_bBMay_CAT = (bool)dtToReturn.Rows[0]["bMay_CAT"];
					m_bBMay_DOT = (bool)dtToReturn.Rows[0]["bMay_DOT"];
					m_iID_VTHH_Vao = (Int32)dtToReturn.Rows[0]["ID_VTHH_Vao"];
					m_fSoLuong_Vao = (double)dtToReturn.Rows[0]["SoLuong_Vao"];
					m_fDonGia_Vao = (double)dtToReturn.Rows[0]["DonGia_Vao"];
					m_iID_VTHH_Ra = (Int32)dtToReturn.Rows[0]["ID_VTHH_Ra"];
					m_fSanLuong_Thuong = (double)dtToReturn.Rows[0]["SanLuong_Thuong"];
					m_fSanLuong_TangCa = (double)dtToReturn.Rows[0]["SanLuong_TangCa"];
					m_fSanLuong_Tong = (double)dtToReturn.Rows[0]["SanLuong_Tong"];
					m_fDonGia_Xuat = (double)dtToReturn.Rows[0]["DonGia_Xuat"];
					m_fPhePham = (double)dtToReturn.Rows[0]["PhePham"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bTrangThaiXuatNhap = (bool)dtToReturn.Rows[0]["TrangThaiXuatNhap"];
					m_bGuiDuLieu = (bool)dtToReturn.Rows[0]["GuiDuLieu"];
					m_fSoKG_MotBao_May_Dot = (double)dtToReturn.Rows[0]["SoKG_MotBao_May_Dot"];
					m_fDoCao_Dot = (double)dtToReturn.Rows[0]["DoCao_Dot"];
					m_bTrangThaiTaoLenhSanXuat = (bool)dtToReturn.Rows[0]["TrangThaiTaoLenhSanXuat"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_ChiTietPhieu_New::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Phieu_ChiTietPhieu_New_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Phieu_ChiTietPhieu_New");
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
					throw new Exception("Stored Procedure 'pr_Phieu_ChiTietPhieu_New_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsPhieu_ChiTietPhieu_New::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietPhieu
		{
			get
			{
				return m_iID_ChiTietPhieu;
			}
			set
			{
				SqlInt32 iID_ChiTietPhieuTmp = (SqlInt32)value;
				if(iID_ChiTietPhieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietPhieu", "iID_ChiTietPhieu can't be NULL");
				}
				m_iID_ChiTietPhieu = value;
			}
		}


		public SqlInt32 iID_SoPhieu
		{
			get
			{
				return m_iID_SoPhieu;
			}
			set
			{
				SqlInt32 iID_SoPhieuTmp = (SqlInt32)value;
				if(iID_SoPhieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_SoPhieu", "iID_SoPhieu can't be NULL");
				}
				m_iID_SoPhieu = value;
			}
		}


		public SqlInt32 iID_May
		{
			get
			{
				return m_iID_May;
			}
			set
			{
				SqlInt32 iID_MayTmp = (SqlInt32)value;
				if(iID_MayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_May", "iID_May can't be NULL");
				}
				m_iID_May = value;
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


		public SqlInt32 iID_CaTruong
		{
			get
			{
				return m_iID_CaTruong;
			}
			set
			{
				SqlInt32 iID_CaTruongTmp = (SqlInt32)value;
				if(iID_CaTruongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_CaTruong", "iID_CaTruong can't be NULL");
				}
				m_iID_CaTruong = value;
			}
		}


		public SqlDateTime daNgaySanXuat
		{
			get
			{
				return m_daNgaySanXuat;
			}
			set
			{
				SqlDateTime daNgaySanXuatTmp = (SqlDateTime)value;
				if(daNgaySanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgaySanXuat", "daNgaySanXuat can't be NULL");
				}
				m_daNgaySanXuat = value;
			}
		}


		public SqlString sCaSanXuat
		{
			get
			{
				return m_sCaSanXuat;
			}
			set
			{
				SqlString sCaSanXuatTmp = (SqlString)value;
				if(sCaSanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sCaSanXuat", "sCaSanXuat can't be NULL");
				}
				m_sCaSanXuat = value;
			}
		}


		public SqlInt32 iID_DinhMuc_Luong
		{
			get
			{
				return m_iID_DinhMuc_Luong;
			}
			set
			{
				SqlInt32 iID_DinhMuc_LuongTmp = (SqlInt32)value;
				if(iID_DinhMuc_LuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_DinhMuc_Luong", "iID_DinhMuc_Luong can't be NULL");
				}
				m_iID_DinhMuc_Luong = value;
			}
		}


		public SqlBoolean bBMay_IN
		{
			get
			{
				return m_bBMay_IN;
			}
			set
			{
				SqlBoolean bBMay_INTmp = (SqlBoolean)value;
				if(bBMay_INTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBMay_IN", "bBMay_IN can't be NULL");
				}
				m_bBMay_IN = value;
			}
		}


		public SqlBoolean bBMay_CAT
		{
			get
			{
				return m_bBMay_CAT;
			}
			set
			{
				SqlBoolean bBMay_CATTmp = (SqlBoolean)value;
				if(bBMay_CATTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBMay_CAT", "bBMay_CAT can't be NULL");
				}
				m_bBMay_CAT = value;
			}
		}


		public SqlBoolean bBMay_DOT
		{
			get
			{
				return m_bBMay_DOT;
			}
			set
			{
				SqlBoolean bBMay_DOTTmp = (SqlBoolean)value;
				if(bBMay_DOTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bBMay_DOT", "bBMay_DOT can't be NULL");
				}
				m_bBMay_DOT = value;
			}
		}


		public SqlInt32 iID_VTHH_Vao
		{
			get
			{
				return m_iID_VTHH_Vao;
			}
			set
			{
				SqlInt32 iID_VTHH_VaoTmp = (SqlInt32)value;
				if(iID_VTHH_VaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_Vao", "iID_VTHH_Vao can't be NULL");
				}
				m_iID_VTHH_Vao = value;
			}
		}


		public SqlDouble fSoLuong_Vao
		{
			get
			{
				return m_fSoLuong_Vao;
			}
			set
			{
				SqlDouble fSoLuong_VaoTmp = (SqlDouble)value;
				if(fSoLuong_VaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuong_Vao", "fSoLuong_Vao can't be NULL");
				}
				m_fSoLuong_Vao = value;
			}
		}


		public SqlDouble fDonGia_Vao
		{
			get
			{
				return m_fDonGia_Vao;
			}
			set
			{
				SqlDouble fDonGia_VaoTmp = (SqlDouble)value;
				if(fDonGia_VaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDonGia_Vao", "fDonGia_Vao can't be NULL");
				}
				m_fDonGia_Vao = value;
			}
		}


		public SqlInt32 iID_VTHH_Ra
		{
			get
			{
				return m_iID_VTHH_Ra;
			}
			set
			{
				SqlInt32 iID_VTHH_RaTmp = (SqlInt32)value;
				if(iID_VTHH_RaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_VTHH_Ra", "iID_VTHH_Ra can't be NULL");
				}
				m_iID_VTHH_Ra = value;
			}
		}


		public SqlDouble fSanLuong_Thuong
		{
			get
			{
				return m_fSanLuong_Thuong;
			}
			set
			{
				SqlDouble fSanLuong_ThuongTmp = (SqlDouble)value;
				if(fSanLuong_ThuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSanLuong_Thuong", "fSanLuong_Thuong can't be NULL");
				}
				m_fSanLuong_Thuong = value;
			}
		}


		public SqlDouble fSanLuong_TangCa
		{
			get
			{
				return m_fSanLuong_TangCa;
			}
			set
			{
				SqlDouble fSanLuong_TangCaTmp = (SqlDouble)value;
				if(fSanLuong_TangCaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSanLuong_TangCa", "fSanLuong_TangCa can't be NULL");
				}
				m_fSanLuong_TangCa = value;
			}
		}


		public SqlDouble fSanLuong_Tong
		{
			get
			{
				return m_fSanLuong_Tong;
			}
			set
			{
				SqlDouble fSanLuong_TongTmp = (SqlDouble)value;
				if(fSanLuong_TongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSanLuong_Tong", "fSanLuong_Tong can't be NULL");
				}
				m_fSanLuong_Tong = value;
			}
		}


		public SqlDouble fDonGia_Xuat
		{
			get
			{
				return m_fDonGia_Xuat;
			}
			set
			{
				SqlDouble fDonGia_XuatTmp = (SqlDouble)value;
				if(fDonGia_XuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDonGia_Xuat", "fDonGia_Xuat can't be NULL");
				}
				m_fDonGia_Xuat = value;
			}
		}


		public SqlDouble fPhePham
		{
			get
			{
				return m_fPhePham;
			}
			set
			{
				SqlDouble fPhePhamTmp = (SqlDouble)value;
				if(fPhePhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fPhePham", "fPhePham can't be NULL");
				}
				m_fPhePham = value;
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


		public SqlBoolean bTrangThaiXuatNhap
		{
			get
			{
				return m_bTrangThaiXuatNhap;
			}
			set
			{
				SqlBoolean bTrangThaiXuatNhapTmp = (SqlBoolean)value;
				if(bTrangThaiXuatNhapTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiXuatNhap", "bTrangThaiXuatNhap can't be NULL");
				}
				m_bTrangThaiXuatNhap = value;
			}
		}


		public SqlBoolean bGuiDuLieu
		{
			get
			{
				return m_bGuiDuLieu;
			}
			set
			{
				SqlBoolean bGuiDuLieuTmp = (SqlBoolean)value;
				if(bGuiDuLieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bGuiDuLieu", "bGuiDuLieu can't be NULL");
				}
				m_bGuiDuLieu = value;
			}
		}


		public SqlDouble fSoKG_MotBao_May_Dot
		{
			get
			{
				return m_fSoKG_MotBao_May_Dot;
			}
			set
			{
				SqlDouble fSoKG_MotBao_May_DotTmp = (SqlDouble)value;
				if(fSoKG_MotBao_May_DotTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoKG_MotBao_May_Dot", "fSoKG_MotBao_May_Dot can't be NULL");
				}
				m_fSoKG_MotBao_May_Dot = value;
			}
		}


		public SqlDouble fDoCao_Dot
		{
			get
			{
				return m_fDoCao_Dot;
			}
			set
			{
				SqlDouble fDoCao_DotTmp = (SqlDouble)value;
				if(fDoCao_DotTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDoCao_Dot", "fDoCao_Dot can't be NULL");
				}
				m_fDoCao_Dot = value;
			}
		}


		public SqlBoolean bTrangThaiTaoLenhSanXuat
		{
			get
			{
				return m_bTrangThaiTaoLenhSanXuat;
			}
			set
			{
				SqlBoolean bTrangThaiTaoLenhSanXuatTmp = (SqlBoolean)value;
				if(bTrangThaiTaoLenhSanXuatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bTrangThaiTaoLenhSanXuat", "bTrangThaiTaoLenhSanXuat can't be NULL");
				}
				m_bTrangThaiTaoLenhSanXuat = value;
			}
		}
		#endregion
	}
}
