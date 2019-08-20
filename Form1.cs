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
                        image.SpacingAfter = 1f;
                        Paragraph paragraph = new Paragraph();
                        doc.Add(paragraph);                                  
                      
                        paragraph.Add(("Date:" + DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/'));
                        doc.Add(paragraph);
                        doc.Add(new iTextSharp.text.Paragraph("Vorname:" + Vorname.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Nachname:" + Nachname.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Institute ID:" + InstId.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Matriculation Nummer:" + MatId.Text));                        

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
