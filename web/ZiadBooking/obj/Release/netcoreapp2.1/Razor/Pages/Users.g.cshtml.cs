#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d15812e68af10082585c44a6f5811fdea4688f7c"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d15812e68af10082585c44a6f5811fdea4688f7c", @"/Pages/Users.cshtml")]
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
            BeginContext(170, 233, true);
            WriteLiteral("\r\n<div id=\"info-div\">\r\n\r\n    <div class=\"switch-buttons\">\r\n        <a data-toggle=\"tab\" href=\"#users\">Users</a>\r\n        <a data-toggle=\"tab\" href=\"#services\">Services</a>\r\n        <a data-toggle=\"tab\" href=\"#packages\">Packages</a>\r\n");
            EndContext();
#line 17 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
          
            List<Models.SubscriptionRequest> srequests = (List<Models.SubscriptionRequest>)ViewData["SubscriptionRequests"];
            if (srequests == null)
            {
                srequests = new List<Models.SubscriptionRequest>();
            }
            if (srequests.Count == 0)
            {

#line default
#line hidden
            BeginContext(730, 81, true);
            WriteLiteral("                <a data-toggle=\"tab\" href=\"#requests\">Subscription Requests</a>\r\n");
            EndContext();
#line 26 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(859, 115, true);
            WriteLiteral("                <a data-toggle=\"tab\" href=\"#requests\" style=\"background-color:#ffd800;\">Subscription Requests</a>\r\n");
            EndContext();
#line 30 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
            }
        

