using System;
using Game_UnknownPanic.GameProcess;
using UnityEngine;
namespace Game_UnknownPanic.Events
{
    [Serializable]
    [CreateAssetMenu]
    public abstract class StoryEvent : ScriptableObject
    {
        public string beginning_description;
        [Tooltip( "Whether the event can be played by C" )]
        public bool is_playable;
        public string[] result_descriptions;
        public abstract void ExecuteResult();
    }
}
