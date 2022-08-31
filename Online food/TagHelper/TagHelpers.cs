using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Online_food.Models;

namespace Online_food.TagHelper
{
    [HtmlTargetElement("div" , Attributes = "page-model")]
    public class TagHelpers: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public TagHelpers(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public pagingInfo PagingInfo { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PagingInfo.TotalItems; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                string Url = PagingInfo.UrlParam.Replace(":", i.ToString());
                tag.Attributes["href"] = Url;
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i== PagingInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
