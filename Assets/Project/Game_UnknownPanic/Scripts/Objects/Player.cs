using System.Collections.Generic;
using Game_UnknownPanic.Events;
using static Game_UnknownPanic.Rules.EscaperRules;
using static Game_UnknownPanic.Rules.GlobalRule;
namespace Game_UnknownPanic.Objects
{


    public abstract class Player { }

    public class Escaper : Player
    {


        public PlayerIdentity m_playerIdentity;
        public Dictionary<EscaperStateType, int> m_states;
        public Escaper(PlayerIdentity playerIdentity, int health, int stamina, int ammo, int san)
        {
            m_playerIdentity = playerIdentity;
            m_states = new Dictionary<EscaperStateType, int>()
            {
                [EscaperStateType.Health] = health,
                [EscaperStateType.Stamina] = stamina,
                [EscaperStateType.Ammo] = ammo,
                [EscaperStateType.San] = san
            };
        }
    }
    public class Consoler : Player
    {
        public List<StoryEvent> cur_cards_pool;
        public Consoler()
        {
            cur_cards_pool = new List<StoryEvent>();
        }
    }

}
