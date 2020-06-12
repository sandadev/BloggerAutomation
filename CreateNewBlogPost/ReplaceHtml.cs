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

            if (postDetails.AvailableOn.Contains("Prime Video"))
            {
                content = content.Replace(ToBeReplaceText.PostImage, postDetails.PostImage).Replace(ToBeReplaceText.Description, postDetails.Description).Replace(ToBeReplaceText.Year, postDetails.Year).Replace(ToBeReplaceText.Age, postDetails.Age).Replace(ToBeReplaceText.Language, postDetails.Language).
                Replace(ToBeReplaceText.ImdbRating, postDetails.ImdbRating).Replace(ToBeReplaceText.RottenTomatoesRating, postDetails.RottenTomatoesRating).Replace(ToBeReplaceText.OttguideRating, postDetails.OttguideRating)
                .Replace(ToBeReplaceText.Genre, postDetails.Genre).Replace(ToBeReplaceText.YTId, postDetails.YTId)
                .Replace(ToBeReplaceText.Stars, postDetails.Stars).Replace(ToBeReplaceText.AvailableOn, ToBeReplaceText.AmazonTag);
            }
            else if(postDetails.AvailableOn.Contains("Netflix"))
            {
                content = content.Replace(ToBeReplaceText.PostImage, postDetails.PostImage).Replace(ToBeReplaceText.Description, postDetails.Description).Replace(ToBeReplaceText.Year, postDetails.Year).Replace(ToBeReplaceText.Age, postDetails.Age).Replace(ToBeReplaceText.Language, postDetails.Language).
                 Replace(ToBeReplaceText.ImdbRating, postDetails.ImdbRating).Replace(ToBeReplaceText.RottenTomatoesRating, postDetails.RottenTomatoesRating).Replace(ToBeReplaceText.OttguideRating, postDetails.OttguideRating)
                 .Replace(ToBeReplaceText.Genre, postDetails.Genre).Replace(ToBeReplaceText.YTId, postDetails.YTId)
                 .Replace(ToBeReplaceText.Stars, postDetails.Stars).Replace(ToBeReplaceText.AvailableOn, ToBeReplaceText.NetfilxTag);
            }
            else if (postDetails.AvailableOn.Contains("Netflix"))
            {
                content = content.Replace(ToBeReplaceText.PostImage, postDetails.PostImage).Replace(ToBeReplaceText.Description, postDetails.Description).Replace(ToBeReplaceText.Year, postDetails.Year).Replace(ToBeReplaceText.Age, postDetails.Age).Replace(ToBeReplaceText.Language, postDetails.Language).
                 Replace(ToBeReplaceText.ImdbRating, postDetails.ImdbRating).Replace(ToBeReplaceText.RottenTomatoesRating, postDetails.RottenTomatoesRating).Replace(ToBeReplaceText.OttguideRating, postDetails.OttguideRating)
                 .Replace(ToBeReplaceText.Genre, postDetails.Genre).Replace(ToBeReplaceText.YTId, postDetails.YTId)
                 .Replace(ToBeReplaceText.Stars, postDetails.Stars).Replace(ToBeReplaceText.AvailableOn, ToBeReplaceText.NetfilxTag);
            }

            return content;
        }
    }
}
