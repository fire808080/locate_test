using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ssms.DataClasses;

namespace ssms
{
    class Macro
    {
        public const string SUCCESS_ADD_SETTING = "success to add setting";
		public const string SUCCESS_UPDATE_SETTING = "success to update setting";
		public const string SUCCESS_UPDATE_PRODUCT = "success to update product";
		public const string ERROR_ADD_SETTING = "error to add setting";
		public const string ERROR_ADD_READERING = "error to add reader";
		public const string ERROR_GET_SETTING_NAME = "error to get setting name with store name";

		//scan item操作步骤宏定义
		public const int SCANITEM_OPR_INIT = 0;
		public const int SCANITEM_OPR_CONNECTING = 1;
		public const int SCANITEM_OPR_CONNECTED = 2;
		public const int SCANITEM_OPR_NOTCONNECT = 3;
		public const int SCANITEM_OPR_STARTING = 4;
		public const int SCANITEM_OPR_STARTED = 5;
		public const int SCANITEM_OPR_NOTSTARTED = 6;
		public const int SCANITEM_OPR_STOP = 7;

		//读写器类型宏定义
		public const int READER_TYPE_READER = 0;
		public const int READER_TYPE_WRITER = 1;
		public const int READER_TYPE_CHECKR = 2;

		//tag状态
		public const int TAG_STATE_ERROR = 0;   //处于该状态下的tag，从产生错误的地方起，不用进行后续的处理
		public const int TAG_STATE_OK = 1;

		//tag写状态
		public const int TAG_WRITE_INIT = 0;   //处于该状态，标识tag没有写成功，是无效tag
		public const int TAG_WRITE_FINISH = 1; //处于该状态，标识tag已写成功
		
		//tag 处理步骤
		public const int TAG_STEP_INIT = 9; //tag开始进入处理阶段 
		public const int TAG_STEP_DONE_WIRTE = 5; //tag进行写操作
		public const int TAG_STEP_DONE_CHECK = 0; //tag进行校验操作 

		//tag 去重状态
		public const int TAG_DEDUPLICATE_READ = 1; //读去重 
		public const int TAG_DEDUPLICATE_WRITE = 2; //写去重 
		public const int TAG_DEDUPLICATE_CHECK = 3; //验去重 

		public const int TAG_NOT_DUPLICATE = 1;
		public const int TAG_IN_DUPLICATE = 0;
    }
}