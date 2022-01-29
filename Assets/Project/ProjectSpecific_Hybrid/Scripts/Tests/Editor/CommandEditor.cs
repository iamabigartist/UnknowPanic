using System;
using System.Collections.Generic;
using Game_UnknownPanic.Events;
using UnityEditor;
using UnityEngine;
namespace ProjectSpecific_Hybrid.Tests
{
    [Serializable]
    public class CommandEditor : EditorWindow
    {
        [MenuItem( "UnknownPanic/CommandEditor" )]
        static void Init()
        {
            var window = GetWindow<CommandEditor>();
            window.titleContent = new GUIContent( "CommandEditor" );
            window.Show();
        }

    #region Serialized

        SerializedObject this_;
        SerializedProperty command_list_;

    #endregion

        [SerializeField]
        List<ResultCommandContainer> command_list;

        void OnEnable()
        {
            command_list = new List<ResultCommandContainer>();

            this_ = new SerializedObject( this );
            command_list_ = this_.FindProperty( nameof(command_list) );
        }

        Vector2 pos_scroll_view;
        void OnGUI()
        {
            if (GUILayout.Button( "Copy" ))
            {
                var _ = new TextEditor();
                _.text = JsonUtility.ToJson( command_list );
                _.OnFocus();
                _.Copy();
            }

            using (var s = new EditorGUILayout.ScrollViewScope( pos_scroll_view ))
            {
                pos_scroll_view = s.scrollPosition;
                EditorGUILayout.PropertyField( command_list_ );
            }


            this_.ApplyModifiedProperties();

        }
    }
}
