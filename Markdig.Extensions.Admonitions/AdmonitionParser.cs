using Markdig.Parsers;

namespace Markdig.Extensions.Admonition
{
    /// <summary>
    /// The block parser for a <see cref="Admonition"/>.
    /// </summary>
    /// <seealso cref="FencedBlockParserBase{CustomContainer}" />
    public class AdmonitionParser : FencedBlockParserBase<Admonition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdmonitionParser"/> class.
        /// </summary>
        public AdmonitionParser()
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
