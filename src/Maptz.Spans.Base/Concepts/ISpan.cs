using System;
namespace Maptz.Spans
{

  

    public interface ISpan
    {
        /// <summary>
        /// Gets the start of the span.
        /// </summary>
        long Start { get; }
        /// <summary>
        /// Gets the length of the span.
        /// </summary>
        long Length { get; }
        /// <summary>
        /// Gets the end of the span.
        /// </summary>
        long End { get; }
        /// <summary>
        /// Gets whether the span is empty.
        /// </summary>
        bool IsEmpty { get; }
    }
}