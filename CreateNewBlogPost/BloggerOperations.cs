using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System.Web;


namespace CreateNewBlogPost
{
   public class BloggerOperations
    {
        private static BloggerService BloggerService(UserCredential credential)
        {

            var service = new BloggerService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Blogger Console App"
            });
            return service;
        }

        public static async Task NewPost(List<PostDetails> postLists)
        {
            try
            {
                List<string> labels = new List<string>();
                //autenticate credentials
                UserCredential credential = await BloggerAuthentication.CreateBlogPost();
                //initiate blogger service
                var service = BloggerService(credential);
                //insertpost

                if (postLists != null)
                {
                    int postCount = 1;
                    foreach (var post in postLists)
                    {

                        labels = SplitLabels(post.Labels);
                        var content = ReplaceHtml.ReplaceText(post);
                        InsertPost(service, post.Title, post.BlogId, labels, content);
                        Console.WriteLine("Created " + postCount + "/" + postLists.Count);
                        postCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        private static void InsertPost(BloggerService service,string title,string blogId,List<string> labels,string content)
        {
            //WebClient wc = new WebClient();
            //byte[] bytes = wc.DownloadData(@"C:\Users\v-santt\Desktop\1.jpg");
            //Post.ImagesData image = new Post.ImagesData();

            //var url = System.Web.HttpUtility.UrlEncode("https://1.bp.blogspot.com/-kqFVZAmU6nE/XseAVmNjpZI/AAAAAAABUyA/wEnCVeLOfJ8hT_KUPPrghoDy3JV5u3swwCK4BGAsYHg/MV5BYjljZGFjNzktZjJlZC00ODkxLWExZGUtYjhmOWMxNGU1YTljXkEyXkFqcGdeQXVyNDc2NzU1MTA%2540._V1_QL50_SY1000_CR0%252C0%252C756%252C1000_AL_.jpg");
            //image.Url = url;
            //List<Post.ImagesData> images = new List<Post.ImagesData>();
            //// images.Add(url);
            ////images.Add((Post.ImagesData)image.Url);
            //images.Add(image);
            var insertRequest = service.Posts.Insert(new Post()
            {
                Title = title,
                Content = content,
                Labels = labels,
            }, blogId: blogId); ;

            insertRequest.Execute();
        }

        internal static List<string> SplitLabels(string labels)
        {
            List<string> lstLabels = new List<string>();
            if (labels != null && labels != "")
            {
                string[] labelsList = labels.Split(',');
                foreach (var item in labelsList)
                {
                    lstLabels.Add(item);
                }
            }
            return lstLabels;
        }
    }
}
