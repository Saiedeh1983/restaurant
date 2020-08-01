

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
    public class RentDAL
    {
        #region Rent

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
        public Rent LoadRent(int RentID, int UserID)
        {
            string SqlStr = "select * from tblRent where RentIsDel=0 and RentID=@RentID and UserID=@UserID";
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
            }
            r.Close();
            cn.Close();
            return Rent;
        }

        public List<Rent> LoadRentListmax(int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and UserID=@UserID ";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Rent = new Rent();
                Rent.RentID = int.Parse(r2[0].ToString());
                Rent.ContractNumber = r2[1].ToString();
                Rent.Price = int.Parse(r2[2].ToString());
                Rent.Type = r2[3].ToString();
                Rent.Date = r2[4].ToString();
                Rent.expireDate = r2[5].ToString();
                Rent.Name = r2[6].ToString();
                Rent.Family = r2[7].ToString();
                Rent.Address = r2[8].ToString();
                Rent.Desc = r2[9].ToString();
                Rent.UserID = int.Parse(r2[10].ToString());

                RentList.Add(Rent);
            }
            r2.Close();
            cn.Close();
            return RentList;
        }

      
        public List<Rent> LoadRentListWithDistinctPrice(int UserID)
        {
            string SqlStr = "select distinct Price from tblRent where (RentIsDel=0) and UserID=@UserID ";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r2;


            r2 = cmd.ExecuteReader();
            while (r2.Read())
            {
                Rent = new Rent();
                Rent.Price = int.Parse(r2[0].ToString());

                RentList.Add(Rent);
            }
            r2.Close();
            cn.Close();
            return RentList;
        }

     
        public Rent LoadRentWithTitle(int PersonID)
        {
            string SqlStr = "select * from tblRent where RentIsDel=0 and PersonID=@PersonID";
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
            }
            r.Close();
            cn.Close();
            return Rent;
        }
        public Rent LoadRentWithContractNumber(string ContractNumber, int UserID)
        {
            string SqlStr = "select * from tblRent where RentIsDel=0 and ContractNumber=@ContractNumber and UserID=@UserID";
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContractNumber", ContractNumber);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
            }
            r.Close();
            cn.Close();
            return Rent;
        }

        public List<Rent> LoadRentList2()
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0)";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Rent = new Rent();
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
                RentList.Add(Rent);
            }
            r.Close();
            cn.Close();
            return RentList;
        }

        public DataTable LoadRentListFORExcel(int UserID)
        {
            string SqlStr = "select ContractNumber,Price,Type,Date,expireDate,Name,Family,Address,[Desc] from tblRent where (RentIsDel=0) and UserID=@UserID";
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
        public DataTable LoadRentListwithContractNumber(string ContractNumber, int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and UserID=@UserID and ContractNumber=@ContractNumber";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@ContractNumber", ContractNumber);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }
        public DataTable LoadRentList(int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and UserID=@UserID ";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);;
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            Da.Fill(dt);
            cn.Close();
            return dt;
        }


    //    public DataTable LoadRentList(int PersonID)
     //   {
   //         string SqlStr = "select F.RentID,tblPerson.Name,tblPerson.Family,F.number,F.expireDate,F.PersonID,F.[Desc],F.UserID,F.RentIsDel from tblRent as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.RentIsDel=0) and F.PersonID=@PersonID";
    //        SqlCommand cmd = new SqlCommand(SqlStr, cn);
    //        cmd.Parameters.AddWithValue("@PersonID", PersonID);
    //        SqlDataAdapter Da = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
     //       if (cn.State == ConnectionState.Closed)
     //           cn.Open();
      //      Da.Fill(dt);
     //       cn.Close();
     //       return dt;
     //   }

        public int accountinglastsalary(string ContractNumber, string Date)
        {
            string SqlStr = "select (RentID) AS From tblRent Where RentIsDel=0";
            // string SqlStr = "select F.RentID,tblPerson.Name,tblPerson.Family,F.lastIncrease,F.Date,F.lastsalary,F.PersonID,F.[Desc],F.UserID,F.RentIsDel from tblRent as F INNER JOIN tblPerson on F.PersonID=tblPerson.PersonID where (F.RentIsDel=0)";
            SqlCommand cmd = new SqlCommand(SqlStr, cn);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            int lastsalary = 0;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            //  Da.Fill(dt);
            cn.Close();
            return lastsalary;
        }

        public Rent LoadRentWithNameANDFamily(string Name, string Family, int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and Name=@Name and Family=@Family and UserID=@UserID ";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Family", Family);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // while (r.Read())
            // {
            //Rent = new Rent();
            Rent.RentID = int.Parse(r[0].ToString());
            Rent.Price = int.Parse(r[1].ToString());
            Rent.Type = r[2].ToString();
            Rent.Date = r[3].ToString();
            Rent.expireDate = r[4].ToString();
            Rent.Name = r[5].ToString();
            Rent.Family = r[6].ToString();
            Rent.Address = r[7].ToString();
            Rent.Desc = r[8].ToString();
            Rent.UserID = int.Parse(r[9].ToString());
            //RentList.Add(Rent);
            // }
            r.Close();
            cn.Close();
            return Rent;
        }

        public List<Rent> LoadRentListWithType(int Type)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and Type=@Type ";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Type", Type);
            // cmd.Parameters.AddWithValue("@RentID", RentID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Rent = new Rent();
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
                RentList.Add(Rent);
            }
            r.Close();
            cn.Close();
            return RentList;
        }
        public List<Rent> LoadRentListWithDateAndexpireDate(string Date, string expireDate, int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and Date=@Date and expireDate=@expireDate AND UserID=@UserID";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@expireDate", expireDate);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Rent = new Rent();
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
                RentList.Add(Rent);
            }
            r.Close();
            cn.Close();
            return RentList;
        }

        public List<Rent> LoadRentListContorID(int UserID)
        {
            string SqlStr = "select * from tblRent where (RentIsDel=0) and UserID=@UserID";
            List<Rent> RentList = new List<Rent>();
            Rent Rent = new Rent();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Rent = new Rent();
                Rent.RentID = int.Parse(r[0].ToString());
                Rent.ContractNumber = r[1].ToString();
                Rent.Price = int.Parse(r[2].ToString());
                Rent.Type = r[3].ToString();
                Rent.Date = r[4].ToString();
                Rent.expireDate = r[5].ToString();
                Rent.Name = r[6].ToString();
                Rent.Family = r[7].ToString();
                Rent.Address = r[8].ToString();
                Rent.Desc = r[9].ToString();
                Rent.UserID = int.Parse(r[10].ToString());
                RentList.Add(Rent);
            }
            r.Close();
            cn.Close();
            return RentList;
        }
         
        public bool InsertRent(Rent rent)
        {
            //  Int32 LastID = 0;
            //try
            //{
            string SqlStr = "Insert into tblRent " +
                              " (ContractNumber,Price,Type,Date,expireDate,Name,Family,Address,[Desc],UserID)" +
                              " VALUES (@ContractNumber,@Price,@Type,@Date,@expireDate,@Name,@Family,@Address,@Desc,@UserID)";
            //"SELECT SCOPE_IDENTITY() AS LastID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Rent Rent = new Rent();
            Rent = rent;
            cmd.Parameters.AddWithValue("@RentID", Rent.RentID);
            cmd.Parameters.AddWithValue("@ContractNumber", Rent.ContractNumber);
            cmd.Parameters.AddWithValue("@Price", Rent.Price);
            cmd.Parameters.AddWithValue("@Type", Rent.Type);
            cmd.Parameters.AddWithValue("@Date", Rent.Date);
            cmd.Parameters.AddWithValue("@expireDate", Rent.expireDate);
            cmd.Parameters.AddWithValue("@Name", Rent.Name);
            cmd.Parameters.AddWithValue("@Family", Rent.Family);
            cmd.Parameters.AddWithValue("@Address", Rent.Address);
            cmd.Parameters.AddWithValue("@Desc", Rent.Desc);
            cmd.Parameters.AddWithValue("@UserID", Rent.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;

        }

        public void EditRent(Rent rent)
        {
            string SqlStr = "UPDATE tblRent " +
                                 " SET ContractNumber=@ContractNumber, Price = @Price, Type = @Type, Date=@Date, expireDate=@expireDate, Name=@Name, Family=@Family, Address=@Address ,[Desc]=@Desc,UserID=@UserID WHERE RentID=@RentID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Rent Rent = new Rent();
            Rent = rent;
            cmd.Parameters.AddWithValue("@RentID", Rent.RentID);
            cmd.Parameters.AddWithValue("@ContractNumber", Rent.ContractNumber);
            cmd.Parameters.AddWithValue("@Price", Rent.Price);
            cmd.Parameters.AddWithValue("@Type", Rent.Type);
            cmd.Parameters.AddWithValue("@Date", Rent.Date);
            cmd.Parameters.AddWithValue("@expireDate", Rent.expireDate);
            cmd.Parameters.AddWithValue("@Name", Rent.Name);
            cmd.Parameters.AddWithValue("@Family", Rent.Family);
            cmd.Parameters.AddWithValue("@Address", Rent.Address);
            cmd.Parameters.AddWithValue("@Desc", Rent.Desc);
            cmd.Parameters.AddWithValue("@UserID", Rent.UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteRent(int RentID, int UserID)
        {
            string SqlStr = "UPDATE tblRent SET RentIsDel =1 where RentID=@RentID and UserID=@UserID ";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@RentID", RentID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Rent
    }
}
