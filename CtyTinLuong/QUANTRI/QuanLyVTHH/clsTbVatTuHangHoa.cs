using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsTbVatTuHangHoa : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bNgungTheoDoi, m_bTonTai;
			private SqlDouble		m_fDoCao_Dot;
			private SqlBinary		m_blobHinhAnh;
			private SqlInt32		m_iID_MaNhom, m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4, m_iID_VTHH;
			private SqlString		m_sAnh, m_sQuyCach, m_sMaVT, m_sDienGiai, m_sDonViTinh, m_sGhiChu, m_sTenVTHH;
		#endregion


		public clsTbVatTuHangHoa()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tbVatTuHangHoa_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaVT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaVT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenVTHH", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenVTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuyCach", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuyCach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonViTinh", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonViTinh));
				int	iLength = 0;
				if(!m_blobHinhAnh.IsNull)
				{
					iLength = m_blobHinhAnh.Length;
				}
				scmCmdToExecute.Parameters.Add(new SqlParameter("@blobHinhAnh", SqlDbType.Image, iLength, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_blobHinhAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MaNhom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MaNhom));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sAnh", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_VTHH = (SqlInt32)scmCmdToExecute.Parameters["@iID_VTHH"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbVatTuHangHoa_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbVatTuHangHoa::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbVatTuHangHoa_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMaVT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMaVT));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenVTHH", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTenVTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDienGiai", SqlDbType.NVarChar, 450, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDienGiai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuyCach", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuyCach));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonViTinh", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonViTinh));
				int	iLength = 0;
				if(!m_blobHinhAnh.IsNull)
				{
					iLength = m_blobHinhAnh.Length;
				}
				scmCmdToExecute.Parameters.Add(new SqlParameter("@blobHinhAnh", SqlDbType.Image, iLength, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_blobHinhAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bNgungTheoDoi", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bNgungTheoDoi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bTonTai", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bTonTai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_MaNhom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_MaNhom));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sAnh", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sAnh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao_Dot", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao_Dot));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbVatTuHangHoa_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbVatTuHangHoa::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbVatTuHangHoa_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbVatTuHangHoa_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbVatTuHangHoa::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbVatTuHangHoa_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbVatTuHangHoa");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_VTHH));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_tbVatTuHangHoa_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_VTHH = (Int32)dtToReturn.Rows[0]["ID_VTHH"];
					m_sMaVT = (string)dtToReturn.Rows[0]["MaVT"];
					m_sTenVTHH = (string)dtToReturn.Rows[0]["TenVTHH"];
					m_sDienGiai = (string)dtToReturn.Rows[0]["DienGiai"];
					m_sQuyCach = (string)dtToReturn.Rows[0]["QuyCach"];
					m_sDonViTinh = (string)dtToReturn.Rows[0]["DonViTinh"];
					m_blobHinhAnh = dtToReturn.Rows[0]["HinhAnh"] == System.DBNull.Value ? SqlBinary.Null : (byte[])dtToReturn.Rows[0]["HinhAnh"];
					m_bNgungTheoDoi = (bool)dtToReturn.Rows[0]["NgungTheoDoi"];
					m_sGhiChu = (string)dtToReturn.Rows[0]["GhiChu"];
					m_bTonTai = (bool)dtToReturn.Rows[0]["TonTai"];
					m_iID_MaNhom = dtToReturn.Rows[0]["ID_MaNhom"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["ID_MaNhom"];
					m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4 = dtToReturn.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["Bien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4"];
					m_sAnh = dtToReturn.Rows[0]["Anh"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["Anh"];
					m_fDoCao_Dot = (double)dtToReturn.Rows[0]["DoCao_Dot"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbVatTuHangHoa::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tbVatTuHangHoa_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tbVatTuHangHoa");
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
					throw new Exception("Stored Procedure 'pr_tbVatTuHangHoa_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTbVatTuHangHoa::SelectAll::Error occured.", ex);
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


		public SqlString sMaVT
		{
			get
			{
				return m_sMaVT;
			}
			set
			{
				SqlString sMaVTTmp = (SqlString)value;
				if(sMaVTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMaVT", "sMaVT can't be NULL");
				}
				m_sMaVT = value;
			}
		}


		public SqlString sTenVTHH
		{
			get
			{
				return m_sTenVTHH;
			}
			set
			{
				SqlString sTenVTHHTmp = (SqlString)value;
				if(sTenVTHHTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTenVTHH", "sTenVTHH can't be NULL");
				}
				m_sTenVTHH = value;
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


		public SqlString sDonViTinh
		{
			get
			{
				return m_sDonViTinh;
			}
			set
			{
				SqlString sDonViTinhTmp = (SqlString)value;
				if(sDonViTinhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDonViTinh", "sDonViTinh can't be NULL");
				}
				m_sDonViTinh = value;
			}
		}


		public SqlBinary blobHinhAnh
		{
			get
			{
				return m_blobHinhAnh;
			}
			set
			{
				SqlBinary blobHinhAnhTmp = (SqlBinary)value;
				if(blobHinhAnhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("blobHinhAnh", "blobHinhAnh can't be NULL");
				}
				m_blobHinhAnh = value;
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


		public SqlInt32 iID_MaNhom
		{
			get
			{
				return m_iID_MaNhom;
			}
			set
			{
				SqlInt32 iID_MaNhomTmp = (SqlInt32)value;
				if(iID_MaNhomTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_MaNhom", "iID_MaNhom can't be NULL");
				}
				m_iID_MaNhom = value;
			}
		}


		public SqlInt32 iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4
		{
			get
			{
				return m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4;
			}
			set
			{
				SqlInt32 iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4Tmp = (SqlInt32)value;
				if(iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4", "iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4 can't be NULL");
				}
				m_iBien_Vao_IN_1_Ra_IN_Vao_Cat_2_Ra_Cat_Vao_Dot_3_RaDot_4 = value;
			}
		}


		public SqlString sAnh
		{
			get
			{
				return m_sAnh;
			}
			set
			{
				SqlString sAnhTmp = (SqlString)value;
				if(sAnhTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sAnh", "sAnh can't be NULL");
				}
				m_sAnh = value;
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
		#endregion
	}
}
