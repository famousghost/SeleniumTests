using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinCzekajSeleniumTests
{
    public enum ElementType
    {
        Id = 0,
        Name = 1
    }

    class BasicSeleniumInteractMethods
    {
        public static void EnterText(string element, string value, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                WebDriverProperties.driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementType == ElementType.Name)
                WebDriverProperties.driver.FindElement(By.Name(element)).SendKeys(value);
        }

        public static void Click(string element, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                WebDriverProperties.driver.FindElement(By.Id(element)).Click();
            if (elementType == ElementType.Name)
                WebDriverProperties.driver.FindElement(By.Name(element)).Click();
        }

        public static void SelectDropDownListElement(string element, string value, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                new SelectElement(WebDriverProperties.driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementType == ElementType.Name)
                new SelectElement(WebDriverProperties.driver.FindElement(By.Name(element))).SelectByText(value);
        }

    }
}
