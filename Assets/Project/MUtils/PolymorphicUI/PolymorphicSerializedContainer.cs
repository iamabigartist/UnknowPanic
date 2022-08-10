using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace MUtils.PolymorphicUI
{
	/// <summary>
	///     Only work when single property but not list
	/// </summary>
	/// <typeparam name="TParent"></typeparam>
	[Serializable]
	public class PolymorphicSerializedContainer<TParent>
	{
		static List<Type> child_types;

		Func<Type, object> GenerateObject;

		[SerializeReference]
		public PopUpField type_choice;
		[SerializeReference]
		public object m_object;

		static PolymorphicSerializedContainer()
		{
			// var types =
			//     Assembly.GetAssembly( typeof(TParent) ).
			//         GetTypes().Where(
			//             t => t.IsSubclassOf( typeof(TParent) ) );
			var types = TypeCache.GetTypesDerivedFrom<TParent>();
			child_types = types.ToList();
		}

		public PolymorphicSerializedContainer() : this(type => Activator.CreateInstance(type)) {}

		public PolymorphicSerializedContainer(Func<Type, object> generateObject)
		{
			GenerateObject = generateObject;
			type_choice = new(RefreshObject, child_types.Select(t => t.Name).ToArray());
			RefreshObject(type_choice.CurChoice);
		}

		void RefreshObject(int type_index)
		{
			m_object = GenerateObject(child_types[type_index]);
			// m_object = Activator.CreateInstance(child_types[type_index]);
		}
	}
}