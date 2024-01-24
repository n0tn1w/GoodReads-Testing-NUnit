using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadTesting
{

    public static class Consts
    {
        public const string BaseUrl = "https://www.goodreads.com/";
        public const string RedirectedSignUrlPrefix = "https://www.goodreads.com/ap/cvf/request";

        public const string Username = "Ivan TestsNewsAndInterviews Ivanov"; 
        public const string SignUpEmailNotUsed = "n0tn1wofficial@gmail.com"; // Should be a gmail
        public const string ValidPassword = "123@akL2oPsvW24@"; // Should be secure
        public const string EmptyField = " ";

        public const string NewsAndInterviewsUrl = "https://www.goodreads.com/news?ref=nav_brws_news";
        public const string BlogBaseUrl = "https://www.goodreads.com/blog/show/";
        public const string NewsAndInterviewsPost = "I really like this book! ;)";
        public const string _72CharA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        public const string NewReleasesUrl = "https://www.goodreads.com/new_releases/";
        public const string _5starsRating = "5 star rating saved";
        public const string _1starsRating = "1 star rating saved";
        public const string RemoveRating = "Rating removed";

        public const string SearchByString = "Harry";
        public const string SearchByCyrillic = "план";
        public const string Auther = "J.K.";

        public const string AskTheAutherUrl = "https://www.goodreads.com/ask_the_author?ref=nav_comm_askauthor";
        public const string MessageToTheAuther = "Do you like milk?";

        public const string HomeUrl = "https://www.goodreads.com/?ref=nav_home";
        public const string MyBooksUrl = "https://www.goodreads.com/review/list/174233575?ref=nav_mybooks";
        public const string MyMessagesUrl = "https://www.goodreads.com/message/inbox?ref=nav_my_messages";
        public const string MyFriendsUrl = "https://www.goodreads.com/friend?ref=nav_my_friends";
    }
}
