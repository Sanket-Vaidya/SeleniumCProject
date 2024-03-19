using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class CheckOutPage
    {
        IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement firstNameTextbox;

        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement lastNameTextbox;

        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement zipCodeTextbox;

        [FindsBy(How = How.ClassName, Using = "cart_button")]
        private IWebElement continueBtn;

        public void EnterFirstName(string firstName)
        {
            firstNameTextbox.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            lastNameTextbox.SendKeys(lastName);
        }

        public void EnterZipCode(string zipCode)
        {
            zipCodeTextbox.SendKeys(zipCode);
        }

        public CheckoutOverViewPage ClickContinuebtn()
        {
            continueBtn.Click();
            return new CheckoutOverViewPage(this.driver);
        }

        public void EnterInformation(string firstName, string lastName, string zipCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterZipCode(zipCode);
        }
    }
}
