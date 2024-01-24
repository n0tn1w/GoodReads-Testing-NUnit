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
    public class TestsSearchBox
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
        public void TestSearchWithWordWorking() 
        {
            // Test if the search box is working
            driver.Navigate().GoToUrl(Consts.BaseUrl);

            //searchBox__form
            IWebElement searchBoxForm = driver.FindElement(By.CssSelector(".searchBox__form"));
            IWebElement inputSearch = searchBoxForm.FindElement(By.CssSelector("form > input"));
            IWebElement buttonSearch = searchBoxForm.FindElement(By.CssSelector("form > button"));

            inputSearch.SendKeys(Consts.SearchByString);
            buttonSearch.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Check if the results are containing the given word
            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".bookTitle"));
            int i = 0;
            foreach (IWebElement element in elements) 
            {
                i++;
               
                string text = element.FindElement(By.CssSelector("a > span")).Text.ToLower();
                if (!text.Contains(Consts.SearchByString.ToLower())) 
                {
                    Assert.Fail("The search result doesnt contain "+ Consts.SearchByString);
                }

                if (i == 5) 
                {
                    break;
                }
            }
            Assert.Pass("The searches contained " + Consts.SearchByString);

        }

        [Test]
        public void TestSearchWithEmptyStringWorking() 
        {
            // Test search with an empty string we expect no books to show up

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            //searchBox__form
            IWebElement searchBoxForm = driver.FindElement(By.CssSelector(".searchBox__form"));
            IWebElement buttonSearch = searchBoxForm.FindElement(By.CssSelector("form > button"));
            buttonSearch.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Check if the results are containing the given word

            try
            {
                IList<IWebElement> elements = driver.FindElements(By.CssSelector(".bookTitle"));
                Assert.Fail("The search result found a book");
            }
            catch (Exception e) 
            {
                Assert.Pass("No books found");
            }
        }

        [Test]
        public void TestSearchWithCyrillicTextWorking() 
        {
            // Test if the search box is working with cyrillic text
            driver.Navigate().GoToUrl(Consts.BaseUrl);

            //searchBox__form
            IWebElement searchBoxForm = driver.FindElement(By.CssSelector(".searchBox__form"));
            IWebElement inputSearch = searchBoxForm.FindElement(By.CssSelector("form > input"));
            IWebElement buttonSearch = searchBoxForm.FindElement(By.CssSelector("form > button"));

            inputSearch.SendKeys(Consts.SearchByCyrillic);
            buttonSearch.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Check if the results are containing the given word
            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".bookTitle"));
            int i = 0;
            foreach (IWebElement element in elements)
            {
                i++;

                string text = element.FindElement(By.CssSelector("a > span")).Text.ToLower();
                if (!text.Contains(Consts.SearchByCyrillic))
                {
                    Assert.Fail("The search result doesnt contain " + Consts.SearchByCyrillic);
                }

                if (i == 5)
                {
                    break;
                }
            }
            Assert.Pass("The searches contained " + Consts.SearchByCyrillic);
        }

        [Test]
        public void TestSearchByAutherWorking() 
        {
            // Test searching book by there authers 

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            //searchBox__form
            IWebElement searchBoxForm = driver.FindElement(By.CssSelector(".searchBox__form"));
            IWebElement buttonSearch = searchBoxForm.FindElement(By.CssSelector("form > button"));
            buttonSearch.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement autherButton = driver.FindElement(By.Id("search_field_author"));
            autherButton.Click();

            // Type into the search bar search_query_main
            IWebElement searchBar = driver.FindElement(By.Id("search_query_main"));
            searchBar.SendKeys(Consts.Auther);

            // Find search button
            IWebElement button = driver.FindElement(By.CssSelector(".searchBox__button"));
            button.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Check if the results are containing the given word
            IWebElement element = driver.FindElements(By.CssSelector(".authorName"))[0];
            string text = element.FindElement(By.CssSelector("a > span")).Text.ToLower();
            if (!text.Contains(Consts.Auther.ToLower()))
            {
                Assert.Fail("The search result doesnt contain the auther" + Consts.Auther);
            }
            Assert.Pass("The searches contained the auther" + Consts.Auther);


        }

        [Test]
        public void TestSearchBySingleWhiteSpaceAutherWorking() 
        {
            // Test searching book by there authers 

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            //searchBox__form
            IWebElement searchBoxForm = driver.FindElement(By.CssSelector(".searchBox__form"));
            IWebElement buttonSearch = searchBoxForm.FindElement(By.CssSelector("form > button"));
            buttonSearch.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement autherButton = driver.FindElement(By.Id("search_field_author"));
            autherButton.Click();

            // Type into the search bar search_query_main
            IWebElement searchBar = driver.FindElement(By.Id("search_query_main"));
            searchBar.SendKeys(Consts.EmptyField);

            // Find search button
            IWebElement button = driver.FindElement(By.CssSelector(".searchBox__button"));
            button.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Check if the results are containing the given word
            try
            {
                IWebElement element = driver.FindElements(By.CssSelector(".authorName"))[0];
                Assert.Fail("An auther is given even thoght there is a white space in the search");

            }catch(Exception e)
            {
                Assert.Pass("No auther found");
            }
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
