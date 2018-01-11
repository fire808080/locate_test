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
    //统计信息
    public class StatInfo
    {
		public int iReadCnt { get; set; }
		public int iWriteCnt { get; set; }
		public int iCheckCnt { get; set; }
		
		public int iDuplicateReadCnt { get; set; }
		public int iDuplicateWriteCnt { get; set; }
		public int iDuplicateCheckCnt { get; set; }

		public int iErrorTagInRead{get; set;}
		public int iErrorTagInWrite{get; set;}
		public int iErrorTagInCheck{get; set;}

		public int iErrorInRead{get; set;}
		public int iErrorInWrite{get; set;}
		public int iErrorInCheck{get; set;}
		
		public StatInfo()
		{
			iReadCnt = iWriteCnt = iCheckCnt = 0;
			iDuplicateReadCnt = iDuplicateWriteCnt = iDuplicateCheckCnt = 0;
			iErrorTagInRead = iErrorTagInWrite = iErrorTagInCheck = 0;
			iErrorInRead = iErrorInWrite= iErrorInCheck = 0;
		}
	}

}



