#pragma checksum "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a004e38f7aacd96e944cbcdd716c463570bc2b2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\_ViewImports.cshtml"
using Kursach2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\_ViewImports.cshtml"
using Kursach2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a004e38f7aacd96e944cbcdd716c463570bc2b2d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0369563cea7c9645504f2ce1b02bf87b0cfe0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Domain.ViewModels.ProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row mt-2 ms-2\">\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
     foreach (var product in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card mb-2 me-1\" style=\"width: 23rem;\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 221, "\"", 227, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <div class=\"card-body\">\r\n                <h4 class=\"card-title\">");
#nullable restore
#line 9 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                                  Write(product.ProductModel.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <label>Price: ");
#nullable restore
#line 10 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                         Write(product.ProductModel.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                <div>\r\n                    <h5>Characteristics:</h5>\r\n                    <div>\r\n");
#nullable restore
#line 14 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                         foreach (var charactristic in product.CharactristicModels)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 16 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                          Write(charactristic.CharacteristicName);

#line default
#line hidden
#nullable disable
            WriteLiteral(": &nbsp; ");
#nullable restore
#line 16 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                                                                    Write(charactristic.CharacteristicValue);

#line default
#line hidden
#nullable disable
            WriteLiteral(";</p>\r\n");
#nullable restore
#line 17 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\User\source\repos\Kursach2\Kursach2\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Domain.ViewModels.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
