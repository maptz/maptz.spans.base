using System;
namespace Maptz.Spans
{public static class ISpanExtensions
    {


        /// <summary>
        /// Determines whether the span contains a position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool Contains(this ISpan me, int position)
        {
            return unchecked((uint)(position - me.Start) < (uint)me.Length);
        }



        /// <summary>
        /// Determines whether it contains another span.
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static bool Contains(this ISpan me, ISpan span)
        {
            return span.Start >= me.Start && span.End <= me.End;
        }

        /// <summary>
        /// Determines if it overlaps with another span.
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static bool OverlapsWith(this ISpan me, ISpan span)
        {
            long overlapStart = Math.Max(me.Start, span.Start);
            long overlapEnd = Math.Min(me.End, span.End);

            return overlapStart < overlapEnd;
        }



        /// <summary>
        /// Determines whether <paramref name="span"/> intersects this span. Two spans are considered to 
        /// intersect if they have positions in common or the end of one span 
        /// coincides with the start of the other span.
        /// </summary>
        /// <param name="span">
        /// The span to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the spans intersect, otherwise <c>false</c>.
        /// </returns>
        public static bool IntersectsWith(this ISpan me, ISpan span)
        {
            return span.Start <= me.End && span.End >= me.Start;
        }

        /// <summary>
        /// Determines whether <paramref name="position"/> intersects this span. 
        /// A position is considered to intersect if it is between the start and
        /// end positions (inclusive) of this span.
        /// </summary>
        /// <param name="position">
        /// The position to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the position intersects, otherwise <c>false</c>.
        /// </returns>
        public static bool IntersectsWith(this ISpan me, int position)
        {
            return unchecked((uint)(position - me.Start) <= (uint)me.Length);
        }

        /// <summary>
        /// Returns the overlap with the given span, or null if there is no overlap.
        /// </summary>
        /// <param name="span">
        /// The span to check.
        /// </param>
        /// <returns>
        /// The overlap of the spans, or null if the overlap is empty.
        /// </returns>
        public static ISpan Overlap(this ISpan me, ISpan span)
        {
            long overlapStart = Math.Max(me.Start, span.Start);
            long overlapEnd = Math.Min(me.End, span.End);

            return overlapStart < overlapEnd
                ? Span.FromBounds(overlapStart, overlapEnd)
                : (Span?)null;
        }

        /// <summary>
        /// Returns the intersection with the given span, or null if there is no intersection.
        /// </summary>
        /// <param name="span">
        /// The span to check.
        /// </param>
        /// <returns>
        /// The intersection of the spans, or null if the intersection is empty.
        /// </returns>
        public static ISpan Intersection(this ISpan me, ISpan span)
        {
            long intersectStart = Math.Max(me.Start, span.Start);
            long intersectEnd = Math.Min(me.End, span.End);

            return intersectStart <= intersectEnd
                ? Span.FromBounds(intersectStart, intersectEnd)
                : (Span?)null;
        }

    }
}