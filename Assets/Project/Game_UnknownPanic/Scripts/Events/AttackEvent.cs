using System;
using UnityEngine;
namespace Game_UnknownPanic.Events
{
    [Serializable]
    [CreateAssetMenu]
    public class AttackEvent : StoryEvent
    {
        public int monster_number;
    }
}
