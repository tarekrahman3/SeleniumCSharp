using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;
using System.Text;

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

        CsvHelper.WriteCsv(twitterProfiles);


    }
}


public static class CsvHelper
{
    public static void WriteCsv(List<TwitterProfile> twitterProfiles)
    {
        var csv = new StringBuilder();
        var header = "Profile URL,Tweet 1 URL,Tweet 1 Source,Tweet 2 URL,Tweet 2 Source,Tweet 3 URL,Tweet 3 Source";
        csv.AppendLine(header);
        foreach (var twitterProfile in twitterProfiles)
        {
            csv.AppendLine($"{twitterProfile.ProfileUrl},{twitterProfile.NonRetweetedUrls[0]},{twitterProfile.TweetSources[0]},{twitterProfile.NonRetweetedUrls[1]},{twitterProfile.TweetSources[1]},{twitterProfile.NonRetweetedUrls[2]},{twitterProfile.TweetSources[2]}");
        }
        File.WriteAllText(@"output.csv", csv.ToString());
    }
}