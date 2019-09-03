using Grpc.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Net.Mail;


// namespace iTextForm PDF creator
namespace iTextForm
{
    // form1 class instance
    public partial class Form1 : Form
    {
        public string sapuser;
        public static string lstRollenItems;

        public Form1()
        {
            InitializeComponent();
            //Hide Export button
            btnExport.Enabled = false;
  
            toolStripStatusLabel1.ForeColor = Color.White;
            username.Text = "Wilkommen " + Environment.UserName;
            toolStripStatusLabel1.Text = "Initialized Program for UserAccount: " + Environment.UserName;
            statusStrip1.BackColor = Color.ForestGreen;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // actions go here....
        }

        private void Benutzer_Click(object sender, EventArgs e)
        {
            // get the values from the form's text field
            sapuser = txtUser.Text;
            string vname = Vorname.Text;
            string Nname = Nachname.Text;
            string eMail = txtEmail.Text;
            string InstID = InstId.Text;
            string Finanz = txtFinStelle.Text;
            string von = dateTimePicker1.Text;
            string bis = dateTimePicker2.Text;
            string einrichtung = txtEinr.Text;
            string tel = txtTel.Text;
            lstRollenItems = lstRollen.Items.ToString();

            // pass the values to row array
            string[] row = { sapuser, vname, Nname, eMail, InstID, Finanz, von, bis, einrichtung, tel };
            dataGridView1.Rows.Add(row);
            statusStrip1.BackColor = Color.LawnGreen;
            toolStripStatusLabel1.ForeColor = Color.White;
            toolStripStatusLabel1.Text = "Data Entered in GridView and Database";
            //once data has been addded to Gridview, make print button visible
            btnExport.Enabled = true;           
            btnExport.BackColor = Color.LawnGreen;


            // Clear form for new user entry

            txtUser.Text = "";
            cmbAnrede.Text = "";
            Vorname.Text = "";
            Nachname.Text = "";
            txtEmail.Text = "";
            InstId.Text = "";
            RefID.Text = "";
            txtFinStelle.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txtEinr.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtfinanz.Text = "";
            chk1.Checked = false; 
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
            //lstRollen.Items.Clear();
            toolStripStatusLabel1.Text = "Please Enter new User";
            statusStrip1.BackColor = Color.CadetBlue;
        }

        //Checkbox values
        private void BtnRollen_Click(object sender, EventArgs e)
        {
            {
                var withBlock = lstRollen;
                withBlock.Items.Clear();
                if (chk1.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-LBV-RESTR");
                    withBlock.Items.Add("A1000_P_BI_LBV-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                    statusStrip1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Benutzerdaten eingegeben";
                    statusStrip1.Refresh();
                }
                if (chk2.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-SKA");
                    withBlock.Items.Add("A1000_P_BI_SKA-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                    statusStrip1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Benutzerdaten eingegeben";
                    statusStrip1.Refresh();
                }
                if (chk3.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-ANLA");
                    withBlock.Items.Add("A1000_P_BI_ANL-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                    statusStrip1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Benutzerdaten eingegeben";
                    statusStrip1.Refresh();
                }
                if (chk4.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-BUDGET");
                    withBlock.Items.Add("A1000_P_BI_SKA-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                    statusStrip1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Benutzerdaten eingegeben";
                    statusStrip1.Refresh();
                }
                if (chk5.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-LBV-RESTR");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-SKA");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-ANLA");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-BUDGET");
                    withBlock.Items.Add("A1000_P_BI_LBV-DATEN");
                    withBlock.Items.Add("A1000_P_BI_SKA-DATEN");
                    withBlock.Items.Add("A1000_P_BI_ANL-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                    statusStrip1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Benutzerdaten eingegeben";
                    statusStrip1.Refresh();
                }
               
            }

        }

        private void Addfnz_Click(object sender, EventArgs e)
        {
            lstRollen.Items.Add("O1000_P_BI_" + txtfinanz.Text);
        }

        private void EMail_Click(object sender, EventArgs e)
        {
           
        }

        private Phrase FormatPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES, 8));
        }

