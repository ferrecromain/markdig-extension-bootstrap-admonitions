using Markdig.Parsers;

namespace Markdig.Extensions.Bootstrap.Admonitions
{
    /// <summary>
    /// The block parser for a <see cref="Admonition"/>.
    /// </summary>
    /// <seealso cref="FencedBlockParserBase{CustomContainer}" />
    public class BootstrapAdmonitionParser : FencedBlockParserBase<Admonition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapAdmonitionParser"/> class.
        /// </summary>
        public BootstrapAdmonitionParser()
        {
            OpeningCharacters = new[] { ':' };

            // We don't need a prefix
            InfoPrefix = null;
        }

        protected override Admonition CreateFencedBlock(BlockProcessor processor)
        {
            return new Admonition(this);
        }
    }
}
