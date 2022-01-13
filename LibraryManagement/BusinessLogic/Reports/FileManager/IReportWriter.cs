using BusinessLogic.Reports.Models;
using System.Collections.Generic;

namespace BusinessLogic.Reports.FileManager
{
    public interface IReportWriter
    {
        void Write(List<BookReportModel> data, string filePath);
    }
}