        private static Phrase FormatHeaderPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES, 8, iTextSharp.text.Font.UNDERLINE, new iTextSharp.text.BaseColor(0, 0, 255)));
        }

        private void BtnCSV_Click_1(object sender, EventArgs e)
        {
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;


            string desktoplink = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FileUsers = "BW_Users_" + DateTime.Now.ToShortDateString() + ".csv";
            string FileRoles = "BW_Roles_" + DateTime.Now.ToShortDateString() + ".csv";
            string fnPdf = "BW_User_Rollen" + "_" + DateTime.Now.ToShortDateString() + ".pdf"; ;

            string newPath = System.IO.Path.Combine(desktoplink, "BW_Workflow");
            System.IO.Directory.CreateDirectory(newPath);

            string filePath1 = Path.Combine(newPath, FileUsers);
            string filePath2 = Path.Combine(newPath, FileRoles);
            string filePath3 = Path.Combine(newPath, fnPdf);


            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                csv += column.HeaderText + ';';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow rowEntry in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in rowEntry.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ';';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.

            

            String[] listitem = new String[lstRollen.Items.Count];
            string Zeile = string.Empty;            
            for (var i = 0; i <= lstRollen.Items.Count -1; i++)
            {               
                Zeile += sapuser + ";B3P;" + lstRollen.Items[i].ToString();
                Zeile += "\r\n";                
            }

            File.WriteAllText(filePath2, Zeile.ToString());
            File.WriteAllText(filePath1, csv.ToString());

            statusStrip1.Refresh();
           
            //PDF Generation

            // declare image instance            
            string imagepath = Environment.CurrentDirectory;
            var exportImage = System.IO.Path.Combine(imagepath, "..\\..\\public\\unistuttgart.png");                
                       
            // create pdf document instance
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

            // set the base fonts for table

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
            BaseFont rowfont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontcell = new iTextSharp.text.Font(rowfont, 10, iTextSharp.text.Font.NORMAL);

            try
            {
                //create a new instance of PDF
                PdfWriter.GetInstance(doc, new FileStream(filePath3, FileMode.Create));
                doc.Open();
                //add the image *Uni Logo* to the pdf
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(exportImage);
                image.ScalePercent(24f);
                doc.Add(image);

                // add space
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("\n\n");
                doc.Add(new Paragraph("\n"));
                var spacerParagraph2 = new Paragraph();
                spacerParagraph2.SpacingBefore = 4f;
                spacerParagraph2.SpacingAfter = 1f;
                doc.Add(spacerParagraph2);

                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 1;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;

                //Adding Header row to the pdf table
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell datacell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                    datacell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    //cell.Colspan = 2;
                    pdfTable.AddCell(datacell);
                }


                //Adding DataRow to the pdf
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        PdfPCell Spalte0 = new PdfPCell(new Phrase(cell.Value.ToString(), fontcell));
                        if (cell.Value == null)
                        {
                            cell.Value = "null";
                        }
                        pdfTable.AddCell(Spalte0);
                        
                    }

                }


                doc.Add(pdfTable);

                //header for Rollen

                doc.Add(new Paragraph("\n"));
                iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph("Rollen for benutzer:" + sapuser, fontcell);
                doc.Add(header);
                doc.Add(new Paragraph("\n"));

                // add listbox values from checked checkboxes

                String[] items = new String[lstRollen.Items.Count];
                for (int loop = 0; loop < lstRollen.Items.Count; loop++)
                {
                    // get rollen from listbox (after checking the checkbox)
                    items[loop] = lstRollen.Items[loop].ToString();                    
                    iTextSharp.text.Paragraph rollen = new iTextSharp.text.Paragraph((items[loop].ToString()));
                    doc.Add(rollen);
                }
                                

                //add space
                doc.Add(new Paragraph("\n"));
                var spacerParagraph = new Paragraph();
                spacerParagraph.SpacingBefore = 4f;
                spacerParagraph.SpacingAfter = 1f;
                doc.Add(spacerParagraph);



                //add datestamp
                iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph(("Date:" + DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/'));
                date.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                doc.Add(date);
                statusStrip1.BackColor = Color.Green;
                toolStripStatusLabel1.ForeColor = Color.White;
                toolStripStatusLabel1.Text = "PDF and CSV files Generated in: " + newPath;
                //close the document
                doc.Close();
                //Application.Exit();
                }

                catch (Exception ex)
                {
                    statusStrip1.BackColor = Color.Red;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "System Error has occurred! Please Try Again Later";
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }

                //Send Email

                string[] attachFilePath = Directory.GetFiles(newPath);
                var files = attachFilePath.Where(x => Path.GetExtension(x).Contains(".pdf") ||
                            Path.GetExtension(x).Contains(".csv"));              

                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "This is the subject";
                mailItem.To = "someone@example.com";
                mailItem.Body = "This is the message.";
                foreach (var file in files)
                {                    
                    mailItem.Attachments.Add(file);
                }                
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(true);
        }

    }
}

