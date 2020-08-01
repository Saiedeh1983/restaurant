

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using restaurant.COMMON;

namespace restaurant.DAL
{
    public class UtilityDAL
    {
        #region Utility

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Utility LoadUtility(int UtilityID)
        {
            string SqlStr = "select * from tblUtility where UtilityIsDel=0 and UtilityID=@UtilityID";
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
            }
            r.Close();
            cn.Close();
            return Utility;
        }
        public List<Utility> LoadUtilityListWithDistinctRentID(int UserID)
        {
            string SqlStr = "select distinct RentID from tblUtility where (UtilityIsDel=0) and UserID=@UserID ";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Utility = new Utility();
                Utility.RentID = int.Parse(r2[0].ToString());

                UtilityList.Add(Utility);
            }
            r2.Close();
            cn.Close();
            return UtilityList;
        }

        public List<Utility> LoadUtilityList3(int RentID)
        {
            string SqlStr = "select F.UtilityID,F.RentID,F.amount,F.TypeOfBill,F.FromDate,F.UntilDate,F.[Desc],F.UserID,F.UtilityIsDel from tblUtility as F INNER JOIN tblRent on F.RentID=tblRent.RentID where (F.UtilityIsDel=0) and F.RentID=@RentID";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Utility = new Utility();
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
                UtilityList.Add(Utility);
            }
            r.Close();
            cn.Close();
            return UtilityList;
        }
       
        public Utility LoadUtilityWithRentID(int RentID)
        {
            string SqlStr = "select * from tblUtility where UtilityIsDel=0 and RentID=@RentID";
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
            }
            r.Close();
            cn.Close();
            return Utility;
        }

        public List<Utility> LoadUtilityList2()
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0)";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Utility = new Utility();
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
                UtilityList.Add(Utility);
            }
            r.Close();
            cn.Close();
            return UtilityList;
        }
        public DataTable LoadUtilityListFORExcel(int UserID)
        {
            string SqlStr = "select tblRent.ContractNumber,tblRent.Type,F.amount,F.TypeOfBill,F.FromDate,F.UntilDate,F.[Desc] from tblUtility as F INNER JOIN tblRent on F.RentID=tblRent.RentID where (F.UtilityIsDel=0) and F.UserID=@UserID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable LoadUtilityListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable LoadUtilityListwithUserID(int UserID)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and UserID=@UserID ";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

       
        public DataTable LoadUtilityList(int RentID)
        {
            string SqlStr = "select F.UtilityID,tblRent.ContractNumber,tblRent.Type,F.amount,F.TypeOfBill,F.FromDate,F.UntilDate,F.RentID,F.[Desc],F.UserID,F.UtilityIsDel from tblUtility as F INNER JOIN tblRent on F.RentID=tblRent.RentID where (F.UtilityIsDel=0) and F.RentID=@RentID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

     

        public Utility LoadUtilityWithRentID(int RentID, int UtilityID)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and RentID=@RentID and UtilityID=@UtilityID ";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Utility = new Utility();
            Utility.UtilityID = int.Parse(r[0].ToString());
            Utility.RentID = int.Parse(r[1].ToString());
            Utility.amount = int.Parse(r[2].ToString());
            Utility.TypeOfBill = r[3].ToString();
            Utility.FromDate = r[4].ToString();
            Utility.UntilDate = r[5].ToString();
            Utility.Desc = r[6].ToString();
            Utility.UserID = int.Parse(r[7].ToString());
            //UtilityList.Add(Utility);
            // }
            r.Close();
            cn.Close();
            return Utility;
        }

        public List<Utility> LoadUtilityListWithRentID(int RentID)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and RentID=@RentID ";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            // cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Utility = new Utility();
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
                UtilityList.Add(Utility);
            }
            r.Close();
            cn.Close();
            return UtilityList;
        }
        public List<Utility> LoadUtilityListWithDateAndUserID(string FromDate, string UntillDate, int UserID)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND UserID=@UserID";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Utility = new Utility();
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
                UtilityList.Add(Utility);
            }
            r.Close();
            cn.Close();
            return UtilityList;
        }

        public List<Utility> LoadUtilityListContorID(int UserID)
        {
            string SqlStr = "select * from tblUtility where (UtilityIsDel=0) and UserID=@UserID";
            List<Utility> UtilityList = new List<Utility>();
            Utility Utility = new Utility();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Utility = new Utility();
                Utility.UtilityID = int.Parse(r[0].ToString());
                Utility.RentID = int.Parse(r[1].ToString());
                Utility.amount = int.Parse(r[2].ToString());
                Utility.TypeOfBill = r[3].ToString();
                Utility.FromDate = r[4].ToString();
                Utility.UntilDate = r[5].ToString();
                Utility.Desc = r[6].ToString();
                Utility.UserID = int.Parse(r[7].ToString());
                UtilityList.Add(Utility);
            }
            r.Close();
            cn.Close();
            return UtilityList;
        }

        public bool InsertUtility(Utility utility)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblUtility " +
                              " (RentID,amount,TypeOfBill,FromDate,UntilDate,[Desc],UserID)" +
                              " VALUES (@RentID,@amount,@TypeOfBill,@FromDate,@UntilDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Utility Utility = new Utility();
            Utility = utility;
            cmd.Parameters.AddWithValue("@UtilityID", Utility.UtilityID);
            cmd.Parameters.AddWithValue("@RentID", Utility.RentID);
            cmd.Parameters.AddWithValue("@amount", Utility.amount);
            cmd.Parameters.AddWithValue("@TypeOfBill", Utility.TypeOfBill);
            cmd.Parameters.AddWithValue("@FromDate", Utility.FromDate);
            cmd.Parameters.AddWithValue("@UntilDate", Utility.UntilDate);
            cmd.Parameters.AddWithValue("@Desc", Utility.Desc);
            cmd.Parameters.AddWithValue("@UserID", Utility.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditUtility(Utility utility)
        {
            string SqlStr = "UPDATE tblUtility " +
                                 " SET RentID = @RentID, amount = @amount,TypeOfBill = @TypeOfBill,FromDate = @FromDate, UntilDate=@UntilDate ,[Desc]=@Desc,UserID=@UserID WHERE UtilityID=@UtilityID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Utility Utility = new Utility();
            Utility = utility;
            cmd.Parameters.AddWithValue("@UtilityID", Utility.UtilityID);
            cmd.Parameters.AddWithValue("@RentID", Utility.RentID);
            cmd.Parameters.AddWithValue("@amount", Utility.amount);
            cmd.Parameters.AddWithValue("@TypeOfBill", Utility.TypeOfBill);
            cmd.Parameters.AddWithValue("@FromDate", Utility.FromDate);
            cmd.Parameters.AddWithValue("@UntilDate", Utility.UntilDate);
            cmd.Parameters.AddWithValue("@Desc", Utility.Desc);
            cmd.Parameters.AddWithValue("@UserID", Utility.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteUtility(int UtilityID, int UserID)
        {
            string SqlStr = "UPDATE tblUtility SET UtilityIsDel =1 where UtilityID=@UtilityID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UtilityID", UtilityID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Utility
    }
}
