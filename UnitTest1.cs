using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Exam01
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://www.commscope.com/");
            var searchBox = Driver.FindElement(By.XPath("//input[@id='desktop-search-bar']"));
            searchBox.SendKeys("ME-7000");
            var searchButton = Driver.FindElement(By.CssSelector("button[aria-label='Search'] > .icon"));
            searchButton.Click();

            var elements = Driver.FindElements(By.PartialLinkText("ME-7000"));

            foreach (var item in elements)
            {

                Console.WriteLine(item.Text + "\n");

            }
            Assert.Pass();
        }
    }
}