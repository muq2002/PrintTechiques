using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace PrintInvoice.Techiques
{
    class PDFEditorDocument
    {

        public static string filePath {get; set;}
        public static string headerImage { get; set; }
        public static string footerImage { get; set; }


        private static PdfWriter  writer = new PdfWriter(filePath);
        private static PdfDocument pdf = new PdfDocument(writer);
        private static Document document = new Document(pdf);
        void createPDFInovice(string filePath)
        {


            createHeaderOfPage(document, pdf.GetDefaultPageSize().GetWidth());

            // Define table columns and widths
            float[] columnWidths = { 0.5F, 3, 1, 3 };

            Table table = crateTable(columnWidths);

            // Add sample data to the table
            fillTable(table);

            document.Add(table);


            createFooter(document, pdf.GetDefaultPageSize().GetWidth());
            // Close the document
            document.Close();

            MessageBox.Show("Invoice generated successfully! Location: " + Path.GetFullPath(filePath));

        }
        void createFooter(Document document, float width)
        {
            Image footerImage = new Image(ImageDataFactory.Create("C:\\Users\\mktad\\OneDrive\\Desktop\\footer_image.png"));
            document.Add(footerImage.SetWidth(width - 36)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER));
        }
        private static void createHeaderOfPage(Document document, float width)
        {
            document.SetMargins(0, 36, 36, 36);
            Image headerImage = new Image(ImageDataFactory.Create("C:\\Users\\mktad\\OneDrive\\Desktop\\header_image.png"));
            document.Add(headerImage.SetWidth(width - 36)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER));


            Paragraph headerText = new Paragraph("ELectrolyes".ToUpper())
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);
            document.Add(headerText);




            document.Add(new Paragraph().Add("Muqtada Jabbar\n")
                .SetFontColor(ColorConstants.BLACK).SetFontSize(12));
            document.Add(new Paragraph().Add("Age: 23\n").SetFontSize(8).SetBold()
                .SetFontColor(ColorConstants.LIGHT_GRAY));
            document.Add(new Paragraph().Add("Sex: Male\n").SetFontSize(8).SetBold()
                .SetFontColor(ColorConstants.LIGHT_GRAY));
            document.Add(new Paragraph().Add("UUID: 32C4ER99\n\n").SetFontSize(8).SetBold()
                .SetFontColor(ColorConstants.LIGHT_GRAY));



        }

        private static void fillTable(Table table)
        {
            for (int i = 1; i <= 5; i++)
            {
                table.AddCell(new Cell().Add(new Paragraph(i.ToString())));
                table.AddCell(new Cell().Add(new Paragraph("Tests " + i.ToString())));
                table.AddCell(new Cell().Add(new Paragraph("1")).SetTextAlignment(TextAlignment.CENTER));
                table.AddCell(new Cell().Add(new Paragraph("$" + (10 * i).ToString())).SetTextAlignment(TextAlignment.CENTER));
            }
        }

        private static Table crateTable(float[] columnWidths)
        {
            // Define table
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths))
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetMarginTop(20);

            // Add header cells with styling
            Cell Col1 = new Cell().Add(new Paragraph("No.").SetBold()
                .SetFontColor(ColorConstants.BLACK).SetBackgroundColor(ColorConstants.WHITE));

            Cell Col2 = new Cell().Add(new Paragraph("Tests Name").SetBold()
                .SetFontColor(ColorConstants.BLACK).SetBackgroundColor(ColorConstants.WHITE));

            Cell Col3 = new Cell().Add(new Paragraph("Results").SetBold()
                .SetFontColor(ColorConstants.BLACK).SetBackgroundColor(ColorConstants.WHITE));
            Cell Col4 = new Cell().Add(new Paragraph("Reference Values").SetBold()
                .SetFontColor(ColorConstants.BLACK).SetBackgroundColor(ColorConstants.WHITE));

            table.AddHeaderCell(Col1);
            table.AddHeaderCell(Col2);
            table.AddHeaderCell(Col3);
            table.AddHeaderCell(Col4);
            return table;
        }
    }
}
