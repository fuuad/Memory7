namespace Memory
{
    /// <summary>
    /// huidige pagina die applicatie laat zien.
    /// </summary>
    public enum ApplicatiePage
    {
        /// <summary>
        /// Hoofd Menu is waar je begint.
        /// </summary>
        Hoofdmenu = 0,

        /// <summary>
        /// Nieuw Spel menu waar je een spel kan opzetten en beginnen.
        /// </summary>
        Newgame = 1,

        /// <summary>
        /// Opgeslagen Spel menu waar je een spel kan laden om verder te spelen.
        /// </summary>
        LoadGame = 2,

        /// <summary>
        /// Statistieken menu om de scores te bekijken.
        /// </summary>
        Stats = 3,

        /// <summary>
        /// Instellingen menu om de instellingen te wijzigen.
        /// </summary>
        Settings = 4,
    }
}
