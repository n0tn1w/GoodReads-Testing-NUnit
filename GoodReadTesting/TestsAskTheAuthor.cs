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
    public class TestsAskTheAuthor
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

            driver.Navigate().GoToUrl(Consts.AskTheAutherUrl);
        }

        [Test]
        public void TestIfThereIsAFeaturedAuthorWokring()
        {
            // Test if there is even a featured author you can ask 

            try
            {
                IList<IWebElement> elemetns = driver.FindElements(By.CssSelector(".askTheAuthorFeaturedListItemContainer"));
                IWebElement first = elemetns[0];
                IWebElement askButton = first.FindElement(By.CssSelector("div > a"));
                askButton.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                Assert.That(() => driver.Url, Does.StartWith(Consts.BaseUrl + "author/").IgnoreCase);
            }
            catch (Exception ex)
            {
                Assert.Fail("No featured authers");
            }
        }

        [Test]
        public void TestAskAuthorWorking()
        {
            // Test if submiting a question to the author works
            IList<IWebElement> elemetns = driver.FindElements(By.CssSelector(".askTheAuthorFeaturedListItemContainer"));
            IWebElement first = elemetns[0];
            IWebElement askButton = first.FindElement(By.CssSelector(".gr-button"));
            askButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement inputBox = driver.FindElement(By.Id("qaTextArea"));
                inputBox.SendKeys(Consts.MessageToTheAuther);

                IWebElement div = driver.FindElement(By.CssSelector(".readerQAFormActions"));
                IWebElement ask = div.FindElement(By.CssSelector("div > div > button"));

                ask.Click();

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Pass("Author was asked");
        }

        [Test]
        public void TestAskAuthorFromProfileWorking() 
        {
            // Go to the Author profile then ask a question

            IList<IWebElement> elemetns = driver.FindElements(By.CssSelector(".askTheAuthorFeaturedListItemContainer"));
            IWebElement first = elemetns[0];
            IWebElement askButton = first.FindElement(By.CssSelector("div > a"));
            askButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try 
            {
                //qaTextArea
                IWebElement inputBox = driver.FindElement(By.Id("qaTextArea"));
                inputBox.SendKeys(Consts.MessageToTheAuther);

                // find the Ask button readerQAFormActions 
                IWebElement button = driver.FindElement(By.CssSelector(".readerQAFormActions")).FindElement(By.CssSelector("div > div > button"));
                button.Click();

            }
            catch (Exception e) 
            { 
                Assert.Fail(e.Message); 
            }
            Assert.Pass("Author was asked");
        }

        [Test]
        public void TestIfAuthorVideoPlays() 
        {
            // Test if a video is playing

            IList<IWebElement> elemetns = driver.FindElements(By.CssSelector(".askTheAuthorFeaturedListItemContainer"));
            IWebElement first = elemetns[0];
            IWebElement askButton = first.FindElement(By.CssSelector("div > a"));
            askButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement firstVideo = driver.FindElement(By.CssSelector(".videoThumbnail"));
                firstVideo.Click();

                // There should be no YT error messages while the video is playing ytp-error
                try
                {
                    IWebElement errors = driver.FindElement(By.CssSelector(".ytp-error"));
                    Assert.Fail("Error in playing the YT video");
                }
                catch (Exception e) 
                {
                    Assert.Pass("Video played succefully");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("No video is playing");
            }

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
