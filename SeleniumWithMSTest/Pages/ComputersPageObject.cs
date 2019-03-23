using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWithMSTest.Helper;

namespace SeleniumWithMSTest.Pages
{
    public class ComputersPageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ComputersPageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.FLUENT_WAIT));
            //PageFactory.InitElements(driver, this); deprecated from 3.11

        }
        //[FindsBy(How = How.Id, Using = "searchbox")] 
        private IWebElement SearchInput => driver.FindElement(By.Id("searchbox"));

        //[FindsBy(How = How.Id, Using = "searchsubmit")]
        private IWebElement SearchBtn => driver.FindElement(By.Id("searchsubmit"));

        private IWebElement ComputerLink(string name) => driver.FindElement(By.XPath($"//a[text()='{name}']"));

        private IWebElement AddComputerBtn => driver.FindElement(By.Id("add"));

        public void FillSearchInput(string value)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(value);
        }

        public void ClickOnSearchButton()
        {
            SearchBtn.Click();
        }

        public void ClickOnComputerByName(string name)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ComputerLink(name)));
            ComputerLink(name).Click();
        }

        public void ClickOnAddComputerButton()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddComputerBtn));
            AddComputerBtn.Click();
        }


        public void SearchComputer(string name)
        {
            FillSearchInput(name);
            ClickOnSearchButton();
        }

    }
}
