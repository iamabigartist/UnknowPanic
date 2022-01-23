using System;
using UnityEngine;
namespace UnknownPanic.Datas.Events
{
    [Serializable]
    [CreateAssetMenu]
    public class AttackEvent : StoryEvent
    {
        public int monster_number;
    }
}
