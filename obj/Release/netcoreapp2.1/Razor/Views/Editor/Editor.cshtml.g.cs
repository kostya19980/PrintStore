#pragma checksum "D:\Diplom\PrintStore\Views\Editor\Editor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2c2a8ad850715d5d39df42146782502cd01f75b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Editor_Editor), @"mvc.1.0.view", @"/Views/Editor/Editor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Editor/Editor.cshtml", typeof(AspNetCore.Views_Editor_Editor))]
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
#line 1 "D:\Diplom\PrintStore\Views\_ViewImports.cshtml"
using PrintStore;

#line default
#line hidden
#line 2 "D:\Diplom\PrintStore\Views\_ViewImports.cshtml"
using PrintStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2c2a8ad850715d5d39df42146782502cd01f75b", @"/Views/Editor/Editor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70f983ffae960d41f9afeb306e0a10f6e766ec90", @"/Views/_ViewImports.cshtml")]
    public class Views_Editor_Editor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/EditorStyles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Shrifts/Roboto/roboto.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Diplom\PrintStore\Views\Editor\Editor.cshtml"
  
    ViewData["Title"] = "Editor";

#line default
#line hidden
            BeginContext(44, 178, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4544a95eb524b6f9d2fbb2a0b1d4380", async() => {
                BeginContext(79, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(85, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b23162a003847a892d4724b41a8e6f5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(140, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(146, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9408dbd5f1394f588f1910ddc703b504", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(206, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(222, 5157, true);
            WriteLiteral(@"
<div class=""editor_block"">
    <div class=""editor_toolbar"">
        <div class=""main_toolbar_buttons"">
            <button class=""toolbar_button"">
                <svg width=""25"" height=""24"" viewBox=""0 0 25 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M14.5 3V8H19.5M14.5 3H7.5C6.96957 3 6.46086 3.21071 6.08579 3.58579C5.71071 3.96086 5.5 4.46957 5.5 5V19C5.5 19.5304 5.71071 20.0391 6.08579 20.4142C6.46086 20.7893 6.96957 21 7.5 21H17.5C18.0304 21 18.5391 20.7893 18.9142 20.4142C19.2893 20.0391 19.5 19.5304 19.5 19V8M14.5 3L19.5 8M9.5 15L11.5 17L15.5 13"" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                </svg>
                Сохранить
            </button>
            <button class=""toolbar_button"">
                <svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M5 9L9 13V5L5 9ZM5 9H16C17.0609 9 18.0783 9.42143 18.8284 10.1716C19.5786 1");
            WriteLiteral(@"0.9217 20 11.9391 20 13C20 14.0609 19.5786 15.0783 18.8284 15.8284C18.0783 16.5786 17.0609 17 16 17H15"" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                    <path d=""M5 9L9 5V13L5 9Z"" fill=""white"" />
                </svg>
                Отменить
            </button>
            <button class=""toolbar_button"">
                <svg width=""25"" height=""24"" viewBox=""0 0 25 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M19.5 9H8.5C7.43913 9 6.42172 9.42143 5.67157 10.1716C4.92143 10.9217 4.5 11.9391 4.5 13C4.5 14.0609 4.92143 15.0783 5.67157 15.8284C6.42172 16.5786 7.43913 17 8.5 17H9.5M15.5 13L19.5 9L15.5 5V13Z"" stroke=""#B4B5BD"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                    <path d=""M15.5 5L19.5 9L15.5 13V5Z"" fill=""#B4B5BD"" />
                </svg>
                Вернуть
            </button>
            <button class=""toolbar_button"">
                <svg xmlns=""http:/");
            WriteLiteral(@"/www.w3.org/2000/svg"" width=""32.67346938775512"" height=""22.489795918367342"" fill=""none"" style="""">
                    <rect id=""backgroundrect"" width=""100%"" height=""100%"" x=""0"" y=""0"" fill=""none"" stroke=""none"" class="""" style="""" />
                    <path d=""M12.831632651388645,3.8520408868789673 H2.831632651388645 C1.7270626513886453,3.8520408868789673 0.8316326513886454,4.7474708868789675 0.8316326513886454,5.852040886878967 V7.852040886878967 C0.8316326513886454,8.956610886878968 1.7270626513886453,9.852040886878967 2.831632651388645,9.852040886878967 H12.831632651388645 C13.936232651388647,9.852040886878967 14.831632651388645,8.956610886878968 14.831632651388645,7.852040886878967 V5.852040886878967 C14.831632651388645,4.7474708868789675 13.936232651388647,3.8520408868789673 12.831632651388645,3.8520408868789673 z"" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" id=""svg_1"" class="""" />
                    <path d=""M14.831632651388645,6.852040886878967 H15.831632651388645 ");
            WriteLiteral(@"C16.362032651388645,6.852040886878967 16.870732651388646,7.062750886878967 17.245832651388646,7.4378308868789675 C17.620932651388646,7.8129008868789676 17.831632651388645,8.321610886878968 17.831632651388645,8.852040886878967 C17.831632651388645,10.178120886878967 17.304832651388644,11.449940886878966 16.367132651388644,12.387540886878968 C15.429532651388644,13.325240886878968 14.157732651388645,13.852040886878967 12.831632651388645,13.852040886878967 H7.831632651388645 V15.852040886878967 "" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" id=""svg_2"" class="""" />
                    <path d=""M8.831632651388645,15.852040886878967 H6.831632651388645 C6.2793326513886445,15.852040886878967 5.831632651388645,16.299740886878965 5.831632651388645,16.852040886878967 V20.852040886878967 C5.831632651388645,21.404340886878966 6.2793326513886445,21.852040886878967 6.831632651388645,21.852040886878967 H8.831632651388645 C9.383932651388646,21.852040886878967 9.831632651388645,21.404340886878");
            WriteLiteral(@"966 9.831632651388645,20.852040886878967 V16.852040886878967 C9.831632651388645,16.299740886878965 9.383932651388646,15.852040886878967 8.831632651388645,15.852040886878967 z"" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" id=""svg_3"" class="""" />
                    <rect fill="""" stroke=""white"" stroke-width=""1.5"" stroke-linejoin=""round"" stroke-linecap=""round"" stroke-dashoffset="""" fill-rule=""nonzero"" id=""svg_4"" x=""21.714285768568516"" y=""0.9387755021452904"" width=""10"" height=""10"" style=""color: rgb(0, 0, 0);"" class="""" />
                </svg>
                Фон
            </button>
            <button class=""toolbar_button"">
                <svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M18.8984 5.84766H13.6719V20.0625H10.1562V5.84766H5V3H18.8984V5.84766Z"" fill=""white"" />
                </svg>
                Текст
            </button>
        </div>
        <div class=""font_select"">
 ");
            WriteLiteral("           <select>\r\n                ");
            EndContext();
            BeginContext(5379, 23, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccd71314f5034dfe9f274cb9f1d98869", async() => {
                BeginContext(5387, 6, true);
                WriteLiteral("Roboto");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5402, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(5420, 22, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfe956a0dcf44ac583a8100fd016bf09", async() => {
                BeginContext(5428, 5, true);
                WriteLiteral("Arial");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5442, 114, true);
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <div class=\"font_select\">\r\n            <select>\r\n                ");
            EndContext();
            BeginContext(5556, 23, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11c93c2694b84f0ea7923dd28cfc2db1", async() => {
                BeginContext(5564, 6, true);
                WriteLiteral("Roboto");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5579, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(5597, 22, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4787ea5d4c644748b51f657be7d16b58", async() => {
                BeginContext(5605, 5, true);
                WriteLiteral("Arial");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5619, 160, true);
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <div class=\"text_tools\">\r\n            <div class=\"font_select\">\r\n                <select>\r\n                    ");
            EndContext();
            BeginContext(5779, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e638c28370f412e9715f45ea5529d21", async() => {
                BeginContext(5787, 2, true);
                WriteLiteral("16");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5798, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(5820, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dbbfa7d56a84a98afab53738ecd53a1", async() => {
                BeginContext(5828, 2, true);
                WriteLiteral("14");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5839, 6009, true);
            WriteLiteral(@"
                </select>
            </div>
            <button class=""text_tools_button"">
                <svg width=""18"" height=""18"" viewBox=""0 0 18 18"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M12.1223 17.1415L12.228 17.5H12.6018H16.3412H17.0286L16.8169 16.846L11.6367 0.84599L11.5247 0.5H11.161H7.16862H6.8047L6.69283 0.846301L1.52421 16.8463L1.31304 17.5H2H5.73931H6.11442L6.21935 17.1399L7.0159 14.4061H11.3151L12.1223 17.1415ZM9.16089 6.98986L10.1949 10.489H8.13369L9.16089 6.98986Z"" fill=""white"" stroke=""#DEDFE3"" />
                </svg>
            </button>
            <div class=""text_decoration_block"">
                <button class=""text_tools_button"">
                    <svg width=""13"" height=""16"" viewBox=""0 0 12 16"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M0 16V0H5.49457C7.47972 0 9.02931 0.368169 10.1429 1.10442C11.2563 1.84058 11.8132 2.93777 11.8132 4.39562C11.8132 5.15763 11.6338 5.83496 11.2748 6.42867C10.");
            WriteLiteral(@"9158 7.0222 10.3627 7.46905 9.61535 7.7693C10.5531 7.9817 11.2453 8.40843 11.6923 9.04951C12.139 9.69059 12.3627 10.4288 12.3627 11.2638C12.3627 12.8243 11.8388 14.0038 10.7914 14.8022C9.7436 15.6009 8.2419 16 6.28569 16H0ZM3.72535 6.67035H5.57149C6.41394 6.65571 7.04408 6.4927 7.46173 6.18125C7.87929 5.86997 8.08816 5.41395 8.08816 4.81319C8.08816 4.1318 7.87559 3.63565 7.45088 3.32419C7.02573 3.01292 6.3738 2.85715 5.49466 2.85715H3.72535V6.67035ZM3.72535 9.13198V13.1429H6.28569C7.07698 13.1429 7.67042 12.9872 8.06602 12.6757C8.46153 12.3644 8.65956 11.8865 8.65956 11.2419C8.65956 10.5458 8.48914 10.0202 8.14841 9.66483C7.80785 9.30963 7.25656 9.13198 6.49473 9.13198H3.72535Z"" fill=""#20222D"" />
                    </svg>
                </button>
                <button class=""text_tools_button"">
                    <svg width=""7"" height=""16"" viewBox=""0 0 7 16"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M3.65946 16H0L3.19788 0H6.85734L3.65946 16Z"" fill=""#20222D"" />");
            WriteLiteral(@"
                    </svg>
                </button>
                <button class=""text_tools_button"">
                    <svg width=""16"" height=""16"" viewBox=""0 0 16 16"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M4.28786 11.4202C5.23381 12.201 6.48744 12.5913 8.03186 12.5913C9.55917 12.5913 10.7921 12.201 11.7354 11.4202C12.6785 10.6394 13.1478 9.53948 13.1478 8.12042V0H10.2261V8.12042C10.2261 8.88981 10.0521 9.4569 9.66748 9.82157C9.28285 10.1864 8.74337 10.3686 8.03102 10.3686C7.31297 10.3686 6.75715 10.1848 6.36389 9.81725C5.97071 9.44981 5.77391 8.88424 5.77391 8.12042V0H2.85217V8.12042C2.85217 9.53948 3.34184 10.6394 4.28786 11.4202Z"" fill=""#20222D"" />
                        <path d=""M16 13.7043H0V16H16V13.7043Z"" fill=""#20222D"" />
                    </svg>
                </button>
                <button class=""text_tools_button"" style=""margin-left:12px;"">
                    <svg width=""18"" height=""14"" viewBox=""0 0 18 14"" fill=""none"" xmlns=""http://w");
            WriteLiteral(@"ww.w3.org/2000/svg"">
                        <path d=""M1 1H17M1 7H11M1 13H15"" stroke=""#20222D"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                    </svg>
                </button>
                <button class=""text_tools_button"">
                    <svg width=""18"" height=""14"" viewBox=""0 0 18 14"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M1 1H17M5 7H13M3 13H15"" stroke=""#20222D"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                    </svg>
                </button>
                <button class=""text_tools_button"">
                    <svg width=""18"" height=""14"" viewBox=""0 0 18 14"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M1 1H17M7 7H17M3 13H17"" stroke=""#20222D"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" />
                    </svg>
                </button>
            </div>
        </div>
        <button class=""full_screen_bu");
            WriteLiteral(@"tton"">
            <svg width=""18"" height=""18"" viewBox=""0 0 18 18"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"" style=""z-index:2"">
                <path d=""M13 1H17M17 1V5M17 1L11 7M5 17H1M1 17V13M1 17L7 11M13 17H17M17 17V13M17 17L11 11M5 1H1M1 1V5M1 1L7 7"" stroke=""white"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
            </svg>
        </button>
    </div>
    <div class=""image_items"">
        <div class=""add_image_button"">
            <svg width=""46"" height=""46"" viewBox=""0 0 46 46"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                <path d=""M15.0001 23H31.0001M23.0001 15V31M7.00008 1.66663H39.0001C41.9456 1.66663 44.3334 4.05444 44.3334 6.99996V39C44.3334 41.9455 41.9456 44.3333 39.0001 44.3333H7.00008C4.05456 44.3333 1.66675 41.9455 1.66675 39V6.99996C1.66675 4.05444 4.05456 1.66663 7.00008 1.66663Z"" stroke=""white"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" />
            </svg>
            <label class=""upload_label"" for=""uploadI");
            WriteLiteral(@"mage""></label>
            <input type=""file"" id=""uploadImage"" style=""visibility:hidden;"" />
        </div>
        <button id=""arrow_back"" class=""arrow_image_list"" style=""left: 96px;"">
            <svg width=""8"" height=""14"" viewBox=""0 0 8 14"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                <path d=""M7 1L1 7L7 13"" stroke=""#494C57"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
            </svg>
        </button>
        <div class=""image_list"">

        </div>
        <button id=""arrow_forward"" class=""arrow_image_list"" style=""right: 16px;"">
            <svg width=""8"" height=""14"" viewBox=""0 0 8 14"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                <path d=""M1 1L7 7L1 13"" stroke=""#494C57"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" />
            </svg>
        </button>
    </div>
</div>");
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