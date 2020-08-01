using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
   public class Advance
    {
       private int _AdvanceID;
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _Date;
        private int _amount;
        private string _cause;

        public string cause
        {
            get { return _cause; }
            set { _cause = value; }
        }

        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
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



        public int AdvanceID
        {
            get { return _AdvanceID; }
            set { _AdvanceID = value; }
        }
    }
}
