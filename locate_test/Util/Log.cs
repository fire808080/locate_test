using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

   namespace ssms.Util
   {

   /// <summary>
    /// 日志类
    /// </summary>
    public class Log
    {		
        //日志文件所在路径
        private static string logPath = string.Empty;
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                   logPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                return logPath;
            }
            set { logPath = value; }
        }
		
        //日志前缀说明信息
        private static string logFielPrefix = string.Empty;
        /// <summary>
        /// 日志文件前缀
        /// </summary>
        public static string LogFielPrefix
        {
        	get
            {
                if (logFielPrefix == string.Empty)
                {
                   logFielPrefix = "rfid";
                }
                return logFielPrefix;
            }
						
            
            set { logFielPrefix = value; }
        }
		
        /// <summary>
        /// 写日志
        /// <param name="logType">日志类型</param>
        /// <param name="msg">日志内容</param> 
        /// </summary>
        public static void WriteLog(string logType, string msg, 
			string memberName ,
			string sourceFilePath ,
			int sourceLineNumber)
        {
        	System.IO.StreamWriter sw=null;

            try
            {
　　　　			//同一天同一类日志以追加形式保存
                sw = System.IO.File.AppendText(
                    LogPath + LogFielPrefix + "_" +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " " + sourceFilePath.ToString() + " " + memberName.ToString() + " " + sourceLineNumber.ToString() + " " + logType + ":" + msg);

				if (logType.Equals(LogType.Error.ToString()))
				{
					//MessageBox.Show(msg);
				}
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("TraceLog Error:" + ex.Message.ToString());
            }
			
            finally
            {
                sw.Close();
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(LogType logType, string msg,
        	[CallerMemberName] string memberName = "",
			[CallerFilePath] string sourceFilePath = "",
			[CallerLineNumber] int sourceLineNumber = 0)
        {
        	string filename = System.IO.Path.GetFileName(sourceFilePath);
            WriteLog(logType.ToString(), msg, memberName, filename, sourceLineNumber);
        }

		public static void WriteLog(LogType logType, StringBuilder msg,
        	[CallerMemberName] string memberName = "",
			[CallerFilePath] string sourceFilePath = "",
			[CallerLineNumber] int sourceLineNumber = 0)
        {
        	string filename = System.IO.Path.GetFileName(sourceFilePath);
            WriteLog(logType.ToString(), msg.ToString(), memberName, filename, sourceLineNumber);
        }
    }
	
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        Trace,  //堆栈跟踪信息
        Warning,//警告信息
        Error,  //错误信息应该包含对象名、发生错误点所在的方法名称、具体错误信息
        SQL    //与数据库相关的信息
    }
   	}

