using System;
using UnityEngine;
namespace UnknownPanic.Utils
{
    public static class TextProcessUtils
    {

    #region BaseProcess

        /// <summary>
        ///     Remove part of the string and replace with new one.
        /// </summary>
        public static string ReplaceSubstring(this string ori_str, string replacement, int replace_start, int replace_length)
        {
            var result_text = ori_str.Remove( replace_start, replace_length );
            result_text = result_text.Insert( replace_start, replacement );
            return result_text;
        }

        public static string ReplaceSubstring(this string ori_str, Func<string, string> string_generator, int replace_start, int replace_length)
        {
            var replaced = ori_str.Substring( replace_start, replace_length );
            var result_text = ori_str.Remove( replace_start, replace_length );
            result_text = result_text.Insert( replace_start, string_generator( replaced ) );
            return result_text;
        }

    #endregion


    #region Color

        public const string R_COLOR_TAG = "</color>";

        public static string L_COLOR_TAG(Color color)
        {
            var color_html_hex = ColorUtility.ToHtmlStringRGBA( color );
            return $"<color=#{color_html_hex}>";
        }

        public static string AddColorToText(this string plain_text, Color color)
        {
            var colored = string.Copy( plain_text );
            colored = L_COLOR_TAG( color ) + colored + R_COLOR_TAG;
            return colored;
        }

    #endregion

    #region Replacement

    #endregion








    }
}
