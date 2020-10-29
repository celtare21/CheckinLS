﻿using System;

namespace CheckinLS.API
{
    public readonly struct TableColumns
    {
        public string Date { get; }
        public TimeSpan OraIncepere { get; }
        public TimeSpan OraFinal { get; }
        public TimeSpan CursAlocat { get; }
        public TimeSpan PregatireAlocat { get; }
        public TimeSpan RecuperareAlocat { get; }
        public TimeSpan Total { get; }

        public TableColumns(string date, TimeSpan oraIncepere, TimeSpan oraFinal, TimeSpan cursAlocat, TimeSpan pregatireAlocat, TimeSpan recuperareAlocat, TimeSpan total) =>
                (Date, OraIncepere, OraFinal, CursAlocat, PregatireAlocat, RecuperareAlocat, Total) = (date, oraIncepere, oraFinal, cursAlocat, pregatireAlocat, recuperareAlocat, total);
    }
}
