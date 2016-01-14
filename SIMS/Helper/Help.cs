using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace SIMS.Helper
{
    public static class Help
    {
        public static MemoryStream CreatePdf(string html)
        {
            using (var msOutput = new MemoryStream())
            {
                var reader = new StringReader(html);
                var document = new Document(PageSize.A4, 25, 25, 25, 25);
                var writer = PdfWriter.GetInstance(document, msOutput);
                var worker = new HTMLWorker(document);
                document.Open();
                worker.StartDocument();
                worker.Parse(reader);
                worker.EndDocument();
                worker.Close();
                document.Close();
                return msOutput;
            }
        }

        public static MemoryStream ConvertHtmlToPdf(string htmlData)
        {
            using (var stream = new MemoryStream())
            {
                FontFactory.RegisterDirectories();
                using (var document = new Document(PageSize.A4, 25, 25, 25, 25))
                {
                     
                    using (var writer = PdfWriter.GetInstance(document, stream))
                    {
                        document.Open();
                        using (var html = new StringReader(htmlData))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, html);
                        }
                        document.Close();
                    }
                }
                return stream;
            }
        }
    }
}