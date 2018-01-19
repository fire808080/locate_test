using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ssms.DataClasses;
using System.Windows.Forms;

using System.ComponentModel;
using System.Collections;
using System.Threading;

using ssms.Util;
using ssms.Pages.Items;




using ssms.Util;
using ssms;


namespace ssms.Util
{
	class Db
	{
		/*返回值:0标识不存在；1标识存在；-1表示处理出错*/
		public static int StoreIsExist(string sStoreName, string sLocation, ref int iID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in StoreIsExist");

			try
			{
				sSql = "select * from Store where StoreName = '" + sStoreName + "' and StoreLocation = '" + sLocation + "';";
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not store[" + sStoreName + "," + sLocation + "] in database.");
					iID = 0;
					return 0; //store不存在
				}
				else 
				{
					iID = Int32.Parse(stDt.Rows[0]["StoreID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the store[" + sStoreName + "," + sLocation + "] with id["+ iID +"]");
					return 1;
				}
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}

		/*获取store的信息*/
		public static DataTable StoreGetInfo()
		{
			DataSet stDs;
			Log.WriteLog(LogType.Trace, "come in StoreGetInfo");

			string sSql = "Select Store.StoreID, Store.StoreName, Store.StoreLocation " +
						"From Store order by StoreID";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);

				Log.WriteLog(LogType.Trace, "Success to store info from db");
				return stDs.Tables[0];
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return null;
			}

		}


		
		/*判断数据库里面是否有重名的类型*/
		public static int CategoryIsExist(string sCategoryName, ref int iRdID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in CategoryIsExist");

			try
			{
				sSql = "select * from Category where CategoryName = '" + sCategoryName + "';";
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not category[" + sCategoryName + "] in database.");
					iRdID = 0;
					return 0; //store不存在
				}
				else 
				{
					iRdID = Int32.Parse(stDt.Rows[0]["CategoryID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the category[" + sCategoryName + "] and id[" + iRdID + "]");
					return 1;
				}
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}

		/*获取category的信息*/
		public static DataTable CategoryGetInfo()
		{
			DataSet stDs;
			Log.WriteLog(LogType.Trace, "come in StoreGetInfo");
		
			string sSql = "Select CategoryID, CategoryName, CategoryDescription " +
						"From Category";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
		
				Log.WriteLog(LogType.Trace, "Success to category info from db");
				return stDs.Tables[0];
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return null;
			}
		
		}

