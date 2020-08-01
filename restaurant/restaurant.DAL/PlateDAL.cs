

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
    public class PlateDAL
    {
        #region Plate

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Plate LoadPlate(int PlateID)
        {
            string SqlStr = "select * from tblPlate where PlateIsDel=0 and PlateID=@PlateID";
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PlateID", PlateID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Plate.PlateID = int.Parse(r[0].ToString());
                Plate.CarID = int.Parse(r[1].ToString());
                Plate.amount = int.Parse(r[2].ToString());
                Plate.Date = r[3].ToString();
                Plate.ExpireDate = r[4].ToString();
                Plate.Desc = r[5].ToString();
                Plate.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Plate;
        }

        public Plate LoadPlateWithTitle(int CarID)
        {
            string SqlStr = "select * from tblPlate where PlateIsDel=0 and CarID=@CarID";
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Plate.PlateID = int.Parse(r[0].ToString());
                Plate.CarID = int.Parse(r[1].ToString());
                Plate.amount = int.Parse(r[2].ToString());
                Plate.Date = r[3].ToString();
                Plate.ExpireDate = r[4].ToString();
                Plate.Desc = r[5].ToString();
                Plate.UserID = int.Parse(r[6].ToString());
            }
            r.Close();
            cn.Close();
            return Plate;
        }

        public List<Plate> LoadPlateList2()
        {
            string SqlStr = "select * from tblPlate where (PlateIsDel=0)";
            List<Plate> PlateList = new List<Plate>();
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Plate = new Plate();
                Plate.PlateID = int.Parse(r[0].ToString());
                Plate.CarID = int.Parse(r[1].ToString());
                Plate.amount = int.Parse(r[2].ToString());
                Plate.Date = r[3].ToString();
                Plate.ExpireDate = r[4].ToString();
                Plate.Desc = r[5].ToString();
                Plate.UserID = int.Parse(r[6].ToString());
                PlateList.Add(Plate);
            }
            r.Close();
            cn.Close();
            return PlateList;
        }
        public DataTable LoadPlateListWithDateUntilDate(string Date, int ExpireDate)
        {
            string SqlStr = "select * from tblPlate where (PlateIsDel=0) and Date=@Date and ExpireDate=@ExpireDate";
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
        public DataTable LoadPlateList(int CarID)
        {
            string SqlStr = "select F.PlateID,tblCar.number,tblCar.Type,F.amount,F.Date,F.ExpireDate,F.CarID,F.[Desc],F.UserID,F.PlateIsDel from tblPlate as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.PlateIsDel=0) and F.CarID=@CarID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable LoadPlateListFORExcel(int UserID)
        {
            string SqlStr = "select tblCar.number,tblCar.Type,F.amount,F.Date,F.ExpireDate,F.[Desc] from tblPlate as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.PlateIsDel=0) and F.UserID=@UserID";
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
        public int accountinglastsalary(int CarID, int PlateID)
        {
            string SqlStr = "select (PlateID) AS From tblPlate Where PlateIsDel=0";
            // string SqlStr = "select F.PlateID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.CarID,F.[Desc],F.UserID,F.PlateIsDel from tblPlate as F INNER JOIN tblPerson on F.CarID=tblPerson.CarID where (F.PlateIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Plate LoadPlateWithCarID(int CarID, int PlateID)
        {
            string SqlStr = "select * from tblPlate where (PlateIsDel=0) and CarID=@CarID and PlateID=@PlateID ";
            List<Plate> PlateList = new List<Plate>();
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@PlateID", PlateID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Plate = new Plate();
            Plate.PlateID = int.Parse(r[0].ToString());
            Plate.CarID = int.Parse(r[1].ToString());
            Plate.amount = int.Parse(r[2].ToString());
            Plate.Date = r[3].ToString();
            Plate.ExpireDate = r[4].ToString();
            Plate.Desc = r[5].ToString();
            Plate.UserID = int.Parse(r[6].ToString());
            //PlateList.Add(Plate);
            // }
            r.Close();
            cn.Close();
            return Plate;
        }

        public List<Plate> LoadPlateListWithCarID(int CarID)
        {
            string SqlStr = "select * from tblPlate where (PlateIsDel=0) and CarID=@CarID ";
            List<Plate> PlateList = new List<Plate>();
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            // cmd.Parameters.AddWithValue("@PlateID", PlateID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Plate = new Plate();
                Plate.PlateID = int.Parse(r[0].ToString());
                Plate.CarID = int.Parse(r[1].ToString());
                Plate.amount = int.Parse(r[2].ToString());
                Plate.Date = r[3].ToString();
                Plate.ExpireDate = r[4].ToString();
                Plate.Desc = r[5].ToString();
                Plate.UserID = int.Parse(r[6].ToString());
                PlateList.Add(Plate);
            }
            r.Close();
            cn.Close();
            return PlateList;
        }

        public List<Plate> LoadPlateList3(int CarID)
        {
            string SqlStr = "select F.PlateID,F.CarID,F.amount,F.Date,F.expireDate,F.[Desc],F.UserID,F.PlateIsDel from tblPlate as F INNER JOIN tblCar on F.CarID=tblCar.CarID where (F.PlateIsDel=0) and F.CarID=@CarID";
            List<Plate> PlateList = new List<Plate>();
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Plate = new Plate();
                Plate.PlateID = int.Parse(r[0].ToString());
                Plate.CarID = int.Parse(r[1].ToString());
                Plate.amount = int.Parse(r[2].ToString());
                Plate.Date = r[3].ToString();
                Plate.ExpireDate = r[4].ToString();
                Plate.Desc = r[5].ToString();
                Plate.UserID = int.Parse(r[6].ToString());
                PlateList.Add(Plate);
            }
            r.Close();
            cn.Close();
            return PlateList;
        }

        public List<Plate> LoadPlateListWithDistinctCarID(int UserID)
        {
            string SqlStr = "select distinct CarID from tblPlate where (PlateIsDel=0) and UserID=@UserID ";
            List<Plate> PlateList = new List<Plate>();
            Plate Plate = new Plate();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Plate = new Plate();
                Plate.CarID = int.Parse(r2[0].ToString());

                PlateList.Add(Plate);
            }
            r2.Close();
            cn.Close();
            return PlateList;
        }


        public bool InsertPlate(Plate plate)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblPlate " +
                              " (CarID,amount,Date,ExpireDate,[Desc],UserID)" +
                              " VALUES (@CarID,@amount,@Date,@ExpireDate,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Plate Plate = new Plate();
            Plate = plate;
            cmd.Parameters.AddWithValue("@PlateID", Plate.PlateID);
            cmd.Parameters.AddWithValue("@CarID", Plate.CarID);
            cmd.Parameters.AddWithValue("@amount", Plate.amount);
            cmd.Parameters.AddWithValue("@Date", Plate.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Plate.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Plate.Desc);
            cmd.Parameters.AddWithValue("@UserID", Plate.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditPlate(Plate plate)
        {
            string SqlStr = "UPDATE tblPlate " +
                                 " SET CarID = @CarID, amount = @amount, Date=@Date,ExpireDate=@ExpireDate ,[Desc]=@Desc,UserID=@UserID WHERE PlateID=@PlateID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Plate Plate = new Plate();
            Plate = plate;
            cmd.Parameters.AddWithValue("@PlateID", Plate.PlateID);
            cmd.Parameters.AddWithValue("@CarID", Plate.CarID);
            cmd.Parameters.AddWithValue("@amount", Plate.amount);
            cmd.Parameters.AddWithValue("@Date", Plate.Date);
            cmd.Parameters.AddWithValue("@ExpireDate", Plate.ExpireDate);
            cmd.Parameters.AddWithValue("@Desc", Plate.Desc);
            cmd.Parameters.AddWithValue("@UserID", Plate.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeletePlate(int PlateID, int UserID)
        {
            string SqlStr = "UPDATE tblPlate SET PlateIsDel =1 where PlateID=@PlateID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PlateID", PlateID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Plate
    }
}
