using Grpc.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace iTextForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Textarea_TextChanged(object sender, EventArgs e)
        {

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
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();                       
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(exportImage);
                        image.ScalePercent(24f);
                        doc.Add(image);
                        iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("\n\n");
                        image.SpacingAfter = 1f;
                        
                        iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph(("Date:" + DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/'));
                        date.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        doc.Add(date);
                        title.SpacingAfter = 1f;
                        iTextSharp.text.Paragraph space = new iTextSharp.text.Paragraph("\n\n");
                        space.SpacingAfter = 1f;

                        var table = new PdfPTable(2);
                        table.WidthPercentage = 98;

                        var cell = new PdfPCell();
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cell);
                        space.SpacingAfter = 1f;

                        table.AddCell("SAP Benutzer:");
                        table.AddCell(txtUser.Text);           
                        table.AddCell("Anrede:");
                        table.AddCell(cmbAnrede.Text);
                        table.AddCell("Nachname:");
                        table.AddCell(Nachname.Text);
                        table.AddCell("Vorname:");
                        table.AddCell(Vorname.Text);
                        table.AddCell("Institute ID:");
                        table.AddCell(InstId.Text);
                        table.AddCell("Reference Nummer:");
                        table.AddCell(RefID.Text);
                        table.AddCell("Finanzstelle:");
                        table.AddCell(txtFinStelle.Text);
                        table.AddCell("Gültigkeit - Von:");
                        table.AddCell(dateTimePicker1.Text);
                        table.AddCell("Gültigkeit - Bis:");
                        table.AddCell(dateTimePicker2.Text);
                        table.AddCell("Einrichtung:");
                        table.AddCell(txtEinr.Text);
                        table.AddCell("Telephone");
                        table.AddCell(txtTel.Text);
                        table.AddCell("Email:");
                        table.AddCell(txtEmail.Text);
                       
                        doc.Add(table);
                        


                       
                       // doc.Add(new iTextSharp.text.Paragraph("SAP Benutzer:" + txtUser.Text));
                        //doc.Add(new iTextSharp.text.Paragraph("Anrede:" + cmbAnrede.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Nachname:" + Nachname.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Vorname:" + Vorname.Text));                        
                       // doc.Add(new iTextSharp.text.Paragraph("Institute ID:" + InstId.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Reference Nummer:" + RefID.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Finanzstelle" + txtFinStelle.Text));
                       //doc.Add(new iTextSharp.text.Paragraph("Gültigkeit Von" + txtVon.Text + "Gültigkeit Bis" + txtBis.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Einrichtung" + txtEinr.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Telephone" + txtTel.Text));
                       // doc.Add(new iTextSharp.text.Paragraph("Email" + txtEmail.Text));
                       // doc.Add(new iTextSharp.text.Paragraph(""));

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

        
    }
}
