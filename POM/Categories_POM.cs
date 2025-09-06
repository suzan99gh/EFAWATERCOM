using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efwatercom.Helpers;
using OpenQA.Selenium;

namespace Efwatercom.POM
{
    public class Categories_POM
    {
        IWebDriver _driver;

        public Categories_POM(IWebDriver driver)
        {
            _driver = driver;
        }


        By catSaidBar = By.XPath("//div/ul/li/a[contains(text(), ' Category ')]");
        By enterBillerName = By.XPath("//div/div/input[@formcontrolname='Billname']");
        By enterEmail = By.XPath("//div/div/input[@formcontrolname='Email']");
        By enterLocation = By.XPath("//div/div/input[@formcontrolname='Location']");
        By enterDeductedCat = By.XPath("//div/div/input[@formcontrolname='deducted']");
        By createBtnCat = By.XPath("//div/button[contains(text(), 'create')]");
        By requerdMsg = By.XPath("//div/mat-error[contains(text(), '*required')]");
        By requerdEmailSyntax = By.XPath("//div/mat-error[contains(text(), '*emeil required')]");
       
     
        public bool IsRequiredMessageShown()
        {
            try
            {
                return _driver.FindElement(requerdMsg).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsRequiredEmaileShown()
        {
            try
            {
                return _driver.FindElement(requerdEmailSyntax).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public int ClickCreateBillBtn()
        {// Find the specific row (e.g., first row)
            IWebElement table = _driver.FindElement(By.XPath("//div/table"));

            // Get all the <td> cells in that row
            IReadOnlyCollection<IWebElement> row = table.FindElements(By.TagName("tbody"));

            // Get the number of columns (tds)
            int numberOfCells = row.Count;
         

            Console.WriteLine("Number of <td> in the row: " + numberOfCells);

            Random rand = new Random();
            int randomIndex = rand.Next(1, numberOfCells); 
            By createBILLBtn = By.XPath($"(//tr/td/button[contains(text(), 'Create')])[{randomIndex}]");
          
            IWebElement element = CommonMethods.WaitAndFindElement(createBILLBtn);
            CommonMethods.Highlightelement(element);
            Console.WriteLine($"Ran num{randomIndex}");

            element.Click(); 
            return randomIndex;

        }
        public string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            return new string(Enumerable.Repeat(chars, 2)
                                        .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public void ClickCategory()
        {
            CommonMethods.WaitAndFindElement(catSaidBar).Click();
        }

      
        public void EnterBillerName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterBillerName);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

       

        public void EnterBillerEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterEmail);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterBillerLocation(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterLocation);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterBillerDeducted()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterDeductedCat);
            CommonMethods.Highlightelement(element);
         
        }
        public void ClickCreateBtn()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(createBtnCat);
            CommonMethods.Highlightelement(element);
            element.Click();
        }
    }
}
