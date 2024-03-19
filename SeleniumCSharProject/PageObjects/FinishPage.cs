using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class FinishPage
    {
        IWebDriver driver;
        public FinishPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "complete-header")]
        private IWebElement message;

        public string GetMessage()
        {
            return message.Text;
        }
    }
}
