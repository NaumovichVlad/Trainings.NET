using BusinessLogic.Reports.FileManager;
using BusinessLogic.Reports.Models;
using System.Collections.Generic;

namespace BusinessLogic.Reports.Factories
{
    public class FileFormatFactory : IReportWriter
    {
        public void Write(List<BookReportModel> data, string filePath)
        {
            IReportWriter reportWriter = null;
            var format = filePath.Split('.')[1];
            switch (format)
            {
                case "xslx":
                    reportWriter = new XlsxReportWriter();
                    break;
                case "txt":
                    reportWriter = new XlsxReportWriter();
                    break;
            }
            reportWriter.Write(data, filePath);
        }
    }
}
