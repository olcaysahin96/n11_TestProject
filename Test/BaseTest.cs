using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace n11_TestProject
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string n11_Url = "https://www.n11.com/";
        protected string btnSignIn = "btnSignIn";
        protected string email = "email";
        protected string password = "password";
        protected string loginButton = "loginButton";
        protected string myEmail = "testautomation9696@gmail.com";
        protected string myPassword = "Test2019";
        protected string searchData = "searchData";
        protected string searchBtn = "searchBtn";
        protected string resultText = "resultText";
        protected string secondPage = ".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]";
        protected string currentPage = "currentPage";
        protected string menuFavorite = "//*[@id='myAccount']/div[1]/div[1]/div[2]/ul/li[5]/a";
        protected string myFavorite = "//*[@id='myAccount']/div[3]/ul/li[1]/div/a";
        protected string myAccount = "myAccount";
        protected string thirdProductItem = ".//*[@id='view']/ul/li[3]/div/div[1]/span[@class='textImg followBtn']";
        protected string listItemWrap = "listItemWrap";
        protected string deleteFavoriteProduct = ".wishProBtns span.deleteProFromFavorites";
        protected string btnHolder = "btnHolder";
        protected string emptyWatchList = "//*[@id='watchList']/div";

        [SetUp]
        public void startBrowser()
        {         
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();    
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
