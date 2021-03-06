﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;
using System.ComponentModel;
using System.Collections;
using System.Threading;

using ssms.Util;
using ssms.Pages.Items;


namespace ssms.DataClasses
{

	//业务处理函数
	public delegate bool delegate_read_handler(TagInfo tag, EventArgs e, Queue<TagInfo> stTagList, ref  Mutex stMutex);

	//写业务处理函数
	public delegate bool delegate_write_handler(EventArgs e, ImpinjReader stReader, string sTagId,  Queue<TagInfo> stRList, ref Mutex stRMutex,  
		 Queue<TagInfo> stWList, ref Mutex stWMutex, ref ushort usEpcOpId, ref ushort usPcBitOpId,  Dictionary<int, TagInfo> stDic, Mutex stDicMutex);

	//写业务处理函数
	public delegate bool delegate_check_handler(ImpinjReader stReader, string sTagId, string sEpc, Queue<TagInfo> stWList,  Mutex stWMutex);
	
	//对读写器进行封装
    public class ImpinjRevolution
    {
        ImpinjReader reader;

		//基本信息
        public string HostName { get; set; }
        public string Filter { get; set; }
        public List<LTS.Antenna> Antennas { get; set; }
        public int AntennaCount { get { if (Antennas != null) { return Antennas.Count; } else { return 0; } } }
		public int iReaderType {get; set;}
		public bool isConnected = false;
		
		public BusinessQue stBQue { get; set; }//业务队列
		
		
		
		bool bTest = true;


		//定义事件和委托
		public event delegate_read_handler dReadHandler;
		public event delegate_write_handler dWriteHandler;
		public event delegate_check_handler dCheckHandler;		
		public bool isdReadHandlerEnable { get { if (dReadHandler != null) { return true; } else { return false; } } }
		public bool isdWriteHandlerEnable { get { if (dWriteHandler != null) { return true; } else { return false; } } }
		public bool isdCheckHandlerEnable { get { if (dCheckHandler != null) { return true; } else { return false; } } }




        public ScanMode ReaderScanMode = ScanMode.FullScan;
        
		
		#if false
		//操作队列
		public Queue<TagInfo> stRList;   //入场队列
		public Mutex stRMutex;

		public Queue<TagInfo> stWList;   //写队列
		public Mutex stWMutex;

		
		

		
        public Dictionary<int, TagInfo> stTagDic = new Dictionary<int, TagInfo>();

		public Dictionary<string, int> stDeduplicateDic = new Dictionary<string, int>();
		public Mutex stDeduplicateDicMutex;
		#endif

		public ushort usEpcOpId {get; set;}
		public ushort usPcBitOpId {get; set;}
		public StatInfo stStatInfo;

		
		
		//生成读写器
        public ImpinjRevolution()
        {
            reader = new ImpinjReader();

			stStatInfo = new StatInfo();

			#if false
            stRList = new Queue<TagInfo>();
			stRMutex = new Mutex();

			stWList = new Queue<TagInfo>();
			stWMutex = new Mutex();	
			stDeduplicateDicMutex = new Mutex();
			#endif

			dReadHandler = null;
			dWriteHandler = null;
			dCheckHandler = null;
			usEpcOpId = 0;
			usPcBitOpId = 0;


        }

		//注册事件处理函数
		public bool ir_register_event_process(ImpinjReader stReader)
        {
			Log.WriteLog(LogType.Trace, "come in ir_register_event_process");


			switch (iReaderType)
			{
				case Macro.READER_TYPE_READER:
				{
					//绑定tag上报处理函数
					stReader.TagsReported += ir_onTagsReported_readTag;   
				}
				break;

				case Macro.READER_TYPE_WRITER:
				{

					// Assign the TagsReported event handler.
					// This specifies which method to call
					// when tags reports are available.
                	stReader.TagsReported += ir_onTagsReported_writeTag;

	                // Assign the TagOpComplete event handler.
	                // This specifies which method to call
	                // when tag operations are complete.
	                stReader.TagOpComplete += ir_onTagOpComplete_writeConfire;
				}
				break;

				case Macro.READER_TYPE_CHECKR:
				{
					//绑定tag上报处理函数
					stReader.TagsReported += ir_onTagsReported_checkTag;   
				}
				break;
								
				default:
				{
					Log.WriteLog(LogType.Error, "the reader["+HostName+"] reader type["+iReaderType+"] is unknow");
					return false;
				}
				break;
			}

			
			

			#if false
			 
			stReader.GpiChanged += OnGpiEvent;
			stReader.AntennaChanged += OnAntennaEvent;
			stReader.ReaderStarted += OnReaderStarted;
			stReader.ReaderStopped += OnReaderStopped;

			stReader.ReportBufferWarning += OnReportBufferWarning;
			stReader.ReportBufferOverflow += OnReportBufferOverflow;
			stReader.KeepaliveReceived += OnKeepaliveReceived;
			stReader.ConnectionLost += OnConnectionLost;
			 
			#endif
			
			return true;
		}

		//注册事件处理函数
		public bool ir_register_event_opProcess(ImpinjReader stReader)
        {
			Log.WriteLog(LogType.Trace, "come in ir_register_event_opProcess");


			switch (iReaderType)
			{
				case Macro.READER_TYPE_READER:
				{
					//绑定tag上报处理函数
					stReader.TagOpComplete += ir_onTagOpComplete_read;
				}
				break;

				case Macro.READER_TYPE_WRITER:
				{

					// Assign the TagsReported event handler.
					// This specifies which method to call
					// when tags reports are available.
                	stReader.TagOpComplete += ir_onTagOpComplete_write;
				}
				break;

				case Macro.READER_TYPE_CHECKR:
				{
					//绑定tag上报处理函数
					stReader.TagOpComplete += ir_onTagOpComplete_check;   
				}
				break;
								
				default:
				{
					Log.WriteLog(LogType.Error, "the reader["+HostName+"] reader type["+iReaderType+"] is unknow");
					return false;
				}
				break;
			}

			
			

	#if false
			 
			stReader.GpiChanged += OnGpiEvent;
			stReader.AntennaChanged += OnAntennaEvent;
			stReader.ReaderStarted += OnReaderStarted;
			stReader.ReaderStopped += OnReaderStopped;

			stReader.ReportBufferWarning += OnReportBufferWarning;
			stReader.ReportBufferOverflow += OnReportBufferOverflow;
			stReader.KeepaliveReceived += OnKeepaliveReceived;
			stReader.ConnectionLost += OnConnectionLost;
			 
	#endif
			
			return true;
		}
		

