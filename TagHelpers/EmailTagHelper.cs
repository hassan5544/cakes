﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cakes.TagHelpers
{
    public class EmailTagHelper:TagHelper
    {
        public string address { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto" + address);
            output.Content.SetContent(Content);
        }

    }

    
}
