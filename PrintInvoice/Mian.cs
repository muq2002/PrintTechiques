using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.IO;
using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;

namespace PrintInvoice
{
    public partial class Main : Form

    {
        private PrintDocument printDocument = new PrintDocument();
        public Main()
        {
            InitializeComponent();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:/Users/mktad/source/repos/PrintInvoice/PrintInvoice/bin/Debug/export.pdf";

            // Check if the PDF file exists
            if (System.IO.File.Exists(pdfFilePath))
            {
                // Open the PDF file using the default PDF viewer
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pdfFilePath,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            else
            {
                MessageBox.Show("PDF file not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pdfFilePath = @"C:/Users/mktad/source/repos/PrintInvoice/PrintInvoice/bin/Debug/export.pdf";

            // Check if the PDF file exists
            if (File.Exists(pdfFilePath))
            {
                // Show print dialog
                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = printDocument;
                    DialogResult result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Print the PDF file using default printer
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = pdfFilePath,
                            Verb = "PrintTo",
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };
                        Process.Start(psi);
                    }
                }
            }
            else
            {
                MessageBox.Show("PDF file not found.");
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // This event handler is required for the PrintDocument to work properly
        }
    }
}



