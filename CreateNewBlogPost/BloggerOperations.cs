using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            List<string> labels = new List<string>();
            //autenticate credentials
            UserCredential credential=  await BloggerAuthentication.CreateBlogPost();
            //initiate blogger service
            var service = BloggerService(credential);
            //insertpost
            if (postLists != null)
            {
                foreach (var post in postLists)
                {
                    labels = SplitLabels(post.Labels);
                    var content = ReplaceHtml.ReplaceText(post);
                    InsertPost(service,post.Title,post.BlogId,labels,content);
                }
            }
        }

        private static void InsertPost(BloggerService service,string title,string blogId,List<string> labels,string content)
        {
            var insertRequest = service.Posts.Insert(new Post()
            {
                Title = title,
                Content = content,


                Labels = labels,

            }, blogId:blogId);

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
