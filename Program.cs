using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;

class App
{
    static void Main()
    {

        IWebDriver driver = new ChromeDriver();

        string CsvFilePath = @"input.csv";

        var lines = File.ReadAllLines(CsvFilePath);

        var twitterProfiles = new List<TwitterProfile>();

        for (var i = 1; i < lines.Length; i++)
        {
            var profileLink = lines[i];

            var browserActions = new BrowserActions(driver);

            var tweets = browserActions.GetTweets(profileLink);

            var nonRetweetedUrls = browserActions.GetNonRetweetedUrlFormTwitterProfile(tweets).Take(3).ToList();

            var tweetSources = browserActions.GetTweetSource(nonRetweetedUrls);

            var twitterProfile = new TwitterProfile
            {
                ProfileUrl = profileLink,
                NonRetweetedUrls = nonRetweetedUrls,
                TweetSources = tweetSources
            };

            twitterProfiles.Add(twitterProfile.Evaluate());
        }

        driver.Quit();

        CsvCustomHelper.WriteCsv(twitterProfiles);
    }
}


