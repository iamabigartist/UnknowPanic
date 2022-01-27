using MUtils;
using UnityEditor;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests
{
    public class TestColorConvert : EditorWindow
    {
        [MenuItem( "Tests/TestColorConvert" )]
        static void ShowWindow()
        {
            var window = GetWindow<TestColorConvert>();
            window.titleContent = new GUIContent( "TestColorConvert" );
            window.Show();
        }

        Color m_color;
        string color_html_hex;
        const string plain_text = "I have a ▙█▓▟░a";
        string rich_text;
        GUIStyle label_style;
        void OnEnable()
        {
            label_style = new GUIStyle()
            {
                richText = true
            };
        }
        void OnGUI()
        {
            m_color = EditorGUILayout.ColorField( m_color );
            color_html_hex = ColorUtility.ToHtmlStringRGBA( m_color );
            rich_text = plain_text.ReplaceSubstring( (str) => str.COLOR( m_color ), 9, 6 );
            EditorGUILayout.LabelField( $"color: {color_html_hex}" );
            GUILayout.Label( $"rich text: {rich_text}", label_style );
        }

    }
}
