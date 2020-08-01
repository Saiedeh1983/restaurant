

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
    public class AdvanceDAL
    {
        #region Advance

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Advance LoadAdvance(int AdvanceID)
        {
            string SqlStr = "select * from tblAdvance where AdvanceIsDel=0 and AdvanceID=@AdvanceID";
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@AdvanceID", AdvanceID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Advance;
        }
        public DataTable LoadAdvanceListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.[Desc] from tblAdvance as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.AdvanceIsDel=0) and F.UserID=@UserID";
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
        public Advance LoadAdvanceWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblAdvance where AdvanceIsDel=0 and PersonID=@PersonID";
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Advance;
        }

        public List<Advance> LoadAdvanceList2()
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0)";
            List<Advance> AdvanceList = new List<Advance>();
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Advance = new Advance();
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
                AdvanceList.Add(Advance);
            }
            r.Close();
            cn.Close();
            return AdvanceList;
        }
        public DataTable LoadAdvanceListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
        public DataTable LoadAdvanceList(int PersonID)
        {
            string SqlStr = "select F.AdvanceID,tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.PersonID,F.[Desc],F.UserID,F.AdvanceIsDel from tblAdvance as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.AdvanceIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int AdvanceID)
        {
            string SqlStr = "select (AdvanceID) AS From tblAdvance Where AdvanceIsDel=0";
            // string SqlStr = "select F.AdvanceID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.AdvanceIsDel from tblAdvance as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.AdvanceIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Advance LoadAdvanceWithPersonID(int PersonID, int AdvanceID)
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0) and PersonID=@PersonID and AdvanceID=@AdvanceID ";
            List<Advance> AdvanceList = new List<Advance>();
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@AdvanceID", AdvanceID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Advance = new Advance();
            Advance.AdvanceID = int.Parse(r[0].ToString());
            Advance.PersonID = int.Parse(r[1].ToString());
            Advance.amount = int.Parse(r[2].ToString());
            Advance.Date = r[3].ToString();
            Advance.cause = r[4].ToString();
            Advance.Desc = r[5].ToString();
            Advance.UserID = int.Parse(r[6].ToString());
            //AdvanceList.Add(Advance);
            // }
            r.Close();
            cn.Close();
            return Advance;
        }

        public List<Advance> LoadAdvanceListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0) and PersonID=@PersonID ";
            List<Advance> AdvanceList = new List<Advance>();
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@AdvanceID", AdvanceID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Advance = new Advance();
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
                AdvanceList.Add(Advance);
            }
            r.Close();
            cn.Close();
            return AdvanceList;
        }
        public List<Advance> LoadAdvanceListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<Advance> AdvanceList = new List<Advance>();
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Advance = new Advance();
                Advance = new Advance();
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
                AdvanceList.Add(Advance);
            }
            r.Close();
            cn.Close();
            return AdvanceList;
        }

        public List<Advance> LoadAdvanceListContorID(int ContorID, int UserID)
        {
            string SqlStr = "select * from tblAdvance where (AdvanceIsDel=0) and ContorID=@ContorID and UserID=@UserID";
            List<Advance> AdvanceList = new List<Advance>();
            Advance Advance = new Advance();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Advance = new Advance();
                Advance = new Advance();
                Advance.AdvanceID = int.Parse(r[0].ToString());
                Advance.PersonID = int.Parse(r[1].ToString());
                Advance.amount = int.Parse(r[2].ToString());
                Advance.Date = r[3].ToString();
                Advance.cause = r[4].ToString();
                Advance.Desc = r[5].ToString();
                Advance.UserID = int.Parse(r[6].ToString());
                AdvanceList.Add(Advance);
            }
            r.Close();
            cn.Close();
            return AdvanceList;
        }

        public bool InsertAdvance(Advance advance)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblAdvance " +
                              " (PersonID,amount,Date,cause,[Desc],UserID)" +
                              " VALUES (@PersonID,@amount,@Date,@cause,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Advance Advance = new Advance();
            Advance = advance;
            cmd.Parameters.AddWithValue("@AdvanceID", Advance.AdvanceID);
            cmd.Parameters.AddWithValue("@PersonID", Advance.PersonID);
            cmd.Parameters.AddWithValue("@amount", Advance.amount);
            cmd.Parameters.AddWithValue("@Date", Advance.Date);
            cmd.Parameters.AddWithValue("@cause", Advance.cause);
            cmd.Parameters.AddWithValue("@Desc", Advance.Desc);
            cmd.Parameters.AddWithValue("@UserID", Advance.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditAdvance(Advance advance)
        {
            string SqlStr = "UPDATE tblAdvance " +
                                 " SET PersonID = @PersonID, amount = @amount, Date=@Date,cause=@cause ,[Desc]=@Desc,UserID=@UserID WHERE AdvanceID=@AdvanceID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Advance Advance = new Advance();
            Advance = advance;
            cmd.Parameters.AddWithValue("@AdvanceID", Advance.AdvanceID);
            cmd.Parameters.AddWithValue("@PersonID", Advance.PersonID);
            cmd.Parameters.AddWithValue("@amount", Advance.amount);
            cmd.Parameters.AddWithValue("@Date", Advance.Date);
            cmd.Parameters.AddWithValue("@cause", Advance.cause);
            cmd.Parameters.AddWithValue("@Desc", Advance.Desc);
            cmd.Parameters.AddWithValue("@UserID", Advance.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteAdvance(int AdvanceID, int UserID)
        {
            string SqlStr = "UPDATE tblAdvance SET AdvanceIsDel =1 where AdvanceID=@AdvanceID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@AdvanceID", AdvanceID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Advance
    }
}
