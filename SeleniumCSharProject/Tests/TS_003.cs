using SeleniumCSharProject.PageObjects;
using SeleniumCSharProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.Tests
{
    public class TS_003 : BaseClass
    {
        LoginPage lp;
        ProductPage prdtPg;

        [Test]
        public void TestRemoveButton()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string firstItemToAddTocart = "Sauce Labs Fleece Jacket";
            string secondItemToAddTocart = "Sauce Labs Onesie";
            int expectedProductCount = 2;
            int actualProductCount;
            int expectedProductCountAfterRemove = 1;

            lp = new LoginPage(GetDriver());
            prdtPg = lp.Login(userName, password);
            prdtPg.AddItemTocart(firstItemToAddTocart);
            prdtPg.AddItemTocart(secondItemToAddTocart);
            actualProductCount = prdtPg.GetProductCount();
            Assert.AreEqual(expectedProductCount, actualProductCount);

            prdtPg.ClickRemoveBtn(firstItemToAddTocart);
            actualProductCount=prdtPg.GetProductCount();
            Assert.AreEqual(expectedProductCountAfterRemove, actualProductCount);

        }
    }
}
