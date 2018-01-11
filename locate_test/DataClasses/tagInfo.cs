using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;
using System.ComponentModel;
using System.Collections;
using System.Threading;

using ssms.Util;

namespace ssms.DataClasses
{
    public class TagInfo
    {
        public string sEpc { get; set; }
		public string sEpcHx { get; set; }
		
		public string sTid { get; set; }
		public string sTidHx { get; set; }
		
        public int AntennaNo { get; set; }
        public string ReaderHostName { get; set; }

		public int iTagState{ get; set; } //标识tag在整个处理过程中的状态，如果状态不好，则标志tag无效，不需做后续处理
		public int iTagWState{ get; set; } //标识tag写操作是否成功完成
		
		public ushort usPcBits{ get; set; }
		
		public int iTagStep{ get; set; }
		
        public TagInfo()
        {

        }


    }

	public class DeduplicateNode
    {		
		public string sTid { get; set; }		
		public int iTagStep{ get; set; }
		
        public DeduplicateNode()
        {

        }


    }
		

}

