using Markdig.Renderers;

namespace Markdig.Extensions.Bootstrap.Admonitions
{
    /// <summary>
    /// Extension to allow custom containers.
    /// </summary>
    /// <seealso cref="IMarkdownExtension" />
    public class BootstrapAdmonitionExtension : IMarkdownExtension
    {
        private IEnumerable<BootstrapAdmonitionTemplate> _admonitionTemplates;
        public BootstrapAdmonitionExtension(
            string warningTitle,
            string dangerTitle,
            string tipTitle,
            string noteTitle)
        {
            _admonitionTemplates = new List<BootstrapAdmonitionTemplate>()
            {
                new BootstrapAdmonitionTemplate("tip", "success", "lightbulb", tipTitle),
                new BootstrapAdmonitionTemplate("note", "info", "info-circle-fill", noteTitle),
                new BootstrapAdmonitionTemplate("danger", "danger", "x-circle-fill", dangerTitle),
                new BootstrapAdmonitionTemplate("warning", "warning", "exclamation-triangle-fill", warningTitle),
            };
        }

        public BootstrapAdmonitionExtension(IEnumerable<BootstrapAdmonitionTemplate> admonitionsTemplates)
        {
            _admonitionTemplates = admonitionsTemplates;
        }
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.BlockParsers.Contains<BootstrapAdmonitionParser>())
            {
                // Insert the parser before any other parsers
                pipeline.BlockParsers.Insert(0, new BootstrapAdmonitionParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (renderer is HtmlRenderer htmlRenderer)
            {
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlBootstrapAdmonitionRenderer>())
                {
                    // Must be inserted before CodeBlockRenderer
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlBootstrapAdmonitionRenderer(_admonitionTemplates));
                }
            }
        }
    }
}