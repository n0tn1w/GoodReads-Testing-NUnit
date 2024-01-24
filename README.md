# Quality-Assurance

## 0 Technology of choice and project set up

NUnit stands as a venerable and widely embraced open-source unit testing framework, serving as an indispensable tool within the .NET development ecosystem. Its inception dates back to the early 2000s, emerging as a response to the need for a robust and flexible testing framework for the .NET platform. Over the years, NUnit has evolved into a sophisticated testing solution, providing developers with a suite of powerful features and conventions that streamline the process of creating and executing tests for .NET applications.

### History
The roots of NUnit trace back to the pioneering work of Charlie Poole, who initiated the project in 2002. Inspired by the popular Java testing framework JUnit, NUnit was conceived with the vision of offering a similar testing experience for .NET developers. Poole's creation quickly gained traction within the .NET community, addressing a critical gap in the testing landscape.

### Core Concepts and Features
At its core, NUnit revolves around the fundamental concepts of test fixtures, test cases, and assertions. A test fixture is a container for a series of test cases, each representing a distinct unit of functionality to be tested. NUnit employs attributes, such as [TestFixture] and [Test], to delineate these fixtures and cases, providing an intuitive and expressive syntax for developers.

One of NUnit's standout features is its support for parameterized tests. This capability allows developers to write a single test method that accepts different inputs, enabling concise and reusable test logic. The [TestCase] attribute empowers developers to provide multiple sets of inputs and expected outputs, promoting efficient and comprehensive test coverage.

Test fixtures in NUnit can leverage setup and teardown methods, marked with [SetUp] and [TearDown] attributes, respectively. These methods facilitate the initialization and cleanup processes required for each test case, fostering a modular and organized testing environment.

### Assertions: The Backbone of NUnit
NUnit provides a diverse set of assertion methods through the Assert class, offering developers a spectrum of options to validate expected outcomes. Whether checking for equality, inequality, or handling exceptions, NUnit's assertion library caters to a wide range of scenarios, ensuring that developers can articulate their test expectations with precision.

### Extensibility and Integration
NUnit's extensibility is a hallmark of its success. The framework embraces the concept of custom extensions and attributes, enabling developers to tailor their testing experience to specific project requirements. Integration with popular development environments, continuous integration tools, and build systems is seamless, further solidifying NUnit's status as an integral part of the .NET testing ecosyste

## 1 Test sign in

### 1.1 Test type

Functional Test: *Yes*  


### 1.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 1.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 1.4 Test Summary

### Results
Total number of test cases: 7  
Total number of test cases passed: 7  
Total number of test cases failed: 0  
Total number of bugs found: 0


## 1.5 Test Cases

### 1.5.1 Test SignUp with correct credentials

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSignUpWorking | |
|---|---|---|
| **Description**   | Tests SignUp with correct credentials. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click SignUp with email. | Redirected so SignUp page. |
| 3 | Write Username in the Your name input box. | An Username is entered. |
| 4 | Write unique Email in the Email input box. | An Email is entered. |
| 5 | Write secure Password in the Password input box. | An Password is entered. | 
| 6 | Write same Password in the Confirm Password input box. | An Confirmed Password is entered. | 
| 7 | Click create an account. | Account is created and redirected to home page. | 
| **Test verdict** | Passed | |


### 1.5.2 Test SignUp with empty strings

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSignUpEmptyFields | |
|---|---|---|
| **Description**   | Tests SignUp with empty credentials. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click SignUp with email. | Redirected so SignUp page. |
| 3 | Write an empty string in the Your name input box. | An Username is entered. |
| 4 | Write an empty string in the Email input box. | An Email is entered. |
| 5 | Write an empty string in the Password input box. | An Password is entered. | 
| 6 | Write an empty string in the Confirm Password input box. | An Confirmed Password is entered. | 
| 7 | Click create an account. | An error div pops up. | 
| **Test verdict** | Passed | |


