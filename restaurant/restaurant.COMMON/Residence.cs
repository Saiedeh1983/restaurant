using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
   public class Residence
    {
       private int _ResidenceID;
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _expireDate;
        private string _number;


        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string expireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
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



        public int ResidenceID
        {
            get { return _ResidenceID; }
            set { _ResidenceID = value; }
        }
    }
}
