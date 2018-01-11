using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;


using ssms.Util;

namespace ssms.Pages.Products
{
    public partial class UpdateProduct : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
		int gProductId;
		string gProductName, gProductDesc, gBarcode, gBrandName, gCategoryName;
		
		private void UpdateProduct_Load(object sender, EventArgs e)
		{
			Log.WriteLog(LogType.Trace, "come in UpdateProduct_Load");
			
			/*加载从数据库中store信息*/
			DataTable stDt = Db.ProductGetInfo();
			if (stDt == null)
			{
				Log.WriteLog(LogType.Error, "error to call ProductGetInfo");
				return;
			}

			if (stDt.Rows.Count > 0)
			{
				Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] product records in db, goto show them");
				for (int n = 0; n < stDt.Rows.Count; n++)
				{
					Log.WriteLog(LogType.Trace, "begin to load product info into front");
					
					dgvProducts.Rows.Add(stDt.Rows[n]["ProductID"], stDt.Rows[n]["ProductName"], stDt.Rows[n]["ProductDescription"],
						stDt.Rows[n]["BarcodeNumber"], stDt.Rows[n]["BrandName"], stDt.Rows[n]["CategoryName"]);
				

				Log.WriteLog(LogType.Trace, "end to load product info into front");

				}
				Log.WriteLog(LogType.Trace, "success to load product info into front");
			}
			else
			{
				Log.WriteLog(LogType.Trace, "there is not product records in db, no need to show");
				
			}

			doneBrand();
			doneCategory();

