using System;
using System.Collections.Generic;
using Game_UnknownPanic.GameProcess;
using UnityEngine;
namespace Game_UnknownPanic.Events
{
    [Serializable]
    [CreateAssetMenu]
    public class StoryEvent : ScriptableObject
    {
        public string beginning_description;
        [Tooltip( "Whether the event can be played by C" )]
        public bool is_playable;
        public int choice_situation_count;
        public string[] result_description;

        [SerializeReference]
        public List<IGameStateCommand> m_list;
    }
}
