using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWithMSTest.Helper;

namespace SeleniumWithMSTest.Pages
{
    public class ComputerOperationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ComputerOperationPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.FLUENT_WAIT));
        }

        private IWebElement ComputerNameInput => driver.FindElement(By.Id("name"));
        private IWebElement IntroducedInput => driver.FindElement(By.Id("introduced"));
        private IWebElement DiscontinuedInput => driver.FindElement(By.Id("discontinued"));
        private IWebElement CompanySelect => driver.FindElement(By.Id("company"));
        private IWebElement CreateComputerBtn => driver.FindElement(By.XPath("//input[@value='Create this computer']"));
        private IWebElement DeleteThisComputerBtn => driver.FindElement(By.XPath("//input[@value='Delete this computer']"));

        public void FillCompanyName(string name)
        {
            ComputerNameInput.Clear();
            ComputerNameInput.SendKeys(name);
        }

        public void FillIntroduced(string date)
        {
            IntroducedInput.Clear();
            IntroducedInput.SendKeys(date);
        }

        public void FillDiscontinued(string date)
        {
            DiscontinuedInput.Clear();
            DiscontinuedInput.SendKeys(date);
        }

        public void SelectCompany(string name)
        {
            var selectElement = new SelectElement(CompanySelect);
            // select by text
            selectElement.SelectByText(name);
        }

        public void ClickOnCreateComputerButton()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CreateComputerBtn));
            CreateComputerBtn.Click();
        }

        public void CreateNewComputer(string Name, string Introduced,string Discontinued, string Company)
        {
            FillCompanyName(Name);
            FillIntroduced(Introduced);
            FillDiscontinued(Discontinued);
            SelectCompany(Company);
            ClickOnCreateComputerButton();
        }

        public void ClickOnDeleteThisCOmputerButton()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DeleteThisComputerBtn));
            DeleteThisComputerBtn.Click();
        }

    }
}
