#pragma checksum "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "024a103bc5780c8f50f348985985368de9afdac5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_Checkout), @"mvc.1.0.view", @"/Views/Catalog/Checkout.cshtml")]
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
#line 1 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\_ViewImports.cshtml"
using BiblioTECH;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\_ViewImports.cshtml"
using BiblioTECH.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
using BiblioTECH.Models.CheckoutModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"024a103bc5780c8f50f348985985368de9afdac5", @"/Views/Catalog/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"103ea2ea11cadad1713edb5e249cd31f73015e0f", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BiblioTECH.Models.CheckoutModel.CheckoutModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
  
    ViewBag.Title = @Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-3.1.1.slim.min.js"" integrity=""sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n"" crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"" integrity=""sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb"" crossorigin=""anonymous""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js"" integrity=""sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn"" crossorigin=""anonymous""></script>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css\" integrity=\"sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ\" crossorigin=\"anonymous\">\r\n");
            }
            );
            WriteLiteral(@"
<div class=""container"">
    <div class=""header clearfix detailHeading"">
        <h2 class=""text-muted"">Checkout Library Item</h2>
    </div>

    <div class=""jumbotron"">
        <div class=""row"">
            <div class=""col-md-3"">
                <div>
                    <p id=""itemTitle"">");
#nullable restore
#line 28 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
                                 Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <img class=\"detailImage\"");
            BeginWriteAttribute("src", " src=\"", 1411, "\"", 1432, 1);
#nullable restore
#line 29 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
WriteAttributeValue("", 1417, Model.ImageUrl, 1417, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"col-md-9\">\r\n");
#nullable restore
#line 35 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
                 using (Html.BeginForm("PlaceCheckout", "Catalog", FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
               Write(Html.HiddenFor(a => a.AssetId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        Please insert a Library Card ID.\r\n                        ");
#nullable restore
#line 40 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
                   Write(Html.TextBoxFor(a => a.LibraryCardId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                    </div>\r\n                    <div>\r\n                        <button type=\"submit\" class=\"btn btn-success btn-lg\">Check out</button>\r\n                    </div>\r\n");
#nullable restore
#line 46 "D:\Anul 4-IS-semestrul 2\Licenta\Aplicatie_fara_sistem_auth\BiblioTECH\Views\Catalog\Checkout.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BiblioTECH.Models.CheckoutModel.CheckoutModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
