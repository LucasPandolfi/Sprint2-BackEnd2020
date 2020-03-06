using System;
using System.Collections.Generic;

namespace Senai.WebApi.DbFirst.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
