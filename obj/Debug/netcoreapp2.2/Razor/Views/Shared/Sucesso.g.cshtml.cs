#pragma checksum "C:\Users\50539955833\Documents\role-topMVC\Views\Shared\Sucesso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c89ecb186e0b6b61a9c1a27036da573e1caa76a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Sucesso), @"mvc.1.0.view", @"/Views/Shared/Sucesso.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Sucesso.cshtml", typeof(AspNetCore.Views_Shared_Sucesso))]
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
#line 1 "C:\Users\50539955833\Documents\role-topMVC\Views\_ViewImports.cshtml"
using role_topMVC;

#line default
#line hidden
#line 2 "C:\Users\50539955833\Documents\role-topMVC\Views\_ViewImports.cshtml"
using role_topMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c89ecb186e0b6b61a9c1a27036da573e1caa76a", @"/Views/Shared/Sucesso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8132c2e51da378f0c159a33ac96c7c339f0fb8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Sucesso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<role_topMVC.ViewModels.RespostaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 28, true);
            WriteLiteral("\r\n<main>\r\n    <h2>\r\n        ");
            EndContext();
            BeginContext(78, 14, false);
#line 5 "C:\Users\50539955833\Documents\role-topMVC\Views\Shared\Sucesso.cshtml"
   Write(Model.NomeView);

#line default
#line hidden
            EndContext();
            BeginContext(92, 29, true);
            WriteLiteral(" deu bom !\r\n    <h2>\r\n    <p>");
            EndContext();
            BeginContext(122, 14, false);
#line 7 "C:\Users\50539955833\Documents\role-topMVC\Views\Shared\Sucesso.cshtml"
  Write(Model.Mensagem);

#line default
#line hidden
            EndContext();
            BeginContext(136, 11, true);
            WriteLiteral("<p>\r\n<main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<role_topMVC.ViewModels.RespostaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591