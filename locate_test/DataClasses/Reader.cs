﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    class Reader
    {
        //public int readerID { get; set; }
        public string IPaddress { get; set; }
        public int numAntennas { get; set; }
		public int iReaderType { get; set; }
        public double rxPower { get; set; }

		public int ReaderID { get; set; }
		public int SettingsID{ get; set; }
        public List<antenna> antenna = new List<antenna>();

        public Reader()
        {

        }
    }
}
