#pragma checksum "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\Shifts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab208b5f9d48d7b4f4e535578245a286f37b2bb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shifts_Index), @"mvc.1.0.view", @"/Views/Shifts/Index.cshtml")]
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
#line 1 "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\_ViewImports.cshtml"
using EvedinceFinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\_ViewImports.cshtml"
using EvedinceFinal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab208b5f9d48d7b4f4e535578245a286f37b2bb3", @"/Views/Shifts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ded771c03b1e34a26c7226bf4333b613b2a4cc3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shifts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EvedinceFinal.Models.Shift>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\Shifts\Index.cshtml"
  
    ViewData["Title"] = "Ajax Crud";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>This Page View from Partial view page</h1>\r\n\r\n<div id=\"view-all\">\r\n    ");
#nullable restore
#line 10 "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\Shifts\Index.cshtml"
Write(await Html.PartialAsync("_ViewAll", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""form-modal"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

            </div>
        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 31 "D:\IDB\ASP.NET Core\EvedinceFinal_Mam\Views\Shifts\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EvedinceFinal.Models.Shift>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
