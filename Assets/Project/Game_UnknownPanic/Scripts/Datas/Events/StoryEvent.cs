using System;
using UnityEngine;
namespace Game_UnknownPanic.Datas.Events
{
    [Serializable]
    public abstract class StoryEvent : ScriptableObject
    {
        public string beginning_description;
        [Tooltip( "Whether the event can be played by C" )]
        public bool is_playable;
        public int choice_situation_count;
        public string[] result_description;
    }
}
