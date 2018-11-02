namespace Memory
{
    /// <summary>
    /// huidige pagina die applicatie laat zien.
    /// </summary>
    public enum ApplicatiePage
    {
        Mainwindow = 0,
        /// <summary>
        /// Hoofd Menu is waar je begint.
        /// </summary>
        Hoofdmenu = 1,

        /// <summary>
        /// Nieuw Spel menu waar je een spel kan opzetten en beginnen.
        /// </summary>
        Newgame = 2,

        /// <summary>
        /// Opgeslagen Spel menu waar je een spel kan laden om verder te spelen.
        /// </summary>
        LoadGame = 3,

        /// <summary>
        /// Statistieken menu om de scores te bekijken.
        /// </summary>
        Stats = 4,
    }
}
