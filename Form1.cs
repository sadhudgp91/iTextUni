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


namespace iTextForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            //string imagepath = "‪C:\\Users\\ac131128\\Pictures\\unistuttgart.png";
            string imagepath = Environment.CurrentDirectory;
            var exportImage = System.IO.Path.Combine(imagepath, "..\\..\\public\\unistuttgart.png");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();                       
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(exportImage);
                        image.ScalePercent(24f);
                        doc.Add(image);
                        iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("\n\n");
                        image.SpacingAfter = 1f;

                        doc.Add(new Paragraph("\n"));
                        var spacerParagraph2 = new Paragraph();
                        spacerParagraph2.SpacingBefore = 4f;
                        spacerParagraph2.SpacingAfter = 1f;
                        doc.Add(spacerParagraph2);


                        title.SpacingAfter = 1f;
                        iTextSharp.text.Paragraph space = new iTextSharp.text.Paragraph("\n\n");
                        space.SpacingBefore = 1f;

                        space.SpacingAfter = 1f;

                        //Creating iTextSharp Table from the DataTable data
                        PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                        pdfTable.DefaultCell.Padding = 8;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 1;

                        //Adding Header row
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                            //cell.Colspan = 2;
                            pdfTable.AddCell(cell);
                        }

                        //Adding DataRow
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value == null)
                                {                                   
                                  cell.Value = "null";
                                }
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                        }

                        doc.Add(pdfTable);

                        doc.Add(new Paragraph("\n"));
                        var spacerParagraph = new Paragraph();
                        spacerParagraph.SpacingBefore = 4f;
                        spacerParagraph.SpacingAfter = 1f;
                        doc.Add(spacerParagraph);

                        iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph(("Date:" + DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/'));
                        date.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        doc.Add(date);


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

        }

        private void Benutzer_Click(object sender, EventArgs e)
        {
            
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
            
            string[] row = { sapuser, vname, Nname, eMail, InstID, Finanz, von, bis, einrichtung, tel };
            dataGridView1.Rows.Add(row);
           
        }
    }
}
