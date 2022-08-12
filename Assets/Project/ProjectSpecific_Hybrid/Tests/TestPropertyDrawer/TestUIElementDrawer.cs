using System;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests.TestPropertyDrawer
{

	[Serializable]
	public class TestDrawn
	{
		public int a;
		public bool b;
	}
	public class TestUIElementDrawer:MonoBehaviour
	{
		[DrawMy]
		public TestDrawn Drawn;
	}
}