
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
    public class PhoneBookDAL
    {
        #region PhoneBook

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public PhoneBook LoadPhoneBook(int PhoneBookID)
        {
            string SqlStr = "select * from tblPhoneBook where PhoneBookIsDel=0 and PhoneBookID=@PhoneBookID";
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return PhoneBook;
        }

        public PhoneBook LoadPhoneBookWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblPhoneBook where PhoneBookIsDel=0 and PersonID=@PersonID";
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return PhoneBook;
        }

        public List<PhoneBook> LoadPhoneBookList2()
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0)";
            List<PhoneBook> PhoneBookList = new List<PhoneBook>();
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PhoneBook = new PhoneBook();
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
                PhoneBookList.Add(PhoneBook);
            }
            r.Close();
            cn.Close();
            return PhoneBookList;
        }

        public DataTable LoadPhoneBookListFORExcel(int UserID)
        {
            string SqlStr = "select Name,Tel,Address,[Desc] from tblPhoneBook where (PhoneBookIsDel=0) and UserID=@UserID";
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
        public DataTable LoadPhoneBookListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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

        public DataTable LoadPhoneBookList(int UserID)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and UserID=@UserID";
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

        public int accountinglastsalary(int PersonID, int PhoneBookID)
        {
            string SqlStr = "select (PhoneBookID) AS From tblPhoneBook Where PhoneBookIsDel=0";
            // string SqlStr = "select F.PhoneBookID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.PhoneBookIsDel from tblPhoneBook as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.PhoneBookIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public PhoneBook LoadPhoneBookWithPersonID(int PersonID, int PhoneBookID)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and PersonID=@PersonID and PhoneBookID=@PhoneBookID ";
            List<PhoneBook> PhoneBookList = new List<PhoneBook>();
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //PhoneBook = new PhoneBook();
            PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
            PhoneBook.Name = r[1].ToString();
            PhoneBook.Tel = r[2].ToString();
            PhoneBook.Address = r[3].ToString();
            PhoneBook.Desc = r[4].ToString();
            PhoneBook.UserID = int.Parse(r[5].ToString());
            //PhoneBookList.Add(PhoneBook);
            // }
            r.Close();
            cn.Close();
            return PhoneBook;
        }

        public List<PhoneBook> LoadPhoneBookListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and PersonID=@PersonID ";
            List<PhoneBook> PhoneBookList = new List<PhoneBook>();
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PhoneBook = new PhoneBook();
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
                PhoneBookList.Add(PhoneBook);
            }
            r.Close();
            cn.Close();
            return PhoneBookList;
        }
        public List<PhoneBook> LoadPhoneBookListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<PhoneBook> PhoneBookList = new List<PhoneBook>();
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PhoneBook = new PhoneBook();
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
                PhoneBookList.Add(PhoneBook);
            }
            r.Close();
            cn.Close();
            return PhoneBookList;
        }

        public List<PhoneBook> LoadPhoneBookListContorID(int UserID)
        {
            string SqlStr = "select * from tblPhoneBook where (PhoneBookIsDel=0) and UserID=@UserID";
            List<PhoneBook> PhoneBookList = new List<PhoneBook>();
            PhoneBook PhoneBook = new PhoneBook();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PhoneBook = new PhoneBook();
                PhoneBook.PhoneBookID = int.Parse(r[0].ToString());
                PhoneBook.Name = r[1].ToString();
                PhoneBook.Tel = r[2].ToString();
                PhoneBook.Address = r[3].ToString();
                PhoneBook.Desc = r[4].ToString();
                PhoneBook.UserID = int.Parse(r[5].ToString());
                PhoneBookList.Add(PhoneBook);
            }
            r.Close();
            cn.Close();
            return PhoneBookList;
        }

        public bool InsertPhoneBook(PhoneBook phoneBook)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblPhoneBook " +
                              " (Name,Tel,Address,[Desc],UserID)" +
                              " VALUES (@Name,@Tel,@Address,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            PhoneBook PhoneBook = new PhoneBook();
            PhoneBook = phoneBook;
            cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBook.PhoneBookID);
            cmd.Parameters.AddWithValue("@Name", PhoneBook.Name);
            cmd.Parameters.AddWithValue("@Tel", PhoneBook.Tel);
            cmd.Parameters.AddWithValue("@Address", PhoneBook.Address);
            cmd.Parameters.AddWithValue("@Desc", PhoneBook.Desc);
            cmd.Parameters.AddWithValue("@UserID", PhoneBook.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditPhoneBook(PhoneBook phoneBook)
        {
            string SqlStr = "UPDATE tblPhoneBook " +
                                 " SET  Name = @Name, Tel=@Tel ,Address=@Address,[Desc]=@Desc,UserID=@UserID WHERE PhoneBookID=@PhoneBookID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            PhoneBook PhoneBook = new PhoneBook();
            PhoneBook = phoneBook;
            cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBook.PhoneBookID);
            cmd.Parameters.AddWithValue("@Name", PhoneBook.Name);
            cmd.Parameters.AddWithValue("@Tel", PhoneBook.Tel);
            cmd.Parameters.AddWithValue("@Address", PhoneBook.Address);
            cmd.Parameters.AddWithValue("@Desc", PhoneBook.Desc);
            cmd.Parameters.AddWithValue("@UserID", PhoneBook.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeletePhoneBook(int PhoneBookID, int UserID)
        {
            string SqlStr = "UPDATE tblPhoneBook SET PhoneBookIsDel =1 where PhoneBookID=@PhoneBookID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion PhoneBook
    }
}
