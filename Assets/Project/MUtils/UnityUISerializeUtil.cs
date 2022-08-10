using System;
using UnityEditor;
namespace MUtils
{
	public static class UnityUISerializeUtil
	{
		/// Creates instance of passed type and assigns it to managed reference
		public static void AssignNewInstanceOfTypeToManagedReference(this SerializedProperty serializedProperty, object obj)
		{
			serializedProperty.serializedObject.Update();
			serializedProperty.managedReferenceValue = obj;
			serializedProperty.serializedObject.ApplyModifiedProperties();
		}

		public static (string AssemblyName, string ClassName) GetSplitNamesFromTypename(string typename)
		{
			if (string.IsNullOrEmpty(typename))
				return ("", "");

			var typeSplitString = typename.Split(char.Parse(" "));
			var typeClassName = typeSplitString[1];
			var typeAssemblyName = typeSplitString[0];
			return (typeAssemblyName, typeClassName);
		}

		public static Type GetTypeFromTypename(this SerializedProperty serializedProperty)
		{
			var names = GetSplitNamesFromTypename(serializedProperty.managedReferenceFieldTypename);
			var realType = Type.GetType($"{names.ClassName}, {names.AssemblyName}");
			return realType;
		}
	}
}