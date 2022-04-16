using System.Text;
using Selenium;

public static class CsvCustomHelper
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