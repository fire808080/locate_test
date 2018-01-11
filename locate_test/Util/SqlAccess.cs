using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssms.DataClasses;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ssms.Util
{
    class SqlAccess
    {
    	/*向数据库添加一条setting记录*/
		public static bool SA_AddSettings(string sStoreName, int iStoreId, string sSettingsName, ref int iSettingsId)
		{
			StringBuilder sLogStr = new StringBuilder();
			//LTS.Store oStore;
			LTS.Settings oSettings = null;
			
			sLogStr.AppendFormat("come in SA_AddSettings\r\nsStoreName[{0}], sSettingsName[{1}],iStoreId[{2}] ", sStoreName, sSettingsName, iStoreId);
			Log.WriteLog(LogType.Trace, sLogStr);

			try
			{
				//oStore = DAT.DataAccess.GetStoreItemByName(sStoreName);
				//oStore = DAT.DataAccess.GetStoreItemByID(iStoreId);

				oSettings = DAT.DataAccess.GetSettingsItemByName(sSettingsName, iStoreId);
				if (oSettings == null)
				{
					oSettings = new LTS.Settings();
					oSettings.SettingsName = sSettingsName;
					oSettings.StoreID = iStoreId;
					oSettings.SettingsSelect = false;

					iSettingsId = DAT.DataAccess.AddSettings(oSettings);
					if (iSettingsId == -1)
					{
						Log.WriteLog(LogType.Error, "error to call DataAccess.AddSettings");
						return false;
					}
					
					sLogStr.Length = 0;
					sLogStr.AppendFormat("success to add settings record with id[{0}], name[{1}],selectFlag[{2}],storeId[{3}]",
						iSettingsId, oSettings.SettingsName, oSettings.SettingsSelect, iStoreId);

					Log.WriteLog(LogType.Trace, sLogStr);

					return true;
				}
				else
				{
					iSettingsId = oSettings.SettingsID;
					
					sLogStr.Length = 0;
					sLogStr.AppendFormat("success to get settings record with id[{0}], name[{1}],storeId[{2}]",
						iSettingsId, oSettings.SettingsName, iStoreId);
					
					Log.WriteLog(LogType.Trace, sLogStr);
					return true;
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "TraceLog Error:" + ex.Message.ToString());
				return false;
			}
			
		}


    	/*向reader增加一个天线信息*/
		public static bool SA_AddAntenna(antenna stAntenna,  int iReaderId)
		{
			StringBuilder sLogStr = new StringBuilder();
			int iAntennaId;
			
			sLogStr.AppendFormat("come in SA_AddAntennas \r\n      antennaNumber[{0}], txPower[{1}], rxPower[{2}], readerId[{3}] ", 
				stAntenna.antennaNumber, stAntenna.txPower, stAntenna.rxPower, iReaderId);
			Log.WriteLog(LogType.Trace, sLogStr);

			try
			{
				LTS.Antenna oAntenna = new LTS.Antenna();  //lts下的数据类型，用来保存将要和数据库交互的数据
				oAntenna.AntennaNumber = stAntenna.antennaNumber;
				oAntenna.TxPower = stAntenna.txPower;
				oAntenna.RxPower = stAntenna.rxPower;
				oAntenna.ReaderID = iReaderId;
				

				iAntennaId = DAT.DataAccess.AddAntenna(oAntenna);
				if (iAntennaId == -1)
				{
                    Log.WriteLog(LogType.Error, "error to call DataAccess.AddAntenna"); 
						return false;
				}
				
				sLogStr.Length = 0;
				sLogStr.AppendFormat("success to add antenna record with id[{0}],AntennaNumber[{1}],TxPower[{2}],RxPower[{3}],ReaderID[{4}]",
					iAntennaId, oAntenna.AntennaNumber, oAntenna.TxPower, oAntenna.RxPower, oAntenna.ReaderID);

				Log.WriteLog(LogType.Trace, sLogStr);

				return true;
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "TraceLog Error:" + ex.Message.ToString());
				return false;
			}
			
		}
		

		/*向数据库添加一条reader记录*/
		public static bool SA_AddReader(Reader stReader, int iSettingsId)
		{
			StringBuilder sLogStr = new StringBuilder();
			int iReaderId;
			int iAntennasIdx;
			
			sLogStr.AppendFormat("come in SA_AddReader \r\n the reader info:ipaddress[{0}], numAntennas[{1}], rxPower[{2}] ",
				stReader.IPaddress, stReader.numAntennas, stReader.rxPower);
			Log.WriteLog(LogType.Trace, sLogStr);

			try
			{
				//生成lts的reader节点
                LTS.Reader oReader = new LTS.Reader();
                oReader.SettingsID = iSettingsId;
                oReader.IPaddress = stReader.IPaddress;
                oReader.NumAntennas = stReader.numAntennas;
                oReader.ReaderType = stReader.iReaderType;
					
				//通过dat接口将reader节点数据插入数据库
				iReaderId = DAT.DataAccess.AddReader(oReader);
				if (iReaderId == -1)
				{
					Log.WriteLog(LogType.Error, "error to call DataAccess.AddReader");
                    return false;
				}
				
				sLogStr.Length = 0;
				sLogStr.AppendFormat("success to add reader record with id[{0}], IPaddress[{1}],NumAntennas[{2}],SettingsID[{3}]",
					iReaderId, oReader.IPaddress, oReader.NumAntennas, oReader.SettingsID);

				Log.WriteLog(LogType.Trace, sLogStr);

				for (iAntennasIdx = 0; iAntennasIdx < stReader.numAntennas; iAntennasIdx++)
				{
					if (!SA_AddAntenna(stReader.antenna[iAntennasIdx], iReaderId))
					{
						Log.WriteLog(LogType.Error, "call AddAntenna error");
						return false;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "TraceLog Error:" + ex.Message.ToString());
				return false;
			}
				
		}
		
		public static DataTable SA_SqlQuery(string sql)
		{
			StringBuilder sLogStr = new StringBuilder();
			
			
    		Log.WriteLog(LogType.Trace, "come in SA_SqlQuery");
			
		
			//string strError = "";
			DataTable dt = new DataTable("Table1");

			/*打开数据可连接*/
			SqlConnection conn = DbConn.sqlConn();
			if (conn.State == ConnectionState.Closed)
			{
				conn.Open();
			}

			/*查询数据库*/
			try
			{
				SqlDataAdapter adpt = new SqlDataAdapter(sql, conn);
				adpt.Fill(dt);

				sLogStr.AppendFormat("success to exec sql[{0}]", sql);
				Log.WriteLog(LogType.Trace,  sLogStr);
				return dt;
			}
			catch (Exception ex)
			{
				sLogStr.AppendFormat("error to exec sql[{0}]; ", sql);
				sLogStr.Append(ex.Message);
				Log.WriteLog(LogType.Error,  sLogStr);
				
				return null;
			}

			/*关闭数据库连接*/
			finally
			{
				if (conn.State != ConnectionState.Closed)
				{
					conn.Close();
				}
			}
		}

			
		/*========new code========*/
		/// <summary>
        /// 连接数据库
        /// </summary>
        #if false //modify at 20171202
        private static string connectionString = "Data Source=.; Initial Catalog=ssms1; UID=sa;PASSWORD=123456;pooling=false; ";
#else
		private static string connectionString = Properties.Settings.Default.ssmsConnectionString;

#endif
        #region 设置数据库链接
        /// <summary>
        /// 设置数据库链接
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public static bool SetConn(string server, string database, string name, string pwd, string pool)
        {
        	string sLog;
			
        	Log.WriteLog(LogType.Trace, "come in SetConn");
			
            connectionString = "Data Source=" + server
            + "; Initial Catalog=" + database
            + "; UID=" + name
            + ";PWD=" + pwd
            + "; pooling=" + pool + ";";
			
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

					sLog = "success to open connection: " + connectionString;
					Log.WriteLog(LogType.Trace, sLog);
					
                    return true;
                }
                catch (Exception E)
                {
                    conn.Close();

					sLog = "error to open connection: " + connectionString + "\r\n errorinfo: " + E.Message;
					Log.WriteLog(LogType.Error, sLog);
					
                    return false;
                }
            }
        }
        #endregion

		#region 公用获取Connection
        /// <summary>
        /// //打开连接   并获得 SqlConnection
        /// </summary>
        public static SqlConnection Connection()
        {
        	string sLog;
			
        	Log.WriteLog(LogType.Trace, "come in Connection");
			sLog = "the connection string is:  " + connectionString;
			Log.WriteLog(LogType.Trace, sLog);
			
            
            {
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn == null)
                {


                    Log.WriteLog(LogType.Trace, "the connection is null, so open it.");
					
                    conn.Open();
                }
                else if (conn.State == System.Data.ConnectionState.Closed)
                {
     
                    Log.WriteLog(LogType.Trace, "the connection is closed, so open it.");
					
                    conn.Open();
                }
                else if (conn.State == System.Data.ConnectionState.Broken)
                {
   
					Log.WriteLog(LogType.Trace, "the connection is broken, so reopen it.");
					
                    conn.Close();
                    conn.Open();
                }
                return conn;
            }
        }

        #endregion

		#region  执行简单SQL语句
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string sqlString)
        {
        	
			
        	Log.WriteLog(LogType.Trace, "come in ExecuteSql");
			
			
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();

						Log.WriteLog(LogType.Trace, "success to          exec sql[" + sqlString + "], the effect row num is " + rows);
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();

						Log.WriteLog(LogType.Trace, "error to           exec sql[" + sqlString + "], the error info is    " + E.Message);
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }



		/// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sqlString)
        {
        	Log.WriteLog(LogType.Trace, "come in GetDataSet");
			
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sqlString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                	Log.WriteLog(LogType.Error, "error to exec sql[ " + sqlString + "], error info is:" + ex.Message);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

				Log.WriteLog(LogType.Trace, "success to exec sql[ " + sqlString + "]");
                return ds;
            }
        }

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="sqlStringList">多条SQL语句</param> 	   
		public static void ExecuteSqlTran(ArrayList sqlStringList)
		{
			Log.WriteLog(LogType.Trace, "come in ExecuteSqlTran");
			
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				SqlTransaction tx = conn.BeginTransaction();
				cmd.Transaction = tx;
				try
				{
					Log.WriteLog(LogType.Trace, "begin transition");
				
					for (int n = 0; n < sqlStringList.Count; n++)
					{
						string sqlString = sqlStringList[n].ToString();
						if (sqlString.Trim().Length > 1)
						{
							cmd.CommandText = sqlString;
							cmd.ExecuteNonQuery();

							Log.WriteLog(LogType.Trace, "success to exec sql["+ sqlString +"];");
						}
					}
					tx.Commit();
					Log.WriteLog(LogType.Trace, "end transition");
				}
				catch (System.Data.SqlClient.SqlException E)
				{
					tx.Rollback();

					Log.WriteLog(LogType.Error, "error to exec sql transition, the error info is ["+ E.Message +"]");
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					conn.Close();
				}
			}
		}
	

        #endregion
    }
}
