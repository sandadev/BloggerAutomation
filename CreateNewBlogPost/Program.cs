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
    class Program
    {
       
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("New posting in blogger started ....... ");
                Console.WriteLine("Please provide input file");
                var inputFilePath = Console.ReadLine();
                if (inputFilePath.EndsWith("json"))
                {
                    var json = File.ReadAllText(inputFilePath);
                    var postList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PostDetails>>(json);
                    await BloggerOperations.NewPost(postList);
                    Console.WriteLine("Creating new post completed");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Input file not valid try again !!!");
                    Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }

        
    }
}
