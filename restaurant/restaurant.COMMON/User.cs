using System;
using System.Collections.Generic;
using System.Text;

namespace restaurant.COMMON
{
   public class User
    {
        private int _UserID;
        private string _UserName;
        private string _Password;
        private string _Desc;
        private string _Date;
        private int _Question;
        private string _Answer;
        private int _Admin;
        private string _SequrityStr;

       public string SequrityStr
        {
            get { return _SequrityStr; }
            set { _SequrityStr = value; }
        }

        public int Admin
        {
            get { return _Admin; }
            set { _Admin = value; }
        }

        public string Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }

        public int Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }


        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}
