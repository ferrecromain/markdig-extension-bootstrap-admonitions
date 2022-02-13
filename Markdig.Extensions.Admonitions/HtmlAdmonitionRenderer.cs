using Markdig.Renderers;
using Markdig.Renderers.Html;
using System.Resources;

namespace Markdig.Extensions.Admonition
{
    public class HtmlAdmonitionRenderer : HtmlObjectRenderer<Admonition>
    {
        protected override void Write(HtmlRenderer renderer, Admonition obj)
        {
            HtmlAttributes? attributes = obj.TryGetAttributes();
            if (attributes != null)
            {
                List<string>? classes = attributes.Classes;
                if (classes != null && classes.Any())
                {
                    renderer.EnsureLine();
                    if (renderer.EnableHtmlForBlock)
                    {
                        string bsAlertType = string.Empty;
                        string bsIconType = string.Empty;
                        string bsAlertHeading = string.Empty;

                        string admonitionType = classes.Single().ToLower();

                        if (admonitionType == "tip")
                        {
                            bsAlertType = "success";
                            bsIconType = "lightbuld";
                            bsAlertHeading = "Astuce";
                        }
                        else if (admonitionType == "note")
                        {
                            bsAlertType = "info";
                            bsIconType = "info-circle-fill";
                            bsAlertHeading = "Note";
                        }
                        else if(admonitionType == "danger")
                        {
                            bsAlertType = "danger";
                            bsIconType = "x-circle-fill";
                            bsAlertHeading = "Attention";
                        }
                        else if(admonitionType == "warning")
                        {
                            bsAlertType = "warning";
                            bsIconType = "exclamation-triangle-fill";
                            bsAlertHeading = "Avertissement";
                        }

                        renderer.Write($"<div class=\"alert alert-{bsAlertType}\" role=\"alert\">");
                        renderer.Write($"<p class=\"alert-heading\"><i class=\"bi bi-{bsIconType}\"></i><strong> {bsAlertHeading}</strong></p>");
                    }

                    HtmlAttributes lastChildAttributes = new HtmlAttributes();
                    lastChildAttributes.AddClass("mb-0");

                    obj.Last().SetAttributes(lastChildAttributes);
                    renderer.WriteChildren(obj);

                    if (renderer.EnableHtmlForBlock)
                    {
                        renderer.WriteLine("</div>");
                    }
                }
            }
        }
    }
}
