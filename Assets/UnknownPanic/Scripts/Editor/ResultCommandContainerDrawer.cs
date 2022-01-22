using UnityEditor;
using UnityEngine;
using UnknownPanic.Datas.Events;
namespace UnknownPanic.Editor
{
    [CustomPropertyDrawer( typeof(ResultCommandContainer), false )]
    public class ResultCommandContainerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.ref
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 300f;
        }
    }
}
