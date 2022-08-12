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
		[PolymorphicSelect]
		public Mammal m_mammal;
	}

	public class TestIMGUIAttributeDraw : MonoBehaviour
	{
		// public PolymorphicSerializedContainer<Mammal> b;

		[SerializeReference] [PolymorphicSelect]
		public Mammal c;

		[SerializeReference] [PolymorphicSelect]
		public List<Mammal> d = new();

	}
}