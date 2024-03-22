using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintInvoice.Techiques
{
    class HTMLDocument
    {

        public void createHTMLFile() {
            string htmlContent = @"
                <html>
                <head>
                    <title>Invoice</title>
                    <style>
                        /* Add your CSS styles here */
                        body {
                            font-family: Arial, sans-serif;
                        }
                        header {
                            text-align: center;
                            margin-bottom: 20px;
                        }
                        footer {
                            text-align: center;
                            margin-top: 20px;
                        }
                        table {
                            width: 100%;
                            border-collapse: collapse;
                        }
                        th, td {
                            border: 1px solid black;
                            padding: 8px;
                            text-align: left;
                        }
                    </style>
                </head>
                <body>
                    <header>
                        <h1>Invoice</h1>
                    </header>
                    <div id='customer-details'>
                        <h2>Customer Details</h2>
                        <p><strong>Name:</strong> John Doe</p>
                        <p><strong>Address:</strong> 123 Main Street, Anytown, USA</p>
                        <p><strong>Email:</strong> john.doe@example.com</p>
                        <p><strong>Phone:</strong> 555-123-4567</p>
                    </div>
                    <table id='items'>
                        <thead>
                            <tr>
                                <th>Item</th>
                                <th>Description</th>
                                <th>Quantity</th>
                                <th>Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Product 1</td>
                                <td>Description of Product 1</td>
                                <td>2</td>
                                <td>$50.00</td>
                            </tr>
                            <tr>
                                <td>Product 2</td>
                                <td>Description of Product 2</td>
                                <td>1</td>
                                <td>$30.00</td>
                            </tr>
                        </tbody>
                    </table>
                    <footer>
                        <p>Thank you for your business!</p>
                    </footer>
                </body>
                </html>";
        }
        public void CreateHtmltoPdf(string htmlDoc)
        {
            if (File.Exists("buffer.html")) File.Delete("buffer.html");

            File.WriteAllText("buffer.html", htmlDoc);

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            if (File.Exists("export.pdf")) File.Delete("export.pdf");

            htmlToPdf.GeneratePdfFromFile("buffer.html", null, "export.pdf");
        }
    }
}
