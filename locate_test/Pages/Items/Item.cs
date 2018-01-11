using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssms.DataClasses;

using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using ssms.Util;


namespace ssms.Pages.Items
{
    public partial class Items : UserControl
    {
        List<ItemMain> imList = new List<ItemMain>();
        public Items()
        {
            InitializeComponent();
        }
		
        private void item_load(object sender, EventArgs e)
        {
			Log.WriteLog(LogType.Trace, "come in item_load");
            radioAll.Checked = true;

        }

        private void item_addItem_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_addItem_click");
            ((Main)this.Parent.Parent).ChangeView<AddStock>();
        }

		
        private void item_updateItem_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_updateItem_click");
            ((Main)this.Parent.Parent).ChangeView<UpdateItem>();
        }

        private void item_viewItem_cick(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_viewItem_cick");
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ViewItemsPerStore>();
        }

        private void item_scanItem_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_scanItem_click");
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ScanItemsInStore>();
        }


        private void item_radioAll_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_radioAll_click");
				
            if (radioAll.Checked)
            {
            	try 
            	{
            		//从数据库中读取item记录到内存
	                List<LTS.Item> i = new List<LTS.Item>();
	                i = DAT.DataAccess.GetItem().ToList();
	                List<ItemMain> imList = new List<ItemMain>();

					//根据item记录字段，组装厂家，类型等信息到内存
                	for (int x = 0; x < i.Count; x++)
	                {
	                    ItemMain im = new ItemMain();

					
	                    //将item记录信息保存到内存
	                    im.itemID = i[x].ItemID;
	                    im.EPC = i[x].TagEPC;
	                    im.ItemStatus = i[x].ItemStatus;
	                    im.ProductID = i[x].ProductID;
	                    im.StoreID = i[x].StoreID;

						Log.WriteLog(LogType.Trace, "goto get item["+im.itemID+"] info into memery:epc["+im.EPC+"], status[{"+im.ItemStatus+"}], pruduct id[{"+im.ProductID+"}], store id[{"+im.StoreID+"}]");
		
	                    //组装item的产品信息
	                    LTS.Product p = new LTS.Product();
	                    p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
	                    im.ProductName = p.ProductName;
	                    im.ProductDescription = p.ProductDescription;
	                    im.BrandID = p.BrandID;
	                    im.CategoryID = p.CategoryID;
	                    im.BarcodeID = p.BarcodeID;

	                    //组装item的store信息
	                    LTS.Store s = new LTS.Store();
	                    s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
	                    im.StoreName = s.StoreName;
	                    im.StoreLocation = s.StoreLocation;

	                    //组装item的厂家信息
	                    LTS.Brand b = new LTS.Brand();
	                    b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
	                    im.BrandName = b.BrandName;
	                    im.BrandDescription = b.BrandDescription;

	                    //组装item的类型信息
	                    LTS.Category c = new LTS.Category();
	                    c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
	                    im.CategoryName = c.CategoryName;
	                    im.CategoryDescription = c.CategoryDescription;

	                    //组装item的条形码信息
	                    LTS.Barcode ba = new LTS.Barcode();
	                    ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
	                    im.BarcodeNumber = ba.BarcodeNumber;

						//item完整信息添加到list中，并在控件中展示
	                    imList.Add(im);
	                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
	                        , im.ItemStatus, im.StoreName);

	                }
            	}
				catch (Exception ex)
				{
					Log.WriteLog(LogType.Error, "error to show item info into data grid view for all");
				}
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void item_radioInStock_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_radioInStock_click");
			
            if (radioInStock.Checked)
            {
            	try
            	{
	                List<LTS.Item> i = new List<LTS.Item>();
	                i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == true).ToList();//list from db
	                List<ItemMain> imList = new List<ItemMain>();

                	for (int x = 0; x < i.Count; x++)
	                {
	                    ItemMain im = new ItemMain();
	                    //assign the item info to the ItemMain object
	                    im.itemID = i[x].ItemID;
	                    im.EPC = i[x].TagEPC;
	                    im.ItemStatus = i[x].ItemStatus;
	                    im.ProductID = i[x].ProductID;
	                    im.StoreID = i[x].StoreID;

	                    //get the specific product and assign the info to the ItemMain object
	                    LTS.Product p = new LTS.Product();
	                    p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
	                    im.ProductName = p.ProductName;
	                    im.ProductDescription = p.ProductDescription;
	                    im.BrandID = p.BrandID;
	                    im.CategoryID = p.CategoryID;
	                    im.BarcodeID = p.BarcodeID;

	                    //get the specific store and assign the info to the ItemMain object
	                    LTS.Store s = new LTS.Store();
	                    s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
	                    im.StoreName = s.StoreName;
	                    im.StoreLocation = s.StoreLocation;

	                    //get the specific brand and assign the info to the ItemMain object
	                    LTS.Brand b = new LTS.Brand();
	                    b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
	                    im.BrandName = b.BrandName;
	                    im.BrandDescription = b.BrandDescription;

	                    //get the sepcific category and assign the info to the ItemMain object
	                    LTS.Category c = new LTS.Category();
	                    c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
	                    im.CategoryName = c.CategoryName;
	                    im.CategoryDescription = c.CategoryDescription;

	                    //get the sepcific category and assign the info to the ItemMain object
	                    LTS.Barcode ba = new LTS.Barcode();
	                    ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
	                    im.BarcodeNumber = ba.BarcodeNumber;

	                    imList.Add(im);
	                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
	                        , im.ItemStatus, im.StoreName);
	                }
            	}
				catch (Exception ex)
				{
					Log.WriteLog(LogType.Error, "error to show item info into data grid view for in stock");
				}

            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }


        private void item_radioOutStock_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_radioOutStock_click");
            if (radioOutStock.Checked)
            {
            	try 
				{
	                List<LTS.Item> i = new List<LTS.Item>();
	                i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == false).ToList();//list from db
	                List<ItemMain> imList = new List<ItemMain>();

	                for (int x = 0; x < i.Count; x++)
	                {
	                    ItemMain im = new ItemMain();
	                    //assign the item info to the ItemMain object
	                    im.itemID = i[x].ItemID;
	                    im.EPC = i[x].TagEPC;
	                    im.ItemStatus = i[x].ItemStatus;
	                    im.ProductID = i[x].ProductID;
	                    im.StoreID = i[x].StoreID;

	                    //get the specific product and assign the info to the ItemMain object
	                    LTS.Product p = new LTS.Product();
	                    p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
	                    im.ProductName = p.ProductName;
	                    im.ProductDescription = p.ProductDescription;
	                    im.BrandID = p.BrandID;
	                    im.CategoryID = p.CategoryID;
	                    im.BarcodeID = p.BarcodeID;

	                    //get the specific store and assign the info to the ItemMain object
	                    LTS.Store s = new LTS.Store();
	                    s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
	                    im.StoreName = s.StoreName;
	                    im.StoreLocation = s.StoreLocation;

	                    //get the specific brand and assign the info to the ItemMain object
	                    LTS.Brand b = new LTS.Brand();
	                    b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
	                    im.BrandName = b.BrandName;
	                    im.BrandDescription = b.BrandDescription;

	                    //get the sepcific category and assign the info to the ItemMain object
	                    LTS.Category c = new LTS.Category();
	                    c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
	                    im.CategoryName = c.CategoryName;
	                    im.CategoryDescription = c.CategoryDescription;

	                    //get the sepcific category and assign the info to the ItemMain object
	                    LTS.Barcode ba = new LTS.Barcode();
	                    ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
	                    im.BarcodeNumber = ba.BarcodeNumber;

	                    imList.Add(im);
	                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
	                        , im.ItemStatus, im.StoreName);

	                }
            	}
				catch (Exception ex)
				{
					Log.WriteLog(LogType.Error, "error to show item info into data grid view for out stock ");
				}
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
        
        
        private void item_pdf_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_pdf_click");
            saveFileDialog1.ShowDialog();
        }


        private void item_saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in item_saveFileDialog1_FileOk");
            string what = "";
            if(radioAll.Checked == true)
            {
                what = "All";
            }
            else if (radioInStock.Checked == true)
            {
                what = "Items in stock";
            }
            else if(radioOutStock.Checked == true)
            {
                what = "Items out of stock";
            }
            else
            {
                what = "All";
            }
            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
            string folderPath = saveFileDialog1.FileName + ".pdf";


            //Creating iTextSharp Table from the DataTable data
            Document pdfDoc = new Document(PageSize.A4);

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = dataGridView1.DefaultCellStyle.Padding.All;

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 0;



            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // pdfTable.AddCell(cell.Value.ToString());
                    PdfPCell cellRows = new PdfPCell(new Phrase(cell.Value.ToString(), font));
                    int R = cell.Style.BackColor.R;
                    int G = cell.Style.BackColor.G;
                    int B = cell.Style.BackColor.B;
                    if (R == 0 && G == 0 && B == 0)
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }
                    cellRows.BackgroundColor = new iTextSharp.text.BaseColor(R, G, B);
                    cellRows.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cellRows);

                }
            }
            Paragraph writing = new iTextSharp.text.Paragraph("Rfid Reader Management System " + Environment.NewLine + "Items Information: " + what + "                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(writing);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

            }
        }
    }
}
