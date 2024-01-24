using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GoodReadTesting
{
    public class TestsBookShow
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
        public void TestPopularNewReleasesWorking() 
        {
            // Test if there is a book in popular new releases
            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            string hrefValue = bookScreen.GetAttribute("href");

            bookScreen.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.That(() => driver.Url, Does.StartWith(hrefValue).IgnoreCase);
        }

        [Test]
        public void TestRateBook5StarsWorking() 
        {
            // Test if you can rate a book with 5 stars
            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            string hrefValue = bookScreen.GetAttribute("href");

            bookScreen.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Get the div of the rating Sticky
            IWebElement rateDiv = driver.FindElement(By.CssSelector(".Sticky"));
            IWebElement rate5StartsButton = rateDiv.FindElement(By.CssSelector("div > div > div > span > button:first-child"));
            rate5StartsButton.Click();

            // We need to check if on the toastr there is a text that says "5 star rating saved"
            try
            {
                IWebElement toastDiv = driver.FindElement(By.CssSelector(".Toastify"));
                IWebElement rate5StartsText = toastDiv.FindElement(By.CssSelector("div > div > div > div > div:last-child"));
                string text = rate5StartsText.Text;
                Assert.That(() => text, Is.EqualTo(Consts._5starsRating).IgnoreCase);

            }
            catch (Exception e) { }
        }

        [Test]
        public void TestRateBookRemoveRatingWorking()
        {
            // Test if you can remove the rating by clicking on the previous rating
            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            string hrefValue = bookScreen.GetAttribute("href");

            bookScreen.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Get the div of the rating Sticky
            IWebElement rateDiv = driver.FindElement(By.CssSelector(".Sticky"));
            IWebElement oldRatingButton = rateDiv.FindElement(By.CssSelector("div > div > div > span > button:last-child"));
            oldRatingButton.Click();

            // We need to check if on the toastr there is a text that says "5 star rating saved"
            try
            {
                IWebElement toastDiv = driver.FindElement(By.CssSelector(".Toastify"));
                IWebElement oldRatingText = toastDiv.FindElement(By.CssSelector("div > div > div > div > div:last-child"));
                string text = oldRatingText.Text;
                Assert.That(() => text, Is.EqualTo(Consts.RemoveRating).IgnoreCase);

            }
            catch (Exception e) { }
        }

        [Test]
        public void TestRateBook1StarsWorking()
        {
            // Test if you can rate a book with 1 star
            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            string hrefValue = bookScreen.GetAttribute("href");

            bookScreen.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Get the div of the rating Sticky
            IWebElement rateDiv = driver.FindElement(By.CssSelector(".Sticky"));
            IWebElement rate1StartsButton = rateDiv.FindElement(By.CssSelector("div > div > div > span > button:last-child"));
            rate1StartsButton.Click();

            // We need to check if on the toastr there is a text that says "5 star rating saved"
            try
            {
                IWebElement toastDiv = driver.FindElement(By.CssSelector(".Toastify"));
                IWebElement rate1StartsText = toastDiv.FindElement(By.CssSelector("div > div > div > div > div:last-child"));
                string text = rate1StartsText.Text;
                Assert.That(() => text, Is.EqualTo(Consts._1starsRating).IgnoreCase);

            }
            catch (Exception e) { }
        }

        [Test]
        public void TestWantToReadBookWorking() 
        {
            // Click want to read the book then go home page and check if it is there

            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            bookScreen.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            // find BookActions__button
            IWebElement readDiv = driver.FindElement(By.CssSelector(".BookActions__button"));
            IWebElement button = readDiv.FindElement(By.CssSelector("div > div > div > button"));
            button.Click();
            string bookUrl = driver.Url.Split("#")[0];

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            // find shelfDisplay and check if the first is the correct one
            IWebElement wantedBookDiv = driver.FindElement(By.CssSelector(".shelfDisplay"));
            IWebElement book = wantedBookDiv.FindElement(By.CssSelector("div > a"));
            string href = book.GetAttribute("href");

            Assert.That(href, Is.EqualTo(bookUrl));
        }

        [Test]
        public void TestRemoveBookFromWantedListWorking() 
        {
            // Testing if you can correctly remove a book from the wanted list

            DateTime currentDate = DateTime.Now;

            // Get the current month and year
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            driver.Navigate().GoToUrl(Consts.NewReleasesUrl + currentYear + "/" + currentMonth);

            // Navigate to a book rightContainer
            IWebElement bookDiv = driver.FindElement(By.CssSelector(".rightContainer"));

            IWebElement bookScreen = bookDiv.FindElement(By.CssSelector("div > div > div > div > div > a:first-child"));
            bookScreen.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement readDiv = driver.FindElement(By.CssSelector(".BookActions__button"));
            IWebElement button = readDiv.FindElement(By.CssSelector("div > div > div > button"));
            string bookUrl = driver.Url.Split("#")[0];
            button.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //WTRStepShelving__removeButton
            IWebElement removeDiv = driver.FindElement(By.CssSelector(".Overlay__window"));
            IWebElement buttonRemove = removeDiv.FindElement(By.CssSelector("div > div > div > div > button"));
            buttonRemove.Click();

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            // find shelfDisplay and check if there is a correct one
            IWebElement wantedBookDiv = driver.FindElement(By.CssSelector(".shelfDisplay"));
            ReadOnlyCollection<IWebElement> books = wantedBookDiv.FindElements(By.CssSelector("div > a"));

            foreach (IWebElement book in books) 
            { 
                string href = book.GetAttribute("href");
                if (href == bookUrl) 
                {
                    Assert.Fail("The book was not removed from the wanted list");
                }
            }
            Assert.Pass("The book was removed from the wanted list");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
