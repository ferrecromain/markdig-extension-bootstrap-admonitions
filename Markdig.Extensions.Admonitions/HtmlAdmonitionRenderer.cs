﻿using Markdig.Renderers;
using Markdig.Renderers.Html;
using System.Resources;

namespace Markdig.Extensions.Admonitions
{
    public class HtmlAdmonitionRenderer : HtmlObjectRenderer<Admonition>
    {
        private IEnumerable<AdmonitionTemplate> _admonitionTemplates;
        public HtmlAdmonitionRenderer(IEnumerable<AdmonitionTemplate> admonitionTemplates)
        {
            _admonitionTemplates = admonitionTemplates;
        }
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
                        string admonitionType = classes.Single().ToLower();

                        AdmonitionTemplate? admonitionTemplate = _admonitionTemplates.SingleOrDefault(p => p.Type.ToLower().Equals(admonitionType));

                        if(admonitionTemplate != null)
                        {
                            renderer.Write($"<div class=\"alert alert-{admonitionTemplate.BsAlertType}\" role=\"alert\">");
                            renderer.Write($"<p class=\"alert-heading\"><i class=\"bi bi-{admonitionTemplate.BsIconType}\"></i><strong> {admonitionTemplate.BsAlertHeading}</strong></p>");
                        }
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
