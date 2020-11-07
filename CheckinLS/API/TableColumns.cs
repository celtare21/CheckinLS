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
        public string Observatii { get; }

        public TableColumns(string date, TimeSpan oraIncepere, TimeSpan oraFinal, TimeSpan cursAlocat,
                                                    TimeSpan pregatireAlocat, TimeSpan recuperareAlocat, TimeSpan total, string observatii) =>
                    (Date, OraIncepere, OraFinal, CursAlocat, PregatireAlocat, RecuperareAlocat, Total, Observatii) =
                            (date, oraIncepere, oraFinal, cursAlocat, pregatireAlocat, recuperareAlocat, total, observatii);
    }
}