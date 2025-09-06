using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Efwatercom.AssistantMethods;
using Efwatercom.Data;
using Efwatercom.Helpers;
using Efwatercom.POM;

namespace Efwatercom.TestMethods
{
    [TestClass]
    public class Account_TestMethode
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\moalgharX\\source\\repos\\Efwatercom\\Data\\HTMLReport\\");
        Account_POM account_POM = new Account_POM(ManageDriver.driver);
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
        public void TestUpdate_valid()
        {
            {
                var test = extentReports.CreateTest("Valid Data", "Test Update Account with valid data.");
               
                try
                {

                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    Thread.Sleep(1500);

                    AccountData accountData = Account_AssistantMethods.ReadDataFromExcel(1);
                    Account_AssistantMethods.UpdateAccount(accountData);
                    Console.WriteLine("data fill");
                    String actualNameAfterUpdate =  Account_AssistantMethods.CheckSuccessNameUpdate(accountData.FullName);
                    string expectedName = accountData.FullName;
                    Console.WriteLine($"Expected name after update : {accountData.FullName}");
                    Console.WriteLine($"Actual name after update : {actualNameAfterUpdate}");
                    
                    Assert.AreEqual(expectedName, actualNameAfterUpdate);   
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
        public void TestInvalidEmailSyntax()
        {
            {
                var test = extentReports.CreateTest("invalid email syntax", "Test Invalid Email Syntax");

                try
                {

                    CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                    Thread.Sleep(500);
                    Login_AssistantMethods.UserLogin();
                    AccountData accountData = Account_AssistantMethods.ReadDataFromExcel(4);
                    Account_AssistantMethods.UpdateAccount(accountData);
                    Console.WriteLine("data fill");
                    bool actual = account_POM.IsRequiredEmaileShown();
                    Console.WriteLine($" Are the expected message shown : {actual}");
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

        [TestMethod]
        public void TestEmptyFeild_UpdateAccount()
        {
            for (int i = 6; i < 12; i++)
            {

                string testTitle = "";
                string testDescription = "";

                switch (i)
                {
                    case 6:
                        testTitle = "Test Empty Feild";
                        testDescription = "Testing empty name.";
                        break;
                    case 7:
                        testTitle = "Test Empty Feild";
                        testDescription = "Empty phone number.";
                        break;
                    case 8:
                        testTitle = "Test Empty Feild";
                        testDescription = "Empty email.";
                        break;
                    case 9:
                        testTitle = "Test Empty Feild";
                        testDescription = "Empty Current password.";
                        break;
                    case 10:
                        testTitle = "Test Empty Feild";
                        testDescription = "Empty address.";
                        break;
                    case 11:
                        testTitle = "Empty address";
                        testDescription = "Empty user name.";
                        break;
                    

                }

                var test = extentReports.CreateTest(testTitle, testDescription);


                {
                    try
                    {
                        CommonMethods.NavigateToURL(GlobalConstant.LoginLink);
                        Thread.Sleep(500);
                        Login_AssistantMethods.UserLogin();
                        Thread.Sleep(1500);

                        AccountData accountData = Account_AssistantMethods.ReadDataFromExcel(i);
                        Account_AssistantMethods.UpdateAccount(accountData);
                        Console.WriteLine("data fill");
                        bool actual = account_POM.IsRequiredMessageShown();
                        Console.WriteLine($"Is requerd Message show : {actual}");
                        Assert.AreEqual(actual, true);
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
}
