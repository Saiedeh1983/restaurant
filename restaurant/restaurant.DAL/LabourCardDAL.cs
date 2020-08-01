

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
    public class LabourCardDAL
    {
        #region LabourCard

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public LabourCard LoadLabourCard(int LabourCardID)
        {
            string SqlStr = "select * from tblLabourCard where LabourCardIsDel=0 and LabourCardID=@LabourCardID";
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@LabourCardID", LabourCardID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return LabourCard;
        }
        public List<LabourCard> LoadLabourCardList3(int PersonID)
        {
            string SqlStr = "select F.LabourCardID,F.PersonID,F.number,F.expireDate,F.[Desc],F.UserID,F.LabourCardIsDel from tblLabourCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.LabourCardIsDel=0) and F.PersonID=@PersonID";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                LabourCard = new LabourCard();
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
                LabourCardList.Add(LabourCard);
            }
            r.Close();
            cn.Close();
            return LabourCardList;
        }
        public List<LabourCard> LoadLabourCardListWithDistinctPersonID(int UserID)
        {
            string SqlStr = "select distinct PersonID from tblLabourCard where (LabourCardIsDel=0) and UserID=@UserID ";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                LabourCard = new LabourCard();
                LabourCard.PersonID = int.Parse(r2[0].ToString());

                LabourCardList.Add(LabourCard);
            }
            r2.Close();
            cn.Close();
            return LabourCardList;
        }
        public LabourCard LoadLabourCardWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblLabourCard where LabourCardIsDel=0 and PersonID=@PersonID";
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return LabourCard;
        }

        public List<LabourCard> LoadLabourCardList2()
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0)";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                LabourCard = new LabourCard();
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
                LabourCardList.Add(LabourCard);
            }
            r.Close();
            cn.Close();
            return LabourCardList;
        }
        public DataTable LoadLabourCardListWithDateUntilDate(string FromDate, int UntillDate)
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0) and FromDate=@FromDate and FromDate=@FromDate";
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
        public DataTable LoadLabourCardListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.[Desc] from tblLabourCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.LabourCardIsDel=0) and F.UserID=@UserID";
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


        public DataTable LoadLabourCardList(int PersonID)
        {
            string SqlStr = "select F.LabourCardID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.LabourCardIsDel from tblLabourCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.LabourCardIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int LabourCardID)
        {
            string SqlStr = "select (LabourCardID) AS From tblLabourCard Where LabourCardIsDel=0";
            // string SqlStr = "select F.LabourCardID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.LabourCardIsDel from tblLabourCard as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.LabourCardIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public LabourCard LoadLabourCardWithPersonID(int PersonID, int LabourCardID)
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0) and PersonID=@PersonID and LabourCardID=@LabourCardID ";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LabourCardID", LabourCardID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //LabourCard = new LabourCard();
            LabourCard.LabourCardID = int.Parse(r[0].ToString());
            LabourCard.PersonID = int.Parse(r[1].ToString());
            LabourCard.number = r[2].ToString();
            LabourCard.expireDate = r[3].ToString();
            LabourCard.Desc = r[4].ToString();
            LabourCard.UserID = int.Parse(r[5].ToString());
            //LabourCardList.Add(LabourCard);
            // }
            r.Close();
            cn.Close();
            return LabourCard;
        }

        public List<LabourCard> LoadLabourCardListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0) and PersonID=@PersonID ";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@LabourCardID", LabourCardID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                LabourCard = new LabourCard();
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
                LabourCardList.Add(LabourCard);
            }
            r.Close();
            cn.Close();
            return LabourCardList;
        }
        public List<LabourCard> LoadLabourCardListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                LabourCard = new LabourCard();
                LabourCard = new LabourCard();
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
                LabourCardList.Add(LabourCard);
            }
            r.Close();
            cn.Close();
            return LabourCardList;
        }

        public List<LabourCard> LoadLabourCardListContorID(int UserID)
        {
            string SqlStr = "select * from tblLabourCard where (LabourCardIsDel=0) and UserID=@UserID";
            List<LabourCard> LabourCardList = new List<LabourCard>();
            LabourCard LabourCard = new LabourCard();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                LabourCard = new LabourCard();
                LabourCard.LabourCardID = int.Parse(r[0].ToString());
                LabourCard.PersonID = int.Parse(r[1].ToString());
                LabourCard.number = r[2].ToString();
                LabourCard.expireDate = r[3].ToString();
                LabourCard.Desc = r[4].ToString();
                LabourCard.UserID = int.Parse(r[5].ToString());
                LabourCardList.Add(LabourCard);
            }
            r.Close();
            cn.Close();
            return LabourCardList;
        }

        public bool InsertLabourCard(LabourCard labourCard)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblLabourCard " +
                              " (PersonID,number,expireDate,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@expireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            LabourCard LabourCard = new LabourCard();
            LabourCard = labourCard;
            cmd.Parameters.AddWithValue("@LabourCardID", LabourCard.LabourCardID);
            cmd.Parameters.AddWithValue("@PersonID", LabourCard.PersonID);
            cmd.Parameters.AddWithValue("@number", LabourCard.number);
            cmd.Parameters.AddWithValue("@expireDate", LabourCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", LabourCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", LabourCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditLabourCard(LabourCard labourCard)
        {
            string SqlStr = "UPDATE tblLabourCard " +
                                 " SET PersonID = @PersonID, number = @number, expireDate=@expireDate ,[Desc]=@Desc,UserID=@UserID WHERE LabourCardID=@LabourCardID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            LabourCard LabourCard = new LabourCard();
            LabourCard = labourCard;
            cmd.Parameters.AddWithValue("@LabourCardID", LabourCard.LabourCardID);
            cmd.Parameters.AddWithValue("@PersonID", LabourCard.PersonID);
            cmd.Parameters.AddWithValue("@number", LabourCard.number);
            cmd.Parameters.AddWithValue("@expireDate", LabourCard.expireDate);
            cmd.Parameters.AddWithValue("@Desc", LabourCard.Desc);
            cmd.Parameters.AddWithValue("@UserID", LabourCard.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteLabourCard(int LabourCardID, int UserID)
        {
            string SqlStr = "UPDATE tblLabourCard SET LabourCardIsDel =1 where LabourCardID=@LabourCardID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@LabourCardID", LabourCardID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion LabourCard
    }
}
