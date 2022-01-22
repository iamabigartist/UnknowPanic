using System.Collections.Generic;
using UnknownPanic.Datas.Events;
namespace UnknownPanic.Datas
{
    public enum PlayerAlias
    {
        A, B, C
    }

    public enum KnowledgeType
    {
        A,
        B,
        C,
        A_B,
        B_A,
        A_B_A,
        B_A_B
    }

    public class Knowledge
    {
        public KnowledgeType m_knowledgeType;
        public PlayerIdentity m_referringPlayerIdentity;
    }

    public enum PlayerIdentity
    {
        Lamb,
        Wolf
    }

    public abstract class PlayerInfo
    {
        public PlayerIdentity m_playerIdentity;
        protected PlayerInfo(PlayerIdentity playerIdentity) { m_playerIdentity = playerIdentity; }
    }

    public class Escaper : PlayerInfo
    {
        public enum StateType
        {
            Health,
            Stamina,
            Ammo,
            San
        }
        int[] m_states;
        public Escaper(PlayerIdentity playerIdentity, int health, int stamina, int ammo, int san) : base( playerIdentity )
        {
            m_states = new int[4] { health, stamina, ammo, san };
        }
    }
    public class Consoler : PlayerInfo
    {
        List<StoryEvent> cur_cards_pool;
        public Consoler(PlayerIdentity playerIdentity) : base( playerIdentity )
        {
            cur_cards_pool = new List<StoryEvent>();
        }


    }

}