#line default
#line hidden
            BeginContext(1000, 1093, true);
            WriteLiteral(@"
    </div>

    <!--<ul class=""nav nav-tabs"">
        <li class=""active""><a data-toggle=""tab"" href=""#users"">Users</a></li>
        <li><a data-toggle=""tab"" href=""#services"">Services</a></li>
        <li><a data-toggle=""tab"" href=""#packages"">Packages</a></li>
        <li><a data-toggle=""tab"" href=""#requests"">Subscription Requests</a></li>
    </ul>-->

    <div class=""tab-content"">
        <div id=""users"" class=""tab-pane fade in active"">
            <div class=""page-heading"">Users</div>
            <div class=""add-new-container"">
                <a href=""User"">+Add New User</a>
            </div>
            <div class=""clearfix""></div>

            <table class=""table table-borderless table-success table-striped info-table"">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Date Of Birth</th>
                        <th>Actions</th>
         ");
            WriteLiteral("           </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 61 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                      
                        foreach (var u in users)
                        {

#line default
#line hidden
            BeginContext(2194, 70, true);
            WriteLiteral("                            <tr>\r\n                                <td>");
            EndContext();
            BeginContext(2265, 6, false);
#line 65 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2271, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2315, 7, false);
#line 66 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2322, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2366, 13, false);
#line 67 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2379, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2423, 13, false);
#line 68 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.DateOfBirth);

#line default
#line hidden
            EndContext();
            BeginContext(2436, 92, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a href=\"#\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2528, "\"", 2557, 2);
            WriteAttributeValue("", 2533, "anchorMoreDetails", 2533, 17, true);
#line 70 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2550, u.Id, 2550, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2558, "\"", 2595, 3);
            WriteAttributeValue("", 2568, "loadMoreDetails(\'", 2568, 17, true);
#line 70 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2585, u.Id, 2585, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 2592, "\');", 2592, 3, true);
            EndWriteAttribute();
            BeginContext(2596, 107, true);
            WriteLiteral(">More Details</a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2703, "\"", 2737, 2);
            WriteAttributeValue("", 2710, "/Subscription?user_id=", 2710, 22, true);
#line 72 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2732, u.Id, 2732, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2738, 108, true);
            WriteLiteral(">Subscriptions</a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2846, "\"", 2867, 2);
            WriteAttributeValue("", 2853, "/User?id=", 2853, 9, true);
#line 74 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 2862, u.Id, 2862, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2868, 121, true);
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2989, "\"", 3026, 3);
            WriteAttributeValue("", 2996, "/User?id=", 2996, 9, true);
#line 76 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 3005, u.Id, 3005, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 3012, "&action=delete", 3012, 14, true);
            EndWriteAttribute();
            BeginContext(3027, 224, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to delete?\');\" style=\"color:#FF0000;\"><i class=\"fa fa-trash\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n                            <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3251, "\"", 3277, 2);
            WriteAttributeValue("", 3256, "moreDetailsRow", 3256, 14, true);
#line 79 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 3270, u.Id, 3270, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3278, 72, true);
            WriteLiteral(" style=\"display:none;\">\r\n                                <td colspan=\"4\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3350, "\"", 3373, 2);
            WriteAttributeValue("", 3355, "moreDetails", 3355, 11, true);
#line 80 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 3366, u.Id, 3366, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3374, 43, true);
            WriteLiteral("></td>\r\n                            </tr>\r\n");
            EndContext();
#line 82 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(3467, 1122, true);
            WriteLiteral(@"                </tbody>
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
                ");
            WriteLiteral("}\r\n            </script>\r\n        </div>\r\n\r\n        <div id=\"services\" class=\"tab-pane fade in\">\r\n");
            EndContext();
#line 109 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
              
                List<Models.BookingService> services = (List<Models.BookingService>)ViewData["Services"];
            

#line default
#line hidden
            BeginContext(4727, 611, true);
            WriteLiteral(@"            <div class=""page-heading"">Services</div>
            <div class=""add-new-container"">
                <a href=""BookingService"">+Add New Service</a>
            </div>
            <div class=""clearfix""></div>
            <table class=""table table-borderless table-success table-striped info-table"">
                <thead>
                    <tr>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Book Online</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 127 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                      
                        foreach (var u in services)
                        {

#line default
#line hidden
            BeginContext(5442, 72, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n");
            EndContext();
#line 132 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                      
                                        if (!string.IsNullOrEmpty(u.ImageUrl))
                                        {

#line default
#line hidden
            BeginContext(5677, 48, true);
            WriteLiteral("                                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 5725, "\"", 5742, 1);
#line 135 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 5731, u.ImageUrl, 5731, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5743, 26, true);
            WriteLiteral(" style=\"width: 60px;\" />\r\n");
            EndContext();
#line 136 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(5851, 75, true);
            WriteLiteral("                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(5927, 6, false);
#line 139 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.Name);

#line default
#line hidden
            EndContext();
            BeginContext(5933, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(5978, 50, false);
#line 140 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                Write(u.CanBookOnline.CompareTo("1") == 0 ? "YES" : "NO");

#line default
#line hidden
            EndContext();
            BeginContext(6029, 83, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6112, "\"", 6143, 2);
            WriteAttributeValue("", 6119, "/BookingService?id=", 6119, 19, true);
#line 142 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6138, u.Id, 6138, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6144, 121, true);
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6265, "\"", 6312, 3);
            WriteAttributeValue("", 6272, "/BookingService?id=", 6272, 19, true);
#line 144 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 6291, u.Id, 6291, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 6298, "&action=delete", 6298, 14, true);
            EndWriteAttribute();
            BeginContext(6313, 193, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to delete?\');\" style=\"color:#FF0000;\"><i class=\"fa fa-trash\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 147 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(6556, 194, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n            <script type=\"text/javascript\">\r\n\r\n            </script>\r\n        </div>\r\n\r\n        <div id=\"packages\" class=\"tab-pane fade in\">\r\n\r\n");
            EndContext();
#line 159 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
              
                List<Models.Package> packages = (List<Models.Package>)ViewData["Packages"];
                if (packages == null)
                {
                    packages = new List<Models.Package>();
                }
            

#line default
#line hidden
            BeginContext(7011, 725, true);
            WriteLiteral(@"
            <div class=""page-heading"">Packages</div>
            <div class=""add-new-container"">
                <a href=""Package"">+Add New Package</a>
            </div>
            <div class=""clearfix""></div>

            <table class=""table table-borderless table-success table-striped info-table"">
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
#line 186 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                      
                        foreach (var u in packages)
                        {

#line default
#line hidden
            BeginContext(7840, 72, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n");
            EndContext();
#line 191 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                      
                                        if (!string.IsNullOrEmpty(u.ImageUrl))
                                        {

#line default
#line hidden
            BeginContext(8075, 48, true);
            WriteLiteral("                                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 8123, "\"", 8140, 1);
#line 194 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 8129, u.ImageUrl, 8129, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8141, 26, true);
            WriteLiteral(" style=\"width: 60px;\" />\r\n");
            EndContext();
#line 195 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(8249, 75, true);
            WriteLiteral("                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(8325, 7, false);
#line 198 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.Title);

#line default
#line hidden
            EndContext();
            BeginContext(8332, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(8377, 11, false);
#line 199 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                Write(u.NumMonths);

#line default
#line hidden
            EndContext();
            BeginContext(8389, 52, true);
            WriteLiteral(" month(s)</td>\r\n                                <td>");
            EndContext();
            BeginContext(8442, 8, false);
#line 200 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(8450, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(8494, 14, false);
#line 201 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.LocationText);

#line default
#line hidden
            EndContext();
            BeginContext(8508, 99, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 8607, "\"", 8690, 4);
            WriteAttributeValue("", 8614, "https://www.google.com/maps/search/?api=1&query=", 8614, 48, true);
#line 203 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 8662, u.Latitude, 8662, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 8675, ",", 8675, 1, true);
#line 203 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 8676, u.Longitude, 8676, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8691, 43, true);
            WriteLiteral(">\r\n                                        ");
            EndContext();
            BeginContext(8736, 10, false);
#line 204 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                    Write(u.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(8747, 1, true);
            WriteLiteral(",");
            EndContext();
            BeginContext(8750, 11, false);
#line 204 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                                                  Write(u.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(8762, 159, true);
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 8921, "\"", 8945, 2);
            WriteAttributeValue("", 8928, "/Package?id=", 8928, 12, true);
#line 208 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 8940, u.Id, 8940, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8946, 121, true);
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 9067, "\"", 9107, 3);
            WriteAttributeValue("", 9074, "/Package?id=", 9074, 12, true);
#line 210 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 9086, u.Id, 9086, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 9093, "&action=delete", 9093, 14, true);
            EndWriteAttribute();
            BeginContext(9108, 193, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to delete?\');\" style=\"color:#FF0000;\"><i class=\"fa fa-trash\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 213 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(9351, 120, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n        <div id=\"requests\" class=\"tab-pane fade in\">\r\n");
            EndContext();
#line 220 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
              
                List<Models.SubscriptionRequest> requests = (List<Models.SubscriptionRequest>)ViewData["SubscriptionRequests"];
                if (requests == null)
                {
                    requests = new List<Models.SubscriptionRequest>();
                }
            

#line default
#line hidden
            BeginContext(9780, 528, true);
            WriteLiteral(@"            <div class=""page-heading"">Subscription Requests</div>
            <div class=""clearfix""></div>
            <table class=""table table-borderless table-success table-striped info-table"">
                <thead>
                    <tr>
                        <th>User</th>
                        <th>Phone</th>
                        <th>Package</th>
                        <th>DateTime</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 240 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                      
                        foreach (var u in requests)
                        {

#line default
#line hidden
            BeginContext(10412, 70, true);
            WriteLiteral("                            <tr>\r\n                                <td>");
            EndContext();
            BeginContext(10483, 10, false);
#line 244 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(10493, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(10537, 13, false);
#line 245 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(10550, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(10594, 13, false);
#line 246 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.PackageName);

#line default
#line hidden
            EndContext();
            BeginContext(10607, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(10651, 11, false);
#line 247 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                               Write(u.RequestDt);

#line default
#line hidden
            EndContext();
            BeginContext(10662, 83, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 10745, "\"", 10798, 3);
            WriteAttributeValue("", 10752, "/SubscriptionRequest?id=(", 10752, 25, true);
#line 249 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 10777, u.Id, 10777, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 10782, ")&action=confirm", 10782, 16, true);
            EndWriteAttribute();
            BeginContext(10799, 185, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to confirm?\');\"><i class=\"fa fa-check\"></i></a>\r\n                                    &nbsp;&nbsp;\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 10984, "\"", 11036, 3);
            WriteAttributeValue("", 10991, "/SubscriptionRequest?id=", 10991, 24, true);
#line 251 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
WriteAttributeValue("", 11015, u.Id, 11015, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 11022, "&action=cancel", 11022, 14, true);
            EndWriteAttribute();
            BeginContext(11037, 193, true);
            WriteLiteral(" onclick=\"return confirm(\'Are you sure you want to cancel?\');\" style=\"color:#FF0000;\"><i class=\"fa fa-times\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 254 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Users.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(11280, 480, true);
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function onCancel(formId) {
        if (window.confirm(""Are you sure you want to cancel?"")) {
            document.getElementById(formId).submit();
        }
    }

    function onConfirm(formId) {
        if (window.confirm(""Are you sure you want to confirm?"")) {
            document.getElementById(formId).submit();
        }
    }

</script>");
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
