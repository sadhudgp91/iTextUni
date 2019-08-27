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

// namespace iTextForm PDF creator
namespace iTextForm
{
    // form1 class instance
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Hide print button
            BtnSave.Enabled = false;
            BtnSave.BackColor = Color.Gray;
        }

        // KS: Function to save the data into PDF format
        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            // declare image instance            
            string imagepath = Environment.CurrentDirectory;
            var exportImage = System.IO.Path.Combine(imagepath, "..\\..\\public\\unistuttgart.png");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // create pdf document instance
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

                    // set the base fonts for table

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD , BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
                    BaseFont rowfont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontcell = new iTextSharp.text.Font(rowfont, 10, iTextSharp.text.Font.NORMAL);

                    try
                    {
                        //create a new instance of PDF
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
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
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);                            
                            //cell.Colspan = 2;
                            pdfTable.AddCell(cell);                            
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
                        iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph("Rollen for benutzer:" + Environment.UserName.ToString(), font);                        
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
                        
                        //close the document
                        doc.Close();
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // actions go here....
        }

        private void Benutzer_Click(object sender, EventArgs e)
        {
            // get the values from the form's text field
            string sapuser = txtUser.Text;
            string vname = Vorname.Text;
            string Nname = Nachname.Text;
            string eMail = txtEmail.Text;
            string InstID = InstId.Text;
            string Finanz = txtFinStelle.Text;
            string von = dateTimePicker1.Text;
            string bis = dateTimePicker2.Text;
            string einrichtung = txtEinr.Text;
            string tel = txtTel.Text;

            // pass the values to row array
            string[] row = { sapuser, vname, Nname, eMail, InstID, Finanz, von, bis, einrichtung, tel };
            dataGridView1.Rows.Add(row);
            //once data has been addded to Gridview, make print button visible
            BtnSave.Enabled = true;
            BtnSave.BackColor = Color.LawnGreen;
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
                }
                if (chk2.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-SKA");
                    withBlock.Items.Add("A1000_P_BI_SKA-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                }
                if (chk3.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-ANLA");
                    withBlock.Items.Add("A1000_P_BI_ANL-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
                }
                if (chk4.Checked)
                {
                    withBlock.Items.Add("B1000_P_BI_BASISBER");
                    withBlock.Items.Add("T1000_P_BI_INFO-USER-BUDGET");
                    withBlock.Items.Add("A1000_P_BI_SKA-DATEN");
                    withBlock.Items.Add("O1000_P_BI_" + txtFinStelle.Text);
                    withBlock.Items.Add("O1000_P_BI_FONDS_ALL");
                    withBlock.Items.Add("O1000_P_BI_FIPOS_TITEL_RESTRIC");
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
                }
            }
            //RemoveDoubleEntries(lstRollen);
        }
    }
}
