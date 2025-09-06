using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efwatercom.Data
{
    public class ReportData
    {
        public ReportData(string billerName = "", string dateFrom = "", string dateTo = "")
        {
            BillerName = billerName;

            DateFrom = dateFrom;
            DateTo = dateTo;
        }


        public string? BillerName { get; set; }

        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
    }
}
