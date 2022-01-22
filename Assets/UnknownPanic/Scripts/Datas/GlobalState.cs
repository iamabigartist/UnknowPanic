using UnityEngine;
using static UnknownPanic.Utils.RandomUtils;
namespace UnknownPanic.Datas
{
    public class GlobalState
    {

        PlayerIdentity[] m_knowledges;
        PlayerInfo[] m_playerInfos;

        public GlobalState() { }

    #region Generate

        void GenerateIdentities()
        {
            m_knowledges = new PlayerIdentity[7];
            m_knowledges[(int)KnowledgeType.A] = (PlayerIdentity)Random.Range( 0, 2 );
            m_knowledges[(int)KnowledgeType.A_B] = (PlayerIdentity)Random.Range( 0, 2 );
            m_knowledges[(int)KnowledgeType.A_B_A] = (PlayerIdentity)Random.Range( 0, 2 );
            int choose_same_pair = Random.Range( 0, 3 );
            m_knowledges[(int)KnowledgeType.B] =
                choose_same_pair == 0 ?
                    m_knowledges[(int)KnowledgeType.A] :
                    InvId( m_knowledges[(int)KnowledgeType.A] );
            m_knowledges[(int)KnowledgeType.B_A] =
                choose_same_pair == 1 ?
                    m_knowledges[(int)KnowledgeType.A_B] :
                    InvId( m_knowledges[(int)KnowledgeType.A_B] );
            m_knowledges[(int)KnowledgeType.B_A_B] =
                choose_same_pair == 2 ?
                    m_knowledges[(int)KnowledgeType.A_B_A] :
                    InvId( m_knowledges[(int)KnowledgeType.A_B_A] );
            m_knowledges[(int)KnowledgeType.C] =
                new[]
                {
                    m_knowledges[(int)KnowledgeType.A],
                    m_knowledges[(int)KnowledgeType.B]
                }[Random.Range( 0, 2 )];

        }


        void GeneratePlayerInfo()
        {
            m_playerInfos = new PlayerInfo[3];
            m_playerInfos[(int)PlayerAlias.A] = new Escaper(
                m_knowledges[(int)KnowledgeType.A],
                Around( 50, 10 ),
                Around( 70, 5 ),
                Around( 30, 5 ),
                Around( 50, 10 ) );
            m_playerInfos[(int)PlayerAlias.B] = new Escaper(
                m_knowledges[(int)KnowledgeType.B],
                Around( 50, 10 ),
                Around( 70, 5 ),
                Around( 30, 5 ),
                Around( 50, 10 ) );
            m_playerInfos[(int)PlayerAlias.C] = new Consoler( m_knowledges[(int)KnowledgeType.C] );
        }

    #endregion

    #region Utils

        public static PlayerIdentity InvId(PlayerIdentity identity)
        {
            return (PlayerIdentity)(identity == 0 ? 1 : 0);
        }

    #endregion

    }


}
