using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUIUtility;
namespace MUtils.PolymorphicUI
{
	public interface IInstanceGenerator
	{
		object Generate(Type type);
	}

	public class DefaultInstanceGenerator : IInstanceGenerator
	{
		public object Generate(Type type)
		{
			return Activator.CreateInstance(type);
		}
	}

	public class SerializedReferenceWithSelectionAttribute : PropertyAttribute
	{
		public Type InstanceGenType;
		public SerializedReferenceWithSelectionAttribute() { InstanceGenType = typeof(DefaultInstanceGenerator); }
		public SerializedReferenceWithSelectionAttribute(Type InstanceGenType) { this.InstanceGenType = InstanceGenType; }
	}

	[Obsolete("Not finished")]
	[CustomPropertyDrawer(typeof(SerializedReferenceWithSelectionAttribute))]
	public class SerializedReferenceWithSelectionDrawer : PropertyDrawer
	{
		List<Type> instance_types;
		string[] type_names;
		int cur_choice;
		IInstanceGenerator Generator;
		int CurChoice(SerializedProperty property)
		{
			return instance_types.IndexOf(property.managedReferenceValue?.GetType());
		}

		void RefreshObject(SerializedProperty property, int type_index)
		{
			var obj = Generator.Generate(instance_types[type_index]);
			property.AssignNewInstanceOfTypeToManagedReference(obj);
		}

		void OnTypeSelectionPopUp(ref Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.LabelField(position.UpPart(singleLineHeight), label);
			var new_choice = EditorGUI.Popup(
				position.UpPart(singleLineHeight * 2).DownPart(singleLineHeight),
				CurChoice(property), type_names);
			// var new_choice = EditorGUI.Popup(
			// 	position.UpPart(singleLineHeight),
			// 	cur_choice, type_names);
			if (new_choice != CurChoice(property))
			{
				Debug.Log($"cur: {CurChoice(property)}, new: {new_choice}");
				// cur_choice = new_choice;
				RefreshObject(property, new_choice);
			}
			position = position.DownPart(singleLineHeight);
		}


		bool inited;
		void Init(SerializedProperty property)
		{
			var parent_type = property.GetTypeFromTypename();
			instance_types = TypeCache.GetTypesDerivedFrom(parent_type).Where(Type => !Type.IsAbstract).ToList();
			type_names = instance_types.Select(Type => Type.Name).ToArray();
			var atr = (SerializedReferenceWithSelectionAttribute)fieldInfo.GetCustomAttributes(false).Single(a => a is SerializedReferenceWithSelectionAttribute);
			Generator = (IInstanceGenerator)Activator.CreateInstance(atr.InstanceGenType);
			var current_type = property.managedReferenceValue?.GetType();
			Debug.Log($"choice: {CurChoice(property)}, instance: {parent_type}, value: {property.managedReferenceValue}");
			// cur_choice = instance_types.IndexOf(current_type);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return singleLineHeight + EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (!inited)
			{
				Init(property);
				inited = true;
			}
			EditorGUI.BeginProperty(position, label, property);
			OnTypeSelectionPopUp(ref position, property, label);
			EditorGUI.PropertyField(position, property, GUIContent.none, true);
			EditorGUI.EndProperty();
		}

	}

}