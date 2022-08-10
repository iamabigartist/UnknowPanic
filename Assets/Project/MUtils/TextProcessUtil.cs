using System;
using UnityEngine;
namespace MUtils
{

    public class RichTextTag
    {
        public string l_part;
        public string r_part;
        public RichTextTag(string l_part, string r_part)
        {
            this.l_part = l_part;
            this.r_part = r_part;
        }
    }


    public static class TextProcessUtil
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

    #region Tag

        public const string L_BOLD_TAG = "<b>";
        public const string R_BOLD_TAG = "</b>";
        public const string L_ITALICS_TAG = "<i>";
        public const string R_ITALICS_TAG = "</i>";
        public const string R_SIZE_TAG = "</size>";
        public const string R_COLOR_TAG = "</color>";


        public static string L_COLOR_TAG(Color color)
        {
            return $"<color=#{color.HtmlHex()}>";
        }
        public static string L_SIZE_TAG(int size)
        {
            return $"<size={size}>";
        }
        public static RichTextTag BoldT()
        {
            return new RichTextTag( L_BOLD_TAG, R_BOLD_TAG );
        }
        public static RichTextTag ItalicsT()
        {
            return new RichTextTag( L_ITALICS_TAG, R_ITALICS_TAG );
        }
        public static RichTextTag ColorT(Color color)
        {
            return new RichTextTag( L_COLOR_TAG( color ), R_COLOR_TAG );
        }
        public static RichTextTag SizeT(int size)
        {
            return new RichTextTag( L_SIZE_TAG( size ), R_SIZE_TAG );
        }

        public static string Tag(this string text, RichTextTag tag)
        {
            return tag.l_part + text + tag.r_part;
        }

        public static string BOLD(this string text)
        {
            return text.Tag( BoldT() );
        }

        public static string ITALICS(this string text)
        {
            return text.Tag( ItalicsT() );
        }

        public static string SIZE(this string text, int size)
        {
            return text.Tag( SizeT( size ) );
        }
        public static string COLOR(this string text, Color color)
        {
            return text.Tag( ColorT( color ) );
        }

    #endregion


    #region Color

        public static string HtmlHex(this Color color)
        {
            return ColorUtility.ToHtmlStringRGBA( color );
        }

    #endregion

    #region Replacement

    #endregion








    }
}
