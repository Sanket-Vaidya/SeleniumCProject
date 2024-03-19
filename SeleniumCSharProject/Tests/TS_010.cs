using SeleniumCSharProject.PageObjects;
using SeleniumCSharProject.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class TS_010 : BaseClass
    {
        LoginPage lp;
        ProductPage prdtPg;
        CartPage cPg;
        CheckOutPage coPg;
        CheckoutOverViewPage covPg;
        FinishPage fp;

        [Test]
        public void EndToEndTest()
        {
            lp = new LoginPage(GetDriver());
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string product1 = ConfigurationManager.AppSettings["product1"];
            string product2 = ConfigurationManager.AppSettings["product2"];
            string firstName = "Sanket";
            string lastName = "Vaidya";
            string zipCode = "412207";
            string expectedMessage = "THANK YOU FOR YOUR ORDER";
            List<string> productsAddedTocart = new List<string>();
            productsAddedTocart.Add(product1);
            productsAddedTocart.Add(product2);
            bool productAvailableInCart = false;
            decimal totalPrice;
            decimal priceDisplayed;

            prdtPg = lp.Login(username, password);

            if (prdtPg != null)
            {
                prdtPg.AddItemTocart(product1);
                prdtPg.AddItemTocart(product2);
                cPg = prdtPg.ClickcartButton();
                totalPrice = cPg.GetTotalPrice();
                coPg = cPg.ClickCheckoutBtn();
                coPg.EnterInformation(firstName, lastName, zipCode);
                covPg = coPg.ClickContinuebtn();
                List<string> products = covPg.GetProductnames();

                foreach (string product in productsAddedTocart)
                {
                    foreach (string addedProducts in products)
                    {
                        if (addedProducts.Contains(product))
                        {
                            productAvailableInCart = true;
                        }

                    }
                    if (!productAvailableInCart)
                    {
                        Assert.Fail($"{product} not added to cart");
                    }
                }

                priceDisplayed = covPg.GetTotalPrice();
                Assert.AreEqual(totalPrice, priceDisplayed);
                fp = covPg.ClickFinishButton();
                string actualMessage=fp.GetMessage();
                Assert.AreEqual(expectedMessage, actualMessage);

            }
            else
            {
                Assert.Fail("Could not launch product page");
            }

        }
    }
}