		/*设置读读写器的专属配置*/
		public void ir_config_settings_read(Settings settings)
		{
			Log.WriteLog(LogType.Trace, "come in ir_config_settings_read");

			try
			{
				// Tell the reader to include the antenna number
				// in all tag reports. Other fields can be added
				// to the reports in the same way by setting the 
				// appropriate Report.IncludeXXXXXXX property.
				settings.Report.IncludeAntennaPortNumber = true;

				// Send a tag report for every tag read.
				settings.Report.Mode = ReportMode.Individual;

				// Start reading tags when GPI #1 goes high.
				settings.Gpis.GetGpi(1).IsEnabled = true;
				settings.Gpis.GetGpi(1).DebounceInMs = 50;
				settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
				settings.AutoStart.GpiPortNumber = 1;
				settings.AutoStart.GpiLevel = true;

				// Stop reading tags when GPI #1 goes low.
				settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
				settings.AutoStop.GpiPortNumber = 1;
				settings.AutoStop.GpiLevel = false;
				
				if (Macro.USE_OPTIMIZE_READ == 1)
				{
					// Create a tag read operation for TID memory.
	                TagReadOp stReadOp = new TagReadOp();
	                // Read from TID memory
	                stReadOp.MemoryBank = MemoryBank.Tid;
	                // Read two (16-bit) words
	                stReadOp.WordCount = 6;
	                // Starting at word 0
	                stReadOp.WordPointer = 0;

	                // Add these operations to the reader as Optimized Read ops.
	                // Optimized Read ops apply to all tags, unlike 
	                // Tag Operation Sequences, which can be applied to specific tags.
	                // Speedway Revolution supports up to two Optimized Read operations.
	                stReadOp.Id = Macro.TAG_OP_ID_READ;
	                settings.Report.OptimizedReadOps.Add(stReadOp);

					Log.WriteLog(LogType.Trace, "success to set reader settings for reader["+HostName+"] with read operation id["+stReadOp.Id+"]");
					
				}
				else
				{
					Log.WriteLog(LogType.Trace, "success to set reader settings for reader["+HostName+"].");
				}
				
				return ;
			}
            catch (Exception e)
            {
            	Log.WriteLog(LogType.Error, "the gip num index is "+settings.AutoStart.GpiPortNumber+"");
				throw e;
            }


		}

		public void ir_config_settings_write(Settings settings)
		{
			Log.WriteLog(LogType.Trace, "come in ir_config_settings_write");

			try
			{
				// Tell the reader to include the antenna number
				// in all tag reports. Other fields can be added
				// to the reports in the same way by setting the 
				// appropriate Report.IncludeXXXXXXX property.
				settings.Report.IncludeAntennaPortNumber = true;
				
				// Tell the reader to include the Protocol Control 
				// bits in all tag reports. We will need to modify 
				// the PC bits if we change the length of the EPC. 
				settings.Report.IncludePcBits = true;
				

				// Send a tag report for every tag read.
				settings.Report.Mode = ReportMode.Individual;

				// Start reading tags when GPI #1 goes high.
				settings.Gpis.GetGpi(1).IsEnabled = true;
				settings.Gpis.GetGpi(1).DebounceInMs = 50;
				settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
				settings.AutoStart.GpiPortNumber = 1;
				settings.AutoStart.GpiLevel = true;

				// Stop reading tags when GPI #1 goes low.
				settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
				settings.AutoStop.GpiPortNumber = 1;
				settings.AutoStop.GpiLevel = false;

				if (Macro.USE_OPTIMIZE_READ == 1)
				{
					// Create a tag read operation for TID memory.
	                TagReadOp stReadOp = new TagReadOp();
	                // Read from TID memory
	                stReadOp.MemoryBank = MemoryBank.Tid;
	                // Read two (16-bit) words
	                stReadOp.WordCount = 6;
	                // Starting at word 0
	                stReadOp.WordPointer = 0;

	                // Add these operations to the reader as Optimized Read ops.
	                // Optimized Read ops apply to all tags, unlike 
	                // Tag Operation Sequences, which can be applied to specific tags.
	                // Speedway Revolution supports up to two Optimized Read operations.
	                stReadOp.Id = Macro.TAG_OP_ID_WRITE;
	                settings.Report.OptimizedReadOps.Add(stReadOp);

					Log.WriteLog(LogType.Trace, "success to set writer settings for reader["+HostName+"] with read operation id["+stReadOp.Id+"]");
					
				}
				else
				{
					Log.WriteLog(LogType.Trace, "success to set writer settings for reader["+HostName+"]");
				}
				return ;
			}
            catch (Exception e)
            {
            	Log.WriteLog(LogType.Error, "the gip num index is "+settings.AutoStart.GpiPortNumber+"");
				throw e;
            }

			return;
		}


		public void ir_config_settings_check(Settings settings)
		{
			Log.WriteLog(LogType.Trace, "come in ir_config_settings_check");

			try
			{
				// Tell the reader to include the antenna number
				// in all tag reports. Other fields can be added
				// to the reports in the same way by setting the 
				// appropriate Report.IncludeXXXXXXX property.
				settings.Report.IncludeAntennaPortNumber = true;

				// Send a tag report for every tag read.
				settings.Report.Mode = ReportMode.Individual;

				// Start reading tags when GPI #1 goes high.
				settings.Gpis.GetGpi(1).IsEnabled = true;
				settings.Gpis.GetGpi(1).DebounceInMs = 50;
				settings.AutoStart.Mode = AutoStartMode.GpiTrigger;
				settings.AutoStart.GpiPortNumber = 1;
				settings.AutoStart.GpiLevel = true;

				// Stop reading tags when GPI #1 goes low.
				settings.AutoStop.Mode = AutoStopMode.GpiTrigger;
				settings.AutoStop.GpiPortNumber = 1;
				settings.AutoStop.GpiLevel = false;

				if (Macro.USE_OPTIMIZE_READ == 1)
				{
					// Create a tag read operation for TID memory.
	                TagReadOp stReadOp = new TagReadOp();
	                // Read from TID memory
	                stReadOp.MemoryBank = MemoryBank.Tid;
	                // Read two (16-bit) words
	                stReadOp.WordCount = 6;
	                // Starting at word 0
	                stReadOp.WordPointer = 0;

	                // Add these operations to the reader as Optimized Read ops.
	                // Optimized Read ops apply to all tags, unlike 
	                // Tag Operation Sequences, which can be applied to specific tags.
	                // Speedway Revolution supports up to two Optimized Read operations.
	                stReadOp.Id = Macro.TAG_OP_ID_CHECK;
	                settings.Report.OptimizedReadOps.Add(stReadOp);
					

					Log.WriteLog(LogType.Trace, "success to set check settings for reader["+HostName+"] with read operation id["+stReadOp.Id+"]");
				}
				else
				{
					Log.WriteLog(LogType.Trace, "success to set check settings for reader["+HostName+"]");
				}
				return ;
			}
            catch (Exception e)
            {
            	Log.WriteLog(LogType.Error, "the gip num index is "+settings.AutoStart.GpiPortNumber+"");
				throw e;
            }


		}
				
