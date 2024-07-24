using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumNUnitExample.PageObject;
using NUnit.Framework.Interfaces;
using System.Xml;

namespace SeleniumNUnitExample
{

    [TestFixture]
    internal class GoogleSearchTest
    {
        private IWebDriver driver;
        private GoogleHomePage homePage;
        private GoogleResultPage resultPage;

        public static IEnumerable<TestData> TestCases => XmlDataReader.ReadData("D:\\תכנות\\שנה ב\\אוטומציה\\lesson 1\\SeleniumNUnitExample\\SeleniumNUnitExample\\TestData.xml.txt");

        public GoogleSearchTest()
        {

        }

        [SetUp]
        public void Setup()
        {
            string driverPath = "C:\\chromedriver-win64\\chromedriver-win64";
            driver = new ChromeDriver(driverPath);
            homePage = new GoogleHomePage(driver);
            resultPage = new GoogleResultPage(driver);  
        }

        [Test,TestCaseSource(nameof(TestCases))]
        public void GoogleSearchTest1(TestData testdata)
        {
            homePage.NavigateTo();
            Assert.AreEqual("Google", driver.Title);

            homePage.Search(testdata.termSearch);

            System.Threading.Thread.Sleep(2000);
            Assert.IsTrue(driver.Title.Contains("Selenium Driver"));

            Assert.IsTrue(resultPage.IsExistResult());

            resultPage.ClickFirstResultTitle();

            Assert.IsTrue(driver.Title.Contains("WebDriver"));

            driver.Navigate().Back();
            Assert.AreEqual(testdata.termSearch, driver.FindElement(By.Name("q")).GetAttribute("value"));





        }

        [TearDown]
        public void Teardown()
        {
            driver.Dispose();
        }
    }
}

