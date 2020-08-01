using System;
using System.Collections.Generic;
using System.Text;
using restaurant.COMMON;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace restaurant.DAL
{
   public class DetailInfoDAL
    {
        #region   DetailInfo

       SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public DataTable LoadDetailInfoForGrid(Int64 BaseInfoID)
        {
            string SqlStr = "SELECT tblDetailInfo.DetailInfoID,tblDetailInfo.DetailInfoTitle,tblBaseInfo.BaseInfoTitle,tblDetailInfo.DetailInfoDesc " +
            "FROM tblBaseInfo,tblDetailInfo " +
            " WHERE tblDetailInfo.BaseInfoID=@BaseInfoID and tblBaseInfo.BaseInfoID=tblDetailInfo.BaseInfoID ";
            //string SqlStr = "select * from tblDetailInfo WHERE BaseInfoID=@BaseInfoID";
            ////////if (cn.State == ConnectionState.Closed) cn.Open();
            //////// cmd.Parameters.AddWithValue("@BaseInfoID", BaseInfoID);
            //////// cmd = new SqlCommand(SqlStr, cn);

            //////// SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //////// DataTable dt = new DataTable("tblDetailInfo");
            //////// dt.Columns.Add("DetailInfoID", typeof(int));
            //////// dt.Columns.Add("DetailInfoTitle", typeof(string));
            //////// dt.Columns.Add("BaseInfoTitle", typeof(int));
            //////// dt.Columns.Add("DetailInfoDesc", typeof(string));
            //////// cn.Close();
            //////// //Da.Fill(dt);
            //////// return dt;
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@BaseInfoID", BaseInfoID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public List<DetailInfo> LoadDetailInfoListWithBaseID(int baseInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0) and BaseInfoID=@BaseInfoID ORDER BY DetailInfoTitle";
            DetailInfo detailInfo = new DetailInfo();
            List<DetailInfo> DList = new List<DetailInfo>();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
            cmd.CommandType = CommandType.Text;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                detailInfo = new DetailInfo();
                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
                detailInfo.DetailInfoTitle = r[1].ToString();
                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
                detailInfo.DetailInfoDesc = r[3].ToString();
                DList.Add(detailInfo);
            }
            r.Close();
            cn.Close();
            return DList;
        }
        public List<DetailInfo> LoadDetailInfoListWithBaseID3(int baseInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0) and BaseInfoID=@BaseInfoID ORDER BY DetailInfoTitle";
            DetailInfo Detail = new DetailInfo();
            List<DetailInfo> DList = new List<DetailInfo>();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
            DataTable r1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(r1);
            for (int co = 0; co < r1.Rows.Count; co++)
            {
                Detail = new DetailInfo();
                Detail.DetailInfoID = Convert.ToInt32(r1.Rows[co].ItemArray.GetValue(0));
                Detail.DetailInfoTitle = r1.Rows[co].ItemArray.GetValue(1).ToString();
                Detail.BaseInfoID = Convert.ToInt32(r1.Rows[co].ItemArray.GetValue(2));
                Detail.DetailInfoDesc = r1.Rows[co].ItemArray.GetValue(3).ToString();
                DList.Add(Detail);
            }

            cn.Close();
            return DList;
        }
        public DetailInfo LoadDetailInfoWithTitle(string DetailInfoTitle)
        {
            string SqlStr = "select * from tblDetailInfo where DetailInfoTitle=@DetailInfoTitle";
            DetailInfo detailInfo = new DetailInfo();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoTitle", DetailInfoTitle);
            cmd.CommandType = CommandType.Text;
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
                detailInfo.DetailInfoTitle = r[1].ToString();
                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
                detailInfo.DetailInfoDesc = r[3].ToString();
            }
            r.Close();
            cn.Close();
            return detailInfo;
        }

        public DetailInfo LoadDetailInfo(int DetailInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where DetailInfoID=@DetailInfoID AND (IsDel=0)";
            DetailInfo detailInfo = new DetailInfo();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoID", DetailInfoID);
            cmd.CommandType = CommandType.Text;
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
                detailInfo.DetailInfoTitle = r[1].ToString();
                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
                detailInfo.DetailInfoDesc = r[3].ToString();
            }
            r.Close();
            cn.Close();
            return detailInfo;
        }


        public List<DetailInfo> LoadDetailInfoList2()
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0)";
            DetailInfo Detail = new DetailInfo();
            List<DetailInfo> DList = new List<DetailInfo>();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            DataTable r = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(r);
            for (int co = 0; co < r.Rows.Count; co++)
            {
                Detail = new DetailInfo();
                Detail.DetailInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(0));
                Detail.DetailInfoTitle = r.Rows[co].ItemArray.GetValue(1).ToString();
                Detail.BaseInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(2));
                Detail.DetailInfoDesc = r.Rows[co].ItemArray.GetValue(3).ToString();
                DList.Add(Detail);
            }

            cn.Close();
            return DList;
        }
        public DataTable LoadDetailInfoList()
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable LoadDetailInfoListWithBaseInfo(int BaseInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0) and BaseInfoID=@BaseInfoID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BaseInfoID", BaseInfoID);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }


        public bool InsertDetailInfo(DetailInfo detailInfo1)
        {
            try
            {
                string SqlStr = "Insert into tblDetailInfo " +
                                  " (DetailInfoTitle,BaseInfoID,DetailInfoDesc)" +
                                  " VALUES (@DetailInfoTitle,@BaseInfoID,@DetailInfoDesc)";
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd = new SqlCommand(SqlStr, cn);
                DetailInfo detailInfo = new DetailInfo();
                detailInfo = detailInfo1;
                cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
                cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
                cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch { return false; }
        }

        public void EditDetailInfo(DetailInfo DetailInfo)
        {
            string SqlStr = "UPDATE tblDetailInfo " +
                                 " SET DetailInfoTitle = @DetailInfoTitle, BaseInfoID = @BaseInfoID, DetailInfoDesc=@DetailInfoDesc where DetailInfoID=@DetailInfoID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            DetailInfo detailInfo = new DetailInfo();
            detailInfo = DetailInfo;
            cmd.Parameters.AddWithValue("@DetailInfoID", detailInfo.DetailInfoID);
            cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
            cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
            cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteDetailInfo(int detailInfoID)
        {
            string SqlStr = "UPDATE tblDetailInfo SET IsDel=1 where DetailInfoID=@DetailInfoID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoID", detailInfoID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion  DetailInfo
    }
}
