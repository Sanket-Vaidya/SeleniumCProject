using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement usernameTextBox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginBtn;

        [FindsBy(How = How.XPath, Using = "//h3[text()='Username and password do not match any user in this service']")]
        private IWebElement errorMsg;

        [FindsBy(How = How.ClassName, Using = "error-button")]
        private IWebElement errorBtn;

        public void EnterUserName(string username)
        {
            usernameTextBox.Clear();
            usernameTextBox.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
        }

        public void ClickLogin()
        {
            loginBtn.Click();
        }

        public bool ErrorMsgExists()
        {
            try
            {
                return errorMsg.Displayed;
                errorBtn.Click();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ProductPage Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
            return new ProductPage(this.driver);

        }
    }
}
