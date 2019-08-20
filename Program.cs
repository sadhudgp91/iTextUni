using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace iText
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "iText_Sample.pdf");

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new Paragraph("This is a sample iText document created for Uni Stuttgart in C#"));

                }
            }

        }
    }
}
