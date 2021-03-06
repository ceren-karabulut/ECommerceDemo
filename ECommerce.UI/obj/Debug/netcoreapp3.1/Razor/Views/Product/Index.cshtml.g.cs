#pragma checksum "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24f4c4a386dba02e2ce01cfeb34e42a94e207ffc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\_ViewImports.cshtml"
using ECommerce.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\_ViewImports.cshtml"
using ECommerce.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24f4c4a386dba02e2ce01cfeb34e42a94e207ffc", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d153a22c3d84e9b5a7a98a669200007cf871ba9", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECommerce.UI.Models.ViewModels.ProductIndexModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
#nullable restore
#line 7 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
 if (TempData["DeleteStatus"]?.ToString() == "Success")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">");
#nullable restore
#line 9 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                                Write(TempData["Message"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 10 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"

}
else if (TempData["DeleteStatus"]?.ToString() == "Not Found")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">");
#nullable restore
#line 14 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                               Write(TempData["Message"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 15 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
}

else if (TempData["DeleteStatus"]?.ToString() == "Failed")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">");
#nullable restore
#line 19 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                               Write(TempData["Message"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 20 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n");
#nullable restore
#line 25 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
             foreach (var item in Model.Categories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    ");
#nullable restore
#line 28 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
               Write(Html.ActionLink(item.Name, "Product", "GetByCategory", null, new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                </div>\r\n");
#nullable restore
#line 31 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <br />
            <div class=""row"">
                <a href=""/Product/Create"" class=""btn btn-success"">Add Product</a>
            </div>
        </div>
        <div class=""col-md-9"">


            <div class=""row"">
                <div class=""col-md-3""><strong>Id</strong></div>
                <div class=""col-md-3""> <strong>Name Of Product</strong></div>
                <div class=""col-md-3""><strong>Brand</strong></div>
                <div class=""col-md-3""><strong>Price</strong></div>
            </div>


");
#nullable restore
#line 49 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
             foreach (var item in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-md-3\">");
#nullable restore
#line 52 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                                     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-3\">");
#nullable restore
#line 53 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-3\">");
#nullable restore
#line 54 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                                     Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-1\">");
#nullable restore
#line 55 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                                     Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n                    <div class=\"col-md-2\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", "Product", new { productId = item.Id }, new { @class = "btn btn-danger btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        ");
#nullable restore
#line 60 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
                   Write(Html.ActionLink("Update", "Update", "Product", new { productId = item.Id }, new { @class = "btn btn-warning btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 65 "C:\Users\hotta\source\repos\ECommerceDemo\ECommerce.UI\Views\Product\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("           \r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECommerce.UI.Models.ViewModels.ProductIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