### 1.5.3 Test SignUp with empty strings

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSignUpAlreadyUsedEmail | |
|---|---|---|
| **Description**   | Tests SignUp with used email. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click SignUp with email. | Redirected so SignUp page. |
| 3 | Write Username in the Your name input box. | An Username is entered. |
| 4 | Write an already used Email in the Email input box. | An Email is entered. |
| 5 | Write secure Password in the Password input box. | An Password is entered. | 
| 6 | Write same Password in the Confirm Password input box. | An Confirmed Password is entered. | 
| 7 | Click create an account. | Account is created and redirected to home page. | 
| **Test verdict** | Passed | |


### 1.5.4 Test SignUp with different password and confirmation password

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSignUpWorking | |
|---|---|---|
| **Description**   | Tests SignUp with different password and confirmation password. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click SignUp with email. | Redirected so SignUp page. |
| 3 | Write Username in the Your name input box. | An Username is entered. |
| 4 | Write unique Email in the Email input box. | An Email is entered. |
| 5 | Write secure Password in the Password input box. | An Password is entered. | 
| 6 | Write a different Password in the Confirm Password input box. | An Confirmed Password is entered. | 
| 7 | Click create an account. | Account is created and redirected to home page. | 
| **Test verdict** | Passed | |


### 1.5.5 Test LogIn with correct credentials

#### Special Instructions
*NONE*

| **Test Case ID**  | TestLoginWorking | |
|---|---|---|
| **Description**   | Tests LogIn with correct credentials. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click LogIn with email. | Redirected so options of LogIn. |
| 3 | Click Sign in with email. | Redirect to LogIn page. |
| 4 | Write Email in the Email input box. | An Email is entered. |
| 5 | Write Password in the Password input box. | An Password is entered. | 
| 6 | Click create an account. | Redirected to home page. | 
| **Test verdict** | Passed | |


### 1.5.6 Test LogIn with incorect email

#### Special Instructions
*NONE*

| **Test Case ID**  | TestLoginWrongEmail | |
|---|---|---|
| **Description**   | Tests LogIn with incorect email. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click LogIn with email. | Redirected so options of LogIn. |
| 3 | Click Sign in with email. | Redirect to LogIn page. |
| 4 | Write wrong Email in the Email input box. | An Email is entered. |
| 5 | Write Password in the Password input box. | An Password is entered. | 
| 6 | Click create an account. |  An error div pops up. | 
| **Test verdict** | Passed | |


### 1.5.7 Test LogIn with incorect password

#### Special Instructions
*NONE*

| **Test Case ID**  | TestLoginWrongPassword | |
|---|---|---|
| **Description**   | Tests LogIn with incorect password. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | None | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click LogIn with email. | Redirected so options of LogIn. |
| 3 | Click Sign in with email. | Redirect to LogIn page. |
| 4 | Write valid Email in the Email input box. | An Email is entered. |
| 5 | Write uncorect Password in the Password input box. | An Password is entered. | 
| 6 | Click create an account. |  An error div pops up. | 
| **Test verdict** | Passed | |


## 2 Test book show page

### 2.1 Test type

Functional Test: *Yes*  


### 2.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 2.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 2.4 Test Summary

### Results
Total number of test cases: 6  
Total number of test cases passed: 6  
Total number of test cases failed: 0  
Total number of bugs found: 0


## 2.5 Test Cases

### 2.5.1 Test most popular book

#### Special Instructions
*NONE*

| **Test Case ID**  | TestPopularNewReleasesWorking | |
|---|---|---|
| **Description**   | Test if there is a most popular book and it has a show. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Save the most popular book's url. | |
| 4 | Click on the most popular book. | Redirect to this book's page. |
| 5 | Comapre saved url to the currect url. | They should be the same. |
| **Test verdict** | Passed | |


### 2.5.2 Test rating a book 5 stars

#### Special Instructions
*NONE*

| **Test Case ID**  | TestRateBook5StarsWorking | |
|---|---|---|
| **Description**   | Test giving a book a rating of 5 stars. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Click on the most popular book. | Redirect to this book's page. |
| 4 | Click on the fifth star. | Tostr popup with text "5 star rating saved" and book is rated 5 stars. |
| **Test verdict** | Passed | |


### 2.5.3 Test rating a book 1 stars

