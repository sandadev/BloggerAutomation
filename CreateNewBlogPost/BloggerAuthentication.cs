using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;

namespace CreateNewBlogPost
{
    class BloggerAuthentication
    {
       public static async Task<UserCredential> CreateBlogPost()
        {
            UserCredential credential;
            //pass credentials to blogger
            try
            {
                using (var stream = new FileStream(path: "client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes: new[] { "https://www.googleapis.com/auth/blogger" },
                        user: "user", CancellationToken.None, new FileDataStore(folder: "BloggerAutomation"));
                    return credential;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
