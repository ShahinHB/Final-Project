#pragma checksum "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "655bea554dd6948f4ce888aedad7406a709bb5f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Booking_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Booking/Detail.cshtml")]
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
#line 1 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"655bea554dd6948f4ce888aedad7406a709bb5f3", @"/Areas/Admin/Views/Booking/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18d77d765dd548436fe740f9e01b2273614cff44", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Booking_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Reservation>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"display: flex;\">\r\n    <p style=\" margin-right: 20px\">FullName: </p> <span> ");
#nullable restore
#line 8 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                                Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Contact Details: </p> <span> ");
#nullable restore
#line 12 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                           Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 12 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                                        Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Where: </p> <span> ");
#nullable restore
#line 16 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                 Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Between: </p> <span> ");
#nullable restore
#line 21 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                   Write(Model.StartDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 21 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                                                           Write(Model.EndDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Count: </p> <span> ");
#nullable restore
#line 26 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                 Write(Model.AdultsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Adult ");
#nullable restore
#line 26 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                                          Write(Model.KidsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kid</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Special Request: </p> <span> ");
#nullable restore
#line 31 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                           Write(Model.SpecialRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Order Date: </p> <span> ");
#nullable restore
#line 36 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                      Write(Model.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Totally Amount: </p> <span> ");
#nullable restore
#line 41 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                          Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n</div>\r\n\r\n<div style=\"display: flex; margin-right: 20px\">\r\n    <p style=\" margin-right: 20px\">Apartment: </p> <span> ");
#nullable restore
#line 46 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                     Write(Model.Apartment.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("  (ID: ");
#nullable restore
#line 46 "C:\Users\Shahin\Desktop\Final Project\Backend\Hotel\Hotel\Areas\Admin\Views\Booking\Detail.cshtml"
                                                                                  Write(Model.Apartment.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Reservation> Html { get; private set; }
    }
}
#pragma warning restore 1591