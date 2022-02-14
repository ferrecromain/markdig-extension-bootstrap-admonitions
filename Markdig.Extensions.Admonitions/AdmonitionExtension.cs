using Markdig;
using Markdig.Extensions.Admonitions;
using Markdig.Renderers;

namespace Markdig.Extensions.Admonition
{
    /// <summary>
    /// Extension to allow custom containers.
    /// </summary>
    /// <seealso cref="IMarkdownExtension" />
    public class AdmonitionExtension : IMarkdownExtension
    {
        private IEnumerable<AdmonitionTemplate> _admonitionTemplates;
        public AdmonitionExtension(
            string warningTitle, 
            string dangerTitle, 
            string tipTitle,
            string noteTitle)
        {
            _admonitionTemplates = new List<AdmonitionTemplate>()
            {
                new AdmonitionTemplate("tip", "success", "lightbuld", tipTitle),
                new AdmonitionTemplate("note", "info", "info-circle-fill", noteTitle),
                new AdmonitionTemplate("danger", "danger", "x-circle-fill", dangerTitle),
                new AdmonitionTemplate("warning", "warning", "exclamation-triangle-fill", warningTitle),
            };
        }

        public AdmonitionExtension(IEnumerable<AdmonitionTemplate> admonitionsTemplates)
        {
            _admonitionTemplates = admonitionsTemplates;
        }
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.BlockParsers.Contains<AdmonitionParser>())
            {
                // Insert the parser before any other parsers
                pipeline.BlockParsers.Insert(0, new AdmonitionParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (renderer is HtmlRenderer htmlRenderer)
            {
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlAdmonitionRenderer>())
                {
                    // Must be inserted before CodeBlockRenderer
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlAdmonitionRenderer(_admonitionTemplates));
                }
            }
        }
    }
}