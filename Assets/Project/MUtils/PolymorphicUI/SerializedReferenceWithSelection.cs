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
				cur_choice, type_names);
			// var new_choice = EditorGUI.Popup(
			// 	position.UpPart(singleLineHeight),
			// 	cur_choice, type_names);
			if (new_choice != cur_choice)
			{
				Debug.Log($"cur: {cur_choice}, new: {new_choice}");
				cur_choice = new_choice;
				RefreshObject(property, new_choice);
			}
			position = position.DownPart(singleLineHeight);
		}


		bool inited;
		void Init(SerializedProperty property)
		{
			var type = property.GetTypeFromTypename();
			instance_types = TypeCache.GetTypesDerivedFrom(type).Where(Type => !Type.IsAbstract).ToList();
			type_names = instance_types.Select(Type => Type.Name).ToArray();
			var atr = (SerializedReferenceWithSelectionAttribute)fieldInfo.GetCustomAttributes(false).Single(a => a is SerializedReferenceWithSelectionAttribute);
			Generator = (IInstanceGenerator)Activator.CreateInstance(atr.InstanceGenType);
			cur_choice = instance_types.IndexOf(type);
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