

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
    public class CarDAL
    {
        #region Car

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Car LoadCar(int CarID, int UserID)
        {
            string SqlStr = "select * from tblCar where CarIsDel=0 and CarID=@CarID and UserID=@UserID";
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return Car;
        }
        public DataTable LoadCarListFORExcel(int UserID)
        {
            string SqlStr = "select tblPerson.Name,tblPerson.Family,F.number,F.Type,F.[Desc] from tblCar as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.CarIsDel=0) and F.UserID=@UserID";
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
        public Car LoadCarWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblCar where CarIsDel=0 and PersonID=@PersonID";
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return Car;
        }

        public List<Car> LoadCarList2()
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0)";
            List<Car> CarList = new List<Car>();
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Car = new Car();
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
                CarList.Add(Car);
            }
            r.Close();
            cn.Close();
            return CarList;
        }


        public Car LoadCarWithnumberandType(string number, string Type, int UserID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and number=@number and Type=@Type and UserID=@UserID";
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Car = new Car();
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
            }
            r.Close();
            cn.Close();
            return Car;
        }
        public DataTable LoadCarListWithnumberandType(string number, string Type, int UserID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and number=@number and Type=@Type and UserID=@UserID";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable LoadCarListWithCarID(int CarID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and CarID=@CarID";
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

        public DataTable LoadCarList(int PersonID)
        {
            string SqlStr = "select F.CarID,tblPerson.Name,tblPerson.Family,F.number,F.Type,F.PersonID,F.[Desc],F.UserID,F.CarIsDel from tblCar as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.CarIsDel=0) and F.PersonID=@PersonID";
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

        public int accountinglastsalary(int PersonID, int CarID)
        {
            string SqlStr = "select (CarID) AS From tblCar Where CarIsDel=0";
            // string SqlStr = "select F.CarID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.CarIsDel from tblCar as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.CarIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Car LoadCarWithPersonID(int PersonID, int CarID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and PersonID=@PersonID and CarID=@CarID ";
            List<Car> CarList = new List<Car>();
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Car = new Car();
            Car.CarID = int.Parse(r[0].ToString());
            Car.PersonID = int.Parse(r[1].ToString());
            Car.number = r[2].ToString();
            Car.Type = r[3].ToString();
            Car.Desc = r[4].ToString();
            Car.UserID = int.Parse(r[5].ToString());
            //CarList.Add(Car);
            // }
            r.Close();
            cn.Close();
            return Car;
        }

        public List<Car> LoadCarListWithPersonID(int PersonID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and PersonID=@PersonID ";
            List<Car> CarList = new List<Car>();
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            // cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Car = new Car();
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
                CarList.Add(Car);
            }
            r.Close();
            cn.Close();
            return CarList;
        }
        public List<Car> LoadCarListWithDateAndContorID(string FromDate, string UntillDate, int ContorID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate AND ContorID=@ContorID";
            List<Car> CarList = new List<Car>();
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Car = new Car();
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
                CarList.Add(Car);
            }
            r.Close();
            cn.Close();
            return CarList;
        }

        public List<Car> LoadCarListContorID(int UserID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and UserID=@UserID";
            List<Car> CarList = new List<Car>();
            Car Car = new Car();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Car = new Car();
                Car.CarID = int.Parse(r[0].ToString());
                Car.PersonID = int.Parse(r[1].ToString());
                Car.number = r[2].ToString();
                Car.Type = r[3].ToString();
                Car.Desc = r[4].ToString();
                Car.UserID = int.Parse(r[5].ToString());
                CarList.Add(Car);
            }
            r.Close();
            cn.Close();
            return CarList;
        }

        public bool InsertCar(Car car)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblCar " +
                              " (PersonID,number,Type,[Desc],UserID)" +
                              " VALUES (@PersonID,@number,@Type,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Car Car = new Car();
            Car = car;
            cmd.Parameters.AddWithValue("@CarID", Car.CarID);
            cmd.Parameters.AddWithValue("@PersonID", Car.PersonID);
            cmd.Parameters.AddWithValue("@number", Car.number);
            cmd.Parameters.AddWithValue("@Type", Car.Type);
            cmd.Parameters.AddWithValue("@Desc", Car.Desc);
            cmd.Parameters.AddWithValue("@UserID", Car.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditCar(Car car)
        {
            string SqlStr = "UPDATE tblCar " +
                                 " SET PersonID = @PersonID, number = @number, Type=@Type ,[Desc]=@Desc,UserID=@UserID WHERE CarID=@CarID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Car Car = new Car();
            Car = car;
            cmd.Parameters.AddWithValue("@CarID", Car.CarID);
            cmd.Parameters.AddWithValue("@PersonID", Car.PersonID);
            cmd.Parameters.AddWithValue("@number", Car.number);
            cmd.Parameters.AddWithValue("@Type", Car.Type);
            cmd.Parameters.AddWithValue("@Desc", Car.Desc);
            cmd.Parameters.AddWithValue("@UserID", Car.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteCar(int CarID, int UserID)
        {
            string SqlStr = "UPDATE tblCar SET CarIsDel =1 where CarID=@CarID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Car
    }
}
