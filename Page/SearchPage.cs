using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;

namespace n11_TestProject.Page
{
    [TestClass]
    public class SearchPage:BaseTest
    {
        [TestMethod]
        public void TestCase3()
        {
            // Ekranin ustundeki Search alanina 'samsung' yazip Ara butonuna tiklayacak                    
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(searchData)).SendKeys("samsung");
            driver.FindElement(By.ClassName(searchBtn)).Click();
            TearDown();
        }

        [TestMethod]
        public void TestCase4()
        {
            // Gelen sayfada samsung icin sonuc bulundugunu onaylayacak
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(searchData)).SendKeys("samsung");
            driver.FindElement(By.ClassName(searchBtn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement result = driver.FindElement(By.ClassName(resultText));
            Assert.IsTrue(result.Text.Contains("Samsung"));
            Assert.IsTrue(result.Text.Contains("sonuç bulundu."));
            TearDown();
        }

        [TestMethod]
        public void TestCase5()
        {
            // Arama sonuclarindan 2.sayfaya tiklayacak ve acilan sayfada 2.sayfanin su an gosterimde oldugunu onaylayacak
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.FindElement(By.Id(searchData)).SendKeys("samsung");
            driver.FindElement(By.ClassName(searchBtn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var element = driver.FindElement(By.XPath(secondPage));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement currentpage = driver.FindElement(By.Id(currentPage));
            string sayfa = currentpage.GetAttribute("value").ToString();
            Assert.IsTrue(sayfa.Equals("2"));
            TearDown();
        }
    }
}
