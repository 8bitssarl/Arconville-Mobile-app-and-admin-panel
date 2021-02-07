#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e71e000c4c2e8b9a422b2acb0bf93b0d707c9de5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_UserMoreDetails), @"mvc.1.0.razor-page", @"/Pages/UserMoreDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/UserMoreDetails.cshtml", typeof(ZiadBooking.Pages.Pages_UserMoreDetails), null)]
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
#line 1 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\_ViewImports.cshtml"
using ZiadBooking;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e71e000c4c2e8b9a422b2acb0bf93b0d707c9de5", @"/Pages/UserMoreDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_UserMoreDetails : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
  
    Layout = null;

#line default
#line hidden
#line 6 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(130, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(176, 30, false);
#line 10 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(206, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 12 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
    }

#line default
#line hidden
#line 14 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
  
    List<Models.Reservation> reservations = (List<Models.Reservation>)ViewData["Reservations"];
    if (reservations == null)
    {
        reservations = new List<Models.Reservation>();
    }
    List<Models.UserSubscription> subscriptions = (List<Models.UserSubscription>)ViewData["Subscriptions"];
    if (subscriptions == null)
    {
        subscriptions = new List<Models.UserSubscription>();
    }
    List<Models.GenericModel> family = (List<Models.GenericModel>)ViewData["Family"];
    if (family == null)
    {
        family = new List<Models.GenericModel>();
    }
    List<Models.UserPayment> payments = (List<Models.UserPayment>)ViewData["Payments"];
    if (payments == null)
    {
        payments = new List<Models.UserPayment>();
    }

#line default
#line hidden
            BeginContext(1015, 335, true);
            WriteLiteral(@"
<h4>Reservations</h4>

<table class=""table table-bordered table-success table-striped"">
    <thead>
        <tr>
            <th>Service</th>
            <th>User</th>
            <th>From</th>
            <th>Till</th>
            <th>Hours</th>
            <th>Reserved On</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 51 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
          
            foreach (var x in reservations)
            {

#line default
#line hidden
            BeginContext(1422, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1469, 13, false);
#line 55 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(1482, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1514, 10, false);
#line 56 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1524, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1556, 11, false);
#line 57 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(1567, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1599, 9, false);
#line 58 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.EndDate);

#line default
#line hidden
            EndContext();
            BeginContext(1608, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1640, 10, false);
#line 59 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.NumHours);

#line default
#line hidden
            EndContext();
            BeginContext(1650, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1682, 13, false);
#line 60 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.ReserveDate);

#line default
#line hidden
            EndContext();
            BeginContext(1695, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 62 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
            }
        

#line default
#line hidden
            BeginContext(1751, 263, true);
            WriteLiteral(@"    </tbody>
</table>

<h4>Family</h4>

<table class=""table table-bordered table-success table-striped"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Phone</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 78 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
          
            foreach (var x in family)
            {

#line default
#line hidden
            BeginContext(2080, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(2127, 27, false);
#line 82 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.values["name"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2154, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2186, 28, false);
#line 83 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.values["email"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2214, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2246, 35, false);
#line 84 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.values["phone_number"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2281, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 86 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
            }
        

#line default
#line hidden
            BeginContext(2337, 328, true);
            WriteLiteral(@"    </tbody>
</table>

<h4>Subscriptions</h4>

<table class=""table table-bordered table-success table-striped"">
    <thead>
        <tr>
            <th>Service/Package</th>
            <th>Start (YYYY-MM-DD)</th>
            <th>Months</th>
            <th>Expires At</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 103 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
          
            foreach (var x in subscriptions)
            {

#line default
#line hidden
            BeginContext(2738, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(2785, 13, false);
#line 107 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(2798, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2830, 11, false);
#line 108 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(2841, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2873, 11, false);
#line 109 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.NumMonths);

#line default
#line hidden
            EndContext();
            BeginContext(2884, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2916, 11, false);
#line 110 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.ExpiredAt);

#line default
#line hidden
            EndContext();
            BeginContext(2927, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 112 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
            }
        

#line default
#line hidden
            BeginContext(2983, 319, true);
            WriteLiteral(@"    </tbody>
</table>

<h4>Previous Payments</h4>

<table class=""table table-bordered table-success table-striped"">
    <thead>
        <tr>
            <th>Service</th>
            <th>Amount</th>
            <th>Date(YYYY-MM-DD)</th>
            <th>Details</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 129 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
          
            foreach (var x in payments)
            {

#line default
#line hidden
            BeginContext(3370, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(3417, 13, false);
#line 133 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(3430, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3462, 12, false);
#line 134 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.AmountPaid);

#line default
#line hidden
            EndContext();
            BeginContext(3474, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3506, 13, false);
#line 135 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.PaymentDate);

#line default
#line hidden
            EndContext();
            BeginContext(3519, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3551, 16, false);
#line 136 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
                   Write(x.PaymentDetails);

#line default
#line hidden
            EndContext();
            BeginContext(3567, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 138 "D:\PROJECTS\DotNotCore\ZiadBooking\ZiadBooking\Pages\UserMoreDetails.cshtml"
            }
        

#line default
#line hidden
            BeginContext(3623, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.UserMoreDetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UserMoreDetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UserMoreDetailsModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.UserMoreDetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
