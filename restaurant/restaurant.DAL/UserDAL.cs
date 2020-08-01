using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using restaurant.COMMON;
using restaurant.DAL;

namespace restaurant.DAL
{
   public class UserDAL
    {
        #region User

       SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public User LoadUser(int UserID)
        {
            string SqlStr = "select * from tblUser where (IsDel=0) and UserID=@UserID ";
            User User = new User();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                User.UserID = int.Parse(r[0].ToString());
                User.UserName = r[1].ToString();
                User.Password = r[2].ToString();
                User.Desc = r[3].ToString();
                User.Date = r[4].ToString();
                User.Question = int.Parse(r[5].ToString());
                User.Answer = r[6].ToString();
                User.Admin = int.Parse(r[7].ToString());
                User.SequrityStr = r[8].ToString();
            }
            r.Close();
            cn.Close();
            return User;
        }

       public List<User> LoadUserListWithUserName(string UserName)
        {
            string SqlStr = "select * from tblUser where (IsDel=0) and UserName=@UserName ";
            List<User> UserList = new List<User>();
            User User = new User();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                User = new User();
                User.UserID = int.Parse(r[0].ToString());
                User.UserName = r[1].ToString();
                User.Password = r[2].ToString();
                User.Desc = r[3].ToString();
                User.Date = r[4].ToString();
                User.Question = int.Parse(r[5].ToString());
                User.Answer = r[6].ToString();
                User.Admin = int.Parse(r[7].ToString());
                User.SequrityStr = r[8].ToString();
                UserList.Add(User);
            }
            r.Close();
            cn.Close();
            return UserList;
        }

       public List<User> LoadUserListWithUserNameAndPassword(string UserName,string Password)
       {
           string SqlStr = "select * from tblUser where (IsDel=0) and UserName=@UserName and Password=@Password";
           List<User> UserList = new List<User>();
           User User = new User();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);
           cmd.Connection = cn;
           cmd.Parameters.AddWithValue("@UserName", UserName);
           cmd.Parameters.AddWithValue("@Password", Password);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               User = new User();
               User.UserID = int.Parse(r[0].ToString());
               User.UserName = r[1].ToString();
               User.Password = r[2].ToString();
               User.Desc = r[3].ToString();
               User.Date = r[4].ToString();
               //User.Question = int.Parse(r[5].ToString());
               User.Answer = r[6].ToString();
               User.Admin = int.Parse(r[7].ToString());
               User.SequrityStr = r[8].ToString();
               UserList.Add(User);
           }
           r.Close();
           cn.Close();
           return UserList;
       }

        public List<User> LoadUserList2()
        {
            string SqlStr = "select * from tblUser where (IsDel=0)";
            List<User> UserList = new List<User>();
            User User = new User();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Connection = cn;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                User = new User();
                User.UserID = int.Parse(r[0].ToString());
                User.UserName = r[1].ToString();
                User.Password = r[2].ToString();
                User.Desc = r[3].ToString();
                User.Date = r[4].ToString();
                //User.Date = r[5].ToString();
                //User.Question = int.Parse(r[5].ToString());
                User.Answer = r[6].ToString();
                User.Admin = int.Parse(r[7].ToString());
                User.SequrityStr = r[8].ToString();
                UserList.Add(User);
            }
            r.Close();
            cn.Close();
            return UserList;
        }

       public List<User> LoadUserListWithPassword(string Password)
        {
            string SqlStr = "select * from tblUser where (IsDel=0) and Password=@Password";
            List<User> UserList = new List<User>();
            User User = new User();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                User = new User();
                User.UserID = int.Parse(r[0].ToString());
                User.UserName = r[1].ToString();
                User.Password = r[2].ToString();
                User.Desc = r[3].ToString();
                User.Date = r[4].ToString();
                User.Question = int.Parse(r[5].ToString());
                User.Answer = r[6].ToString();
                User.Admin = int.Parse(r[7].ToString());
                User.SequrityStr = r[8].ToString();
                UserList.Add(User);
            }
            r.Close();
            cn.Close();
            return UserList;
        }

       public DataTable LoadUserList()
       {
           string SqlStr = "select U.UserID,U.UserName,U.Password,D.DetailInfoTitle,U.Answer,U.[Desc],U.Date,U.Admin from tblUser as U inner join tblDetailInfo as D on D.DetailInfoID=U.Question where U.IsDel=0";
           SqlCommand cmd = new SqlCommand(SqlStr, cn);
           SqlDataAdapter Da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           Da.Fill(dt);
           cn.Close();
           return dt;
       }

       public DataTable LoadUserList1()
       {
           string SqlStr = "select U.UserID,U.UserName,U.Password,U.Question,U.Answer,U.[Desc],U.Date from tblUser as U where U.IsDel=0";
           SqlCommand cmd = new SqlCommand(SqlStr, cn);
           SqlDataAdapter Da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           Da.Fill(dt);
           cn.Close();
           return dt;
       }

        //public DataTable LoadUserListWithUnitID(int UnitID, int UserID)
        //{
            //string SqlStr = "select tblUser.* from tblUser INNER JOIN Unit_User ON Unit_User.UserID=tblUser.UserID" +
           // " INNER JOIN tblDetailInfo ON tblDetailInfo.DetailInfoID=tblUser.Question where Unit_User.UnitID=@UnitID and Unit_User.UserID=@UserID";
            //SqlCommand cmd = new SqlCommand(SqlStr, cn);
            //cmd.Parameters.AddWithValue("@UnitID", UnitID);
            //cmd.Parameters.AddWithValue("@UserID", UserID);
           // SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
           // if (cn.State == ConnectionState.Closed)
             //   cn.Open();
            //Da.Fill(dt);
            //cn.Close();
            //return dt;
       // }

        public DataTable LoadUserList2(int UnitID)
        {
            string SqlStr = "select U.UserID,U.UserName,U.Password,D.DetailInfoTitle,U.Answer,U.[Desc],C.Date from tblUser as U inner join tblDetailInfo as D on D.DetailInfoID=C.Question where U.IsDel=0";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }

        public Int32 InsertUser(User user)
        {
            Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblUser " +
                              " (UserName,Password,[Desc],Date,Question,Answer,Admin,SequrityStr)" +
                              " VALUES (@UserName,@Password,@Desc,@Date,@Question,@Answer,@Admin,@SequrityStr)" +
                               "SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            User User = new User();
            User = user;
            if (User.Answer == null)
                User.Answer = "";
            cmd.Parameters.AddWithValue("@UserName", User.UserName);
            cmd.Parameters.AddWithValue("@Password", User.Password);
            cmd.Parameters.AddWithValue("@Desc", User.Desc);
            cmd.Parameters.AddWithValue("@Date", User.Date);
            cmd.Parameters.AddWithValue("@Question", User.Question);
            cmd.Parameters.AddWithValue("@Answer", User.Answer);
            cmd.Parameters.AddWithValue("@Admin", User.Admin);
            cmd.Parameters.AddWithValue("@SequrityStr", User.SequrityStr);
            SqlDataReader Dr;
            Dr = cmd.ExecuteReader();
            Dr.Read();
            if (Dr.HasRows)
                LastID = Convert.ToInt32(Dr.GetValue(0));
            Dr.Close();
            cn.Close();
            return LastID;
            //}
            //catch { return 0; }
        }
        public void EditUser(User user)
        {
            string SqlStr = "UPDATE tblUser " +
                                 " SET UserName = @UserName, Password = @Password, [Desc]=@Desc,Date=@Date,Question=@Question,Answer=@Answer,Admin=@Admin,SequrityStr=@SequrityStr WHERE UserID=@UserID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            User User = new User();
            User = user;
            cmd.Parameters.AddWithValue("@UserID", User.UserID);
            cmd.Parameters.AddWithValue("@UserName", User.UserName);
            cmd.Parameters.AddWithValue("@Password", User.Password);
            cmd.Parameters.AddWithValue("@Desc", User.Desc);
            cmd.Parameters.AddWithValue("@Date", User.Date);
            cmd.Parameters.AddWithValue("@Question", User.Question);
            cmd.Parameters.AddWithValue("@Answer", User.Answer);
            cmd.Parameters.AddWithValue("@Admin", User.Admin);
            cmd.Parameters.AddWithValue("@SequrityStr", User.SequrityStr);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteUser(int UserID)
        {
            string SqlStr = "UPDATE tblUser SET IsDel=1 where UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion User
    }
}
