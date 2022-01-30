using System;
using UnityEditor;
using UnityEngine;
namespace MUtils.PolymorphicUI
{
    [Obsolete("Not finished")]
    public class SerializedReferenceWithSelectionAttribute : PropertyAttribute { }

    [Obsolete("Not finished")]
    [CustomPropertyDrawer( typeof(SerializedReferenceWithSelectionAttribute) )]
    public class SerializedReferenceWithSelectionDrawer : PropertyDrawer
    {
        public SerializedReferenceWithSelectionDrawer() : base()
        {
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight( property, label, true );
        }
    }

}
