using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Senai.WebApi.DbFirst.Domains
{
    public partial class Jogos
    {

        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string DescricaoJogo { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal? ValorJogo { get; set; }
        public int? IdEstudio { get; set; }

        public Estudios IdEstudioNavigation { get; set; }
    }
}
