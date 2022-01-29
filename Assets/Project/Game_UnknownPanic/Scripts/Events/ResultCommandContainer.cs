using System;
using System.Collections.Generic;
using Game_UnknownPanic.GameProcess;
using Game_UnknownPanic.Objects;
using UnityEditor;
using UnityEngine;
using static Game_UnknownPanic.Rules.EscaperRules;
using static Game_UnknownPanic.Rules.GlobalRule;
using static MUtils.UIUtils;
namespace Game_UnknownPanic.Events
{
    public enum ResultCommandType
    {
        EscaperStateChange,
        StoryUnlock
    }

    [Serializable]
    public class ResultCommandContainer
    {
        public static Dictionary<ResultCommandType, int> FieldCounts;
        public static Dictionary<ResultCommandType, Action<Rect, SerializedProperty>> GUIInput_methods;
        public static Dictionary<ResultCommandType, Action<ResultCommandContainer, GlobalState>> Execute_methods;
        static void DrawPropertyList(Rect position, SerializedProperty property, string[] field_names)
        {
            DrawGridUIs( position, 1, field_names.Length, field_names,
                (m_rect, i, name) =>
                {
                    EditorGUI.PropertyField( m_rect, property.FindPropertyRelative( name ) );
                } );
        }
        static ResultCommandContainer()
        {
            FieldCounts = new Dictionary<ResultCommandType, int>();
            GUIInput_methods = new Dictionary<ResultCommandType, Action<Rect, SerializedProperty>>();
            Execute_methods = new Dictionary<ResultCommandType, Action<ResultCommandContainer, GlobalState>>();

            FieldCounts[ResultCommandType.EscaperStateChange] = 4;
            GUIInput_methods[ResultCommandType.EscaperStateChange] = (rect, property) =>
            {
                DrawPropertyList( rect, property, new[]
                {
                    nameof(command_type),
                    nameof(player_alias),
                    nameof(EscaperStateType),
                    nameof(change_value)
                } );
            };
            Execute_methods[ResultCommandType.EscaperStateChange] = (container, state) =>
            {
                ((Escaper)state.m_playerInfos
                        [container.player_alias]).
                    m_states[container.EscaperStateType] += container.change_value;
            };

            FieldCounts[ResultCommandType.StoryUnlock] = 2;
            GUIInput_methods[ResultCommandType.StoryUnlock] = (rect, property) =>
            {
                DrawPropertyList( rect, property, new[]
                {
                    nameof(command_type),
                    nameof(story_name)
                } );
            };

        }

        public ResultCommandType command_type;

        public PlayerAlias player_alias;
        public EscaperStateType EscaperStateType;
        public int change_value;
        public string story_name;
    }



}
