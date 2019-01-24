using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinCzekajSeleniumTests
{
    class BasicSeleniumGetMethods
    {
        public static string GetText(string element, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                return WebDriverProperties.driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementType == ElementType.Name)
                return WebDriverProperties.driver.FindElement(By.Name(element)).GetAttribute("value");
            return String.Empty;
        }

        public static string GetTextFromSpecialFields(string element, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                return WebDriverProperties.driver.FindElement(By.Id(element)).Text;
            if (elementType == ElementType.Name)
                return WebDriverProperties.driver.FindElement(By.Name(element)).Text;
            return String.Empty;
        }

        public static string GetTextFromSelectFileds(string element, ElementType elementType)
        {
            if (elementType == ElementType.Id)
                return new SelectElement(WebDriverProperties.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            if (elementType == ElementType.Name)
                return new SelectElement(WebDriverProperties.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            return String.Empty;
        }
    }
}
