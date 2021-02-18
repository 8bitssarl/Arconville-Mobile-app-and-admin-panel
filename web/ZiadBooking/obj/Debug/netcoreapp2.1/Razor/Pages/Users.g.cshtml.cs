#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f880554e0c21c9530952bd169f041c17a15349a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_Users), @"mvc.1.0.razor-page", @"/Pages/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Users.cshtml", typeof(ZiadBooking.Pages.Pages_Users), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f880554e0c21c9530952bd169f041c17a15349a", @"/Pages/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Users : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
  
    ViewData["Title"] = "Reservations";

#line default
#line hidden
            BeginContext(92, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
  
    List<Models.User> users = (List<Models.User>)ViewData["Users"];

#line default
#line hidden
            BeginContext(170, 841, true);
            WriteLiteral(@"
<ul class=""nav nav-tabs"">
    <li class=""active""><a data-toggle=""tab"" href=""#users"">Users</a></li>
    <li><a data-toggle=""tab"" href=""#packages"">Packages</a></li>
    <li><a data-toggle=""tab"" href=""#requests"">Subscription Requests</a></li>
</ul>

<div class=""tab-content"">
    <div id=""users"" class=""tab-pane fade in active"">
        <h2>Users</h2>

        <div class=""add-new-container"" style=""margin-bottom: 15px;text-align: right"">
            <a href=""User"">+Add New User</a>
        </div>

        <table class=""table table-bordered table-success table-striped"">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 35 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                  
                    foreach (var u in users)
                    {

#line default
#line hidden
            BeginContext(1100, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1163, 6, false);
#line 39 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1209, 7, false);
#line 40 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1216, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1256, 13, false);
#line 41 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1269, 84, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a href=\"#\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1353, "\"", 1382, 2);
            WriteAttributeValue("", 1358, "anchorMoreDetails", 1358, 17, true);
#line 43 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 1375, u.Id, 1375, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1383, "\"", 1420, 3);
            WriteAttributeValue("", 1393, "loadMoreDetails(\'", 1393, 17, true);
#line 43 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 1410, u.Id, 1410, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 1417, "\');", 1417, 3, true);
            EndWriteAttribute();
            BeginContext(1421, 99, true);
            WriteLiteral(">More Details</a>\r\n                                &nbsp;&nbsp;\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1520, "\"", 1554, 2);
            WriteAttributeValue("", 1527, "/Subscription?user_id=", 1527, 22, true);
#line 45 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 1549, u.Id, 1549, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1555, 100, true);
            WriteLiteral(">Subscriptions</a>\r\n                                &nbsp;&nbsp;\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1655, "\"", 1676, 2);
            WriteAttributeValue("", 1662, "/User?id=", 1662, 9, true);
#line 47 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 1671, u.Id, 1671, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1677, 91, true);
            WriteLiteral(">Edit</a>\r\n                                &nbsp;&nbsp;\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1768, "\"", 1805, 3);
            WriteAttributeValue("", 1775, "/User?id=", 1775, 9, true);
#line 49 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 1784, u.Id, 1784, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 1791, "&action=delete", 1791, 14, true);
            EndWriteAttribute();
            BeginContext(1806, 191, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to delete?\');\" style=\"color:#FF0000;\">Delete</a>\r\n                            </td>\r\n                        </tr>\r\n                        <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1997, "\"", 2023, 2);
            WriteAttributeValue("", 2002, "moreDetailsRow", 2002, 14, true);
#line 52 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2016, u.Id, 2016, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2024, 68, true);
            WriteLiteral(" style=\"display:none;\">\r\n                            <td colspan=\"4\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2092, "\"", 2115, 2);
            WriteAttributeValue("", 2097, "moreDetails", 2097, 11, true);
#line 53 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2108, u.Id, 2108, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2116, 39, true);
            WriteLiteral("></td>\r\n                        </tr>\r\n");
            EndContext();
#line 55 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(2197, 1074, true);
            WriteLiteral(@"            </tbody>
        </table>

        <script type=""text/javascript"">
            function loadMoreDetails(userId) {
                if ($(""#moreDetailsRow"" + userId).css(""display"") != ""none"") {
                    $(""#moreDetailsRow"" + userId).css(""display"", ""none"");
                    $(""#anchorMoreDetails"" + userId).text(""More Details"");
                    return;
                }
                $(""#anchorMoreDetails"" + userId).text(""Loading..."");
                var pageUrl = '/UserMoreDetails?user_id=' + userId;
                console.log(pageUrl);
                $.ajax({
                    url: pageUrl,
                }).done(function (result) {
                    $(""#moreDetailsRow"" + userId).css(""display"", ""table-row"");
                    $(""#moreDetails"" + userId).html(result);
                    $(""#anchorMoreDetails"" + userId).text(""Hide Details"");
                });
            }
        </script>
    </div>

    <div id=""requests"" class=""tab-pane fade ");
            WriteLiteral("in\">\r\n\r\n        <h2>Subscription Requests</h2>\r\n\r\n");
            EndContext();
#line 85 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
          
            List<Models.SubscriptionRequest> requests = (List<Models.SubscriptionRequest>)ViewData["SubscriptionRequests"];
            if (requests == null)
            {
                requests = new List<Models.SubscriptionRequest>();
            }
        

#line default
#line hidden
            BeginContext(3552, 297, true);
            WriteLiteral(@"
        <table class=""table table-bordered table-success table-striped"">
            <thead>
                <tr>
                    <th>User</th>
                    <th>Package</th>
                    <th>DateTime</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 102 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                  
                    foreach (var u in requests)
                    {

#line default
#line hidden
            BeginContext(3941, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(4004, 10, false);
#line 106 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(4014, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4054, 13, false);
#line 107 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.PackageName);

#line default
#line hidden
            EndContext();
            BeginContext(4067, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4107, 11, false);
#line 108 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.RequestDt);

#line default
#line hidden
            EndContext();
            BeginContext(4118, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 110 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(4198, 135, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n    <div id=\"packages\" class=\"tab-pane fade in\">\r\n\r\n        <h2>Packages</h2>\r\n\r\n");
            EndContext();
#line 120 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
          
            List<Models.Package> packages = (List<Models.Package>)ViewData["Packages"];
            if (packages == null)
            {
                packages = new List<Models.Package>();
            }
        

#line default
#line hidden
            BeginContext(4566, 598, true);
            WriteLiteral(@"
        <div class=""add-new-container"" style=""margin-bottom: 15px;text-align: right"">
            <a href=""Package"">+Add New Package</a>
        </div>

        <table class=""table table-bordered table-success table-striped"">
            <thead>
                <tr>
                    <th>Image</th>
                    <th>Title</th>
                    <th>Duration</th>
                    <th>Amount</th>
                    <th>Location</th>
                    <th>Lat/Lng</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 145 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                  
                    foreach (var u in packages)
                    {

#line default
#line hidden
            BeginContext(5256, 64, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n");
            EndContext();
#line 150 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                  
                                    if (!string.IsNullOrEmpty(u.ImageUrl))
                                    {

#line default
#line hidden
            BeginContext(5471, 44, true);
            WriteLiteral("                                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 5515, "\"", 5532, 1);
#line 153 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 5521, u.ImageUrl, 5521, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5533, 26, true);
            WriteLiteral(" style=\"width: 60px;\" />\r\n");
            EndContext();
#line 154 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(5633, 67, true);
            WriteLiteral("                            </td>\r\n                            <td>");
            EndContext();
            BeginContext(5701, 7, false);
#line 157 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.Title);

#line default
#line hidden
            EndContext();
            BeginContext(5708, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5749, 11, false);
#line 158 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                            Write(u.NumMonths);

#line default
#line hidden
            EndContext();
            BeginContext(5761, 48, true);
            WriteLiteral(" month(s)</td>\r\n                            <td>");
            EndContext();
            BeginContext(5810, 8, false);
#line 159 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(5818, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5858, 14, false);
#line 160 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                           Write(u.LocationText);

#line default
#line hidden
            EndContext();
            BeginContext(5872, 91, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5963, "\"", 6046, 4);
            WriteAttributeValue("", 5970, "https://www.google.com/maps/search/?api=1&query=", 5970, 48, true);
#line 162 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6018, u.Latitude, 6018, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 6031, ",", 6031, 1, true);
#line 162 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6032, u.Longitude, 6032, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6047, 39, true);
            WriteLiteral(">\r\n                                    ");
            EndContext();
            BeginContext(6088, 10, false);
#line 163 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                Write(u.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(6099, 1, true);
            WriteLiteral(",");
            EndContext();
            BeginContext(6102, 11, false);
#line 163 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                              Write(u.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(6114, 143, true);
            WriteLiteral("\r\n                                </a>\r\n                            </td>\r\n                            <td>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6257, "\"", 6281, 2);
            WriteAttributeValue("", 6264, "/Package?id=", 6264, 12, true);
#line 167 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6276, u.Id, 6276, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6282, 91, true);
            WriteLiteral(">Edit</a>\r\n                                &nbsp;&nbsp;\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6373, "\"", 6413, 3);
            WriteAttributeValue("", 6380, "/Package?id=", 6380, 12, true);
#line 169 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6392, u.Id, 6392, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 6399, "&action=delete", 6399, 14, true);
            EndWriteAttribute();
            BeginContext(6414, 164, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to delete?\');\" style=\"color:#FF0000;\">Delete</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 172 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(6620, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.UsersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UsersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UsersModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.UsersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
