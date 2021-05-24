#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b99a527f8fe378dc71c9f73423807165b7cce24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_Reception), @"mvc.1.0.razor-page", @"/Pages/Reception.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Reception.cshtml", typeof(ZiadBooking.Pages.Pages_Reception), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b99a527f8fe378dc71c9f73423807165b7cce24", @"/Pages/Reception.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Reception : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
  
    ViewData["Title"] = "Reception";
    string userName = "";
    if (ViewData["UserName"] != null)
    {
        userName = (string)ViewData["UserName"];
    }

#line default
#line hidden
            BeginContext(223, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(274, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(320, 30, false);
#line 16 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(350, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 18 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
    }

#line default
#line hidden
            BeginContext(378, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 21 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
  
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

#line default
#line hidden
            BeginContext(979, 144, true);
            WriteLiteral("\r\n        <div id=\"info-div\">\r\n\r\n            <div class=\"page-heading\">Search User</div>\r\n            <div class=\"clearfix\"></div>\r\n            ");
            EndContext();
            BeginContext(1123, 292, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "428cc8e088fb45c4b1e8ba8ea3f77059", async() => {
                BeginContext(1143, 88, true);
                WriteLiteral("\r\n                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1231, "\"", 1248, 1);
#line 44 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 1239, userName, 1239, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1249, 159, true);
                WriteLiteral(" placeholder=\"Full name or email of user\" />\r\n                <button class=\"btn btn-success btn-block\" style=\"margin-top: 15px;\">Search</button>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1415, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 48 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
              
                if (ViewData["User"] != null)
                {
                    Models.User usr = (Models.User)ViewData["User"];

#line default
#line hidden
            BeginContext(1571, 657, true);
            WriteLiteral(@"                    <div class=""page-heading"">Personal Details</div>
                    <div class=""clearfix""></div>
                    <table class=""table table-bordered table-success table-striped info-table"">
                        <thead>
                            <tr>
                                <th>Profile Image</th>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Phone</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
");
            EndContext();
#line 66 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                     if (usr.ProfilePicUrl.CompareTo("") != 0)
                                    {

#line default
#line hidden
            BeginContext(2347, 44, true);
            WriteLiteral("                                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2391, "\"", 2415, 1);
#line 68 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 2397, usr.ProfilePicUrl, 2397, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2416, 26, true);
            WriteLiteral(" style=\"width: 60px;\" />\r\n");
            EndContext();
#line 69 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                    }

#line default
#line hidden
            BeginContext(2481, 75, true);
            WriteLiteral("                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(2557, 8, false);
#line 71 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                               Write(usr.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2565, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2609, 9, false);
#line 72 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                               Write(usr.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2618, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2662, 15, false);
#line 73 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                               Write(usr.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2677, 106, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n");
            EndContext();
            BeginContext(2785, 117, true);
            WriteLiteral("                    <div class=\"page-heading\">Subscriptions</div>\r\n                    <div class=\"clearfix\"></div>\r\n");
            EndContext();
            BeginContext(2904, 479, true);
            WriteLiteral(@"                    <table class=""table table-bordered table-success table-striped info-table"">
                        <thead>
                            <tr>
                                <th>Service</th>
                                <th>Start (YYYY-MM-DD)</th>
                                <th>Months</th>
                                <th>Expires At</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 91 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                              
                                foreach (var x in subscriptions)
                                {
                                    string color = "#00FF00";
                                    if (x.ExpiredAt.Contains("EXPIRED"))
                                    {
                                        color = "#FF0000";
                                    }

#line default
#line hidden
            BeginContext(3791, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(3878, 13, false);
#line 100 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(3891, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3943, 11, false);
#line 101 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(3954, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(4006, 11, false);
#line 102 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.NumMonths);

#line default
#line hidden
            EndContext();
            BeginContext(4017, 56, true);
            WriteLiteral("</td>\r\n                                        <td><span");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4073, "\"", 4113, 4);
            WriteAttributeValue("", 4081, "color:", 4081, 6, true);
#line 103 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 4087, color, 4087, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4095, ";font-weight:", 4095, 13, true);
            WriteAttributeValue(" ", 4108, "600;", 4109, 5, true);
            EndWriteAttribute();
            BeginContext(4114, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4117, 11, false);
#line 103 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                                                                       Write(x.ExpiredAt);

#line default
#line hidden
            EndContext();
            BeginContext(4129, 57, true);
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n");
            EndContext();
#line 105 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(4252, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
            BeginContext(4318, 116, true);
            WriteLiteral("                    <div class=\"page-heading\">Reservations</div>\r\n                    <div class=\"clearfix\"></div>\r\n");
            EndContext();
            BeginContext(4436, 667, true);
            WriteLiteral(@"                    <table class=""table table-bordered table-success table-striped info-table"">
                        <thead>
                            <tr>
                                <th>Service</th>
                                <th>User</th>
                                <th>From</th>
                                <th>Till</th>
                                <th>Hours</th>
                                <th>Reserved On</th>
                                <th>Checkin At</th>
                                <th colspan=""2""></th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 127 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                              
                                foreach (var x in reservations)
                                {

#line default
#line hidden
            BeginContext(5235, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(5322, 13, false);
#line 131 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(5335, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5387, 10, false);
#line 132 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(5397, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5449, 11, false);
#line 133 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(5460, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5512, 9, false);
#line 134 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.EndDate);

#line default
#line hidden
            EndContext();
            BeginContext(5521, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5573, 10, false);
#line 135 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.NumHours);

#line default
#line hidden
            EndContext();
            BeginContext(5583, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5635, 13, false);
#line 136 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.ReserveDate);

#line default
#line hidden
            EndContext();
            BeginContext(5648, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5700, 15, false);
#line 137 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.CheckinAtDate);

#line default
#line hidden
            EndContext();
            BeginContext(5715, 97, true);
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(5812, 476, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33ea1afcd0a243009b3b00060479238e", async() => {
                BeginContext(5832, 70, true);
                WriteLiteral("\r\n                                                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5902, "\"", 5915, 1);
#line 140 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 5910, x.Id, 5910, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5916, 198, true);
                WriteLiteral(" name=\"reservation_id\" />\r\n                                                <input type=\"hidden\" value=\"checkin\" name=\"status\" />\r\n                                                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6114, "\"", 6131, 1);
#line 142 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 6122, usr.Name, 6122, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6132, 149, true);
                WriteLiteral(" name=\"name\" />\r\n                                                <button type=\"submit\">CHECKIN</button>\r\n                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6288, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(6427, 478, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426a713c0b894937a28130a046cb1d18", async() => {
                BeginContext(6447, 70, true);
                WriteLiteral("\r\n                                                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6517, "\"", 6530, 1);
#line 148 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 6525, x.Id, 6525, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6531, 199, true);
                WriteLiteral(" name=\"reservation_id\" />\r\n                                                <input type=\"hidden\" value=\"checkout\" name=\"status\" />\r\n                                                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6730, "\"", 6747, 1);
#line 150 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 6738, usr.Name, 6738, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6748, 150, true);
                WriteLiteral(" name=\"name\" />\r\n                                                <button type=\"submit\">CHECKOUT</button>\r\n                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6905, 92, true);
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 155 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(7063, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
            BeginContext(7129, 110, true);
            WriteLiteral("                    <div class=\"page-heading\">Family</div>\r\n                    <div class=\"clearfix\"></div>\r\n");
            EndContext();
            BeginContext(7241, 460, true);
            WriteLiteral(@"                    <table class=""table table-bordered table-success table-striped info-table"">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Phone</th>
                                <th>Relation</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 173 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                              
                                foreach (var x in family)
                                {

#line default
#line hidden
            BeginContext(7827, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(7914, 27, false);
#line 177 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.values["name"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(7941, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(7993, 28, false);
#line 178 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.values["email"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(8021, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(8073, 35, false);
#line 179 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.values["phone_number"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(8108, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(8160, 41, false);
#line 180 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                       Write(x.values["relation"].ToString().ToUpper());

#line default
#line hidden
            EndContext();
            BeginContext(8201, 50, true);
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
            EndContext();
#line 182 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(8317, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 186 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                }
            

#line default
#line hidden
            BeginContext(8415, 14, true);
            WriteLiteral("        </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.ReceptionModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.ReceptionModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.ReceptionModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.ReceptionModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
