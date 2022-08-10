using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace MUtils
{
	[Serializable]
	public class PopUpField
	{
		public List<string> choices;
		event Action<int> OnChoiceChange;
		int cur_choice;
		public int CurChoice
		{
			get => cur_choice;
			set
			{
				if (value != cur_choice)
				{
					cur_choice = value;
					OnChoiceChange!.Invoke(cur_choice);
				}
			}
		}

		public PopUpField(Action<int> choice_change_callback, params string[] choices)
		{
			OnChoiceChange = choice_change_callback;
			this.choices = choices.ToList();
			cur_choice = 0;
		}
		
	}
	[CustomPropertyDrawer(typeof(PopUpField))]
	public class PopUpFieldDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var field = (PopUpField)property.managedReferenceValue;
			EditorGUI.BeginProperty(position, label, property);
			field.CurChoice = EditorGUI.Popup(position, field.CurChoice, field.choices.ToArray());
			EditorGUI.EndProperty();
		}
	}
}