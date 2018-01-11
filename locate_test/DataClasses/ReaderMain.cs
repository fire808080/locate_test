using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
	//保存一个reader下的所有信息
	public class ReaderMain
    {
    	//reader基本信息
        public int ReaderID { get; set; }
        public string IPaddress { get; set; }
        public int NumAntennas { get; set; }
		public int iReaderType { get; set; }
		

		//reader下所有天线信息
        public List<LTS.Antenna> antennas = new List<LTS.Antenna>();

        public ReaderMain()
        {

        }
    }
}
