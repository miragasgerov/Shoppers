#pragma checksum "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\Account\profileDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0b111cb24ce202ab7c797d8555905043c0e9c58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_profileDetail), @"mvc.1.0.view", @"/Views/Account/profileDetail.cshtml")]
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
#line 1 "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\_ViewImports.cshtml"
using Shoppers_BackEnd_Final;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\_ViewImports.cshtml"
using Shoppers_BackEnd_Final.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\_ViewImports.cshtml"
using Shoppers_BackEnd_Final.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0b111cb24ce202ab7c797d8555905043c0e9c58", @"/Views/Account/profileDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62053d88b14f909c0512b8e58fbdbaafa14708bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_profileDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("heroBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/cloth1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/cloth3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/cloth4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\Account\profileDetail.cshtml"
  
    ViewData["Title"] = "profileDetail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <section class=""breadCrumb"">
        <div class=""container"">
            <div class=""row"">
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb mt-3"">
                        <li class=""breadcrumb-item active""><a href=""#"">Home</a></li>
                        <li class=""breadcrumb-item"" aria-current=""page"">Profile</li>
                    </ol>
                </nav>
            </div>
        </div>
    </section>

    <section class=""profile-detail"">
        <div class=""container"">
            <div class=""row"">
                <section class=""blok"">
                    <div class=""blok-body"">
                        <!-- Nav tabs -->
                        <ul class=""nav tab-menu nav-pills col-sm-3 nav-stacked pr15"">
                            <li class=""active"" data-toggle=""tab""><a href=""#accountDetail"">Account Detail</a></li>
                            <li><a href=""#cartInfo"" data-toggle=""tab"">Cart</a></li>
                         ");
            WriteLiteral("   <li><a href=\"#wishlist\" data-toggle=\"tab\">Wishlist</a></li>\r\n                            <li>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0b111cb24ce202ab7c797d8555905043c0e9c587747", async() => {
                WriteLiteral("Log out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                        </ul>
                        <!-- Tab panes -->
                        <div class=""tab-content col-sm-9"">
                            <div class=""tab-pane well active in active"" id=""accountDetail"">
                                ");
#nullable restore
#line 37 "C:\Users\sfarh\Desktop\Shoppers-BackEnd-Final\Shoppers-BackEnd-Final\Views\Account\profileDetail.cshtml"
                           Write(await Html.PartialAsync("_MemberUpdateFormPartial",Model.Member));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 
                            </div>
                            <div class=""tab-pane well fade"" id=""cartInfo"">
                                <div class=""row"">
                                    <div class=""col-lg-12"">
                                        <table class=""table"">
                                            <thead>
                                            <th>Image</th>
                                            <th>Product</th>
                                            <th>Price</th>
                                            <th>Quantity</th>
                                            <th>Total</th>
                                            <th>Remove</th>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td data-label=""Image"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0b111cb24ce202ab7c797d8555905043c0e9c5810933", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </td>
                                                    <td data-label=""Product"">Top Up T-Shirt</td>
                                                    <td data-label=""Price"">$49.00</td>
                                                    <td data-label=""Quantity"">
                                                        <div class=""number"" style=""margin: 0px !important;"">
                                                            <span class=""minus"">-</span>
                                                            <input type=""text"" value=""1"" />
                                                            <span class=""plus"">+</span>
                                                        </div>
                                                    </td>
                                                    <td data-label=""Total"">$49.00</td>
                                                    <td data-label=""Remove"">
                          ");
            WriteLiteral(@"                              <button type=""button"" class=""heroBtn"" style=""width: 4rem;"">X</button>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td data-label=""Image"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0b111cb24ce202ab7c797d8555905043c0e9c5813535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </td>
                                                    <td data-label=""Product"">Top Up T-Shirt</td>
                                                    <td data-label=""Price"">$49.00</td>
                                                    <td data-label=""Quantity"">
                                                        <div class=""number"" style=""margin: 0px !important;"">
                                                            <span class=""minus"">-</span>
                                                            <input type=""text"" value=""1"" />
                                                            <span class=""plus"">+</span>
                                                        </div>
                                                    </td>
                                                    <td data-label=""Total"">$49.00</td>
                                                    <td data-label=""Remove"">
                          ");
            WriteLiteral(@"                              <button type=""button"" class=""heroBtn"" style=""width: 4rem;"">X</button>
                                                    </td>
                                                </tr>


                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class=""tab-pane well fade"" id=""wishlist"">

                                <div class=""row"">
                                    <div class=""col-lg-12"">
                                        <table class=""table"">
                                            <thead>
                                            <th>Image</th>
                                            <th>Product</th>
                                            <th>Price</th>
                                            <th>Add Cart</th>
                              ");
            WriteLiteral(@"              <th>Remove</th>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td data-label=""Image"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0b111cb24ce202ab7c797d8555905043c0e9c5817124", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </td>
                                                    <td data-label=""Product"">Top Up T-Shirt</td>
                                                    <td data-label=""Price"">$49.00</td>
                                                    <td data-label=""Add Cart"">
                                                        <button type=""button"" class=""heroBtn"">Add To Cart</button>
                                                    </td>
                                                    <td data-label=""Remove"">
                                                        <button type=""button"" class=""heroBtn"" style=""width: 4rem;"">X</button>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td data-label=""Image"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e0b111cb24ce202ab7c797d8555905043c0e9c5819266", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </td>
                                                    <td data-label=""Product"">Top Up T-Shirt</td>
                                                    <td data-label=""Price"">$49.00</td>
                                                    <td data-label=""Add Cart""><button type=""button"" class=""heroBtn"">Add To Cart</button>
                                                    <td data-label=""Remove"">
                                                        <button type=""button"" class=""heroBtn"" style=""width: 4rem;"">X</button>
                                                    </td>
                                                </tr>


                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                            </div>



                        </div>
                    </div><!-- blok-body // -->
   ");
            WriteLiteral("             </section><!-- // blok -->\r\n            </div>\r\n        </div>\r\n\r\n    </section>\r\n\r\n\r\n\r\n    <hr>\r\n\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591