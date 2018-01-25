using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.Util;

namespace ssms.Pages.Products
{
    public partial class AddProduct : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;

		/*清空已填信息*/
		private void cleardata()
		{
			this.tProduceName.Clear();
            this.tProduceDesc.Clear();
            this.tProduceBarcode.Clear();
			this.tBasicEpc.Clear();
		}

		
		/*添加bracode*/
        private int addBarcode(string sBarcodeNumber, ref int iID)
        {
            LTS.Barcode stBarcode = new LTS.Barcode(); ;

			stBarcode.BarcodeNumber = this.tProduceBarcode.Text;

            /*category添加到数据库*/
            iID = DAT.DataAccess.AddBarcode(stBarcode);
			if (iID !=-1)
			{
                Log.WriteLog(LogType.Trace, "success to insert barcode with number[" + stBarcode.BarcodeNumber + "] and id[" + iID + "]into db.");
                
				return 1;
			}
			else
			{
                Log.WriteLog(LogType.Error, "error to insert barcode with name[" + stBarcode.BarcodeNumber + "] into db.");
                
				return 0;
			}
        }

		/*添加product到数据库*/
		private int addProduct(string sProductName, string sProductDesc, int iBarcodeId, 
			int iBrandId, int iCategoryId, ref int iID, string sBasicEpc)
        {

			
            LTS.Product stProduct = new LTS.Product(); 
			stProduct.BarcodeID = iBarcodeId;
			stProduct.BrandID = iBrandId;
			stProduct.CategoryID = iCategoryId;
			stProduct.ProductName = sProductName;
			stProduct.ProductDescription = sProductDesc;
            stProduct.BasicEpc = sBasicEpc;
			
			Log.WriteLog(LogType.Trace, "test22 the basic epc is ["+ sBasicEpc+"], the product epc is "+stProduct.BasicEpc+".");

			
            /*category添加到数据库*/
            iID = DAT.DataAccess.AddProduct(stProduct);
			if (iID !=-1)
			{
                Log.WriteLog(LogType.Trace, "success to insert product with number[" + sProductName + "] and id[" + iID + "]into db.");
                
				return 1;
			}
			else
			{
                Log.WriteLog(LogType.Error, "error to insert product with name[" + sProductName + "] into db.");
                
				return 0;
			}
        }
				
        public AddProduct()
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

       
		/*新增生产商*/
        private void AddBrand_Click(object sender, EventArgs e)
        {
            bAddProduce.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
           

            ChangeView<Items.AddBrandSmall>();
        }

		/*新增产品类型*/
        private void AddCategory_Click(object sender, EventArgs e)
        {
            bAddProduce.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            
            ChangeView<Items.AddCategorySmall>();
        }

		/*初始化produce添加页面，加载厂家信息和产品类型信息*/
        private void AddProduct_Load(object sender, EventArgs e)
        {
            //load brand names into combo box from db
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            //load category names into combo box from db
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;
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

            bAddProduce.Enabled = true;
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

            bAddProduce.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
           
        }

        

        private void back_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

		
    
	
		
