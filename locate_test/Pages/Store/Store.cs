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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
	
namespace ssms.Pages.Store
{
    public partial class Store : UserControl
    {

        private void store_saveFile_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in store_saveFile_click");
			
            saveFileDialog1.ShowDialog();
        }
        private void store_saveFileDialog_ok(object sender, CancelEventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in store_saveFileDialog_ok");
            try
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
                string folderPath = saveFileDialog1.FileName + ".pdf";


                //Creating iTextSharp Table from the DataTable data
                Document pdfDoc = new Document(PageSize.A4);

                PdfPTable pdfTable = new PdfPTable(dgvStore.ColumnCount);
                pdfTable.DefaultCell.Padding = dgvStore.DefaultCellStyle.Padding.All;

                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;



                //Adding Header row
                foreach (DataGridViewColumn column in dgvStore.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dgvStore.Rows)
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
                Paragraph writing = new iTextSharp.text.Paragraph("Rfid Reader Management System " + Environment.NewLine + "Stores Information                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        /*获取store的基本信息*/

    	private void store_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in store_load");
			
            /*加载从数据库中store信息*/
            DataTable stDt = Db.StoreGetInfo();
            if (stDt == null)
            {
                Log.WriteLog(LogType.Error, "error to call StoreGetInfo");
                return;
            }

            if (stDt.Rows.Count > 0)
            {
                Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] store records in db, goto show them");
                for (int n = 0; n < stDt.Rows.Count; n++)
                {
                    dgvStore.Rows.Add(stDt.Rows[n]["StoreID"], stDt.Rows[n]["StoreName"], stDt.Rows[n]["StoreLocation"], 0);
                }
                Log.WriteLog(LogType.Trace, "success to load store info into front");
            }
            else
            {
                Log.WriteLog(LogType.Trace, "there is not store records in db, no need to show");
                
            }
            return;
			
        }
		
        public Store()
        {
            InitializeComponent();
        }

        private void store_addStore_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in store_addStore_click");
			
            ((Main)this.Parent.Parent).ChangeView<AddStore>();
        }

        private void store_updateStore_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in store_updateStore_click");
			
            ((Main)this.Parent.Parent).ChangeView<UpdateStore>();
        }

		
    }
}
