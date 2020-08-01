using System;
using System.Collections.Generic;
using System.Text;

namespace restaurant.COMMON
{
   public class Increasesalary
    {
       private int _IncreasesalaryID;       
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _Date;
        private int _lastIncrease;
        private int _lastsalary;

        public int lastsalary
        {
            get { return _lastsalary; }
            set { _lastsalary = value; }
        }
       
       public int lastIncrease
        {
            get { return _lastIncrease; }
            set { _lastIncrease = value; }
        }
       
       public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

       

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

      

       public int IncreasesalaryID
        {
            get { return _IncreasesalaryID; }
            set { _IncreasesalaryID = value; }
        }
    }
}
