using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Efwatercom.Helpers;
using Efwatercom.POM;

namespace Efwatercom.AssistantMethods
{
    public class Login_AssistantMethods
    {

        public static void UserLogin()
        {
           
            LoginPage login_POM = new LoginPage(ManageDriver.driver);
            login_POM.EnterEmail("Admin");
            login_POM.EnterPassword("123456");
            login_POM.ClickSignInButton();

        }
    }
}
