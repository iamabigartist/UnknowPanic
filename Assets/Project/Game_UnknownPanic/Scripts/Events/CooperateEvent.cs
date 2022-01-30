using Game_UnknownPanic.GameProcess;
using UnityEngine;
namespace Game_UnknownPanic.Events
{
    public abstract class CooperateEvent : StoryEvent
    {

        [SerializeReference]
        [SerializeReferenceButton]
        public IGameStateCommand[] success_commands;
        [SerializeReference]
        [SerializeReferenceButton]
        public IGameStateCommand[] fail_commands;
        [SerializeReference]
        [SerializeReferenceButton]
        public IGameStateCommand[] cooperate_commands;
        [SerializeReference]
        [SerializeReferenceButton]
        public IGameStateCommand[] no_cooperate_commands;
    }
}
