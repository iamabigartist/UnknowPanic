using UnityEngine;
namespace UnknownPanic.Utils
{
    public static class RichTextUtils
    {
        public const string R_COLOR_TAG = "</color>";
        public static string L_COLOR_TAG(Color color)
        {
            var color_html_hex = ColorUtility.ToHtmlStringRGBA( color );
            return $"<color=#{color_html_hex}>";
        }

        /// <summary>
        ///     Remove part of the string and replace with new one.
        /// </summary>
        public static string ReplacePosition(this string ori_str, string replacement, int replace_start, int replace_length)
        {
            var result_text = ori_str.Remove( replace_start, replace_length );
            result_text = result_text.Insert( replace_start, replacement );
            return result_text;
        }

        public static string AddColorToText(this string plain_text, Color color, int start, int length)
        {
            var colored = plain_text.Substring( start, length );
            colored = L_COLOR_TAG( color ) + colored + R_COLOR_TAG;
            var rich_text = plain_text.ReplacePosition( colored, start, length );
            return rich_text;
        }
    }
}
