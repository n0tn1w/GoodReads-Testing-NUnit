using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadTesting
{
    public class TestsNavigation
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Login in 
            driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            // Click on the sing in signIn
            IWebElement signInDiv = driver.FindElement(By.Id("signIn"));

            // Navigate through the nested div elements
            IWebElement nestedDiv = signInDiv.FindElement(By.CssSelector("div > div > div"));

            // Find the link (a) element inside the last nested div
            IWebElement link = nestedDiv.FindElement(By.TagName("a"));

            // Click on the link
            link.Click();

            // Verify if the link redirects to the expected URL 
            // string linkHref = link.GetAttribute("href");
            //Assert.That(linkHref, Is.EqualTo("https://www.goodreads.com/user/sign_in"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.StartsWith("https://www.goodreads.com/user/sign_in"));

            // Now, find the div with id "bruh" on the redirected page
            IWebElement choicesDiv = driver.FindElement(By.Id("choices"));

            // Get all posible options to sign in
            IWebElement linkToPickWhichWayToSignIn = choicesDiv.FindElement(By.CssSelector("div > div > a:last-child"));
            linkToPickWhichWayToSignIn.FindElement(By.TagName("button")).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Email ap_email
            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys(Privates.LoginEmail);

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Privates.LoginPassword);

            // final sign in button signInSubmit
            IWebElement button = driver.FindElement(By.Id("signInSubmit"));
            button.Click();

            // Wait for the redirection to complete
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestNavigationOnTheHomePageWorking() 
        {
            // Test the header navigation

            // Home 
            IWebElement navItem = driver.FindElement(By.CssSelector(".siteHeader__menuList")).FindElements(By.CssSelector("ul > li > a"))[0];
            navItem.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string homeUrl = driver.Url;

            // My books
            navItem = driver.FindElement(By.CssSelector(".siteHeader__menuList")).FindElements(By.CssSelector("ul > li > a"))[1];
            navItem.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string myBooksUrl = driver.Url;

            // My groups
            navItem = driver.FindElement(By.CssSelector(".personalNav")).FindElements(By.CssSelector("ul > li > a"))[1];
            navItem.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string myMessagesUrl = driver.Url;

            // My messages
            navItem = driver.FindElement(By.CssSelector(".personalNav")).FindElements(By.CssSelector("ul > li > a"))[2];
            navItem.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string myFriendsUrl = driver.Url;

            if (homeUrl == Consts.HomeUrl && myBooksUrl == Consts.MyBooksUrl && myMessagesUrl == Consts.MyMessagesUrl && myFriendsUrl == Consts.MyFriendsUrl)
            {
                Assert.Pass("All well in the navigation");
            }
            else 
            {
                Assert.Fail("Failed in Navigation");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
