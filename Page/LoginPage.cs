using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace n11_TestProject.Page
{
    [TestClass]
    public class LoginPage:BaseTest
    {

        [TestMethod]
        public void TestCase1()
        {
            // https://www.n11.com <https://www.n11.com/> sitesine gelecek ve anasayfanin acildigini onaylayacak
            try
            {
                startBrowser();
                driver.Navigate().GoToUrl(n11_Url);
                string currentUrl = driver.Url;
                Assert.IsTrue(n11_Url == currentUrl);
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                throw;
            }
        }

        [TestMethod]
        public void TestCase2()
        {
            //Login ekranini acip, bir kullanici ile login olacak(daha once siteye uyeliginiz varsa o olabilir)
            try
            {
                startBrowser();
                driver.Navigate().GoToUrl(n11_Url);
                driver.FindElement(By.ClassName(btnSignIn)).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.Id(email)).SendKeys(myEmail);
                driver.FindElement(By.Id(password)).SendKeys(myPassword);
                driver.FindElement(By.Id(loginButton)).Click();              
                TearDown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Test Failed!");
                throw;
            }
        }

    }
}
