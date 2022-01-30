using System;
using Game_UnknownPanic.GameProcess;
using UnityEngine;
namespace Game_UnknownPanic.Events
{
    [Serializable]
    [CreateAssetMenu]
    public class AttackEvent : StoryEvent
    {
        public int monster_number;

        [SerializeReference]
        [SerializeReferenceButton]
        public IGameStateCommand[] result_commands;
        public override void ExecuteResult() { throw new NotImplementedException(); }
    }
}
