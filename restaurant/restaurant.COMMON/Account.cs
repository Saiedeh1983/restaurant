using System;
using System.Collections.Generic;
using System.Text;

namespace restaurant.COMMON
{
   public class Account
    {
        private int _AccountID;
        private string _AccountNum;
        private int _BankName;
        private int _AccountType;
        private string _Description;
        private int _UserID;
        private string _Date;
        private int _CodePart;
        private string _NamePart;

        public string NamePart
        {
            get { return _NamePart; }
            set { _NamePart = value; }
        }

        public int CodePart
        {
            get { return _CodePart; }
            set { _CodePart = value; }
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

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public int AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }

        public int BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }

        public string AccountNum
        {
            get { return _AccountNum; }
            set { _AccountNum = value; }
        }

        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }
    }
}
