using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateNewBlogPost
{
    class ReplaceHtml
    {
        public static string ReplaceText(PostDetails postDetails)
        {
            var htmlFile = "HtmlTemplateFile.txt";
            var content = File.ReadAllText(htmlFile);
            content = content.Replace(ToBeReplaceText.PostImage, postDetails.PostImage).Replace(ToBeReplaceText.Description, postDetails.Description).Replace(ToBeReplaceText.Language, postDetails.Language).
                Replace(ToBeReplaceText.ImdbRating, postDetails.ImdbRating).Replace(ToBeReplaceText.RottenTomatoesRating, postDetails.RottenTomatoesRating).Replace(ToBeReplaceText.OttguideRating, postDetails.OttguideRating)
                .Replace(ToBeReplaceText.Genre, postDetails.Genre)
                .Replace(ToBeReplaceText.Stars, postDetails.Stars);
            if (postDetails.AvailableOn.Contains("Prime Video"))
            {
                content.Replace(ToBeReplaceText.AvailableOn, ToBeReplaceText.AmazonTag);
            }
            else
            {
                content.Replace(ToBeReplaceText.AvailableOn, ToBeReplaceText.NetfilxTag);
            }

            return content;
        }
    }
}
