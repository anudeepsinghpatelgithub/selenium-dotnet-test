using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithMSTest.Helper;
using SeleniumWithMSTest.Pages;

namespace SeleniumWithMSTest
{
    [TestClass]
    public class AddComputerTests
    {
        static IWebDriver driver;
        private ComputersPageObject computersPageObject;
        private ComputerOperationPage computerOperationPage;
        string name;

        [ClassInitialize]
        public static void InitialSetup(TestContext  context)
        {
            Console.WriteLine("I am in InitialSetup " + context.TestName);
            driver = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Constants.URL);
        }

        [TestInitialize]
        public void TestSetUp()
        {
            computersPageObject = new ComputersPageObject(driver);
            computerOperationPage = new ComputerOperationPage(driver);
            name = "computedotnet" + DateTime.Today.ToLongTimeString();
            Console.WriteLine("I am in TestSetUp");
        }

        [TestMethod, Ignore]
        public void TestMethod1()
        {
            computersPageObject.FillSearchInput("ACE");
            computersPageObject.ClickOnSearchButton();
            computersPageObject.ClickOnComputerByName("ACE");
        }

        [TestMethod]
        public void TestAddNewComputer()
        {
            computersPageObject.ClickOnAddComputerButton();
            computerOperationPage.FillCompanyName(name);
            computerOperationPage.FillIntroduced("2019-03-21");
            computerOperationPage.FillDiscontinued("2020-03-21");
            computerOperationPage.SelectCompany("IBM");
            computerOperationPage.ClickOnCreateComputerButton();           
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            computersPageObject.SearchComputer(name);
            computersPageObject.ClickOnComputerByName(name);
            computerOperationPage.ClickOnDeleteThisCOmputerButton();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("I am in ClassCleanup");
            Console.WriteLine("I am in ClassCleanup2");
            System.Threading.Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
