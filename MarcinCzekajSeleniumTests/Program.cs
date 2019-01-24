using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinCzekajSeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        [SetUp]
        public void initalized()
        {
            WebDriverProperties.driver = new ChromeDriver();
            WebDriverProperties.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }

        public void setStartUrl(string anotherURL)
        {
            WebDriverProperties.driver.Navigate().GoToUrl(anotherURL);
        }

        [Test]
        public void basicLoginTest()
        {
            LoginCheck();
        }

        [Test]
        public void loginAndFillUserForm()
        {
            setStartUrl("http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj&Login=Login");
            FillUserForm();
        }

        [Test]
        public void SexCheckBoxVerification()
        {
            setStartUrl("http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj&Login=Login");
            PageObjectModelForIndex pageIndex = new PageObjectModelForIndex();

            pageIndex.Female.Click();
            if(pageIndex.Male.Selected)
            {
                Assert.Fail("Problem with checkboxs cannot unchecked");
            }

            pageIndex.Save.Click();
        }

        [Test]
        public void CheckGenerateButtonPopUpAllertOkVersion()
        {
            string notification = "You pressed OK!";
            setStartUrl("http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj&Login=Login");
            PageObjectModelForIndex pageIndex = new PageObjectModelForIndex();

            pageIndex.Generate.Click();

            WebDriverProperties.driver.SwitchTo().Alert().Accept();

            Console.WriteLine(notification);
            Assert.AreEqual(WebDriverProperties.driver.SwitchTo().Alert().Text, notification);
            WebDriverProperties.driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void CheckGenerateButtonPopUpAllertCancelVersion()
        {
            string notification = "You pressed Cancel!";
            setStartUrl("http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj&Login=Login");
            PageObjectModelForIndex pageIndex = new PageObjectModelForIndex();

            pageIndex.Generate.Click();

            WebDriverProperties.driver.SwitchTo().Alert().Dismiss();

            Console.WriteLine(notification);
            Assert.AreEqual(WebDriverProperties.driver.SwitchTo().Alert().Text, notification);
            WebDriverProperties.driver.SwitchTo().Alert().Accept();
        }


        [Test]
        public void CheckIfPopUpShows()
        {
            setStartUrl("http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj&Login=Login");
            PageObjectModelForIndex pageIndex = new PageObjectModelForIndex();

            PopupWindowFinder finder = new PopupWindowFinder(WebDriverProperties.driver);
            string popupWindowHandle = finder.Click(pageIndex.httpPopUp);
           
            WebDriverProperties.driver.SwitchTo().Window(popupWindowHandle);

            PageObjectModelForIndex pageIndexPopUp = new PageObjectModelForIndex();
            pageIndexPopUp.FirstName.SendKeys("Marcin");
            pageIndexPopUp.MiddleName.SendKeys("Marcin");
            pageIndexPopUp.Male.Click();
            pageIndexPopUp.Country.SendKeys("USA");
            pageIndexPopUp.Save.Click();
        }

        public void LoginCheck()
        {
            Login();

            string correctURL = "http://executeautomation.com/demosite/index.html?UserName=Marcin&Password=Czekaj";

            String URL = WebDriverProperties.driver.Url;
            Assert.AreEqual(URL, correctURL);
        }

        public void Login()
        {
            PageObjectModelForLogin pageLogin = new PageObjectModelForLogin();
            string login = "Marcin";
            string password = "Czekaj";
            pageLogin.UserName.SendKeys(login);
            Console.WriteLine("UserName: " + pageLogin.UserName.GetAttribute("value"));
            pageLogin.Password.SendKeys(password);
            Console.WriteLine("Password: " + pageLogin.Password.GetAttribute("value"));
            if (pageLogin.Password.GetAttribute("value") != password)
            {
                Assert.Fail("To Long password");
            }
            if (pageLogin.Login.GetAttribute("value") == "" || pageLogin.Password.GetAttribute("value") == "")
            {
                Assert.Fail("Login or password is empty");
            }

            pageLogin.Login.Submit();
        }

        public void FillUserForm()
        {
            PageObjectModelForIndex pageIndex = new PageObjectModelForIndex();

            new SelectElement(pageIndex.TitleId).SelectByText("Mr.");
            pageIndex.FirstName.SendKeys("Marcin");
            pageIndex.MiddleName.SendKeys("Czekaj");
            pageIndex.Male.Click();
            pageIndex.Save.Click();
        }

        [TearDown]
        public void stop()
        {
            WebDriverProperties.driver.Close();
        }
    }
}
