

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
    public class DriverLicenseDAL
    {
        #region DriverLicense

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public DriverLicense LoadDriverLicense(int DriverLicenseID)
        {
            string SqlStr = "select * from tblDriverLicense where DriverLicenseIsDel=0 and DriverLicenseID=@DriverLicenseID";
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return DriverLicense;
        }
        public DataTable LoadDriverLicenseListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.[Desc] from tblDriverLicense as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.DriverLicenseIsDel=0) and F.UserID=@UserID";
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
        public List<DriverLicense> LoadDriverLicenseList3(int PersonID)
        {
            string SqlStr = "select F.DriverLicenseID,F.PersonID,F.number,F.expireDate,F.[Desc],F.UserID,F.DriverLicenseIsDel from tblDriverLicense as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.DriverLicenseIsDel=0) and F.PersonID=@PersonID";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
                DriverLicenseList.Add(DriverLicense);
            }
            r.Close();
            cn.Close();
            return DriverLicenseList;
        }
        public List<DriverLicense> LoadDriverLicenseListWithDistinctPersonID(int UserID)
        {
            string SqlStr = "select distinct PersonID from tblDriverLicense where (DriverLicenseIsDel=0) and UserID=@UserID ";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense.PersonID = int.Parse(r2[0].ToString());

                DriverLicenseList.Add(DriverLicense);
            }
            r2.Close();
            cn.Close();
            return DriverLicenseList;
        }

        public DriverLicense LoadDriverLicenseWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblDriverLicense where DriverLicenseIsDel=0 and PersonID=@PersonID";
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return DriverLicense;
        }

        public List<DriverLicense> LoadDriverLicenseList2()
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0)";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
                DriverLicenseList.Add(DriverLicense);
            }
            r.Close();
            cn.Close();
            return DriverLicenseList;
        }
        public DataTable LoadDriverLicenseListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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


        public DataTable LoadDriverLicenseList(int PersonID)
        {
            string SqlStr = "select F.DriverLicenseID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.DriverLicenseIsDel from tblDriverLicense as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.DriverLicenseIsDel=0) and F.PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public int accountinglastsalary(int PersonID, int DriverLicenseID)
        {
            string SqlStr = "select (DriverLicenseID) AS From tblDriverLicense Where DriverLicenseIsDel=0";
            // string SqlStr = "select F.DriverLicenseID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.DriverLicenseIsDel from tblDriverLicense as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.DriverLicenseIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public DriverLicense LoadDriverLicenseWithPersonID(int PersonID, int DriverLicenseID)
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0) and PersonID=@PersonID and DriverLicenseID=@DriverLicenseID ";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //DriverLicense = new DriverLicense();
            DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
            DriverLicense.PersonID = int.Parse(r[1].ToString());
            DriverLicense.number = r[2].ToString();
            DriverLicense.expireDate = r[3].ToString();
            DriverLicense.Desc = r[4].ToString();
            DriverLicense.UserID = int.Parse(r[5].ToString());
            //DriverLicenseList.Add(DriverLicense);
            // }
            r.Close();
            cn.Close();
            return DriverLicense;
        }

        public List<DriverLicense> LoadDriverLicenseListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0) and PersonID=@PersonID ";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
                DriverLicenseList.Add(DriverLicense);
            }
            r.Close();
            cn.Close();
            return DriverLicenseList;
        }
        public List<DriverLicense> LoadDriverLicenseListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense = new DriverLicense();
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
                DriverLicenseList.Add(DriverLicense);
            }
            r.Close();
            cn.Close();
            return DriverLicenseList;
        }

        public List<DriverLicense> LoadDriverLicenseListContorID(int UserID)
        {
            string SqlStr = "select * from tblDriverLicense where (DriverLicenseIsDel=0) and UserID=@UserID";
            List<DriverLicense> DriverLicenseList = new List<DriverLicense>();
            DriverLicense DriverLicense = new DriverLicense();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DriverLicense = new DriverLicense();
                DriverLicense.DriverLicenseID = int.Parse(r[0].ToString());
                DriverLicense.PersonID = int.Parse(r[1].ToString());
                DriverLicense.number = r[2].ToString();
                DriverLicense.expireDate = r[3].ToString();
                DriverLicense.Desc = r[4].ToString();
                DriverLicense.UserID = int.Parse(r[5].ToString());
                DriverLicenseList.Add(DriverLicense);
            }
            r.Close();
            cn.Close();
            return DriverLicenseList;
        }

        public bool InsertDriverLicense(DriverLicense driverLicense)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblDriverLicense " +
                              " (PersonID,number,expireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@expireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            DriverLicense DriverLicense = new DriverLicense();
            DriverLicense = driverLicense;
            cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicense.DriverLicenseID);
            cmd.Parameters.AddWithValue("@PersonID", DriverLicense.PersonID);
            cmd.Parameters.AddWithValue("@number", DriverLicense.number);
            cmd.Parameters.AddWithValue("@expireDate", DriverLicense.expireDate);
            cmd.Parameters.AddWithValue("@Desc", DriverLicense.Desc);
            cmd.Parameters.AddWithValue("@UserID", DriverLicense.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditDriverLicense(DriverLicense driverLicense)
        {
            string SqlStr = "UPDATE tblDriverLicense " +
                                 " SET PersonID = @PersonID, number = @number, expireDate=@expireDate ,[Desc]=@Desc,UserID=@UserID WHERE DriverLicenseID=@DriverLicenseID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            DriverLicense DriverLicense = new DriverLicense();
            DriverLicense = driverLicense;
            cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicense.DriverLicenseID);
            cmd.Parameters.AddWithValue("@PersonID", DriverLicense.PersonID);
            cmd.Parameters.AddWithValue("@number", DriverLicense.number);
            cmd.Parameters.AddWithValue("@expireDate", DriverLicense.expireDate);
            cmd.Parameters.AddWithValue("@Desc", DriverLicense.Desc);
            cmd.Parameters.AddWithValue("@UserID", DriverLicense.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteDriverLicense(int DriverLicenseID, int UserID)
        {
            string SqlStr = "UPDATE tblDriverLicense SET DriverLicenseIsDel =1 where DriverLicenseID=@DriverLicenseID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion DriverLicense
    }
}
