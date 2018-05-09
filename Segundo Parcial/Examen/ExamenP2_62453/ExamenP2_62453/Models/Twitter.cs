using System;
using LinqToTwitter;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenP2_62453.Models
{
    public class Twitter
    {
        #region Variables
        Tweet tweet;
        #endregion
        #region Constructors
        public Twitter()
        {
        }
        #endregion


        public async Task<List<Tweet>> GetTweets(string query){
            try
            {
                List<Tweet> tweets = new List<Tweet>();



                var auth = new SingleUserAuthorizer
                {

                    CredentialStore = new SingleUserInMemoryCredentialStore()
                    {

                        ConsumerKey = "cuIC1tAM7CfI2tSAKNwZmrb8O",
                        ConsumerSecret = "G3JbDyMUrwCpJrHHfwj6nY9pa2NJ3DtIE6nCRor8yEQk4bcyja",
                        AccessToken = "161139379-AFXix34IfTSsFVJihRVsycNkEZICJEYXG7gSKcvf",
                        AccessTokenSecret = "lfmvdCIjKXujBBvHWFvwwTUgZIwY9EQsJRs9aWTF5bwOC"

                    }

                };
                await auth.AuthorizeAsync();
                var twitterCtx = new TwitterContext(auth);

                var srch =
                (from search in twitterCtx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == query &&
                       search.Count == 50
                 select search)
                .SingleOrDefault();

                Console.WriteLine("\nQuery: {0}\n", srch.SearchMetaData.Query);
                srch.Statuses.ForEach(entry =>
                {
                    tweet = new Tweet();
                    tweet.Text = entry.Text;
                    tweet.ReTweets = entry.RetweetCount;
                    tweet.Favorite = (System.nint)entry.FavoriteCount;
                    tweets.Add(tweet);
                });
                return tweets;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
