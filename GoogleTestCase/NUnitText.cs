using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace GoogleTestCase
{
    class NUnitText
    {
        public static void Main() { }
        IWebDriver driver;

        [SetUp]
        public void Initialize()
            {
               driver = new FirefoxDriver();
            }
        [Test]
        public void OpenAppTest()
        {
            driver.Url = "http://www.google.com";
            driver.FindElement(By.Name("q")).SendKeys("food");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("LC20lb")));
            Console.WriteLine("Found first search result!"); 
            Console.WriteLine(driver.FindElement(By.ClassName("LC20lb")).Text);

        }
        [TearDown]
        public void EndTest()
        { 
            driver.Close();
        }
    }
}
