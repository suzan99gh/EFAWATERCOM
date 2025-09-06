using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Efwatercom.Data;
using Efwatercom.Helpers;
using Efwatercom.POM;
using Efwatercom.AssistantMethods;
using System.Drawing.Drawing2D;
using OpenQA.Selenium;
using AventStack.ExtentReports.Model;

namespace Efwatercom.TestMethods
{
    [TestClass]

    public class Category_TestMethode
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\moalgharX\\source\\repos\\Efwatercom\\Data\\HTMLReport\\");
        Categories_POM categories_POM = new Categories_POM(ManageDriver.driver);
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();

        }

        //[ClassCleanup]
        //public static void ClassCleanup()
        //{
        //    extentReports.Flush();
        //    ManageDriver.CloseDriver();
        //}

        [TestMethod]
        public void TestCreate_Bill_valid()
        {
            {
                var test = extentReports.CreateTest("Valid Data", "Test create bill insid category");
                //Categories_POM categories_POM = new Categories_POM(ManageDriver.driver);
                //IJavaScriptExecutor executor = (IJavaScriptExecutor)categories_POM;
                try
                {

                CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                Thread.Sleep(500);
                Login_AssistantMethods.UserLogin();
                CategoryData catDtat = Category_AssistantMethods.ReadDataFromExcel(1);
                Thread.Sleep(500);
                 string ran = categories_POM.RandomString();
                Category_AssistantMethods.CreateNewBill(catDtat);
                Console.WriteLine("data fill");
 
                string ifNameAdded = Category_AssistantMethods.CheckBllAdded(catDtat.BillerName);
                Console.WriteLine(ifNameAdded);
                Assert.IsNotNull(ifNameAdded);
                Console.WriteLine("Test Case completed Successfully");
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
        public void TestEmptyFeild_Bill()
        {
            for (int s = 4; s < 7; s++)
            {

                string testTitle = "";
                string testDescription = "";

                switch (s)
                {
                    case 3:
                        testTitle = "Test Empty Feild";
                        testDescription = "Testing empty name.";
                        break;
                    case 4:
                        testTitle = "Test Empty Feild";
                        testDescription = "Testing empty email.";
                        break;
                    case 5:
                        testTitle = "Test Empty Feild";
                        testDescription = "Testing empty location.";
                        break;

                }

                var test = extentReports.CreateTest(testTitle, testDescription);


                {
                    for (int i = 3; i < 6; i++)
                    {
                        Console.WriteLine(i);

                        //IJavaScriptExecutor executor = (IJavaScriptExecutor)categories_POM;
                        try
                        {

                            CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                            Thread.Sleep(500);
                            Login_AssistantMethods.UserLogin();
                            CategoryData catDtat = Category_AssistantMethods.ReadDataFromExcel(i);
                            Thread.Sleep(500);
                            Category_AssistantMethods.CreateBillWithoutRand(catDtat);
                            Console.WriteLine("data fill");
                            bool actual = categories_POM.IsRequiredMessageShown();
                            Console.WriteLine(actual);
                            Assert.AreEqual(actual, true);

                            Console.WriteLine("Test Case completed Successfully");
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
        [TestMethod]
        public void TestInvalidEmailSyntax()
        {
            {
                var test = extentReports.CreateTest("invalid email syntax", "Test Invalid Email Syntax");

                try
                {

                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    CategoryData catDtat = Category_AssistantMethods.ReadDataFromExcel(2);
                    Thread.Sleep(500);

                    Category_AssistantMethods.CreateBillWithoutRand(catDtat);
                    Console.WriteLine("data fill");
                    bool actual = categories_POM.IsRequiredEmaileShown();
                    Console.WriteLine(actual);
                    Assert.AreEqual(actual, true);

                    Console.WriteLine("Test Case completed Successfully");
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
