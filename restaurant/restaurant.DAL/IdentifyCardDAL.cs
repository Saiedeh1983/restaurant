

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
    public class IdentifyCardDAL
    {
        #region IdentifyCard

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public IdentifyCard LoadIdentifyCard(int IdentifyCardID)
        {
            string SqlStr = "select * from tblIdentifyCard where IdentifyCardIsDel=0 and IdentifyCardID=@IdentifyCardID";
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCardID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return IdentifyCard;
        }

        public IdentifyCard LoadIdentifyCardWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblIdentifyCard where IdentifyCardIsDel=0 and PersonID=@PersonID";
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return IdentifyCard;
        }
        public DataTable LoadIdentifyCardListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.[Desc] from tblIdentifyCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IdentifyCardIsDel=0) and F.UserID=@UserID";
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
        public List<IdentifyCard> LoadIdentifyCardList2()
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0)";
            List<IdentifyCard> IdentifyCardList = new List<IdentifyCard>();
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                IdentifyCard = new IdentifyCard();
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
                IdentifyCardList.Add(IdentifyCard);
            }
            r.Close();
            cn.Close();
            return IdentifyCardList;
        }
        public DataTable LoadIdentifyCardListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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


        public DataTable LoadIdentifyCardList(int PersonID)
        {
            string SqlStr = "select F.IdentifyCardID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.IdentifyCardIsDel from tblIdentifyCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IdentifyCardIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int IdentifyCardID)
        {
            string SqlStr = "select (IdentifyCardID) AS From tblIdentifyCard Where IdentifyCardIsDel=0";
            // string SqlStr = "select F.IdentifyCardID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.IdentifyCardIsDel from tblIdentifyCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.IdentifyCardIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public IdentifyCard LoadIdentifyCardWithPersonID(int PersonID, int IdentifyCardID)
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0) and PersonID=@PersonID and IdentifyCardID=@IdentifyCardID ";
            List<IdentifyCard> IdentifyCardList = new List<IdentifyCard>();
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCardID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //IdentifyCard = new IdentifyCard();
            IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
            IdentifyCard.PersonID = int.Parse(r[1].ToString());
            IdentifyCard.number = r[2].ToString();
            IdentifyCard.expireDate = r[3].ToString();
            IdentifyCard.Desc = r[4].ToString();
            IdentifyCard.UserID = int.Parse(r[5].ToString());
            //IdentifyCardList.Add(IdentifyCard);
            // }
            r.Close();
            cn.Close();
            return IdentifyCard;
        }

        public List<IdentifyCard> LoadIdentifyCardListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0) and PersonID=@PersonID ";
            List<IdentifyCard> IdentifyCardList = new List<IdentifyCard>();
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCardID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                IdentifyCard = new IdentifyCard();
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
                IdentifyCardList.Add(IdentifyCard);
            }
            r.Close();
            cn.Close();
            return IdentifyCardList;
        }
        public List<IdentifyCard> LoadIdentifyCardListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<IdentifyCard> IdentifyCardList = new List<IdentifyCard>();
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                IdentifyCard = new IdentifyCard();
                IdentifyCard = new IdentifyCard();
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
                IdentifyCardList.Add(IdentifyCard);
            }
            r.Close();
            cn.Close();
            return IdentifyCardList;
        }

        public List<IdentifyCard> LoadIdentifyCardListContorID(int UserID)
        {
            string SqlStr = "select * from tblIdentifyCard where (IdentifyCardIsDel=0) and UserID=@UserID";
            List<IdentifyCard> IdentifyCardList = new List<IdentifyCard>();
            IdentifyCard IdentifyCard = new IdentifyCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                IdentifyCard = new IdentifyCard();
                IdentifyCard.IdentifyCardID = int.Parse(r[0].ToString());
                IdentifyCard.PersonID = int.Parse(r[1].ToString());
                IdentifyCard.number = r[2].ToString();
                IdentifyCard.expireDate = r[3].ToString();
                IdentifyCard.Desc = r[4].ToString();
                IdentifyCard.UserID = int.Parse(r[5].ToString());
                IdentifyCardList.Add(IdentifyCard);
            }
            r.Close();
            cn.Close();
            return IdentifyCardList;
        }

        public bool InsertIdentifyCard(IdentifyCard identifyCard)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblIdentifyCard " +
                              " (PersonID,number,expireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@expireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            IdentifyCard IdentifyCard = new IdentifyCard();
            IdentifyCard = identifyCard;
            cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCard.IdentifyCardID);
            cmd.Parameters.AddWithValue("@PersonID", IdentifyCard.PersonID);
            cmd.Parameters.AddWithValue("@number", IdentifyCard.number);
            cmd.Parameters.AddWithValue("@expireDate", IdentifyCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", IdentifyCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", IdentifyCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditIdentifyCard(IdentifyCard identifyCard)
        {
            string SqlStr = "UPDATE tblIdentifyCard " +
                                 " SET PersonID = @PersonID, number = @number, expireDate=@expireDate ,[Desc]=@Desc,UserID=@UserID WHERE IdentifyCardID=@IdentifyCardID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            IdentifyCard IdentifyCard = new IdentifyCard();
            IdentifyCard = identifyCard;
            cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCard.IdentifyCardID);
            cmd.Parameters.AddWithValue("@PersonID", IdentifyCard.PersonID);
            cmd.Parameters.AddWithValue("@number", IdentifyCard.number);
            cmd.Parameters.AddWithValue("@expireDate", IdentifyCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", IdentifyCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", IdentifyCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteIdentifyCard(int IdentifyCardID, int UserID)
        {
            string SqlStr = "UPDATE tblIdentifyCard SET IdentifyCardIsDel =1 where IdentifyCardID=@IdentifyCardID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IdentifyCardID", IdentifyCardID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion IdentifyCard
    }
}