#### Special Instructions
*NONE*

| **Test Case ID**  | TestRateBook1StarsWorking | |
|---|---|---|
| **Description**   | Test giving a book a rating of 1 stars. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Click on the most popular book. | Redirect to this book's page. |
| 4 | Click on the first star. | Tostr popup with text "1 star rating saved" and book is rated 1 stars. |
| **Test verdict** | Passed | |


### 2.5.4 Test remove rating

#### Special Instructions
*NONE*

| **Test Case ID**  | TestRateBookRemoveRatingWorking | |
|---|---|---|
| **Description**   | Test remove rating from a book. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Click on the most popular book. | Redirect to this book's page. | 
| 4 | Click on the remove rating. | Tostr popup with text "Rating removed" and book's rating will be reset. |
| **Test verdict** | Passed | |


### 2.5.5 Test adding book to wanted list

#### Special Instructions
*NONE*

| **Test Case ID**  | TestWantToReadBookWorking | |
|---|---|---|
| **Description**   | Test adding book to wanted list. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Click on the most popular book. | Redirect to this book's page. | 
| 4 | Click on Wanting a book. | A tostr "Shelved as want to read" pops up |
| 5 | Go to home page. | |
| 6 | Go to Want to Read | Wanted book apears as the first option inside of it. |
| **Test verdict** | Passed | |


### 2.5.6 Test removing book to wanted list

#### Special Instructions
*NONE*

| **Test Case ID**  | TestRemoveBookFromWantedListWorking | |
|---|---|---|
| **Description**   | Test removing book to wanted list. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click New Releases. | Redirected to New Releases page. |
| 3 | Click on the most popular book. | Redirect to this book's page. | 
| 4 | Click on Wanting a book. | A model pops up. |
| 5 | Pick Remove from my shelf | Book removed. |
| 6 | Confirm the removal. | The modal closes. |
| 7 | Go to home page. | | 
| 8 | Go to Want to Read | Removed book doesnt appear in any of the books. |
| **Test verdict** | Passed | |


## 3 Test News and Interviews

### 3.1 Test type

Functional Test: *Yes*  


### 3.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 3.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 3.4 Test Summary

### Results
Total number of test cases: 7  
Total number of test cases passed: 3  
Total number of test cases failed: 4  
Total number of bugs found: 4


## 3.5 Test Cases

### 3.5.1 Test News and Interviews opening blog

#### Special Instructions
*NONE*

| **Test Case ID**  | TestNewsAndInterviewsHasAFirstBlog | |
|---|---|---|
| **Description**   | Tests News and Interview that is has a first blog | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog show load. |
| 4 | Test blog url. | The blog url should be the same as the first News and Interview page. |
| **Test verdict** | Passed | |


### 3.5.2 Test posting a comment under a blog

#### Special Instructions
*NONE*

| **Test Case ID**  | TestPostACommentNotWorking | |
|---|---|---|
| **Description**   | Tests if you can post a comment under a blog. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Type a comment in the comment input field. | A coomment is displayed. |
| 5 | Click on post button. | |
| 6 | No error should come up and the comments is posted. | An error comes up. |
| **Test verdict** | Failed | |


### 3.5.3 Test the view of the html helper button

#### Special Instructions
*NONE*

| **Test Case ID**  | TestButtonHtmlIsOkScroll | |
|---|---|---|
| **Description**   | Tests if the html helper button is displayed correctly. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Click on the (some html is okei) button. | A modal pops up. |
| 5 | Scroll up to look at the bottom of the modal. | The button disapears from the scree. |
| **Test verdict** | Failed | |


### 3.5.3 Test the view of the add book/author button

#### Special Instructions
*NONE*

| **Test Case ID**  | TestButtonAddBookAutherScroll | |
|---|---|---|
| **Description**   | Tests if the add book/author is displayed correctly. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Click on the (add book/author) button. | A modal pops up. |
| 5 | Scroll up to look at the bottom of the modal. | The button disapears from the scree. |
| **Test verdict** | Failed | |


### 3.5.4 Test the add book/author modal text field

