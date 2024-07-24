using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.PageObject
{
    public class GoogleHomePage
    {
        private IWebDriver driver;

        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement searchBox => driver.FindElement(By.Name("q"));

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void Search(string searchText)
        {

            searchBox.SendKeys("Selenium Driver");
            searchBox.Submit(); 
        }
    }
}
