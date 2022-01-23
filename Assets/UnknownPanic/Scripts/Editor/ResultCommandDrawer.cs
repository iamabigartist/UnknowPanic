using UnityEditor;
using UnityEngine;
using UnknownPanic.Datas.Events;
namespace UnknownPanic
{
    [CustomPropertyDrawer( typeof(ResultCommandContainer) )]
    public class ResultCommandDrawer : PropertyDrawer
    {
        const float base_height = 20;
        public static ResultCommandType GetCommandType(SerializedProperty property)
        {
            return (ResultCommandType)property.FindPropertyRelative( "command_type" ).enumValueIndex;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var command_type = GetCommandType( property );
            EditorGUI.BeginProperty( position, label, property );
            ResultCommandContainer.GUIInput_methods[command_type]( position, property );
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var command_type = GetCommandType( property );
            return base_height * ResultCommandContainer.FieldCounts[command_type];
        }
    }
}
