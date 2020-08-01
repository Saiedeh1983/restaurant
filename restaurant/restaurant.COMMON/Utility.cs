using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
  public class Utility
    {
      private int _UtilityID;
        private string _Desc;
        private int _RentID;
        private int _UserID;
        private string _UntilDate;
        private int _amount;
        private string _TypeOfBill;
        private string _FromDate;


        public string UntilDate
        {
            get { return _UntilDate; }
            set { _UntilDate = value; }
        }


        public string TypeOfBill
        {
            get { return _TypeOfBill; }
            set { _TypeOfBill = value; }
        }

        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public int RentID
        {
            get { return _RentID; }
            set { _RentID = value; }
        }



        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }



        public int UtilityID
        {
            get { return _UtilityID; }
            set { _UtilityID = value; }
        }
    }
}
