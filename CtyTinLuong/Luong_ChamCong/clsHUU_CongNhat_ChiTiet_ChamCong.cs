using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace CtyTinLuong
{
	public partial class clsHUU_CongNhat_ChiTiet_ChamCong : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlBoolean		m_bGuiDuLieu, m_bDaTraLuong, m_bCheck_ChamCongGapDan;
			private SqlDecimal		m_dcPhuCapVeSinhMay, m_dcPhuCapXangXe, m_dcPhuCapDienthoai, m_dcLuongCongNhat, m_dcLuongCoDinh, m_dcLuongLonNhat, m_dcLuongSanLuong, m_dcBaoHiem, m_dcSoTienDaTraLuong, m_dcThucNhan, m_dcTamUng, m_dcPhuCapTienAn, m_dcTrachNhiem, m_dcTruTienAn;
			private SqlDouble		m_fTCNgay14, m_fTCNgay13, m_fTCNgay12, m_fTCNgay17, m_fTCNgay16, m_fTCNgay15, m_fTCNgay11, m_fTCNgay7, m_fTCNgay6, m_fTCNgay5, m_fTCNgay10, m_fTCNgay9, m_fTCNgay8, m_fTCNgay18, m_fTCNgay28, m_fTCNgay27, m_fTCNgay26, m_fTCNgay31, m_fTCNgay30, m_fTCNgay29, m_fTCNgay25, m_fTCNgay21, m_fTCNgay20, m_fTCNgay19, m_fTCNgay24, m_fTCNgay23, m_fTCNgay22, m_fNgay10, m_fNgay11, m_fNgay8, m_fNgay9, m_fNgay12, m_fNgay15, m_fNgay16, m_fNgay13, m_fNgay14, m_fNgay1, m_fNgay2, m_fSLThuong, m_fSLTangCa, m_fNgay3, m_fNgay6, m_fNgay7, m_fNgay4, m_fNgay5, m_fNgay17, m_fNgay29, m_fNgay30, m_fNgay27, m_fNgay28, m_fNgay31, m_fTCNgay3, m_fTCNgay4, m_fTCNgay1, m_fTCNgay2, m_fNgay20, m_fNgay21, m_fNgay18, m_fNgay19, m_fNgay22, m_fNgay25, m_fNgay26, m_fNgay23, m_fNgay24;
			private SqlInt32		m_iID_CongNhan, m_iID_ChiTietChamCong, m_iID_ChamCong, m_iNam, m_iThang, m_iID_DinhMucLuong_CongNhat;
		#endregion


		public clsHUU_CongNhat_ChiTiet_ChamCong()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CongNhat_ChiTiet_ChamCong_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSLThuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSLThuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSLTangCa", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSLTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay1));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay2));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay5));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay6));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay7));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay8));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay9));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay10));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay11));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay12));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay13));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay14));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay15));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay16));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay17));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay18));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay19));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay20));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay21));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay22));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay23));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay24));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay25));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay26));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay27));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay28));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay29));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay30));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay31));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay1));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay2));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay5));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay6));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay7));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay8));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay9));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay10));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay11));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay12));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay13));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay14));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay15));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay16));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay17));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay18));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay19));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay20));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay21));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay22));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay23));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay24));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay25));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay26));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay27));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay28));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay29));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay30));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay31));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCongNhat", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongSanLuong", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongSanLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongLonNhat", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongLonNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTruTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTruTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTamUng", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTamUng));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcSoTienDaTraLuong", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcSoTienDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcThucNhan", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcThucNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaTraLuong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_ChamCongGapDan", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_ChamCongGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietChamCong", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iID_ChiTietChamCong = (SqlInt32)scmCmdToExecute.Parameters["@iID_ChiTietChamCong"].Value;
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CongNhat_ChiTiet_ChamCong_Insert' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CongNhat_ChiTiet_ChamCong::Insert::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CongNhat_ChiTiet_ChamCong_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietChamCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_CongNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_DinhMucLuong_CongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSLThuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSLThuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSLTangCa", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSLTangCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bGuiDuLieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iNam));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay1));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay2));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay5));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay6));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay7));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay8));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay9));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay10));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay11));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay12));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay13));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay14));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay15));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay16));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay17));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay18));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay19));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay20));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay21));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay22));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay23));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay24));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay25));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay26));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay27));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay28));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay29));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay30));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fNgay31));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay1));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay2));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay3));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay4));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay5));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay6));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay7));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay8));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay9));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay10));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay11));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay12));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay13));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay14));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay15));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay16));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay17));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay18));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay19));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay20));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay21));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay22));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay23));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay24));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay25));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay26));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay27));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay28));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay29));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay30));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTCNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTCNgay31));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCoDinh", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCoDinh));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongCongNhat", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongCongNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongSanLuong", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongSanLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcLuongLonNhat", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcLuongLonNhat));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapXangXe", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapXangXe));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapDienthoai", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapDienthoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapVeSinhMay", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapVeSinhMay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcPhuCapTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcPhuCapTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTrachNhiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTrachNhiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTruTienAn", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTruTienAn));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcTamUng", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcTamUng));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcBaoHiem", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcBaoHiem));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcSoTienDaTraLuong", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcSoTienDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@dcThucNhan", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, m_dcThucNhan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bDaTraLuong", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bDaTraLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@bCheck_ChamCongGapDan", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_bCheck_ChamCongGapDan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CongNhat_ChiTiet_ChamCong_Update' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CongNhat_ChiTiet_ChamCong::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CongNhat_ChiTiet_ChamCong_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietChamCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CongNhat_ChiTiet_ChamCong_Delete' reported the ErrorCode: " + m_iErrorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CongNhat_ChiTiet_ChamCong::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CongNhat_ChiTiet_ChamCong_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_CongNhat_ChiTiet_ChamCong");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChiTietChamCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iID_ChiTietChamCong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iErrorCode));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				m_iErrorCode = (SqlInt32)scmCmdToExecute.Parameters["@iErrorCode"].Value;

				if(m_iErrorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'pr_HUU_CongNhat_ChiTiet_ChamCong_SelectOne' reported the ErrorCode: " + m_iErrorCode);
				}

				if(dtToReturn.Rows.Count > 0)
				{
					m_iID_ChiTietChamCong = (Int32)dtToReturn.Rows[0]["ID_ChiTietChamCong"];
					m_iID_ChamCong = (Int32)dtToReturn.Rows[0]["ID_ChamCong"];
					m_iID_CongNhan = (Int32)dtToReturn.Rows[0]["ID_CongNhan"];
					m_iID_DinhMucLuong_CongNhat = (Int32)dtToReturn.Rows[0]["ID_DinhMucLuong_CongNhat"];
					m_fSLThuong = (double)dtToReturn.Rows[0]["SLThuong"];
					m_fSLTangCa = (double)dtToReturn.Rows[0]["SLTangCa"];
					m_bGuiDuLieu = (bool)dtToReturn.Rows[0]["GuiDuLieu"];
					m_iThang = (Int32)dtToReturn.Rows[0]["Thang"];
					m_iNam = (Int32)dtToReturn.Rows[0]["Nam"];
					m_fNgay1 = (double)dtToReturn.Rows[0]["Ngay1"];
					m_fNgay2 = (double)dtToReturn.Rows[0]["Ngay2"];
					m_fNgay3 = (double)dtToReturn.Rows[0]["Ngay3"];
					m_fNgay4 = (double)dtToReturn.Rows[0]["Ngay4"];
					m_fNgay5 = (double)dtToReturn.Rows[0]["Ngay5"];
					m_fNgay6 = (double)dtToReturn.Rows[0]["Ngay6"];
					m_fNgay7 = (double)dtToReturn.Rows[0]["Ngay7"];
					m_fNgay8 = (double)dtToReturn.Rows[0]["Ngay8"];
					m_fNgay9 = (double)dtToReturn.Rows[0]["Ngay9"];
					m_fNgay10 = (double)dtToReturn.Rows[0]["Ngay10"];
					m_fNgay11 = (double)dtToReturn.Rows[0]["Ngay11"];
					m_fNgay12 = (double)dtToReturn.Rows[0]["Ngay12"];
					m_fNgay13 = (double)dtToReturn.Rows[0]["Ngay13"];
					m_fNgay14 = (double)dtToReturn.Rows[0]["Ngay14"];
					m_fNgay15 = (double)dtToReturn.Rows[0]["Ngay15"];
					m_fNgay16 = (double)dtToReturn.Rows[0]["Ngay16"];
					m_fNgay17 = (double)dtToReturn.Rows[0]["Ngay17"];
					m_fNgay18 = (double)dtToReturn.Rows[0]["Ngay18"];
					m_fNgay19 = (double)dtToReturn.Rows[0]["Ngay19"];
					m_fNgay20 = (double)dtToReturn.Rows[0]["Ngay20"];
					m_fNgay21 = (double)dtToReturn.Rows[0]["Ngay21"];
					m_fNgay22 = (double)dtToReturn.Rows[0]["Ngay22"];
					m_fNgay23 = (double)dtToReturn.Rows[0]["Ngay23"];
					m_fNgay24 = (double)dtToReturn.Rows[0]["Ngay24"];
					m_fNgay25 = (double)dtToReturn.Rows[0]["Ngay25"];
					m_fNgay26 = (double)dtToReturn.Rows[0]["Ngay26"];
					m_fNgay27 = (double)dtToReturn.Rows[0]["Ngay27"];
					m_fNgay28 = (double)dtToReturn.Rows[0]["Ngay28"];
					m_fNgay29 = (double)dtToReturn.Rows[0]["Ngay29"];
					m_fNgay30 = (double)dtToReturn.Rows[0]["Ngay30"];
					m_fNgay31 = (double)dtToReturn.Rows[0]["Ngay31"];
					m_fTCNgay1 = (double)dtToReturn.Rows[0]["TCNgay1"];
					m_fTCNgay2 = (double)dtToReturn.Rows[0]["TCNgay2"];
					m_fTCNgay3 = (double)dtToReturn.Rows[0]["TCNgay3"];
					m_fTCNgay4 = (double)dtToReturn.Rows[0]["TCNgay4"];
					m_fTCNgay5 = (double)dtToReturn.Rows[0]["TCNgay5"];
					m_fTCNgay6 = (double)dtToReturn.Rows[0]["TCNgay6"];
					m_fTCNgay7 = (double)dtToReturn.Rows[0]["TCNgay7"];
					m_fTCNgay8 = (double)dtToReturn.Rows[0]["TCNgay8"];
					m_fTCNgay9 = (double)dtToReturn.Rows[0]["TCNgay9"];
					m_fTCNgay10 = (double)dtToReturn.Rows[0]["TCNgay10"];
					m_fTCNgay11 = (double)dtToReturn.Rows[0]["TCNgay11"];
					m_fTCNgay12 = (double)dtToReturn.Rows[0]["TCNgay12"];
					m_fTCNgay13 = (double)dtToReturn.Rows[0]["TCNgay13"];
					m_fTCNgay14 = (double)dtToReturn.Rows[0]["TCNgay14"];
					m_fTCNgay15 = (double)dtToReturn.Rows[0]["TCNgay15"];
					m_fTCNgay16 = (double)dtToReturn.Rows[0]["TCNgay16"];
					m_fTCNgay17 = (double)dtToReturn.Rows[0]["TCNgay17"];
					m_fTCNgay18 = (double)dtToReturn.Rows[0]["TCNgay18"];
					m_fTCNgay19 = (double)dtToReturn.Rows[0]["TCNgay19"];
					m_fTCNgay20 = (double)dtToReturn.Rows[0]["TCNgay20"];
					m_fTCNgay21 = (double)dtToReturn.Rows[0]["TCNgay21"];
					m_fTCNgay22 = (double)dtToReturn.Rows[0]["TCNgay22"];
					m_fTCNgay23 = (double)dtToReturn.Rows[0]["TCNgay23"];
					m_fTCNgay24 = (double)dtToReturn.Rows[0]["TCNgay24"];
					m_fTCNgay25 = (double)dtToReturn.Rows[0]["TCNgay25"];
					m_fTCNgay26 = (double)dtToReturn.Rows[0]["TCNgay26"];
					m_fTCNgay27 = (double)dtToReturn.Rows[0]["TCNgay27"];
					m_fTCNgay28 = (double)dtToReturn.Rows[0]["TCNgay28"];
					m_fTCNgay29 = (double)dtToReturn.Rows[0]["TCNgay29"];
					m_fTCNgay30 = (double)dtToReturn.Rows[0]["TCNgay30"];
					m_fTCNgay31 = (double)dtToReturn.Rows[0]["TCNgay31"];
					m_dcLuongCoDinh = (Decimal)dtToReturn.Rows[0]["LuongCoDinh"];
					m_dcLuongCongNhat = (Decimal)dtToReturn.Rows[0]["LuongCongNhat"];
					m_dcLuongSanLuong = (Decimal)dtToReturn.Rows[0]["LuongSanLuong"];
					m_dcLuongLonNhat = (Decimal)dtToReturn.Rows[0]["LuongLonNhat"];
					m_dcPhuCapXangXe = (Decimal)dtToReturn.Rows[0]["PhuCapXangXe"];
					m_dcPhuCapDienthoai = (Decimal)dtToReturn.Rows[0]["PhuCapDienthoai"];
					m_dcPhuCapVeSinhMay = (Decimal)dtToReturn.Rows[0]["PhuCapVeSinhMay"];
					m_dcPhuCapTienAn = (Decimal)dtToReturn.Rows[0]["PhuCapTienAn"];
					m_dcTrachNhiem = (Decimal)dtToReturn.Rows[0]["TrachNhiem"];
					m_dcTruTienAn = (Decimal)dtToReturn.Rows[0]["TruTienAn"];
					m_dcTamUng = (Decimal)dtToReturn.Rows[0]["TamUng"];
					m_dcBaoHiem = (Decimal)dtToReturn.Rows[0]["BaoHiem"];
					m_dcSoTienDaTraLuong = (Decimal)dtToReturn.Rows[0]["SoTienDaTraLuong"];
					m_dcThucNhan = (Decimal)dtToReturn.Rows[0]["ThucNhan"];
					m_bDaTraLuong = (bool)dtToReturn.Rows[0]["DaTraLuong"];
					m_bCheck_ChamCongGapDan = dtToReturn.Rows[0]["Check_ChamCongGapDan"] == System.DBNull.Value ? SqlBoolean.Null : (bool)dtToReturn.Rows[0]["Check_ChamCongGapDan"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CongNhat_ChiTiet_ChamCong::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_HUU_CongNhat_ChiTiet_ChamCong_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("HUU_CongNhat_ChiTiet_ChamCong");
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
					throw new Exception("Stored Procedure 'pr_HUU_CongNhat_ChiTiet_ChamCong_SelectAll' reported the ErrorCode: " + m_iErrorCode);
				}

				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsHUU_CongNhat_ChiTiet_ChamCong::SelectAll::Error occured.", ex);
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
		public SqlInt32 iID_ChiTietChamCong
		{
			get
			{
				return m_iID_ChiTietChamCong;
			}
			set
			{
				SqlInt32 iID_ChiTietChamCongTmp = (SqlInt32)value;
				if(iID_ChiTietChamCongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChiTietChamCong", "iID_ChiTietChamCong can't be NULL");
				}
				m_iID_ChiTietChamCong = value;
			}
		}


		public SqlInt32 iID_ChamCong
		{
			get
			{
				return m_iID_ChamCong;
			}
			set
			{
				SqlInt32 iID_ChamCongTmp = (SqlInt32)value;
				if(iID_ChamCongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iID_ChamCong", "iID_ChamCong can't be NULL");
				}
				m_iID_ChamCong = value;
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


		public SqlDouble fSLThuong
		{
			get
			{
				return m_fSLThuong;
			}
			set
			{
				SqlDouble fSLThuongTmp = (SqlDouble)value;
				if(fSLThuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSLThuong", "fSLThuong can't be NULL");
				}
				m_fSLThuong = value;
			}
		}


		public SqlDouble fSLTangCa
		{
			get
			{
				return m_fSLTangCa;
			}
			set
			{
				SqlDouble fSLTangCaTmp = (SqlDouble)value;
				if(fSLTangCaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSLTangCa", "fSLTangCa can't be NULL");
				}
				m_fSLTangCa = value;
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


		public SqlInt32 iThang
		{
			get
			{
				return m_iThang;
			}
			set
			{
				SqlInt32 iThangTmp = (SqlInt32)value;
				if(iThangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iThang", "iThang can't be NULL");
				}
				m_iThang = value;
			}
		}


		public SqlInt32 iNam
		{
			get
			{
				return m_iNam;
			}
			set
			{
				SqlInt32 iNamTmp = (SqlInt32)value;
				if(iNamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iNam", "iNam can't be NULL");
				}
				m_iNam = value;
			}
		}


		public SqlDouble fNgay1
		{
			get
			{
				return m_fNgay1;
			}
			set
			{
				SqlDouble fNgay1Tmp = (SqlDouble)value;
				if(fNgay1Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay1", "fNgay1 can't be NULL");
				}
				m_fNgay1 = value;
			}
		}


		public SqlDouble fNgay2
		{
			get
			{
				return m_fNgay2;
			}
			set
			{
				SqlDouble fNgay2Tmp = (SqlDouble)value;
				if(fNgay2Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay2", "fNgay2 can't be NULL");
				}
				m_fNgay2 = value;
			}
		}


		public SqlDouble fNgay3
		{
			get
			{
				return m_fNgay3;
			}
			set
			{
				SqlDouble fNgay3Tmp = (SqlDouble)value;
				if(fNgay3Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay3", "fNgay3 can't be NULL");
				}
				m_fNgay3 = value;
			}
		}


		public SqlDouble fNgay4
		{
			get
			{
				return m_fNgay4;
			}
			set
			{
				SqlDouble fNgay4Tmp = (SqlDouble)value;
				if(fNgay4Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay4", "fNgay4 can't be NULL");
				}
				m_fNgay4 = value;
			}
		}


		public SqlDouble fNgay5
		{
			get
			{
				return m_fNgay5;
			}
			set
			{
				SqlDouble fNgay5Tmp = (SqlDouble)value;
				if(fNgay5Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay5", "fNgay5 can't be NULL");
				}
				m_fNgay5 = value;
			}
		}


		public SqlDouble fNgay6
		{
			get
			{
				return m_fNgay6;
			}
			set
			{
				SqlDouble fNgay6Tmp = (SqlDouble)value;
				if(fNgay6Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay6", "fNgay6 can't be NULL");
				}
				m_fNgay6 = value;
			}
		}


		public SqlDouble fNgay7
		{
			get
			{
				return m_fNgay7;
			}
			set
			{
				SqlDouble fNgay7Tmp = (SqlDouble)value;
				if(fNgay7Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay7", "fNgay7 can't be NULL");
				}
				m_fNgay7 = value;
			}
		}


		public SqlDouble fNgay8
		{
			get
			{
				return m_fNgay8;
			}
			set
			{
				SqlDouble fNgay8Tmp = (SqlDouble)value;
				if(fNgay8Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay8", "fNgay8 can't be NULL");
				}
				m_fNgay8 = value;
			}
		}


		public SqlDouble fNgay9
		{
			get
			{
				return m_fNgay9;
			}
			set
			{
				SqlDouble fNgay9Tmp = (SqlDouble)value;
				if(fNgay9Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay9", "fNgay9 can't be NULL");
				}
				m_fNgay9 = value;
			}
		}


		public SqlDouble fNgay10
		{
			get
			{
				return m_fNgay10;
			}
			set
			{
				SqlDouble fNgay10Tmp = (SqlDouble)value;
				if(fNgay10Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay10", "fNgay10 can't be NULL");
				}
				m_fNgay10 = value;
			}
		}


		public SqlDouble fNgay11
		{
			get
			{
				return m_fNgay11;
			}
			set
			{
				SqlDouble fNgay11Tmp = (SqlDouble)value;
				if(fNgay11Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay11", "fNgay11 can't be NULL");
				}
				m_fNgay11 = value;
			}
		}


		public SqlDouble fNgay12
		{
			get
			{
				return m_fNgay12;
			}
			set
			{
				SqlDouble fNgay12Tmp = (SqlDouble)value;
				if(fNgay12Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay12", "fNgay12 can't be NULL");
				}
				m_fNgay12 = value;
			}
		}


		public SqlDouble fNgay13
		{
			get
			{
				return m_fNgay13;
			}
			set
			{
				SqlDouble fNgay13Tmp = (SqlDouble)value;
				if(fNgay13Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay13", "fNgay13 can't be NULL");
				}
				m_fNgay13 = value;
			}
		}


		public SqlDouble fNgay14
		{
			get
			{
				return m_fNgay14;
			}
			set
			{
				SqlDouble fNgay14Tmp = (SqlDouble)value;
				if(fNgay14Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay14", "fNgay14 can't be NULL");
				}
				m_fNgay14 = value;
			}
		}


		public SqlDouble fNgay15
		{
			get
			{
				return m_fNgay15;
			}
			set
			{
				SqlDouble fNgay15Tmp = (SqlDouble)value;
				if(fNgay15Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay15", "fNgay15 can't be NULL");
				}
				m_fNgay15 = value;
			}
		}


		public SqlDouble fNgay16
		{
			get
			{
				return m_fNgay16;
			}
			set
			{
				SqlDouble fNgay16Tmp = (SqlDouble)value;
				if(fNgay16Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay16", "fNgay16 can't be NULL");
				}
				m_fNgay16 = value;
			}
		}


		public SqlDouble fNgay17
		{
			get
			{
				return m_fNgay17;
			}
			set
			{
				SqlDouble fNgay17Tmp = (SqlDouble)value;
				if(fNgay17Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay17", "fNgay17 can't be NULL");
				}
				m_fNgay17 = value;
			}
		}


		public SqlDouble fNgay18
		{
			get
			{
				return m_fNgay18;
			}
			set
			{
				SqlDouble fNgay18Tmp = (SqlDouble)value;
				if(fNgay18Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay18", "fNgay18 can't be NULL");
				}
				m_fNgay18 = value;
			}
		}


		public SqlDouble fNgay19
		{
			get
			{
				return m_fNgay19;
			}
			set
			{
				SqlDouble fNgay19Tmp = (SqlDouble)value;
				if(fNgay19Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay19", "fNgay19 can't be NULL");
				}
				m_fNgay19 = value;
			}
		}


		public SqlDouble fNgay20
		{
			get
			{
				return m_fNgay20;
			}
			set
			{
				SqlDouble fNgay20Tmp = (SqlDouble)value;
				if(fNgay20Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay20", "fNgay20 can't be NULL");
				}
				m_fNgay20 = value;
			}
		}


		public SqlDouble fNgay21
		{
			get
			{
				return m_fNgay21;
			}
			set
			{
				SqlDouble fNgay21Tmp = (SqlDouble)value;
				if(fNgay21Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay21", "fNgay21 can't be NULL");
				}
				m_fNgay21 = value;
			}
		}


		public SqlDouble fNgay22
		{
			get
			{
				return m_fNgay22;
			}
			set
			{
				SqlDouble fNgay22Tmp = (SqlDouble)value;
				if(fNgay22Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay22", "fNgay22 can't be NULL");
				}
				m_fNgay22 = value;
			}
		}


		public SqlDouble fNgay23
		{
			get
			{
				return m_fNgay23;
			}
			set
			{
				SqlDouble fNgay23Tmp = (SqlDouble)value;
				if(fNgay23Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay23", "fNgay23 can't be NULL");
				}
				m_fNgay23 = value;
			}
		}


		public SqlDouble fNgay24
		{
			get
			{
				return m_fNgay24;
			}
			set
			{
				SqlDouble fNgay24Tmp = (SqlDouble)value;
				if(fNgay24Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay24", "fNgay24 can't be NULL");
				}
				m_fNgay24 = value;
			}
		}


		public SqlDouble fNgay25
		{
			get
			{
				return m_fNgay25;
			}
			set
			{
				SqlDouble fNgay25Tmp = (SqlDouble)value;
				if(fNgay25Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay25", "fNgay25 can't be NULL");
				}
				m_fNgay25 = value;
			}
		}


		public SqlDouble fNgay26
		{
			get
			{
				return m_fNgay26;
			}
			set
			{
				SqlDouble fNgay26Tmp = (SqlDouble)value;
				if(fNgay26Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay26", "fNgay26 can't be NULL");
				}
				m_fNgay26 = value;
			}
		}


		public SqlDouble fNgay27
		{
			get
			{
				return m_fNgay27;
			}
			set
			{
				SqlDouble fNgay27Tmp = (SqlDouble)value;
				if(fNgay27Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay27", "fNgay27 can't be NULL");
				}
				m_fNgay27 = value;
			}
		}


		public SqlDouble fNgay28
		{
			get
			{
				return m_fNgay28;
			}
			set
			{
				SqlDouble fNgay28Tmp = (SqlDouble)value;
				if(fNgay28Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay28", "fNgay28 can't be NULL");
				}
				m_fNgay28 = value;
			}
		}


		public SqlDouble fNgay29
		{
			get
			{
				return m_fNgay29;
			}
			set
			{
				SqlDouble fNgay29Tmp = (SqlDouble)value;
				if(fNgay29Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay29", "fNgay29 can't be NULL");
				}
				m_fNgay29 = value;
			}
		}


		public SqlDouble fNgay30
		{
			get
			{
				return m_fNgay30;
			}
			set
			{
				SqlDouble fNgay30Tmp = (SqlDouble)value;
				if(fNgay30Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay30", "fNgay30 can't be NULL");
				}
				m_fNgay30 = value;
			}
		}


		public SqlDouble fNgay31
		{
			get
			{
				return m_fNgay31;
			}
			set
			{
				SqlDouble fNgay31Tmp = (SqlDouble)value;
				if(fNgay31Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fNgay31", "fNgay31 can't be NULL");
				}
				m_fNgay31 = value;
			}
		}


		public SqlDouble fTCNgay1
		{
			get
			{
				return m_fTCNgay1;
			}
			set
			{
				SqlDouble fTCNgay1Tmp = (SqlDouble)value;
				if(fTCNgay1Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay1", "fTCNgay1 can't be NULL");
				}
				m_fTCNgay1 = value;
			}
		}


		public SqlDouble fTCNgay2
		{
			get
			{
				return m_fTCNgay2;
			}
			set
			{
				SqlDouble fTCNgay2Tmp = (SqlDouble)value;
				if(fTCNgay2Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay2", "fTCNgay2 can't be NULL");
				}
				m_fTCNgay2 = value;
			}
		}


		public SqlDouble fTCNgay3
		{
			get
			{
				return m_fTCNgay3;
			}
			set
			{
				SqlDouble fTCNgay3Tmp = (SqlDouble)value;
				if(fTCNgay3Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay3", "fTCNgay3 can't be NULL");
				}
				m_fTCNgay3 = value;
			}
		}


		public SqlDouble fTCNgay4
		{
			get
			{
				return m_fTCNgay4;
			}
			set
			{
				SqlDouble fTCNgay4Tmp = (SqlDouble)value;
				if(fTCNgay4Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay4", "fTCNgay4 can't be NULL");
				}
				m_fTCNgay4 = value;
			}
		}


		public SqlDouble fTCNgay5
		{
			get
			{
				return m_fTCNgay5;
			}
			set
			{
				SqlDouble fTCNgay5Tmp = (SqlDouble)value;
				if(fTCNgay5Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay5", "fTCNgay5 can't be NULL");
				}
				m_fTCNgay5 = value;
			}
		}


		public SqlDouble fTCNgay6
		{
			get
			{
				return m_fTCNgay6;
			}
			set
			{
				SqlDouble fTCNgay6Tmp = (SqlDouble)value;
				if(fTCNgay6Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay6", "fTCNgay6 can't be NULL");
				}
				m_fTCNgay6 = value;
			}
		}


		public SqlDouble fTCNgay7
		{
			get
			{
				return m_fTCNgay7;
			}
			set
			{
				SqlDouble fTCNgay7Tmp = (SqlDouble)value;
				if(fTCNgay7Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay7", "fTCNgay7 can't be NULL");
				}
				m_fTCNgay7 = value;
			}
		}


		public SqlDouble fTCNgay8
		{
			get
			{
				return m_fTCNgay8;
			}
			set
			{
				SqlDouble fTCNgay8Tmp = (SqlDouble)value;
				if(fTCNgay8Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay8", "fTCNgay8 can't be NULL");
				}
				m_fTCNgay8 = value;
			}
		}


		public SqlDouble fTCNgay9
		{
			get
			{
				return m_fTCNgay9;
			}
			set
			{
				SqlDouble fTCNgay9Tmp = (SqlDouble)value;
				if(fTCNgay9Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay9", "fTCNgay9 can't be NULL");
				}
				m_fTCNgay9 = value;
			}
		}


		public SqlDouble fTCNgay10
		{
			get
			{
				return m_fTCNgay10;
			}
			set
			{
				SqlDouble fTCNgay10Tmp = (SqlDouble)value;
				if(fTCNgay10Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay10", "fTCNgay10 can't be NULL");
				}
				m_fTCNgay10 = value;
			}
		}


		public SqlDouble fTCNgay11
		{
			get
			{
				return m_fTCNgay11;
			}
			set
			{
				SqlDouble fTCNgay11Tmp = (SqlDouble)value;
				if(fTCNgay11Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay11", "fTCNgay11 can't be NULL");
				}
				m_fTCNgay11 = value;
			}
		}


		public SqlDouble fTCNgay12
		{
			get
			{
				return m_fTCNgay12;
			}
			set
			{
				SqlDouble fTCNgay12Tmp = (SqlDouble)value;
				if(fTCNgay12Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay12", "fTCNgay12 can't be NULL");
				}
				m_fTCNgay12 = value;
			}
		}


		public SqlDouble fTCNgay13
		{
			get
			{
				return m_fTCNgay13;
			}
			set
			{
				SqlDouble fTCNgay13Tmp = (SqlDouble)value;
				if(fTCNgay13Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay13", "fTCNgay13 can't be NULL");
				}
				m_fTCNgay13 = value;
			}
		}


		public SqlDouble fTCNgay14
		{
			get
			{
				return m_fTCNgay14;
			}
			set
			{
				SqlDouble fTCNgay14Tmp = (SqlDouble)value;
				if(fTCNgay14Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay14", "fTCNgay14 can't be NULL");
				}
				m_fTCNgay14 = value;
			}
		}


		public SqlDouble fTCNgay15
		{
			get
			{
				return m_fTCNgay15;
			}
			set
			{
				SqlDouble fTCNgay15Tmp = (SqlDouble)value;
				if(fTCNgay15Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay15", "fTCNgay15 can't be NULL");
				}
				m_fTCNgay15 = value;
			}
		}


		public SqlDouble fTCNgay16
		{
			get
			{
				return m_fTCNgay16;
			}
			set
			{
				SqlDouble fTCNgay16Tmp = (SqlDouble)value;
				if(fTCNgay16Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay16", "fTCNgay16 can't be NULL");
				}
				m_fTCNgay16 = value;
			}
		}


		public SqlDouble fTCNgay17
		{
			get
			{
				return m_fTCNgay17;
			}
			set
			{
				SqlDouble fTCNgay17Tmp = (SqlDouble)value;
				if(fTCNgay17Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay17", "fTCNgay17 can't be NULL");
				}
				m_fTCNgay17 = value;
			}
		}


		public SqlDouble fTCNgay18
		{
			get
			{
				return m_fTCNgay18;
			}
			set
			{
				SqlDouble fTCNgay18Tmp = (SqlDouble)value;
				if(fTCNgay18Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay18", "fTCNgay18 can't be NULL");
				}
				m_fTCNgay18 = value;
			}
		}


		public SqlDouble fTCNgay19
		{
			get
			{
				return m_fTCNgay19;
			}
			set
			{
				SqlDouble fTCNgay19Tmp = (SqlDouble)value;
				if(fTCNgay19Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay19", "fTCNgay19 can't be NULL");
				}
				m_fTCNgay19 = value;
			}
		}


		public SqlDouble fTCNgay20
		{
			get
			{
				return m_fTCNgay20;
			}
			set
			{
				SqlDouble fTCNgay20Tmp = (SqlDouble)value;
				if(fTCNgay20Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay20", "fTCNgay20 can't be NULL");
				}
				m_fTCNgay20 = value;
			}
		}


		public SqlDouble fTCNgay21
		{
			get
			{
				return m_fTCNgay21;
			}
			set
			{
				SqlDouble fTCNgay21Tmp = (SqlDouble)value;
				if(fTCNgay21Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay21", "fTCNgay21 can't be NULL");
				}
				m_fTCNgay21 = value;
			}
		}


		public SqlDouble fTCNgay22
		{
			get
			{
				return m_fTCNgay22;
			}
			set
			{
				SqlDouble fTCNgay22Tmp = (SqlDouble)value;
				if(fTCNgay22Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay22", "fTCNgay22 can't be NULL");
				}
				m_fTCNgay22 = value;
			}
		}


		public SqlDouble fTCNgay23
		{
			get
			{
				return m_fTCNgay23;
			}
			set
			{
				SqlDouble fTCNgay23Tmp = (SqlDouble)value;
				if(fTCNgay23Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay23", "fTCNgay23 can't be NULL");
				}
				m_fTCNgay23 = value;
			}
		}


		public SqlDouble fTCNgay24
		{
			get
			{
				return m_fTCNgay24;
			}
			set
			{
				SqlDouble fTCNgay24Tmp = (SqlDouble)value;
				if(fTCNgay24Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay24", "fTCNgay24 can't be NULL");
				}
				m_fTCNgay24 = value;
			}
		}


		public SqlDouble fTCNgay25
		{
			get
			{
				return m_fTCNgay25;
			}
			set
			{
				SqlDouble fTCNgay25Tmp = (SqlDouble)value;
				if(fTCNgay25Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay25", "fTCNgay25 can't be NULL");
				}
				m_fTCNgay25 = value;
			}
		}


		public SqlDouble fTCNgay26
		{
			get
			{
				return m_fTCNgay26;
			}
			set
			{
				SqlDouble fTCNgay26Tmp = (SqlDouble)value;
				if(fTCNgay26Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay26", "fTCNgay26 can't be NULL");
				}
				m_fTCNgay26 = value;
			}
		}


		public SqlDouble fTCNgay27
		{
			get
			{
				return m_fTCNgay27;
			}
			set
			{
				SqlDouble fTCNgay27Tmp = (SqlDouble)value;
				if(fTCNgay27Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay27", "fTCNgay27 can't be NULL");
				}
				m_fTCNgay27 = value;
			}
		}


		public SqlDouble fTCNgay28
		{
			get
			{
				return m_fTCNgay28;
			}
			set
			{
				SqlDouble fTCNgay28Tmp = (SqlDouble)value;
				if(fTCNgay28Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay28", "fTCNgay28 can't be NULL");
				}
				m_fTCNgay28 = value;
			}
		}


		public SqlDouble fTCNgay29
		{
			get
			{
				return m_fTCNgay29;
			}
			set
			{
				SqlDouble fTCNgay29Tmp = (SqlDouble)value;
				if(fTCNgay29Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay29", "fTCNgay29 can't be NULL");
				}
				m_fTCNgay29 = value;
			}
		}


		public SqlDouble fTCNgay30
		{
			get
			{
				return m_fTCNgay30;
			}
			set
			{
				SqlDouble fTCNgay30Tmp = (SqlDouble)value;
				if(fTCNgay30Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay30", "fTCNgay30 can't be NULL");
				}
				m_fTCNgay30 = value;
			}
		}


		public SqlDouble fTCNgay31
		{
			get
			{
				return m_fTCNgay31;
			}
			set
			{
				SqlDouble fTCNgay31Tmp = (SqlDouble)value;
				if(fTCNgay31Tmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTCNgay31", "fTCNgay31 can't be NULL");
				}
				m_fTCNgay31 = value;
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


		public SqlDecimal dcLuongCongNhat
		{
			get
			{
				return m_dcLuongCongNhat;
			}
			set
			{
				SqlDecimal dcLuongCongNhatTmp = (SqlDecimal)value;
				if(dcLuongCongNhatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongCongNhat", "dcLuongCongNhat can't be NULL");
				}
				m_dcLuongCongNhat = value;
			}
		}


		public SqlDecimal dcLuongSanLuong
		{
			get
			{
				return m_dcLuongSanLuong;
			}
			set
			{
				SqlDecimal dcLuongSanLuongTmp = (SqlDecimal)value;
				if(dcLuongSanLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongSanLuong", "dcLuongSanLuong can't be NULL");
				}
				m_dcLuongSanLuong = value;
			}
		}


		public SqlDecimal dcLuongLonNhat
		{
			get
			{
				return m_dcLuongLonNhat;
			}
			set
			{
				SqlDecimal dcLuongLonNhatTmp = (SqlDecimal)value;
				if(dcLuongLonNhatTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcLuongLonNhat", "dcLuongLonNhat can't be NULL");
				}
				m_dcLuongLonNhat = value;
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


		public SqlDecimal dcTruTienAn
		{
			get
			{
				return m_dcTruTienAn;
			}
			set
			{
				SqlDecimal dcTruTienAnTmp = (SqlDecimal)value;
				if(dcTruTienAnTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcTruTienAn", "dcTruTienAn can't be NULL");
				}
				m_dcTruTienAn = value;
			}
		}


		public SqlDecimal dcTamUng
		{
			get
			{
				return m_dcTamUng;
			}
			set
			{
				SqlDecimal dcTamUngTmp = (SqlDecimal)value;
				if(dcTamUngTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcTamUng", "dcTamUng can't be NULL");
				}
				m_dcTamUng = value;
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


		public SqlDecimal dcSoTienDaTraLuong
		{
			get
			{
				return m_dcSoTienDaTraLuong;
			}
			set
			{
				SqlDecimal dcSoTienDaTraLuongTmp = (SqlDecimal)value;
				if(dcSoTienDaTraLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcSoTienDaTraLuong", "dcSoTienDaTraLuong can't be NULL");
				}
				m_dcSoTienDaTraLuong = value;
			}
		}


		public SqlDecimal dcThucNhan
		{
			get
			{
				return m_dcThucNhan;
			}
			set
			{
				SqlDecimal dcThucNhanTmp = (SqlDecimal)value;
				if(dcThucNhanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("dcThucNhan", "dcThucNhan can't be NULL");
				}
				m_dcThucNhan = value;
			}
		}


		public SqlBoolean bDaTraLuong
		{
			get
			{
				return m_bDaTraLuong;
			}
			set
			{
				SqlBoolean bDaTraLuongTmp = (SqlBoolean)value;
				if(bDaTraLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bDaTraLuong", "bDaTraLuong can't be NULL");
				}
				m_bDaTraLuong = value;
			}
		}


		public SqlBoolean bCheck_ChamCongGapDan
		{
			get
			{
				return m_bCheck_ChamCongGapDan;
			}
			set
			{
				SqlBoolean bCheck_ChamCongGapDanTmp = (SqlBoolean)value;
				if(bCheck_ChamCongGapDanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("bCheck_ChamCongGapDan", "bCheck_ChamCongGapDan can't be NULL");
				}
				m_bCheck_ChamCongGapDan = value;
			}
		}
		#endregion
	}
}
