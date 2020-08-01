using System;
using System.Collections.Generic;
using System.Text;

namespace restaurant.COMMON
{
  public  class Person
    {
        #region Fields
        private int _PersonID;
        private string _Date;
        private string _PersonCode;
        private string _Place;
        private string _Name;
        private string _Family;
        private string _FatherName;
        private string _Nationality;
        private string _PicturePath;
        private string _Passportnumber;
        private string _Endtime;
        private string _Job;
        private string _Starttime;
        private string _Birthday;
        private string _Religion;
        private string _Married;
        private int _Childrennumber;
        private string _Education;
        private string _Skills;
        private string _Experiences;
        private string _Diseases;
        private string _otherDiseases;
        private string _Address1;
        private string _Address2;
        private string _Tel1;
        private string _Tel2;
        private string _Relative1;
        private string _Relative2;
        private string _Telr1;
        private string _Telr2;
        private int _firstSalary;
        private int _userID;
          
        #endregion Fields

        #region Properties

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public int firstSalary
        {
            get { return _firstSalary; }
            set { _firstSalary = value; }
        }
        public string Telr1
        {
            get { return _Telr1; }
            set { _Telr1 = value; }
        }

        public string Telr2
        {
            get { return _Telr2; }
            set { _Telr2 = value; }
        }
        public string Relative1
        {
            get { return _Relative1; }
            set { _Relative1 = value; }
        }

        public string Relative2
        {
            get { return _Relative2; }
            set { _Relative2 = value; }
        }

        public string Tel1
        {
            get { return _Tel1; }
            set { _Tel1 = value; }
        }

        public string Tel2
        {
            get { return _Tel2; }
            set { _Tel2 = value; }
        }

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }

        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        public string otherDiseases
        {
            get { return _otherDiseases; }
            set { _otherDiseases = value; }
        }

        public string Diseases
        {
            get { return _Diseases; }
            set { _Diseases = value; }
        }

        public string Experiences
        {
            get { return _Experiences; }
            set { _Experiences = value; }
        }

        public string Skills
        {
            get { return _Skills; }
            set { _Skills = value; }
        }

        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        public int Childrennumber
        {
            get { return _Childrennumber; }
            set { _Childrennumber = value; }
        }
        public string Married
        {
            get { return _Married; }
            set { _Married = value; }
        }

        public string Religion
        {
            get { return _Religion; }
            set { _Religion = value; }
        }

        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public string Starttime
        {
            get { return _Starttime; }
            set { _Starttime = value; }
        }

        public string Job
        {
            get { return _Job; }
            set { _Job = value; }
        }

        public string Endtime
        {
            get { return _Endtime; }
            set { _Endtime = value; }
        }

        public string Passportnumber
        {
            get { return _Passportnumber; }
            set { _Passportnumber = value; }
        }
        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }
        public string PersonCode
        {
            get { return _PersonCode; }
            set { _PersonCode = value; }
        }

        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }


        public string PicturePath
        {
            get { return _PicturePath; }
            set { _PicturePath = value; }
        }

       

        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }

        public string Family
        {
            get { return _Family; }
            set { _Family = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        #endregion Properties
    }
}
