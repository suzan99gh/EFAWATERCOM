using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efwatercom.Helpers;
using OpenQA.Selenium;

namespace Efwatercom.POM
{
    public class LoginPage
    {
        IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By loginInHomePageBtn = By.XPath("//div/div/a[contains(text(), 'Login')]");
        By inputEmail = By.XPath("//div/form/input[@type='email']");
        By inputPassword = By.XPath("//div/form/input[@type='password']");
        By signInBtn = By.XPath("//div/form/button[contains(text(), 'SIGN IN')]");

        public void ClickLoginButton()
        {
            CommonMethods.WaitAndFindElement(loginInHomePageBtn).Click();
        }
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(inputEmail);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(inputPassword);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }
        public void ClickSignInButton()
        {
            CommonMethods.WaitAndFindElement(signInBtn).Click();
        }

    }
}
