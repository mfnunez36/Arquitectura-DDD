using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Perfil
    {
        public int PerfilID { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string descripcion { get; set; }

        public Nullable<bool> vigente { get; set; }

        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
