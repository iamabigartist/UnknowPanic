using System.Collections.Generic;
using Game_UnknownPanic.Datas.Events;
using static Game_UnknownPanic.Rules.GlobalRule;
namespace Game_UnknownPanic.Datas.Objects
{


    public abstract class Player
    {
        public PlayerIdentity m_playerIdentity;
        protected Player(PlayerIdentity playerIdentity) { m_playerIdentity = playerIdentity; }
    }

    public class Escaper : Player
    {
        public enum StateType
        {
            Health,
            Stamina,
            Ammo,
            San
        }
        public int[] m_states;
        public Escaper(PlayerIdentity playerIdentity, int health, int stamina, int ammo, int san) : base( playerIdentity )
        {
            m_states = new int[4] { health, stamina, ammo, san };
        }
    }
    public class Consoler : Player
    {
        public List<StoryEvent> cur_cards_pool;
        public Consoler(PlayerIdentity playerIdentity) : base( playerIdentity )
        {
            cur_cards_pool = new List<StoryEvent>();
        }
    }

}
