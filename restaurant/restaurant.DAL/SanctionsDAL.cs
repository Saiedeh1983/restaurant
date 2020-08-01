

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
    public class SanctionsDAL
    {
        #region Sanctions

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Sanctions LoadSanctions(int SanctionsID)
        {
            string SqlStr = "select * from tblSanctions where SanctionsIsDel=0 and SanctionsID=@SanctionsID";
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@SanctionsID", SanctionsID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Sanctions;
        }

        public Sanctions LoadSanctionsWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblSanctions where SanctionsIsDel=0 and PersonID=@PersonID";
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Sanctions;
        }

        public List<Sanctions> LoadSanctionsList2()
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0)";
            List<Sanctions> SanctionsList = new List<Sanctions>();
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Sanctions = new Sanctions();
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
                SanctionsList.Add(Sanctions);
            }
            r.Close();
            cn.Close();
            return SanctionsList;
        }

        public DataTable LoadSanctionsListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.[Desc] from tblSanctions as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.SanctionsIsDel=0) and F.UserID=@UserID";
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
        public DataTable LoadSanctionsListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
        public DataTable LoadSanctionsList(int PersonID)
        {
            string SqlStr = "select F.SanctionsID,tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.cause,F.PersonID,F.[Desc],F.UserID,F.SanctionsIsDel from tblSanctions as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.SanctionsIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int SanctionsID)
        {
            string SqlStr = "select (SanctionsID) AS From tblSanctions Where SanctionsIsDel=0";
            // string SqlStr = "select F.SanctionsID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.SanctionsIsDel from tblSanctions as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.SanctionsIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Sanctions LoadSanctionsWithPersonID(int PersonID, int SanctionsID)
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0) and PersonID=@PersonID and SanctionsID=@SanctionsID ";
            List<Sanctions> SanctionsList = new List<Sanctions>();
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@SanctionsID", SanctionsID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Sanctions = new Sanctions();
            Sanctions.SanctionsID = int.Parse(r[0].ToString());
            Sanctions.PersonID = int.Parse(r[1].ToString());
            Sanctions.amount = int.Parse(r[2].ToString());
            Sanctions.Date = r[3].ToString();
            Sanctions.cause = r[4].ToString();
            Sanctions.Desc = r[5].ToString();
            Sanctions.UserID = int.Parse(r[6].ToString());
            //SanctionsList.Add(Sanctions);
            // }
            r.Close();
            cn.Close();
            return Sanctions;
        }

        public List<Sanctions> LoadSanctionsListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0) and PersonID=@PersonID ";
            List<Sanctions> SanctionsList = new List<Sanctions>();
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@SanctionsID", SanctionsID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Sanctions = new Sanctions();
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
                SanctionsList.Add(Sanctions);
            }
            r.Close();
            cn.Close();
            return SanctionsList;
        }
        public List<Sanctions> LoadSanctionsListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<Sanctions> SanctionsList = new List<Sanctions>();
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Sanctions = new Sanctions();
                Sanctions = new Sanctions();
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
                SanctionsList.Add(Sanctions);
            }
            r.Close();
            cn.Close();
            return SanctionsList;
        }

        public List<Sanctions> LoadSanctionsListContorID(int ContorID, int UserID)
        {
            string SqlStr = "select * from tblSanctions where (SanctionsIsDel=0) and ContorID=@ContorID and UserID=@UserID";
            List<Sanctions> SanctionsList = new List<Sanctions>();
            Sanctions Sanctions = new Sanctions();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Sanctions = new Sanctions();
                Sanctions = new Sanctions();
                Sanctions.SanctionsID = int.Parse(r[0].ToString());
                Sanctions.PersonID = int.Parse(r[1].ToString());
                Sanctions.amount = int.Parse(r[2].ToString());
                Sanctions.Date = r[3].ToString();
                Sanctions.cause = r[4].ToString();
                Sanctions.Desc = r[5].ToString();
                Sanctions.UserID = int.Parse(r[6].ToString());
                SanctionsList.Add(Sanctions);
            }
            r.Close();
            cn.Close();
            return SanctionsList;
        }

        public bool InsertSanctions(Sanctions sanctions)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblSanctions " +
                              " (PersonID,amount,Date,cause,[Desc],UserID)" +
                              " VALUES (@PersonID,@amount,@Date,@cause,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Sanctions Sanctions = new Sanctions();
            Sanctions = sanctions;
            cmd.Parameters.AddWithValue("@SanctionsID", Sanctions.SanctionsID);
            cmd.Parameters.AddWithValue("@PersonID", Sanctions.PersonID);
            cmd.Parameters.AddWithValue("@amount", Sanctions.amount);
            cmd.Parameters.AddWithValue("@Date", Sanctions.Date);
            cmd.Parameters.AddWithValue("@cause", Sanctions.cause);
            cmd.Parameters.AddWithValue("@Desc", Sanctions.Desc);
            cmd.Parameters.AddWithValue("@UserID", Sanctions.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditSanctions(Sanctions sanctions)
        {
            string SqlStr = "UPDATE tblSanctions " +
                                 " SET PersonID = @PersonID, amount = @amount, Date=@Date,cause=@cause ,[Desc]=@Desc,UserID=@UserID WHERE SanctionsID=@SanctionsID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Sanctions Sanctions = new Sanctions();
            Sanctions = sanctions;
            cmd.Parameters.AddWithValue("@SanctionsID", Sanctions.SanctionsID);
            cmd.Parameters.AddWithValue("@PersonID", Sanctions.PersonID);
            cmd.Parameters.AddWithValue("@amount", Sanctions.amount);
            cmd.Parameters.AddWithValue("@Date", Sanctions.Date);
            cmd.Parameters.AddWithValue("@cause", Sanctions.cause);
            cmd.Parameters.AddWithValue("@Desc", Sanctions.Desc);
            cmd.Parameters.AddWithValue("@UserID", Sanctions.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteSanctions(int SanctionsID, int UserID)
        {
            string SqlStr = "UPDATE tblSanctions SET SanctionsIsDel =1 where SanctionsID=@SanctionsID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@SanctionsID", SanctionsID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Sanctions
    }
}
