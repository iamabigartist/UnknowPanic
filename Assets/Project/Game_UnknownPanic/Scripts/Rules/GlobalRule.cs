namespace Game_UnknownPanic.Rules
{
    public static class GlobalRule
    {

        public enum PlayerIdentity
        {
            Lamb,
            Wolf
        }

        public enum PlayerAlias
        {
            A, B, C
        }

        public enum LieInformationType
        {
            A,
            B,
            A_B,
            B_A,
            A_B_A,
            B_A_B
        }

        public class LieInformation
        {
            public LieInformationType m_lieInformationType;
            public PlayerIdentity m_referringPlayerIdentity;
        }


        public enum PlayerEnding
        {
            Survive,
            Die
        }

        public enum StoryPart
        {
            BeforeKey,
            AfterKey
        }

        public enum DeadPerson
        {
            Me,
            TheOther
        }

        public static PlayerIdentity InvId(PlayerIdentity identity)
        {
            return (PlayerIdentity)(identity == 0 ? 1 : 0);
        }

        public static DeadPerson? GetDeadPerson(PlayerAlias me, PlayerAlias? dead_player)
        {
            if (dead_player == null)
            {
                return null;
            }
            return me == dead_player ? DeadPerson.Me : DeadPerson.TheOther;
        }

        public static PlayerEnding GetEscaperEnding(
            PlayerIdentity identity,
            PlayerIdentity other_identity,
            DeadPerson? dead_person,
            StoryPart story_part)
        {
            return dead_person switch
            {
                DeadPerson.Me
                    => PlayerEnding.Die,
                DeadPerson.TheOther when story_part == StoryPart.BeforeKey
                    => identity == PlayerIdentity.Lamb ? PlayerEnding.Die : PlayerEnding.Survive,
                DeadPerson.TheOther when story_part == StoryPart.AfterKey
                    => other_identity == PlayerIdentity.Lamb ? PlayerEnding.Die : PlayerEnding.Survive,
                _
                    => other_identity == PlayerIdentity.Lamb ? PlayerEnding.Survive : PlayerEnding.Die
            };
        }

        public static (PlayerEnding ending_a, PlayerEnding ending_b, PlayerEnding ending_c)
            GetGameEnding(
                StoryPart story_part,
                PlayerIdentity identity_a,
                PlayerIdentity identity_b,
                PlayerAlias c_teammate,
                PlayerAlias? dead_player)
        {

            (PlayerEnding ending_a, PlayerEnding ending_b, PlayerEnding ending_c) result;

            result.ending_a = GetEscaperEnding(
                identity_a, identity_b, GetDeadPerson( PlayerAlias.A, dead_player ), story_part );

            result.ending_b = GetEscaperEnding(
                identity_b, identity_a, GetDeadPerson( PlayerAlias.B, dead_player ), story_part );

            result.ending_c = c_teammate == PlayerAlias.A ? result.ending_a : result.ending_b;
            return result;
        }
    }
}
