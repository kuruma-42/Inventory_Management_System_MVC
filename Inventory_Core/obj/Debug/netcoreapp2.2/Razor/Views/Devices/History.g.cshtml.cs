#pragma checksum "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af73fc634bbfbe4085bfefadc189c916d3d7ff87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Devices_History), @"mvc.1.0.view", @"/Views/Devices/History.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Devices/History.cshtml", typeof(AspNetCore.Views_Devices_History))]
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
#line 1 "D:\3.DevOps\Inventory\Inventory_Core\Views\_ViewImports.cshtml"
using Inventory_Core;

#line default
#line hidden
#line 2 "D:\3.DevOps\Inventory\Inventory_Core\Views\_ViewImports.cshtml"
using Inventory_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af73fc634bbfbe4085bfefadc189c916d3d7ff87", @"/Views/Devices/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be55a8999898cfd29e404398af1ad5a921db109f", @"/Views/_ViewImports.cshtml")]
    public class Views_Devices_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inventory_Core.ViewModels.HistoryViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(66, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
  
    ViewData["Title"] = "History";

#line default
#line hidden
            BeginContext(111, 311, true);
            WriteLiteral(@"
<h1>History</h1>
<table class=""table"">
    <thead>
        <tr>
            <th>
                SERIAL ID
            </th>
            <th>
                SUB ID
            </th>
            <th>
                자재 구분
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
");
            EndContext();
#line 25 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
             foreach (var item in ViewBag.devicedata)
            {

#line default
#line hidden
            BeginContext(492, 21, true);
            WriteLiteral("                <td> ");
            EndContext();
            BeginContext(514, 14, false);
#line 27 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
                Write(item.Serial_id);

#line default
#line hidden
            EndContext();
            BeginContext(528, 28, true);
            WriteLiteral("</td>\r\n                <td> ");
            EndContext();
            BeginContext(557, 11, false);
#line 28 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
                Write(item.Sub_id);

#line default
#line hidden
            EndContext();
            BeginContext(568, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(596, 12, false);
#line 29 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
               Write(item.Code_nm);

#line default
#line hidden
            EndContext();
            BeginContext(608, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 30 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
            }

#line default
#line hidden
            BeginContext(630, 308, true);
            WriteLiteral(@"        </tr>
    </tbody>
</table>

<table class=""table"">
    <thead>
        <tr>
            <th>
                기준일시
            </th>
            <th>
                현장명
            </th>
            <th>
                입력자
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 50 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(987, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1048, 41, false);
#line 54 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
               Write(Html.DisplayFor(modelItem => item.Reg_dt));

#line default
#line hidden
            EndContext();
            BeginContext(1089, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1157, 42, false);
#line 57 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
               Write(Html.DisplayFor(modelItem => item.Site_nm));

#line default
#line hidden
            EndContext();
            BeginContext(1199, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1267, 43, false);
#line 60 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
               Write(Html.DisplayFor(modelItem => item.Input_id));

#line default
#line hidden
            EndContext();
            BeginContext(1310, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 63 "D:\3.DevOps\Inventory\Inventory_Core\Views\Devices\History.cshtml"
        }

#line default
#line hidden
            BeginContext(1365, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inventory_Core.ViewModels.HistoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
