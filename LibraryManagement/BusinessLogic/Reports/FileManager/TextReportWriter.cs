using BusinessLogic.Reports.Models;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic.Reports.FileManager
{
    public class TextReportWriter : IReportWriter
    {
        public void Write(List<BookReportModel> data, string filePath)
        {
            var dataText = string.Empty;
            foreach (var line in data)
                dataText += string.Format("Title: {0}; Genre: {1}; Author: {2}; Condition: {3}; Count: {4}",
                    line.Title, line.Genre, line.Author, line.Condition, line.Count);
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                sr.Write(dataText);
            }
        }
    }
}
