using SeleniumCSharProject.PageObjects;
using SeleniumCSharProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class TS_002 : BaseClass
    {
        LoginPage lp;
        ProductPage prdtPg;
        CartPage cp;

        [Test, Order(1)]
        public void TC_ATC_001_AddSingleItemToCart()
        {
            lp = new LoginPage(GetDriver());
            prdtPg = lp.Login("standard_user", "secret_sauce");
            string itemToAddTocart = "Sauce Labs Fleece Jacket";
            if (prdtPg != null)
            {
                prdtPg.AddItemTocart(itemToAddTocart);
                cp = prdtPg.ClickcartButton();
                bool itemIsAddedToCart = cp.ItemAddedTocart(itemToAddTocart);
                if (itemIsAddedToCart)
                {
                    Assert.True(true);
                }
                else { Assert.False(true); }
            }
            else
            {
                Console.WriteLine("Login failed");
                Assert.Fail();
            }
        }

        [Test, Order(2)]
        public void TC_ATC_002_AddMultipleItemToCart()
        {
            lp = new LoginPage(GetDriver());
            prdtPg = lp.Login("standard_user", "secret_sauce");
            string firstItemToAddTocart = "Sauce Labs Fleece Jacket";
            string secondItemToAddTocart = "Sauce Labs Onesie";
            if (prdtPg != null)
            {
                prdtPg.AddItemTocart(firstItemToAddTocart);
                prdtPg.AddItemTocart(secondItemToAddTocart);
                cp = prdtPg.ClickcartButton();
                bool firstItemIsAddedToCart = cp.ItemAddedTocart(firstItemToAddTocart);
                bool secondItemIsAddedToCart = cp.ItemAddedTocart(secondItemToAddTocart);
                if (firstItemIsAddedToCart && secondItemIsAddedToCart)
                {
                    Assert.True(true);
                }
                else { Assert.False(true); }

            }
            else
            {
                Console.WriteLine("Login failed");
                Assert.Fail();
            }

        }
    }
}
