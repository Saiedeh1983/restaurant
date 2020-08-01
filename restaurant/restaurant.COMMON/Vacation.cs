using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
   public class Vacation
    {
       private int _VacationID;
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _Date;
        private int _amount;
        private string _ExpireDate;

        public string ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
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



        public int VacationID
        {
            get { return _VacationID; }
            set { _VacationID = value; }
        }
    }
}