		//公共配置
		public void ir_config_settings_common(Settings settings)
		{
			Log.WriteLog(LogType.Trace, "come in ir_config_settings_common");
			
			try
			{				
                settings.Report.IncludeAntennaPortNumber = true;
				Log.WriteLog(LogType.Trace, "enable include antenna port number");
				
                /*==========设置会话状态==========*/
                settings.Session = 2;
				Log.WriteLog(LogType.Trace, "set reader into session["+settings.Session+"]");

				/*==========设置工作模式==========*/
				LowDutyCycleSettings ldc = new LowDutyCycleSettings();  //低占空比模式
                ldc.EmptyFieldTimeoutInMs = 2000;  	//等待多长时间后，进入低空占比模式
                ldc.FieldPingIntervalInMs = 200;  	//间隔多长时间去扫描一次可视范围
                ldc.IsEnabled = true;  				//是否启动低空占比模式
                settings.LowDutyCycle = ldc;  //KM
				Log.WriteLog(LogType.Trace, "set LowDutyCycleSettings");

				/*==========设置天线参数==========*/
                settings.Antennas.DisableAll();
				Log.WriteLog(LogType.Trace, "disable all antenna");
				
                for (ushort i = 0; i < Antennas.Count; i++)
                {
                    ushort x = Convert.ToUInt16(i + 1);
                    settings.Antennas.GetAntenna(x).IsEnabled = true;
                    settings.Antennas.GetAntenna(x).RxSensitivityInDbm = Convert.ToDouble(Antennas[i].RxPower);  //接收灵敏度
                    settings.Antennas.GetAntenna(x).TxPowerInDbm = Convert.ToDouble(Antennas[i].TxPower); 		 //传输功率
                    settings.Antennas.GetAntenna(x).MaxRxSensitivity = false;
                    settings.Antennas.GetAntenna(x).MaxTransmitPower = false;
                    settings.Antennas.GetAntenna(x).PortNumber = x;
		
                    Log.WriteLog(LogType.Trace, "config antenna[" + x + "] RxSensitivityInDbm[" + Antennas[i].RxPower + "]," +
                        "TxPowerInDbm["+Antennas[i].TxPower+"]," +
                        "MaxRxSensitivity["+settings.Antennas.GetAntenna(x).MaxRxSensitivity+"], MaxTransmitPower["+settings.Antennas.GetAntenna(x).MaxTransmitPower+"], PortNumber["+x+"]");
                }
				Log.WriteLog(LogType.Trace, "set antenna params");

				//上报的扫描数据包括tag id
				//settings.Report.IncludeFastId = true;  

                if (ReaderScanMode == ScanMode.FullScan)
                {				
                    settings.ReaderMode = ReaderMode.AutoSetDenseReader;     //AutoSetDenseReader;自动优化模式 //KM   DenseReaderM8;
                    settings.SearchMode = SearchMode.DualTarget;
					//settings.SearchMode = SearchMode.SingleTarget ;

                    Log.WriteLog(LogType.Trace, "config ReaderMode[" + settings.ReaderMode + "], SearchMode[" + settings.SearchMode + "]");
                }
                else
                {
                    settings.ReaderMode = ReaderMode.AutoSetDenseReader;     //AutoSetDenseReader;    //KM   DenseReaderM8;
                    settings.SearchMode = SearchMode.DualTarget;

                    Log.WriteLog(LogType.Trace, "config ReaderMode[" + settings.ReaderMode + "], SearchMode[" + settings.SearchMode + "]");
                }
				
                return ;

            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                Log.WriteLog(LogType.Error, "Octane SDK exception: "+e.Message+"");

				throw e;
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                Log.WriteLog(LogType.Error,"Exception : "+e.Message+"");
				throw e;
            }


			return;
		}

		//配置读写器
		public bool ir_config_settings(Settings settings, int iReaderType)
		{
			Log.WriteLog(LogType.Trace, "come in ir_config_settings");
			
			try
			{			
				//配置公共属性
				ir_config_settings_common(settings);

				//根据不同的读写器类型，进行相应的参数配置
				switch (iReaderType)
				{
					case Macro.READER_TYPE_READER:
					{
						ir_config_settings_read(settings);
					}
					break;

					case Macro.READER_TYPE_WRITER:
					{
						ir_config_settings_write(settings);
					}
					break;

					case Macro.READER_TYPE_CHECKR:
					{
						ir_config_settings_check(settings);
					}
					break;
										
					default:
					{
						Log.WriteLog(LogType.Error, "error reader type "+iReaderType+" for reader["+HostName+"]");
						return false;
					}
					break;
				}
				


                // Apply the newly modified settings.
                reader.ApplySettings(settings);
				
				Log.WriteLog(LogType.Trace, "success apply new config to reader");
				
                return true;

            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                Log.WriteLog(LogType.Error, "Octane SDK exception: "+e.Message+"");
				Log.WriteLog(LogType.Trace, "error to set settings for reader["+HostName+"]");

				return false;
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                Log.WriteLog(LogType.Error,"Exception : "+e.Message+"");
				Log.WriteLog(LogType.Trace, "error to set settings for reader["+HostName+"]");
				return false;
            }

		}

		
		//连接到读写器
        public bool ir_connectReader()
        {
        	bool bConnectToReader = false;
			
            Log.WriteLog(LogType.Trace, "come in ir_connectReader");

            // Connect to the reader.
            try
            {
				//连到指定的读写器上
                reader.Connect(HostName);
				bConnectToReader = true;
				

				Log.WriteLog(LogType.Trace, "success connect to reader["+HostName+"]");
				
                Settings settings = reader.QueryDefaultSettings();

				
                // Apply the newly modified settings.
                if (!ir_config_settings(settings, iReaderType))
                {
					isConnected = true;
					return false;
				}

				//注册处理事件
				if (Macro.USE_OPTIMIZE_READ == 0)
				{
					if (!ir_register_event_process(reader))
					{
						Log.WriteLog(LogType.Error, "error to call ir_register_event_process for reader["+HostName+"]");
						isConnected = true;
						return false;
					}
				}
				else
				{
					if (!ir_register_event_opProcess(reader))
					{
						Log.WriteLog(LogType.Error, "error to call ir_register_event_process for reader["+HostName+"]");
						isConnected = true;
						return false;
					}

				}
				
                
                
                Log.WriteLog(LogType.Trace, "success to connect the reader["+HostName+"] and apply new settings.");

				
				isConnected = true;
                return true;

            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to use new setting to reader["+HostName+"], the error msg is " + ex.Message + ".");

				//只要调用reader.Connect函数成功，就应该算连接读写器成功
				if (bConnectToReader)
				{
                	isConnected = true;
				}

                return false;
            }
			
            finally
            {

            }
        }

        public bool ir_disconnect()
        {
            Log.WriteLog(LogType.Trace, "come in ir_disconnect");
            try
            {
            	switch (iReaderType)
            	{
					case Macro.READER_TYPE_READER:
					{
						if (Macro.USE_OPTIMIZE_READ == 0)
						{
							reader.TagsReported -= ir_onTagsReported_readTag;  //去绑定tag上报处理函数
						}
						else
						{
							reader.TagOpComplete -= ir_onTagOpComplete_read;

						}
					}
					break;

                    case Macro.READER_TYPE_WRITER:
					{
						if (Macro.USE_OPTIMIZE_READ == 0)
						{
							reader.TagsReported -= ir_onTagsReported_writeTag;  //去绑定tag上报处理函数
							reader.TagOpComplete -= ir_onTagOpComplete_writeConfire;

						}
						else
						{
							reader.TagOpComplete -= ir_onTagOpComplete_write;
						}
						
					}
					break;
					
					case Macro.READER_TYPE_CHECKR:
					{
						if (Macro.USE_OPTIMIZE_READ == 0)
						{
							reader.TagsReported -= ir_onTagsReported_checkTag;	
						}
						else
						{
							reader.TagOpComplete -= ir_onTagOpComplete_check;
						}
					}
					break;
					

					default:
					{
						Log.WriteLog(LogType.Error, "error the reader["+HostName+"] has wrong read type["+iReaderType+"]");
					}
					break;
				}
				
                
                reader.Disconnect();

                Log.WriteLog(LogType.Trace, "success to disconnect from reader");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to disconnect from reader, the error msg is " + ex.Message + ".");

                return false;
            }
            finally
            {

            }

        }

