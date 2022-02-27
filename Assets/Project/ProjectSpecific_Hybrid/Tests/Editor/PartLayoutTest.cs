using MUtils;
using UnityEditor;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests
{
    public class PartLayoutTest : EditorWindow
    {
        [MenuItem( "UnknownPanic.Tests/PartLayoutTest" )]
        static void ShowWindow()
        {
            var window = GetWindow<PartLayoutTest>();
            window.titleContent = new GUIContent( "PartLayoutTest" );
            window.Show();
        }

        void OnGUI()
        {
            var coordinate_rect = new Rect( 0, 0, position.width, position.height );
            const int column = 3;
            const int row = 3;
            const int count = column * row;
            var layout = new Vector2Int( column, row );
            var rects = new Rect[count];

            int i = 0;
            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    rects[i] = coordinate_rect.GetPart( layout.x, layout.y, x, y );
                    GUI.Box( rects[i], $"coordinate: ({x},{y})\nrect: {rects[i]}\n{position}" );
                    EditorGUI.DrawRect( rects[i], new Color( 0.2f, 0.4f, 0.15f, 0.8f * i / count ) );
                    i++;
                }
            }
        }
    }
}