			comboBoxBrand.Text = "";
            comboBoxCategory.Text = "";
			return;
					
		}

		private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow.Index > -1)
            {

                /*获取选中的信息*/
				gProductId = int.Parse(dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[0].Value.ToString());
                gProductName = tProductName.Text = dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[1].Value.ToString();
                gProductDesc = tProductDesc.Text = dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[2].Value.ToString();
                gBarcode = tBarcode.Text = dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[3].Value.ToString();
                gBrandName = comboBoxBrand.Text = dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[4].Value.ToString();
                gCategoryName = comboBoxCategory.Text = dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[5].Value.ToString();

            }
        }
				
        public UpdateProduct()
        {
            InitializeComponent();
        }

        public void ChangeView<T>() where T : Control, new()
        {
            try
            {

                panel1.Controls.Clear();
                T find = new T();
                find.Parent = panel1;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }

        private void bAddBrand_Click(object sender, EventArgs e)
        {
            bAdd.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            

            ChangeView<Items.AddBrandSmall>();
        }

        private void bAddCategory_Click(object sender, EventArgs e)
        {
            bAdd.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            
            ChangeView<Items.AddCategorySmall>();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }



        //after a brand is added in the small panel you need to update the combobox
        public void doneBrand()
        {
            panel1.Controls.Clear();
            comboBoxBrand.DataSource = null;
            if (listB != null)
            {
                listB.Clear();
            }

            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            bAdd.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            
        }

        //after a category is added in the small panel you need to update the combobox
        public void doneCategory()
        {
            panel1.Controls.Clear();
            comboBoxCategory.DataSource = null;
            if (listC != null)
            {
                listC.Clear();
            }

            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            bAdd.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            
        }

        private int getCateOgryID(string sCategoryName)
        {
        	int iCategoryID;
			
        	Log.WriteLog(LogType.Trace, "come in getCateOgryID");
            /*获取category的id*/
            string sSql = "select CategoryID from Category where CategoryName = '" + sCategoryName + "';";

			try
			{
            	DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
            	if (stDs.Tables[0].Rows.Count != 1)
	            {
	                Log.WriteLog(LogType.Trace, "error:there is not category with name[" + sCategoryName + "], the impossible");

	                MessageBox.Show("error:there is not category with name[" + sCategoryName + "], the impossible");
	                return 0;
	            }

				iCategoryID = Int32.Parse(stDs.Tables[0].Rows[0]["CategoryID"].ToString());
				Log.WriteLog(LogType.Trace, "success to get  category id["+iCategoryID+"] with name[" + sCategoryName + "]");
            	return iCategoryID;
			}
            catch (Exception ex)
            {
                MessageBox.Show("error to get category with name["+sCategoryName+"]");
                return 0;
            }

        }

		private int getBrandID(string sBrandName)
        {
        	Log.WriteLog(LogType.Trace, "come in getBrandID");

			int iBrandID;
			
            /*获取brand的id*/
            string sSql = "select BrandID from Brand where BrandName = '" + sBrandName + "';";

			try
			{
            	DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
            	if (stDs.Tables[0].Rows.Count != 1)
	            {
	                Log.WriteLog(LogType.Trace, "error:there is not brand with name[" + sBrandName + "], the impossible");

	                MessageBox.Show("error:there is not brand with name[" + sBrandName + "], the impossible");
	                return 0;
	            }
				iBrandID = Int32.Parse(stDs.Tables[0].Rows[0]["BrandID"].ToString());

				Log.WriteLog(LogType.Trace, "success to get   brand   id["+iBrandID+"] with name[" + sBrandName + "]");
            	return iBrandID;
			}
            catch (Exception ex)
            {
                MessageBox.Show("error to get brand with name["+CategoryName+"]");
				
                return 0;
            }

        }

		private int getBarcodeID(string sBarcodeNumber)
        {
        	Log.WriteLog(LogType.Trace, "come in GetBarcodeID");
			int iBarcodeID;
			
            /*获取brand的id*/
            string sSql = "select BarcodeID from Barcode where BarcodeNumber = '" + sBarcodeNumber + "';";

			try
			{
            	DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
            	if (stDs.Tables[0].Rows.Count != 1)
	            {
	                Log.WriteLog(LogType.Trace, "info:there is not barcodeId with name[" + sBarcodeNumber + "], will goto create it");
	                return 0;
	            }
				iBarcodeID = Int32.Parse(stDs.Tables[0].Rows[0]["BarcodeID"].ToString());
				Log.WriteLog(LogType.Trace, "success to get   barcode   id["+iBarcodeID+"] with name[" + sBarcodeNumber + "]");
            	return iBarcodeID;
			}
            catch (Exception ex)
            {
                MessageBox.Show("error to get barcode with name["+sBarcodeNumber+"]");
                return 0;
            }

        }
				
		private bool UpdateProduct_Params2Db(string sCategoryName, string sBrand, string sBarcode, int iProductID, string sProductName, string sProductDesc)
        {
            Log.WriteLog(LogType.Trace, "come in UpdateProduct_Params2Db");
			string sSql;
			int iCateogryID, iBrandID, iBarcodeID, iPid = 0;
			bool bRet;
			
			iCateogryID = getCateOgryID(sCategoryName);
			iBrandID = getBrandID(sBrand);
			iBarcodeID = getBarcodeID(sBarcode);

			/*厂商和类型不能为空*/
			if (iCateogryID == 0 || iBrandID == 0 )
			{
				Log.WriteLog(LogType.Error, "error to get category   or brand id.");
				return false;
			}

			/*一个barcode只能被一个product使用，所以在此判断barcode是否有被其他product使用*/
			if (-1 == Db.BarcodeHadBeenUse(sBarcode, ref iPid))
			{
				Log.WriteLog(LogType.Error, "error to check whether barcode["+sBarcode+"] has been use.");
				
				return false;
			}
			else if (iPid > 0)
			{
				//条形码已经被使用，必须输入没有被使用过的条形码
				Log.WriteLog(LogType.Trace, "info:the barcode["+ sBarcode+"] has been use by product["+iPid+"], please change it");
				MessageBox.Show("the barcode has been use by product["+iPid+"], please change it");
				return false;
			} 

			/*将最新的product信息写入数据库*/	
			#if false  //modify at 20171202
			string sCommStr = "Data Source=.; Initial Catalog=ssms; UID=sa;PASSWORD=123456;pooling=false; ";
			#else
			string sCommStr = Properties.Settings.Default.ssmsConnectionString;
			#endif
			using (SqlConnection conn = new SqlConnection(sCommStr))
			{
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
				
                try
                {
                    Log.WriteLog(LogType.Trace, "begin update product["+sProductName+"] with id["+iProductID+"] transition" );

					if (0 == iBarcodeID)
					{
						/*插入reader记录*/
                        sSql = "INSERT INTO Barcode(BarcodeNumber) VALUES('" +sBarcode  + "') select @@identity;";
						cmd.CommandText = sSql;
                        iBarcodeID = Convert.ToInt32(cmd.ExecuteScalar());
                        Log.WriteLog(LogType.Trace, "success to exec sql[" + sSql + "];");
					}

					/*更新product记录*/
					sSql = "update Product set ProductName = '" + sProductName + "', ProductDescription = '" + sProductDesc + "', BarcodeID = "+iBarcodeID+", BrandID = "+iBrandID+", CategoryID = "+iCateogryID+" where ProductID = " + iProductID + ";";
					cmd.CommandText = sSql;
					cmd.ExecuteNonQuery();

					Log.WriteLog(LogType.Trace, "success to exec sql[" + sSql + "];");

                    tx.Commit();
                    Log.WriteLog(LogType.Trace, "end update product transition");
					MessageBox.Show(Macro.SUCCESS_UPDATE_PRODUCT);

					bRet= true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();

                    Log.WriteLog(LogType.Error, "error to exec sql transition, the error info is [" + E.Message + "]");

					//MessageBox.Show(E.Message);
					
                    throw new Exception(E.Message);
					
					bRet =  false;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

            return bRet;
        }


        private void bAdd_Click(object sender, EventArgs e)
        {
            string sProductName, sProductDesc, sBarcode, sBrandName, sCategoryName;
            int iRet, iRdID = 0;

            sProductName = tProductName.Text;
			sProductDesc = tProductDesc.Text;
			sBarcode = tBarcode.Text;
			sBrandName = comboBoxBrand.Text;
			sCategoryName = comboBoxCategory.Text;

            /*参数不能为空*/
            if (!String.IsNullOrWhiteSpace(sProductName) &&
                !String.IsNullOrWhiteSpace(sProductDesc) &&
                !String.IsNullOrWhiteSpace(sBarcode) &&
                !String.IsNullOrWhiteSpace(sBrandName) &&
                !String.IsNullOrWhiteSpace(sCategoryName) )
            {
                if (String.Equals(sProductName, gProductName) == false ||
                    String.Equals(sProductDesc, gProductDesc) == false ||
                    String.Equals(sBarcode, gBarcode) == false ||
                    String.Equals(sBrandName, gBrandName) == false ||
                    String.Equals(sCategoryName, gCategoryName) == false )
                {
                    /*去重*/
                    iRet = Db.ProductIsExist(sProductName, sBrandName, sCategoryName, ref iRdID);
                    if (iRet == -1)
                    {
                        Log.WriteLog(LogType.Error, "error to call ProductIsExist");
                        //MessageBox.Show("error to call ProductIsExist");
                        return;
                    }
                    else if (iRet == 1 && iRdID != gProductId)
                    {
                        MessageBox.Show("the name[" + sProductName + "] has been use in brand["+sBrandName+"] category["+sCategoryName+"],you should use another name.");
                        return;
                    }

                    /*更新数据库*/
                    if (!UpdateProduct_Params2Db(sCategoryName, sBrandName, sBarcode, gProductId, sProductName, sProductDesc))
                    {
                        //Log.WriteLog(LogType.Error, "error to call UpdateProduct_Params2Db");
                        //MessageBox.Show("error to call UpdateProduct_Params2Db");
                        return;
                    }

                    dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[1].Value = sProductName;
                    dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[2].Value = sProductDesc;
					dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[3].Value = sBarcode;
					dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[4].Value = sBrandName;
					dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[5].Value = sCategoryName;
										

					Log.WriteLog(LogType.Trace, "success to update product[" + gProductId + "] with new params:name[" + sProductName + "] description[" + sProductDesc + "], barcode["+sBarcode+"], brand["+sBrandName+"], cateogry["+sCategoryName+"]");
					
                    /*清空选中的product信息*/
                    gProductDesc = sProductDesc;
                    gProductName = sProductName;
             
					gCategoryName = sCategoryName;
					gBarcode = sBarcode;
					gBrandName = sBrandName;
                }
            }
            else
            {
                MessageBox.Show("please input the name and description");
            }
        }
    }
}
