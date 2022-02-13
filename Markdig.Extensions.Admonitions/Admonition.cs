using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;

namespace Markdig.Extensions.Admonition
{
    public class Admonition : ContainerBlock, IFencedBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Admonition"/> class.
        /// </summary>
        /// <param name="parser">The parser used to create this block.</param>
        public Admonition(BlockParser parser) : base(parser)
        {
        }

        /// <inheritdoc />
        public char FencedChar { get; set; }

        /// <inheritdoc />
        public int OpeningFencedCharCount { get; set; }

        /// <inheritdoc />
        public StringSlice TriviaAfterFencedChar { get; set; }

        /// <inheritdoc />
        public string? Info { get; set; }

        /// <inheritdoc />
        public StringSlice UnescapedInfo { get; set; }

        /// <inheritdoc />
        public StringSlice TriviaAfterInfo { get; set; }

        /// <inheritdoc />
        public string? Arguments { get; set; }

        /// <inheritdoc />
        public StringSlice UnescapedArguments { get; set; }

        /// <inheritdoc />
        public StringSlice TriviaAfterArguments { get; set; }

        /// <inheritdoc />
        public NewLine InfoNewLine { get; set; }

        /// <inheritdoc />
        public StringSlice TriviaBeforeClosingFence { get; set; }

        /// <inheritdoc />
        public int ClosingFencedCharCount { get; set; }
    }
}
