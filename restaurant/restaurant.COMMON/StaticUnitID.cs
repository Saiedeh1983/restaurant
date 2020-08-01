using System;
using System.Collections.Generic;
using System.Text;
using restaurant.COMMON;

namespace restaurant.COMMON
{
public static class StaticUnitID
    {
        public static int UnitID;
        private static int FloorNum;
        private static int checkfloor;
        private static int UserID;
        private static int Selectednode;
        private static int _UnitID;
        private static string _UserName;
        private static int _Admin;
        private static int _SequrityStr;
        private static int _Question;
        private static string _Answer;

        public static string Answer
        {
            get { return StaticUnitID._Answer; }
            set { StaticUnitID._Answer = value; }
        }

        public static int Question
        {
            get { return StaticUnitID._Question; }
            set { StaticUnitID._Question = value; }
        }

        public static int SequrityStr
        {
            get { return StaticUnitID._SequrityStr; }
            set { StaticUnitID._SequrityStr = value; }
        }

        public static int Admin
        {
            get { return StaticUnitID._Admin; }
            set { StaticUnitID._Admin = value; }
        }

        public static string UserName
        {
            get { return StaticUnitID._UserName; }
            set { StaticUnitID._UserName = value; }
        }

        public static int UnitID2
        {
            get { return StaticUnitID._UnitID; }
            set { StaticUnitID._UnitID = value; }
        }

        public static int Selectednode1
        {
            get { return StaticUnitID.Selectednode; }
            set { StaticUnitID.Selectednode = value; }
        }

        public static int UserID1
        {
            get { return StaticUnitID.UserID; }
            set { StaticUnitID.UserID = value; }
        }

        public static int Checkfloor
        {
            get { return StaticUnitID.checkfloor; }
            set { StaticUnitID.checkfloor = value; }
        }

        public static int FloorNum1
        {
            get { return StaticUnitID.FloorNum; }
            set { StaticUnitID.FloorNum = value; }
        }

        public static int UnitID1
        {
            get { return StaticUnitID.UnitID; }
            set { StaticUnitID.UnitID = value; }
        }
    }
}
