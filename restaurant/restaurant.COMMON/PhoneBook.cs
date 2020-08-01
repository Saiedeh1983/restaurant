using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant.COMMON
{
   public class PhoneBook
    {
       private int _PhoneBookID;
        private string _Desc;
        private int _PersonID;
        private int _UserID;
        private string _Address;
        private string _Tel;
        private string _Name;


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
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



        public int PhoneBookID
        {
            get { return _PhoneBookID; }
            set { _PhoneBookID = value; }
        }
    }
}
