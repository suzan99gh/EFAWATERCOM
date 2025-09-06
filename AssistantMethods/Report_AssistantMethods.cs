using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using Efwatercom.Data;
using Efwatercom.Helpers;
using Efwatercom.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Oracle.ManagedDataAccess.Client;

namespace Efwatercom.AssistantMethods
{
    public class Report_AssistantMethods
    {

        public IWebDriver _webDriver;

        public Report_AssistantMethods(IWebDriver driver)

        {
            _webDriver = driver;

        }
        public static IJavaScriptExecutor drive;
        private static readonly IWebDriver driver;

        public static void ClickRandomOption()
        {

            Report_POM report_POM = new Report_POM(ManageDriver.driver);
            report_POM.ClickrReportSaidBar();
            Thread.Sleep(2000);
            report_POM.ClickrCategoryOption();
            Thread.Sleep(500);
            report_POM.ClickRandomOption();
        }
        public static void ClickFirstOption()
        {

           Report_POM report_POM = new Report_POM(ManageDriver.driver);
            report_POM.ClickrReportSaidBar();
            Thread.Sleep(2000);
            report_POM.ClickrCategoryOption();
            Thread.Sleep(500);
            report_POM.ChooseFirstOption();
        }

        public static void ClickSeondOption()
        {

            Report_POM report_POM = new Report_POM(ManageDriver.driver);
            report_POM.ClickrReportSaidBar();
            Thread.Sleep(2000);
            report_POM.ClickrCategoryOption();
            Thread.Sleep(500);
            report_POM.ChooseSeonedOption();
        }


        public static void ClickThirdOption()
        {

            Report_POM report_POM = new Report_POM(ManageDriver.driver);
            report_POM.ClickrReportSaidBar();
            Thread.Sleep(2000);
            report_POM.ClickrCategoryOption();
            Thread.Sleep(500);
            report_POM.ChooseThirdOption();
        }
        public static void ClickSearchField()
        {

            Report_POM report_POM = new Report_POM(ManageDriver.driver);
            report_POM.ClickrReportSaidBar();
            Thread.Sleep(500);
            report_POM.EnterBillerName("");
            report_POM.EnterDateFrom("02/01/2022");
            report_POM.EnterDateTo("02/28/2022");
                                   //MM/DD/YYYY
            Thread.Sleep(500);
           
        }

        public class PaymentHistoryResult
        {
            public string BillName { get; set; }
            public string Category { get; set; }
            public decimal TotalAmount { get; set; }
            // Add any other fields you want from the SELECT *
        }

        //public static ReportData ReadDataFromExcel(int row)
        //{
        //    Worksheet workSheet = CommonMethods.ReadExcel("SearchSheet");
        //    ReportData reportData = new ReportData();
        //    reportData.BillerName = Convert.ToString(workSheet.Cell(row, 1).Value);
        //    reportData.DateFrom = Convert.ToString(workSheet.Cell(row, 2).Value);
        //    reportData.DateTo = Convert.ToString(workSheet.Cell(row, 3).Value);
        //    return reportData;
        //}

        public static List<string> GetCategoriesByPaymentDate(DateTime fromDate, DateTime toDate)
        {
            List<string> categories = new List<string>();

            using (OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString))
            {
                oracleConnection.Open();

                string query = @"
            SELECT DISTINCT bc.BILLERCATEGORYNAME
            FROM PAYMENTHISTORY ph
            JOIN BILLERNAME bn ON ph.BILLERID = bn.BILLERID
            JOIN BILLERCATEGORY bc ON bn.BILLERCATEGORYID = bc.BILLERCATEGORYID
            WHERE ph.PAYMENTDATE BETWEEN :fromDate AND :toDate";

                using (OracleCommand command = new OracleCommand(query, oracleConnection))
                {
                    command.Parameters.Add(new OracleParameter("fromDate", fromDate));
                    command.Parameters.Add(new OracleParameter("toDate", toDate));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["BILLERCATEGORYNAME"].ToString());
                        }
                    }
                }
            }

            return categories;
        }

        //public static ReportData ReadDataFromExcel(int row)
        //{
        //    Worksheet workSheet = CommonMethods.ReadExcel("SearchSheet");
        //    ReportData reportData = new ReportData();

        //    // Log the raw values to debug
        //    var billerName = workSheet.Cell(row, 1).Value;
        //    Console.WriteLine($"Biller Name: {billerName}");

        //    var dateFrom = workSheet.Cell(row, 2).Value;
        //    var dateTo = workSheet.Cell(row, 3).Value;

        //    Console.WriteLine($"Raw DateFrom: {dateFrom}  Raw DateTo: {dateTo}");

        //    reportData.BillerName = Convert.ToString(billerName);
        //    reportData.DateFrom = ConvertExcelDateToString(dateFrom);
        //    reportData.DateTo = ConvertExcelDateToString(dateTo);

        //    Console.WriteLine($"Formatted DateFrom: {reportData.DateFrom}  Formatted DateTo: {reportData.DateTo}");

        //    return reportData;
        //}
    }
}
