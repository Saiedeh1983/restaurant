

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
   public class EncouragementDAL
    {
        #region Encouragement

       SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Encouragement LoadEncouragement(int EncouragementID)
        {
            string SqlStr = "select * from tblEncouragement where EncouragementIsDel=0 and EncouragementID=@EncouragementID";
            Encouragement Encouragement = new Encouragement();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@EncouragementID", EncouragementID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Encouragement.EncouragementID = int.Parse(r[0].ToString());
                Encouragement.PersonID = int.Parse(r[1].ToString());
                Encouragement.amount = int.Parse(r[2].ToString());
                Encouragement.Date = r[3].ToString();
                Encouragement.cause = r[4].ToString();
                Encouragement.Desc = r[5].ToString();
                Encouragement.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Encouragement;
        }
        public DataTable LoadEncouragementListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.[Desc] from tblEncouragement as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.EncouragementIsDel=0) and F.UserID=@UserID";
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
        public Encouragement LoadEncouragementWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblEncouragement where EncouragementIsDel=0 and PersonID=@PersonID";
            Encouragement Encouragement = new Encouragement();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Encouragement.EncouragementID = int.Parse(r[0].ToString());
                Encouragement.PersonID = int.Parse(r[1].ToString());
                Encouragement.amount = int.Parse(r[2].ToString());
                Encouragement.Date = r[3].ToString();
                Encouragement.cause = r[4].ToString();
                Encouragement.Desc = r[5].ToString();
                Encouragement.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Encouragement;
        }

        public List<Encouragement> LoadEncouragementList2()
        {
            string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0)";
            List<Encouragement> EncouragementList = new List<Encouragement>();
            Encouragement Encouragement = new Encouragement();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Encouragement = new Encouragement();
                Encouragement.EncouragementID = int.Parse(r[0].ToString());
                Encouragement.PersonID = int.Parse(r[1].ToString());
                Encouragement.amount = int.Parse(r[2].ToString());
                Encouragement.Date = r[3].ToString();
                Encouragement.cause = r[4].ToString() ;
                Encouragement.Desc = r[5].ToString();
                Encouragement.UserID = int.Parse(r[6].ToString());
                EncouragementList.Add(Encouragement);
            }
            r.Close();
            cn.Close();
            return EncouragementList;
        }
        public DataTable LoadEncouragementListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
        public DataTable LoadEncouragementList(int PersonID)
        {
            string SqlStr = "select F.EncouragementID,tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.PersonID,F.[Desc],F.UserID,F.EncouragementIsDel from tblEncouragement as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.EncouragementIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int EncouragementID)
        {
            string SqlStr = "select (EncouragementID) AS From tblEncouragement Where EncouragementIsDel=0";
           // string SqlStr = "select F.EncouragementID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.EncouragementIsDel from tblEncouragement as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.EncouragementIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
          //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Encouragement LoadEncouragementWithPersonID(int PersonID, int EncouragementID)
        {
            string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0) and PersonID=@PersonID and EncouragementID=@EncouragementID ";
            List<Encouragement> EncouragementList = new List<Encouragement>();
            Encouragement Encouragement = new Encouragement();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@EncouragementID", EncouragementID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
           // while (r.Read())
           // {
                //Encouragement = new Encouragement();
            Encouragement.EncouragementID = int.Parse(r[0].ToString());
            Encouragement.PersonID = int.Parse(r[1].ToString());
            Encouragement.amount = int.Parse(r[2].ToString());
            Encouragement.Date = r[3].ToString();
            Encouragement.cause = r[4].ToString();
            Encouragement.Desc = r[5].ToString();
            Encouragement.UserID = int.Parse(r[6].ToString());
                //EncouragementList.Add(Encouragement);
           // }
            r.Close();
            cn.Close();
            return Encouragement;
        }

        public List<Encouragement> LoadEncouragementListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0) and PersonID=@PersonID ";
            List<Encouragement> EncouragementList = new List<Encouragement>();
            Encouragement Encouragement = new Encouragement();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
           // cmd.Parameters.AddWithValue("@EncouragementID", EncouragementID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Encouragement = new Encouragement();
                Encouragement.EncouragementID = int.Parse(r[0].ToString());
                Encouragement.PersonID = int.Parse(r[1].ToString());
                Encouragement.amount = int.Parse(r[2].ToString());
                Encouragement.Date = r[3].ToString();
                Encouragement.cause = r[4].ToString();
                Encouragement.Desc = r[5].ToString();
                Encouragement.UserID = int.Parse(r[6].ToString());
                EncouragementList.Add(Encouragement);
            }
            r.Close();
            cn.Close();
            return EncouragementList;
        }
       public List<Encouragement> LoadEncouragementListWithDateAndContorID(string FromDate, string UntillDate,int ContorID)
       {
           string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
           List<Encouragement> EncouragementList = new List<Encouragement>();
           Encouragement Encouragement = new Encouragement();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);
           cmd.Parameters.AddWithValue("@FromDate", FromDate);
           cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
           cmd.Parameters.AddWithValue("@ContorID", ContorID);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               Encouragement = new Encouragement();
               Encouragement = new Encouragement();
               Encouragement.EncouragementID = int.Parse(r[0].ToString());
               Encouragement.PersonID = int.Parse(r[1].ToString());
               Encouragement.amount = int.Parse(r[2].ToString());
               Encouragement.Date = r[3].ToString();
               Encouragement.cause = r[4].ToString();
               Encouragement.Desc = r[5].ToString();
               Encouragement.UserID = int.Parse(r[6].ToString());
               EncouragementList.Add(Encouragement);
           }
           r.Close();
           cn.Close();
           return EncouragementList;
       }

       public List<Encouragement> LoadEncouragementListContorID(int ContorID, int UserID)
       {
           string SqlStr = "select * from tblEncouragement where (EncouragementIsDel=0) and ContorID=@ContorID and UserID=@UserID";
           List<Encouragement> EncouragementList = new List<Encouragement>();
           Encouragement Encouragement = new Encouragement();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);           
           cmd.Parameters.AddWithValue("@ContorID", ContorID);
             cmd.Parameters.AddWithValue("@UserID", UserID);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               Encouragement = new Encouragement();
               Encouragement = new Encouragement();
               Encouragement.EncouragementID = int.Parse(r[0].ToString());
               Encouragement.PersonID = int.Parse(r[1].ToString());
               Encouragement.amount = int.Parse(r[2].ToString());
               Encouragement.Date = r[3].ToString();
               Encouragement.cause = r[4].ToString();
               Encouragement.Desc = r[5].ToString();
               Encouragement.UserID = int.Parse(r[6].ToString());
               EncouragementList.Add(Encouragement);
           }
           r.Close();
           cn.Close();
           return EncouragementList;
       }
      
       public bool InsertEncouragement(Encouragement encouragement)
        {
          //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblEncouragement " +
                              " (PersonID,amount,Date,cause,[Desc],UserID)" +
                              " VALUES (@PersonID,@amount,@Date,@cause,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Encouragement Encouragement = new Encouragement();
            Encouragement = encouragement;
            cmd.Parameters.AddWithValue("@EncouragementID", Encouragement.EncouragementID);
            cmd.Parameters.AddWithValue("@PersonID", Encouragement.PersonID);
            cmd.Parameters.AddWithValue("@amount", Encouragement.amount);
            cmd.Parameters.AddWithValue("@Date", Encouragement.Date);
            cmd.Parameters.AddWithValue("@cause", Encouragement.cause);
            cmd.Parameters.AddWithValue("@Desc", Encouragement.Desc);
            cmd.Parameters.AddWithValue("@UserID", Encouragement.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;
           
        }

        public void EditEncouragement(Encouragement encouragement)
        {
            string SqlStr = "UPDATE tblEncouragement " +
                                 " SET PersonID = @PersonID, amount = @amount, Date=@Date,cause=@cause ,[Desc]=@Desc,UserID=@UserID WHERE EncouragementID=@EncouragementID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Encouragement Encouragement = new Encouragement();
            Encouragement = encouragement;
            cmd.Parameters.AddWithValue("@EncouragementID", Encouragement.EncouragementID);
            cmd.Parameters.AddWithValue("@PersonID", Encouragement.PersonID);
            cmd.Parameters.AddWithValue("@amount", Encouragement.amount);
            cmd.Parameters.AddWithValue("@Date", Encouragement.Date);
            cmd.Parameters.AddWithValue("@cause", Encouragement.cause);
            cmd.Parameters.AddWithValue("@Desc", Encouragement.Desc);
            cmd.Parameters.AddWithValue("@UserID", Encouragement.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

       public void DeleteEncouragement(int EncouragementID, int UserID)
        {
            string SqlStr = "UPDATE tblEncouragement SET EncouragementIsDel =1 where EncouragementID=@EncouragementID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@EncouragementID", EncouragementID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Encouragement
    }
}
