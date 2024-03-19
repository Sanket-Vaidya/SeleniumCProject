using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Model;
using CSharpSeleniumFrameWork.Utilities;

namespace SeleniumCSharProject.Utilities
{
    public class BaseClass
    {
        public string browserName;
        // public static IWebDriver driver;
        public ExtentReports extentReports;
        ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + $"//{TestContext.CurrentContext.Test.Name}_Report.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Host Name", "Local Host");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("Username", "Sanket.Vaidya");
        }
        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            string url = ConfigurationManager.AppSettings["url"];
            InitBrowser(browserName);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Url = url;
        }

        public void InitBrowser(string browserName)
        {

            switch (browserName)
            {
                case "Chrome":
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    driver.Value = new EdgeDriver();
                    break;
                case "Firefox":
                    driver.Value = new FirefoxDriver();
                    break;
            }

        }

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }

        [TearDown]
        public void Closebrowser()
        {
            var result = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (result == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "Test failed with logtrace " + stackTrace);
            }
            else if (result == NUnit.Framework.Interfaces.TestStatus.Passed)
            {

            }
            extentReports.Flush();
            driver.Value.Quit();
        }

        public Media captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }

        public static IEnumerable<TestCaseData> AddTestdataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("[0].username"), getDataParser().extractData("[0].password"), getDataParser().extractData("[0].result"));
            yield return new TestCaseData(getDataParser().extractData("[1].username"), getDataParser().extractData("[1].password"), getDataParser().extractData("[1].result"));
            yield return new TestCaseData(getDataParser().extractData("[2].username"), getDataParser().extractData("[2].password"), getDataParser().extractData("[2].result"));
            yield return new TestCaseData(getDataParser().extractData("[3].username"), getDataParser().extractData("[3].password"), getDataParser().extractData("[3].result"));
            yield return new TestCaseData(getDataParser().extractData("[4].username"), getDataParser().extractData("[4].password"), getDataParser().extractData("[4].result"));
        }

        public static JSONReader getDataParser()
        {
            return new JSONReader();
        }
    }
}
