using UnityEditor;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests.TestPropertyDrawer.Editor
{
	[CustomPropertyDrawer(typeof(DrawMyAttribute))]
	public class DrawMyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, true);
		}
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property); 
			
			var labelPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.LabelField(labelPosition, label);
			EditorGUI.PropertyField(position, property, GUIContent.none, true);

			EditorGUI.EndProperty(); 

		}
	}
}