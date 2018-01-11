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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using ssms;
using ssms.Util;

namespace ssms.Pages.Settings
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddSettings>();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<SelectSetting>();
        }

        private void buttonUpdateSettings_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateSettings>();
        }


	
		private void buttonExportPDF_Click(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
		}
		

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
				string folderPath = saveFileDialog1.FileName + ".pdf";


				//Creating iTextSharp Table from the DataTable data
				Document pdfDoc = new Document(PageSize.A4);

				PdfPTable pdfTable = new PdfPTable(dataGridViewSettings.ColumnCount);
				pdfTable.DefaultCell.Padding = dataGridViewSettings.DefaultCellStyle.Padding.All;

				pdfTable.WidthPercentage = 100;
				pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
				pdfTable.DefaultCell.BorderWidth = 0;



				//Adding Header row
				foreach (DataGridViewColumn column in dataGridViewSettings.Columns)
				{
					PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
					cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
					cell.HorizontalAlignment = Element.ALIGN_CENTER;
					pdfTable.AddCell(cell);
				}

				//Adding DataRow
				foreach (DataGridViewRow row in dataGridViewSettings.Rows)
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
				Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Settings Information				" + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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

				

		/*加载系统setting配置，每页10条*/
		private void Settings_Load(object sender, EventArgs e)
		{
			
			string sSql="SELECT Settings.SettingsID, Settings.SettingsName,Settings.SettingsSelect, COUNT(DISTINCT Reader.ReaderID) as ReadNum, COUNT(Antenna.AntennaID) as AntennaNum, Store.StoreName  " +
						"from Settings "+
						"LEFT JOIN Reader ON Reader.SettingsID = Settings.SettingsID "+
						"LEFT JOIN Antenna ON Antenna.ReaderID = Reader.ReaderID "+
						"LEFT JOIN Store ON Store.StoreID = Settings.StoreID " +
						"GROUP BY Settings.SettingsID,Settings.SettingsName,Settings.SettingsSelect,Store.StoreName " +
						"order by SettingsID ; ";
			
			#if false  //modify at 20171202
			SqlConnection conn = DbConn.sqlConn();
			#else
			SqlConnection conn = SqlAccess.Connection();
			#endif
			try
			{
				//conn.Open();      delete at 20171202
				SqlCommand sqlCmd = new SqlCommand(sSql.ToString(), conn);
				SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);	 
				DataSet ds = new DataSet();
				sda.Fill(ds,"Settings");
	            //dataGridViewSettings.DataSource = ds.Tables["Settings"].DefaultView;
	            dataGridViewSettings.DataSource = ds.Tables["Settings"];
				conn.Close();  
			}
			catch (SqlException ex)
			{
				Log.WriteLog(LogType.Error, (ex.Message));
			}
		}
	
    }
}
