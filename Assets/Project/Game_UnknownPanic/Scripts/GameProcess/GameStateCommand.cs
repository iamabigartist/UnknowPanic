using System;
using System.Diagnostics;
using Game_UnknownPanic.Objects;
using Game_UnknownPanic.Rules;
using UnityEngine;
using static Game_UnknownPanic.Rules.EscaperRules;
namespace Game_UnknownPanic.GameProcess
{
    public interface IGameStateCommand
    {
        public void Execute(ref GameState state);
    }

    [Serializable]
    public class EscaperStateChange : IGameStateCommand
    {
        public GlobalRules.PlayerAlias escaper_name;
        public EscaperStateType state_type;
        public int change_value;
        public void Execute(ref GameState state)
        {
            Trace.Assert( escaper_name != GlobalRules.PlayerAlias.C );
            var escaper = (Escaper)state.m_playerInfos[escaper_name];
            escaper.m_states[state_type] += change_value;
            escaper.m_states[state_type] = Mathf.Clamp(
                escaper.m_states[state_type], state_range.min, state_range.max );
        }
    }

}
