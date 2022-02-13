using Markdig;
using Markdig.Renderers;

namespace Markdig.Extensions.Admonition
{
    /// <summary>
    /// Extension to allow custom containers.
    /// </summary>
    /// <seealso cref="IMarkdownExtension" />
    public class AdmonitionExtension : IMarkdownExtension
    {
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
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlAdmonitionRenderer());
                }
            }
        }
    }
}