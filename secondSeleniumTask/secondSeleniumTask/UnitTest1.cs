using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace secondSeleniumTask
{
    public class Tests
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {

            string driverPath = "C:\\chromedriver-win64\\chromedriver-win64";
            driver = new ChromeDriver(driverPath);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [Test]
        public void TestHandleAlert()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            var button = driver.FindElement(By.Id("timerAlertButton"));
            button.Click();

            IAlert alert = WaitForAlert(driver, 10);
            Assert.IsNotNull(alert, "allert is not exist!!");
            alert.Accept();

        }

        [Test]
        public void WindowsAndTabs()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/brouser-windows");

            var button = driver.FindElement(By.Id("windowButton"));
            button.Click();

            var currentWindow = driver.CurrentWindowHandle;
            WaitForWindows(driver, 10);

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != currentWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
            var newWindowTitle = driver.FindElement(By.Id("sampleHeading"));
            Assert.AreEqual("This is a sample page", newWindowTitle.Text);

            driver.Close();
            driver.SwitchTo().Window(currentWindow);

        }
        private IAlert WaitForAlert(IWebDriver driver, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private void WaitForWindows(IWebDriver driver, int expectedWindowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d=>d.WindowHandles.Count() == expectedWindowCount);

        }

        [TearDown]
        public void Teardown()
        {
            driver.Dispose();
        }
    }
}