using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efwatercom.Data
{
    internal class GlobalConstant
    {
        public readonly static string ConnectionString = "Data Source= localhost:1521/xe; User Id=C##EFAWATERCOMM2; Password=S123S123;";
        public readonly static string LoginLink = "http://localhost:4200/auth/lohin";
        public readonly static string TestDataPath = "C:\\Users\\moalgharX\\Downloads\\Fill Data sheet.xlsx";
        public readonly static string ImagesPath = "C:\\Users\\moalgharX\\source\\repos\\Efwatercom\\Data\\Images";
        public readonly static string HTMLReportPath = "C:\\Users\\moalgharX\\source\\repos\\Efwatercom\\Data\\HTMLReport";
    }
}
