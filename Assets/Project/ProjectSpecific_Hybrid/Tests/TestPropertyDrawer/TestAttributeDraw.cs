using System;
using System.Collections.Generic;
using MUtils.PolymorphicUI;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests.TestPropertyDrawer
{
	[Serializable]
	public abstract class Mammal
	{
		public int life;
		public Color fur;
	}

	[Serializable]
	public class Cat : Mammal
	{
		public string friend;
	}


	[Serializable]
	public abstract class Dog : Mammal
	{
		public string master;
	}

	[Serializable]
	public class Dog11 : Dog
	{
		public AnimationCurve thought;
	}

	[Serializable]
	public class S1 : Mammal
	{
		[SerializeReference]
		[SerializedReferenceWithSelection]
		public Mammal m_mammal;
	}

	public class TestAttributeDraw : MonoBehaviour
	{
		
		[SerializeReference]
		[DrawMy]
		[Range(1, 100f)]
		public List<Mammal> a;

		public PolymorphicSerializedContainer<Mammal> b;

		public static object GenObject(Type type)
		{
			return Activator.CreateInstance(type);
		}


		[SerializeReference]
		[SerializedReferenceWithSelection]
		public Mammal c;


		[SerializeReference]
		[SerializedReferenceWithSelection]
		public List<Mammal> d = new();

		[ContextMenu("Value Cat")]
		void ValueCat()
		{
			a = new()
			{
				new Cat()
			};
		}
	}
}