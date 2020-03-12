using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace n11_TestProject.Page
{
    [TestClass]
    public class FavoritePage:BaseTest
    {
        [TestMethod]
        public void TestCase6()
        {
            // Ustten 3.urunun icindeki 'favorilere ekle' butonuna tiklayacak  
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
            var element = driver.FindElement(By.XPath(secondPage));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(thirdProductItem)).Click();
            TearDown();
        }
      
        [TestMethod]
        public void TestCase7()
        {
            // Ekranin en ustundeki 'favorilerim' linkine tiklayacak
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.FindElement(By.ClassName(myAccount)).Click();
            driver.FindElement(By.XPath(menuFavorite)).Click();
            TearDown();
        }
        [TestMethod]
        public void TestCase8()
        {
            // Acilan sayfada bir onceki sayfada izlemeye alinmis urunun bulundugunu onaylayacak
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.FindElement(By.ClassName(myAccount)).Click();
            driver.FindElement(By.XPath(menuFavorite)).Click();
            IWebElement favorite = driver.FindElement(By.ClassName(listItemWrap));
            Assert.IsTrue(favorite.Text.Contains("Favorilerim (1)"));
            TearDown();
        }
        [TestMethod]
        public void TestCase9()
        {
            // Favorilere alinan bu urunun yanindaki 'Kaldir' butonuna basarak, favorilerimden cikaracak          
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.FindElement(By.ClassName(myAccount)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath(menuFavorite)).Click();
            driver.FindElement(By.XPath(myFavorite)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector(deleteFavoriteProduct)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.ClassName(btnHolder)).Click();
            TearDown();
        }
        [TestMethod]
        public void TestCase10()
        {
            // Sayfada bu urunun artik favorilere alinmadigini onaylayacak.
            startBrowser();
            driver.Navigate().GoToUrl(n11_Url);
            driver.FindElement(By.ClassName(btnSignIn)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id(email)).SendKeys(myEmail);
            driver.FindElement(By.Id(password)).SendKeys(myPassword);
            driver.FindElement(By.Id(loginButton)).Click();
            driver.FindElement(By.ClassName(myAccount)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath(menuFavorite)).Click();
            driver.FindElement(By.XPath(myFavorite)).Click();
            IWebElement emptyList = driver.FindElement(By.XPath(emptyWatchList));
            Assert.IsTrue(emptyList.Text.Contains("İzlediğiniz bir ürün bulunmamaktadır."));
            TearDown();
        }
    }
}
