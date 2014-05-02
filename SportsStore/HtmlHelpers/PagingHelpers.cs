using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper htmlHelper, PagingInfo info, Func<int, string> pageUrl)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < info.TotalPages; i++)
            {
                var tag = new TagBuilder("a");

                tag.MergeAttribute("href", pageUrl(i + 1));
                tag.InnerHtml = (i + 1).ToString(CultureInfo.InvariantCulture);

                if ((i + 1) == info.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                builder.Append(tag);
            }

            return MvcHtmlString.Create(builder.ToString());


        }
    }
}