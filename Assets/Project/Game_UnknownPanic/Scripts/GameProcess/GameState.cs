using System.Collections.Generic;
using Game_UnknownPanic.Objects;
using UnityEngine;
using static Game_UnknownPanic.Rules.GlobalRules;
using static MUtils.RandomUtils;
namespace Game_UnknownPanic.GameProcess
{
    public class GameState
    {
    #region Model

    #region Players

        public PlayerAlias c_teammate;
        public Dictionary<LieInformationType, PlayerIdentity> m_informations;
        public Dictionary<PlayerAlias, Player> m_playerInfos;

    #endregion

    #region Story

        public bool key_found;

    #endregion

    #endregion

    #region Generate

        public void GenerateNewGame()
        {
            GenerateBuilding();
            GenerateIdentities();
            GeneratePlayerInfo();
        }

        void GenerateBuilding()
        {
            key_found = false;
        }

        void GenerateIdentities()
        {
            int choose_same_pair = Random.Range( 0, 3 );
            m_informations = new Dictionary<LieInformationType, PlayerIdentity>
            {
                [LieInformationType.A] = (PlayerIdentity)Random.Range( 0, 2 ),
                [LieInformationType.A_B] = (PlayerIdentity)Random.Range( 0, 2 ),
                [LieInformationType.A_B_A] = (PlayerIdentity)Random.Range( 0, 2 ),
                [LieInformationType.B] =
                    choose_same_pair == 0 ?
                        m_informations[LieInformationType.A] :
                        InvId( m_informations[LieInformationType.A] ),
                [LieInformationType.B_A] =
                    choose_same_pair == 1 ?
                        m_informations[LieInformationType.A_B] :
                        InvId( m_informations[LieInformationType.A_B] ),
                [LieInformationType.B_A_B] =
                    choose_same_pair == 2 ?
                        m_informations[LieInformationType.A_B_A] :
                        InvId( m_informations[LieInformationType.A_B_A] )
            };

            c_teammate = Random.Range( 0, 2 ) == 0 ? PlayerAlias.A : PlayerAlias.B;

        }

        void GeneratePlayerInfo()
        {
            m_playerInfos = new Dictionary<PlayerAlias, Player>
            {
                [PlayerAlias.A] = new Escaper(
                    m_informations[LieInformationType.A],
                    Around( 50, 10 ),
                    Around( 70, 5 ),
                    Around( 30, 5 ),
                    Around( 50, 10 ) ),
                [PlayerAlias.B] = new Escaper(
                    m_informations[LieInformationType.B],
                    Around( 50, 10 ),
                    Around( 70, 5 ),
                    Around( 30, 5 ),
                    Around( 50, 10 ) ),
                [PlayerAlias.C] = new Consoler()
            };
        }

    #endregion

    #region View

    #endregion

    }


}
