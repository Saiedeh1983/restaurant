

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
    public class InsuranceDAL
    {
        #region Insurance

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Insurance LoadInsurance(int InsuranceID)
        {
            string SqlStr = "select * from tblInsurance where InsuranceIsDel=0 and InsuranceID=@InsuranceID";
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@InsuranceID", InsuranceID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Insurance.InsuranceID = int.Parse(r[0].ToString());
                Insurance.CarID = int.Parse(r[1].ToString());
                Insurance.amount = int.Parse(r[2].ToString());
                Insurance.Date = r[3].ToString();
                Insurance.ExpireDate = r[4].ToString();
                Insurance.Desc = r[5].ToString();
                Insurance.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Insurance;
        }
        public List<Insurance> LoadInsuranceList3(int CarID)
        {
            string SqlStr = "select F.InsuranceID,F.CarID,F.amount,F.Date,F.expireDate,F.[Desc],F.UserID,F.InsuranceIsDel from tblInsurance as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.InsuranceIsDel=0) and F.CarID=@CarID";
            List<Insurance> InsuranceList = new List<Insurance>();
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Insurance = new Insurance();
                Insurance.InsuranceID = int.Parse(r[0].ToString());
                Insurance.CarID = int.Parse(r[1].ToString());
                Insurance.amount = int.Parse(r[2].ToString());
                Insurance.Date = r[3].ToString();
                Insurance.ExpireDate = r[4].ToString();
                Insurance.Desc = r[5].ToString();
                Insurance.UserID = int.Parse(r[6].ToString());
                InsuranceList.Add(Insurance);
            }
            r.Close();
            cn.Close();
            return InsuranceList;
        }

        public List<Insurance> LoadInsuranceListWithDistinctCarID(int UserID)
        {
            string SqlStr = "select distinct CarID from tblInsurance where (InsuranceIsDel=0) and UserID=@UserID ";
            List<Insurance> InsuranceList = new List<Insurance>();
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Insurance = new Insurance();
                Insurance.CarID = int.Parse(r2[0].ToString());

                InsuranceList.Add(Insurance);
            }
            r2.Close();
            cn.Close();
            return InsuranceList;
        }
        public Insurance LoadInsuranceWithTitle(int CarID)
        {
            string SqlStr = "select * from tblInsurance where InsuranceIsDel=0 and CarID=@CarID";
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Insurance.InsuranceID = int.Parse(r[0].ToString());
                Insurance.CarID = int.Parse(r[1].ToString());
                Insurance.amount = int.Parse(r[2].ToString());
                Insurance.Date = r[3].ToString();
                Insurance.ExpireDate = r[4].ToString();
                Insurance.Desc = r[5].ToString();
                Insurance.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Insurance;
        }

        public List<Insurance> LoadInsuranceList2()
        {
            string SqlStr = "select * from tblInsurance where (InsuranceIsDel=0)";
            List<Insurance> InsuranceList = new List<Insurance>();
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Insurance = new Insurance();
                Insurance.InsuranceID = int.Parse(r[0].ToString());
                Insurance.CarID = int.Parse(r[1].ToString());
                Insurance.amount = int.Parse(r[2].ToString());
                Insurance.Date = r[3].ToString();
                Insurance.ExpireDate = r[4].ToString();
                Insurance.Desc = r[5].ToString();
                Insurance.UserID = int.Parse(r[6].ToString());
                InsuranceList.Add(Insurance);
            }
            r.Close();
            cn.Close();
            return InsuranceList;
        }
        public DataTable LoadInsuranceListWithDateUntilDate(string Date, int ExpireDate)
        {
            string SqlStr = "select * from tblInsurance where (InsuranceIsDel=0) and Date=@Date and ExpireDate=@ExpireDate";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable LoadInsuranceListFORExcel(int UserID)
        {
            string SqlStr = "select tblCar.number,tblCar.Type,F.amount,F.Date,F.ExpireDate,F.[Desc] from tblInsurance as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.InsuranceIsDel=0) and F.UserID=@UserID";
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

        public DataTable LoadInsuranceList(int CarID)
        {
            string SqlStr = "select F.InsuranceID,tblCar.number,tblCar.Type,F.amount,F.Date,F.ExpireDate,F.CarID,F.[Desc],F.UserID,F.InsuranceIsDel from tblInsurance as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.InsuranceIsDel=0) and F.CarID=@CarID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public int accountinglastsalary(int CarID, int InsuranceID)
        {
            string SqlStr = "select (InsuranceID) AS From tblInsurance Where InsuranceIsDel=0";
            // string SqlStr = "select F.InsuranceID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.CarID,F.[Desc],F.UserID,F.InsuranceIsDel from tblInsurance as F INNER JOIN tblPerson on F.CarID=tblPerson.CarID where (F.InsuranceIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Insurance LoadInsuranceWithCarID(int CarID, int InsuranceID)
        {
            string SqlStr = "select * from tblInsurance where (InsuranceIsDel=0) and CarID=@CarID and InsuranceID=@InsuranceID ";
            List<Insurance> InsuranceList = new List<Insurance>();
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@InsuranceID", InsuranceID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Insurance = new Insurance();
            Insurance.InsuranceID = int.Parse(r[0].ToString());
            Insurance.CarID = int.Parse(r[1].ToString());
            Insurance.amount = int.Parse(r[2].ToString());
            Insurance.Date = r[3].ToString();
            Insurance.ExpireDate = r[4].ToString();
            Insurance.Desc = r[5].ToString();
            Insurance.UserID = int.Parse(r[6].ToString());
            //InsuranceList.Add(Insurance);
            // }
            r.Close();
            cn.Close();
            return Insurance;
        }

        public List<Insurance> LoadInsuranceListWithCarID(int CarID)
        {
            string SqlStr = "select * from tblInsurance where (InsuranceIsDel=0) and CarID=@CarID ";
            List<Insurance> InsuranceList = new List<Insurance>();
            Insurance Insurance = new Insurance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            // cmd.Parameters.AddWithValue("@InsuranceID", InsuranceID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Insurance = new Insurance();
                Insurance.InsuranceID = int.Parse(r[0].ToString());
                Insurance.CarID = int.Parse(r[1].ToString());
                Insurance.amount = int.Parse(r[2].ToString());
                Insurance.Date = r[3].ToString();
                Insurance.ExpireDate = r[4].ToString();
                Insurance.Desc = r[5].ToString();
                Insurance.UserID = int.Parse(r[6].ToString());
                InsuranceList.Add(Insurance);
            }
            r.Close();
            cn.Close();
            return InsuranceList;
        }


      
        public bool InsertInsurance(Insurance insurance)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblInsurance " +
                              " (CarID,amount,Date,ExpireDate,[Desc],UserID)" +
                              " VALUES (@CarID,@amount,@Date,@ExpireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Insurance Insurance = new Insurance();
            Insurance = insurance;
            cmd.Parameters.AddWithValue("@InsuranceID", Insurance.InsuranceID);
            cmd.Parameters.AddWithValue("@CarID", Insurance.CarID);
            cmd.Parameters.AddWithValue("@amount", Insurance.amount);
            cmd.Parameters.AddWithValue("@Date", Insurance.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Insurance.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Insurance.Desc);
            cmd.Parameters.AddWithValue("@UserID", Insurance.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditInsurance(Insurance insurance)
        {
            string SqlStr = "UPDATE tblInsurance " +
                                 " SET CarID = @CarID, amount = @amount, Date=@Date,ExpireDate=@ExpireDate ,[Desc]=@Desc,UserID=@UserID WHERE InsuranceID=@InsuranceID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Insurance Insurance = new Insurance();
            Insurance = insurance;
            cmd.Parameters.AddWithValue("@InsuranceID", Insurance.InsuranceID);
            cmd.Parameters.AddWithValue("@CarID", Insurance.CarID);
            cmd.Parameters.AddWithValue("@amount", Insurance.amount);
            cmd.Parameters.AddWithValue("@Date", Insurance.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Insurance.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Insurance.Desc);
            cmd.Parameters.AddWithValue("@UserID", Insurance.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteInsurance(int InsuranceID, int UserID)
        {
            string SqlStr = "UPDATE tblInsurance SET InsuranceIsDel =1 where InsuranceID=@InsuranceID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@InsuranceID", InsuranceID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Insurance
    }
}
