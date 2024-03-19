using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class CheckoutOverViewPage
    {
        IWebDriver driver;
        public CheckoutOverViewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cart_item_label")]
        private IList<IWebElement> checkOutItemsList;

        [FindsBy(How = How.ClassName, Using = "summary_subtotal_label")]
        private IWebElement totalPrice;

        [FindsBy(How = How.ClassName, Using = "cart_button")]
        private IWebElement finishBtn;

        By productLabel = By.ClassName("inventory_item_name");

        public List<string> GetProductnames()
        {
            List<string> product = new List<string>();
            foreach (IWebElement item in checkOutItemsList)
            {
                string productname = item.FindElement(productLabel).Text;
                product.Add(productname);
            }
            return product;
        }

        public decimal GetTotalPrice()
        {
            string text = totalPrice.Text;
            var price = (Regex.Split(text, @"[^0-9\.]+"));
            return Convert.ToDecimal(price[1]);
        }

        public FinishPage ClickFinishButton()
        {
            finishBtn.Click();
            return new FinishPage(this.driver);
        }

    }
}