		/*手动启动读写器*/
        public bool ir_startRead()
        {
            Log.WriteLog(LogType.Trace, "come in ir_startRead");

            try
            {
                reader.Start();

                Log.WriteLog(LogType.Trace, "success to start reader");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to start reader, the error msg is " + ex.Message + ".");

                return false;
            }
            finally
            {

            }
        }

		/*手动停止读写器*/
        public bool ir_stopRead()
        {
            Log.WriteLog(LogType.Trace, "come in ir_stopRead");

            try
            {
                reader.Stop();

                Log.WriteLog(LogType.Trace, "success to stop reader");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to stop reader, the error msg is " + ex.Message + ".");

                return false;
            }
        }

		//读读写器上报tag标签，进行去重操作						
		bool ir_deduplicateTagId_read(string sTagId, ref int iRet)
        {
			Log.WriteLog(LogType.Trace, "come in ir_deduplicateTagId_read");

			iRet = Macro.TAG_IN_DUPLICATE;
			
			try
			{
				if (!stBQue.stDeduplicateDic.ContainsKey(sTagId))
				{
					//第一次上报，建立映射节点
					stBQue.stDeduplicateDic.Add(sTagId, Macro.TAG_DEDUPLICATE_READ);

					stStatInfo.iReadCnt ++;
					iRet = Macro.TAG_NOT_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "success to read tag["+sTagId+"] at first time in read process.");
				}
				else
				{
					stStatInfo.iDuplicateReadCnt ++;
					iRet = Macro.TAG_IN_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "the tag["+sTagId+"] has been read before in read process.");					
				}
			}
			catch (System.Exception e)
			{
				Log.WriteLog(LogType.Error, "the error message is ["+e.Message+"].");
				return false;
			}