		public static int CategoryGetID(string sCategoryName)
		{
			DataSet stDs;
			DataTable stDt;
			int iRdID;
			
			Log.WriteLog(LogType.Trace, "come in CategoryGetID");
		
			string sSql = "Select CategoryID From Category Where  CategoryName = '"+sCategoryName+"'";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
		
				Log.WriteLog(LogType.Trace, "Success to category info from db");
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count >0)
				{
					iRdID = Int32.Parse(stDt.Rows[0]["CategoryID"].ToString());

					Log.WriteLog(LogType.Trace, "success to get category[" + sCategoryName + "] with id[" + iRdID + "]");
					return iRdID;
				}
				else
				{
					Log.WriteLog(LogType.Error, "there is not category with name["+sCategoryName+"]");
					return 0;
				}
				
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}
		
		}
		
		/*判断数据库里面是否有重名的类型*/
		public static int BrandIsExist(string sBrandName, ref int iRdID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in BrandIsExist");

			try
			{
				sSql = "select * from Brand where BrandName = '" + sBrandName + "';";
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not brand[" + sBrandName + "] in database.");
					iRdID = 0;
					return 0; //brand不存在
				}
				else 
				{
					iRdID = Int32.Parse(stDt.Rows[0]["BrandID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the brand[" + sBrandName + "] and id[" + iRdID + "]");
					return 1;
				}
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}
				

		/*获取Brands的信息*/
		public static DataTable BrandsGetInfo()
		{
			DataSet stDs;
			Log.WriteLog(LogType.Trace, "come in BrandsGetInfo");

			string sSql = "Select BrandID, BrandName, BrandDescription " +
						"From Brand";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);

				Log.WriteLog(LogType.Trace, "Success to brands info from db");
				return stDs.Tables[0];
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return null;
			}

		}

		public static int BrandGetID(string sBrandName)
		{
			DataSet stDs;
			DataTable stDt;
			int iRdID;
			
			Log.WriteLog(LogType.Trace, "come in BrandGetID");
		
			string sSql = "Select BrandID From Brand Where  BrandName = '"+sBrandName+"'";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
		
				Log.WriteLog(LogType.Trace, "Success to brand info from db");
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count >0)
				{
					iRdID = Int32.Parse(stDt.Rows[0]["BrandID"].ToString());

					Log.WriteLog(LogType.Trace, "success to get brand['" + sBrandName + "'] with id[" + iRdID + "]");
					return iRdID;
				}
				else
				{
					Log.WriteLog(LogType.Error, "there is not brand with name["+sBrandName+"]");
					return 0;
				}
				
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}
		
		}
				
		public static int BarcodeIsExist(string sBarcodeNum,  ref int iID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in BarcodeIsExist");

			try
			{
				sSql = "select * from Barcode where BarcodeNumber = '"+sBarcodeNum+"';";
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not barcode[" + sBarcodeNum + "] in database.");
					iID = 0;
					return 0; //barcode不存在
				}
				else 
				{
					iID = Int32.Parse(stDt.Rows[0]["BarcodeID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the barcode[" + sBarcodeNum + "] with id["+ iID +"]");
					return 1;
				}
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}

		//判断条形码是否又被product使用
		public static int BarcodeHadBeenUse(string sBarcodeNum,  ref int iID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in BarcodeHadBeenUse");

			try
			{
				sSql = "select ProductID from Product join Barcode on Product.BarcodeID = Barcode.BarcodeID" +
						" where BarcodeNumber = '"+sBarcodeNum+"';";
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not barcode[" + sBarcodeNum + "] in database.");
					iID = 0;
					return 0; //barcode 没有被使用过
				}
				else 
				{
					iID = Int32.Parse(stDt.Rows[0]["ProductID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the product["+iID+"] use barcode[" + sBarcodeNum + "]");
					return 1;
				}
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}
				
		public static int BarcodeDelRecode(int iID)
		{
			DataSet stDs;
			DataTable stDt;

			string sSql;

			Log.WriteLog(LogType.Trace, "come in BarcodeDelRecode");

			try
			{
				sSql = "delete from Barcode where BarcodeID = '"+iID+"';";
				SqlAccess.ExecuteSql(sSql);
				Log.WriteLog(LogType.Trace, "success to delete barcode with id["+iID+"] from db");
				return 1;
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call ExecuteSql");
				return 0;
			}

		}
		
		/*获取produce的id*/
		public static int ProductIsExist(string sProduceName, string sBrandName, string sCategoryName, ref int iRdID)
		{
			DataSet stDs;
			DataTable stDt;
			
			Log.WriteLog(LogType.Trace, "come in ProductIsExist");

			string sSql = "Select Product.ProductID From Product "+
				" Join Brand on Product.BrandID = Brand.BrandID "+
				" Join Category on Category.CategoryID = Product.CategoryID "+
				" where Product.ProductName = '"+sProduceName+"' And Brand.BrandName = '"+sBrandName+"' And Category.CategoryName = '"+sCategoryName+"';";
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);

				Log.WriteLog(LogType.Trace, "Success to product info from db");
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not product[" + sProduceName + ","+sBrandName+","+sCategoryName+"] in database.");
					iRdID = 0;
					return 0; //barcode不存在
				}
				else 
				{
					iRdID = Int32.Parse(stDt.Rows[0]["ProductID"].ToString());
					Log.WriteLog(LogType.Trace, "success to get the product[" + sProduceName + ","+sBrandName+","+sCategoryName+"]  and id[" + iRdID + "]");
					return 1;
				}
				
				
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return -1;
			}

		}


		/*获取products的信息*/
		public static DataTable ProductGetInfo()
		{
			DataSet stDs;
			Log.WriteLog(LogType.Trace, "come in ProductGetInfo");
		
			string sSql = "Select Product.ProductID, Product.ProductName, Product.ProductDescription, Barcode.BarcodeNumber, Brand.BrandName, Category.CategoryName From Product "+
				"Join Barcode on  Product.BarcodeID = Barcode.BarcodeID "+
				"Join Brand on Product.BrandID = Brand.BrandID "+
				"Join Category on Product.CategoryID = Category.CategoryID;";
			
			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
		
				Log.WriteLog(LogType.Trace, "Success to get product info from db");
				return stDs.Tables[0];
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call product");
				return null;
			}
		
		}

		/*判断barcode是否绑定了product*/
		public static int barcode_isBandWithProduct(int iBarcodeId)
		{
			Log.WriteLog(LogType.Trace, "come in barcode_isBandWithProduct");
			try
			{
				List<LTS.Product> listProduct = DAT.DataAccess.GetProduct().Where(p=>p.BarcodeID == iBarcodeId).ToList();
				if (listProduct == null)
				{
					Log.WriteLog(LogType.Error, "error to get product with band with barcode["+iBarcodeId+"]");
					return -1;
				}

				//一个barcode只能对应一个product
				if (listProduct.Count > 1)
				{
					Log.WriteLog(LogType.Error, "system error, the barcode["+iBarcodeId+"] is banding more than one product, is not permit.");
					return -1;
				}

				if (listProduct.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "the barcode["+iBarcodeId+"] is not banding any product");
					return 0;
				}
				
				LTS.Product stProduct = listProduct[0];

				Log.WriteLog(LogType.Trace, "the barcode["+iBarcodeId+"] is banding with product["+stProduct.ProductID+"]");

				return 1;

			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to get product with barcode["+iBarcodeId+"]");
				return -1;
			}
		}

	
		/*判断barcode是否绑定了product，一个barcode只能对应一个product*/
		public static bool barcode_getBandingProduct(int iBarcodeId, ref LTS.Product stProduct)
		{
			Log.WriteLog(LogType.Trace, "come in barcode_getBandingProduct");
			try
			{
				List<LTS.Product> listProduct = DAT.DataAccess.GetProduct().Where(p=>p.BarcodeID == iBarcodeId).ToList();
				if (listProduct == null)
				{
					Log.WriteLog(LogType.Error, "error to get product with band with barcode["+iBarcodeId+"]");
					return false;
				}

				//一个barcode只能对应一个product
				if (listProduct.Count > 1)
				{
					Log.WriteLog(LogType.Error, "system error, the barcode["+iBarcodeId+"] is banding more than one product, is not permit.");
					return false;
				}

				if (listProduct.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "the barcode["+iBarcodeId+"] is not banding any product");
					stProduct = null;
					return true;
				}
				
				stProduct = listProduct[0];

				Log.WriteLog(LogType.Trace, "the barcode["+iBarcodeId+"] is banding with product["+stProduct.ProductID+"]");

				return true;

			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to get product with barcode["+iBarcodeId+"]");
				return false;
			}
		}
	

	}

	class ParamValid
	{
		 /// <summary>   
		 /// 判断输入的字符串只包含数字   
		 /// 可以匹配整数和浮点数   
		 /// ^-?\d+$|^(-?\d+)(\.\d+)?$   
		 /// </summary>   
		 /// <param name="input"></param>   
		 /// <returns></returns>   
		 public static bool IsNumber(string input)  
		 {  
			 string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";  
			 Regex regex = new Regex(pattern);  
			 return regex.IsMatch(input);  
		 } 

		 /// <summary>   
		 /// 判断输入的字符串是否只包含数字和英文字母   
		 /// </summary>   
		 /// <param name="input"></param>   
		 /// <returns></returns>   
		 public static bool IsNumAndEnCh(string input)  
		 {  
			 string pattern = @"^[A-Za-z0-9]+$";  
			 Regex regex = new Regex(pattern);  
			 return regex.IsMatch(input);  
		 }  
		 
	}

	class Tool
	{
		public static void clearDgv()
		{
			
		}
	}

	//具体业务列表
	public class BusinessQue
	{
		public Queue<TagInfo> stRList;   //读队列
		public Mutex stRMutex;

		public Queue<TagInfo> stWList;   //写队列
		public Mutex stWMutex;

		
		//供写操作确认是否写成功使用
		public Dictionary<int, TagInfo>stTagDic;
		public Mutex stTagDicMutex;
		
		//供所有读写器去重使用
		public Dictionary<string, int> stDeduplicateDic;
		public Mutex stDeduplicateDicMutex;


		//生成业务队列资源
        public BusinessQue()
        {			
            stRList = new Queue<TagInfo>();
			stRMutex = new Mutex();

			stWList = new Queue<TagInfo>();
			stWMutex = new Mutex();

			
			
			stTagDic = new Dictionary<int, TagInfo>();
			stTagDicMutex = new Mutex(); 

			stDeduplicateDic = new Dictionary<string, int>();
			stDeduplicateDicMutex = new Mutex();
        }
		
	}

	
	class Rfid
	{


		//保存Store信息
		private static bool SaveStoreInfo(ref DataTable stDt, ref SettingsMain stSmi)
		{
			Log.WriteLog(LogType.Trace, "come in SaveStoreInfo");
			
			stSmi.StoreID = Int32.Parse(stDt.Rows[0]["StoreID"].ToString());
			stSmi.StoreLocation = stDt.Rows[0]["StoreLocation"].ToString();
			stSmi.StoreName = stDt.Rows[0]["StoreName"].ToString();

			Log.WriteLog(LogType.Trace, "success save store info :id["+stSmi.StoreID+"],name["+stSmi.StoreName+"], storelocate["+stSmi.StoreLocation +"]");
			
			return true;
		}

		//保存setting信息
		private static bool SaveSettingInfo(ref DataTable stDt, ref SettingsMain stSmi)
		{
			Log.WriteLog(LogType.Trace, "come in SaveStoreInfo");

			stSmi.SettingsID = Int32.Parse(stDt.Rows[0]["SettingsID"].ToString());
			stSmi.SettingsName =  stDt.Rows[0]["SettingsName"].ToString();
			stSmi.SettingsSelect = true;

			Log.WriteLog(LogType.Trace, "save setting info : SettingsID[" + stSmi.SettingsID + "], SettingsName[" + stSmi.SettingsName + "], select["+stSmi.SettingsSelect+"]");

			return true;
		}

		//保存antenna信息
		private static bool SaveAntennaInfo(ref ReaderMain rm, int iReaderId)
		{
			DataSet stDs;
			DataTable stDt;
			
			Log.WriteLog(LogType.Trace, "come in SaveAntennaInfo");

			string sSql = "select * from Antenna where ReaderID = " + iReaderId + " order by AntennaID;";


			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
		
				Log.WriteLog(LogType.Trace, "success to get reader["+iReaderId+"] antenna info from db");
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count >0)
				{
					for (int iIdx = 0; iIdx < stDt.Rows.Count; iIdx ++)
					{
						DataRow stDr = stDt.Rows[iIdx];
						LTS.Antenna stAnt = new LTS.Antenna();
 
						stAnt.AntennaID = Int32.Parse(stDr["AntennaID"].ToString());
						stAnt.ReaderID = Int32.Parse(stDr["ReaderID"].ToString());
						stAnt.RxPower = decimal.Parse(stDr["RxPower"].ToString());
						stAnt.TxPower = decimal.Parse(stDr["TxPower"].ToString());
						stAnt.AntennaNumber = Int32.Parse(stDr["AntennaNumber"].ToString());

						rm.antennas.Add(stAnt);

						Log.WriteLog(LogType.Trace, "success to save reader["+iReaderId+"] antenna["+stAnt.AntennaNumber+"] info:antennid["+stAnt.AntennaID+"], " +
							"RxPower["+stAnt.RxPower+"], TxPower["+stAnt.TxPower+"]");
					}
				}
				else
				{
					Log.WriteLog(LogType.Trace, "info:there is not antenna with reader["+iReaderId+"]");
					return true;
				}
				
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to call GetDataSet");
				return false;
			}


			

			return true;
		}

		//保存reader信息
		private static bool SaveReaderInfo(ref DataRow stDr, ref SettingsMain stSmi, int iIdx)
		{
			ReaderMain rm = new ReaderMain();

			Log.WriteLog(LogType.Trace, "come in SaveReaderInfo");

			rm.ReaderID =Int32.Parse(stDr["ReaderID"].ToString());
			rm.IPaddress = stDr["IPaddress"].ToString();
			rm.NumAntennas = Int32.Parse(stDr["NumAntennas"].ToString());
			rm.iReaderType = Int32.Parse(stDr["ReaderType"].ToString());
			
			Log.WriteLog(LogType.Trace, "success to save reader[" + iIdx + "] info is :ReaderID[" + rm.ReaderID + "], IPaddress[" + rm.IPaddress + "],NumAntennas[" + rm.NumAntennas + "], ReaderType["+rm.iReaderType+"]");

			//保存reader下所有antenna信息
			if (rm.NumAntennas > 0)
			{
				if (!SaveAntennaInfo(ref rm, rm.ReaderID))
				{
					Log.WriteLog(LogType.Trace, "error to call SaveAntennaInfo");
					return false;
				}
			}
			
			stSmi.Readers.Add(rm);

			return true;
		}

		//所有读写器去连接
		//private static bool reader_disconnect(ref List<ImpinjRevolution> lsImpinjRev)
		private static bool reader_disconnect(List<ImpinjRevolution> lsImpinjRev)
		{
			Log.WriteLog(LogType.Trace, "come reader_disconnect");

            if (lsImpinjRev == null)
			{
				Log.WriteLog(LogType.Error, "error:the input params is null");
				return false;	
			}

			Log.WriteLog(LogType.Trace, "goto disconnect "+lsImpinjRev.Count+" reader(s)");

			try
			{
				for (int i = 0; i < lsImpinjRev.Count; i++)
				{
					if (lsImpinjRev[i].isConnected)
					{
						lsImpinjRev[i].ir_stopRead();
						lsImpinjRev[i].ir_disconnect();
						
						Log.WriteLog(LogType.Trace, "success to disconnect reader["+lsImpinjRev[i].HostName+"]");
					}
					else
					{
						Log.WriteLog(LogType.Trace, "reader["+lsImpinjRev[i].HostName+"] status is disconnect, so not need to disconnect it.");
					}
				}

				//释放对所有impinj revolution的引用
				lsImpinjRev.Clear();
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to disconnect impinj resolution reader, the error msg is "+ex.Message.ToString()+"");
			}
			return true;
		}

		//判断读写器是否有委托处理函数
		private static bool reader_has_delegate(ImpinjRevolution imp)
		{
			Log.WriteLog(LogType.Trace, "come in reader_has_delegate");

			switch (imp.iReaderType)
			{
				case Macro.READER_TYPE_READER:
				{
					if (!imp.isdReadHandlerEnable)
					{
						Log.WriteLog(LogType.Error, "error:there is not read delegate function in reader["+ imp.HostName+"], so no need to start it");
						MessageBox.Show("error:there is not read delegate function in reader["+ imp.HostName+"], so no need to start it");
					}
				}
				break;

				case Macro.READER_TYPE_WRITER:
				{
					if (!imp.isdWriteHandlerEnable)
					{
						Log.WriteLog(LogType.Error, "error:there is not write delegate function in reader["+ imp.HostName+"], so no need to start it");
						MessageBox.Show("error:there is not write delegate function in reader["+ imp.HostName+"], so no need to start it");
					}
				}
				break;

				case Macro.READER_TYPE_CHECKR:
				{
					if (!imp.isdCheckHandlerEnable)
					{
						Log.WriteLog(LogType.Error, "error:there is not check delegate function in reader["+ imp.HostName+"], so no need to start it");
						MessageBox.Show("error:there is not chech delegate function in reader["+ imp.HostName+"], so no need to start it");
					}
				}
				break;
												

				default:
				{
					Log.WriteLog(LogType.Error, "error:unknow operation type["+imp.iReaderType+"] with reader["+ imp.HostName+"]");
					return false;
				}
				break;
			}

			
			return true;
		}
		
		//注册委托函数
		//private static bool reader_regist_delegate(ref ImpinjRevolution ir, int iReaderType, delegate_read_handler dRHandler, delegate_write_handler dWHandler, delegate_check_handler dCHandler)
		private static bool reader_regist_delegate(ImpinjRevolution ir, int iReaderType, delegate_read_handler dRHandler, delegate_write_handler dWHandler, delegate_check_handler dCHandler)
		{
			Log.WriteLog(LogType.Trace, "come in reader_regist_delegate");

			switch (iReaderType)
			{
				case Macro.READER_TYPE_READER:
				{
					if (dRHandler != null)
					{
						ir.dReadHandler += dRHandler;
						Log.WriteLog(LogType.Trace, "success to regist read delegate function to the reader["+ir.HostName+"] with type["+iReaderType+"].");
					
					}
				}
				break;

				case Macro.READER_TYPE_WRITER:
				{
					if (dWHandler != null)
					{
						ir.dWriteHandler += dWHandler;
						Log.WriteLog(LogType.Trace, "success to regist write delegate function to the reader["+ir.HostName+"] with type["+iReaderType+"].");
					}
				}
				break;

				case Macro.READER_TYPE_CHECKR:
				{
					if (dCHandler != null)
					{
						ir.dCheckHandler += dCHandler;
						Log.WriteLog(LogType.Trace, "success to regist check delegate function to the reader["+ir.HostName+"] with type["+iReaderType+"].");
					}
				}
				break;
												

				default:
				{
					//目前只提示出错，不退出处理，后续处理交事务流程合法性进行判断
					Log.WriteLog(LogType.Error, "error:the reader["+ir.HostName+"] type["+iReaderType+"] is invaliable.");
					return false;
				}	
				break;
			}

			
			return true;
		}

		/*SettingsMain smii, settings的配置信息;
		*ref List<ImpinjRevolution> impinjrev, reader控制节点列表;
		*delegate_read_handler dRHandler, 读操作函数;
        *delegate_write_handler dWHandler, 写操作函数;
        *delegate_check_handler dCHandler, 校验函数;
        *bool bTest， 测试标志位;
        *描述：为每个读写器申请一个读写器节点，并连接到物理读写器上，将配置应用到读写器中。*/
        private static bool reader_connect_handler(SettingsMain smii, List<ImpinjRevolution> impinjrev, BusinessQue stBQue, delegate_read_handler dRHandler, 
        	delegate_write_handler dWHandler, delegate_check_handler dCHandler, bool bTest)
		{
			bool bAllConnected = true;
			
			
			Log.WriteLog(LogType.Trace, "come reader_connect_handler");

			try
			{
				//连接到对应读写器上,并对读写器进行配置(一个reader配置对应一个impinj解决方案对象)
				for (int x = 0; x < smii.Readers.Count; x++)
				{
					//如果系统没有内存分配给revolution,则会抛出异常，所以在这里不需要对ir返回值进行合法性判断
					ImpinjRevolution ir = new ImpinjRevolution();
					
					ir.ReaderScanMode = ScanMode.FullScan;
					ir.HostName = smii.Readers[x].IPaddress;
					ir.Antennas = smii.Readers[x].antennas;
					ir.iReaderType = smii.Readers[x].iReaderType;
					ir.stBQue = stBQue;
					//注册委托函数
					reader_regist_delegate(ir, ir.iReaderType, dRHandler, dWHandler, dCHandler);

					//连接到读写器，并进行配置					
					if (!ir.ir_connectReader())
					{
                        Log.WriteLog(LogType.Trace, "error to connect to reader[" + ir.HostName + "]");
					}
					else
					{
                        Log.WriteLog(LogType.Trace, "success to connect to reader[" + ir.HostName + "]");
					}

					//读写器控制节点加入数组
					impinjrev.Add(ir);

					//根据本节点的操作，决定全局操作标志位
					if (!ir.isConnected)
					{
						if (bAllConnected == true)
						{
							bAllConnected = false;
                            Log.WriteLog(LogType.Warning, "Warning: reader["+smii.Readers[x].IPaddress+"] can not be connect to, so we will not using the revolution");
						}
						else
						{
							Log.WriteLog(LogType.Warning, "Warning: reader["+smii.Readers[x].IPaddress+"] can not be connect to");
						}
					}
				}

				if (bAllConnected == true)
				{
					MessageBox.Show("All the readers in settings["+smii.SettingsID+"] are connected succesfully!");	
				}
				else
				{
					MessageBox.Show("there are some readers in settins["+smii.SettingsID+"] are not connect succesfully!");					
				}

				if (bTest || !bAllConnected)
				{
					Log.WriteLog(LogType.Trace, "this is a test process or some reader(s) can not connect to, so go to disconnect reader(s)");
					//去连接
					if (!reader_disconnect(impinjrev))
					{
						Log.WriteLog(LogType.Error, "error to call reader_disconnect");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Sorry Something went wrong, the connect was not completed!");
				bAllConnected = false;
			}

			return bAllConnected;

		}

		/*int iStoreId, int iSettingId, 
		*List<ImpinjRevolution> impinjrev, 读写器列表;
		*delegate_read_handler dRHandler, 读操作函数;
		*delegate_write_handler dWHandler, 写操作函数;
		*delegate_check_handler dCHandler, 校验函数;
		*bool bTest, 标识是否是测试操作;
		*描述:供外部使用的连接读写器的接口API。应用setting的配置，连接到指定的读写器上。
		*/
		public static bool reader_connectReader(int iStoreId, int iSettingId, List<ImpinjRevolution> impinjrev, BusinessQue stBQue, 
			delegate_read_handler dRHandler, delegate_write_handler dWHandler, delegate_check_handler dCHandler, bool bTest)
		{  
			DataSet stDs;
			DataTable stDt;

			SettingsMain smi = new SettingsMain();
				
			Log.WriteLog(LogType.Trace, "come in reader_connectReader");
			
			//获取指定setting下所有reader的信息
			string sSql = "select s.StoreID, s.StoreName, s.StoreLocation, st.SettingsID, st.SettingsName, st.SettingsSelect, r.ReaderID, r.IPaddress, r.NumAntennas, r.ReaderType " +
				"from Store s " +
				"LEFT JOIN Settings st ON st.StoreID = s.StoreID "+
				"LEFT JOIN Reader r ON r.SettingsID = st.SettingsID "+
				"where s.StoreID = "+iStoreId+" AND st.SettingsID = "+iSettingId+"; ";

			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];
				if (stDt.Rows.Count == 0)
				{
					Log.WriteLog(LogType.Trace, "there is not setting with storeid[" + iStoreId + "] and settingId[" + iSettingId + "]");

					MessageBox.Show("there is not setting with storeid[" + iStoreId + "] and settingId[" + iSettingId + "]");

					return true;
				}
				Log.WriteLog(LogType.Trace, "success to get "+stDt.Rows.Count+" readers configs in store["+iStoreId+"]  settings["+iSettingId+"].");

				/*====================保存配置到内存====================*/
				SaveStoreInfo(ref stDt, ref smi);
				SaveSettingInfo(ref stDt, ref smi);

				//遍历所有reader
				for (int iIdx = 0; iIdx < stDt.Rows.Count; iIdx++)
				{
					DataRow stDr = stDt.Rows[iIdx];

					if (!SaveReaderInfo(ref stDr, ref smi, iIdx))
					{
						MessageBox.Show("error to get reader config, so can not connect to reader.");
						return false;
					}
				}

				/*================根据配置连接到指定的读写器上================*/
				if (!reader_connect_handler(smi, impinjrev, stBQue, dRHandler, dWHandler, dCHandler, bTest))
				{
					Log.WriteLog(LogType.Error, "error go call reader_connect");
					return false;
				}

				return true;
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to process connect reader, the exception msg is "+ex.Message.ToString()+".");
				return false;
			}
			
			
		} 
		
		//启动读写器读写功能
		public static bool reader_start_read(ref List<ImpinjRevolution> impinjrev, delegate_read_handler dRHandler, delegate_write_handler dWHandler, delegate_check_handler dCHandler)
		{
            Log.WriteLog(LogType.Trace, "come in reader_start_read");
			string sReaderIp = "";

			try
			{
				impinjrev.ForEach(imp =>
				{
					sReaderIp = imp.HostName;

					if (reader_regist_delegate(imp, imp.iReaderType, dRHandler, dWHandler, dCHandler))
					{
						if (reader_has_delegate(imp))
						{
							imp.ir_startRead();
							Log.WriteLog(LogType.Trace, "success to start reader["+imp.HostName+"], with operation type["+imp.iReaderType+"].");
						}
						
					}
					else
					{
						Log.WriteLog(LogType.Error, "error to regist reader["+imp.HostName+"] delegate function with operation type["+imp.iReaderType+"]");
						MessageBox.Show("error to regist reader["+imp.HostName+"] delegate function with operation type["+imp.iReaderType+"]");
					}					
				});
			}
			catch (Exception ex)
			{
                Log.WriteLog(LogType.Error, "error to start reader[" + sReaderIp + "], the exception msg is" + ex.Message.ToString() + ".");
				return false;
			}

			return true;	
		}
	}


}
