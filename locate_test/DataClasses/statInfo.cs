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
    	/*正确读到的标签数*/
		public int iReadCnt { get; set; }
		public int iWriteCnt { get; set; }
		public int iWriteConfirmCnt { get; set; }
		public int iCheckCnt { get; set; }

		/*统计重复读入的标签*/
		public int iDuplicateReadCnt { get; set; }
		public int iDuplicateWriteCnt { get; set; }
		public int iDuplicateWriteConfirmCnt { get; set; }
		public int iDuplicateCheckCnt { get; set; }

		/*统计错误的标签*/
		public int iErrorTagInRead{get; set;}
		public int iErrorTagInWrite{get; set;}
		public int iErrorTagInCheck{get; set;}

		//统计系统处理错误
		public int iErrorInRead{get; set;}
		public int iErrorInWrite{get; set;}
		public int iErrorInWriteConfrim{get; set;}
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



