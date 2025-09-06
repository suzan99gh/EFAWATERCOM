using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efwatercom.Helpers;
using OpenQA.Selenium;

namespace Efwatercom.POM
{
    public class Account_POM
    {
        IWebDriver _driver;

        public Account_POM(IWebDriver driver)
        {
            _driver = driver;
        }
        By requerdMsg = By.XPath("//div/mat-error");
        By requerdEmailSyntax = By.XPath("//div/mat-error[contains(text(), 'invalid email')]");

        By profileSaidBar = By.XPath("//div/ul/li/a[contains(text(), ' Profile ')]");
        By enterFullName = By.XPath("//div/div/input[@formcontrolname='FullName']");
        By enterPhoneNumber = By.XPath("//div/div/input[@formcontrolname='PhoneNumber']");
        By enterEmail = By.XPath("//div/div/input[@formcontrolname='Email']");
        By enterCurntPassword = By.XPath("//div/div/input[@formcontrolname='password']");
        By enterPassword = By.XPath("//div/div/input[@formcontrolname='curenrpassword']");
        By enterAddress = By.XPath("//div/div/input[@formcontrolname='address']");
        By enterUserName = By.XPath("//div/div/input[@formcontrolname='username']");
        By enterPhoto = By.XPath("//div/div/input[@type='file']");
        By UpdateBtn = By.XPath("//div/div/button[@class='bac']");

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
        public void ClickUpdateBTN()
        {
            CommonMethods.WaitAndFindElement(UpdateBtn).Click();
        }

        public void EnterPhoto(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterPhoto);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterUserName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterUserName);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterAddress(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterAddress);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterPasswoed(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterPassword);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }


        public void EnterCurrentPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterCurntPassword);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterFullName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterFullName);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void EnterphoneNumber(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterPhoneNumber);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void ClickSaidBarBtn()
        {
            CommonMethods.WaitAndFindElement(profileSaidBar).Click();
        }
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(enterEmail);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
    }
}
