#pragma checksum "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4dd454ac094490de1b996f428493b82aac5b788"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SiteGroups_Details), @"mvc.1.0.view", @"/Views/SiteGroups/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SiteGroups/Details.cshtml", typeof(AspNetCore.Views_SiteGroups_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4dd454ac094490de1b996f428493b82aac5b788", @"/Views/SiteGroups/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be55a8999898cfd29e404398af1ad5a921db109f", @"/Views/_ViewImports.cshtml")]
    public class Views_SiteGroups_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inventory_Core.Models.SiteGroup>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(85, 196, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>SiteGroup</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            그룹명\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(282, 40, false);
#line 17 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Memco_nm));

#line default
#line hidden
            EndContext();
            BeginContext(322, 127, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            정렬번호\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(450, 39, false);
#line 23 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Sort_no));

#line default
#line hidden
            EndContext();
            BeginContext(489, 127, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            사용여부\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(617, 38, false);
#line 29 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Use_yn));

#line default
#line hidden
            EndContext();
            BeginContext(655, 126, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            메모1\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(782, 37, false);
#line 35 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Memo1));

#line default
#line hidden
            EndContext();
            BeginContext(819, 126, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            메모2\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(946, 37, false);
#line 41 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Memo2));

#line default
#line hidden
            EndContext();
            BeginContext(983, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1046, 44, false);
#line 44 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Input_dt));

#line default
#line hidden
            EndContext();
            BeginContext(1090, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1154, 40, false);
#line 47 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Input_dt));

#line default
#line hidden
            EndContext();
            BeginContext(1194, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1257, 45, false);
#line 50 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Update_dt));

#line default
#line hidden
            EndContext();
            BeginContext(1302, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1366, 41, false);
#line 53 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Update_dt));

#line default
#line hidden
            EndContext();
            BeginContext(1407, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1470, 44, false);
#line 56 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Input_id));

#line default
#line hidden
            EndContext();
            BeginContext(1514, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1578, 40, false);
#line 59 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Input_id));

#line default
#line hidden
            EndContext();
            BeginContext(1618, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1681, 45, false);
#line 62 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Update_id));

#line default
#line hidden
            EndContext();
            BeginContext(1726, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1790, 41, false);
#line 65 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
       Write(Html.DisplayFor(model => model.Update_id));

#line default
#line hidden
            EndContext();
            BeginContext(1831, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1878, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4dd454ac094490de1b996f428493b82aac5b7889908", async() => {
                BeginContext(1930, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 70 "D:\3.DevOps\Inventory\Inventory_Core\Views\SiteGroups\Details.cshtml"
                           WriteLiteral(Model.Memco_cd);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1938, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1946, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4dd454ac094490de1b996f428493b82aac5b78812224", async() => {
                BeginContext(1968, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1984, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inventory_Core.Models.SiteGroup> Html { get; private set; }
    }
}
#pragma warning restore 1591
