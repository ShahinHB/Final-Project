#pragma checksum "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3065b6af5cd03aec48da0641c795b9d4e1876ef4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3065b6af5cd03aec48da0641c795b9d4e1876ef4", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00630510a69c62db4e186dce360504dace6c5285", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""page-title"">
    <h1>
        Contact Us
    </h1>
</section>
<section id=""contact"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-10"">
                <div class=""form"">
                    <div class=""row"">
                        <div class=""col-4"">
                            <div class=""title"">
                                <h2>
                                    Ask Us <br> Anything!
                                </h2>
                            </div>
                        </div>
                        <div class=""col-8"">
                            <div class=""content"">
                                <input type=""text"" placeholder=""Name"">
                                <input type=""email"" placeholder=""Email"">
                                <textarea rows=""10"" placeholder=""Type your message here...""></textarea>
                            </div>
                        </div>
                    </div>
            ");
            WriteLiteral(@"    </div>
                <div class=""map"">
                    <div class=""row"">
                        <div class=""col-4"">
                            <div class=""title"">
                                <h2>
                                    How to <br> Get Here
                                </h2>
                                <div class=""seperator"">
                                    <div></div>
                                </div>
                                <p>
                                    R. Frame de Morá
                                    <br>
                                    Floor 6
                                    <br>
                                    Rio de Janeiro - Ipanema
                                    <br>
                                    Cell: 123-456-7890
                                </p>
                            </div>
                        </div>
                        <div class=""col-8"">
                            <div");
            WriteLiteral(@" class=""content"">
                                <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d24307.49426733976!2d49.9474266!3d40.399173700000006!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4030630f12a08785%3A0x71f2cb035667ccb4!2sLachin%20Shopping%20Mall!5e0!3m2!1sen!2s!4v1643664176360!5m2!1sen!2s"" style=""border:0; width: 100%; height: 100%;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2465, "\"", 2483, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"></iframe>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
