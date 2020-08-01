using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
   public class Rent
    {
       private int _RentID;
       private int _Price;
        private string _Desc;
        private int _UserID;
        private string _Date;
        private string _expireDate;
        private string _Address;
        private string _Name;
        private string _Family;
        private string _Type;
        private string _ContractNumber;


        public string ContractNumber
        {
            get { return _ContractNumber; }
            set { _ContractNumber = value; }
        }


        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
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
       
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
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
        

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }



        public int RentID
        {
            get { return _RentID; }
            set { _RentID = value; }
        }
    }
}
