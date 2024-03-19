using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.PageObjects
{
    public class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text()='Open Menu']")]
        private IWebElement menu;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logoutLink;

        [FindsBy(How = How.ClassName, Using = "product_label")]
        private IWebElement productLabel;

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        private IList<IWebElement> invetoryItemsList;

        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement cartIcon;

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement productCount;

        By productName = By.ClassName("inventory_item_name");
        By productBtn = By.ClassName("btn_inventory");


        public void ClickMenu()
        {
            menu.Click();
        }

        public void ClickLogout()
        {
            logoutLink.Click();
        }

        public void LogOut()
        {
            ClickMenu();
            ClickLogout();
        }

        public bool PageExists()
        {
            try
            {
                return productLabel.Displayed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddItemTocart(string itemLabel)
        {
            foreach (IWebElement item in invetoryItemsList)
            {
                string product = item.FindElement(productName).Text;

                if (product.Equals(itemLabel))
                {
                    IWebElement addToCartBtn = item.FindElement(productBtn);
                    addToCartBtn.Click();
                }
            }
        }

        public CartPage ClickcartButton()
        {
            cartIcon.Click();
            return new CartPage(this.driver);
        }

        public int GetProductCount()
        {
            return Convert.ToInt32(productCount.Text);
        }

        public void ClickRemoveBtn(string itemLabel)
        {
            foreach (IWebElement item in invetoryItemsList)
            {
                string product = item.FindElement(productName).Text;


                if (product.Equals(itemLabel))
                {
                    IWebElement removeBtn = item.FindElement(productBtn);
                    if (removeBtn.Text.Equals("REMOVE"))
                    {
                        removeBtn.Click();
                    }
                    else
                    {
                        Assert.Fail("The remove button did not appear");
                    }
                }
            }
        }
    }
}
