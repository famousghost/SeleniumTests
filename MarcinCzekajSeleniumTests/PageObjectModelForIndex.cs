using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinCzekajSeleniumTests
{
    class PageObjectModelForIndex
    {

        public PageObjectModelForIndex()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(WebDriverProperties.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        [FindsBy(How = How.Name, Using = "TitleId")]
        public IWebElement TitleId { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstName { get; set;}

        [FindsBy(How = How.Id, Using = "MiddleName")]
        public IWebElement MiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "Male")]
        public IWebElement Male { get; set;}

        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement Female { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement Save { get; set; }

        [FindsBy(How = How.LinkText, Using = "HtmlPopup")]
        public IWebElement httpPopUp { get; set; }

        [FindsBy(How = How.Name, Using = "generate")]
        public IWebElement Generate { get; set; }

        [FindsBy(How = How.Id, Using = "Country")]
        public IWebElement Country { get; set; }

    }
}
