#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f56744053cf7a295fb2518f40d72b9a03aab445e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_ManagementUser), @"mvc.1.0.razor-page", @"/Pages/ManagementUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/ManagementUser.cshtml", typeof(ZiadBooking.Pages.Pages_ManagementUser), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f56744053cf7a295fb2518f40d72b9a03aab445e", @"/Pages/ManagementUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ManagementUser : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
  
    ViewData["Title"] = "Management User";

#line default
#line hidden
            BeginContext(104, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(155, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(201, 30, false);
#line 11 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(231, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 13 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
    }

#line default
#line hidden
            BeginContext(259, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
  
    Models.Admin user = null;
    if (ViewData["User"] != null)
    {
        user = (Models.Admin)ViewData["User"];
    }

    Models.GenericModel userAuth = (Models.GenericModel)ViewData["UserAuth"];
    if (userAuth == null)
    {
        userAuth = new Models.GenericModel();
    }

    List<dynamic> usertypes = new List<dynamic>();
    usertypes.Add(new { id = "admin", label = "Admin" });
    usertypes.Add(new { id = "reception", label = "Reception" });
    usertypes.Add(new { id = "ceo", label = "CEO" });

    string utype = user != null ? user.UserType : "";

    /*List<string> reportsKeys = new List<string>();
    reportsKeys.Add("report_allreservations");
    reportsKeys.Add("report_nowshow");
    reportsKeys.Add("report_cancellations");
    reportsKeys.Add("report_clientsinside");
    reportsKeys.Add("report_subscriptionsended");
    reportsKeys.Add("report_subscriptionsending");*/

#line default
#line hidden
            BeginContext(1198, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 45 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
 if (user != null)
{

#line default
#line hidden
            BeginContext(1223, 35, true);
            WriteLiteral("    <h2>Edit Management User</h2>\r\n");
            EndContext();
#line 48 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1270, 38, true);
            WriteLiteral("    <h2>Add New Management User</h2>\r\n");
            EndContext();
#line 52 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
}

#line default
#line hidden
            BeginContext(1311, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(1317, 4600, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1be9d06395a84950b5b2e55dc69e3a8b", async() => {
                BeginContext(1367, 189, true);
                WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Name</b>\r\n                <input type=\"text\" class=\"form-control\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1556, "\"", 1596, 1);
#line 58 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
WriteAttributeValue("", 1564, user == null ? "" : user.Name, 1564, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1597, 187, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Email</b>\r\n                <input type=\"text\" class=\"form-control\" name=\"email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1784, "\"", 1825, 1);
#line 62 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
WriteAttributeValue("", 1792, user == null ? "" : user.Email, 1792, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1826, 256, true);
                WriteLiteral(@" />
            </div>
        </div>
        <div class=""row"" style=""margin-top: 15px;"">
            <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-12"">
                <b>User Type</b>
                <select class=""form-control"" name=""user_type"">
");
                EndContext();
#line 69 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                       foreach (var m in usertypes)
                        {
                            string sel = "";
                            if (m.id.CompareTo(utype) == 0)
                            {
                                sel = "SELECTED";
                            }
                            if (sel == "")
                            {

#line default
#line hidden
                BeginContext(2457, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2489, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e4f9b7ad72347bdac38432aa492ddff", async() => {
                    BeginContext(2512, 7, false);
#line 78 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                 Write(m.label);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 78 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                   WriteLiteral(m.id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2528, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 79 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                            }
                            else
                            {

#line default
#line hidden
                BeginContext(2626, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2658, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c24215703e104d428d2fdd8f6b958afd", async() => {
                    BeginContext(2690, 7, false);
#line 82 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                          Write(m.label);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 82 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                   WriteLiteral(m.id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("SELECTED", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2706, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 83 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                            }
                        }
                    

#line default
#line hidden
                BeginContext(2789, 462, true);
                WriteLiteral(@"                </select>
            </div>
            <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-12"">
                <b>Password</b>
                <input type=""password"" class=""form-control"" name=""password"" />
            </div>
        </div>
        <div class=""row"" style=""margin-top: 15px;"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <b>Report(s)</b>
                <div style=""margin-top: 5px;"">
");
                EndContext();
#line 97 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        string checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_allreservations") && (string)userAuth.values["report_allreservations"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(3508, 73, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_allreservations\" ");
                EndContext();
                BeginContext(3582, 10, false);
#line 100 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                                    Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(3592, 61, true);
                WriteLiteral(" />&nbsp;&nbsp;All Reservations\r\n                    <br />\r\n");
                EndContext();
#line 102 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_noshow") && (string)userAuth.values["report_noshow"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(3885, 64, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_noshow\" ");
                EndContext();
                BeginContext(3950, 10, false);
#line 105 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                           Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(3960, 52, true);
                WriteLiteral(" />&nbsp;&nbsp;No Show\r\n                    <br />\r\n");
                EndContext();
#line 107 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_cancellations") && (string)userAuth.values["report_cancellations"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(4258, 71, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_cancellations\" ");
                EndContext();
                BeginContext(4330, 10, false);
#line 110 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                                  Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(4340, 58, true);
                WriteLiteral(" />&nbsp;&nbsp;Cancellations\r\n                    <br />\r\n");
                EndContext();
#line 112 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_clientsinside") && (string)userAuth.values["report_clientsinside"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(4644, 71, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_clientsinside\" ");
                EndContext();
                BeginContext(4716, 10, false);
#line 115 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                                  Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(4726, 59, true);
                WriteLiteral(" />&nbsp;&nbsp;Clients inside\r\n                    <br />\r\n");
                EndContext();
#line 117 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_subscriptionsended") && (string)userAuth.values["report_subscriptionsended"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(5041, 76, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_subscriptionsended\" ");
                EndContext();
                BeginContext(5118, 10, false);
#line 120 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                                       Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(5128, 64, true);
                WriteLiteral(" />&nbsp;&nbsp;Subscriptions Ended\r\n                    <br />\r\n");
                EndContext();
#line 122 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                      
                        checkedStr = (userAuth != null && userAuth.values.ContainsKey("report_subscriptionsending") && (string)userAuth.values["report_subscriptionsending"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(5450, 77, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"report_subscriptionsending\" ");
                EndContext();
                BeginContext(5528, 10, false);
#line 125 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\ManagementUser.cshtml"
                                                                        Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(5538, 372, true);
                WriteLiteral(@" />&nbsp;&nbsp;Subscriptions Ending
                    <br />
                </div>
            </div>
        </div>
        <div class=""row"" style=""margin-top: 30px;"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <button class=""btn btn-success btn-block"" type=""submit"">SAVE</button>
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.ManagementUserModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.ManagementUserModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.ManagementUserModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.ManagementUserModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591