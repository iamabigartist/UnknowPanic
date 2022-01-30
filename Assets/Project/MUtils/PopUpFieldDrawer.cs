using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace MUtils
{
    [Serializable]
    public struct PopUpField
    {
        public List<string> choices;
        public int cur_choice;
    }
    [CustomPropertyDrawer( typeof(PopUpField) )]
    public class PopUpFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var field = (PopUpField)property.GetValue();
        }
    }
}
