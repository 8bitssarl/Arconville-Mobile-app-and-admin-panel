#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ef228ebe4a2cda74c1771f2a9ef854c1fefcddf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_BookingService), @"mvc.1.0.razor-page", @"/Pages/BookingService.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/BookingService.cshtml", typeof(ZiadBooking.Pages.Pages_BookingService), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ef228ebe4a2cda74c1771f2a9ef854c1fefcddf", @"/Pages/BookingService.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_BookingService : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
  
    ViewData["Title"] = "Service";

#line default
#line hidden
            BeginContext(96, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(147, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(193, 30, false);
#line 11 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(223, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 13 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
    }

#line default
#line hidden
            BeginContext(251, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
  
    Models.GenericModel user = null;
    if (ViewData["Service"] != null)
    {
        user = (Models.GenericModel)ViewData["Service"];
    }

#line default
#line hidden
            BeginContext(408, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 24 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
 if (user != null)
{

#line default
#line hidden
            BeginContext(433, 27, true);
            WriteLiteral("    <h2>Edit Service</h2>\r\n");
            EndContext();
#line 27 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(472, 30, true);
            WriteLiteral("    <h2>Add New Service</h2>\r\n");
            EndContext();
#line 31 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
}

#line default
#line hidden
            BeginContext(505, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(511, 1166, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21d18fbae52241849ae710c4e58cd541", async() => {
                BeginContext(561, 189, true);
                WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Name</b>\r\n                <input type=\"text\" class=\"form-control\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 750, "\"", 800, 1);
#line 37 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
WriteAttributeValue("", 758, user == null ? "" : user.values["name"], 758, 42, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(801, 263, true);
                WriteLiteral(@" />
            </div>
            
        </div>
        <div class=""row"" style=""margin-top: 15px;"">
            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                <b>Can Book Online</b>
                <div style=""margin-top: 5px;"">
");
                EndContext();
#line 45 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
                      
                        string checkedStr = (user!=null && user.values["can_book_online"] != null && user.values["can_book_online"].ToString() == "1") ? "checked" : "";
                    

#line default
#line hidden
                BeginContext(1281, 66, true);
                WriteLiteral("                    <input type=\"checkbox\" name=\"can_book_online\" ");
                EndContext();
                BeginContext(1348, 10, false);
#line 48 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\BookingService.cshtml"
                                                             Write(checkedStr);

#line default
#line hidden
                EndContext();
                BeginContext(1358, 312, true);
                WriteLiteral(@" />
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.BookingServiceModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.BookingServiceModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.BookingServiceModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.BookingServiceModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
