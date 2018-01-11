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
    /// ��־��
    /// </summary>
    public class Log
    {		
        //��־�ļ�����·��
        private static string logPath = string.Empty;
        /// <summary>
        /// ������־���ļ���
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
		
        //��־ǰ׺˵����Ϣ
        private static string logFielPrefix = string.Empty;
        /// <summary>
        /// ��־�ļ�ǰ׺
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
        /// д��־
        /// <param name="logType">��־����</param>
        /// <param name="msg">��־����</param> 
        /// </summary>
        public static void WriteLog(string logType, string msg, 
			string memberName ,
			string sourceFilePath ,
			int sourceLineNumber)
        {
        	System.IO.StreamWriter sw=null;

            try
            {
��������			//ͬһ��ͬһ����־��׷����ʽ����
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
        /// д��־
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
    /// ��־����
    /// </summary>
    public enum LogType
    {
        Trace,  //��ջ������Ϣ
        Warning,//������Ϣ
        Error,  //������ϢӦ�ð�����������������������ڵķ������ơ����������Ϣ
        SQL    //�����ݿ���ص���Ϣ
    }
   	}

