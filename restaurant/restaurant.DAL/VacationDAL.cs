

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
    public class VacationDAL
    {
        #region Vacation

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Vacation LoadVacation(int VacationID)
        {
            string SqlStr = "select * from tblVacation where VacationIsDel=0 and VacationID=@VacationID";
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@VacationID", VacationID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Vacation;
        }

        public Vacation LoadVacationWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblVacation where VacationIsDel=0 and PersonID=@PersonID";
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Vacation;
        }

        public List<Vacation> LoadVacationList3(int PersonID)
        {
            string SqlStr = "select F.VacationID,F.PersonID,F.amount,F.Date,F.expireDate,F.[Desc],F.UserID,F.VacationIsDel from tblVacation as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.VacationIsDel=0) and F.PersonID=@PersonID";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vacation = new Vacation();
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
                VacationList.Add(Vacation);
            }
            r.Close();
            cn.Close();
            return VacationList;
        }

        public List<Vacation> LoadVacationListWithDistinctPersonID(int UserID)
        {
            string SqlStr = "select distinct PersonID from tblVacation where (VacationIsDel=0) and UserID=@UserID ";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Vacation = new Vacation();
                Vacation.PersonID = int.Parse(r2[0].ToString());

                VacationList.Add(Vacation);
            }
            r2.Close();
            cn.Close();
            return VacationList;
        }

        public List<Vacation> LoadVacationList2()
        {
            string SqlStr = "select * from tblVacation where (VacationIsDel=0)";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vacation = new Vacation();
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
                VacationList.Add(Vacation);
            }
            r.Close();
            cn.Close();
            return VacationList;
        }

        public DataTable LoadVacationListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.ExpireDate,F.[Desc] from tblVacation as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.VacationIsDel=0) and F.UserID=@UserID";
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

        public DataTable LoadVacationListWithDateUntilDate(string Date, int ExpireDate)
        {
            string SqlStr = "select * from tblVacation where (VacationIsDel=0) and Date=@Date and ExpireDate=@ExpireDate";
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
        public DataTable LoadVacationList(int PersonID)
        {
            string SqlStr = "select F.VacationID,tblPerson.Name,tblPerson.Family,F.amount,F.Date,F.ExpireDate,F.PersonID,F.[Desc],F.UserID,F.VacationIsDel from tblVacation as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.VacationIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int VacationID)
        {
            string SqlStr = "select (VacationID) AS From tblVacation Where VacationIsDel=0";
            // string SqlStr = "select F.VacationID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.VacationIsDel from tblVacation as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.VacationIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Vacation LoadVacationWithPersonID(int PersonID, int VacationID)
        {
            string SqlStr = "select * from tblVacation where (VacationIsDel=0) and PersonID=@PersonID and VacationID=@VacationID ";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@VacationID", VacationID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Vacation = new Vacation();
            Vacation.VacationID = int.Parse(r[0].ToString());
            Vacation.PersonID = int.Parse(r[1].ToString());
            Vacation.amount = int.Parse(r[2].ToString());
            Vacation.Date = r[3].ToString();
            Vacation.ExpireDate = r[4].ToString();
            Vacation.Desc = r[5].ToString();
            Vacation.UserID = int.Parse(r[6].ToString());
            //VacationList.Add(Vacation);
            // }
            r.Close();
            cn.Close();
            return Vacation;
        }

        public List<Vacation> LoadVacationListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblVacation where (VacationIsDel=0) and PersonID=@PersonID ";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@VacationID", VacationID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vacation = new Vacation();
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
                VacationList.Add(Vacation);
            }
            r.Close();
            cn.Close();
            return VacationList;
        }
      

        public List<Vacation> LoadVacationListContorID(int ContorID, int UserID)
        {
            string SqlStr = "select * from tblVacation where (VacationIsDel=0) and ContorID=@ContorID and UserID=@UserID";
            List<Vacation> VacationList = new List<Vacation>();
            Vacation Vacation = new Vacation();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vacation = new Vacation();
                Vacation.VacationID = int.Parse(r[0].ToString());
                Vacation.PersonID = int.Parse(r[1].ToString());
                Vacation.amount = int.Parse(r[2].ToString());
                Vacation.Date = r[3].ToString();
                Vacation.ExpireDate = r[4].ToString();
                Vacation.Desc = r[5].ToString();
                Vacation.UserID = int.Parse(r[6].ToString());
                VacationList.Add(Vacation);
            }
            r.Close();
            cn.Close();
            return VacationList;
        }

        public bool InsertVacation(Vacation vacation)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblVacation " +
                              " (PersonID,amount,Date,ExpireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@amount,@Date,@ExpireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Vacation Vacation = new Vacation();
            Vacation = vacation;
            cmd.Parameters.AddWithValue("@VacationID", Vacation.VacationID);
            cmd.Parameters.AddWithValue("@PersonID", Vacation.PersonID);
            cmd.Parameters.AddWithValue("@amount", Vacation.amount);
            cmd.Parameters.AddWithValue("@Date", Vacation.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Vacation.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Vacation.Desc);
            cmd.Parameters.AddWithValue("@UserID", Vacation.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditVacation(Vacation vacation)
        {
            string SqlStr = "UPDATE tblVacation " +
                                 " SET PersonID = @PersonID, amount = @amount, Date=@Date,ExpireDate=@ExpireDate ,[Desc]=@Desc,UserID=@UserID WHERE VacationID=@VacationID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Vacation Vacation = new Vacation();
            Vacation = vacation;
            cmd.Parameters.AddWithValue("@VacationID", Vacation.VacationID);
            cmd.Parameters.AddWithValue("@PersonID", Vacation.PersonID);
            cmd.Parameters.AddWithValue("@amount", Vacation.amount);
            cmd.Parameters.AddWithValue("@Date", Vacation.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Vacation.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Vacation.Desc);
            cmd.Parameters.AddWithValue("@UserID", Vacation.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteVacation(int VacationID, int UserID)
        {
            string SqlStr = "UPDATE tblVacation SET VacationIsDel =1 where VacationID=@VacationID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@VacationID", VacationID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Vacation
    }
}
