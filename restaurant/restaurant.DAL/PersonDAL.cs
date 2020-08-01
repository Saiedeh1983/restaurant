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
   public class PersonDAL
    {
        #region Person

        SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
        SqlCommand cmd;
       public Person LoadPerson(int PersonID, int UserID)
        {
            string SqlStr = "select * from tblPerson where PersonIsDel=0 and PersonID=@PersonID and UserID=@UserID";
            Person person = new Person();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                person.PersonID = int.Parse(r[0].ToString());
                person.Date = r[1].ToString();
                person.PersonCode = r[2].ToString();
                person.Place = r[3].ToString();
                person.Name = r[4].ToString();
                person.Family = r[5].ToString();
                person.FatherName = r[6].ToString();
                person.Nationality = r[7].ToString();
                person.PicturePath = r[8].ToString();
                person.Passportnumber = r[9].ToString();
                person.Endtime = r[10].ToString();
                person.Job = r[11].ToString();
                person.Starttime = r[12].ToString();
                person.Birthday = r[13].ToString();
                person.Religion = r[14].ToString();
                person.Married = r[15].ToString();
                person.Childrennumber = int.Parse(r[16].ToString());
                person.Education = r[17].ToString();
                person.Skills = r[18].ToString();
                person.Experiences = r[19].ToString();
                person.Diseases = r[20].ToString();
                person.otherDiseases = r[21].ToString();
                person.Address1 = r[22].ToString();
                person.Address2 = r[23].ToString();
                person.Tel1 = r[24].ToString();
                person.Tel2 = r[25].ToString();
                person.Relative1 = r[26].ToString();
                person.Relative2 = r[27].ToString();
                person.Telr1 = r[28].ToString();
                person.Telr2 = r[29].ToString();
                person.firstSalary = int.Parse(r[30].ToString());
                person.userID = int.Parse(r[31].ToString());
            }
            r.Close();
            cn.Close();
            return person;
        }



       public Person LoadPersonwithnamefamily(string Name, string Family, int UserID)
       {
           string SqlStr = "select * from tblPerson where PersonIsDel=0 and Name=@Name and Family=@Family and UserID=@UserID";
           Person person = new Person();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);
           cmd.Parameters.AddWithValue("@Name", Name);
           cmd.Parameters.AddWithValue("@Family", Family);
           cmd.Parameters.AddWithValue("@UserID", UserID);
           SqlDataReader r = cmd.ExecuteReader();
           if (r.Read())
           {
               person.PersonID = int.Parse(r[0].ToString());
               person.Date = r[1].ToString();
               person.PersonCode = r[2].ToString();
               person.Place = r[3].ToString();
               person.Name = r[4].ToString();
               person.Family = r[5].ToString();
               person.firstSalary = int.Parse(r[30].ToString());
              
           }
           r.Close();
           cn.Close();
           return person;
       }

        public Person LoadPersonWithFamily(string Family,int UserID)
        {
            string SqlStr = "select * from tblPerson where PersonIsDel=0 and Family=@Family and UserID=@UserID";
            Person person = new Person();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Family", Family);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                person.PersonID = int.Parse(r[0].ToString());
                person.Date = r[1].ToString();
                person.PersonCode = r[2].ToString();
                person.Place = r[3].ToString();
                person.Name = r[4].ToString();
                person.Family = r[5].ToString();
                person.FatherName = r[6].ToString();
                person.Nationality = r[7].ToString();
                person.PicturePath = r[8].ToString();
                person.Passportnumber = r[9].ToString();
                person.Endtime = r[10].ToString();
                person.Job = r[11].ToString();
                person.Starttime = r[12].ToString();
                person.Birthday = r[13].ToString();
                person.Religion = r[14].ToString();
                person.Married = r[15].ToString();
                person.Childrennumber = int.Parse(r[16].ToString());
                person.Education = r[17].ToString();
                person.Skills = r[18].ToString();
                person.Experiences = r[19].ToString();
                person.Diseases = r[20].ToString();
                person.otherDiseases = r[21].ToString();
                person.Address1 = r[22].ToString();
                person.Address2 = r[23].ToString();
                person.Tel1 = r[24].ToString();
                person.Tel2 = r[25].ToString();
                person.Relative1 = r[26].ToString();
                person.Relative2 = r[27].ToString();
                person.Telr1 = r[28].ToString();
                person.Telr2 = r[29].ToString();
                person.firstSalary = int.Parse(r[30].ToString());
                person.userID= int.Parse(r[31].ToString());
            }
            r.Close();
            cn.Close();
            return person;
        }

        public DataTable LoadPersonListFORExcel(int UserID)
        {
            string SqlStr = "select Date,PersonCode,Place,Name,Family,FatherName,Nationality,PicturePath,Passportnumber,Endtime,Starttime,Job,Birthday,Religion,Married,Childrennumber,Education,Skills,Experiences,Diseases,otherDiseases,Address1,Address2,Tel1,Tel2,Relative1,Relative2,firstSalary from tblPerson where (PersonIsDel=0) and UserID=@UserID";
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

       public DataTable LoadPersonList(int UserID)
        {
            string SqlStr = "select * from tblPerson where (PersonIsDel=0) and UserID=@UserID";
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
     

       public DataTable LoadPersonListwithnamefamily(string Name, string Family, int UserID)
       {
           string SqlStr = "select * from tblPerson where (PersonIsDel=0) and Name=@Name and Family=@Family and UserID=@UserID";
           SqlCommand cmd = new SqlCommand(SqlStr, cn);
           cmd.Parameters.AddWithValue("@Name", Name);
           cmd.Parameters.AddWithValue("@Family", Family);
           cmd.Parameters.AddWithValue("@UserID", UserID);
           SqlDataAdapter Da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           Da.Fill(dt);
           cn.Close();
           return dt;
       }

       public List<Person> LoadPersonList2(int UserID)
        {
            string SqlStr = "select * from tblPerson where (PersonIsDel=0) and UserID=@UserID";
            List<Person> personList = new List<Person>();
            Person person = new Person();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person = new Person();
                person.PersonID = int.Parse(r[0].ToString());
                person.Date = r[1].ToString();
                person.PersonCode = r[2].ToString();
                person.Place = r[3].ToString();
                person.Name = r[4].ToString();
                person.Family = r[5].ToString();
                person.FatherName = r[6].ToString();
                person.Nationality = r[7].ToString();
                person.PicturePath = r[8].ToString();
                person.Passportnumber = r[9].ToString();
                person.Endtime = r[10].ToString();
                person.Job = r[11].ToString();
                person.Starttime = r[12].ToString();
                person.Birthday = r[13].ToString();
                person.Religion = r[14].ToString();
                person.Married = r[15].ToString();
                person.Childrennumber = int.Parse(r[16].ToString());
                person.Education = r[17].ToString();
                person.Skills = r[18].ToString();
                person.Experiences = r[19].ToString();
                person.Diseases = r[20].ToString();
                person.otherDiseases = r[21].ToString();
                person.Address1 = r[22].ToString();
                person.Address2 = r[23].ToString();
                person.Tel1 = r[24].ToString();
                person.Tel2 = r[25].ToString();
                person.Relative1 = r[26].ToString();
                person.Relative2 = r[27].ToString();
                person.Telr1 = r[28].ToString();
                person.Telr2 = r[29].ToString();
                person.firstSalary = int.Parse(r[30].ToString());
                person.userID = int.Parse(r[31].ToString());
                personList.Add(person);
            }
            r.Close();
            cn.Close();
            return personList;
        }

       public List<Person> LoadPersonListWithoutOwner(int PersonID,int UserID)
       {
           string SqlStr = "select * from tblPerson where (PersonIsDel=0) and UserID=@UserID AND PersonID<>@PersonID";
           List<Person> personList = new List<Person>();
           Person person = new Person();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           cmd = new SqlCommand(SqlStr, cn);
           cmd.Parameters.AddWithValue("@UserID", UserID);
           cmd.Parameters.AddWithValue("@PersonID", PersonID);
           SqlDataReader r = cmd.ExecuteReader();
           while (r.Read())
           {
               person = new Person();
               person.PersonID = int.Parse(r[0].ToString());
               person.Date = r[1].ToString();
               person.PersonCode = r[2].ToString();
               person.Place = r[3].ToString();
               person.Name = r[4].ToString();
               person.Family = r[5].ToString();
               person.FatherName = r[6].ToString();
               person.Nationality = r[7].ToString();
               person.PicturePath = r[8].ToString();
               person.Passportnumber = r[9].ToString();
               person.Endtime = r[10].ToString();
               person.Job = r[11].ToString();
               person.Starttime = r[12].ToString();
               person.Birthday = r[13].ToString();
               person.Religion = r[14].ToString();
               person.Married = r[15].ToString();
               person.Childrennumber = int.Parse(r[16].ToString());
               person.Education = r[17].ToString();
               person.Skills = r[18].ToString();
               person.Experiences = r[19].ToString();
               person.Diseases = r[20].ToString();
               person.otherDiseases = r[21].ToString();
               person.Address1 = r[22].ToString();
               person.Address2 = r[23].ToString();
               person.Tel1 = r[24].ToString();
               person.Tel2 = r[25].ToString();
               person.Relative1 = r[26].ToString();
               person.Relative2 = r[27].ToString();
               person.Telr1 = r[28].ToString();
               person.Telr2 = r[29].ToString();
               person.firstSalary = int.Parse(r[30].ToString());
               person.userID = int.Parse(r[31].ToString());
               personList.Add(person);
           }
           r.Close();
           cn.Close();
           return personList;
       }


       public List<Person> LoadPersonListWithName(string Name, string Family, int UserID)
        {
            string SqlStr = "select * from tblPerson where (PersonIsDel=0) and Name=@Name and Family=@Family and UserID=@UserID";
            List<Person> personList = new List<Person>();
            Person person = new Person();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Family", Family);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@userID", UserID);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person = new Person();
                person.PersonID = int.Parse(r[0].ToString());
                person.Date = r[1].ToString();
                person.PersonCode = r[2].ToString();
                person.Place = r[3].ToString();
                person.Name = r[4].ToString();
                person.Family = r[5].ToString();
                person.FatherName = r[6].ToString();
                person.Nationality = r[7].ToString();
                person.PicturePath = r[8].ToString();
                person.Passportnumber = r[9].ToString();
                person.Endtime = r[10].ToString();
                person.Job = r[11].ToString();
                person.Starttime = r[12].ToString();
                person.Birthday = r[13].ToString();
                person.Religion = r[14].ToString();
                person.Married = r[15].ToString();
                person.Childrennumber = int.Parse(r[16].ToString());
                person.Education = r[17].ToString();
                person.Skills = r[18].ToString();
                person.Experiences = r[19].ToString();
                person.Diseases = r[20].ToString();
                person.otherDiseases = r[21].ToString();
                person.Address1 = r[22].ToString();
                person.Address2 = r[23].ToString();
                person.Tel1 = r[24].ToString();
                person.Tel2 = r[25].ToString();
                person.Relative1 = r[26].ToString();
                person.Relative2 = r[27].ToString();
                person.Telr1 = r[28].ToString();
                person.Telr2 = r[29].ToString();
                person.firstSalary = int.Parse(r[30].ToString());
                person.userID = int.Parse(r[31].ToString());
                personList.Add(person);
            }
            r.Close();
            cn.Close();
            return personList;
        }

       


        public bool InsertPerson(Person Person)
        {
            //try
            //{
            string SqlStr = "Insert into tblPerson " +
                              " (Date,PersonCode,Place,Name,Family,FatherName,Nationality,PicturePath,Passportnumber,Endtime,Job,Starttime,Birthday,Religion,Married,Childrennumber,Education,Skills,Experiences,Diseases,otherDiseases,Address1,Address2,Tel1,Tel2,Relative1,Relative2,Telr1,Telr2,firstSalary,userID)" +
                              " VALUES (@Date,@PersonCode,@Place,@Name,@Family,@FatherName,@Nationality,@PicturePath,@Passportnumber,@Endtime,@Job,@Starttime,@Birthday,@Religion,@Married,@Childrennumber,@Education,@Skills,@Experiences,@Diseases,@otherDiseases,@Address1,@Address2,@Tel1,@Tel2,@Relative1,@Relative2,@Telr1,@Telr2,@firstSalary,@userID)";
          
            
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Person person = new Person();
            person = Person;
            
            cmd.Parameters.AddWithValue("@Date", person.Date);
            cmd.Parameters.AddWithValue("@PersonCode", person.PersonCode);
            cmd.Parameters.AddWithValue("@Place", person.Place);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Family", person.Family);
            cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
            cmd.Parameters.AddWithValue("@Nationality", person.Nationality);
            cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
            cmd.Parameters.AddWithValue("@Passportnumber", person.Passportnumber);
            cmd.Parameters.AddWithValue("@Endtime", person.Endtime);
            cmd.Parameters.AddWithValue("@Job", person.Job);
            cmd.Parameters.AddWithValue("@Starttime", person.Starttime);
            cmd.Parameters.AddWithValue("@Birthday", person.Birthday);
            cmd.Parameters.AddWithValue("@Religion", person.Religion);
            cmd.Parameters.AddWithValue("@Married", person.Married);
            cmd.Parameters.AddWithValue("@Childrennumber", person.Childrennumber);
            cmd.Parameters.AddWithValue("@Education", person.Education);
            cmd.Parameters.AddWithValue("@Skills", person.Skills);
            cmd.Parameters.AddWithValue("@Experiences", person.Experiences);
            cmd.Parameters.AddWithValue("@Diseases", person.Diseases);
            cmd.Parameters.AddWithValue("@otherDiseases", person.otherDiseases);
            cmd.Parameters.AddWithValue("@Address1", person.Address1);
            cmd.Parameters.AddWithValue("@Address2", person.Address2);
            cmd.Parameters.AddWithValue("@Tel1", person.Tel1);
            cmd.Parameters.AddWithValue("@Tel2", person.Tel2);
            cmd.Parameters.AddWithValue("@Relative1", person.Relative1);
            cmd.Parameters.AddWithValue("@Relative2", person.Relative2);
            cmd.Parameters.AddWithValue("@Telr1", person.Telr1);
            cmd.Parameters.AddWithValue("@Telr2", person.Telr2);
            cmd.Parameters.AddWithValue("@firstSalary", person.firstSalary);
            cmd.Parameters.AddWithValue("@userID", person.userID);
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;
            //}
            //catch { return false; }
        }

        public void EditPerson(Person Person)
        {
            string SqlStr = "UPDATE tblPerson " +
                                 " SET Date = @Date, PersonCode = @PersonCode, Place=@Place ,Name=@Name,Family=@Family,FatherName=@FatherName,Nationality=@Nationality,PicturePath=@PicturePath                                ,Passportnumber=Passportnumber,Endtime=Endtime,Job=@Job,Starttime=@Starttime,Birthday=@Birthday,Religion = Religion,Married = @Married,Childrennumber = @Childrennumber,Education = @Education,Skills = @Skills,                                 Experiences = @Experiences,Diseases = @Diseases,otherDiseases = @otherDiseases,Address1 = @Address1,Address2 = @Address2,Tel1 = @Tel1,Tel2 = @Tel2,Relative1 = @Relative1,Relative2 = @Relative2,Telr1 = @Telr1,Telr2 = @Telr2,firstSalary = @firstSalary,userID = @userID where PersonID=@PersonID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            Person person = new Person();
            person = Person;
            cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
            cmd.Parameters.AddWithValue("@Date", person.Date);
            cmd.Parameters.AddWithValue("@PersonCode", person.PersonCode);
            cmd.Parameters.AddWithValue("@Place", person.Place);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Family", person.Family);
            cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
            cmd.Parameters.AddWithValue("@Nationality", person.Nationality);
            cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
            cmd.Parameters.AddWithValue("@Passportnumber", person.Passportnumber);
            cmd.Parameters.AddWithValue("@Endtime", person.Endtime);
            cmd.Parameters.AddWithValue("@Job", person.Job);
            cmd.Parameters.AddWithValue("@Starttime", person.Starttime);
            cmd.Parameters.AddWithValue("@Birthday", person.Birthday);
            cmd.Parameters.AddWithValue("@Religion", person.Religion);
            cmd.Parameters.AddWithValue("@Married", person.Married);
            cmd.Parameters.AddWithValue("@Childrennumber", person.Childrennumber);
            cmd.Parameters.AddWithValue("@Education", person.Education);
            cmd.Parameters.AddWithValue("@Skills", person.Skills);
            cmd.Parameters.AddWithValue("@Experiences", person.Experiences);
            cmd.Parameters.AddWithValue("@Diseases", person.Diseases);
            cmd.Parameters.AddWithValue("@otherDiseases", person.otherDiseases);
            cmd.Parameters.AddWithValue("@Address1", person.Address1);
            cmd.Parameters.AddWithValue("@Address2", person.Address2);
            cmd.Parameters.AddWithValue("@Tel1", person.Tel1);
            cmd.Parameters.AddWithValue("@Tel2", person.Tel2);
            cmd.Parameters.AddWithValue("@Relative1", person.Relative1);
            cmd.Parameters.AddWithValue("@Relative2", person.Relative2);
            cmd.Parameters.AddWithValue("@Telr1", person.Telr1);
            cmd.Parameters.AddWithValue("@Telr2", person.Telr2);
            cmd.Parameters.AddWithValue("@firstSalary", person.firstSalary);
            cmd.Parameters.AddWithValue("@userID", person.userID);
           
            cmd.ExecuteNonQuery();
            cn.Close();
        }

       public void DeletePerson(long PersonID, int UserID)
        {
            string SqlStr = "UPDATE tblPerson SET PersonIsDel =1 where PersonID=@PersonID and userID=@userID";
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@userID", UserID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        #endregion Person
    }
}
