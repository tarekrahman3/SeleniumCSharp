namespace Selenium
{
    public class TwitterProfile
    {
        public TwitterProfile()
        {
            NonRetweetedUrls = new List<string>();
            TweetSources = new List<string>();
        }

        public string ProfileUrl { get; set; }
        public List<string> NonRetweetedUrls { get; set; }
        public List<string> TweetSources { get; set; }

        public TwitterProfile Evaluate()
        {
            if (NonRetweetedUrls.Count < 3)
            {
                var nonRelatedTweetLength = NonRetweetedUrls.Count;

                for (int i = 0; i < 3 - nonRelatedTweetLength; i++)
                {
                    NonRetweetedUrls.Add("");
                    TweetSources.Add("");

                }
            }

            return this;
        }
    }
}
