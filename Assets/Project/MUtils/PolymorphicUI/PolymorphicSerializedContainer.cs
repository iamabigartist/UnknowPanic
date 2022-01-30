using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace MUtils
{
    /// <summary>
    /// Only work when single property but not list
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    [Serializable]
    public class PolymorphicSerializedContainer<TParent>
    {
        List<Type> child_types;
        [SerializeReference]
        public PopUpField type_choice;
        [SerializeReference]
        public object m_object;
        public PolymorphicSerializedContainer()
        {
            var types = TypeCache.GetTypesDerivedFrom<TParent>();
            // var types =
            //     Assembly.GetAssembly( typeof(TParent) ).
            //         GetTypes().Where(
            //             t => t.IsSubclassOf( typeof(TParent) ) );
            child_types = types.ToList();
            type_choice = new PopUpField( GenerateObject, child_types.Select( t => t.Name ).ToArray() );
            GenerateObject( type_choice.CurChoice );
        }

        void GenerateObject(int type_index)
        {
            m_object = Activator.CreateInstance( child_types[type_index] );
        }
    }
}
