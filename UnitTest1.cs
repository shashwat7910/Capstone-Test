using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CapstoneTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:4200/");

                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var username = driver.FindElementById("user-field");
                username.SendKeys("User123");
                var pass = driver.FindElementById("pass-field");
                pass.SendKeys("1234");
                var btn = driver.FindElementById("login-btn");
                btn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var adminpanel = driver.FindElementById("admin-btn");
                adminpanel.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var access= driver.PageSource.Contains("403");
                Assert.IsTrue(access);
                driver.Navigate().Refresh();
                var logout = driver.FindElementById("logout-btn");
                logout.Click();
                
                driver.Navigate().Refresh();
                username = driver.FindElementById("user-field");
                username.SendKeys("123@admin");
                pass = driver.FindElementById("pass-field");
                pass.SendKeys("1234");
                btn = driver.FindElementById("login-btn");
                btn.Click();
                driver.Navigate().Refresh();
                adminpanel = driver.FindElementById("admin-btn");
                adminpanel.Click();
                var medicine = driver.PageSource.Contains("403");
                Assert.IsFalse(medicine);
                var home = driver.FindElementById("home-btn");
                home.Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                
            }
        }
    }
}

