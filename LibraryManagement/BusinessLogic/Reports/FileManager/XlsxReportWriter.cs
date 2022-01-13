using BusinessLogic.Reports.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BusinessLogic.Reports.FileManager
{
    public class XlsxReportWriter : IReportWriter
    {
        public void Write(List<BookReportModel> data, string filePath)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets
                .Add("Library Report");
            Type type = data.First().GetType();
            var j = 0;
            foreach (PropertyInfo pi in type.GetProperties())
            {
                sheet.Cells[0, j].Value = pi.Name;
                j++;
            }
            for (var i = 0; i < data.Count; i++)
            {
                sheet.Cells[i + 1, 0].Value = data[i].Title;
                sheet.Cells[i + 1, 1].Value = data[i].Genre;
                sheet.Cells[i + 1, 2].Value = data[i].Author;
                sheet.Cells[i + 1, 3].Value = data[i].Condition;
                sheet.Cells[i + 1, 4].Value = data[i].Count;
            }
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                sr.Write(sheet);
            }
        }
    }
}
