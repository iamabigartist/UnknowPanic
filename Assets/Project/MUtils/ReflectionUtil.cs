using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
namespace MUtils
{
    public static class ReflectionUtil
    {
        /// <summary>
        ///     <a href="https://forum.unity.com/threads/get-a-general-object-value-from-serializedproperty.327098/#post-6600706"> Link </a>
        /// </summary>
        public static object GetTargetObjectOfProperty(this SerializedProperty prop)
        {
            var path = prop.propertyPath.Replace( ".Array.data[", "[" );
            object obj = prop.serializedObject.targetObject;
            var elements = path.Split( '.' );
            foreach (var element in elements)
            {
                if (element.Contains( "[" ))
                {
                    var elementName = element.Substring( 0, element.IndexOf( "[", StringComparison.Ordinal ) );
                    var index = Convert.ToInt32( element.Substring( element.IndexOf( "[", StringComparison.Ordinal ) ).Replace( "[", "" ).Replace( "]", "" ) );
                    obj = GetValue_Imp( obj, elementName, index );
                }
                else
                {
                    obj = GetValue_Imp( obj, element );
                }
            }
            return obj;
        }

        static object GetValue_Imp(object source, string name)
        {
            if (source == null)
            {
                return null;
            }
            var type = source.GetType();

            while (type != null)
            {
                var f = type.GetField( name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );
                if (f != null)
                {
                    return f.GetValue( source );
                }

                var p = type.GetProperty( name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase );
                if (p != null)
                {
                    return p.GetValue( source, null );
                }

                type = type.BaseType;
            }
            return null;
        }

        static object GetValue_Imp(object source, string name, int index)
        {
            var enumerable = GetValue_Imp( source, name ) as IEnumerable;
            if (enumerable == null)
            {
                return null;
            }
            var enm = enumerable.GetEnumerator();
            //while (index-- >= 0)
            //    enm.MoveNext();
            //return enm.Current;

            for (int i = 0; i <= index; i++)
            {
                if (!enm.MoveNext())
                {
                    return null;
                }
            }
            return enm.Current;

        }
    }
}
