using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FastFood.TagHelpers
{
    public class EmailTagHelper:TagHelper
    {
        public string Address { get; set; } = null!;

        public string Content { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href","mailto:"+Address);
            output.Content.SetContent(Content);
        }
    }
}
