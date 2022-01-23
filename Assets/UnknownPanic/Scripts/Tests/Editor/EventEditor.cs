using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnknownPanic.Datas.Events;
namespace UnknownPanic.Tests
{
    [Serializable]
    public class EventEditor : EditorWindow
    {
        [MenuItem( "UnknownPanic.Tests/EventEditor" )]
        static void Init()
        {
            var window = GetWindow<EventEditor>();
            window.titleContent = new GUIContent( "EventEditor" );
            window.Show();
        }

    #region Serialized

        SerializedObject this_;
        SerializedProperty event_list_;

    #endregion

        [SerializeField]
        List<StoryEvent> event_list;

        void OnEnable()
        {
            event_list = new List<StoryEvent>();

            this_ = new SerializedObject( this );
            event_list_ = this_.FindProperty( nameof(event_list) );
        }

        Vector2 pos_scroll_view;
        void OnGUI()
        {
            if (GUILayout.Button( "Copy" ))
            {
                var _ = new TextEditor();
                _.text = JsonUtility.ToJson( event_list );
                _.OnFocus();
                _.Copy();
            }

            using (var s = new EditorGUILayout.ScrollViewScope( pos_scroll_view ))
            {
                pos_scroll_view = s.scrollPosition;
                EditorGUILayout.PropertyField( event_list_, true );
            }


            this_.ApplyModifiedProperties();

        }
    }
}
