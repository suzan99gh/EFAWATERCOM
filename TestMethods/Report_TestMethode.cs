using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Efwatercom.AssistantMethods;
using Efwatercom.Data;
using Efwatercom.Helpers;
using Efwatercom.POM;
using OpenQA.Selenium;

namespace Efwatercom.TestMethods
{ [TestClass]
    public class Report_TestMethode
    {



        Report_POM payment_POM = new Report_POM(ManageDriver.driver);
            public static ExtentReports extentReports = new ExtentReports();
             public static ExtentHtmlReporter reporter = new ExtentHtmlReporter(GlobalConstant.HTMLReportPath);

            [ClassInitialize]
            public static void ClassInitialize(TestContext testContext)
            {

                Report_POM report_POM = new Report_POM(ManageDriver.driver);
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();

            }

        [ClassCleanup]
        public static void ClassCleanup()
        {
             //extentReports.Flush();
            ManageDriver.CloseDriver();

        }

        [TestMethod]
            public void FirstOptonReport()
            {
              {
                Report_POM report_POM = new Report_POM(ManageDriver.driver);
                var test = extentReports.CreateTest("Valid Data", "Test create category");
                try
                {
                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    Thread.Sleep(2000);
                    Console.WriteLine($"loggedin");
                    Report_AssistantMethods.ClickFirstOption();
                    Console.WriteLine($"2");
                    int numRows = report_POM.NumberOfRow();

                    Console.WriteLine($"3");

                    Console.WriteLine($"Number of rows: {numRows}");
                    Assert.AreEqual(2, numRows);
                    test.Pass("Test Case completed Successfully");
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }

              }

            }

      

        [TestMethod]
        public void SeondOptonReport()
        {

            {

                Report_POM report_POM = new Report_POM(ManageDriver.driver);

                var test = extentReports.CreateTest("Valid Data", "Test create category");
                try
                {
                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    Thread.Sleep(500);
                    Console.WriteLine($"loggedin");
                    Report_AssistantMethods.ClickSeondOption();
                    int numRows = report_POM.NumberOfRow();
                    Console.WriteLine($"Number of rows: {numRows}");
                    Assert.AreEqual(2, numRows);
                    test.Pass("Test Case completed Successfully");
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }

            }

        }

        [TestMethod]
        public void ThirdOptonReport()
        {
            {
                Report_POM report_POM = new Report_POM(ManageDriver.driver);
                var test = extentReports.CreateTest("Valid Data", "Test create category");
                try
                {
                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    Thread.Sleep(500);
                    Report_AssistantMethods.ClickThirdOption();
                    int numRows = report_POM.NumberOfRow();
                    Console.WriteLine($"Number of rows: {numRows}");
                    Assert.AreEqual(2, numRows);
                    test.Pass("Test Case completed Successfully");
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }

            }

        }

        [TestMethod]
        public void SearchReport_valid()
        {
            {
                Report_POM report_POM = new Report_POM(ManageDriver.driver);
                var test = extentReports.CreateTest("Valid Data", "Test create category");
                try
                {
                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    //ReportData reportData = Report_AssistantMethods.ReadDataFromExcel(1);
                    //Thread.Sleep(500);
                    Report_AssistantMethods.ClickSearchField();
                    Console.WriteLine("data fill");
                    DateTime fromDate = new DateTime(2022, 2, 4);
                    DateTime toDate = new DateTime(2022, 2, 28);

                    var result = Report_AssistantMethods.GetCategoriesByPaymentDate(fromDate, toDate);

                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                    Console.WriteLine("done");

                    //int numRows = report_POM.NumberOfRow();
                    //Console.WriteLine($"Number of rows: {numRows}");
                    //Assert.AreEqual(2, numRows);
                    test.Pass("Test Case completed Successfully");
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }

            }

        }
    }
}
