using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace GoodReadTesting
{
    public class TestsSign
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void TestSignUpWorking()
        {

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            IWebElement signInDiv = driver.FindElement(By.Id("signInUsingContent"));

            IWebElement link = signInDiv.FindElement(By.CssSelector("div > a:last-child"));
            link.Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Your name ap_customer_name
            IWebElement yourNameInput = driver.FindElement(By.Id("ap_customer_name"));
            yourNameInput.SendKeys(Consts.Username);

            // Email ap_email
            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys(Consts.SignUpEmailNotUsed);

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Consts.ValidPassword);

            // Confirm password ap_password_check
            IWebElement confPasswordInput = driver.FindElement(By.Id("ap_password_check"));
            confPasswordInput.SendKeys(Consts.ValidPassword);

            // Click the continue button continue
            IWebElement button = driver.FindElement(By.Id("continue"));
            button.Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Assert that the URL starts with the expected value after clicking the button
            Assert.That(() => driver.Url, Does.StartWith(Consts.RedirectedSignUrlPrefix).IgnoreCase);
        }

        [Test]
        public void TestSignUpEmptyFields()
        {

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            IWebElement signInDiv = driver.FindElement(By.Id("signInUsingContent"));

            IWebElement link = signInDiv.FindElement(By.CssSelector("div > a:last-child"));
            link.Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Your name ap_customer_name
            IWebElement yourNameInput = driver.FindElement(By.Id("ap_customer_name"));
            yourNameInput.SendKeys(Consts.EmptyField);

            // Email ap_email
            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys(Consts.EmptyField);

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Consts.EmptyField);

            // Confirm password ap_password_check
            IWebElement confPasswordInput = driver.FindElement(By.Id("ap_password_check"));
            confPasswordInput.SendKeys(Consts.EmptyField);

            // Click the continue button continue
            IWebElement button = driver.FindElement(By.Id("continue"));
            button.Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Assert that the URL starts with the expected value after clicking the button
            Assert.That(() => driver.Url, !Does.StartWith(Consts.RedirectedSignUrlPrefix).IgnoreCase);
        }

        [Test]
        public void TestSignUpAlreadyUsedEmail()
        {

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            IWebElement signInDiv = driver.FindElement(By.Id("signInUsingContent"));

            IWebElement link = signInDiv.FindElement(By.CssSelector("div > a:last-child"));
            link.Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Your name ap_customer_name
            IWebElement yourNameInput = driver.FindElement(By.Id("ap_customer_name"));
            yourNameInput.SendKeys(Consts.Username);

            // Email ap_email
            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys(Privates.LoginEmail);

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Consts.ValidPassword);

            // Confirm password ap_password_check
            IWebElement confPasswordInput = driver.FindElement(By.Id("ap_password_check"));
            confPasswordInput.SendKeys(Consts.ValidPassword);

            // Click the continue button continue
            IWebElement button = driver.FindElement(By.Id("continue"));
            button.Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Assert that the URL starts with the expected value after clicking the button
            Assert.That(() => driver.Url, !Does.StartWith(Consts.RedirectedSignUrlPrefix).IgnoreCase);
        }

        [Test]
        public void TestSignUpNotMatchingPasswords()
        {

            driver.Navigate().GoToUrl(Consts.BaseUrl);

            IWebElement signInDiv = driver.FindElement(By.Id("signInUsingContent"));

            IWebElement link = signInDiv.FindElement(By.CssSelector("div > a:last-child"));
            link.Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Your name ap_customer_name
            IWebElement yourNameInput = driver.FindElement(By.Id("ap_customer_name"));
            yourNameInput.SendKeys(Consts.Username);

            // Email ap_email
            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys(Consts.SignUpEmailNotUsed);

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Consts.ValidPassword);

            // Confirm password ap_password_check
            IWebElement confPasswordInput = driver.FindElement(By.Id("ap_password_check"));
            confPasswordInput.SendKeys(Consts.ValidPassword + "1");

            // Click the continue button continue
            IWebElement button = driver.FindElement(By.Id("continue"));
            button.Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Assert that the URL starts with the expected value after clicking the button
            Assert.That(() => driver.Url, !Does.StartWith(Consts.RedirectedSignUrlPrefix).IgnoreCase);
        }

        [Test]
        public void TestLoginWorking() 
        {
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

            // Assert that the URL starts with the expected value after clicking the button
            Assert.That(() => driver.Url, Is.EqualTo(Consts.BaseUrl).IgnoreCase);
        }

        [Test]
        public void TestLoginWrongEmail()
        {
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
            emailInput.SendKeys("a@a");

            // Password ap_password
            IWebElement passwordInput = driver.FindElement(By.Id("ap_password"));
            passwordInput.SendKeys(Privates.LoginPassword);
            //passwordInput.SendKeys("3v1L@4v5C8L");

            // final sign in button signInSubmit
            IWebElement button = driver.FindElement(By.Id("signInSubmit"));
            button.Click();

            // Wait for the redirection to complete
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Remain on the same page auth-error-message-box
            try
            {
                IWebElement errorDiv = driver.FindElement(By.Id("auth-error-message-box"));
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }
        }

        [Test]
        public void TestLoginWrongPassword()
        {
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
            passwordInput.SendKeys("........");
            //passwordInput.SendKeys("3v1L@4v5C8L");

            // final sign in button signInSubmit
            IWebElement button = driver.FindElement(By.Id("signInSubmit"));
            button.Click();

            // Wait for the redirection to complete
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Remain on the same page auth-error-message-box
            try
            {
                IWebElement errorDiv = driver.FindElement(By.Id("auth-error-message-box"));
                Assert.That(true);
            }
            catch (Exception ex) 
            { 
                Assert.That(false);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}