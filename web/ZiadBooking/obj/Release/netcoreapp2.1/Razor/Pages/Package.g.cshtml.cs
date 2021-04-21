#pragma checksum "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2b93e6cf0e2a78863897eee99272afa9ec92bf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZiadBooking.Pages.Pages_Package), @"mvc.1.0.razor-page", @"/Pages/Package.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Package.cshtml", typeof(ZiadBooking.Pages.Pages_Package), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2b93e6cf0e2a78863897eee99272afa9ec92bf6", @"/Pages/Package.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6716a9fd0c64556a91912705e32a3fedc0bc29", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Package : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
  
    ViewData["Title"] = "Package";

#line default
#line hidden
            BeginContext(89, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
  
    if (ViewData["Message"] != null)
    {

#line default
#line hidden
            BeginContext(140, 45, true);
            WriteLiteral("        <div class=\"error-msg\">\r\n            ");
            EndContext();
            BeginContext(186, 30, false);
#line 11 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
       Write(ViewData["Message"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(216, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 13 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
    }

#line default
#line hidden
            BeginContext(244, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
  
    List<Models.BookingService> services = (List<Models.BookingService>)ViewData["Services"];
    if (services == null)
    {
        services = new List<Models.BookingService>();
    }

    List<Models.PackageService> packageServices = (List<Models.PackageService>)ViewData["PackageServices"];
    if (packageServices == null)
    {
        packageServices = new List<Models.PackageService>();
    }

    Models.Package package = null;
    if (ViewData["Package"] != null)
    {
        package = (Models.Package)ViewData["Package"];
    }

    string[] months = new string[36];
    for (int a = 1; a <= 36; a++)
    {
        months[a - 1] = a.ToString();
    }

#line default
#line hidden
            BeginContext(940, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 42 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
 if (package != null)
{

#line default
#line hidden
            BeginContext(968, 27, true);
            WriteLiteral("    <h2>Edit Package</h2>\r\n");
            EndContext();
#line 45 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1007, 30, true);
            WriteLiteral("    <h2>Add New Package</h2>\r\n");
            EndContext();
#line 49 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
}

#line default
#line hidden
            BeginContext(1040, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(1046, 5526, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61b0caac8e26425fb822e3dad9ed0a93", async() => {
                BeginContext(1096, 210, true);
                WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Title</b>\r\n                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"title\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1306, "\"", 1347, 1);
#line 55 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 1314, package==null?"":package.Title, 1314, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1348, 217, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Location</b>\r\n                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"location_text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1565, "\"", 1619, 1);
#line 59 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 1573, package == null ? "" : package.LocationText, 1573, 46, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1620, 212, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Latitude</b>\r\n                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"latitude\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1832, "\"", 1882, 1);
#line 63 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 1840, package == null ? "" : package.Latitude, 1840, 42, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1883, 214, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Longitude</b>\r\n                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"longitude\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2097, "\"", 2148, 1);
#line 67 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 2105, package == null ? "" : package.Longitude, 2105, 43, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2149, 254, true);
                WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"row\" style=\"margin-top: 15px;\">\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Duration</b>\r\n                <select class=\"form-control\" name=\"duration\">\r\n");
                EndContext();
#line 74 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                       foreach (var m in months)
                        {
                            string sel = "";
                            if (package != null && m.CompareTo(package.NumMonths) == 0)
                            {
                                sel = "SELECTED";
                            }
                            if (sel == "")
                            {

#line default
#line hidden
                BeginContext(2803, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(2835, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30e965564a2445298110a3036c88f01f", async() => {
                    BeginContext(2855, 1, false);
#line 83 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                              Write(m);

#line default
#line hidden
                    EndContext();
                    BeginContext(2856, 9, true);
                    WriteLiteral(" month(s)");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 83 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                   WriteLiteral(m);

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
                BeginContext(2874, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 84 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                            }
                            else
                            {

#line default
#line hidden
                BeginContext(2972, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(3004, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc10f2a8b1eb49779cb8cf263268a017", async() => {
                    BeginContext(3033, 1, false);
#line 87 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                                       Write(m);

#line default
#line hidden
                    EndContext();
                    BeginContext(3034, 9, true);
                    WriteLiteral(" month(s)");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 87 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                   WriteLiteral(m);

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
                BeginContext(3052, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 88 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                            }
                        }
                    

#line default
#line hidden
                BeginContext(3135, 210, true);
                WriteLiteral("                </select>\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12\">\r\n                <b>Amount</b>\r\n                <input type=\"tel\" class=\"form-control\" name=\"amount\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3345, "\"", 3387, 1);
#line 95 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 3353, package==null?"":package.Amount, 3353, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3388, 293, true);
                WriteLiteral(@" />
            </div>
        </div>
        <div class=""row"" style=""margin-top: 15px;"">
            <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-12"">
                <b>Image (JPG or PNG image. 600px width is recommended)</b>
                <input type=""file"" name=""profile_pic"" />
");
                EndContext();
#line 102 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                 if (package != null && package.ImageUrl != "")
                {

#line default
#line hidden
                BeginContext(3765, 71, true);
                WriteLiteral("                    <span>&nbsp;&nbsp;</span>\r\n                    <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 3836, "\"", 3859, 1);
#line 105 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 3842, package.ImageUrl, 3842, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3860, 26, true);
                WriteLiteral(" style=\"width: 60px;\" />\r\n");
                EndContext();
#line 106 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                }

#line default
#line hidden
                BeginContext(3905, 212, true);
                WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"row\" style=\"margin-top: 15px;\">\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12\">\r\n                <b>Featured</b>\r\n                <div>\r\n");
                EndContext();
#line 113 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                       
                        string fsel = "";
                        if (package != null)
                        {
                            if (package.Featured.CompareTo("1") == 0)
                            {
                                fsel = " SELECTED";
                            }
                        }
                        if (fsel == "")
                        {

#line default
#line hidden
                BeginContext(4539, 81, true);
                WriteLiteral("                            <input type=\"checkbox\" name=\"featured\" value=\"1\" />\r\n");
                EndContext();
#line 125 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(4704, 99, true);
                WriteLiteral("                            <input type=\"checkbox\" name=\"featured\" value=\"1\" checked=\"checked\" />\r\n");
                EndContext();
#line 129 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                        }
                    

#line default
#line hidden
                BeginContext(4853, 238, true);
                WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\" style=\"margin-top: 15px;\">\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12\">\r\n                <b>Service(s)</b>\r\n                <div>\r\n");
                EndContext();
#line 138 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                       foreach (var m in services)
                        {
                            string sel = "";
                            if (package != null)
                            {
                                for (int x = 0; x < packageServices.Count; x++)
                                {
                                    if (packageServices[x].ServiceId.CompareTo(m.Id) == 0)
                                    {
                                        sel = "SELECTED";
                                        break;
                                    }
                                }
                            }
                            if (sel == "")
                            {

#line default
#line hidden
                BeginContext(5831, 71, true);
                WriteLiteral("                                <input type=\"checkbox\" name=\"service[]\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5902, "\"", 5915, 1);
#line 154 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 5910, m.Id, 5910, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5916, 4, true);
                WriteLiteral(" /> ");
                EndContext();
                BeginContext(5921, 6, false);
#line 154 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                                                                    Write(m.Name);

#line default
#line hidden
                EndContext();
#line 154 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                                                                                
                            }
                            else
                            {

#line default
#line hidden
                BeginContext(6025, 71, true);
                WriteLiteral("                                <input type=\"checkbox\" name=\"service[]\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6096, "\"", 6109, 1);
#line 158 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
WriteAttributeValue("", 6104, m.Id, 6104, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6110, 22, true);
                WriteLiteral(" checked=\"checked\" /> ");
                EndContext();
                BeginContext(6133, 6, false);
#line 158 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                                                                                      Write(m.Name);

#line default
#line hidden
                EndContext();
#line 158 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                                                                                                                  
                            }

#line default
#line hidden
                BeginContext(6172, 36, true);
                WriteLiteral("                            <br />\r\n");
                EndContext();
#line 161 "D:\PROJECTS\DotNotCore\ZiadBooking\web\ZiadBooking\Pages\Package.cshtml"
                        }
                    

#line default
#line hidden
                BeginContext(6258, 307, true);
                WriteLiteral(@"                </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZiadBooking.Pages.PackageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.PackageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZiadBooking.Pages.PackageModel>)PageContext?.ViewData;
        public ZiadBooking.Pages.PackageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
