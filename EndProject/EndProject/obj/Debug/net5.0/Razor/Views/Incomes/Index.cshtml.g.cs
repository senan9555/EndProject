#pragma checksum "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d22b3f34fc6a3ef51f8fd3144d8afd810417a2d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incomes_Index), @"mvc.1.0.view", @"/Views/Incomes/Index.cshtml")]
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
#line 1 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\_ViewImports.cshtml"
using EndProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\_ViewImports.cshtml"
using EndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\_ViewImports.cshtml"
using EndProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22b3f34fc6a3ef51f8fd3144d8afd810417a2d1", @"/Views/Incomes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"874588e09390a8c3f0993aa143d6556a57f12e4b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Incomes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Income>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btnprimary btn-rounded btn-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-lg-12 grid-margin stretch-card\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n");
            WriteLiteral("                <div class=\"d-flex justify-content-between\">\r\n                    <h4 class=\"card-title\">G??L??RL??R</h4>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d22b3f34fc6a3ef51f8fd3144d8afd810417a2d14675", async() => {
                WriteLiteral("\r\n                        <i class=\"mdi mdi-currency-usd\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""table-responsive pt-3"">
                    <table id=""myServices"" class=""table table-bordered"">
                        <thead>
                            <tr>

                                <th>
                                    G??lir
                                </th>
                                <th>
                                    G??lir Haqq??nda
                                </th>
                                <th>
                                    G??lirin Vaxt??
                                </th>
                                <th>
                                    Qeyd Ed??n ????xs
                                </th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 37 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                             foreach (Income item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 42 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                                   Write(item.Money);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 45 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                                   Write(item.For);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 48 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                                   Write(item.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 51 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                                   Write(item.AppUser?.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\99450\Desktop\EndProject\EndProject\EndProject\Views\Incomes\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"    <script>
        $(document).ready(function () {
            $('#myServices').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });</script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Income>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
