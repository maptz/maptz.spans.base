using System;

namespace Maptz.Spans
{


    /// <summary>
    /// Immutable abstract representation of a span of in one-dimensional space. 
    /// </summary>
    public struct Span : IEquatable<Span>, IComparable<Span>, ISpan
    {

        public Span(long start, long length)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (start + length < start)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            this.Start = start;
            this.Length = length;
        }


        /// <summary>
        /// Gets the start of the span.
        /// </summary>
        public long Start { get; }

        /// <summary>
        /// Gets the end of the span.
        /// </summary>
        public long End => Start + Length;

        /// <summary>
        /// Length of the span.
        /// </summary>
        public long Length { get; }

        /// <summary>
        /// Gets whether the span is empty.
        /// </summary>
        public bool IsEmpty => this.Length == 0;







        /// <summary>
        /// Creates a new <see cref="TextSpan"/> from <paramref name="start" /> and <paramref
        /// name="end"/> positions as opposed to a position and length.
        /// 
        /// The returned TextSpan contains the range with <paramref name="start"/> inclusive, 
        /// and <paramref name="end"/> exclusive.
        /// </summary>
        public static Span FromBounds(long start, long end)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), $"{nameof(start)} must not be negative");
            }

            if (end < start)
            {
                throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} must not be negative");
            }

            return new Span(start, end - start);
        }

        /// <summary>
        /// Determines if two instances of <see cref="TextSpan"/> are the same.
        /// </summary>
        public static bool operator ==(Span left, Span right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines if two instances of <see cref="TextSpan"/> are different.
        /// </summary>
        public static bool operator !=(Span left, Span right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines if current instance of <see cref="TextSpan"/> is equal to another.
        /// </summary>
        public bool Equals(Span other)
        {
            return Start == other.Start && Length == other.Length;
        }

        /// <summary>
        /// Determines if current instance of <see cref="TextSpan"/> is equal to another.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Span && Equals((Span)obj);
        }

        /// <summary>
        /// Produces a hash code for <see cref="TextSpan"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCodeHelpers.Combine((int)Start, (int)Length);
        }



        /// <summary>
        /// Provides a string representation for <see cref="TextSpan"/>.
        /// </summary>
        public override string ToString()
        {
            return $"[{Start}..{End})";
        }

        /// <summary>
        /// Compares current instance of <see cref="TextSpan"/> with another.
        /// </summary>
        public int CompareTo(Span other)
        {
            var diff = Start - other.Start;
            if (diff != 0)
            {
                return (int) diff;
            }

            return (int)(Length - other.Length);
        }
    }
}