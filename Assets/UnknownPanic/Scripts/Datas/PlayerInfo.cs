namespace UnknownPanic.Datas
{
    public enum KnowledgeType
    {
        A,
        B,
        A_B,
        B_A,
        A_B_A,
        B_A_B,
        C
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
    }
    public class Consoler : PlayerInfo
    {

    }

}
