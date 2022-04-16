namespace Selenium
{
    public static class Constants
    {
        public static string tweetsXpath = "//*[contains(@aria-label,'Timeline:') and contains(@aria-label,'Tweets')]//article";
        public static string retweetXpath = ".//*[text()=' Retweeted']";
        public static string retweetTestXpath = ".//a[contains(@href,'/status/')]";
        public static string tweetSourceXpath = "//a[contains(@href,'#source-labels')]/span";
    }
}
