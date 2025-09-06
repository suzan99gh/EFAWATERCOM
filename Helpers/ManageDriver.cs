using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Efwatercom.Helpers
{
    public class ManageDriver
    {
        public static IWebDriver driver = new ChromeDriver();

        public static void MaximizeDriver()
        {
            driver.Manage().Window.Maximize();
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }
    }
}