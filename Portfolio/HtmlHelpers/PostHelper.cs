using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.HtmlHelpers;

public static class PostHelper
{
    public static IHtmlContent DrawPost(this IHtmlHelper htmlHelper, Portfolio.Entity.Post post)
    {
        var div = new TagBuilder("div")
        {
            Attributes =
            {
                {"id", "grey"}
            }
        };

        var div2 = new TagBuilder("div")
        {
            Attributes =
            {
                {"class", "container"}
            }
        };

        var div3 = new TagBuilder("div")
        {
            Attributes =
            {
                {"class", "row"}
            }
        };
        var div4 = new TagBuilder("div")
        {
            Attributes =
            {
                {"class", "col-lg-8 col-lg-offset-2"}
            }
        };

        var p1 = new TagBuilder("p");
        var p2 = new TagBuilder("p");

        var profile = new TagBuilder("img")
        {
            Attributes =
            {
                {"src", "/img/user.png"},
                {"width", "50px"},
                {"height", "50px"}
            }
        };

        var ba = new TagBuilder("ba").InnerHtml.Append("Stanley Stinson");

        div.InnerHtml.AppendHtml(div2);
        div2.InnerHtml.AppendHtml(div3);
        div3.InnerHtml.AppendHtml(div4);

        div4.InnerHtml.AppendHtml(p1);
        p1.InnerHtml.AppendHtml(profile);
        p1.InnerHtml.AppendHtml(ba);

        var content =
            $"<div id=\"grey\"><div class=\"container\"><div class=\"row\"><div class=\"col-lg-8 col-lg-offset-2\"><p>" +
            $"<img src=\"/img/user.png\" width=\"50px\" height=\"50px\"><ba>Stanley Stinson</ba></p>" +
            $"<p><bd>January 18, 2014</bd></p><h4>{post.Title}</h4>" +
            $"<p>{post.Content}</p><p>@* <a href=\"blog01.html\">Continue Reading...</a> *@</p></div></div><!-- /row -->" +
            $"</div><!-- /container --></div>";
        
        //Todo: сделать
        return new HtmlString(content);
    }
}