#### Special Instructions
*NONE*

| **Test Case ID**  | TestButtonAddBookAutherBoxOverflow | |
|---|---|---|
| **Description**   | Tests if the add book/author modal text field works fine. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Click on the (add book/author) button. | A modal pops up. |
| 5 | Add the letter 'a' 72 times. | The input field flows of the modal. |
| **Test verdict** | Failed | |


### 3.5.5 Test like button of the blog

#### Special Instructions
*NONE*

| **Test Case ID**  | TestLikeWorking | |
|---|---|---|
| **Description**   | Test like button of the blog. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Save the number of likes. | |
| 5 | Check if like button exist. | |
| 6 | Like the post. | The button turns to Unlike. | 
| 7 | Comapre the old number of likes with the new number of likes | They should have a one difference. |
| **Test verdict** | Passed | |


### 3.5.6 Test unlike button of the blog

#### Special Instructions
*NONE*

| **Test Case ID**  | TestLikeWorking | |
|---|---|---|
| **Description**   | Test like button of the blog. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to News and Interviews | The News and Interviews page is loaded. |
| 3 | Click on the first blog | The blog page is loaded. |
| 4 | Save the number of likes. | |
| 5 | Check if unlike button exist. | |
| 6 | Unlike the post. | The button turns to Like. | 
| 7 | Comapre the old number of likes with the new number of likes | They should have a one difference. |
| **Test verdict** | Passed | |



## 4 Test the Search Box

### 4.1 Test type

Functional Test: *Yes*  


### 4.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 4.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 4.4 Test Summary

### Results
Total number of test cases: 5
Total number of test cases passed: 5  
Total number of test cases failed: 0  
Total number of bugs found: 0


## 4.5 Test Cases


### 4.5.1 Test Search box with a string

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSearchWithWordWorking | |
|---|---|---|
| **Description**   | Test Search box with a string promt. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Add promt to the search box. | A promt is added. |
| 3 | Press the search option. | The page is redirected. |
| 4 | View first five promts of the search results. | Check if the they contain the string promt inside. |
| **Test verdict** | Passed | |


### 4.5.2 Test Search box with an empty string

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSearchWithEmptyStringWorking | |
|---|---|---|
| **Description**   | Test Search box with a empty promt. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Add promt to the search box. | A promt is added. |
| 3 | Press the search option. | The page is redirected. |
| 4 | View the search results. | No results show be showm. |
| **Test verdict** | Passed | |


### 4.5.3 Test Search box with an cyrillic promt

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSearchWithCyrillicTextWorking | |
|---|---|---|
| **Description**   | Test Search box with a cyrillic promt. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Add promt to the search box. | A promt is added. |
| 3 | Press the search option. | The page is redirected. |
| 4 | View first five promts of the search results. | Check if the they contain the cyrillic promt inside. |
| **Test verdict** | Passed | |


### 4.5.4 Test Search box by author

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSearchByAutherWorking | |
|---|---|---|
| **Description**   | Test Search box by author. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Add promt to the search box. | A promt is added. |
| 3 | Press the search option. | The page is redirected. |
| 4 | View the search results. | No results show be showm. |
| 5 | Click on the Author checkbox. | The author checkbox is selected. |
| 6 | Search by author. | The page is redirected. | 
| 7 | Get the first search results author. | Same author as the promt author. | 
| **Test verdict** | Passed | |


### 4.5.4 Test Search box by author by empty author

#### Special Instructions
*NONE*

| **Test Case ID**  | TestSearchBySingleWhiteSpaceAutherWorking | |
|---|---|---|
| **Description**   | Test Search box by empty author. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Add promt to the search box. | A promt is added. |
| 3 | Press the search option. | The page is redirected. |
| 4 | View the search results. | No results show be showm. |
| 5 | Click on the Author checkbox. | The author checkbox is selected. |
| 6 | Search by empty author. | The page is redirected. | 
| 7 | Get the results. | No results presant. |
| **Test verdict** | Passed | |



## 5 Test the Navigation

### 5.1 Test type

Functional Test: *Yes*  


### 5.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 5.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 5.4 Test Summary

