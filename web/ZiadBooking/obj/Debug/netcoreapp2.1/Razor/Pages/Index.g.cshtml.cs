#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79501680a70a4bd79ec28281316aaba50d6226cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(ZiadBooking.Pages.Pages_Index), null)]
namespace ZiadBooking.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\_ViewImports.cshtml"
using ZiadBooking;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79501680a70a4bd79ec28281316aaba50d6226cd", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
  
    List<Models.ReportRow> reportData = (List<Models.ReportRow>)ViewData["SubsEnding"];
    if (reportData == null)
    {
        reportData = new List<Models.ReportRow>();
    }

#line default
#line hidden
            BeginContext(264, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 15 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
  
    int endingIn = 12;

#line default
#line hidden
            BeginContext(294, 492, true);
            WriteLiteral(@"    <h2>Subscriptions Ending In 12 Months</h2>
    <div style=""height: 20px;""></div>
    <table class=""table table-bordered table-success table-striped"">
        <thead>
            <tr>
                <th>User</th>
                <th>Service</th>
                <th>Months</th>
                <th>Started On</th>
                <th>Expires On</th>
                <th>Amount Paid</th>
                <th>Ending In</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 32 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
              
                foreach (dynamic x in reportData)
                {

#line default
#line hidden
            BeginContext(872, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(927, 21, false);
#line 36 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("UserName"));

#line default
#line hidden
            EndContext();
            BeginContext(948, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(984, 24, false);
#line 37 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("ServiceName"));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1044, 22, false);
#line 38 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("NumMonths"));

#line default
#line hidden
            EndContext();
            BeginContext(1066, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1102, 22, false);
#line 39 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("StartDate"));

#line default
#line hidden
            EndContext();
            BeginContext(1124, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1160, 22, false);
#line 40 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("ExpiredAt"));

#line default
#line hidden
            EndContext();
            BeginContext(1182, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1218, 23, false);
#line 41 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("AmountPaid"));

#line default
#line hidden
            EndContext();
            BeginContext(1241, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1277, 21, false);
#line 42 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                       Write(x.GetItem("EndingIn"));

#line default
#line hidden
            EndContext();
            BeginContext(1298, 39, true);
            WriteLiteral(" days</td>\r\n                    </tr>\r\n");
            EndContext();
#line 44 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Index.cshtml"
                }
            

#line default
#line hidden
            BeginContext(1371, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
