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
   public class IncreasesalaryDAL
    {
        #region Increasesalary

       SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Increasesalary LoadIncreasesalary(int IncreasesalaryID)
        {
            string SqlStr = "select * from tblIncreasesalary where IncreasesalaryIsDel=0 and IncreasesalaryID=@IncreasesalaryID";
            Increasesalary Increasesalary = new Increasesalary();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IncreasesalaryID", IncreasesalaryID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
                Increasesalary.PersonID = int.Parse(r[1].ToString());
                Increasesalary.lastIncrease = int.Parse(r[2].ToString());
                Increasesalary.Date = r[3].ToString();
                Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
                Increasesalary.Desc = r[5].ToString();
                Increasesalary.UserID = int.Parse(r[6].ToString());

            }
            r.Close();
            cn.Close();
            return Increasesalary;
        }

        public Increasesalary LoadIncreasesalaryWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblIncreasesalary where IncreasesalaryIsDel=0 and PersonID=@PersonID";
            Increasesalary Increasesalary = new Increasesalary();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
                Increasesalary.PersonID = int.Parse(r[1].ToString());
                Increasesalary.lastIncrease = int.Parse(r[2].ToString());
                Increasesalary.Date = r[3].ToString();
                Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
                Increasesalary.Desc = r[5].ToString();
                Increasesalary.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Increasesalary;
        }

        public List<Increasesalary> LoadIncreasesalaryList2()
        {
            string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0)";
            List<Increasesalary> IncreasesalaryList = new List<Increasesalary>();
            Increasesalary Increasesalary = new Increasesalary();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Increasesalary = new Increasesalary();
                Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
                Increasesalary.PersonID = int.Parse(r[1].ToString());
                Increasesalary.lastIncrease = int.Parse(r[2].ToString());
                Increasesalary.Date = r[3].ToString();
                Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
                Increasesalary.Desc = r[5].ToString();
                Increasesalary.UserID = int.Parse(r[6].ToString());
                IncreasesalaryList.Add(Increasesalary);
            }
            r.Close();
            cn.Close();
            return IncreasesalaryList;
        }

        public DataTable LoadIncreasesalaryListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.[Desc] from tblIncreasesalary as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IncreasesalaryIsDel=0) and F.UserID=@UserID";
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
        public DataTable LoadIncreasesalaryListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
        public DataTable LoadIncreasesalaryList(int PersonID)
        {
            string SqlStr = "select F.IncreasesalaryID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.IncreasesalaryIsDel from tblIncreasesalary as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IncreasesalaryIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int IncreasesalaryID)
        {
            string SqlStr = "select (IncreasesalaryID) AS From tblIncreasesalary Where IncreasesalaryIsDel=0";
           // string SqlStr = "select F.IncreasesalaryID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.IncreasesalaryIsDel from tblIncreasesalary as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IncreasesalaryIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
          //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Increasesalary LoadIncreasesalaryWithPersonID(int PersonID, int IncreasesalaryID)
        {
            string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0) and PersonID=@PersonID and IncreasesalaryID=@IncreasesalaryID ";
            List<Increasesalary> IncreasesalaryList = new List<Increasesalary>();
            Increasesalary Increasesalary = new Increasesalary();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@IncreasesalaryID", IncreasesalaryID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
           // while (r.Read())
           // {
                //Increasesalary = new Increasesalary();
                Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
                Increasesalary.PersonID = int.Parse(r[1].ToString());
                Increasesalary.lastIncrease = int.Parse(r[2].ToString());
                Increasesalary.Date = r[3].ToString();
                Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
                Increasesalary.Desc = r[5].ToString();
                Increasesalary.UserID = int.Parse(r[6].ToString());
                //IncreasesalaryList.Add(Increasesalary);
           // }
            r.Close();
            cn.Close();
            return Increasesalary;
        }

        public List<Increasesalary> LoadIncreasesalaryListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0) and PersonID=@PersonID ";
            List<Increasesalary> IncreasesalaryList = new List<Increasesalary>();
            Increasesalary Increasesalary = new Increasesalary();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
           // cmd.Parameters.AddWithValue("@IncreasesalaryID", IncreasesalaryID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Increasesalary = new Increasesalary();
                Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
                Increasesalary.PersonID = int.Parse(r[1].ToString());
                Increasesalary.lastIncrease = int.Parse(r[2].ToString());
                Increasesalary.Date = r[3].ToString();
                Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
                Increasesalary.Desc = r[5].ToString();
                Increasesalary.UserID = int.Parse(r[6].ToString());
                IncreasesalaryList.Add(Increasesalary);
            }
            r.Close();
            cn.Close();
            return IncreasesalaryList;
        }
       public List<Increasesalary> LoadIncreasesalaryListWithDateAndContorID(string FromDate, string UntillDate,int ContorID)
       {
           string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
           List<Increasesalary> IncreasesalaryList = new List<Increasesalary>();
           Increasesalary Increasesalary = new Increasesalary();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);
           cmd.Parameters.AddWithValue("@FromDate", FromDate);
           cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
           cmd.Parameters.AddWithValue("@ContorID", ContorID);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               Increasesalary = new Increasesalary();
               Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
               Increasesalary.PersonID = int.Parse(r[1].ToString());
               Increasesalary.lastIncrease = int.Parse(r[2].ToString());
               Increasesalary.Date = r[3].ToString();
               Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
               Increasesalary.Desc = r[5].ToString();
               Increasesalary.UserID = int.Parse(r[6].ToString());
               IncreasesalaryList.Add(Increasesalary);
           }
           r.Close();
           cn.Close();
           return IncreasesalaryList;
       }

       public List<Increasesalary> LoadIncreasesalaryListContorID(int ContorID, int UserID)
       {
           string SqlStr = "select * from tblIncreasesalary where (IncreasesalaryIsDel=0) and ContorID=@ContorID and UserID=@UserID";
           List<Increasesalary> IncreasesalaryList = new List<Increasesalary>();
           Increasesalary Increasesalary = new Increasesalary();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);           
           cmd.Parameters.AddWithValue("@ContorID", ContorID);
             cmd.Parameters.AddWithValue("@UserID", UserID);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               Increasesalary = new Increasesalary();
               Increasesalary.IncreasesalaryID = int.Parse(r[0].ToString());
               Increasesalary.PersonID = int.Parse(r[1].ToString());
               Increasesalary.lastIncrease = int.Parse(r[2].ToString());
               Increasesalary.Date = r[3].ToString();
               Increasesalary.lastsalary = int.Parse(r[4].ToString()); ;
               Increasesalary.Desc = r[5].ToString();
               Increasesalary.UserID = int.Parse(r[6].ToString());
               IncreasesalaryList.Add(Increasesalary);
           }
           r.Close();
           cn.Close();
           return IncreasesalaryList;
       }
      
       public bool InsertIncreasesalary(Increasesalary increasesalary)
        {
          //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblIncreasesalary " +
                              " (PersonID,lastIncrease,Date,lastsalary,[Desc],UserID)" +
                              " VALUES (@PersonID,@lastIncrease,@Date,@lastsalary,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Increasesalary Increasesalary = new Increasesalary();
            Increasesalary = increasesalary;
            cmd.Parameters.AddWithValue("@IncreasesalaryID", Increasesalary.IncreasesalaryID);
            cmd.Parameters.AddWithValue("@PersonID", Increasesalary.PersonID);
            cmd.Parameters.AddWithValue("@lastIncrease", Increasesalary.lastIncrease);
            cmd.Parameters.AddWithValue("@Date", Increasesalary.Date);
            cmd.Parameters.AddWithValue("@lastsalary", Increasesalary.lastsalary);
            cmd.Parameters.AddWithValue("@Desc", Increasesalary.Desc);
            cmd.Parameters.AddWithValue("@UserID", Increasesalary.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;
           
        }

        public void EditIncreasesalary(Increasesalary increasesalary)
        {
            string SqlStr = "UPDATE tblIncreasesalary " +
                                 " SET PersonID = @PersonID, lastIncrease = @lastIncrease, Date=@Date,lastsalary=@lastsalary ,[Desc]=@Desc,UserID=@UserID WHERE IncreasesalaryID=@IncreasesalaryID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Increasesalary Increasesalary = new Increasesalary();
            Increasesalary = increasesalary;
            cmd.Parameters.AddWithValue("@IncreasesalaryID", Increasesalary.IncreasesalaryID);
            cmd.Parameters.AddWithValue("@PersonID", Increasesalary.PersonID);
            cmd.Parameters.AddWithValue("@lastIncrease", Increasesalary.lastIncrease);
            cmd.Parameters.AddWithValue("@Date", Increasesalary.Date);
            cmd.Parameters.AddWithValue("@lastsalary", Increasesalary.lastsalary);
            cmd.Parameters.AddWithValue("@Desc", Increasesalary.Desc);
            cmd.Parameters.AddWithValue("@UserID", Increasesalary.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

       public void DeleteIncreasesalary(int IncreasesalaryID, int UserID)
        {
            string SqlStr = "UPDATE tblIncreasesalary SET IncreasesalaryIsDel =1 where IncreasesalaryID=@IncreasesalaryID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IncreasesalaryID", IncreasesalaryID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Increasesalary
    }
}
