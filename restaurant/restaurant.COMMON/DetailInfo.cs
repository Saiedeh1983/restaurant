using System;
using System.Collections.Generic;
using System.Text;


namespace restaurant.COMMON
{
  public  class DetailInfo
  {
      #region Fields
      private int _DetailInfoID;
        private string _DetailInfoTitle;
        private int _BaseInfoID;
        private string _DetailInfoDesc;
        #endregion Fields

        #region Properties
        public string DetailInfoDesc
        {
            get { return _DetailInfoDesc; }
            set { _DetailInfoDesc = value; }
        }

        public int BaseInfoID
        {
            get { return _BaseInfoID; }
            set { _BaseInfoID = value; }
        }

        public string DetailInfoTitle
        {
            get { return _DetailInfoTitle; }
            set { _DetailInfoTitle = value; }
        }

        public int DetailInfoID
        {
            get { return _DetailInfoID; }
            set { _DetailInfoID = value; }
        }
        #endregion Properties
    }
}
