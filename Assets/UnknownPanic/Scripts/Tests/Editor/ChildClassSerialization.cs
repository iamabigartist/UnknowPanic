using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace UnknownPanic.Tests
{
    [Serializable]
    public class Mammal
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
    public class Dog : Mammal
    {
        public string master;
    }


    [Serializable]
    public class ChildClassSerialization : EditorWindow
    {
        [MenuItem( "Tests/ChildClassSerialization" )]
        static void ShowWindow()
        {
            var window = GetWindow<ChildClassSerialization>();
            window.titleContent = new GUIContent( "ChildClassSerialization" );
            window.Show();
        }


        public Cat m_cat;
        public Dog m_dog;
        public Mammal m_mammal;
        public List<Mammal> m_mammals;

        SerializedObject this_;

        void OnEnable()
        {
            this_ = new SerializedObject( this );
            m_mammal = new Cat();
        }
        void OnGUI()
        {
            EditorGUILayout.PropertyField( this_.FindProperty( nameof(m_cat) ) );
            EditorGUILayout.PropertyField( this_.FindProperty( nameof(m_dog) ) );
            EditorGUILayout.PropertyField( this_.FindProperty( nameof(m_mammal) ) );
            EditorGUILayout.PropertyField( this_.FindProperty( nameof(m_mammals) ) );
            this_.ApplyModifiedProperties();
        }
    }
}
