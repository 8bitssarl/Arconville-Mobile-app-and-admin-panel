#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49a4eba778779b4089796a3608ca9f32dad67779"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_User), @"mvc.1.0.razor-page", @"/Pages/User.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/User.cshtml", typeof(ZiadBooking.Pages.Pages_User), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49a4eba778779b4089796a3608ca9f32dad67779", @"/Pages/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_User : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
  
    ViewData["Title"] = "User";

#line default
#line hidden
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(134, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(180, 30, false);
#line 11 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(210, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 13 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
    }

#line default
#line hidden
            BeginContext(238, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
  
    Models.User user = null;
    List<Models.GenericModel> family = null;
    if (ViewData["User"] != null)
    {
        user = (Models.User)ViewData["User"];
        family = (List<Models.GenericModel>)ViewData["Family"];
    }
    if (family == null)
    {
        family = new List<Models.GenericModel>();
    }

#line default
#line hidden
            BeginContext(574, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
 if (user != null)
{

#line default
#line hidden
            BeginContext(599, 24, true);
            WriteLiteral("    <h2>Edit User</h2>\r\n");
            EndContext();
#line 33 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(635, 27, true);
            WriteLiteral("    <h2>Add New User</h2>\r\n");
            EndContext();
#line 37 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
}

#line default
#line hidden
            BeginContext(665, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(667, 2262, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9a18049751a4721b830343125a4b387", async() => {
                BeginContext(717, 173, true);
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n            <b>Name</b>\r\n            <input type=\"text\" class=\"form-control\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 890, "\"", 924, 1);
#line 43 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 898, user==null?"":user.Name, 898, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(925, 171, true);
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n            <b>Email</b>\r\n            <input type=\"text\" class=\"form-control\" name=\"email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1096, "\"", 1131, 1);
#line 47 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 1104, user==null?"":user.Email, 1104, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1132, 245, true);
                WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\" style=\"margin-top: 15px;\">\r\n        <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n            <b>Phone Number</b>\r\n            <input type=\"tel\" class=\"form-control\" name=\"phone_number\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1377, "\"", 1418, 1);
#line 53 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 1385, user==null?"":user.PhoneNumber, 1385, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1419, 442, true);
                WriteLiteral(@" />
        </div>
        <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-12"">
            <b>Password</b>
            <input type=""password"" class=""form-control"" name=""password"" />
        </div>
    </div>
    <div class=""row"" style=""margin-top: 15px;"">
        <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-12"">
            <b>Date Of Birth (YYYY-MM-DD)</b>
            <input type=""text"" class=""form-control"" name=""date_of_birth""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1861, "\"", 1902, 1);
#line 63 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 1869, user==null?"":user.DateOfBirth, 1869, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1903, 171, true);
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n            <b>Profile Picture</b>\r\n            <input type=\"file\" name=\"profile_pic\" />\r\n");
                EndContext();
#line 68 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
             if (user != null && user.ProfilePicUrl != "")
            {

#line default
#line hidden
                BeginContext(2149, 63, true);
                WriteLiteral("                <span>&nbsp;&nbsp;</span>\r\n                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 2212, "\"", 2237, 1);
#line 71 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 2218, user.ProfilePicUrl, 2218, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2238, 26, true);
                WriteLiteral(" style=\"width: 30px;\" />\r\n");
                EndContext();
#line 72 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
            }

#line default
#line hidden
                BeginContext(2279, 194, true);
                WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"row\" style=\"margin-top: 15px;\">\r\n        <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n            <input type=\"checkbox\" name=\"phone_verified\" ");
                EndContext();
                BeginContext(2475, 64, false);
#line 77 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
                                                     Write(user != null ? (user.PhoneVerified == "1" ? "checked" : "") : "");

#line default
#line hidden
                EndContext();
                BeginContext(2540, 382, true);
                WriteLiteral(@" />
            &nbsp;&nbsp;
            <b>Phone Verified</b>
        </div>
        <input type=""hidden"" name=""can_add_member"" value=""1"" />
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
            BeginContext(2929, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 90 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
 if (family.Count > 0)
{

#line default
#line hidden
            BeginContext(2960, 21, true);
            WriteLiteral("    <h3>Family</h3>\r\n");
            EndContext();
            BeginContext(2983, 291, true);
            WriteLiteral(@"    <table class=""table table-bordered table-success table-striped"">
        <thead>
            <tr>
                <th>Picture</th>
                <th>Name</th>
                <th>Phone</th>
                <th>Relation</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 104 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
              
                foreach (var x in family)
                {

#line default
#line hidden
            BeginContext(3352, 68, true);
            WriteLiteral("            <tr>\r\n                <td style=\"text-align: center;\">\r\n");
            EndContext();
#line 109 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
                     if (x.values["profile_pic_url"].ToString().CompareTo("") != 0)
                    {

#line default
#line hidden
            BeginContext(3528, 28, true);
            WriteLiteral("                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3556, "\"", 3601, 1);
#line 111 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
WriteAttributeValue("", 3562, x.values["profile_pic_url"].ToString(), 3562, 39, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3602, 26, true);
            WriteLiteral(" style=\"width: 80px;\" />\r\n");
            EndContext();
#line 112 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
                    }

#line default
#line hidden
            BeginContext(3651, 43, true);
            WriteLiteral("                </td>\r\n                <td>");
            EndContext();
            BeginContext(3695, 27, false);
#line 114 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
               Write(x.values["name"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3722, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(3750, 35, false);
#line 115 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
               Write(x.values["phone_number"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3785, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(3813, 41, false);
#line 116 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
               Write(x.values["relation"].ToString().ToUpper());

#line default
#line hidden
            EndContext();
            BeginContext(3854, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 118 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
                }
            

#line default
#line hidden
            BeginContext(3914, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 122 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\User.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.UserModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UserModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.UserModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.UserModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
