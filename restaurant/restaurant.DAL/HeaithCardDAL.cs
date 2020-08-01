

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
    public class HeaithCardDAL
    {
        #region HeaithCard

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public HeaithCard LoadHeaithCard(int HeaithCardID)
        {
            string SqlStr = "select * from tblHeaithCard where HeaithCardIsDel=0 and HeaithCardID=@HeaithCardID";
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCardID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return HeaithCard;
        }

        public HeaithCard LoadHeaithCardWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblHeaithCard where HeaithCardIsDel=0 and PersonID=@PersonID";
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return HeaithCard;
        }
        public DataTable LoadHeaithCardListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.[Desc] from tblHeaithCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.HeaithCardIsDel=0) and F.UserID=@UserID";
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
        public List<HeaithCard> LoadHeaithCardList2()
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0)";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
                HeaithCardList.Add(HeaithCard);
            }
            r.Close();
            cn.Close();
            return HeaithCardList;
        }

        public List<HeaithCard> LoadHeaithCardList3(int PersonID)
        {
            string SqlStr = "select F.HeaithCardID,F.PersonID,F.number,F.expireDate,F.[Desc],F.UserID,F.HeaithCardIsDel from tblHeaithCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.HeaithCardIsDel=0) and F.PersonID=@PersonID";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
                HeaithCardList.Add(HeaithCard);
            }
            r.Close();
            cn.Close();
            return HeaithCardList;
        }

        public DataTable LoadHeaithCardListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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

        


        public DataTable LoadHeaithCardList(int PersonID)
        {
            string SqlStr = "select F.HeaithCardID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.HeaithCardIsDel from tblHeaithCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.HeaithCardIsDel=0) and F.PersonID=@PersonID";
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

        public List<HeaithCard> LoadHeaithCardListWithDistinctPersonID(int UserID)
        {
            string SqlStr = "select distinct PersonID from tblHeaithCard where (HeaithCardIsDel=0) and UserID=@UserID ";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;
       
                       
               r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard.PersonID = int.Parse(r2[0].ToString());
               
             HeaithCardList.Add(HeaithCard);
            }
            r2.Close();
            cn.Close();
            return HeaithCardList;
        }
            
        public int accountinglastsalary(int PersonID, int HeaithCardID)
        {
            string SqlStr = "select (HeaithCardID) AS From tblHeaithCard Where HeaithCardIsDel=0";
            // string SqlStr = "select F.HeaithCardID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.HeaithCardIsDel from tblHeaithCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.HeaithCardIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public HeaithCard LoadHeaithCardWithPersonID(int PersonID, int HeaithCardID)
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0) and PersonID=@PersonID and HeaithCardID=@HeaithCardID ";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCardID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //HeaithCard = new HeaithCard();
            HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
            HeaithCard.PersonID = int.Parse(r[1].ToString());
            HeaithCard.number = r[2].ToString();
            HeaithCard.expireDate = r[3].ToString();
            HeaithCard.Desc = r[4].ToString();
            HeaithCard.UserID = int.Parse(r[5].ToString());
            //HeaithCardList.Add(HeaithCard);
            // }
            r.Close();
            cn.Close();
            return HeaithCard;
        }

        public List<HeaithCard> LoadHeaithCardListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0) and PersonID=@PersonID ";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCardID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
                HeaithCardList.Add(HeaithCard);
            }
            r.Close();
            cn.Close();
            return HeaithCardList;
        }
        public List<HeaithCard> LoadHeaithCardListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard = new HeaithCard();
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
                HeaithCardList.Add(HeaithCard);
            }
            r.Close();
            cn.Close();
            return HeaithCardList;
        }

        public List<HeaithCard> LoadHeaithCardListContorID(int UserID)
        {
            string SqlStr = "select * from tblHeaithCard where (HeaithCardIsDel=0) and UserID=@UserID";
            List<HeaithCard> HeaithCardList = new List<HeaithCard>();
            HeaithCard HeaithCard = new HeaithCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                HeaithCard = new HeaithCard();
                HeaithCard.HeaithCardID = int.Parse(r[0].ToString());
                HeaithCard.PersonID = int.Parse(r[1].ToString());
                HeaithCard.number = r[2].ToString();
                HeaithCard.expireDate = r[3].ToString();
                HeaithCard.Desc = r[4].ToString();
                HeaithCard.UserID = int.Parse(r[5].ToString());
                HeaithCardList.Add(HeaithCard);
            }
            r.Close();
            cn.Close();
            return HeaithCardList;
        }

        public bool InsertHeaithCard(HeaithCard heaithCard)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblHeaithCard " +
                              " (PersonID,number,expireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@expireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            HeaithCard HeaithCard = new HeaithCard();
            HeaithCard = heaithCard;
            cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCard.HeaithCardID);
            cmd.Parameters.AddWithValue("@PersonID", HeaithCard.PersonID);
            cmd.Parameters.AddWithValue("@number", HeaithCard.number);
            cmd.Parameters.AddWithValue("@expireDate", HeaithCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", HeaithCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", HeaithCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditHeaithCard(HeaithCard heaithCard)
        {
            string SqlStr = "UPDATE tblHeaithCard " +
                                 " SET PersonID = @PersonID, number = @number, expireDate=@expireDate ,[Desc]=@Desc,UserID=@UserID WHERE HeaithCardID=@HeaithCardID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            HeaithCard HeaithCard = new HeaithCard();
            HeaithCard = heaithCard;
            cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCard.HeaithCardID);
            cmd.Parameters.AddWithValue("@PersonID", HeaithCard.PersonID);
            cmd.Parameters.AddWithValue("@number", HeaithCard.number);
            cmd.Parameters.AddWithValue("@expireDate", HeaithCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", HeaithCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", HeaithCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteHeaithCard(int HeaithCardID, int UserID)
        {
            string SqlStr = "UPDATE tblHeaithCard SET HeaithCardIsDel =1 where HeaithCardID=@HeaithCardID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@HeaithCardID", HeaithCardID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion HeaithCard
    }
}
