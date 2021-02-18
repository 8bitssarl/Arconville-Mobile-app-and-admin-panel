#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60e43c8caa0153b98c8e80388ec8f4f9edb7d5ab"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60e43c8caa0153b98c8e80388ec8f4f9edb7d5ab", @"/Pages/Reception.cshtml")]
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
            BeginContext(979, 24, true);
            WriteLiteral("\r\n<h2>Search User</h2>\r\n");
            EndContext();
            BeginContext(1003, 223, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f181c0be2664d53a3252789621ad6ca", async() => {
                BeginContext(1023, 57, true);
                WriteLiteral("\r\n    <input type=\"text\" class=\"form-control\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1080, "\"", 1097, 1);
#line 41 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 1088, userName, 1088, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1098, 121, true);
                WriteLiteral(" placeholder=\"Name of user\" />\r\n    <button class=\"btn btn-success btn-block\" style=\"margin-top: 15px;\">Search</button>\r\n");
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
            BeginContext(1226, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 45 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
  
    if (ViewData["User"] != null)
    {
        Models.User usr = (Models.User)ViewData["User"];

#line default
#line hidden
            BeginContext(1334, 371, true);
            WriteLiteral(@"        <h3>Personal Details</h3>
        <table class=""table table-bordered table-success table-striped"">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>");
            EndContext();
            BeginContext(1706, 8, false);
#line 60 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                   Write(usr.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1714, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1746, 9, false);
#line 61 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                   Write(usr.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1755, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1787, 15, false);
#line 62 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                   Write(usr.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1802, 70, true);
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n");
            EndContext();
            BeginContext(1874, 32, true);
            WriteLiteral("        <h3>Subscriptions</h3>\r\n");
            EndContext();
            BeginContext(1908, 348, true);
            WriteLiteral(@"        <table class=""table table-bordered table-success table-striped"">
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
#line 79 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                  
                    foreach (var x in subscriptions)
                    {
                        string color = "#00FF00";
                        if (x.ExpiredAt.Contains("EXPIRED"))
                        {
                            color = "#FF0000";
                        }

#line default
#line hidden
            BeginContext(2568, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(2631, 13, false);
#line 88 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(2644, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2684, 11, false);
#line 89 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(2695, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2735, 11, false);
#line 90 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.NumMonths);

#line default
#line hidden
            EndContext();
            BeginContext(2746, 44, true);
            WriteLiteral("</td>\r\n                            <td><span");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2790, "\"", 2830, 4);
            WriteAttributeValue("", 2798, "color:", 2798, 6, true);
#line 91 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 2804, color, 2804, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 2812, ";font-weight:", 2812, 13, true);
            WriteAttributeValue(" ", 2825, "600;", 2826, 5, true);
            EndWriteAttribute();
            BeginContext(2831, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2834, 11, false);
#line 91 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                                                                           Write(x.ExpiredAt);

#line default
#line hidden
            EndContext();
            BeginContext(2846, 45, true);
            WriteLiteral("</span></td>\r\n                        </tr>\r\n");
            EndContext();
#line 93 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(2933, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
            BeginContext(2975, 31, true);
            WriteLiteral("        <h3>Reservations</h3>\r\n");
            EndContext();
            BeginContext(3008, 488, true);
            WriteLiteral(@"        <table class=""table table-bordered table-success table-striped"">
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
#line 114 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                  
                    foreach (var x in reservations)
                    {

#line default
#line hidden
            BeginContext(3592, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(3655, 13, false);
#line 118 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(3668, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3708, 10, false);
#line 119 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(3718, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3758, 11, false);
#line 120 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(3769, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3809, 9, false);
#line 121 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.EndDate);

#line default
#line hidden
            EndContext();
            BeginContext(3818, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3858, 10, false);
#line 122 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.NumHours);

#line default
#line hidden
            EndContext();
            BeginContext(3868, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3908, 13, false);
#line 123 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.ReserveDate);

#line default
#line hidden
            EndContext();
            BeginContext(3921, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3961, 15, false);
#line 124 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.CheckinAtDate);

#line default
#line hidden
            EndContext();
            BeginContext(3976, 73, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4049, 416, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a25fe7066484ce399f91e10a2946f46", async() => {
                BeginContext(4069, 58, true);
                WriteLiteral("\r\n                                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4127, "\"", 4140, 1);
#line 127 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 4135, x.Id, 4135, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4141, 174, true);
                WriteLiteral(" name=\"reservation_id\" />\r\n                                    <input type=\"hidden\" value=\"checkin\" name=\"status\" />\r\n                                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4315, "\"", 4332, 1);
#line 129 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 4323, usr.Name, 4323, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4333, 125, true);
                WriteLiteral(" name=\"name\" />\r\n                                    <button type=\"submit\">CHECKIN</button>\r\n                                ");
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
            BeginContext(4465, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4568, 418, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "811accd904e84ab9b6649a2bbe73c989", async() => {
                BeginContext(4588, 58, true);
                WriteLiteral("\r\n                                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4646, "\"", 4659, 1);
#line 135 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 4654, x.Id, 4654, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4660, 175, true);
                WriteLiteral(" name=\"reservation_id\" />\r\n                                    <input type=\"hidden\" value=\"checkout\" name=\"status\" />\r\n                                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4835, "\"", 4852, 1);
#line 137 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
WriteAttributeValue("", 4843, usr.Name, 4843, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4853, 126, true);
                WriteLiteral(" name=\"name\" />\r\n                                    <button type=\"submit\">CHECKOUT</button>\r\n                                ");
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
            BeginContext(4986, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 142 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(5096, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
            BeginContext(5138, 25, true);
            WriteLiteral("        <h3>Family</h3>\r\n");
            EndContext();
            BeginContext(5165, 290, true);
            WriteLiteral(@"        <table class=""table table-bordered table-success table-striped"">
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
#line 158 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                  
                    foreach (var x in family)
                    {

#line default
#line hidden
            BeginContext(5545, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(5608, 27, false);
#line 162 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.values["name"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5635, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5675, 28, false);
#line 163 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.values["email"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5703, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(5743, 35, false);
#line 164 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                           Write(x.values["phone_number"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5778, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 166 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(5858, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 170 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Reception.cshtml"
    }

#line default
#line hidden
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
