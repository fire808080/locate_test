using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DataClasses的数据类型的定义，用来接收业务来的数据
namespace ssms.DataClasses
{
    class antenna
    {
        //public int antennaID { get; set; }
        public int antennaNumber { get; set; }
        public decimal txPower { get; set; }
        public decimal rxPower { get; set; }
		public int AntennaID { get; set; }
		public int ReaderID { get; set; }

        public antenna()
        {

        }
    }
}
