using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cart_item_label")]
        private IList<IWebElement> cartItemsList;

        [FindsBy(How = How.ClassName, Using = "checkout_button")]
        private IWebElement checkoutBtn;

        By productName = By.ClassName("inventory_item_name");
        By productPrice = By.ClassName("inventory_item_price");


        public bool ItemAddedTocart(string itemLabel)
        {
            bool productIsAdded = false;
            foreach (IWebElement product in cartItemsList)
            {
                string productLabel = product.FindElement(productName).Text;
                if (productLabel.Equals(itemLabel))
                {
                    productIsAdded = true;
                }

            }
            return productIsAdded;
        }

        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach (IWebElement cartItem in cartItemsList)
            {
                price += Convert.ToDecimal(cartItem.FindElement(productPrice).Text);
            }
            return price;
        }

        public CheckOutPage ClickCheckoutBtn()
        {
            checkoutBtn.Click();
            return new CheckOutPage(this.driver);
        }


    }
}
