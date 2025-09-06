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
using Oracle.ManagedDataAccess.Client;

namespace Efwatercom.AssistantMethods
{
    public class Category_AssistantMethods
    {
        public IWebDriver _webDriver;

        public Category_AssistantMethods(IWebDriver driver)

        {
            _webDriver = driver;

        }
        public static IJavaScriptExecutor drive;
        private static readonly IWebDriver driver;

        public static void CreateNewBill(CategoryData catData)
        {
            Categories_POM categories_POM = new Categories_POM(ManageDriver.driver);
            Thread.Sleep(500);
            categories_POM.ClickCreateBillBtn();
            categories_POM.EnterBillerName(catData.BillerName + categories_POM.RandomString());
            categories_POM.EnterBillerEmail(catData.Email);
            categories_POM.EnterBillerLocation(catData.Location);
            Thread.Sleep(500);
            categories_POM.ClickCreateBtn();

        }

        public static void CreateBillWithoutRand(CategoryData catData)
        {
            Categories_POM categories_POM = new Categories_POM(ManageDriver.driver);
            Thread.Sleep(500);
            categories_POM.ClickCreateBillBtn();
            categories_POM.EnterBillerName(catData.BillerName);
            categories_POM.EnterBillerEmail(catData.Email);
            categories_POM.EnterBillerLocation(catData.Location);
            Thread.Sleep(500);
            categories_POM.ClickCreateBtn();

        }


        public static CategoryData ReadDataFromExcel(int row)
        {
            Worksheet workSheet = CommonMethods.ReadExcel("Sheet1");
            CategoryData catData = new CategoryData();
            catData.BillerName = Convert.ToString(workSheet.Cell(row, 1).Value);
            catData.Email = Convert.ToString(workSheet.Cell(row, 2).Value);
            catData.Location = Convert.ToString(workSheet.Cell(row, 3).Value);
            return catData;
        }

        public static string CheckBllAdded(string billadded)
        {
            using (OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString))
            {
                oracleConnection.Open();

                string query = "SELECT BILLNAME FROM BILLERNAME WHERE BILLNAME = :value";
                using (OracleCommand command = new OracleCommand(query, oracleConnection))
                {
                    command.Parameters.Add(new OracleParameter("value", billadded)); // No colon here in parameter name

                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }
    }
}
