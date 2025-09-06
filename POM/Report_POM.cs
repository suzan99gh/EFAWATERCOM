using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Efwatercom.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Efwatercom.POM
{
    public class Report_POM
    {
        IWebDriver _driver;

        public Report_POM(IWebDriver driver)
        {
            _driver = driver;
        }

        By reportSaidBar = By.XPath("(//div/ul/li/a)[3]");
        By selectCategory = By.XPath("//div/form/div/select");
        By selectFirstOption = By.XPath("(//div/form/div/select/option)[2]");
        By selectSeondOption = By.XPath("(//div/form/div/select/option)[3]");
        By selectThirdOption = By.XPath("(//div/form/div/select/option)[4]");
        By rowOfTable = By.XPath("//div/table/tbody/tr");
        By dateFrom = By.XPath("//div/input[@formcontrolname='DateFrom']");
        By dateTo = By.XPath("//div/input[@formcontrolname='DateTo']");
        By enterBillerName = By.XPath("//form/div/select[@formcontrolname='Billercategoryname']");
        public void EnterBillerName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterBillerName);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterDateFrom(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(dateFrom);
            CommonMethods.Highlightelement(element);

            ((IJavaScriptExecutor)ManageDriver.driver)
                .ExecuteScript("arguments[0].removeAttribute('readonly')", element);
            Console.WriteLine(value);
            element.Clear();
            element.SendKeys(value);
        }
        public void EnterDateTo(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(dateTo);
            CommonMethods.Highlightelement(element);

            ((IJavaScriptExecutor)ManageDriver.driver)
                .ExecuteScript("arguments[0].removeAttribute('readonly')", element);
            Console.WriteLine(value);
            element.Clear();
            element.SendKeys(value);
        }


        //By enterEmailCat = By.XPath("//div/div/input[@formcontrolname='Email']");
        //By enterLocationCat = By.XPath("//div/div/input[@formcontrolname='Location']");


        //public int  NumberOfRow() 
        //{
        //    IReadOnlyCollection<IWebElement> rows = _driver.FindElements(rowOfTable);
        //    int numberOfRows = rows.Count;

        //    Console.WriteLine("Number of rows: " + numberOfRows);
        //    return numberOfRows;
        //}
        public int ClickRandomOption()
        {
            IWebElement options = _driver.FindElement(By.XPath("//div/form/div/select"));

            IReadOnlyCollection<IWebElement> number = options.FindElements(By.TagName("option"));
            int numberOfOption = number.Count;
            Console.WriteLine("Number of options: " + numberOfOption);

            Random rand = new Random();
            int randomIndex = rand.Next(1, numberOfOption);
            By click = By.XPath($"(//div/form/div/select/option)[{randomIndex}]");

            CommonMethods.WaitAndFindElement(click).Click();

            Console.WriteLine($"Ran num{randomIndex}");

            return randomIndex;

        }

        public int NumberOfRow()
        {
            IReadOnlyCollection<IWebElement> rows = _driver.FindElements(rowOfTable);
            int numberOfRows = rows.Count;

            Console.WriteLine("Number of rows: " + numberOfRows);
            return numberOfRows;
        }
        public void ClickrReportSaidBar()
        {
            CommonMethods.WaitAndFindElement(reportSaidBar).Click();
        }

        public void ClickrCategoryOption()
        {
            CommonMethods.WaitAndFindElement(selectCategory).Click();
        }

        public void ChooseFirstOption()
        {
                CommonMethods.WaitAndFindElement(selectFirstOption).Click();
           

        }
        public string TextFirstOption()
        {

            IWebElement Text = _driver.FindElement(selectFirstOption);
            string optionText = Text.Text;
            return optionText;
        }

        public void ChooseSeonedOption()
        {
            CommonMethods.WaitAndFindElement(selectSeondOption).Click();

        }

        public void ChooseThirdOption()
        {
            CommonMethods.WaitAndFindElement(selectThirdOption).Click();
        }
    }
}
