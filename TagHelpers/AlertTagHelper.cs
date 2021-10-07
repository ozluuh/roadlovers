using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Checkpoint01.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {
        public string Message { get; set; }
        public string Class { get; set; }

        public string Type { get; set; } = "primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            output.Attributes.SetAttribute("class", $"alert alert-{Type} alert-dismissible fade show {Class}");
            output.Attributes.SetAttribute("role", "alert");
            output.Content.SetHtmlContent(Message);
            output.Content.AppendHtml("<button type='button' class='btn-close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'></span></button>");
        }
    }
}
