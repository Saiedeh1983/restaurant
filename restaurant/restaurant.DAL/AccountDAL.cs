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
   public class AccountDAL
    {
        #region Account

       //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ali"].ConnectionString);
       SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123"); 
      
       SqlCommand cmd;
       public Account LoadAccount(int AccountID, int UserID)
        {
            string SqlStr = "select * from tblAccount where IsDel=0 and AccountID=@AccountID and UserID=@UserID";
            Account Account = new Account();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Account.AccountID = int.Parse(r[0].ToString());
                Account.AccountNum = r[1].ToString();
                Account.BankName = int.Parse(r[2].ToString());
                Account.AccountType = int.Parse(r[3].ToString());
                Account.Description = r[4].ToString();
                Account.CodePart = int.Parse(r[5].ToString());
                Account.NamePart = r[6].ToString();
                Account.UserID = int.Parse(r[7].ToString());
                Account.Date = r[8].ToString();
            }
            r.Close();
            cn.Close();
            return Account;
        }

       public DataTable LoadAccountList(int UserID)
       {
           string SqlStr = "select A.AccountID,A.AccountNum,D.DetailInfoTitle,A.CodePart,A.NamePart,Description,Date,A.BankName,A.AccountType,A.UserID from tblAccount as A " +
           " INNER JOIN tblDetailInfo AS D ON D.DetailInfoID=A.BankName INNER JOIN tblBaseInfo ON D.BaseInfoID=tblBaseInfo.BaseInfoID where A.UserID=@UserID and A.IsDel=0";
           //string SqlStr = "select * from tblAccount where IsDel=0";
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

       public List<Account> LoadAccountListWithAccountNum(int AccountNum, int UserID)
        {
            string SqlStr = "select * from tblAccount where IsDel=0 and AccountNum=@AccountNum and UserID=@UserID";
            List<Account> AccountList = new List<Account>();
            Account Account = new Account();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@AccountNum", AccountNum);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Account = new Account();
                Account.AccountID = int.Parse(r[0].ToString());
                Account.AccountNum = r[1].ToString();
                Account.BankName = int.Parse(r[2].ToString());
                Account.AccountType = int.Parse(r[3].ToString());
                Account.Description = r[4].ToString();
                Account.CodePart = int.Parse(r[5].ToString());
                Account.NamePart = r[6].ToString();
                Account.UserID = int.Parse(r[7].ToString());
                Account.Date = r[8].ToString();
                AccountList.Add(Account);
            }
            r.Close();
            cn.Close();
            return AccountList;
        }

       public List<Account> LoadAccountList2(int UserID)
        {
            string SqlStr = "select * from tblAccount where IsDel=0 and UserID=@UserID";
            List<Account> AccountList = new List<Account>();
            Account Account = new Account();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Connection = cn;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Account = new Account();
                Account.AccountID = int.Parse(r[0].ToString());
                Account.AccountNum = r[1].ToString();
                Account.BankName = int.Parse(r[2].ToString());
                Account.AccountType = int.Parse(r[3].ToString());
                Account.Description = r[4].ToString();
                Account.CodePart = int.Parse(r[5].ToString());
                Account.NamePart = r[6].ToString();
                Account.UserID = int.Parse(r[7].ToString());
                Account.Date = r[8].ToString();
                AccountList.Add(Account);
            }
            r.Close();
            cn.Close();
            return AccountList;
        }
        
        public Int32 InsertAccount(Account account)
        {
            Int32 LastID = 0;
            //try
            //{

            string SqlStr = "Insert into tblAccount " +
                              " (AccountNum,BankName,AccountType,Description,CodePart,NamePart,UserID,Date)" +
                              " VALUES (@AccountNum,@BankName,@AccountType,@Description,@CodePart,@NamePart,@UserID,@Date)";
                              //+
                             // "SELECT SCOPE_IDENTITY() AS LastID";
           if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Account Account = new Account();
            Account = account;
          //  cmd.Parameters.AddWithValue("@AccountID",account.AccountType);
            cmd.Parameters.AddWithValue("@AccountNum", Account.AccountNum);
            cmd.Parameters.AddWithValue("@BankName", Account.BankName);
            cmd.Parameters.AddWithValue("@AccountType", Account.AccountType);
            cmd.Parameters.AddWithValue("@Description", Account.Description);
            cmd.Parameters.AddWithValue("@CodePart", Account.CodePart);
            cmd.Parameters.AddWithValue("@NamePart", Account.NamePart);
            cmd.Parameters.AddWithValue("@UserID", Account.UserID);
            cmd.Parameters.AddWithValue("@Date", Account.Date);

            
          
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
        public void EditAccount(Account account)
        {
            string SqlStr = "UPDATE tblAccount " +
                                 " SET AccountNum = @AccountNum, BankName = @BankName, AccountType=@AccountType,Description=@Description,CodePart=@CodePart,NamePart=@NamePart,UserID=@UserID,Date=@Date WHERE AccountID=@AccountID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Account Account = new Account();
            Account = account;
            cmd.Parameters.AddWithValue("@AccountID", Account.AccountID);
            cmd.Parameters.AddWithValue("@AccountNum", Account.AccountNum);
            cmd.Parameters.AddWithValue("@BankName", Account.BankName);
            cmd.Parameters.AddWithValue("@AccountType", Account.AccountType);
            cmd.Parameters.AddWithValue("@Description", Account.Description);
            cmd.Parameters.AddWithValue("@CodePart", Account.CodePart);
            cmd.Parameters.AddWithValue("@NamePart", Account.NamePart);
            cmd.Parameters.AddWithValue("@UserID", Account.UserID);
            cmd.Parameters.AddWithValue("@Date", Account.Date);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

       public void DeleteAccount(int AccountID, int UserID)
        {
            string SqlStr = "UPDATE tblAccount SET IsDel=1 where AccountID=@AccountID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Account
    }
}
