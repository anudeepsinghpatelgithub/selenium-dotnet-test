using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWithMSTest.Pages
{
    public class CommonFunctions
    {
        IWebDriver driver;
        WebDriverWait wait;
        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        public void EnterTextInInput(IWebElement el, string value)
        {
            el.Clear();
            el.SendKeys(value);
        }

        public void ClickOnElement(IWebElement el)
        {
            el.Click();
        }

    }


}