### Results
Total number of test cases: 1
Total number of test cases passed: 1  
Total number of test cases failed: 0  
Total number of bugs found: 0


## 5.5 Test Cases


### 5.5.1 Test the home page navigation

#### Special Instructions
*NONE*

| **Test Case ID**  | TestNavigationOnTheHomePageWorking | |
|---|---|---|
| **Description**   | Test the home page navigation. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Click on Home button in the nav bar. | Redirected to https://www.goodreads.com/?ref=nav_home. |
| 3 | Click on My Books button in the nav bar. | Redirected to https://www.goodreads.com/review/list/174233575?ref=nav_mybooks. |
| 4 | Click on My Messages button in the nav bar. | Redirected to https://www.goodreads.com/message/inbox?ref=nav_my_messages. |
| 5 | Click on My Friends button in the nav bar. | Redirected to https://www.goodreads.com/friend?ref=nav_my_friends. |
| **Test verdict** | Passed | |



## 6 Test Ask the Author

### 6.1 Test type

Functional Test: *Yes*  


### 6.2 System Under Test

System name: https://www.goodreads.com
Version: 10.01.2024

Short description of the system:
The world's largest site for readers and book recommendations


### 6.3 Test Personnel

Name: _________ Date: 10.01.2024  


## 6.4 Test Summary

### Results
Total number of test cases: 4
Total number of test cases passed: 3  
Total number of test cases failed: 1 
Total number of bugs found: 1


## 6.5 Test Cases

### 6.5.1 Test Ask the Author existing

#### Special Instructions
*NONE*

| **Test Case ID**  | TestIfThereIsAFeaturedAuthorWokring | |
|---|---|---|
| **Description**   | Tests Asks the Author tab if there is a featured author you could ask | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to Ask the Author. | Redirect to Ask the Author. |
| 3 | Select the first author. | Redirect to the author's page. | 
| 4 | Check if the author page works | |
| **Test verdict** | Passed | |


### 6.5.2 Test if you could ask the author a question

#### Special Instructions
*NONE*

| **Test Case ID**  | TestAskAuthorWorking | |
|---|---|---|
| **Description**   | Tests Asks the Author tab after pressing ask you could write to him. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to Ask the Author. | Redirect to Ask the Author. |
| 3 | Press the first author ask page. | Redirect to the author's ask page. | 
| 4 | Write a promt to ask. | The promt is displayed. |
| 5 | Click the post button. | The author should be asked the promt. |
| **Test verdict** | Passed | |


### 6.5.3 Test if you could ask the author a question fromt his page

#### Special Instructions
*NONE*

| **Test Case ID**  | TestAskAuthorWorking | |
|---|---|---|
| **Description**   | Tests Asks the Author tab after pressing the author's profile you could write to him. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to Ask the Author. | Redirect to Ask the Author. |
| 3 | Select the first author page. | Redirect to the author's page. | 
| 4 | Write a promt to ask. | The promt is displayed. |
| 5 | Click the post button. | The author should be asked the promt. |
| **Test verdict** | Passed | |


### 6.5.4 Test author's video playing

#### Special Instructions
*NONE*

| **Test Case ID**  | TestIfAuthorVideoPlays | |
|---|---|---|
| **Description**   | Tests if author's video is playing. | |
| **Applicable for**| Firefox | |
| **Initial Conditions** | The user should be logged in. | |
| **Test Step ID**  | **Test Step Description** | **Expected Result**  |
| 1 | Open the site's home page. | The home page is loaded. |
| 2 | Go to Ask the Author. | Redirect to Ask the Author. |
| 3 | Select the first author page. | Redirect to the author's page. | 
| 4 | Select the first video. | Redirect should happen. |
| 5 | Video is playing. | An error div occurs. |
| **Test verdict** | Failed | |


## Traceability matrix

| Test Case ID | Bug Description  | Note  |
|---|---|---|
| TC_FUNCT_01  | The bug was found in the page login.aspx  |  |
| bug2 |  |  |
| bug3 |  |  |
| bug4 |  |  |
| bug5 |  |  |
