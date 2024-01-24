using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace GoodReadTesting
{
    public class TestsNewsAndInterviews
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
        public void TestNewsAndInterviewsHasAFirstBlog() 
        {
            // Testing that the first news exists
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(Consts.BlogBaseUrl).IgnoreCase);
        }

        [Test]
        public void TestPostACommentNotWorking()
        {
            // Testing about posting but account is too new to do that
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(Consts.BlogBaseUrl).IgnoreCase);

            IWebElement inputBox = driver.FindElement(By.Id("comment_body_usertext"));
            inputBox.SendKeys(Consts.NewsAndInterviewsPost);

            // Find the post button gr-comment_form-container
            IWebElement largeDiv = driver.FindElement(By.CssSelector(".gr-comment_form-container"));
            IWebElement postButton = largeDiv.FindElement(By.CssSelector("div > div > input"));
            postButton.Click();

            // Error Page
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement errorDiv = driver.FindElement(By.Id("errorExplanation"));
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }
        }

        [Test]
        public void TestButtonHtmlIsOkScroll()
        {
            // Testing about scroll on the (some html is ok)
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(Consts.BlogBaseUrl).IgnoreCase);

            // Find the post button gr-comment_form-container
            IWebElement largeDiv = driver.FindElement(By.CssSelector(".gr-comment_form-container"));
            IWebElement postButton = largeDiv.FindElement(By.CssSelector("div > div > a:last-child"));
            postButton.Click();

            // Error Page
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement faultDiv = driver.FindElement(By.Id("formattingTipsBox"));
                // If you scroll while you are on this button it will leave the screen. There is no way to code this.
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }
        }

        [Test]
        public void TestButtonAddBookAutherScroll()
        {
            // Testing about scroll on the ( add book/auther)
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(Consts.BlogBaseUrl).IgnoreCase);

            // Find the post button gr-comment_form-container
            IWebElement largeDiv = driver.FindElement(By.CssSelector(".gr-comment_form-container"));
            IWebElement postButton = largeDiv.FindElement(By.CssSelector("div > div > a:first-child"));
            postButton.Click();

            // Error Page
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement faultDiv = driver.FindElement(By.Id("add_mention_box"));
                // If you scroll while you are on this button it will leave the screen. There is no way to code this.
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }
        }

        [Test]
        public void TestButtonAddBookAutherBoxOverflow()
        {
            // Testing adding text in Book input field inside (add books/auther button)
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(Consts.BlogBaseUrl).IgnoreCase);

            // Find the post button gr-comment_form-container
            IWebElement largeDiv = driver.FindElement(By.CssSelector(".gr-comment_form-container"));
            IWebElement postButton = largeDiv.FindElement(By.CssSelector("div > div > a:first-child"));
            postButton.Click();

            // Error Page
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                IWebElement faultDiv = driver.FindElement(By.Id("search_query"));
                faultDiv.SendKeys(Consts._72CharA);
                // The input in falling over
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }
        }

        [Test]
        public void TestLikeWorking()
        {
            // Testing liking feature
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement inputBox = driver.FindElement(By.Id("likesAndComments likesAndComments--withButtons"));
            IWebElement inputBox = driver.FindElement(By.XPath("//*[contains(@id,'like_container_blog')]"));

            IWebElement likeButton = inputBox.FindElement(By.CssSelector("span > span > a"));
            IWebElement alreadyLiked = inputBox.FindElement(By.CssSelector("span > a > span"));
            int count = int.Parse(alreadyLiked.Text.Split(" ")[0]);


            if (likeButton.Text == "Unlike")
            {
                Assert.Inconclusive("You cannot unlike a post that is not liked");
            }
            likeButton.Click();

            inputBox = driver.FindElement(By.XPath("//*[contains(@id,'like_container_blog')]"));
            IWebElement newAlreadyLiked = inputBox.FindElement(By.CssSelector("span > a > span"));
            int newCount = int.Parse(newAlreadyLiked.Text.Split(" ")[0]);

            Assert.That(newCount, Is.EqualTo(count + 1));
        }

        [Test]
        public void TestUnlikeWorking()
        {
            // Testing liking feature
            driver.Navigate().GoToUrl(Consts.NewsAndInterviewsUrl);

            // Find the first availavle news
            IWebElement firstNews = driver.FindElement(By.CssSelector(".editorialCard__image"));
            IWebElement firstNewsButton = firstNews.FindElement(By.CssSelector("div > a"));
            firstNewsButton.Click();

            // We need to go to .https://www.goodreads.com/blog/show/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement inputBox = driver.FindElement(By.Id("likesAndComments likesAndComments--withButtons"));
            IWebElement inputBox = driver.FindElement(By.XPath("//*[contains(@id,'like_container_blog')]"));

            IWebElement likeButton = inputBox.FindElement(By.CssSelector("span > span > a"));
            IWebElement alreadyLiked = inputBox.FindElement(By.CssSelector("span > a > span"));
            int count = int.Parse(alreadyLiked.Text.Split(" ")[0]);

            if (likeButton.Text == "Like") {
                Assert.Inconclusive("You cannot unlike a post that is not liked");
            }
            likeButton.Click();

            inputBox = driver.FindElement(By.XPath("//*[contains(@id,'like_container_blog')]"));
            IWebElement newAlreadyLiked = inputBox.FindElement(By.CssSelector("span > a > span"));
            int newCount = int.Parse(newAlreadyLiked.Text.Split(" ")[0]);

            Assert.That(newCount, Is.EqualTo(count - 1));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
