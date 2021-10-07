using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Checkpoint01.TagHelpers
{
    public class BtnTagHelper : TagHelper
    {
        public string Text { get; set; } = "Enviar";
        public string Class { get; set; }

        public string Type { get; set; } = "submit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";

            output.Attributes.SetAttribute("class", $"btn {Class}");
            output.Attributes.SetAttribute("type", Type);
            output.Attributes.SetAttribute("value", Text);
        }
    }
}
