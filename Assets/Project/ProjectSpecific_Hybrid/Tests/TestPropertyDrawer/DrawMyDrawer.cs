using MUtils;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUIUtility;
namespace ProjectSpecific_Hybrid.Tests.TestPropertyDrawer
{
	public class DrawMyAttribute : PropertyAttribute {}

	[CustomPropertyDrawer(typeof(DrawMyAttribute))]
	public class DrawMyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return singleLineHeight + EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			var rect = position.UpPart(singleLineHeight);
			rect.x -= 10;
			EditorGUI.HelpBox(rect, label.text, MessageType.Error);
			EditorGUI.PropertyField(position.DownPart(singleLineHeight), property, GUIContent.none, true);
			EditorGUI.EndProperty();
		}
	}
}