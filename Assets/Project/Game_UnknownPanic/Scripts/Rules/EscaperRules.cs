namespace Game_UnknownPanic.Rules
{
    public static class EscaperRules
    {
        public enum EscaperStateType
        {
            Health,
            Stamina,
            Ammo,
            San
        }

        /// <summary>
        ///     The state bottom and capacity of a escaper
        /// </summary>
        public static readonly (int min, int max) state_range = (0, 100);
    }
}
