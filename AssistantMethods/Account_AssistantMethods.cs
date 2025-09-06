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
using ServiceStack.Script;

namespace Efwatercom.AssistantMethods
{
    public class Account_AssistantMethods
    {
        public IWebDriver _webDriver;

        public Account_AssistantMethods(IWebDriver driver)

        {
            _webDriver = driver;

        }

        public static IJavaScriptExecutor drive;
        private static readonly IWebDriver driver;

        public static void UpdateAccount(AccountData accountData)
        {
            Account_POM account_POM = new Account_POM(ManageDriver.driver);
    
            account_POM.ClickSaidBarBtn();
            account_POM.EnterFullName(accountData.FullName);
            account_POM.EnterphoneNumber(accountData.PhoneNumber);
            account_POM.EnterEmail(accountData.Email);
            account_POM.EnterCurrentPassword(accountData.CurrentPassword);
            account_POM.EnterAddress(accountData.Address);
            account_POM.EnterUserName(accountData.User);
            account_POM.EnterPasswoed(accountData.NewPassword);
            account_POM.ClickUpdateBTN();

        }
        public static AccountData ReadDataFromExcel(int row)
        {
            Worksheet workSheet = CommonMethods.ReadExcel("Acount data");
            AccountData accountData = new AccountData();
            accountData.FullName = Convert.ToString(workSheet.Cell(row, 1).Value);
            accountData.PhoneNumber = Convert.ToString(workSheet.Cell(row, 2).Value);
            accountData.Email = Convert.ToString(workSheet.Cell(row, 3).Value);
            accountData.CurrentPassword = Convert.ToString(workSheet.Cell(row, 4).Value);
            accountData.Address = Convert.ToString(workSheet.Cell(row, 5).Value);
            accountData.User = Convert.ToString(workSheet.Cell(row, 6).Value);
            accountData.NewPassword = Convert.ToString(workSheet.Cell(row, 7).Value);
            accountData.Photo = Convert.ToString(workSheet.Cell(row, 8).Value);
            return accountData;
        }
        public static string CheckSuccessNameUpdate(string name)
        {
            using (OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString))
            {
                oracleConnection.Open();

                string query = "SELECT FULLNAME FROM USERF WHERE FULLNAME = :value";
                OracleCommand command = new OracleCommand(query, oracleConnection);
                command.Parameters.Add(new OracleParameter("value", name)); 

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }
        //public static string CheckSuccessNameUpdate(string name)
        //{
        //    OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString);
        //    oracleConnection.Open();

        //    string query = "SELECT FULLNAME FROM USERF WHERE FULLNAME == :value";
        //    OracleCommand command = new OracleCommand(query, oracleConnection);
        //    command.Parameters.Add(new OracleParameter(":value", name));
        //    string newName = command.ExecuteScalar();
        //    int result = Convert.ToInt32(command.ExecuteScalar());
        //    return result;
        //}


    }
}
