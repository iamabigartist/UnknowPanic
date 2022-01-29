using System.Collections.Generic;
using Game_UnknownPanic.Objects;
using UnityEngine;
using static Game_UnknownPanic.Rules.EscaperRules;
using static Game_UnknownPanic.Rules.GlobalRule;
using static MUtils.RandomUtils;
namespace Game_UnknownPanic.GameProcess
{
    public class GlobalState
    {
        public PlayerAlias c_teammate;
        public Dictionary<LieInformationType, PlayerIdentity> m_informations;
        public Dictionary<PlayerAlias, Player> m_playerInfos;

    #region Generate

        public void GenerateNewGame()
        {
            GenerateIdentities();
            GeneratePlayerInfo();
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

    #region Update

        public void EscaperStateChange(
            PlayerAlias escaper_name,
            EscaperStateType state_type,
            int change_value)
        {
            var escaper = (Escaper)m_playerInfos[escaper_name];
            escaper.m_states[state_type] += change_value;
            escaper.m_states[state_type] = Mathf.Clamp(
                escaper.m_states[state_type], state_range.min, state_range.max );
        }

    #endregion

    #region View

    #endregion

    }


}