		/*添加产品*/
        private void addProduce_Click(object sender, EventArgs e)
        {
            int iRet;
            int iBarcodeID = 0;
            int iProduceId = 0;
            string sBrandName, sCategoryName;

            
            
			/*名字合法性判断*/
            if (!ParamValid.IsNumAndEnCh(tProduceName.Text) || !ParamValid.IsNumAndEnCh(tProduceBarcode.Text))
            {
                Log.WriteLog(LogType.Trace, "the produce name[" + tProduceName.Text + "] and produce barcode[" + tProduceBarcode.Text + "] must be char and digit string");
                MessageBox.Show("the produce name[" + tProduceName.Text + "] and produce barcode[" + tProduceBarcode.Text + "] must be char and digit string");
                return;
            }

            /*判断basic epc的合法性*/
            if (tBasicEpc.Text.Length == 0 || !ParamValid.IsNumAndEnCh(tBasicEpc.Text))
            {
                Log.WriteLog(LogType.Trace, "the produce basic epc[" + tBasicEpc.Text + "] must be char and digit string");
                MessageBox.Show("the produce basic epc[" + tBasicEpc.Text + "] must be char and digit string");
                return;
            }
				
            /*去重*/
            if (comboBoxBrand.SelectedIndex > -1 && comboBoxCategory.SelectedIndex > -1)
            {
            	int iCategoryId = 0, iBrandId = 0;
				
                sBrandName = comboBoxBrand.SelectedItem.ToString();
                sCategoryName = comboBoxCategory.SelectedItem.ToString();

                iRet = Db.ProductIsExist(tProduceName.Text, sBrandName, sCategoryName, ref iProduceId);
                if (iRet == -1)
                {
                    Log.WriteLog(LogType.Error, "error to call ProductIsExist");
                    //MessageBox.Show("error to call ProductIsExist");
                    return;
                }
                else if(iRet == 1)
                {
                    MessageBox.Show("the name[" + tProduceName.Text + "] has been use in brand[" + sBrandName + "] category["+sCategoryName+"],you should use another name.");
                    return;
                }

				/*获取category在数据库中的id*/
				iCategoryId = Db.CategoryGetID(sCategoryName);
				if (iCategoryId <= 0)
				{
					MessageBox.Show("there is not category["+sCategoryName+"] in system");
					return;
				}

				/*获取brand在数据库中的id*/
				iBrandId = Db.BrandGetID(sBrandName);
				if (iBrandId <= 0)
				{
					MessageBox.Show("there is not brand["+sBrandName+"] in system");
					return;
				}

                /*获得条形码在数据库中的ID*/
			#if  false
                if (-1 == Db.BarcodeIsExist(tProduceBarcode.Text, ref iBarcodeID))
                {
                    MessageBox.Show("error to get barcode id");
                    return;
                }
				else if (iBarcodeID > 0)
				{
					//条形码已经被使用，必须输入没有被使用过的条形码
				}
                else if (iBarcodeID == 0)
                {
                    /*添加barcode，并返回barcode在数据库的ID*/
                    if (0 == addBarcode(tProduceBarcode.Text, ref iBarcodeID))
                    {
                        MessageBox.Show("error to add barcode name[" + tProduceBarcode.Text + "] into db.");
                        return;
                    }
                }
			#else
				/*一个barcode只能被一个product使用，所以在此判断barcode是否有被其他product使用*/
				if (-1 == Db.BarcodeHadBeenUse(tProduceBarcode.Text, ref iProduceId))
                {
                    MessageBox.Show("error to check whether barcode has been use");
                    return;
                }
				else if (iProduceId > 0)
				{
					//条形码已经被使用，必须输入没有被使用过的条形码
					Log.WriteLog(LogType.Trace, "info:the barcode["+ tProduceBarcode.Text +"] has been use by product["+iProduceId+"], please change it");
					MessageBox.Show("the barcode has been use by product["+iProduceId+"], please change it");
                    return;
				}
                else  //(iProduceId == 0)
                {
                    /*添加barcode，并返回barcode在数据库的ID*/
                    if (0 == addBarcode(tProduceBarcode.Text, ref iBarcodeID))
                    {
                        MessageBox.Show("error to add barcode name[" + tProduceBarcode.Text + "] into db.");
                        return;
                    }
                }
			#endif

				Log.WriteLog(LogType.Trace, "test11 the basic epc is ["+  tBasicEpc.Text+"].");
			
				/*将produce信息添加到数据库*/
				if (0 != addProduct(tProduceName.Text, tProduceDesc.Text, iBarcodeID, iBrandId, iCategoryId,ref iProduceId, tBasicEpc.Text))
				{
					MessageBox.Show("success to add product name[" + tProduceName.Text + "] into db.");
					cleardata();
				}
				else
				{
					Log.WriteLog(LogType.Trace, "test222 the basic epc is ["+  tBasicEpc.Text+"].");

					
					/*删除上面建立的barcode记录*/
					Db.BarcodeDelRecode(iBarcodeID);
					MessageBox.Show("error to add product with name[" + tProduceName.Text + "] into db.");
				}
            }
        }
    }
}
