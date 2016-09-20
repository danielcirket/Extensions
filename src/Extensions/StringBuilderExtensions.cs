using System;
using System.Text;

namespace Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder TrimEnd(this StringBuilder source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                return source;

            var i = source.Length - 1;

            for (; i >= 0; i--)
            {
                if (!char.IsWhiteSpace(source[i]))
                    break;
            }

            if (i < source.Length - 1)
                source.Length = i + 1;

            return source;
        }
        public static StringBuilder TrimEnd(this StringBuilder source, params char[] characters)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                return source;

            if (characters.Length == 0)
                return source;

            return TrimInternal(source, source.Length - 1, characters);
        }
        public static StringBuilder TrimEnd(this StringBuilder source, string find)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (find == null)
                throw new ArgumentNullException(nameof(find));

            if (source.Length == 0)
                return source;

            if (find.Length == 0)
                return source;

            if (source.Length < find.Length)
                return source;

            return TrimInternal(source, (source.Length - 1) - (find.Length - 1), find);
            //var i = (source.Length - 1) - (find.Length - 1);
            //var j = 0;

            //while (i < source.Length && j < find.Length)
            //{
            //    if (source[i] != find[j])
            //        break;

            //    if (j == find.Length -1)
            //    {
            //        source.Remove(source.Length - find.Length, find.Length);
            //        break;
            //    }

            //    i++;
            //    j++;
            //}

            //return source;
        }
        public static StringBuilder TrimStart(this StringBuilder source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                return source;

            var i = 0;
            for (; i < source.Length - 1; i++)
            {
                if (!char.IsWhiteSpace(source[i]))
                    break;
            }

            if (i < source.Length - 1)
                source.Remove(0, i);

            return source;

        }
        public static StringBuilder TrimStart(this StringBuilder source, params char[] characters)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                return source;

            if (characters.Length == 0)
                return source;

            return TrimInternal(source, 0, characters);
        }
        public static StringBuilder TrimStart(this StringBuilder source, string find)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (find == null)
                throw new ArgumentNullException(nameof(find));

            if (source.Length == 0)
                return source;

            if (find.Length == 0)
                return source;

            if (source.Length < find.Length)
                return source;

            if (source[find.Length - 1] != find[find.Length - 1])
                return source;

            return TrimInternal(source, 0, find);
        }

        private static StringBuilder TrimInternal(this StringBuilder source, int startIndex, string find)
        {
            var i = startIndex;
            var j = 0;

            while (i < source.Length && j < find.Length)
            {
                if (source[i] != find[j])
                    break;

                i++;
                j++;
            }

            if (j == find.Length)
            {
                source.Remove(startIndex, find.Length);
            }

            // TODO(Dan): Reset the length here...

            return source;
        }
        private static StringBuilder TrimInternal(this StringBuilder source, int startIndex, params char[] characters)
        {
            var i = startIndex;
            var j = 0;
            for (; i < source.Length; ++i, ++j)
                if (!source[i].IsAnyOf(characters))
                    break;

            if (i > startIndex)
                source.Remove(startIndex, j);

            return source;
        }
    }
}
