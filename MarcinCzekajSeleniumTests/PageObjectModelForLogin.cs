using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinCzekajSeleniumTests
{
    class PageObjectModelForLogin
    {
        public PageObjectModelForLogin()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(WebDriverProperties.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement Login { get; set; }
    }
}
