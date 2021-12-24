using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Reports.Models
{
    public class BookReportModel
    {
        public BookDto Book { get; set; }
        public int Count { get; set; }
    }
}
