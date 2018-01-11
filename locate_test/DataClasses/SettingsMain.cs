using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
	//用来保存一个setting的所有信息
    public class SettingsMain
    {
       	//保存setting信息
        public int SettingsID { get; set; }
        public string SettingsName { get; set; }
        public bool SettingsSelect { get; set; }

		//保存store信息
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }

		//保存对应setting下reader的信息
        public List<ReaderMain> Readers = new List<ReaderMain>();

        public SettingsMain()
        {
            
        }

        //计算reader下有多少个天线
        public int TotalAmountAntennas()
        {
            int result = 0;
            for(int x = 0; x < Readers.Count; x++)
            {
                result = result + Readers[x].NumAntennas;
            }
            return result;
        }
    }
}