			return true;
		}

		//写读写器上报tag标签，进行去重操作						
		bool ir_deduplicateTagId_write(string sTagId, ref int iRet)
        {
			Log.WriteLog(LogType.Trace, "come in ir_deduplicateTagId_write");

			iRet = Macro.TAG_IN_DUPLICATE;
			
			try
			{
				//存在并且是第一次上报的
				if (stBQue.stDeduplicateDic.ContainsKey(sTagId) && stBQue.stDeduplicateDic[sTagId] == Macro.TAG_DEDUPLICATE_READ)
				{
					//第一次上报，修改状态值
					stBQue.stDeduplicateDic[sTagId] = Macro.TAG_DEDUPLICATE_WRITE;

					stStatInfo.iWriteCnt ++;
					iRet = Macro.TAG_NOT_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "success to read tag["+sTagId+"] at first time in write process.");
				}
				else
				{
					stStatInfo.iDuplicateWriteCnt ++;
					iRet = Macro.TAG_IN_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "the tag["+sTagId+"] has been read before in write process, the step in memery is["+stBQue.stDeduplicateDic[sTagId]+"] not equal["+Macro.TAG_DEDUPLICATE_READ+"].");					
				}
			}
			catch (System.Exception e)
			{
				Log.WriteLog(LogType.Error, "the error message is ["+e.Message+"].");
				return false;
			}

			return true;
		}

		//写读写器上报tag标签，进行去重操作						
		bool ir_deduplicateTagId_writeConfirm(string sTagId, ref int iRet)
        {
			Log.WriteLog(LogType.Trace, "come in ir_deduplicateTagId_writeConfirm");

			iRet = Macro.TAG_IN_DUPLICATE;
			
			try
			{
				//存在并且是第一次上报的
				if (stBQue.stDeduplicateDic.ContainsKey(sTagId) && stBQue.stDeduplicateDic[sTagId] == Macro.TAG_DEDUPLICATE_WRITE)
				{
					//第一次上报，修改状态值
					stBQue.stDeduplicateDic[sTagId] = Macro.TAG_DEDUPLICATE_WRITE_CONFIRM;

					stStatInfo.iWriteConfirmCnt ++;
					iRet = Macro.TAG_NOT_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "success to read tag["+sTagId+"] at first time in write confirm process.");
				}
				else
				{
					stStatInfo.iDuplicateWriteConfirmCnt ++;
					iRet = Macro.TAG_IN_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "the tag["+sTagId+"] has been read before in write confirm process, the step in memery is["+stBQue.stDeduplicateDic[sTagId]+"] not equal ["+Macro.TAG_DEDUPLICATE_WRITE+"].");					
				}
			}
			catch (System.Exception e)
			{
				Log.WriteLog(LogType.Error, "the error message is ["+e.Message+"].");
				return false;
			}

			return true;
		}

		
		//验读写器上报tag标签，进行去重操作						
		bool ir_deduplicateTagId_check(string sTagId, ref int iRet)
        {
			Log.WriteLog(LogType.Trace, "come in ir_deduplicateTagId_check");

			iRet = Macro.TAG_IN_DUPLICATE;
			
			try
			{
				//存在并且是第一次上报的
				if (stBQue.stDeduplicateDic.ContainsKey(sTagId) && stBQue.stDeduplicateDic[sTagId] == Macro.TAG_DEDUPLICATE_WRITE)
				{
					//第一次上报，修改状态值
					stBQue.stDeduplicateDic[sTagId] = Macro.TAG_DEDUPLICATE_CHECK;

					stStatInfo.iCheckCnt ++;
					iRet = Macro.TAG_NOT_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "success to read tag["+sTagId+"] at first time in check process.");
				}
				else
				{
					stStatInfo.iDuplicateCheckCnt ++;
					iRet = Macro.TAG_IN_DUPLICATE;
					
					Log.WriteLog(LogType.Trace, "the tag["+sTagId+"] has been read before in check process, the step in memery is["+stBQue.stDeduplicateDic[sTagId]+"] not equal ["+Macro.TAG_DEDUPLICATE_WRITE+"].");					
				}
			}
			catch (System.Exception e)
			{
				Log.WriteLog(LogType.Error, "the error message is ["+e.Message+"].");
				return false;
			}

			return true;
		}

		
		//入场tag id进行去重判断;判断tag id是否有重复;只有当tag id是重复的，才会返回false；其他情况都返回true，继续处理；
        bool ir_deduplicateTagId(string sTagId, int iReaderType, ref int iRet)
        {
			Log.WriteLog(LogType.Trace, "come in ir_deduplicateTagId");

			stBQue.stDeduplicateDicMutex.WaitOne();

			switch (iReaderType)
			{
				case Macro.READER_TYPE_READER:
				{
					if (!ir_deduplicateTagId_read(sTagId, ref iRet))
					{
						Log.WriteLog(LogType.Error, "error to call ir_deduplicateTagId_read");

						stBQue.stDeduplicateDicMutex.ReleaseMutex();
						return false;
					}
				}
				break;

				case Macro.READER_TYPE_WRITER:
				{					
					if (!ir_deduplicateTagId_write(sTagId, ref iRet))
					{
						Log.WriteLog(LogType.Error, "error to call ir_deduplicateTagId_write");

						stBQue.stDeduplicateDicMutex.ReleaseMutex();
						return false;
					}
				}
				break;

				case Macro.READER_TYPE_WRITER_CONFIRM:
				{					
					if (!ir_deduplicateTagId_writeConfirm(sTagId, ref iRet))
					{
						Log.WriteLog(LogType.Error, "error to call ir_deduplicateTagId_writeConfirm");

						stBQue.stDeduplicateDicMutex.ReleaseMutex();
						return false;
					}
				}
				break;

				

				case Macro.READER_TYPE_CHECKR:
				{
					if (!ir_deduplicateTagId_check(sTagId, ref iRet))
					{
						Log.WriteLog(LogType.Error, "error to call ir_deduplicateTagId_check");

						stBQue.stDeduplicateDicMutex.ReleaseMutex();
						return false;
					}
				}
				break;

				default:
				{
					Log.WriteLog(LogType.Error, "the reader type is error.");

					stBQue.stDeduplicateDicMutex.ReleaseMutex();
					return false;
				}
				break;
			}

			


			stBQue.stDeduplicateDicMutex.ReleaseMutex();
			return true;
		}

		//生成一个tag info节点。该函数只会在一种情况下发生错误：申请不到内存的情况下。
		TagInfo ir_createTagInfo(Tag tag, string sTagId)
        {
        	Log.WriteLog(LogType.Trace, "come in ir_createTagInfo");

			try
			{
				TagInfo stTagInfo = new TagInfo();

				//将报告上来的信息保存至内存
				stTagInfo.AntennaNo = tag.AntennaPortNumber;
				stTagInfo.sEpc = tag.Epc.ToString();
				stTagInfo.sEpcHx = tag.Epc.ToHexString();
				
				stTagInfo.sTid = sTagId;
				//stTagInfo.sTidHx = sTagId;
				stTagInfo.usPcBits = tag.PcBits;
				stTagInfo.ReaderHostName = HostName;

				//初始化tag info节点的处理状态
				stTagInfo.iTagStep = Macro.TAG_STEP_INIT;
				stTagInfo.iTagState = Macro.TAG_STATE_OK;
				
				Log.WriteLog(LogType.Trace, "success to create tag info for tag["+stTagInfo.sTid+"].");
				
				return stTagInfo;
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to create tag info node, the error msg is ["+ex.Message+"].");
				return null;
			}
		}

		/*处理每一个上报上来的tag标签*/
		bool ir_read_processTag(Tag stTag, string sTagId)
        {
            Log.WriteLog(LogType.Trace, "come in ir_read_processTag");
			
			int iRet = 0;

			Log.WriteLog(LogType.Trace, "get tag from tagOpComplete report, the tag["+sTagId+"]with epc[" + stTag.Epc.ToString() + "], it  is readed "+
				"from reader[" + HostName + "] in antenna[" + stTag.AntennaPortNumber + "]");
				
        	//入场对tag id进行去重处理
			if (!ir_deduplicateTagId(sTagId, Macro.READER_TYPE_READER, ref iRet))
			{
				return false;
			}

			//重复上报的tag
			if (iRet != Macro.TAG_NOT_DUPLICATE)
			{
				return true;
			}
				
			//生成tag info消息节点
			TagInfo stTagInfo = ir_createTagInfo(stTag, sTagId);
			if (null == stTagInfo)
			{
				return false;
			}

			//判断tag id合法性，如不合法，则后续的流程都不用操作
			if (stTagInfo.sTid == "")
			{
				stTagInfo.iTagState = Macro.TAG_STATE_ERROR;
				stStatInfo.iErrorTagInWrite ++;
				Log.WriteLog(LogType.Warning, "the tag id is null");
			}
						
			
			//加入入场队列
			if (!dReadHandler(stTagInfo, null, stBQue.stRList, ref stBQue.stRMutex))
			{
				Log.WriteLog(LogType.Error, "error to insert tag["+stTagInfo.sTid+"] into input list");
				return false;
			}
				
            
			return true;
			
        }

		//写读写器处理tag上报事件
		bool ir_write_processTag(Tag stTag, string sTagId, ImpinjReader sender)
		{
			ushort usTmpEpcOpId = 0, usTmpPcBitOpId = 0;
			int iRet = 0;
			
			Log.WriteLog(LogType.Trace, "come in ir_write_processTag");

			Log.WriteLog(LogType.Trace, "get tag from tagOpComplete report, the tag["+sTagId+"]with epc[" + stTag.Epc.ToString() + "] is readed "+
				"from reader[" + HostName + "] in antenna[" + stTag.AntennaPortNumber + "]");

			//入场对tag id进行去重处理
			if (!ir_deduplicateTagId(sTagId, Macro.READER_TYPE_WRITER, ref iRet))
			{
				return false;
			}

			if (iRet != Macro.TAG_NOT_DUPLICATE)
			{
				return true;
			}


			//进行写操作
			if (!dWriteHandler(null, sender, sTagId,  stBQue.stRList, ref  stBQue.stRMutex,  stBQue.stWList, ref  stBQue.stWMutex, ref usTmpEpcOpId, ref usTmpPcBitOpId, stBQue.stTagDic, stBQue.stTagDicMutex))
			{
				Log.WriteLog(LogType.Error, "error to write tag[" + sTagId + "] epc info.");

				return false;
			}

			usEpcOpId = usTmpEpcOpId;
			usPcBitOpId = usTmpPcBitOpId;
 
            return true;
		}

		//处理写操作的确认信息
		bool ir_write_processConfirm(int iOpId, ref bool bOk)
		{	
			int iRet = 0;

			Log.WriteLog(LogType.Trace, "come in ir_write_processConfirm");
			bOk = false;

			#if false
			//入场对tag id进行去重处理
			if (!ir_deduplicateTagId(sTid, Macro.READER_TYPE_WRITER_CONFIRM, ref iRet))
			{
				return false;
			}
         
			//重复上报的tag
			if (iRet != Macro.TAG_NOT_DUPLICATE)
			{
				return true;
			}
			#endif

		    /*更新tag info写状态*/
			if (!ir_dic_updateWriteState(stBQue.stTagDic, iOpId))
			{				
				return false;
			}
			
			bOk = true;
			return true;					
		}

		

		//定义tag上报处理函数
        bool ir_check_processTag(Tag stTag, string sTagId, ImpinjReader sender)
        {
            Log.WriteLog(LogType.Trace, "come in ir_check_processTag");
			
            
        	int iRet = 0;
				
        	Log.WriteLog(LogType.Trace, "get tag from tagOpComplete report, the tag["+sTagId+"]with epc[" + stTag.Epc.ToString() + "] is readed "+
				"from reader[" + HostName + "] in antenna[" + stTag.AntennaPortNumber + "]");


			//入场对tag id进行去重处理
			if (!ir_deduplicateTagId(sTagId, Macro.READER_TYPE_CHECKR, ref iRet))
			{
				
				return false;
			}

			if (iRet != Macro.TAG_NOT_DUPLICATE)
			{
				return true;
			}
				
			//进行校验操作
			if (!dCheckHandler(sender, sTagId, stTag.Epc.ToString(), stBQue.stWList, stBQue.stWMutex))
			{
                Log.WriteLog(LogType.Error, "error to check tag[" +sTagId + "] epc info.");
				return false;
			}
                
			return true;
			
        }
		
		

		/*在写操作测试前，进行读操作*/
		public void ir_test_forWrite(ImpinjReader sender, TagOpReport report)
        {
            string userData, sTid, sEpc;
            userData = sTid = sEpc = "";
            ScanItemsInStore stScanItem = new ScanItemsInStore();

			Log.WriteLog(LogType.Trace, "come in ir_test_forWrite");


            dReadHandler = stScanItem.ir_handler_readTag;
			
            // Loop through all the completed tag operations
            foreach (TagOpResult stRet in report)
            {
                // Was this completed operation a tag read operation?
                if (stRet is TagReadOpResult)
                {
                    // Cast it to the correct type.
                    TagReadOpResult stRRet = stRet as TagReadOpResult;

                    // Save the EPC
                    sEpc = stRRet.Tag.Epc.ToHexString();

                    // Are these the results for User memory or TID?
                    //if (stRRet.OpId == Macro.TAG_OP_ID_READ)
                    {
                        sTid = stRRet.Data.ToHexString();
						Log.WriteLog(LogType.Trace, "success to get tid["+sTid+"], epc["+sEpc+"] with operation id["+stRRet.OpId+"] in read process.");

						if (!ir_read_processTag(stRRet.Tag, sTid))
						{
							Log.WriteLog(LogType.Error, "Error to call ir_read_processTag");
						}
						
                    }
					#if false
					else
					{
						//tid 操作出错 
						Log.WriteLog(LogType.Error, "the operation id["+stRRet.OpId+"] in   result is not equal with regist operation id["+Macro.TAG_OP_ID_READ+"] in read process.");
					}
					#endif
                }
				else
				{
					Log.WriteLog(LogType.Warning, "the tag operation result is not read result in read process.");
				}
            }

        }

		/*删除操作id对应的tag在字典中的映射*/
		bool ir_dic_updateWriteState(Dictionary<int, TagInfo> stDic, int iOpId)
		{
			Log.WriteLog(LogType.Trace, "come in ir_dic_updateWriteState");

			/*不存在指定的key*/
			if (!stDic.ContainsKey(iOpId))
			{
				Log.WriteLog(LogType.Error, "there is not tag info in the dictionary with op id["+iOpId+"]");
				return false;
			}
			
			TagInfo stTagInfo = stDic[iOpId];
            int iOldState = stTagInfo.iTagWState;

			stTagInfo.iTagWState += 1;

            Log.WriteLog(LogType.Trace, "change write state from[" + iOldState + "] into [" + stTagInfo.iTagWState + "]");

			if (stTagInfo.iTagWState == Macro.TAG_WRITE_FINISH)
			{
				//移除节点
				stDic.Remove(iOpId);
				Log.WriteLog(LogType.Trace, "success to remove tag["+stTagInfo.sTid+"] info from dictionary with op id["+iOpId+"]");
			}

			return true;
					
		}


		/*读读写器处理读操作的结果数据*/
		bool ir_read_procRResult(TagReadOpResult stResult)
		{
			string sTid, sEpc;
			sTid = sEpc = "";
			
			Log.WriteLog(LogType.Trace, "come in ir_read_procRResult");
			
			sEpc = stResult.Tag.Epc.ToHexString();

			if (stResult.OpId == Macro.TAG_OP_ID_READ)
			{
				sTid = stResult.Data.ToHexString();
				Log.WriteLog(LogType.Trace, "success to get tid["+sTid+"], epc["+sEpc+"] with operation id["+stResult.OpId+"] in read process.");

				if (!ir_read_processTag(stResult.Tag, sTid))
				{
					Log.WriteLog(LogType.Error, "Error to call ir_read_processTag");

					stStatInfo.iErrorInRead++;
					return false;
				}

			}
			else
			{
				//tid 操作出错 
				Log.WriteLog(LogType.Error, "the operation id["+stResult.OpId+"] in result is not equal with regist operation id["+Macro.TAG_OP_ID_READ+"] in read process.");
				return false;
			}
			
			return true;		
		}
		

		/*处理写读写器返回的读操作结果*/
		bool ir_write_procRResult(TagReadOpResult stResult, ImpinjReader sender)
		{
			string sTid, sEpc;
            sTid = sEpc = "";			
			
			Log.WriteLog(LogType.Trace, "come in ir_write_procRResult");

			sEpc = stResult.Tag.Epc.ToHexString();

			//根据op id来区分不同的操作
			if (stResult.OpId == Macro.TAG_OP_ID_WRITE)
			{
				sTid = stResult.Data.ToHexString();
				Log.WriteLog(LogType.Trace, "success to get tid["+sTid+"], epc["+sEpc+"] with operation id["+stResult.OpId+"] in write process.");

				if (!ir_write_processTag(stResult.Tag, sTid, sender))
				{
					Log.WriteLog(LogType.Error, "Error to call ir_write_processTag");

					stStatInfo.iErrorInWrite ++;
					return false;
				}

			}
			else
			{
				//tid 操作出错 
				Log.WriteLog(LogType.Error, "the operation id["+stResult.OpId+"] in result is not equal with regist operation id["+Macro.TAG_OP_ID_WRITE+"] in write process.");
				return false;
			}

			return true;
		}



		
		/*处理写读写器的一些写操作结果*/
		bool ir_write_procWResult(TagWriteOpResult stResult)
		{
			int iRet = 0;
			string sTid, sEpc;
			sTid = sEpc = "";
			bool bConfireOk = false;
			
			Log.WriteLog(LogType.Trace, "come in ir_write_procWResult");

			sEpc = stResult.Tag.Epc.ToHexString();
			
			try
			{
				//sTid = stResult.Data.ToHexString();
				Log.WriteLog(LogType.Trace, "success to get tid include   epc["+sEpc+"] with operation id["+stResult.OpId+"] in write confire process.");
				
		        if (stResult.OpId == usEpcOpId)
	            {
	            	/*更新tag info写状态*/
					if (!ir_write_processConfirm(stResult.OpId, ref bConfireOk))
					{
						Log.WriteLog(LogType.Error, "error to call ir_write_processConfirm in ecp operation");

						stStatInfo.iErrorInWriteConfrim ++;
						
						return false;
					}

					if (bConfireOk == true)
					{
						Log.WriteLog(LogType.Trace, "success to   write to EPC with op id["+usEpcOpId+"] complete, the result is "+ stResult.Result+".");
					}
	            }
	            else if (stResult.OpId == usPcBitOpId)
	            {
	            	/*更新tag info写状态*/
					if (!ir_write_processConfirm(stResult.OpId, ref bConfireOk))
					{
						Log.WriteLog(LogType.Error, "error to call ir_write_processConfirm in pc bit operation");

						stStatInfo.iErrorInWriteConfrim ++;
						return false;
					}

					if (bConfireOk == true)
					{
						Log.WriteLog(LogType.Trace, "success to write to PC bits with op id["+usPcBitOpId+"] complete, the result is "+stResult.Result+".");
					}
	            }
				else
				{
					Log.WriteLog(LogType.Error, "Unknow write operation with op id["+stResult.OpId+"]");

					//stStatInfo.iErrorInWriteConfrim ++;
					return false;
				}
				
	            // Print out the number of words written
				Log.WriteLog(LogType.Trace, "Number of words written : "+stResult.NumWordsWritten+".");
			}
			catch (Exception e)
			{
				Log.WriteLog(LogType.Error, "the exception is "+e.Message+"");

				stStatInfo.iErrorInWriteConfrim ++;
				return false;
			}

			return true;
		}

		
		/*处理读操作结果集*/
		bool ir_check_procRResult(TagReadOpResult stResult, ImpinjReader sender)
        {
			string sTid, sEpc;
			sTid = sEpc = "";

			Log.WriteLog(LogType.Trace, "come in ir_check_procRResult");
			
            sEpc = stResult.Tag.Epc.ToHexString();

            if (stResult.OpId == Macro.TAG_OP_ID_CHECK)
            {
                sTid = stResult.Data.ToHexString();
				Log.WriteLog(LogType.Trace, "success to get tid["+sTid+"], epc["+sEpc+"] with operation id["+stResult.OpId+"] in check process.");

				if (!ir_check_processTag(stResult.Tag, sTid, sender))
				{
					Log.WriteLog(LogType.Error, "Error to call ir_check_processTag");
					stStatInfo.iErrorInCheck ++;
					return false;
				}
				
            }
			else
			{
				//tid 操作出错 
				Log.WriteLog(LogType.Error, "the operation id["+stResult.OpId+"] in result is not equal with regist operation id["+Macro.TAG_OP_ID_CHECK+"] in check process.");
				return false;
			}

			return true;
		}
		
        //定义tag上报处理函数
        void ir_onTagOpComplete_read(ImpinjReader sender, TagOpReport report)
        {
            string sTid, sEpc;
            sTid = sEpc = "";
			
			Log.WriteLog(LogType.Trace, "come in ir_onTagOpComplete_read");

			sender.TagOpComplete -= ir_onTagOpComplete_read;
			
            foreach (TagOpResult stRet in report)
            {
                if (stRet is TagReadOpResult)
                {
                    TagReadOpResult stRRet = stRet as TagReadOpResult;

					if (stRRet.Result != ReadResultStatus.Success)
					{
                        Log.WriteLog(LogType.Error, "read operation with op id["+stRRet.OpId+"] failed : {" + stRRet.Result + "} in read process.");
						continue;
					}
								
					if (!ir_read_procRResult(stRRet))
					{
						Log.WriteLog(LogType.Error, "Error to call ir_read_procRResult");
					}
                }
				else
				{
					Log.WriteLog(LogType.Warning, "the tag operation result is not read result in read process.");
				}
            }

            sender.TagOpComplete += ir_onTagOpComplete_read;

			return;
        }

		//定义tag上报处理函数
        void ir_onTagOpComplete_write(ImpinjReader sender, TagOpReport report)
        {
			Log.WriteLog(LogType.Trace, "come in ir_onTagOpComplete_write");

			sender.TagOpComplete -= ir_onTagOpComplete_write;
			
			#if false
			if (bTest)
			{
				ir_test_forWrite(sender, report);
				bTest = false;
			}
			#endif


            //遍历所有op complete的返回结果
            foreach (TagOpResult stRet in report)
            {
                if (stRet is TagReadOpResult)
                {
                    TagReadOpResult stRResult = stRet as TagReadOpResult;

					if (stRResult.Result != ReadResultStatus.Success)
					{
                        Log.WriteLog(LogType.Error, "read operation with op id["+stRResult.OpId+"] failed : {" + stRResult.Result + "} in write process.");
						continue;
					}
										
					if (!ir_write_procRResult(stRResult, sender))
					{
						Log.WriteLog(LogType.Error, "error to call ir_write_procRResult");
					}

                }
				else if (stRet is TagWriteOpResult)
				{
                    TagWriteOpResult stWResult = stRet as TagWriteOpResult;

					if (stWResult.Result != WriteResultStatus.Success)
					{
                        Log.WriteLog(LogType.Error, "write operation with op id["+stWResult.OpId+"] failed : {" + stWResult.Result + "} in write process.");
						continue;
					}
										
					if (!ir_write_procWResult(stWResult))
					{
						Log.WriteLog(LogType.Error, "error to call ir_writeTag_procWResult");
					}

	            }
				else
				{
					Log.WriteLog(LogType.Warning, "unknow the tag operation result type.");
				}
            }

            sender.TagOpComplete += ir_onTagOpComplete_write;
        }

		
		//定义tag上报处理函数
        void ir_onTagOpComplete_check(ImpinjReader sender, TagOpReport report)
        {
            string userData, sTid, sEpc;
            userData = sTid = sEpc = "";
			
			Log.WriteLog(LogType.Trace, "come in ir_onTagOpComplete_check");

			sender.TagOpComplete -= ir_onTagOpComplete_check;
			
            foreach (TagOpResult stRet in report)
            {
                if (stRet is TagReadOpResult)
                {
                    TagReadOpResult stCRet = stRet as TagReadOpResult;
                    
					if (stCRet.Result != ReadResultStatus.Success)
					{
                        Log.WriteLog(LogType.Error, "read operation with op id["+stCRet.OpId+"] failed : {" + stCRet.Result + "} in check process.");
						continue;
					}
										
					if (!ir_check_procRResult(stCRet, sender))
					{
						Log.WriteLog(LogType.Error, "error to call ir_check_procRResult");
					}
					
                }
				else
				{
					Log.WriteLog(LogType.Warning, "the tag operation result is not read result in check process.");
				}
            }

            sender.TagOpComplete += ir_onTagOpComplete_check;
        }

		//定义tag写完成报告处理函数
        void ir_onTagOpComplete_writeConfire(ImpinjReader sender, TagOpReport report)
        {
        	bool bOk = true;
			
        	Log.WriteLog(LogType.Trace, "come in ir_onTagOpComplete_writeConfire");


			try
			{
	            // Loop through all the completed tag operations.
	            foreach (TagOpResult result in report)
	            {
	                // Was this completed operation a tag write operation?
	                if (result is TagWriteOpResult)
	                {
	                    // Cast it to the correct type.
	                    TagWriteOpResult writeResult = result as TagWriteOpResult;

						if (writeResult.Result != WriteResultStatus.Success)
						{

                            Log.WriteLog(LogType.Error, "write confirm operation with op id[" + writeResult.OpId + "] failed : {" + writeResult.Result + "} in write confirm process.");
							continue;
						}
											
	                    if (writeResult.OpId == usEpcOpId)
	                    {
	                        
							Log.WriteLog(LogType.Trace, "Write to EPC with op id["+usEpcOpId+"] complete, the result is "+ writeResult.Result+".");
	                    }
                        else if (writeResult.OpId == usPcBitOpId)
                        {

                            Log.WriteLog(LogType.Trace, "Write to PC bits with op id[" + usPcBitOpId + "] complete, the result is " + writeResult.Result + ".");
                        }
                        else
                        {
                            Log.WriteLog(LogType.Error, "unknow op id[" + writeResult.OpId + "]");
                            bOk = false;
                        }
	                    // Print out the number of words written

						Log.WriteLog(LogType.Trace, "Number of words written : "+writeResult.NumWordsWritten+".");
	                }
					else if (result is TagReadOpResult)
					{
						TagReadOpResult readResult = result as TagReadOpResult;
						
						Log.WriteLog(LogType.Warning, "the result report for tag is read report, the op id["+readResult.OpId+"], the result is " +readResult.Result);
						bOk = false;
					}
					else
					{
						Log.WriteLog(LogType.Warning, "the result report for tag is not write report");
						bOk = false;
					}
	            }

				//设置tag的写状态
	            if (bOk)
	            {
	            	
					
	                TagInfo stTagInfo = stBQue.stTagDic[usEpcOpId];
	                stTagInfo.iTagWState = Macro.TAG_WRITE_FINISH;

	                Log.WriteLog(LogType.Trace, "success to set tag[" + stTagInfo.sTid + "] write state into finish.");

					//移除节点
					stBQue.stTagDicMutex.WaitOne();
					stBQue.stTagDic.Remove(usEpcOpId);
					stBQue.stTagDicMutex.ReleaseMutex();
					Log.WriteLog(LogType.Trace, "success to remove tag info from dictionary with ecp op id["+usEpcOpId+"]");
	            }
			}
			catch (Exception e)
			{
				Log.WriteLog(LogType.Error, "the exception is "+e.Message+"");
			}
        }
		
		
        //定义tag上报处理函数
        void ir_onTagsReported_readTag(ImpinjReader sender, TagReport report)
        {
            Log.WriteLog(LogType.Trace, "come in ir_onTagsReported_readTag");
			
			Log.WriteLog(LogType.Trace, "there are "+report.Tags.Count()+" tags in the read report");

			//不再接收tag report
			sender.TagsReported -= ir_onTagsReported_readTag;
			
            foreach (Tag tag in report)
            {
            	int iRet = 0;
				
            	Log.WriteLog(LogType.Trace, "get tag from tagreport, the tag["+tag.Tid.ToString()+"]with epc[" + tag.Epc.ToString() + "] is readed "+
					"from reader[" + HostName + "] in antenna[" + tag.AntennaPortNumber + "]");
				
            	//入场对tag id进行去重处理
				if (!ir_deduplicateTagId(tag.Tid.ToString(), Macro.READER_TYPE_READER, ref iRet))
				{
					stStatInfo.iErrorInRead++;
					continue;
				}

				//重复上报的tag
				if (iRet != Macro.TAG_NOT_DUPLICATE)
				{
					continue;
				}
				
				//生成tag info消息节点
				TagInfo stTagInfo = ir_createTagInfo(tag, "");
				if (null == stTagInfo)
				{
					stStatInfo.iErrorInRead++;

					sender.TagsReported += ir_onTagsReported_readTag;
					return;
				}

				//判断tag id合法性，如不合法，则后续的流程都不用操作
				if (stTagInfo.sTid == "")
				{
					stTagInfo.iTagState = Macro.TAG_STATE_ERROR;
					stStatInfo.iErrorTagInRead ++;
					Log.WriteLog(LogType.Warning, "the tag id is null");
				}
							
				
				//加入入场队列
				if (!dReadHandler(stTagInfo, null, stBQue.stRList, ref stBQue.stRMutex))
				{
					stStatInfo.iErrorInRead++;
					Log.WriteLog(LogType.Error, "error to insert tag["+stTagInfo.sTid+"] into input list");
				}
				
            }

			sender.TagsReported += ir_onTagsReported_readTag;
        }




		

		
        //写读写器处理tag上报事件
        void ir_onTagsReported_writeTag(ImpinjReader sender, TagReport report)
        {
            Log.WriteLog(LogType.Trace, "come in ir_onTagsReported_writeTag");
			
			Log.WriteLog(LogType.Trace, "there are "+report.Tags.Count()+" tags in the report");

			//不再接收tag report
			sender.TagsReported -= ir_onTagsReported_writeTag;
			
            foreach (Tag tag in report)
            {
            	ushort usTmpEpcOpId = 0, usTmpPcBitOpId = 0;
				int iRet = 0;
				
            	Log.WriteLog(LogType.Trace, "get tag from tagreport, the tag["+tag.Tid.ToString()+"]with epc[" + tag.Epc.ToString() + "] is readed "+
					"from reader[" + HostName + "] in antenna[" + tag.AntennaPortNumber + "]");

            	//入场对tag id进行去重处理
				if (!ir_deduplicateTagId(tag.Tid.ToString(), Macro.READER_TYPE_WRITER, ref iRet))
				{
					stStatInfo.iErrorInWrite ++;
					continue;
				}

				if (iRet != Macro.TAG_NOT_DUPLICATE)
				{
					continue;
				}

					
				//进行写操作
                if (!dWriteHandler(null, sender, tag.Tid.ToString(), stBQue.stRList, ref stBQue.stRMutex, stBQue.stWList, ref stBQue.stWMutex, ref usTmpEpcOpId, ref usTmpPcBitOpId, stBQue.stTagDic, stBQue.stTagDicMutex))
				{
                    Log.WriteLog(LogType.Error, "error to write tag[" + tag.Tid.ToString() + "] epc info.");
					stStatInfo.iErrorInWrite ++;
				}

				usEpcOpId = usTmpEpcOpId;
				usPcBitOpId = usTmpPcBitOpId;

   
            }
			
			//再次接收tag report
			sender.TagsReported += ir_onTagsReported_writeTag;
			
        }



		//定义tag上报处理函数
        void ir_onTagsReported_checkTag(ImpinjReader sender, TagReport report)
        {
            Log.WriteLog(LogType.Trace, "come in ir_onTagsReported_checkTag");
			
			Log.WriteLog(LogType.Trace, "there are "+report.Tags.Count()+" tags in the check report");

			//不再接收tag report
			sender.TagsReported -= ir_onTagsReported_checkTag;
			
            foreach (Tag tag in report)
            {
            	int iRet = 0;
				
            	Log.WriteLog(LogType.Trace, "get tag from tagreport, the tag["+tag.Tid.ToString()+"]with epc[" + tag.Epc.ToString() + "] is readed "+
					"from reader[" + HostName + "] in antenna[" + tag.AntennaPortNumber + "]");


				//入场对tag id进行去重处理
				if (!ir_deduplicateTagId(tag.Tid.ToString(), Macro.READER_TYPE_CHECKR, ref iRet))
				{
					continue;
				}

				if (iRet != Macro.TAG_NOT_DUPLICATE)
				{
					continue;
				}
				
				//进行写操作
				if (!dCheckHandler(sender, tag.Tid.ToString(), tag.Epc.ToString(), stBQue.stWList, stBQue.stWMutex))
				{
                    Log.WriteLog(LogType.Error, "error to write tag[" + tag.Tid.ToString() + "] epc into.");
				}
                
            }
			
			//再次接收tag report
			sender.TagsReported += ir_onTagsReported_checkTag;
			
        }
		

		// This event handler gets called when the reader is started.
		static void OnReaderStarted(ImpinjReader reader, ReaderStartedEvent e)
		{
			Console.WriteLine("Reader started {0}", reader.Address);
		}

		// This event handler gets called when the reader is stopped.
		static void OnReaderStopped(ImpinjReader reader, ReaderStoppedEvent e)
		{
			Console.WriteLine("Reader stopped : {0}", reader.Address);
		}

		// This event handler gets called when a GPI event occurs.
		static void OnGpiEvent(ImpinjReader sender, GpiEvent e)
		{
			Console.WriteLine("A GPI event occurred.");
			Console.WriteLine("Port : {0} State : {1}\n", 
			e.PortNumber, e.State);
		}

		// This event handler gets called when an antenna event occurs.
		static void OnAntennaEvent(ImpinjReader sender, AntennaEvent e)
		{
			Console.WriteLine("An antenna event occurred.");
			Console.WriteLine("Port : {0} State : {1}\n",
			e.PortNumber, e.State);
		}


        ~ImpinjRevolution()
        {
            reader = null;
        }


    }

	




	

    public enum ScanMode
    {
        ScanItem = 1,
        FullScan = 2
    }
}
