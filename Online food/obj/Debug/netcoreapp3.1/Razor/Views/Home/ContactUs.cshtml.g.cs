#pragma checksum "A:\Food Shop\Online food\Online food\Views\Home\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c70626b2d5b772f41b35e4be45bb7e04b62c011"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ContactUs), @"mvc.1.0.view", @"/Views/Home/ContactUs.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "A:\Food Shop\Online food\Online food\Views\_ViewImports.cshtml"
using Online_food;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\Food Shop\Online food\Online food\Views\_ViewImports.cshtml"
using Online_food.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c70626b2d5b772f41b35e4be45bb7e04b62c011", @"/Views/Home/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4c078f0508331bd74aaae922a97278d90dc722", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "A:\Food Shop\Online food\Online food\Views\Home\ContactUs.cshtml"
  
    ViewData["Title"] = "درباره ما";
    Layout = "_Pages";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- about section -->

<section class=""about_section layout_padding"">
    <div class=""container  "">

        <div class=""row"">
            <div class=""col-md-6 "">
                <div class=""img-box"">
                    <img src=""images/about-img.png""");
            BeginWriteAttribute("alt", " alt=\"", 334, "\"", 340, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
            </div>
            <div class=""col-md-6"">
                <div class=""detail-box"">
                    <div class=""heading_container"">
                        <h2>
                            درباره ما
                        </h2>
                    </div>
                    <p>
                       ما خوبیم.
                    </p>
                </div>
            </div>
        </div>
    </div>
</section>

<!-- end about section -->

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
