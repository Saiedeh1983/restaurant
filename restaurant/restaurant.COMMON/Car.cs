using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
  public  class Car
    {
      private int _CarID;
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _Type;
        private string _number;


        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
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



        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }
    }
}
