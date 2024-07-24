using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.PageObject
{
    public class GoogleResultPage
    {
        private IWebDriver driver;
        private ReadOnlyCollection<IWebElement> results;

        public GoogleResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsExistResult()
        {
            IWebElement pageElement = driver.FindElement(By.Id("search"));
            results = pageElement.FindElements(By.XPath(".//a"));
            return results.Count > 0;
        }


        public void ClickFirstResultTitle()
        {
            results[0].FindElement(By.TagName("h3")).Click();
        }


    }
}
