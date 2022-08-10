using System.Linq;
using UnityEditor;
using UnityEngine;
namespace MUtils
{
	public abstract class GUIPropertyAttribute : PropertyAttribute
	{
		public abstract void OnGUI(Rect position, SerializedProperty property, GUIContent label);
	}

	[CustomPropertyDrawer(typeof(GUIPropertyAttribute))]
	public class GUIPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			foreach (var a in fieldInfo.GetCustomAttributes(false).OrderBy(a => ((PropertyAttribute)a).order))
			{
				if (a is GUIPropertyAttribute gui_atr) { gui_atr.OnGUI(position, property, label); }
			}
		}
	}
}