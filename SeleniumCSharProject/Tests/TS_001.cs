using OrangeHRM_Test.Utilities;
using SeleniumCSharProject.PageObjects;
using SeleniumCSharProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharProject.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class TS_001 : BaseClass
    {
        LoginPage lp;
        ProductPage pdtPg;
        [Test, TestCaseSource("AddTestdataConfig")]
        public void LoginFunctionality(string username, string password, string result)
        {
            lp = new LoginPage(GetDriver());
            pdtPg= new ProductPage(GetDriver());
           // string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\TestData\Testdata.xls";
          //  string[,] testData = ExcelUtilities.ReadExcel(filePath);

            
            {
                string userName = username;
                string passWord = password;
                string Result = result;

                lp.EnterUserName(username);
                lp.EnterPassword(password);
                lp.ClickLogin();

                bool PageExists = pdtPg.PageExists();

                if (result.Equals("Pass"))
                {
                    if (PageExists)
                    {
                        Assert.True(true);
                        pdtPg.LogOut();
                    }
                    else
                    {
                        {
                            Assert.True(false);
                        }
                    }
                }
                else
                {
                    if (PageExists)
                    {
                        Assert.True(false);
                    }
                    else
                    {
                        Assert.True(true);
                    }
                }
            }
        }
    }
}
