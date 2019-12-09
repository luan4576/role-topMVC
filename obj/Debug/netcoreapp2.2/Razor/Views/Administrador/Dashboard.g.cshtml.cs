#pragma checksum "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b43a1cde40cb378aceca42ee922d81da7a7d2f36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_Dashboard), @"mvc.1.0.view", @"/Views/Administrador/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrador/Dashboard.cshtml", typeof(AspNetCore.Views_Administrador_Dashboard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b43a1cde40cb378aceca42ee922d81da7a7d2f36", @"/Views/Administrador/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8132c2e51da378f0c159a33ac96c7c339f0fb8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 284, true);
            WriteLiteral(@"<main>
        <h2>aprovar recusar eventos</h2>
        <section id=""status-pedidos"">
            <h3>Status dos eventos</h3>
            <div id=""painel"">
                <div class=""box-status-pedidos aprovados"">
                    <h4>Aprovados</h4>
                    <p>");
            EndContext();
            BeginContext(285, 22, false);
#line 8 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                  Write(Model.PacotesAprovados);

#line default
#line hidden
            EndContext();
            BeginContext(307, 153, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"box-status-pedidos pendentes\">\r\n                    <h4>Pendentes</h4>\r\n                    <p>");
            EndContext();
            BeginContext(461, 22, false);
#line 12 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                  Write(Model.PacotesPendentes);

#line default
#line hidden
            EndContext();
            BeginContext(483, 155, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"box-status-pedidos reprovados\">\r\n                    <h4>Reprovados</h4>\r\n                    <p>");
            EndContext();
            BeginContext(639, 23, false);
#line 16 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                  Write(Model.PacotesReprovados);

#line default
#line hidden
            EndContext();
            BeginContext(662, 865, true);
            WriteLiteral(@"</p>
                </div>
            </div>
        </section>

        <section id=""lista-contratos"">
            <h3>Lista de contratos</h3>
            <table>
                <thead>
                    <tr>
                        <th rowspan=""2"">Nome</th>
                        <th rowspan=""2"">cpf</th>
                        <th colspan=""2"">dia do evento</th>
                        <th colspan=""2"" rowspan=""2"">Aprovar</th>
                    </tr>

                    <tr>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                
                </thead>
                <tfoot>
                    <tr>
                        <td colspan=""6"">
                            <p>Pedidos atualizados em ");
            EndContext();
            BeginContext(1528, 12, false);
#line 43 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                                                 Write(DateTime.Now);

#line default
#line hidden
            EndContext();
            BeginContext(1540, 115, true);
            WriteLiteral("</p>\r\n                        </td>\r\n                    </tr>\r\n                </tfoot>\r\n                <tbody>\r\n");
            EndContext();
#line 48 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                     foreach (var pacote in Model.pacotes)
                    {

#line default
#line hidden
            BeginContext(1738, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1801, 19, false);
#line 51 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                           Write(pacote.Cliente.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1820, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1860, 18, false);
#line 52 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                           Write(pacote.Cliente.Cpf);

#line default
#line hidden
            EndContext();
            BeginContext(1878, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1918, 19, false);
#line 53 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                           Write(pacote.Cliente.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1937, 41, true);
            WriteLiteral("</td>\r\n                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1978, "\'", 2040, 1);
#line 54 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 1985, Url.Action("Aprovar", "Pacote", new {id = @pacote.Id}), 1985, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2041, 74, true);
            WriteLiteral("><i class=\"fas fa-check\"></i></a></td>\r\n                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 2115, "\'", 2178, 1);
#line 55 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 2122, Url.Action("Reprovar", "Pacote", new {id = @pacote.Id}), 2122, 56, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2179, 71, true);
            WriteLiteral("><i class=\"fas fa-times\"></i></a></td>\r\n                        </tr>\r\n");
            EndContext();
#line 57 "C:\Users\50539955833\Documents\role-topMVC\Views\Administrador\Dashboard.cshtml"
                    }

#line default
#line hidden
            BeginContext(2273, 83, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </section>\r\n\r\n    </main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
