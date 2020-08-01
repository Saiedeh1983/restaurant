

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
    public class ResidenceDAL
    {
        #region Residence

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Residence LoadResidence(int ResidenceID)
        {
            string SqlStr = "select * from tblResidence where ResidenceIsDel=0 and ResidenceID=@ResidenceID";
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ResidenceID", ResidenceID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return Residence;
        }

        public List<Residence> LoadResidenceListWithDistinctPersonID(int UserID)
        {
            string SqlStr = "select distinct PersonID from tblResidence where (ResidenceIsDel=0) and UserID=@UserID ";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Residence = new Residence();
                Residence.PersonID = int.Parse(r2[0].ToString());

                ResidenceList.Add(Residence);
            }
            r2.Close();
            cn.Close();
            return ResidenceList;
        }

        public List<Residence> LoadResidenceList3(int PersonID)
        {
            string SqlStr = "select F.ResidenceID,F.PersonID,F.number,F.expireDate,F.[Desc],F.UserID,F.ResidenceIsDel from tblResidence as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.ResidenceIsDel=0) and F.PersonID=@PersonID";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Residence = new Residence();
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
                ResidenceList.Add(Residence);
            }
            r.Close();
            cn.Close();
            return ResidenceList;
        }
        public Residence LoadResidenceWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblResidence where ResidenceIsDel=0 and PersonID=@PersonID";
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return Residence;
        }

        public List<Residence> LoadResidenceList2()
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0)";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Residence = new Residence();
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
                ResidenceList.Add(Residence);
            }
            r.Close();
            cn.Close();
            return ResidenceList;
        }
        public DataTable LoadResidenceListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
       

        public DataTable LoadResidenceList(int PersonID)
        {
            string SqlStr = "select F.ResidenceID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.ResidenceIsDel from tblResidence as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.ResidenceIsDel=0) and F.PersonID=@PersonID";
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
        public DataTable LoadResidenceListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.[Desc] from tblResidence as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.ResidenceIsDel=0) and F.UserID=@UserID";
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
        public int accountinglastsalary(int PersonID, int ResidenceID)
        {
            string SqlStr = "select (ResidenceID) AS From tblResidence Where ResidenceIsDel=0";
            // string SqlStr = "select F.ResidenceID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.ResidenceIsDel from tblResidence as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.ResidenceIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Residence LoadResidenceWithPersonID(int PersonID, int ResidenceID)
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0) and PersonID=@PersonID and ResidenceID=@ResidenceID ";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@ResidenceID", ResidenceID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Residence = new Residence();
            Residence.ResidenceID = int.Parse(r[0].ToString());
            Residence.PersonID = int.Parse(r[1].ToString());
            Residence.number = r[2].ToString();
            Residence.expireDate = r[3].ToString();
            Residence.Desc = r[4].ToString();
            Residence.UserID = int.Parse(r[5].ToString());
            //ResidenceList.Add(Residence);
            // }
            r.Close();
            cn.Close();
            return Residence;
        }

        public List<Residence> LoadResidenceListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0) and PersonID=@PersonID ";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@ResidenceID", ResidenceID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Residence = new Residence();
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
                ResidenceList.Add(Residence);
            }
            r.Close();
            cn.Close();
            return ResidenceList;
        }
        public List<Residence> LoadResidenceListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Residence = new Residence();
                Residence = new Residence();
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
                ResidenceList.Add(Residence);
            }
            r.Close();
            cn.Close();
            return ResidenceList;
        }

        public List<Residence> LoadResidenceListContorID( int UserID)
        {
            string SqlStr = "select * from tblResidence where (ResidenceIsDel=0) and UserID=@UserID";
            List<Residence> ResidenceList = new List<Residence>();
            Residence Residence = new Residence();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Residence = new Residence();
                Residence.ResidenceID = int.Parse(r[0].ToString());
                Residence.PersonID = int.Parse(r[1].ToString());
                Residence.number = r[2].ToString();
                Residence.expireDate = r[3].ToString();
                Residence.Desc = r[4].ToString();
                Residence.UserID = int.Parse(r[5].ToString());
                ResidenceList.Add(Residence);
            }
            r.Close();
            cn.Close();
            return ResidenceList;
        }

        public bool InsertResidence(Residence residence)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblResidence " +
                              " (PersonID,number,expireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@expireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Residence Residence = new Residence();
            Residence = residence;
            cmd.Parameters.AddWithValue("@ResidenceID", Residence.ResidenceID);
            cmd.Parameters.AddWithValue("@PersonID", Residence.PersonID);
            cmd.Parameters.AddWithValue("@number", Residence.number);
            cmd.Parameters.AddWithValue("@expireDate", Residence.expireDate);
            cmd.Parameters.AddWithValue("@Desc", Residence.Desc);
            cmd.Parameters.AddWithValue("@UserID", Residence.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditResidence(Residence residence)
        {
            string SqlStr = "UPDATE tblResidence " +
                                 " SET PersonID = @PersonID, number = @number, expireDate=@expireDate ,[Desc]=@Desc,UserID=@UserID WHERE ResidenceID=@ResidenceID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Residence Residence = new Residence();
            Residence = residence;
            cmd.Parameters.AddWithValue("@ResidenceID", Residence.ResidenceID);
            cmd.Parameters.AddWithValue("@PersonID", Residence.PersonID);
            cmd.Parameters.AddWithValue("@number", Residence.number);
            cmd.Parameters.AddWithValue("@expireDate", Residence.expireDate);
            cmd.Parameters.AddWithValue("@Desc", Residence.Desc);
            cmd.Parameters.AddWithValue("@UserID", Residence.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteResidence(int ResidenceID, int UserID)
        {
            string SqlStr = "UPDATE tblResidence SET ResidenceIsDel =1 where ResidenceID=@ResidenceID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ResidenceID", ResidenceID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Residence
    }
}
